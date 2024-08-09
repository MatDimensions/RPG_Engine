using Engine;

namespace AnimationTool
{
	public partial class ChoseAnimationType : Form
	{
		public ChoseAnimationType()
		{
			InitializeComponent();
			Debug.Init();
			SpriteUtility.Init();
			ShaderUtility.Init();
		}

		void OpenTool(object? sender, EventArgs e)
		{
			if (comboBox.SelectedIndex == -1)
				return;
			switch (comboBox.SelectedIndex)
			{
				case 0:
					AnimationTool animationTool = new AnimationTool(this);
					animationTool.Show();
					this.Hide();
					break;
				case 1:
					TimedAnimationTool timedAnimationTool = new TimedAnimationTool(this);
					timedAnimationTool.Show();
					this.Hide();
					break;
				case 2:
					MultiAnimationTool multianimationTool = new MultiAnimationTool(this);
					multianimationTool.Show();
					this.Hide();
					break;
				case 3:

					break;
				default:
					break;
			}
		}
	}
}
