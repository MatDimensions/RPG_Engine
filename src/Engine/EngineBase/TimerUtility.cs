namespace Engine
{
	public static class TimerUtility
	{
		public class Timer
		{
			public bool Destroy = false;

			public Timer(uint index, System.Action action, float timer, object objectReference, bool destroySelf = false)
			{
				this.index = index;
				this.action = action;
				this.timer = timer;
				this.timerClock = 0f;
				this.destroySelf = destroySelf;
				this.objectReference = objectReference;
			}

			public void Update(float deltaTime)
			{
				if (objectReference.Equals(null))
				{
					this.Destroy = true;
					return;
				}

				timerClock += deltaTime;
				if (this.timerClock >= this.timer)
				{
					timerClock = 0f;
					action?.Invoke();
					if (destroySelf)
					{
						this.Destroy = true;
					}
				}
			}

			private readonly uint index;
			private event System.Action action;
			private float timerClock;
			private readonly float timer;
			private readonly bool destroySelf;
			private readonly object objectReference;
		}

		public static void Init()
		{
			m_timers = new Dictionary<uint, TimerUtility.Timer>();
			m_toRemove = new List<uint>(EngineConfig.ToRemoveTimerLength);
		}

		public static void UpdateTimers()
		{
			float frameDeltaTime = EngineData.DeltaTime;
			m_toRemove.Clear();

			foreach (KeyValuePair<uint, Timer> pairTimer in m_timers)
			{
				pairTimer.Value.Update(frameDeltaTime);
				if (pairTimer.Value.Destroy)
					m_toRemove.Add(pairTimer.Key);
			}

			foreach (uint index in m_toRemove)
			{
				m_timers.Remove(index);
			}
		}

		public static uint CreateNewTimer(System.Action action, float timer, object objectReference, bool selfDestruct = false)
		{
			do
			{
				m_timersIndex = unchecked(++m_timersIndex);
			} while (m_timers.ContainsKey(m_timersIndex));

			m_timers.Add(m_timersIndex, new Timer(m_timersIndex, action, timer, objectReference, selfDestruct));
			return m_timersIndex;
		}

		public static bool DestroyTimer(uint index)
			=> m_timers.Remove(index);

		private static Dictionary<uint, TimerUtility.Timer> m_timers;
		private static uint m_timersIndex;

		private static List<uint> m_toRemove;
	}
}
