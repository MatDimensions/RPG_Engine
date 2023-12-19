using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
#if UPDATE_TIMERS
	public class TimerSystem : IEcsRunSystem
	{
		public void Rum(IEcsSystems systems)
		{
			TimerUtility.UpdateTimers();
		}
	}
#elif LATE_UPDATE_TIMERS
	public class TimerSystem : IEcsPostRunSystem
	{
		public void PostRun(IEcsSystems systems)
		{
			TimerUtility.UpdateTimers();
		}
	}
#endif
}
