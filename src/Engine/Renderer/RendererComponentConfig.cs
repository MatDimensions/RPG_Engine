using SFML.Graphics;

namespace Engine
{
	public class RendererComponentConfig : ComponentConfig<RendererComponent>
	{
		public Sprite Sprite = null;
		public Shader Shader = null;
		public BlendMode BlendMode = BlendMode.Alpha;
		public bool IsTerrain = false;
		public bool IsStatic = false;

		public RendererComponentConfig() : this(SpriteUtility.GetSprite(EngineConfig.DebugSprite), BlendMode.Alpha) { }

		public RendererComponentConfig(
			Sprite sprite,
			BlendMode blendMode,
			Shader shader = null,
			bool isTerrain = false,
			bool isStatic = false)
		{
			Sprite = sprite;
			BlendMode = blendMode;
			Shader = shader;
			IsTerrain = isTerrain;
			IsStatic = isStatic;
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
			writer.Write(IsStatic);
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
			IsStatic = reader.ReadBoolean();
		}

		public override void InitComponent(ref RendererComponent component)
		{
			component.Sprite = Sprite;
			component.Shader = Shader;
			component.BlendMode = BlendMode;
			component.IsTerrain = IsTerrain;
			component.IsStatic = IsStatic;
		}
	}
}
