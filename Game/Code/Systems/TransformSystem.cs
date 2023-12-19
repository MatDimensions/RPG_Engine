using Engine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

public class TransformSystem : IEcsRunSystem
{
	public void Run(IEcsSystems systems)
	{
		foreach (int entity in m_rendererFilter.Value)
		{
			ref TransformComponent transform = ref m_transformPool.Value.Get(entity);
			transform.Position += new SFML.System.Vector2f((float)Math.Cos((double)DateTime.Now.Ticks), 0f);
		}
	}

	//private EcsWorldInject m_world;

	private EcsFilterInject<Inc<TransformComponent, RendererComponent>> m_rendererFilter;
	private EcsPoolInject<TransformComponent> m_transformPool;
	//private EcsPoolInject<RendererComponent> m_rendererPool;
}
