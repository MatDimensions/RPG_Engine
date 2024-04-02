using Engine;
using Engine.Colliders;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SFML.System;

namespace Game
{
	public static class Program
	{
		public static void Main()
		{
			EcsWorld world = new EcsWorld();
			EcsSystems systems = new EcsSystems(world);
			Clock clock = new Clock();
			float timer = 0f;
			int frameCount = 0;

			AddSystems(systems);

			systems.Inject();
			systems.Init();

			while (EngineData.Window.IsOpen)
			{
				EngineData.DeltaTime = clock.Restart().AsSeconds();
				timer += EngineData.DeltaTime;
				frameCount++;
				if (timer >= 1f)
				{
					Debug.Log("fps : " + frameCount);
					frameCount = 0;
					timer = 0f;
				}

				systems.Run();
			}

			systems.Destroy();
			world.Destroy();
		}

		private static void AddSystems(EcsSystems systems)
		{
			systems.Add(new EngineInitSystem());
			systems.Add(new EnginePreRunSystem());

			systems.Add(new CheckCollisionSystem());

			systems.Add(new AnimationSystem());
			systems.Add(new RendererSystem());
			#region PostRunSystems
			systems.Add(new TimerSystem());
			systems.Add(new ResetTransformSystem());
			systems.Add(new ResetCollisionSystem());
			#endregion
			systems.Add(new EngineDestroySystem());
		}
	}
}
