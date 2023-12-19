namespace Engine.Threading
{
	public static class ThreadUtility
	{
		public static uint CreateNewThread(ThreadStart func)
		{
			do
			{
				m_threadID = unchecked(++m_threadID);
			} while (m_threads.ContainsKey(m_threadID));

			Thread thread = new Thread(func);
			thread.Start();
			m_threads.Add(m_threadID, thread);

			return m_threadID;
		}

		public static void JoinThread(uint threadID)
		{
			if (m_threads.ContainsKey(threadID))
			{
				Thread threadRef = m_threads[threadID];
				threadRef.Join();
				m_threads.Remove(threadID);
			}
		}

		public static void SetThreadPriority(uint threadID, ThreadPriority priority)
		{
			if (m_threads.ContainsKey(threadID))
			{
				Thread threadRef = m_threads[threadID];
				threadRef.Priority = priority;
			}
		}

		public static void Init()
		{
			m_threads = new Dictionary<uint, Thread>();
		}

		public static void JoinAllThreads()
		{
			foreach (var kvp in m_threads)
			{
				kvp.Value.Join();
			}
			m_threads.Clear();
		}

		private static Dictionary<uint, Thread> m_threads;
		private static uint m_threadID = 0;
	}
}
