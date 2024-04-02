using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using System.Runtime.CompilerServices;

namespace Engine
{
	public class CheckCollisionSystem : IEcsInitSystem, IEcsRunSystem
	{
		public void Init(IEcsSystems systems)
		{
#if COLLIDE_ENTITY
			m_collideEntityConfig = new();
#endif
		}

		public void Run(IEcsSystems systems)
		{
			int[] entities = m_circularFilter.Value.GetRawEntities();
			int entityCount = m_circularFilter.Value.GetEntitiesCount();

			for (int i = 0; i < entityCount; i++)
			{
				ref TransformComponent firstTransformComp = ref m_transformPool.Value.Get(entities[i]);
				ref CircularCollisionComponent firstCircularCollisionComp = ref m_circularCollisionPool.Value.Get(entities[i]);
				for (int j = i + 1; j < entityCount; j++)
				{
					ref TransformComponent secondTransformComp = ref m_transformPool.Value.Get(entities[j]);
					ref CircularCollisionComponent secondCircularCollisionComp = ref m_circularCollisionPool.Value.Get(entities[j]);

					if (IsCircularCollide(ref firstTransformComp, ref secondTransformComp, ref firstCircularCollisionComp, ref secondCircularCollisionComp))
					{
						firstCircularCollisionComp.IsColliding = true;
						secondCircularCollisionComp.IsColliding = true;
#if COLLIDE_ENTITY
						ref CollideComponent collideComp = ref m_collidePool.Value.Get(m_collideEntityConfig.CreateEntity(m_world.Value));
						collideComp.FirstEntity = m_world.Value.PackEntity(entities[i]);
						collideComp.SecondEntity = m_world.Value.PackEntity(entities[j]);
#endif
#if CALL_COLLIDER_WHEN_COLLIDE
						EcsPackedEntityWithWorld firstEntityPacked = m_world.Value.PackEntityWithWorld(entities[i]);
						EcsPackedEntityWithWorld secondEntityPacked = m_world.Value.PackEntityWithWorld(entities[j]);
						firstCircularCollisionComp.Collider?.Collide(ref firstEntityPacked, ref secondEntityPacked);
						secondCircularCollisionComp.Collider?.Collide(ref secondEntityPacked, ref firstEntityPacked);
#endif
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool IsCircularCollide(ref TransformComponent firstTansform, ref TransformComponent secondTansform, ref CircularCollisionComponent firstCollision, ref CircularCollisionComponent secondCollision)
		{
			return (firstTansform.Position.X - secondTansform.Position.X) * (firstTansform.Position.X - secondTansform.Position.X) + (firstTansform.Position.Y - secondTansform.Position.Y) * (firstTansform.Position.Y - secondTansform.Position.Y)
				<= (firstCollision.Radius * firstTansform.Scale + secondCollision.Radius * secondTansform.Scale) * (firstCollision.Radius * firstTansform.Scale + secondCollision.Radius * secondTansform.Scale);
		}

		private EcsWorldInject m_world;
		private EcsFilterInject<Inc<TransformComponent, CircularCollisionComponent>> m_circularFilter;
		private EcsPoolInject<TransformComponent> m_transformPool;
		private EcsPoolInject<CircularCollisionComponent> m_circularCollisionPool;
#if COLLIDE_ENTITY
		private EcsPoolInject<CollideComponent> m_collidePool;

		private CollideEntityConfig m_collideEntityConfig;
#endif
	}
}
