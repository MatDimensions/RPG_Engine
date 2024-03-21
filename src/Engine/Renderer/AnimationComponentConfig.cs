namespace Engine
{
	public class AnimationComponentConfig : ComponentConfig<AnimationComponent>
	{
		public int SpritesNumber;
		public float AnimationTime;
		public float AnimationCurrentTime;
		public string[] SpritesNames;

		public AnimationComponentConfig() { }

		public AnimationComponentConfig(string definitionDirectory, string definitionFile)
		{
			m_definitionDirectory = definitionDirectory;
			m_definitionFile = definitionFile;
			Init();
		}

		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(m_definitionDirectory);
			writer.Write(m_definitionFile);
		}

		public override void Deserialize(BinaryReader reader)
		{
			m_definitionDirectory = reader.ReadString();
			m_definitionFile = reader.ReadString();
			Init();
		}

		public override void InitComponent(ref AnimationComponent component)
		{
			component.SpritesNumber = SpritesNumber;
			component.AnimationTime = AnimationTime;
			component.AnimationCurrentTime = AnimationCurrentTime;
			component.AnimationStartIndex = 0;
			component.SpritesNames = SpritesNames;
		}

		private void Init()
		{
			Init(m_definitionDirectory, m_definitionFile);
		}

		private void Init(string definitionDirectory, string definitionFile)
		{
			using (StreamReader sr = new StreamReader(EngineConfig.DataDirectory + definitionDirectory + definitionFile))
			{
				string firstLine = sr.ReadLine();
				string[] splitLine = firstLine.Split(' ');
				if (!splitLine[0].Contains("ANIM"))
				{
					Debug.LogError("Can't read definition file of anim : " + definitionDirectory + definitionFile);
					return;
				}

				SpritesNumber = int.Parse(splitLine[1]);
				AnimationTime = float.Parse(splitLine[2]);
				AnimationCurrentTime = 0f;
				SpritesNames = new string[SpritesNumber];
				for (int i = 0; i < SpritesNumber; ++i)
				{
					SpritesNames[i] = "../" + definitionDirectory + sr.ReadLine();
					SpriteUtility.LoadSprite(SpritesNames[i]);
				}
			}
		}

		private string m_definitionDirectory;
		private string m_definitionFile;
	}
}
