using SFML.Graphics;
using SFML.System;

namespace Engine
{
	public static class SpriteUtility
	{
		public static void Init()
		{
			m_sprites = new Dictionary<string, Sprite>();
			LoadDebugSprite(EngineConfig.DebugSprite);
		}

		public static void Destroy()
		{
			UnloadSprite(EngineConfig.DebugSprite);
		}

		public static bool IsSpriteLoad(string textureName)
		{
			return m_sprites.ContainsKey(textureName);
		}

		/// <summary>
		/// Load sprite corresponding at the texture name
		/// /!\ cause allocation
		/// </summary>
		/// <param name="textureName"></param>
		public static void LoadSprite(string textureName)
		{
			if (m_sprites.ContainsKey(textureName))
			{
				Debug.LogError(LOAD_ERROR + textureName);
				return;
			}
			Texture text = new Texture(TEXTURES_DIRECTORY + textureName);
			Sprite sprite = new Sprite(text);
			sprite.Origin = (Vector2f)sprite.Texture.Size / 2f;
			m_sprites.Add(textureName, sprite);
		}

		/// <summary>
		/// remove ref of the sprite
		/// </summary>
		/// <param name="textureName"></param>
		public static void UnloadSprite(string textureName)
		{
			Sprite sprite = m_sprites[textureName];
			m_sprites.Remove(textureName);
			sprite.Texture.Dispose();
			sprite.Dispose();
		}

		public static string? GetSpriteName(Sprite sprite)
		{
			if (!m_sprites.ContainsValue(sprite))
			{
				Debug.LogError(TEXTURE_GETTER_ERROR);
				return null;
			}

			foreach (var kvp in m_sprites)
			{
				if (kvp.Value == sprite)
					return kvp.Key;
			}
			return null;
		}

		public static Sprite GetSprite(string textureName)
		{
			if (!m_sprites.ContainsKey(textureName))
			{
				Debug.LogError(SPRITE_GETTER_ERROR + textureName);
				Debug.LogError(SPRITE_GETTER_ERROR_TWO);
				LoadSprite(textureName);
			}
			return m_sprites[textureName];
		}

		private static void LoadDebugSprite(string textureName)
		{
			if (m_sprites.ContainsKey(textureName))
			{
				Debug.LogError(LOAD_ERROR + textureName);
				return;
			}
			Texture text = new Texture(EngineConfig.EngineDataDirectory + textureName);
			Sprite sprite = new Sprite(text);
			sprite.Origin = (Vector2f)sprite.Texture.Size / 2f;
			m_sprites.Add(textureName, sprite);
		}

		private static Dictionary<string, Sprite> m_sprites;
		private static string TEXTURES_DIRECTORY = "../../Datas/Textures/";
		private const string SPRITE_GETTER_ERROR = "Try to get a non load sprite with texture ";
		private const string SPRITE_GETTER_ERROR_TWO = "Load the sprite at a non optimal moment, this shouldn't happen, use LoadSprite before at an optimal moment";
		private const string TEXTURE_GETTER_ERROR = "";
		private const string LOAD_ERROR = "Try to load an already load sprite with texture ";
	}
}
