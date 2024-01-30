namespace Engine
{
	public class DebugEntityConfig : EntityConfig
	{
		public TransformComponentConfig TransformConfig = new();
		public RendererComponentConfig RendererConfig = new();
	}
}
