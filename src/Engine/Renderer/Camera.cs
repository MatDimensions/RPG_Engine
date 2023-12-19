using SFML.Graphics;
using SFML.System;
using System.Runtime.CompilerServices;

namespace Engine
{
	public static class Camera
	{
		public static void Init(Vector2f center, Vector2u size)
		{
			m_view = new View(center, (Vector2f)size);
			m_position = new Vector2f(0, 0);
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
		public static void SetSize(Vector2u size)
		{
			m_view.Size = (Vector2f)size;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static View GetView()
		{
			return m_view;
		}

		private static View m_view;
		private static Vector2f m_position;
	}
}
