using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SFML.System;
using SFML.Window;

namespace Engine
{
	public class EnginePreRunSystem : IEcsRunSystem
	{
		public void Run(IEcsSystems systems)
		{
			Debug.WriteOnFile();

			InputUtility.Run();
		}
	}
}
