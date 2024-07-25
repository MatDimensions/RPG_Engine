namespace AnimationTool
{
	public partial class TimedAnimationTool : Form
	{
		public TimedAnimationTool(Form parent)
		{
			m_parent = parent;

			InitializeComponent();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			m_parent.Show();
		}

		private Form m_parent;
	}
}
