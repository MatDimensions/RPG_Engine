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
			}
		}
		public bool HaveAnimationChanged { get => !string.Equals(m_currentAnimation, m_lastAnimation); }
		internal string LastAnimation { set => m_lastAnimation = value; }

		public Dictionary<string, int> Animations;
		public float[] SpritesTime;
		public int[] AnimationsSpritesNumbers;
		public int[] AnimationsStartIndex;
		public string[] SpritesNames;

		private string m_currentAnimation;
		private string m_lastAnimation;
	}
}
