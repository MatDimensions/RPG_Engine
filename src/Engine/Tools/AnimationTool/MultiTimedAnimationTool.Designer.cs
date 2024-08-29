namespace AnimationTool
{
	partial class MultiTimedAnimationTool
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
			addAnimationToolStripMenuItem = new ToolStripMenuItem();
			removeDuplicates = new ToolStripMenuItem();
			invertListToolStripMenuItem = new ToolStripMenuItem();
			startAnimationToolStripMenuItem = new ToolStripMenuItem();
			stopAnimationToolStripMenuItem = new ToolStripMenuItem();
			panelSprites = new Panel();
			openFileDialog = new OpenFileDialog();
			saveFileDialog = new SaveFileDialog();
			panelAnimsNames = new Panel();
			label2 = new Label();
			AnimationNameBox = new TextBox();
			splitContainer1 = new SplitContainer();
			splitContainer2 = new SplitContainer();
			splitContainer3 = new SplitContainer();
			panelImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
			splitContainer3.Panel1.SuspendLayout();
			splitContainer3.Panel2.SuspendLayout();
			splitContainer3.SuspendLayout();
			SuspendLayout();
			// 
			// panelAnim
			// 
			panelAnim.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelAnim.BorderStyle = BorderStyle.Fixed3D;
			panelAnim.Location = new Point(3, 29);
			panelAnim.Name = "panelAnim";
			panelAnim.Size = new Size(407, 507);
			panelAnim.TabIndex = 0;
			// 
			// panelImage
			// 
			panelImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelImage.BorderStyle = BorderStyle.Fixed3D;
			panelImage.Controls.Add(pictureBox);
			panelImage.Location = new Point(3, 3);
			panelImage.Name = "panelImage";
			panelImage.Size = new Size(388, 316);
			panelImage.TabIndex = 1;
			// 
			// pictureBox
			// 
			pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			pictureBox.Location = new Point(3, 3);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new Size(378, 306);
			pictureBox.TabIndex = 0;
			pictureBox.TabStop = false;
			// 
			// menuStrip
			// 
			menuStrip.Dock = DockStyle.None;
			menuStrip.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, addSpritesToolStripMenuItem, addAnimationToolStripMenuItem, removeDuplicates, invertListToolStripMenuItem, startAnimationToolStripMenuItem, stopAnimationToolStripMenuItem });
			menuStrip.Location = new Point(0, 0);
			menuStrip.Name = "menuStrip";
			menuStrip.Size = new Size(615, 24);
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
			loadToolStripMenuItem.Size = new Size(100, 22);
			loadToolStripMenuItem.Text = "Load";
			loadToolStripMenuItem.Click += Load_Click;
			// 
			// saveToolStripMenuItem
			// 
			saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			saveToolStripMenuItem.Size = new Size(100, 22);
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
			// addAnimationToolStripMenuItem
			// 
			addAnimationToolStripMenuItem.Name = "addAnimationToolStripMenuItem";
			addAnimationToolStripMenuItem.Size = new Size(100, 20);
			addAnimationToolStripMenuItem.Text = "Add Animation";
			addAnimationToolStripMenuItem.Click += AddAnimation_Click;
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
			panelSprites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelSprites.BorderStyle = BorderStyle.Fixed3D;
			panelSprites.Location = new Point(3, 3);
			panelSprites.Name = "panelSprites";
			panelSprites.Size = new Size(388, 207);
			panelSprites.TabIndex = 2;
			// 
			// openFileDialog
			// 
			openFileDialog.FileName = "openFileDialog";
			// 
			// panelAnimsNames
			// 
			panelAnimsNames.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelAnimsNames.BorderStyle = BorderStyle.Fixed3D;
			panelAnimsNames.Location = new Point(3, 3);
			panelAnimsNames.Name = "panelAnimsNames";
			panelAnimsNames.Size = new Size(192, 533);
			panelAnimsNames.TabIndex = 5;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(3, 3);
			label2.Name = "label2";
			label2.Size = new Size(104, 15);
			label2.TabIndex = 6;
			label2.Text = "Animation Name :";
			// 
			// AnimationNameBox
			// 
			AnimationNameBox.Location = new Point(107, 0);
			AnimationNameBox.Name = "AnimationNameBox";
			AnimationNameBox.Size = new Size(191, 23);
			AnimationNameBox.TabIndex = 7;
			// 
			// splitContainer1
			// 
			splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer1.Location = new Point(0, 27);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(panelAnim);
			splitContainer1.Panel1.Controls.Add(AnimationNameBox);
			splitContainer1.Panel1.Controls.Add(label2);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(splitContainer2);
			splitContainer1.Size = new Size(1017, 539);
			splitContainer1.SplitterDistance = 414;
			splitContainer1.TabIndex = 8;
			// 
			// splitContainer2
			// 
			splitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer2.Location = new Point(3, 0);
			splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(panelAnimsNames);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(splitContainer3);
			splitContainer2.Size = new Size(596, 539);
			splitContainer2.SplitterDistance = 198;
			splitContainer2.TabIndex = 0;
			// 
			// splitContainer3
			// 
			splitContainer3.Dock = DockStyle.Fill;
			splitContainer3.Location = new Point(0, 0);
			splitContainer3.Name = "splitContainer3";
			splitContainer3.Orientation = Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			splitContainer3.Panel1.Controls.Add(panelImage);
			// 
			// splitContainer3.Panel2
			// 
			splitContainer3.Panel2.Controls.Add(panelSprites);
			splitContainer3.Size = new Size(394, 539);
			splitContainer3.SplitterDistance = 322;
			splitContainer3.TabIndex = 0;
			// 
			// MultiTimedAnimationTool
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1020, 569);
			Controls.Add(splitContainer1);
			Controls.Add(menuStrip);
			MaximizeBox = false;
			Name = "MultiTimedAnimationTool";
			Text = "AnimationTool";
			panelImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
			menuStrip.ResumeLayout(false);
			menuStrip.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			splitContainer3.Panel1.ResumeLayout(false);
			splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
			splitContainer3.ResumeLayout(false);
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
		private ToolStripMenuItem removeDuplicates;
		private ToolStripMenuItem invertListToolStripMenuItem;
		private ToolStripMenuItem startAnimationToolStripMenuItem;
		private ToolStripMenuItem stopAnimationToolStripMenuItem;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem loadToolStripMenuItem;
		private ToolStripMenuItem saveToolStripMenuItem;
		private Panel panelAnimsNames;
		private Label label2;
		private TextBox AnimationNameBox;
		private ToolStripMenuItem addAnimationToolStripMenuItem;
		private SplitContainer splitContainer1;
		private SplitContainer splitContainer2;
		private SplitContainer splitContainer3;
	}
}
