using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SFML.System;
using SFML.Window;

namespace Engine
{
	public class EnginePreRunSystem : IEcsInitSystem, IEcsRunSystem
	{
		Random rand = new Random(0);
		DebugEntityConfig entityconfig;
		public void Init(IEcsSystems systems)
		{
			entityconfig = new DebugEntityConfig();
			entityconfig.LoadFromFile(EngineConfig.DataDirectory + "truc.entityConfig");
		}

		public void Run(IEcsSystems systems)
		{
			Debug.WriteOnFile();

			InputUtility.Run();
		}
	}
}
