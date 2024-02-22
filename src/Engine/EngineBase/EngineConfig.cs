using SFML.System;

namespace Engine
{
	public static class EngineConfig
	{
		public static readonly int ToRemoveTimerLength = 10;
		public static readonly string ProjectPath = Directory.GetCurrentDirectory() + "/../../../";
		public static readonly string DebugFilePath = ProjectPath + "/Logs/";
		public static readonly string DebugFileName = "Logs.log";
		public static readonly string DataDirectory = "../../Datas/";
		public static readonly string EngineDataDirectory = "../../Datas/Engine/";
		public static readonly string DebugSprite = "Textures/ignoble.png";
		public static readonly string DebugShader = "Shaders/truc.frag";
		public static readonly string DebugAnimDirectory = "Engine/Anims/DarkBlueSpirit/";
		public static readonly string DebugAnimDefinitionFile = "MultiTimedAnimDef.txt";

		public static readonly Vector2u BaseWindowSize = new Vector2u(800, 600);
	}
}
