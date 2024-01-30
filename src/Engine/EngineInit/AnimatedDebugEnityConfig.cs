namespace Engine
{
	public class AnimatedDebugEnityConfig : EntityConfig
	{
		public TransformComponentConfig TransformConfig = new();
		public RendererComponentConfig RendererConfig = new();
		public TimedAnimationComponentConfig AnimationConfig = new TimedAnimationComponentConfig(EngineConfig.DebugAnimDirectory, EngineConfig.DebugAnimDefinitionFile, true);
	}
}
