using System.Text;

namespace Engine
{
	public static class Debug
	{
		public static void Init()
		{
			if (!Directory.Exists(EngineConfig.DebugFilePath))
				Directory.CreateDirectory(EngineConfig.DebugFilePath);
			m_logFilePath = EngineConfig.DebugFilePath + EngineConfig.DebugFileName;
			using (StreamWriter sw = new StreamWriter(m_logFilePath, false))
				sw.WriteLine("Start of the game");
		}

		public static void LogError(string text)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("[Error] " + text);
			m_stringBuilder.AppendLine("[Error] " + text);
			Console.ResetColor();
		}

		public static void Log(string text)
		{
			Console.WriteLine(text);
			m_stringBuilder.AppendLine(text);
		}

		public static void LogWarning(string text)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("[Warning] " + text);
			m_stringBuilder.AppendLine("[Warning] " + text);
			Console.ResetColor();
		}

		public static void WriteOnFile()
		{
			using (StreamWriter sw = new StreamWriter(m_logFilePath, true))
			{
				sw.Write(m_stringBuilder.ToString());
				m_stringBuilder.Clear();
			}
		}

		private static StringBuilder m_stringBuilder = new StringBuilder();
		private static string m_logFilePath;
	}
}
