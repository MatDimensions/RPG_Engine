namespace AnimationTool
{
	partial class AnimationTool
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			panelAnim = new Panel();
			panelImage = new Panel();
			pictureBox = new PictureBox();
			menuStrip = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			loadToolStripMenuItem = new ToolStripMenuItem();
			saveToolStripMenuItem = new ToolStripMenuItem();
			addSpritesToolStripMenuItem = new ToolStripMenuItem();
			removeDuplicates = new ToolStripMenuItem();
			invertListToolStripMenuItem = new ToolStripMenuItem();
			startAnimationToolStripMenuItem = new ToolStripMenuItem();
			stopAnimationToolStripMenuItem = new ToolStripMenuItem();
			panelSprites = new Panel();
			openFileDialog = new OpenFileDialog();
			saveFileDialog = new SaveFileDialog();
			label1 = new Label();
			AnimationTimeBox = new TextBox();
			panelImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			menuStrip.SuspendLayout();
			SuspendLayout();
			// 
			// panelAnim
			// 
			panelAnim.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelAnim.BorderStyle = BorderStyle.Fixed3D;
			panelAnim.Location = new Point(12, 27);
			panelAnim.Name = "panelAnim";
			panelAnim.Size = new Size(375, 411);
			panelAnim.TabIndex = 0;
			// 
			// panelImage
			// 
			panelImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			panelImage.BorderStyle = BorderStyle.Fixed3D;
			panelImage.Controls.Add(pictureBox);
			panelImage.Location = new Point(393, 27);
			panelImage.Name = "panelImage";
			panelImage.Size = new Size(395, 185);
			panelImage.TabIndex = 1;
			// 
			// pictureBox
			// 
			pictureBox.Location = new Point(3, 3);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new Size(385, 175);
			pictureBox.TabIndex = 0;
			pictureBox.TabStop = false;
			// 
			// menuStrip
			// 
			menuStrip.Dock = DockStyle.None;
			menuStrip.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, addSpritesToolStripMenuItem, removeDuplicates, invertListToolStripMenuItem, startAnimationToolStripMenuItem, stopAnimationToolStripMenuItem });
			menuStrip.Location = new Point(0, 0);
			menuStrip.Name = "menuStrip";
			menuStrip.Size = new Size(635, 24);
			menuStrip.TabIndex = 2;
			menuStrip.Text = "menuStrip";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// loadToolStripMenuItem
			// 
			loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			loadToolStripMenuItem.Size = new Size(180, 22);
			loadToolStripMenuItem.Text = "Load";
			loadToolStripMenuItem.Click += Load_Click;
			// 
			// saveToolStripMenuItem
			// 
			saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			saveToolStripMenuItem.Size = new Size(180, 22);
			saveToolStripMenuItem.Text = "Save";
			saveToolStripMenuItem.Click += Save_Click;
			// 
			// addSpritesToolStripMenuItem
			// 
			addSpritesToolStripMenuItem.Name = "addSpritesToolStripMenuItem";
			addSpritesToolStripMenuItem.Size = new Size(76, 20);
			addSpritesToolStripMenuItem.Text = "AddSprites";
			addSpritesToolStripMenuItem.Click += AddSprites_Click;
			// 
			// removeDuplicates
			// 
			removeDuplicates.Name = "removeDuplicates";
			removeDuplicates.Size = new Size(120, 20);
			removeDuplicates.Text = "Remove Duplicates";
			removeDuplicates.Click += RemoveDuplicates_Click;
			// 
			// invertListToolStripMenuItem
			// 
			invertListToolStripMenuItem.Name = "invertListToolStripMenuItem";
			invertListToolStripMenuItem.Size = new Size(70, 20);
			invertListToolStripMenuItem.Text = "Invert List";
			invertListToolStripMenuItem.Click += InvertAnimationList_Click;
			// 
			// startAnimationToolStripMenuItem
			// 
			startAnimationToolStripMenuItem.Name = "startAnimationToolStripMenuItem";
			startAnimationToolStripMenuItem.Size = new Size(102, 20);
			startAnimationToolStripMenuItem.Text = "Start Animation";
			startAnimationToolStripMenuItem.Click += StartAnimation_Click;
			// 
			// stopAnimationToolStripMenuItem
			// 
			stopAnimationToolStripMenuItem.Name = "stopAnimationToolStripMenuItem";
			stopAnimationToolStripMenuItem.Size = new Size(102, 20);
			stopAnimationToolStripMenuItem.Text = "Stop Animation";
			stopAnimationToolStripMenuItem.Click += StopAnimation_Click;
			// 
			// panelSprites
			// 
			panelSprites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			panelSprites.BorderStyle = BorderStyle.Fixed3D;
			panelSprites.Location = new Point(393, 218);
			panelSprites.Name = "panelSprites";
			panelSprites.Size = new Size(395, 220);
			panelSprites.TabIndex = 2;
			// 
			// openFileDialog
			// 
			openFileDialog.FileName = "openFileDialog";
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new Point(584, 4);
			label1.Name = "label1";
			label1.Size = new Size(98, 15);
			label1.TabIndex = 3;
			label1.Text = "Animation Time :";
			// 
			// AnimationTimeBox
			// 
			AnimationTimeBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			AnimationTimeBox.Location = new Point(688, 1);
			AnimationTimeBox.Name = "AnimationTimeBox";
			AnimationTimeBox.Size = new Size(100, 23);
			AnimationTimeBox.TabIndex = 4;
			AnimationTimeBox.Text = "1,0";
			// 
			// AnimationTool
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(AnimationTimeBox);
			Controls.Add(label1);
			Controls.Add(panelSprites);
			Controls.Add(panelImage);
			Controls.Add(panelAnim);
			Controls.Add(menuStrip);
			MaximizeBox = false;
			Name = "AnimationTool";
			Text = "AnimationTool";
			panelImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
			menuStrip.ResumeLayout(false);
			menuStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Panel panelAnim;
		private Panel panelImage;
		private MenuStrip menuStrip;
		private ToolStripMenuItem addSpritesToolStripMenuItem;
		private Panel panelSprites;
		private PictureBox pictureBox;
		private OpenFileDialog openFileDialog;
		private SaveFileDialog saveFileDialog;
		private Label label1;
		private TextBox AnimationTimeBox;
		private ToolStripMenuItem removeDuplicates;
		private ToolStripMenuItem invertListToolStripMenuItem;
		private ToolStripMenuItem startAnimationToolStripMenuItem;
		private ToolStripMenuItem stopAnimationToolStripMenuItem;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem loadToolStripMenuItem;
		private ToolStripMenuItem saveToolStripMenuItem;
	}
}
