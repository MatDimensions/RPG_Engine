using Engine.Threading;
using Leopotam.EcsLite;

namespace Engine
{
	public class EngineDestroySystem : IEcsPostDestroySystem
	{
		public void PostDestroy(IEcsSystems systems)
		{
			ThreadUtility.JoinAllThreads();
			SpriteUtility.Destroy();
			ShaderUtility.Destroy();
		}
	}
}
