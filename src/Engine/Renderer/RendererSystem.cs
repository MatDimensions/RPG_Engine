using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SFML.Graphics;
using SFML.System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Engine
{
	public class RendererSystem : IEcsPreInitSystem, IEcsRunSystem, IEcsDestroySystem
	{
		#region Class
		internal class RendererEcsEventListener : IEcsWorldEventListener
		{
			public RendererEcsEventListener(RendererSystem rendererSystem)
			{
				m_rendererSystem = rendererSystem;
			}

			public void OnEntityChanged(int entity) { }

			public void OnEntityCreated(int entity) { }

			public void OnEntityDestroyed(int entity)
			{
				m_rendererSystem.RemoveRenderer(entity);
			}

			public void OnFilterCreated(EcsFilter filter) { }

			public void OnWorldDestroyed(EcsWorld world) { }

			public void OnWorldResized(int newSize) { }

			private RendererSystem m_rendererSystem;
		}

		private class Layer
		{
			internal List<int> Renderers = new();
			internal List<int> SortedRenderers = new();
			internal bool IsStaticLayer = false;
			internal bool HaveToResort = false;

			internal void Add(int entity)
			{
				Renderers.Add(entity);
				if (!IsStaticLayer)
				{
					SortedRenderers.Clear();
					HaveToResort = true;
				}
			}

			internal void Remove(int entity)
			{
				Renderers.Remove(entity);
				SortedRenderers.Remove(entity);
			}

			internal Layer(int layerLevel)
			{
				IsStaticLayer = RendererUtility.IsLayerStatic(layerLevel);
			}
		}
		#endregion //Class

		#region Public
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CloseWindow(object sender, EventArgs e)
		{
			if (sender is RenderWindow window)
			{
				EngineData.Window.Close();
			}
		}

		public void PreInit(IEcsSystems systems)
		{
			m_registeredRenderers = new Dictionary<int, int>();
			m_terrainRenderers = new List<int>();
			m_layers = new();

			m_invertVector = new Vector2f(1f, -1f);
			m_scaleVector = new Vector2f(1f, 1f);
			m_renderStates = RenderStates.Default;

			m_ecsEventListener = new RendererEcsEventListener(this);

			m_world.Value.AddEventListener(m_ecsEventListener);
		}

		public void Run(IEcsSystems systems)
		{
#if DEBUG
			if (EngineConfig.DisplayOnlyCollisions)
			{
				EngineData.Window.Clear();

				Sprite sprite = null;
				sprite = SpriteUtility.GetSprite(EngineConfig.CircularCollisionSprite);

				m_renderStates.Shader = ShaderUtility.GetShader(EngineConfig.CollisionShader);
				m_renderStates.BlendMode = BlendMode.Alpha;

				foreach (int entity in m_circleCollisionFilter.Value)
				{
					ref CircularCollisionComponent collisionComp = ref m_circleCollisionPool.Value.Get(entity);
					ref TransformComponent transform = ref m_transformPool.Value.Get(entity);

					sprite.Position = Camera.WorldToScreen((transform.Position + collisionComp.CenterOffset) * m_invertVector);
					m_scaleVector.X = transform.Scale * collisionComp.Radius / 175;
					m_scaleVector.Y = transform.Scale * collisionComp.Radius / 175;
					sprite.Scale = m_scaleVector;

					EngineData.Window.Draw(sprite, m_renderStates);
				}

				EngineData.Window.Display();
				return;
			}
#endif

			foreach (int entity in m_rendererFilter.Value)
			{
				ref RendererComponent rendererComp = ref m_rendererPool.Value.Get(entity);
				ref TransformComponent transform = ref m_transformPool.Value.Get(entity);

				if (rendererComp.IsTerrain && !rendererComp.IsRegistered)
				{
					AddTerrainRenderer(entity, ref transform);
					rendererComp.IsRegistered = true;
				}
				else if (!rendererComp.IsTerrain)
				{
					if (!rendererComp.IsRegistered)
					{
						AddRenderer(entity, ref rendererComp, ref transform);
						rendererComp.IsRegistered = true;
					}
					if (!m_layers[rendererComp.Layer].IsStaticLayer)
						m_layers[rendererComp.Layer].HaveToResort |= transform.HasMoved;
				}
			}

			CheckLayers();

			EngineData.Window.Clear();

			//Draw terrain
			foreach (int entity in m_terrainRenderers)
			{
				DisplayRenderer(ref m_rendererPool.Value.Get(entity), ref m_transformPool.Value.Get(entity), EngineData.Window);
			}

			//Draw others
			foreach (Layer layer in m_layers)
			{
				foreach (int entity in layer.SortedRenderers)
				{
					DisplayRenderer(ref m_rendererPool.Value.Get(entity), ref m_transformPool.Value.Get(entity), EngineData.Window);
				}
			}

#if DEBUG
			if (EngineConfig.DisplayCollisionsOnTopOfSprites)
			{
				Sprite sprite = null;
				sprite = SpriteUtility.GetSprite(EngineConfig.CircularCollisionSprite);

				m_renderStates.Shader = ShaderUtility.GetShader(EngineConfig.CollisionShader);
				m_renderStates.BlendMode = BlendMode.Alpha;

				foreach (int entity in m_circleCollisionFilter.Value)
				{
					ref CircularCollisionComponent collisionComp = ref m_circleCollisionPool.Value.Get(entity);
					ref TransformComponent transform = ref m_transformPool.Value.Get(entity);

					sprite.Position = Camera.WorldToScreen((transform.Position + collisionComp.CenterOffset) * m_invertVector);
					m_scaleVector.X = transform.Scale * collisionComp.Radius / 175;
					m_scaleVector.Y = transform.Scale * collisionComp.Radius / 175;
					sprite.Scale = m_scaleVector;

					EngineData.Window.Draw(sprite, m_renderStates);
				}
			}
#endif

			EngineData.Window.Display();
		}

		public void Destroy(IEcsSystems systems)
		{
			m_world.Value.RemoveEventListener(m_ecsEventListener);
		}
		#endregion //Public

		#region Private

		private void ApplyTransformOnSprite(ref RendererComponent renderer, ref TransformComponent transform)
		{
			Sprite sprite = renderer.Sprite;
			if (sprite == null)
			{
				Debug.LogError("try do apply transform on null sprite");
				return;
			}

			sprite.Position = Camera.WorldToScreen(transform.Position * m_invertVector);
			sprite.Rotation = transform.Rotation;
			m_scaleVector.X = transform.Scale * Camera.FOV;
			m_scaleVector.Y = transform.Scale * Camera.FOV;
			sprite.Scale = m_scaleVector;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int IsTerrainRendererAtCorrectIndex(
			ref TransformComponent renderer,
			ref TransformComponent previousRenderer,
			ref TransformComponent nextRenderer)
		{
			if (previousRenderer.Position.Y < renderer.Position.Y
				|| previousRenderer.Position.X > renderer.Position.X)
				return -1;
			else if (nextRenderer.Position.Y > renderer.Position.Y
				|| nextRenderer.Position.X < renderer.Position.X)
				return 1;
			else
				return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int IsRendererAtCorrectIndex(
			ref TransformComponent renderer,
			ref TransformComponent previousRenderer,
			ref TransformComponent nextRenderer)
		{
			if (previousRenderer.Position.Y < renderer.Position.Y)
			{
				return -1;
			}
			else if (nextRenderer.Position.Y > renderer.Position.Y)
			{
				return 1;
			}
			else
				return 0;
		}

		private int GetRendererInsertionPlace(
			List<int> list,
			ref TransformComponent rendererToInsert,
			SortFunction sortFunction)
		{
			if (list.Count == 0)
			{
				return 0;
			}
			ref TransformComponent previousRenderer = ref m_transformPool.Value.Get(list[0]);

			if (list.Count == 1)
			{
				if (rendererToInsert.Position.Y == previousRenderer.Position.Y)
				{
					if (rendererToInsert.Position.X < previousRenderer.Position.X)
						return 0;
					else
						return 1;
				}
				else if (rendererToInsert.Position.Y > previousRenderer.Position.Y)
					return 1;
				else
					return 0;
			}

			ref TransformComponent nextRenderer = ref m_transformPool.Value.Get(list[list.Count - 1]);
			//at place 0
			if (previousRenderer.Position.Y == rendererToInsert.Position.Y
				&& previousRenderer.Position.X <= rendererToInsert.Position.X
				|| previousRenderer.Position.Y < rendererToInsert.Position.Y)
			{
				return 0;
			}

			//at last place
			if (nextRenderer.Position.Y == rendererToInsert.Position.Y
				&& nextRenderer.Position.X >= rendererToInsert.Position.X
				|| nextRenderer.Position.Y > rendererToInsert.Position.Y)
			{
				return list.Count;
			}

			int insertionPlace = list.Count / 2;
			int isRightPlace = 1;
			int lastLastInsertionPlace = 0;
			int lastInsertionPlace = list.Count;
			int minPlace = 0;
			int maxPlace = list.Count;

			while (isRightPlace != 0)
			{
				previousRenderer = ref m_transformPool.Value.Get(list[insertionPlace - 1]);
				nextRenderer = ref m_transformPool.Value.Get(list[insertionPlace]);
				isRightPlace = sortFunction.Invoke(ref rendererToInsert, ref previousRenderer, ref nextRenderer);
				if (isRightPlace == 0)
					return insertionPlace;
				else if (isRightPlace <= -1)
				{
					maxPlace = insertionPlace;
				}
				else
				{
					minPlace = insertionPlace;
				}

				lastLastInsertionPlace = lastInsertionPlace;
				lastInsertionPlace = insertionPlace;
				insertionPlace = (minPlace + maxPlace) / 2;
				insertionPlace = insertionPlace == 0 ? 1 : insertionPlace;

				if (lastLastInsertionPlace == insertionPlace)
					return insertionPlace;
			}

			throw new Exception("No place for renderer found");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AddTerrainRenderer(int entity, ref TransformComponent transform)
		{
			int place = GetRendererInsertionPlace(m_terrainRenderers, ref transform, IsTerrainRendererAtCorrectIndex);
			m_terrainRenderers.Insert(place, entity);
		}

		private void AddRenderer(int entity, ref RendererComponent renderer, ref TransformComponent transform)
		{
			while (m_layers.Count - 1 <= renderer.Layer)
			{
				m_layers.Add(new Layer(m_layers.Count));
			}

			m_layers[renderer.Layer].Add(entity);

			if (m_layers[renderer.Layer].IsStaticLayer)
			{
				int place = GetRendererInsertionPlace(m_layers[renderer.Layer].SortedRenderers, ref transform, IsRendererAtCorrectIndex);
				m_layers[renderer.Layer].SortedRenderers.Insert(place, entity);
			}

			m_registeredRenderers.Add(entity, renderer.Layer);
		}

		private void CheckLayers()
		{
			for (int i = 0; i < m_layers.Count; i++)
			{
				Layer layer = m_layers[i];
				bool haveToBeStatic = RendererUtility.IsLayerStatic(i);
				if (haveToBeStatic && !layer.IsStaticLayer)
					layer.IsStaticLayer = haveToBeStatic;
				else if (!haveToBeStatic && layer.IsStaticLayer)
				{
					layer.HaveToResort = true;
					layer.IsStaticLayer = haveToBeStatic;
				}

				SortLayer(layer);
			}
		}

		private void SortLayer(Layer layer)
		{
			if (layer.HaveToResort)
			{
				layer.SortedRenderers.Clear();
				int place;

				foreach (int entity in layer.Renderers)
				{
					place = GetRendererInsertionPlace(layer.SortedRenderers, ref m_transformPool.Value.Get(entity), IsRendererAtCorrectIndex);
					layer.SortedRenderers.Insert(place, entity);
				}
				layer.HaveToResort = false;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RemoveRenderer(int entity)
		{
			if (m_terrainRenderers.Contains(entity))
				m_terrainRenderers.Remove(entity);
			else if (m_registeredRenderers.ContainsKey(entity))
			{
				m_layers[m_registeredRenderers[entity]].Remove(entity);
				m_registeredRenderers.Remove(entity);
			}
		}

		private void DisplayRenderer(ref RendererComponent renderer, ref TransformComponent transform, RenderWindow window)
		{
			Sprite sprite = renderer.Sprite;
			if (sprite == null)
			{
				Debug.LogError("try do display null sprite");
				return;
			}

			ApplyTransformOnSprite(ref renderer, ref transform);

			m_renderStates.Shader = renderer.Shader;
			m_renderStates.BlendMode = renderer.BlendMode;

			window.Draw(sprite, m_renderStates);
		}
		#endregion

		#region Fields
		#region DisplayCollisions
#if DEBUG
		private EcsFilterInject<Inc<TransformComponent, CircularCollisionComponent>> m_circleCollisionFilter;
		private EcsPoolInject<CircularCollisionComponent> m_circleCollisionPool;
#endif
		#endregion

		private EcsWorldInject m_world;

		private EcsFilterInject<Inc<TransformComponent, RendererComponent>> m_rendererFilter;
		private EcsPoolInject<TransformComponent> m_transformPool;
		private EcsPoolInject<RendererComponent> m_rendererPool;

		private RendererEcsEventListener m_ecsEventListener;

		private Dictionary<int, int> m_registeredRenderers;
		private List<int> m_terrainRenderers;

		private List<Layer> m_layers;

		private Vector2f m_invertVector;
		private Vector2f m_scaleVector;
		private RenderStates m_renderStates;

		private delegate int SortFunction(ref TransformComponent component, ref TransformComponent previous, ref TransformComponent next);
		#endregion //Fields
	}
}
