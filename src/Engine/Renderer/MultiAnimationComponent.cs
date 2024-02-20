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
				m_haveAnimationChanged = true;
			}
		}
		public bool HaveAnimationChanged { get => m_haveAnimationChanged; internal set => m_haveAnimationChanged = value; }
		public Dictionary<string, int> Animations;
		public int[] AnimationsSpritesNumbers;
		public float[] AnimationsTime;
		public int[] AnimationsStartIndex;
		public string[] SpritesNames;

		private string m_currentAnimation;
		private bool m_haveAnimationChanged;
	}
}
