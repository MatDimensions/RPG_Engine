using SFML.System;

namespace Engine
{
	public class CircularCollisionComponentConfig : ComponentConfig<CircularCollisionComponent>
	{
		public Vector2f CenterOffset;
		public float Radius;
		public ICollider Collider;

		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(CenterOffset.X);
			writer.Write(CenterOffset.Y);
			writer.Write(Radius);
		}

		public override void Deserialize(BinaryReader reader)
		{
			CenterOffset.X = reader.ReadSingle();
			CenterOffset.Y = reader.ReadSingle();
			Radius = reader.ReadSingle();
		}

		public override void InitComponent(ref CircularCollisionComponent component)
		{
			component.CenterOffset = CenterOffset;
			component.Radius = Radius;
			component.IsColliding = false;
		}
	}
}
