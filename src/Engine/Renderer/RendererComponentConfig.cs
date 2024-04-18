using SFML.Graphics;

namespace Engine
{
	public class RendererComponentConfig : ComponentConfig<RendererComponent>
	{
		public Sprite Sprite = null;
		public Shader Shader = null;
		public BlendMode BlendMode = BlendMode.Alpha;
		public int Layer;
		public bool IsTerrain = false;

		public RendererComponentConfig() : this(SpriteUtility.GetSprite(EngineConfig.DebugSprite), BlendMode.Alpha) { }

		public RendererComponentConfig(
			Sprite sprite,
			BlendMode blendMode,
			Shader shader = null,
			bool isTerrain = false,
			int layer = 0)
		{
			Sprite = sprite;
			BlendMode = blendMode;
			Shader = shader;
			IsTerrain = isTerrain;
			Layer = layer;
		}

		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(SpriteUtility.GetSpriteName(Sprite));
			writer.Write(ShaderUtility.GetShaderName(Shader));
			writer.Write((int)BlendMode.ColorSrcFactor);
			writer.Write((int)BlendMode.ColorDstFactor);
			writer.Write((int)BlendMode.ColorEquation);
			writer.Write((int)BlendMode.AlphaSrcFactor);
			writer.Write((int)BlendMode.AlphaDstFactor);
			writer.Write((int)BlendMode.AlphaEquation);
			writer.Write(IsTerrain);
			writer.Write(Layer);
		}

		public override void Deserialize(BinaryReader reader)
		{
			Sprite = SpriteUtility.GetSprite(reader.ReadString());
			Shader = ShaderUtility.GetShader(reader.ReadString());
			BlendMode = new BlendMode(
				(BlendMode.Factor)reader.ReadInt32(),
				(BlendMode.Factor)reader.ReadInt32(),
				(BlendMode.Equation)reader.ReadInt32(),
				(BlendMode.Factor)reader.ReadInt32(),
				(BlendMode.Factor)reader.ReadInt32(),
				(BlendMode.Equation)reader.ReadInt32());
			IsTerrain = reader.ReadBoolean();
			Layer = reader.ReadInt32();
		}

		public override void InitComponent(ref RendererComponent component)
		{
			component.Sprite = Sprite;
			component.Shader = Shader;
			component.BlendMode = BlendMode;
			component.Layer = Layer;
			component.IsTerrain = IsTerrain;
			component.IsRegistered = false;
		}
	}
}
