using Leopotam.EcsLite;

namespace Engine
{
	internal interface ComponentConfigBase
	{
		public abstract void AddComponent(EcsWorld world, int entity);
		public abstract void Serialize(BinaryWriter writer);
		public abstract void Deserialize(BinaryReader reader);
	}

	public class ComponentConfig<T> : ComponentConfigBase where T : struct
	{
		public void AddComponent(EcsWorld world, int entity)
		{
			EcsPool<T> pool = world.GetPool<T>();
			ref T component = ref pool.Add(entity);
			InitComponent(ref component);
		}

		public virtual void Serialize(BinaryWriter writer)
		{
			throw new NotImplementedException("Serialize of " + this.GetType().UnderlyingSystemType.Name + " isn't implemented");
		}

		public virtual void Deserialize(BinaryReader reader)
		{
			throw new NotImplementedException("Deserialize of " + this.GetType().UnderlyingSystemType.Name + " isn't implemented");
		}

		public virtual void InitComponent(ref T component)
		{

		}
	}
}
