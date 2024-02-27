using Leopotam.EcsLite;

namespace Engine.Colliders
{
	public class DebugCollider : ICollider
	{
		public void Collide(ref EcsPackedEntityWithWorld currentEntity, ref EcsPackedEntityWithWorld otherEntity)
		{
			if (currentEntity.Unpack(out EcsWorld _, out int entity)
				&& otherEntity.Unpack(out EcsWorld _, out int entity2))
				Debug.Log("Collision !!!!");
		}
	}
}
