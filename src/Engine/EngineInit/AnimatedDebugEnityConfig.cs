namespace Engine
{
	public class AnimatedDebugEnityConfig : EntityConfig
	{
		public TransformComponentConfig TransformConfig = new();
		public RendererComponentConfig RendererConfig = new();
		public MultiTimedAnimationComponentConfig AnimationConfig = new MultiTimedAnimationComponentConfig(EngineConfig.DebugAnimDirectory, EngineConfig.DebugAnimDefinitionFile, true);
	}
}
