using Leopotam.EcsLite;
using System.Reflection;

namespace Engine
{
	public class EntityConfig
	{
		public int CreateEntity(EcsWorld world)
		{
			int entity = world.NewEntity();
			FieldInfo[] fieldsInfo = this.GetType().UnderlyingSystemType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

			foreach (FieldInfo field in fieldsInfo)
			{
				if (typeof(ComponentConfigBase).IsAssignableFrom(field.FieldType))
				{
					ComponentConfigBase configBase = (ComponentConfigBase)field.GetValue(this);
					configBase.AddComponent(world, entity);
				}
			}

			return entity;
		}

		public void LoadFromFile(string file)
		{
#if DEBUG
			if (!File.Exists(file))
			{
				Debug.LogError(LOAD_ERROR + file);
				return;
			}
#endif
			using FileStream fileStream = File.OpenRead(file);
			using BinaryReader br = new BinaryReader(fileStream);

			string fieldName = "";
			int componentsNumber = br.ReadInt32();
			Type underlyingType = this.GetType().UnderlyingSystemType;
			for (int i = 0; i < componentsNumber; ++i)
			{
				fieldName = br.ReadString();
				ComponentConfigBase config = (ComponentConfigBase)underlyingType.GetField(fieldName).GetValue(this);
				config.Deserialize(br);
			}
		}

		public void SaveOnFile(string file)
		{
			using FileStream fileStream = File.OpenWrite(file);
			using BinaryWriter bw = new BinaryWriter(fileStream);

			FieldInfo[] fieldInfos = this.GetType().UnderlyingSystemType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
			bw.Write(fieldInfos.Length);
			foreach (FieldInfo field in fieldInfos)
			{
				ComponentConfigBase configBase = (ComponentConfigBase)field.GetValue(this);
				bw.Write(field.Name);
				configBase.Serialize(bw);
			}
		}

#if DEBUG
		private const string LOAD_ERROR = "Try to load an entityConfig from a file than doesn't exist : ";
#endif
	}
}
