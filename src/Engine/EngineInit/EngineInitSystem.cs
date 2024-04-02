using Engine.Threading;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Engine
{
	public class EngineInitSystem : IEcsPreInitSystem
	{
		public void PreInit(IEcsSystems systems)
		{
			Debug.Init();

			ThreadUtility.Init();
			TimerUtility.Init();
			SpriteUtility.Init();
			ShaderUtility.Init();
			InputUtility.Init();

			Camera.Init(Vector2f.Zero, 1f);
			EngineData.Window = new RenderWindow(new VideoMode(EngineConfig.BaseWindowSize.X, EngineConfig.BaseWindowSize.Y), "Game");
			EngineData.WindowSize = EngineConfig.BaseWindowSize;
			EngineData.Window.Closed += RendererSystem.CloseWindow;
			//EngineData.Window.SetFramerateLimit(60);
		}
	}
}
