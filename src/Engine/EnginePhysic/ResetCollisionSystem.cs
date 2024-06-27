using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
	public class ResetCollisionSystem : IEcsPostRunSystem
	{
		public void PostRun(IEcsSystems systems)
		{
			foreach (int collideEntity in m_collideFilter.Value)
			{
				m_world.Value.DelEntity(collideEntity);
			}

			foreach (int entity in m_circularFilter.Value)
			{
				ref CircularCollisionComponent circularCollisionComp = ref m_circularCollisionPool.Value.Get(entity);
				circularCollisionComp.IsColliding = false;
			}
		}

		private EcsWorldInject m_world;

		private EcsFilterInject<Inc<CollideComponent>> m_collideFilter;
		private EcsFilterInject<Inc<TransformComponent, CircularCollisionComponent>> m_circularFilter;

		private EcsPoolInject<CircularCollisionComponent> m_circularCollisionPool;
	}
}
