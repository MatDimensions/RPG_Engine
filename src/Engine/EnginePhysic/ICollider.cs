using Leopotam.EcsLite;

namespace Engine
{
	public interface ICollider
	{
		public void Collide(ref EcsPackedEntityWithWorld currentEntity, ref EcsPackedEntityWithWorld otherEntity);
	}
}
