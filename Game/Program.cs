using Engine;
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
			float timer = 0f;
			int frameCount = 0;

			AddSystems(systems);

			systems.Inject();
			systems.Init();

			AnimatedEnityDebugConfig animEntityConfig = new AnimatedEnityDebugConfig();
			float animationTimer = 0f;

			ref MultiAnimationComponent multiAnimComp = ref world.GetPool<MultiAnimationComponent>().Get(animEntityConfig.CreateEntity(world));
			multiAnimComp.CurrentAnimation = "Idle";

			EntityDebugConfig entityconfig = new EntityDebugConfig();
			/*entityconfig.RendererConfig.Sprite = SpriteUtility.GetSprite(EngineConfig.DebugSprite);
			entityconfig.RendererConfig.Shader = ShaderUtility.GetShader(EngineConfig.DebugShader);
			entityconfig.RendererConfig.BlendMode = SFML.Graphics.BlendMode.Alpha;
			entityconfig.RendererConfig.IsStatic = false;
			entityconfig.RendererConfig.IsTerrain = false;
			entityconfig.SaveOnFile("../../truc.entityConfig");*/

			entityconfig.LoadFromFile("../../truc.entityConfig");

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
				timer += EngineData.DeltaTime;
				frameCount++;
				if (timer >= 1f)
				{
					Debug.Log("fps : " + frameCount);
					frameCount = 0;
					timer = 0f;
				}

				animationTimer += EngineData.DeltaTime;
				if (animationTimer >= 7f && multiAnimComp.CurrentAnimation == "Idle")
				{
					multiAnimComp.CurrentAnimation = "Fade";
				}
				if (animationTimer > 15f)
				{
					multiAnimComp.CurrentAnimation = "Idle";
					animationTimer = 0f;
				}

				EngineData.Window.DispatchEvents();

				if (Mouse.IsButtonPressed(Mouse.Button.Left))
				{
					int entity = entityconfig.CreateEntity(world);
					ref TransformComponent transformComp = ref world.GetPool<TransformComponent>().Get(entity);
					transformComp.Position = Camera.ScreenToWorld(Mouse.GetPosition(EngineData.Window));
					transformComp.Rotation = (rand.NextSingle() - 0.5f) * 2 * 180f;
					transformComp.Scale = rand.NextSingle() + 0.5f;
				}

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
