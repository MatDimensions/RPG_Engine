using SFML.Graphics;

namespace Engine
{
	public static class ShaderUtility
	{
		public static string SHADER_NULL_NAME
		{
			get => "null";
		}

		public static void Init()
		{
			m_shaders = new Dictionary<string, Shader>();
			LoadDebugShader(EngineConfig.DebugShader);
			m_shaders.Add(SHADER_NULL_NAME, null);
		}

		public static void Destroy()
		{
			UnloadShader(EngineConfig.DebugShader);
		}

		public static bool IsShaderLoad(string shaderName)
		{
			return m_shaders.ContainsKey(shaderName);
		}

		/// <summary>
		/// Load sprite corresponding at the texture name
		/// /!\ cause allocation
		/// </summary>
		/// <param name="shaderName"></param>
		public static void LoadShader(
			string shaderName,
			string? vertexShaderName = null,
			string? geometryShaderName = null,
			string? fragmentShaderName = null)
		{
			if (m_shaders.ContainsKey(shaderName))
			{
				Debug.LogError(LOAD_ERROR + shaderName);
				return;
			}
			Shader shader = new Shader(
				vertexShaderName != null ? SHADERS_DIRECTORY + vertexShaderName : null,
				geometryShaderName != null ? SHADERS_DIRECTORY + geometryShaderName : null,
				fragmentShaderName != null ? SHADERS_DIRECTORY + fragmentShaderName : null);
			m_shaders.Add(shaderName, shader);
		}

		/// <summary>
		/// remove ref of the sprite
		/// </summary>
		/// <param name="shaderName"></param>
		public static void UnloadShader(string shaderName)
		{
			Shader shader = m_shaders[shaderName];
			m_shaders.Remove(shaderName);
			shader.Dispose();
		}

		public static string GetShaderName(Shader shader)
		{
			if (!m_shaders.ContainsValue(shader))
			{
				Debug.LogError(SHADER_NAME_GETTER_ERROR);
				return SHADER_NULL_NAME;
			}

			foreach (var kvp in m_shaders)
			{
				if (kvp.Value == shader)
					return kvp.Key;
			}
			return SHADER_NULL_NAME;
		}

		public static Shader GetShader(string shaderName)
		{
			if (!m_shaders.ContainsKey(shaderName))
			{
				Debug.LogError(SHADER_GETTER_ERROR + shaderName);
				Debug.LogError(SHADER_GETTER_ERROR_TWO);
				LoadShader(shaderName);
			}
			return m_shaders[shaderName];
		}

		private static void LoadDebugShader(string shaderName)
		{
			if (m_shaders.ContainsKey(shaderName))
			{
				Debug.LogError(LOAD_ERROR + shaderName);
				return;
			}
			Shader shader = new Shader(null, null, EngineConfig.EngineDataDirectory + EngineConfig.DebugShader);
			m_shaders.Add(shaderName, shader);
		}

		private static Dictionary<string, Shader> m_shaders;
		private static string SHADERS_DIRECTORY = "../../Datas/Shaders/";
		private const string SHADER_GETTER_ERROR = "Try to get a non load sprite with texture ";
		private const string SHADER_GETTER_ERROR_TWO = "Load the sprite at a non optimal moment, this shouldn't happen, use LoadSprite before at an optimal moment";
		private const string SHADER_NAME_GETTER_ERROR = "";
		private const string LOAD_ERROR = "Try to load an already load sprite with texture ";
	}
}
