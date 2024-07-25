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
			menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			panelImage.SuspendLayout();
			SuspendLayout();
			// 
			// openFileDialog
			// 
			openFileDialog.FileName = "openFileDialog";
			// 
			// panelSprites
			// 
			panelSprites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			panelSprites.BorderStyle = BorderStyle.Fixed3D;
			panelSprites.Location = new Point(393, 218);
			panelSprites.Name = "panelSprites";
			panelSprites.Size = new Size(395, 220);
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
			saveToolStripMenuItem.Size = new Size(180, 22);
			saveToolStripMenuItem.Text = "Save";
			saveToolStripMenuItem.Click += Save_Click;
			// 
			// loadToolStripMenuItem
			// 
			loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			loadToolStripMenuItem.Size = new Size(180, 22);
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
			menuStrip.Size = new Size(635, 24);
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
			pictureBox.Location = new Point(3, 3);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new Size(385, 175);
			pictureBox.TabIndex = 0;
			pictureBox.TabStop = false;
			// 
			// panelImage
			// 
			panelImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			panelImage.BorderStyle = BorderStyle.Fixed3D;
			panelImage.Controls.Add(pictureBox);
			panelImage.Location = new Point(393, 27);
			panelImage.Name = "panelImage";
			panelImage.Size = new Size(395, 185);
			panelImage.TabIndex = 6;
			// 
			// panelAnim
			// 
			panelAnim.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelAnim.BorderStyle = BorderStyle.Fixed3D;
			panelAnim.Location = new Point(12, 27);
			panelAnim.Name = "panelAnim";
			panelAnim.Size = new Size(375, 411);
			panelAnim.TabIndex = 5;
			// 
			// TimedAnimationTool
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(panelSprites);
			Controls.Add(menuStrip);
			Controls.Add(panelImage);
			Controls.Add(panelAnim);
			Name = "TimedAnimationTool";
			Text = "TimedAnimationTool";
			menuStrip.ResumeLayout(false);
			menuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
			panelImage.ResumeLayout(false);
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
	}
}
