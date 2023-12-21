using SFML.System;

namespace Engine
{
	public class TransformComponentConfig : ComponentConfig<TransformComponent>
	{
		public Vector2f Position;
		public float Rotation;
		public float Scale;

		public TransformComponentConfig() : this(new Vector2f(0f, 0f)) { }

		public TransformComponentConfig(
			Vector2f position,
			float rotation = 0f,
			float scale = 1f)
		{
			Position = position;
			Rotation = rotation;
			Scale = scale;
		}

		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(Position.X);
			writer.Write(Position.Y);
			writer.Write(Rotation);
			writer.Write(Scale);
		}

		public override void Deserialize(BinaryReader reader)
		{
			Position.X = reader.ReadSingle();
			Position.Y = reader.ReadSingle();
			Rotation = reader.ReadSingle();
			Scale = reader.ReadSingle();
		}

		public override void InitComponent(ref TransformComponent component)
		{
			component.Position = Position;
			component.Rotation = Rotation;
			component.Scale = Scale;
		}
	}
}
