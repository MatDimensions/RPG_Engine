using SFML.Graphics;

namespace Engine
{
	public struct RendererComponent
	{
		public Sprite Sprite;
		public Shader Shader;
		public BlendMode BlendMode;
		public int Layer;
		public bool IsTerrain;
		internal bool IsRegistered;
	}
}
