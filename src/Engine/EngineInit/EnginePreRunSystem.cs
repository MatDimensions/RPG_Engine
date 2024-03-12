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

			EngineData.Window.DispatchEvents();

			InputUtility.Run();

			if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
			{
				RendererSystem.CloseWindow(EngineData.Window, null);
			}

			if (InputUtility.IsInputPressed("CameraUp"))
			{
				Camera.SetPosition(Camera.GetPosition() + new Vector2f(0, 1f));
			}
			else if (InputUtility.IsInputPressed("CameraDown"))
			{
				Camera.SetPosition(Camera.GetPosition() + new Vector2f(0, -1f));
			}
			if (InputUtility.IsInputPressed("CameraLeft"))
			{
				Camera.SetPosition(Camera.GetPosition() + new Vector2f(-1f, 0f));
			}
			else if (InputUtility.IsInputPressed("CameraRight"))
			{
				Camera.SetPosition(Camera.GetPosition() + new Vector2f(1f, 0f));
			}
		}

		private EcsWorldInject m_world;
	}
}
