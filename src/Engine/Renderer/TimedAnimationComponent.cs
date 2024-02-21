namespace Engine
{
	public struct TimedAnimationComponent
	{
		public int SpritesNumber;
		public float AnimationCurrentTime;
		public int CurrentSprite;
		public float[] SpritesTime;
		public int AnimationStartIndex;
		public int AnimationLastIndex;
		public string[] SpritesNames;
	}
}
