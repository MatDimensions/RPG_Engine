using SFML.System;

namespace Engine
{
	public struct TransformComponent
	{
		public Vector2f Position
		{
			get => m_position;
			set
			{
				m_position = value;
				m_hasMoved = true;
			}
		}
		public float Rotation
		{
			get => m_rotation;
			set
			{
				m_rotation = value;
				m_hasMoved = true;
			}
		}
		public float Scale
		{
			get => m_scale;
			set
			{
				m_scale = value;
				m_hasMoved = true;
			}
		}

		public bool HasMoved
		{
			get => m_hasMoved;
			internal set => m_hasMoved = value;
		}

		private Vector2f m_position;
		private float m_rotation;
		private float m_scale;

		private bool m_hasMoved;
	}
}
