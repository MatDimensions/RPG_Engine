using SFML.System;
using System.Runtime.Remoting;

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
			writer.Write(Collider.GetType().UnderlyingSystemType.FullName);
		}

		public override void Deserialize(BinaryReader reader)
		{
			CenterOffset.X = reader.ReadSingle();
			CenterOffset.Y = reader.ReadSingle();
			Radius = reader.ReadSingle();
			string typeName = reader.ReadString();
			ObjectHandle? oh = Activator.CreateInstance(null, typeName);
			Collider = (ICollider)oh.Unwrap();
		}

		public override void InitComponent(ref CircularCollisionComponent component)
		{
			component.CenterOffset = CenterOffset;
			component.Radius = Radius;
			component.Collider = Collider;
			component.IsColliding = false;
		}
	}
}
