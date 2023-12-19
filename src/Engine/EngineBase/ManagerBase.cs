using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
	public interface IManager { }

	public abstract class ManagerBase<T> : IManager where T : class, IManager, new()
	{
		#region Static
		public static T Instance { get; private set; }
		public static void Init()
		{
#if DEBUG
			if (Instance == null)
			{
#endif
			Instance = new T();
			(Instance as ManagerBase<T>).InitInstance();
#if DEBUG
			}
#endif
		}

		protected virtual void InitInstance()
		{

		}

		#endregion
	}
}
