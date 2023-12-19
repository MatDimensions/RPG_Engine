using SFML.Graphics;

namespace Engine
{
	public struct RendererComponent
	{
		public Sprite Sprite;
		public Shader Shader;
		public BlendMode BlendMode;
		public bool IsTerrain;
		public bool IsStatic;
	}
}
