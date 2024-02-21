namespace Engine
{
	public class MultiTimedAnimationComponentConfig : ComponentConfig<MultiTimedAnimationComponent>
	{
		public int SpritesNumber;
		public Dictionary<string, int> Animations;
		public float[] SpritesTime;
		public int[] AnimationsSpritesNumbers;
		public int[] AnimationsStartIndex;
		public string[] SpritesNames;

		public MultiTimedAnimationComponentConfig() { }

		public MultiTimedAnimationComponentConfig(string definitionDirectory, string definitionFile, bool isEngineAnim)
		{
			m_definitionDirectory = definitionDirectory;
			m_definitionFile = definitionFile;
			m_isEngineAnim = isEngineAnim;
			Init();
		}

		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(m_definitionDirectory);
			writer.Write(m_definitionFile);
			writer.Write(m_isEngineAnim);
		}

		public override void Deserialize(BinaryReader reader)
		{
			m_definitionDirectory = reader.ReadString();
			m_definitionFile = reader.ReadString();
			m_isEngineAnim = reader.ReadBoolean();
			Init();
		}

		public override void InitComponent(ref MultiTimedAnimationComponent component)
		{
			component.Animations = Animations;
			component.SpritesTime = SpritesTime;
			component.AnimationsSpritesNumbers = AnimationsSpritesNumbers;
			component.AnimationsStartIndex = AnimationsStartIndex;
			component.SpritesNames = SpritesNames;
		}

		private void Init()
		{
			Init(m_definitionDirectory, m_definitionFile, m_isEngineAnim);
		}

		private void Init(string definitionDirectory, string definitionFile, bool isEngineAnim)
		{
			using (StreamReader sr = new StreamReader(EngineConfig.DataDirectory + definitionDirectory + definitionFile))
			{
				string line = sr.ReadLine();
				string[] splitLine = line.Split(' ');
				if (!splitLine[0].Contains("MULTI_TIMED_ANIM"))
				{
					Debug.LogError("Can't read definition file of anim : " + definitionDirectory + definitionFile);
					return;
				}
				int animationsNumber = int.Parse(splitLine[1]);
				SpritesNumber = int.Parse(splitLine[2]);
				Animations = new Dictionary<string, int>();
				AnimationsSpritesNumbers = new int[animationsNumber];
				AnimationsStartIndex = new int[animationsNumber];
				SpritesNames = new string[SpritesNumber];
				SpritesTime = new float[SpritesNumber];

				for (int i = 0; i < animationsNumber; ++i)
				{
					line = sr.ReadLine();
					splitLine = line.Split(' ');
					Animations.Add(splitLine[0], i);
					AnimationsStartIndex[i] = int.Parse(splitLine[1]);
					AnimationsSpritesNumbers[i] = int.Parse(splitLine[2]);
				}
				for (int i = 0; i < SpritesNumber; ++i)
				{
					line = sr.ReadLine();
					splitLine = line.Split(' ');
					SpritesNames[i] = isEngineAnim ? "../" : "";
					SpritesNames[i] += definitionDirectory + splitLine[0];
					SpritesTime[i] = float.Parse(splitLine[1]);
					SpriteUtility.LoadSprite(SpritesNames[i]);
				}
			}
		}

		private string m_definitionDirectory;
		private string m_definitionFile;
		private bool m_isEngineAnim;
	}
}
