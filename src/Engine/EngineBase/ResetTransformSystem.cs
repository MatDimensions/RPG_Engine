using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Engine
{
	public class ResetTransformSystem : IEcsPostRunSystem
	{
		public void PostRun(IEcsSystems systems)
		{
			foreach (int entity in m_transformFilter.Value)
			{
				ref TransformComponent transform = ref m_transformPool.Value.Get(entity);
				if (transform.HasMoved)
					transform.HasMoved = false;
			}
		}

		EcsFilterInject<Inc<TransformComponent>> m_transformFilter;
		EcsPoolInject<TransformComponent> m_transformPool;
	}
}
