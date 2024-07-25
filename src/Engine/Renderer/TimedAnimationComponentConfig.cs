namespace Engine
{
	public class TimedAnimationComponentConfig : ComponentConfig<TimedAnimationComponent>
	{
		public int SpritesNumber;
		public float AnimationCurrentTime;
		public int CurrentSprite;
		public float[] SpritesTime;
		public string[] SpritesNames;

		public TimedAnimationComponentConfig() { }

		public TimedAnimationComponentConfig(string definitionDirectory, string definitionFile)
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

		public override void InitComponent(ref TimedAnimationComponent component)
		{
			component.SpritesNumber = SpritesNumber;
			component.AnimationCurrentTime = AnimationCurrentTime;
			component.CurrentSprite = CurrentSprite;
			component.SpritesTime = SpritesTime;
			component.AnimationStartIndex = 0;
			component.AnimationLastIndex = SpritesNumber - 1;
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
				if (!splitLine[0].Contains("TIMED_ANIM") || splitLine.Contains("MULTI"))
				{
					Debug.LogError("Can't read definition file of timed anim : " + definitionDirectory + definitionFile);
					return;
				}

				SpritesNumber = int.Parse(splitLine[1]);
				AnimationCurrentTime = 0f;
				CurrentSprite = 0;
				SpritesTime = new float[SpritesNumber];
				SpritesNames = new string[SpritesNumber];
				for (int i = 0; i < SpritesNumber; ++i)
				{
					line = sr.ReadLine();
					splitLine = line.Split(' ');
					SpritesNames[i] = "../" + definitionDirectory + splitLine[0];
					SpritesTime[i] = float.Parse(splitLine[1]);
					SpriteUtility.LoadSprite(SpritesNames[i]);
				}
			}
		}

		private string m_definitionDirectory;
		private string m_definitionFile;
	}
}
