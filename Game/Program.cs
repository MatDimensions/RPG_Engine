using Engine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SFML.System;

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

			AnimatedDebugEnityConfig animEntityConfig = new AnimatedDebugEnityConfig();

			animEntityConfig.CreateEntity(world);

			DebugEntityConfig entityconfig = new DebugEntityConfig();
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
