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
			Random rand = new Random(0);
			Clock clock = new Clock();
			float timer = 0f;
			int frameCount = 0;

			AddSystems(systems);

			systems.Inject();
			systems.Init();

			#region Test
			AnimatedDebugEnityConfig animEntityConfig = new AnimatedDebugEnityConfig();
			animEntityConfig.LoadFromFile(EngineConfig.DataDirectory + "AnimEntity.entityConfig");
			animEntityConfig.CreateEntity(world);
			/*float animationTimer = 0f;

			ref MultiTimedAnimationComponent multiAnimComp = ref world.GetPool<MultiTimedAnimationComponent>().Get(animEntityConfig.CreateEntity(world));
			multiAnimComp.CurrentAnimation = "Idle";*/

			/*entityconfig.LoadFromFile(EngineConfig.DataDirectory + "truc.entityConfig");
			entityconfig.RendererConfig.IsTerrain = true;

			for (int i = 0; i < 2000; i++)
			{
				int entity = entityconfig.CreateEntity(world);
				ref TransformComponent transformComp = ref world.GetPool<TransformComponent>().Get(entity);
				transformComp.Position = new SFML.System.Vector2f(rand.NextSingle() * 800f, rand.NextSingle() * 600f);
				transformComp.Rotation = (rand.NextSingle() - 0.5f) * 2 * 180f;
				transformComp.Scale = rand.NextSingle() + 1.1f;
			}*/
			#endregion

			#region CollisionTest
			CollisionDebugEntityConfig collisionDebugEntity = new CollisionDebugEntityConfig();
			collisionDebugEntity.LoadFromFile(EngineConfig.DataDirectory + "CollideEntity.entityConfig");
			collisionDebugEntity.CreateEntity(world);

			world.GetPool<FollowCursorTag>().Add(collisionDebugEntity.CreateEntity(world));
			#endregion

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

				/*animationTimer += EngineData.DeltaTime;
				if (animationTimer >= 7f && multiAnimComp.CurrentAnimation == "Idle")
				{
					multiAnimComp.CurrentAnimation = "Fade";
				}
				if (animationTimer > 15f)
				{
					multiAnimComp.CurrentAnimation = "Idle";
					animationTimer = 0f;
				}*/

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
			systems.Add(new MoveToCursorSystem());

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
