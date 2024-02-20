namespace Engine
{
	public class AnimatedDebugEnityConfig : EntityConfig
	{
		public TransformComponentConfig TransformConfig = new();
		public RendererComponentConfig RendererConfig = new();
		public MultiAnimationComponentConfig AnimationConfig = new MultiAnimationComponentConfig(EngineConfig.DebugAnimDirectory, EngineConfig.DebugAnimDefinitionFile, true);
	}
}
