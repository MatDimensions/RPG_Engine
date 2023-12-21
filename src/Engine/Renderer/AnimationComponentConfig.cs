namespace Engine
{
	public class AnimationComponentConfig : ComponentConfig<AnimationComponent>
	{
		public int SpritesNumber;
		public float AnimationTime;
		public float AnimationCurrentTime;
		public string[] SpritesNames;

		public AnimationComponentConfig(string definitionDirectory, string definitionFile, bool isEngineAnim)
		{
			using (StreamReader sr = new StreamReader(EngineConfig.DataDirectory + definitionDirectory + definitionFile))
			{
				string firstLine = sr.ReadLine();
				string[] splitLine = firstLine.Split(' ');
				if (!splitLine[0].Contains("ANIM"))
				{
					Debug.LogError("Can't read definition file of anim : " + definitionDirectory + definitionFile);
				}

				SpritesNumber = int.Parse(splitLine[1]);
				AnimationTime = float.Parse(splitLine[2]);
				AnimationCurrentTime = 0f;
				SpritesNames = new string[SpritesNumber];
				for (int i = 0; i < SpritesNumber; ++i)
				{
					SpritesNames[i] = isEngineAnim ? "../" : "";
					SpritesNames[i] += definitionDirectory + sr.ReadLine();
					SpriteUtility.LoadSprite(SpritesNames[i]);
				}
			}
		}

		public override void Serialize(BinaryWriter writer) { }

		public override void Deserialize(BinaryReader reader) { }

		public override void InitComponent(ref AnimationComponent component)
		{
			component.SpritesNumber = SpritesNumber;
			component.AnimationTime = AnimationTime;
			component.AnimationCurrentTime = AnimationCurrentTime;
			component.SpritesNames = SpritesNames;
		}
	}
}
