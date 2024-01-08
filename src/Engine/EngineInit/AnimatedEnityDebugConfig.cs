namespace Engine
{
	public class AnimatedEnityDebugConfig : EntityConfig
	{
		public TransformComponentConfig TransformConfig = new();
		public RendererComponentConfig RendererConfig = new();
		public TimedAnimationComponentConfig AnimationConfig = new TimedAnimationComponentConfig(EngineConfig.DebugAnimDirectory, EngineConfig.DebugAnimDefinitionFile, true);
	}
}
