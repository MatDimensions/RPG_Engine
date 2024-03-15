using Engine;

namespace EntityConfigEditor
{
	internal class SelectionEntityConfigForm : Form
	{
		public SelectionEntityConfigForm(EntityConfigEditor parent)
		{
			m_parent = parent;

			this.Size = new Size(640, 360);

			Label label = new Label();
			label.AutoSize = true;
			label.Text = "Selected Entity Config";
			label.Location = new Point(440, 8);
			label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			Controls.Add(label);

			m_numeric = new();
			m_numeric.Value = (decimal)m_parent.SelectedConfig;
			m_numeric.Size = new Size(50, 20);
			m_numeric.Location = new Point(570, 5);
			m_numeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			Controls.Add(m_numeric);

			Panel panel = new Panel();
			panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panel.BorderStyle = BorderStyle.Fixed3D;
			panel.Location = new Point(12, 35);
			panel.Size = new Size(600, 280);
			panel.AutoScroll = true;
			panel.VerticalScroll.Enabled = true;
			panel.VerticalScroll.Visible = true;
			Controls.Add(panel);

			int index = 0;
			foreach (EntityConfig config in m_parent.EntityConfigs)
			{
				Label number = new();
				number.Text = index.ToString();
				number.Location = new Point(3, 25 * index);
				number.Size = new Size(30, 20);
				panel.Controls.Add(number);

				Label name = new();
				name.Text = config.GetType().UnderlyingSystemType.Name;
				name.Location = new Point(40, 25 * index);
				name.AutoSize = true;
				panel.Controls.Add(name);

				++index;
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			m_parent.SelectedConfig = (int)m_numeric.Value;
		}

		private EntityConfigEditor m_parent;
		private NumericUpDown m_numeric;
	}
}
