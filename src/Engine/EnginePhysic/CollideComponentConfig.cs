namespace Engine
{
	public class CollideComponentConfig : ComponentConfig<CollideComponent>
	{
		public override void InitComponent(ref CollideComponent component) { }
		public override void Serialize(BinaryWriter writer) { }
		public override void Deserialize(BinaryReader reader) { }
	}
}
