using Leopotam.EcsLite;

namespace Engine
{
	internal interface ComponentConfigBase
	{
		public abstract void AddComponent(EcsWorld world, int entity);
		public abstract void Serialize(BinaryWriter writer);
		public abstract void Deserialize(BinaryReader reader);
	}

	public abstract class ComponentConfig<T> : ComponentConfigBase where T : struct
	{
		public void AddComponent(EcsWorld world, int entity)
		{
			EcsPool<T> pool = world.GetPool<T>();
			ref T component = ref pool.Add(entity);
			InitComponent(ref component);
		}

		public abstract void Serialize(BinaryWriter writer);

		public abstract void Deserialize(BinaryReader reader);

		public abstract void InitComponent(ref T component);
	}
}
