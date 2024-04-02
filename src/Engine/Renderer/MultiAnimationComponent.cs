namespace Engine
{
	public struct MultiAnimationComponent
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
		public int[] AnimationsSpritesNumbers;
		public float[] AnimationsTime;
		public int[] AnimationsStartIndex;
		public string[] SpritesNames;

		private string m_currentAnimation;
		private string m_lastAnimation;
	}
}
