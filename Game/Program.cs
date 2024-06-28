using Engine;
using Engine.Colliders;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SFML.System;
using System.Runtime.InteropServices;

namespace Game
{
	public static class Program
	{
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		const int SW_HIDE = 0;
		const int SW_SHOW = 5;

		public static void Main()
		{
			var handle = GetConsoleWindow();
#if DEBUG
			ShowWindow(handle, SW_SHOW);
#else
			ShowWindow(handle, SW_HIDE);
#endif
			EcsWorld world = new EcsWorld();
			EcsSystems systems = new EcsSystems(world);
			Clock clock = new Clock();
			float timer = 0f;
			int frameCount = 0;

			AddSystems(systems);

			systems.Inject();
			systems.Init();

			//DebugEntityConfig config = new DebugEntityConfig();
			//config.LoadFromFile(EngineConfig.DataDirectory + "DebugEntity.entityConfig");
			AnimatedDebugEnityConfig animated = new AnimatedDebugEnityConfig();
			animated.LoadFromFile(EngineConfig.DataDirectory + "AnimEntity.entityConfig");
			//CollisionDebugEntityConfig collision = new CollisionDebugEntityConfig();
			//collision.LoadFromFile(EngineConfig.DataDirectory + "CollideEntity.entityConfig");

			//config.CreateEntity(world);
			animated.CreateEntity(world);
			//collision.CreateEntity(world);

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
