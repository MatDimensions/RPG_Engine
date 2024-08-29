namespace AnimationTool
{
	partial class ChoseAnimationType
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
			comboBox = new ComboBox();
			button1 = new Button();
			SuspendLayout();
			// 
			// comboBox
			// 
			comboBox.FormattingEnabled = true;
			comboBox.Items.AddRange(new object[] { "Animation", "TimedAnimation", "MultiAnimation", "MultiTimedAnimation", "Converter" });
			comboBox.Location = new Point(12, 12);
			comboBox.Name = "comboBox";
			comboBox.Size = new Size(193, 23);
			comboBox.TabIndex = 0;
			// 
			// button1
			// 
			button1.Location = new Point(211, 11);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 1;
			button1.Text = "Open";
			button1.UseVisualStyleBackColor = true;
			button1.Click += OpenTool;
			// 
			// ChoseAnimationType
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(302, 48);
			Controls.Add(button1);
			Controls.Add(comboBox);
			MaximizeBox = false;
			Name = "ChoseAnimationType";
			Text = "ChoseAnimationType";
			ResumeLayout(false);
		}

		#endregion

		private ComboBox comboBox;
		private Button button1;
	}
}
