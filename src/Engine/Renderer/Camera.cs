using SFML.System;
using System.Runtime.CompilerServices;

namespace Engine
{
	public static class Camera
	{
		public static float FOV { get => m_FOV; set => m_FOV = value; }
		public static void Init(Vector2f pos, float fov = 1f)
		{
			m_position = pos;
			m_FOV = fov;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPosition(Vector2f position)
		{
			m_position = position;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2f GetPosition()
		{
			return m_position;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2f ScreenToWorld(Vector2f screenPos)
		{
			return new Vector2f(
				(screenPos.X - EngineData.WindowSize.X / 2f) / m_FOV + m_position.X,
				((screenPos.Y - EngineData.WindowSize.Y / 2f) / m_FOV - m_position.Y) * -1f
				);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2f ScreenToWorld(Vector2i screenPos)
		{
			return new Vector2f(
				(screenPos.X - EngineData.WindowSize.X / 2f) / m_FOV + m_position.X,
				((screenPos.Y - EngineData.WindowSize.Y / 2f) / m_FOV - m_position.Y) * -1f
				);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2f WorldToScreen(Vector2f worldPos)
		{
			return new Vector2f(
				(worldPos.X - m_position.X) * m_FOV + EngineData.WindowSize.X / 2f,
				(worldPos.Y + m_position.Y) * m_FOV + EngineData.WindowSize.Y / 2f
				);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2f WorldToScreen(Vector2i worldPos)
		{
			return new Vector2f(
				(worldPos.X - m_position.X) * m_FOV + EngineData.WindowSize.X / 2f,
				(worldPos.Y + m_position.Y) * m_FOV + EngineData.WindowSize.Y / 2f
				);
		}

		private static Vector2f m_position;
		private static float m_FOV;
	}
}
