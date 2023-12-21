namespace Engine
{
	public class AnimatedEnityDebugConfig : EntityConfig
	{
		public TransformComponentConfig TransformConfig = new();
		public RendererComponentConfig RendererConfig = new();
		public AnimationComponentConfig AnimationConfig = new AnimationComponentConfig(EngineConfig.DebugAnimDirectory, EngineConfig.DebugAnimDefinitionFile, true);
	}
}
