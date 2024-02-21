namespace Engine
{
	public struct MultiTimedAnimationComponent
	{
		public string CurrentAnimation
		{
			get => m_currentAnimation;
			set
			{
				m_currentAnimation = value;
				m_haveAnimationChanged = true;
			}
		}
		public bool HaveAnimationChanged { get => m_haveAnimationChanged; internal set => m_haveAnimationChanged = value; }

		public Dictionary<string, int> Animations;
		public float[] SpritesTime;
		public int[] AnimationsSpritesNumbers;
		public int[] AnimationsStartIndex;
		public string[] SpritesNames;

		private string m_currentAnimation;
		private bool m_haveAnimationChanged;
	}
}
