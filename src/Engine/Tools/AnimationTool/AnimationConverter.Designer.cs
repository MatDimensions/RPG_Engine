namespace AnimationTool
{
	partial class AnimationConverter
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
			button1 = new Button();
			FileName = new Label();
			openFileDialog = new OpenFileDialog();
			saveFileDialog = new SaveFileDialog();
			comboBox = new ComboBox();
			animationType = new Label();
			label1 = new Label();
			button2 = new Button();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(12, 12);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 0;
			button1.Text = "Select File";
			button1.UseVisualStyleBackColor = true;
			button1.Click += SelectFile_Click;
			// 
			// FileName
			// 
			FileName.AutoSize = true;
			FileName.Location = new Point(93, 16);
			FileName.Name = "FileName";
			FileName.Size = new Size(56, 15);
			FileName.TabIndex = 1;
			FileName.Text = "file name";
			// 
			// openFileDialog
			// 
			openFileDialog.FileName = "openFileDialog";
			// 
			// comboBox
			// 
			comboBox.FormattingEnabled = true;
			comboBox.Items.AddRange(new object[] { "Animation", "TimedAnimation", "MultiAnimation", "MultiTimedAnimation" });
			comboBox.Location = new Point(224, 35);
			comboBox.Name = "comboBox";
			comboBox.Size = new Size(193, 23);
			comboBox.TabIndex = 2;
			// 
			// animationType
			// 
			animationType.AutoSize = true;
			animationType.Location = new Point(12, 38);
			animationType.Name = "animationType";
			animationType.Size = new Size(89, 15);
			animationType.TabIndex = 3;
			animationType.Text = "Animation type";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(148, 38);
			label1.Name = "label1";
			label1.Size = new Size(71, 15);
			label1.TabIndex = 4;
			label1.Text = "convert into";
			// 
			// button2
			// 
			button2.Location = new Point(12, 56);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 5;
			button2.Text = "Convert";
			button2.UseVisualStyleBackColor = true;
			button2.Click += Convert_Click;
			// 
			// AnimationConverter
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(429, 90);
			Controls.Add(button2);
			Controls.Add(label1);
			Controls.Add(animationType);
			Controls.Add(comboBox);
			Controls.Add(FileName);
			Controls.Add(button1);
			MaximizeBox = false;
			Name = "AnimationConverter";
			Text = "AnimationConverter";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private Label FileName;
		private OpenFileDialog openFileDialog;
		private SaveFileDialog saveFileDialog;
		private ComboBox comboBox;
		private Label animationType;
		private Label label1;
		private Button button2;
	}
}