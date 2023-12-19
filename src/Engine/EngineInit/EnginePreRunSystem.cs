using Leopotam.EcsLite;

namespace Engine
{
	public class EnginePreRunSystem : IEcsRunSystem
	{
		public void Run(IEcsSystems systems)
		{
			Debug.WriteOnFile();
		}
	}
}
