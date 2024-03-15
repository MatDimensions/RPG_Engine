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

			entityconfig = new DebugEntityConfig();
			entityconfig.LoadFromFile(EngineConfig.DataDirectory + "truc.entityConfig");
			entityconfig.RendererConfig.Shader = ShaderUtility.GetShader(ShaderUtility.SHADER_NULL_NAME);

			InputUtility.Init();
			InitInputs();
			Camera.Init(Vector2f.Zero, 1f);
			EngineData.Window = new RenderWindow(new VideoMode(EngineConfig.BaseWindowSize.X, EngineConfig.BaseWindowSize.Y), "Game");
			EngineData.WindowSize = EngineConfig.BaseWindowSize;

			//EngineData.Window.SetFramerateLimit(60);
			EngineData.Window.Closed += RendererSystem.CloseWindow;
		}

		private void InitInputs()
		{
			InputUtility.InputMap inputMap = InputUtility.CreateNewMap("GameInputMap");
			List<InputUtility.Input> inputs = new List<InputUtility.Input>(5);
			for (int i = 0; i < 5; i++) inputs.Add(new InputUtility.Input());
			inputs[0].Name = "CameraUp";
			inputs[1].Name = "CameraDown";
			inputs[2].Name = "CameraLeft";
			inputs[3].Name = "CameraRight";
			inputs[4].Name = "CreateBlobs";

			inputs[0].Keys.Add(InputUtility.InputKeys.Z);
			inputs[1].Keys.Add(InputUtility.InputKeys.S);
			inputs[2].Keys.Add(InputUtility.InputKeys.Q);
			inputs[3].Keys.Add(InputUtility.InputKeys.D);
			inputs[4].Keys.Add(InputUtility.InputKeys.MouseLeft);

			inputs[4].PressedActions.Add(CreateBlob);

			inputMap.Inputs = inputs;
			InputUtility.SetCurrentMapName("GameInputMap");
		}

		private void CreateBlob(InputUtility.InputKeys key)
		{
			int entity = entityconfig.CreateEntity(m_world.Value);
			ref TransformComponent transformComp = ref m_world.Value.GetPool<TransformComponent>().Get(entity);
			transformComp.Position = Camera.ScreenToWorld(Mouse.GetPosition(EngineData.Window));
			transformComp.Rotation = (rand.NextSingle() - 0.5f) * 2 * 180f;
			transformComp.Scale = rand.NextSingle() + 0.5f;
		}

		private DebugEntityConfig entityconfig;
		private EcsWorldInject m_world;
		private Random rand = new Random(0);
	}
}
