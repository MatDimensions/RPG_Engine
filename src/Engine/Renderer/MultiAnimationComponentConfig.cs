namespace Engine
{
	public class MultiAnimationComponentConfig : ComponentConfig<MultiAnimationComponent>
	{
		public int SpritesNumber;
		public Dictionary<string, int> Animations;
		public int[] AnimationsSpritesNumbers;
		public float[] AnimationsTime;
		public int[] AnimationsStartIndex;
		public string[] SpritesNames;

		public MultiAnimationComponentConfig() { }

		public MultiAnimationComponentConfig(string definitionDirectory, string definitionFile)
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

		public override void InitComponent(ref MultiAnimationComponent component)
		{
			component.Animations = Animations;
			component.AnimationsSpritesNumbers = AnimationsSpritesNumbers;
			component.AnimationsTime = AnimationsTime;
			component.AnimationsStartIndex = AnimationsStartIndex;
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
				string line = sr.ReadLine();
				string[] splitLine = line.Split(' ');
				if (!splitLine[0].Contains("MULTI_ANIM"))
				{
					Debug.LogError("Can't read definition file of anim : " + definitionDirectory + definitionFile);
					return;
				}
				int animationsNumber = int.Parse(splitLine[1]);
				SpritesNumber = int.Parse(splitLine[2]);
				Animations = new Dictionary<string, int>();
				AnimationsSpritesNumbers = new int[animationsNumber];
				AnimationsTime = new float[animationsNumber];
				AnimationsStartIndex = new int[animationsNumber];
				SpritesNames = new string[SpritesNumber];

				for (int i = 0; i < animationsNumber; ++i)
				{
					line = sr.ReadLine();
					splitLine = line.Split(' ');
					Animations.Add(splitLine[0], i);
					AnimationsTime[i] = float.Parse(splitLine[1]);
					AnimationsStartIndex[i] = int.Parse(splitLine[2]);
					AnimationsSpritesNumbers[i] = int.Parse(splitLine[3]);
				}
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
