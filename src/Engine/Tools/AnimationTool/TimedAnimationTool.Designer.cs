namespace AnimationTool
{
	partial class TimedAnimationTool
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
			saveFileDialog = new SaveFileDialog();
			openFileDialog = new OpenFileDialog();
			panelSprites = new Panel();
			stopAnimationToolStripMenuItem = new ToolStripMenuItem();
			startAnimationToolStripMenuItem = new ToolStripMenuItem();
			invertListToolStripMenuItem = new ToolStripMenuItem();
			removeDuplicates = new ToolStripMenuItem();
			saveToolStripMenuItem = new ToolStripMenuItem();
			loadToolStripMenuItem = new ToolStripMenuItem();
			fileToolStripMenuItem = new ToolStripMenuItem();
			menuStrip = new MenuStrip();
			addSpritesToolStripMenuItem = new ToolStripMenuItem();
			pictureBox = new PictureBox();
			panelImage = new Panel();
			panelAnim = new Panel();
			splitContainer1 = new SplitContainer();
			splitContainer2 = new SplitContainer();
			menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			panelImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			SuspendLayout();
			// 
			// openFileDialog
			// 
			openFileDialog.FileName = "openFileDialog";
			// 
			// panelSprites
			// 
			panelSprites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelSprites.BorderStyle = BorderStyle.Fixed3D;
			panelSprites.Location = new Point(3, 3);
			panelSprites.Name = "panelSprites";
			panelSprites.Size = new Size(421, 215);
			panelSprites.TabIndex = 7;
			// 
			// stopAnimationToolStripMenuItem
			// 
			stopAnimationToolStripMenuItem.Name = "stopAnimationToolStripMenuItem";
			stopAnimationToolStripMenuItem.Size = new Size(102, 20);
			stopAnimationToolStripMenuItem.Text = "Stop Animation";
			stopAnimationToolStripMenuItem.Click += StopAnimation_Click;
			// 
			// startAnimationToolStripMenuItem
			// 
			startAnimationToolStripMenuItem.Name = "startAnimationToolStripMenuItem";
			startAnimationToolStripMenuItem.Size = new Size(102, 20);
			startAnimationToolStripMenuItem.Text = "Start Animation";
			startAnimationToolStripMenuItem.Click += StartAnimation_Click;
			// 
			// invertListToolStripMenuItem
			// 
			invertListToolStripMenuItem.Name = "invertListToolStripMenuItem";
			invertListToolStripMenuItem.Size = new Size(70, 20);
			invertListToolStripMenuItem.Text = "Invert List";
			invertListToolStripMenuItem.Click += InvertAnimationList_Click;
			// 
			// removeDuplicates
			// 
			removeDuplicates.Name = "removeDuplicates";
			removeDuplicates.Size = new Size(120, 20);
			removeDuplicates.Text = "Remove Duplicates";
			removeDuplicates.Click += RemoveDuplicates_Click;
			// 
			// saveToolStripMenuItem
			// 
			saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			saveToolStripMenuItem.Size = new Size(100, 22);
			saveToolStripMenuItem.Text = "Save";
			saveToolStripMenuItem.Click += Save_Click;
			// 
			// loadToolStripMenuItem
			// 
			loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			loadToolStripMenuItem.Size = new Size(100, 22);
			loadToolStripMenuItem.Text = "Load";
			loadToolStripMenuItem.Click += Load_Click;
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// menuStrip
			// 
			menuStrip.Dock = DockStyle.None;
			menuStrip.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, addSpritesToolStripMenuItem, removeDuplicates, invertListToolStripMenuItem, startAnimationToolStripMenuItem, stopAnimationToolStripMenuItem });
			menuStrip.Location = new Point(0, 0);
			menuStrip.Name = "menuStrip";
			menuStrip.Size = new Size(515, 24);
			menuStrip.TabIndex = 8;
			menuStrip.Text = "menuStrip";
			// 
			// addSpritesToolStripMenuItem
			// 
			addSpritesToolStripMenuItem.Name = "addSpritesToolStripMenuItem";
			addSpritesToolStripMenuItem.Size = new Size(76, 20);
			addSpritesToolStripMenuItem.Text = "AddSprites";
			addSpritesToolStripMenuItem.Click += AddSprites_Click;
			// 
			// pictureBox
			// 
			pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			pictureBox.Location = new Point(3, 3);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new Size(411, 175);
			pictureBox.TabIndex = 0;
			pictureBox.TabStop = false;
			// 
			// panelImage
			// 
			panelImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelImage.BorderStyle = BorderStyle.Fixed3D;
			panelImage.Controls.Add(pictureBox);
			panelImage.Location = new Point(3, 3);
			panelImage.Name = "panelImage";
			panelImage.Size = new Size(421, 185);
			panelImage.TabIndex = 6;
			// 
			// panelAnim
			// 
			panelAnim.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelAnim.BorderStyle = BorderStyle.Fixed3D;
			panelAnim.Location = new Point(3, 3);
			panelAnim.Name = "panelAnim";
			panelAnim.Size = new Size(362, 414);
			panelAnim.TabIndex = 5;
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
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(splitContainer2);
			splitContainer1.Size = new Size(799, 420);
			splitContainer1.SplitterDistance = 368;
			splitContainer1.TabIndex = 9;
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = DockStyle.Fill;
			splitContainer2.Location = new Point(0, 0);
			splitContainer2.Name = "splitContainer2";
			splitContainer2.Orientation = Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(panelImage);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(panelSprites);
			splitContainer2.Size = new Size(427, 420);
			splitContainer2.SplitterDistance = 195;
			splitContainer2.TabIndex = 0;
			// 
			// TimedAnimationTool
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(splitContainer1);
			Controls.Add(menuStrip);
			Name = "TimedAnimationTool";
			Text = "TimedAnimationTool";
			menuStrip.ResumeLayout(false);
			menuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
			panelImage.ResumeLayout(false);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private SaveFileDialog saveFileDialog;
		private OpenFileDialog openFileDialog;
		private Panel panelSprites;
		private ToolStripMenuItem stopAnimationToolStripMenuItem;
		private ToolStripMenuItem startAnimationToolStripMenuItem;
		private ToolStripMenuItem invertListToolStripMenuItem;
		private ToolStripMenuItem removeDuplicates;
		private ToolStripMenuItem saveToolStripMenuItem;
		private ToolStripMenuItem loadToolStripMenuItem;
		private ToolStripMenuItem fileToolStripMenuItem;
		private MenuStrip menuStrip;
		private ToolStripMenuItem addSpritesToolStripMenuItem;
		private PictureBox pictureBox;
		private Panel panelImage;
		private Panel panelAnim;
		private SplitContainer splitContainer1;
		private SplitContainer splitContainer2;
	}
}
