using SFML.System;

namespace Engine
{
	public class EngineConfig
	{
		public static int ToRemoveTimerLength = 10;
		public static string ProjectPath = Directory.GetCurrentDirectory() + "/../../../";
		public static string DebugFilePath = ProjectPath + "/Logs/";
		public static string DebugFileName = "Logs.log";
		public static string DataDirectory = "../../Datas/";
		public static string EngineDataDirectory = "../../Datas/Engine/";
		public static string DebugSprite = "Textures/ignoble.png";
		public static string DebugShader = "Shaders/truc.frag";
		public static string DebugAnimDirectory = "Engine/Anims/DarkBlueSpirit/";
		public static string DebugAnimDefinitionFile = "MultiTimedAnimDef.txt";

		public static Vector2u BaseWindowSize = new Vector2u(800, 600);
	}
}
