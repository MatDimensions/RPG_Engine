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
			m_stackTrace = "";
		}

		public static void LogError(string text)
		{
			GetStacktrace();
			text += "\n" + m_stackTrace;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("[Error] " + text);
			m_stringBuilder.AppendLine("[Error] " + text);
			Console.ResetColor();
		}

		public static void Log(string text)
		{
			GetStacktrace();
			Console.WriteLine(text);
#if GET_STACKTRACE
			Console.WriteLine(m_stackTrace);
			text += m_stackTrace;
#endif
			m_stringBuilder.AppendLine(text);
		}

		public static void LogWarning(string text)
		{
			GetStacktrace();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("[Warning] " + text);
#if GET_STACKTRACE
			Console.WriteLine(m_stackTrace);
#endif
			text += m_stackTrace;
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

		private static void GetStacktrace()
		{
			m_stackTrace = Environment.StackTrace;
			string[] tab = m_stackTrace.Split('\n');
			m_stackTrace = "";
			foreach (string s in tab.Skip(3))
			{
				m_stackTrace += s + "\n";
			}
		}

		private static StringBuilder m_stringBuilder = new StringBuilder();
		private static string m_logFilePath;
		private static string m_stackTrace;
	}
}
