namespace EntityConfigEditor
{
	partial class EntityConfigEditor
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityConfigEditor));
			saveFileDialog = new SaveFileDialog();
			openFileDialog = new OpenFileDialog();
			toolStrip = new ToolStrip();
			toolStripDropDownButton = new ToolStripDropDownButton();
			testToolStripMenuItem = new ToolStripMenuItem();
			createNewEntityConfigToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripMenuItem();
			saveEntityConfigToolStripMenuItem = new ToolStripMenuItem();
			panel = new Panel();
			toolStrip.SuspendLayout();
			SuspendLayout();
			// 
			// openFileDialog
			// 
			openFileDialog.FileName = "openFileDialog1";
			// 
			// toolStrip
			// 
			toolStrip.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton });
			toolStrip.Location = new Point(0, 0);
			toolStrip.Name = "toolStrip";
			toolStrip.Size = new Size(800, 25);
			toolStrip.TabIndex = 0;
			toolStrip.Text = "toolStrip";
			// 
			// toolStripDropDownButton
			// 
			toolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
			toolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { testToolStripMenuItem, createNewEntityConfigToolStripMenuItem, toolStripMenuItem1, saveEntityConfigToolStripMenuItem });
			toolStripDropDownButton.Image = (Image)resources.GetObject("toolStripDropDownButton.Image");
			toolStripDropDownButton.ImageTransparentColor = Color.Magenta;
			toolStripDropDownButton.Name = "toolStripDropDownButton";
			toolStripDropDownButton.Size = new Size(38, 22);
			toolStripDropDownButton.Text = "File";
			toolStripDropDownButton.ToolTipText = "File";
			// 
			// testToolStripMenuItem
			// 
			testToolStripMenuItem.Name = "testToolStripMenuItem";
			testToolStripMenuItem.Size = new Size(205, 22);
			testToolStripMenuItem.Text = "Change Config Selected";
			testToolStripMenuItem.Click += ChangeEntityConfigSelected;
			// 
			// createNewEntityConfigToolStripMenuItem
			// 
			createNewEntityConfigToolStripMenuItem.Name = "createNewEntityConfigToolStripMenuItem";
			createNewEntityConfigToolStripMenuItem.Size = new Size(205, 22);
			createNewEntityConfigToolStripMenuItem.Text = "Create new Entity Config";
			createNewEntityConfigToolStripMenuItem.Click += CreateNewEntityConfig;
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(205, 22);
			toolStripMenuItem1.Text = "Load an Entity Config";
			toolStripMenuItem1.Click += LoadEntityConfig;
			// 
			// saveEntityConfigToolStripMenuItem
			// 
			saveEntityConfigToolStripMenuItem.Name = "saveEntityConfigToolStripMenuItem";
			saveEntityConfigToolStripMenuItem.Size = new Size(205, 22);
			saveEntityConfigToolStripMenuItem.Text = "Save Entity Config";
			saveEntityConfigToolStripMenuItem.Click += SaveEntityConfig;
			// 
			// panel
			// 
			panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panel.BorderStyle = BorderStyle.Fixed3D;
			panel.Location = new Point(12, 28);
			panel.Name = "panel";
			panel.Size = new Size(776, 410);
			panel.TabIndex = 3;
			// 
			// EntityConfigEditor
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(panel);
			Controls.Add(toolStrip);
			MaximizeBox = false;
			Name = "EntityConfigEditor";
			Text = "EntityConfigEditor";
			toolStrip.ResumeLayout(false);
			toolStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private SaveFileDialog saveFileDialog;
		private OpenFileDialog openFileDialog;
		private ToolStrip toolStrip;
		private ToolStripDropDownButton toolStripDropDownButton;
		private ToolStripMenuItem toolStripMenuItem1;
		private Panel panel;
		private ToolStripMenuItem saveEntityConfigToolStripMenuItem;
		private ToolStripMenuItem createNewEntityConfigToolStripMenuItem;
		private ToolStripMenuItem testToolStripMenuItem;
	}
}
