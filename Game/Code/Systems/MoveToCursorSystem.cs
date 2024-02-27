using Engine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SFML.Window;

public class MoveToCursorSystem : IEcsRunSystem
{
	public void Run(IEcsSystems systems)
	{
		foreach (int entity in m_filter.Value)
		{
			ref TransformComponent transform = ref m_transformPool.Value.Get(entity);
			transform.Position = Camera.ScreenToWorld(Mouse.GetPosition(EngineData.Window));
		}
	}

	private EcsFilterInject<Inc<FollowCursorComponent, TransformComponent>> m_filter;
	private EcsPoolInject<TransformComponent> m_transformPool;
}
