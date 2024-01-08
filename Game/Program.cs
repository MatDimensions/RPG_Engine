﻿using Engine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SFML.System;
using SFML.Window;

namespace Global
{
	public static class Program
	{
		public static void Main()
		{
			EcsWorld world = new EcsWorld();
			EcsSystems systems = new EcsSystems(world);
			Random rand = new Random(0);
			Clock clock = new Clock();

			AddSystems(systems);

			systems.Inject();
			systems.Init();

			AnimatedEnityDebugConfig animEntityConfig = new AnimatedEnityDebugConfig();

			animEntityConfig.CreateEntity(world);

			EntityDebugConfig entityconfig = new EntityDebugConfig();
			/*config.RendererConfig.Sprite = SpriteUtility.GetSprite(EngineConfig.DebugSprite);
			config.RendererConfig.Shader = ShaderUtility.GetShader(EngineConfig.DebugShader);
			config.RendererConfig.BlendMode = SFML.Graphics.BlendMode.Alpha;
			config.RendererConfig.IsStatic = false;
			config.RendererConfig.IsTerrain = false;
			config.SaveOnFile("../../truc.entityConfig");*/

			entityconfig.LoadFromFile("../../truc.entityConfig");
			//config.CreateEntity(world);

			for (int i = 0; i < 2000; i++)
			{
				int entity = entityconfig.CreateEntity(world);
				ref TransformComponent transformComp = ref world.GetPool<TransformComponent>().Get(entity);
				transformComp.Position = new SFML.System.Vector2f(rand.NextSingle() * 800f, rand.NextSingle() * 600f);
				transformComp.Rotation = (rand.NextSingle() - 0.5f) * 2 * 180f;
				transformComp.Scale = rand.NextSingle() + 1.1f;
			}

			clock.Restart();

			while (EngineData.Window.IsOpen)
			{
				EngineData.DeltaTime = clock.Restart().AsSeconds();
				int fps = (int)(1f / EngineData.DeltaTime);
				Debug.Log("fps : " + fps);
				EngineData.Window.DispatchEvents();

				/*if (Mouse.IsButtonPressed(Mouse.Button.Left))
				{
					int entity = config.CreateEntity(world);
					ref TransformComponent transformComp = ref world.GetPool<TransformComponent>().Get(entity);
					transformComp.Position = Camera.ScreenToWorld(Mouse.GetPosition(EngineData.Window));
					transformComp.Rotation = (rand.NextSingle() - 0.5f) * 2 * 180f;
					transformComp.Scale = rand.NextSingle() + 0.5f;
				}*/

				if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
				{
					RendererSystem.CloseWindow(EngineData.Window, null);
				}

				if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
				{
					Camera.SetPosition(Camera.GetPosition() + new Vector2f(0, 1f));
				}
				else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
				{
					Camera.SetPosition(Camera.GetPosition() + new Vector2f(0, -1f));
				}
				if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
				{
					Camera.SetPosition(Camera.GetPosition() + new Vector2f(-1f, 0f));
				}
				else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
				{
					Camera.SetPosition(Camera.GetPosition() + new Vector2f(1f, 0f));
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

			//systems.Add(new TransformSystem());

			systems.Add(new AnimationSystem());
			systems.Add(new RendererSystem());
			systems.Add(new TimerSystem());
			systems.Add(new ResetTransformSystem());
			systems.Add(new EngineDestroySystem());
		}
	}
}
