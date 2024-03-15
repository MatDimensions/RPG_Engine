using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityConfigEditor
{
	public partial class EntityConfigEditor
	{
		private void AddEntityConfigs()
		{
			m_entityConfigs.Add(new DebugEntityConfig());
			m_entityConfigs.Add(new AnimatedDebugEnityConfig());
			m_entityConfigs.Add(new CollisionDebugEntityConfig());
		}
	}
}
