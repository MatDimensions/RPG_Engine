using System.Runtime.CompilerServices;

namespace Engine
{
	public static class RendererUtility
	{
		public class RendererLayer
		{
			public bool IsStatic = false;
		}

		public static void Init()
		{
			m_layers = new();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLayerStatic(int layerLevel, bool isStatic)
		{
			CheckLayers(layerLevel);
			m_layers[layerLevel].IsStatic = isStatic;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsLayerStatic(int layerLevel)
		{
			CheckLayers(layerLevel);
			return m_layers[layerLevel].IsStatic;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void CheckLayers(int layerLevel)
		{
			while (m_layers.Count - 1 < layerLevel)
				m_layers.Add(new RendererLayer());
		}

		private static List<RendererLayer> m_layers;
	}
}
