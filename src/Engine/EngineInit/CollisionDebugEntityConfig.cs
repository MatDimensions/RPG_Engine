namespace Engine
{
	public class CollisionDebugEntityConfig : EntityConfig
	{
		public TransformComponentConfig TransformComponentConfig = new();
		public RendererComponentConfig RendererComponentConfig = new();
		public CircularCollisionComponentConfig CircularCollisionComponentConfig = new();
	}
}
