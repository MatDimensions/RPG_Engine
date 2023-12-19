﻿using Engine.Threading;
using Leopotam.EcsLite;
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
			Camera.Init(Vector2f.Zero, EngineConfig.BaseWindowSize);
			EngineData.Window = new RenderWindow(new VideoMode(EngineConfig.BaseWindowSize.X, EngineConfig.BaseWindowSize.Y), "Game");

			//EngineData.Window.SetFramerateLimit(60);
			EngineData.Window.Closed += RendererSystem.CloseWindow;
		}
	}
}
