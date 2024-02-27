namespace Engine
{
	public class CollisionDebugEntityConfig : EntityConfig
	{
		public TransformComponentConfig transformComponentConfig = new();
		public RendererComponentConfig rendererComponentConfig = new();
		public CircularCollisionComponentConfig circularCollisionComponentConfig = new();
	}
}
