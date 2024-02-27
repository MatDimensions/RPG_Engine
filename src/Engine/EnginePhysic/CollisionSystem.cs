using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using System.Runtime.CompilerServices;

namespace Engine
{
	public class CollisionSystem : IEcsRunSystem
	{
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
						EcsPackedEntityWithWorld firstEntityPacked = m_world.Value.PackEntityWithWorld(entities[i]);
						EcsPackedEntityWithWorld secondEntityPacked = m_world.Value.PackEntityWithWorld(entities[j]);
						firstCircularCollisionComp.Collider.Collide(ref firstEntityPacked, ref secondEntityPacked);
						secondCircularCollisionComp.Collider.Collide(ref secondEntityPacked, ref firstEntityPacked);
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
	}
}
