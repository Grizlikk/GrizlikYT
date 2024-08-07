namespace Průhledná_aplikace
{
	partial class MainWindow
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
			TransparencyBar = new TrackBar();
			MainHeadingLabel = new Label();
			TransparencyLabel = new Label();
			((System.ComponentModel.ISupportInitialize)TransparencyBar).BeginInit();
			SuspendLayout();
			// 
			// TransparencyBar
			// 
			TransparencyBar.BackColor = Color.FromArgb(224, 224, 224);
			TransparencyBar.LargeChange = 10;
			TransparencyBar.Location = new Point(12, 90);
			TransparencyBar.Maximum = 100;
			TransparencyBar.Name = "TransparencyBar";
			TransparencyBar.Size = new Size(560, 45);
			TransparencyBar.TabIndex = 0;
			TransparencyBar.Value = 80;
			TransparencyBar.ValueChanged += TransparencyBar_ValueChanged;
			// 
			// MainHeadingLabel
			// 
			MainHeadingLabel.AutoSize = true;
			MainHeadingLabel.Font = new Font("Segoe UI", 44.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
			MainHeadingLabel.Location = new Point(12, 9);
			MainHeadingLabel.Name = "MainHeadingLabel";
			MainHeadingLabel.Size = new Size(562, 78);
			MainHeadingLabel.TabIndex = 1;
			MainHeadingLabel.Text = "Průhledná aplikace";
			// 
			// TransparencyLabel
			// 
			TransparencyLabel.AutoSize = true;
			TransparencyLabel.BackColor = Color.Transparent;
			TransparencyLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 238);
			TransparencyLabel.Location = new Point(128, 143);
			TransparencyLabel.Name = "TransparencyLabel";
			TransparencyLabel.Size = new Size(335, 45);
			TransparencyLabel.TabIndex = 2;
			TransparencyLabel.Text = "Neprůhlednost: 80 %";
			// 
			// MainWindow
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(224, 224, 224);
			ClientSize = new Size(584, 197);
			Controls.Add(TransparencyLabel);
			Controls.Add(MainHeadingLabel);
			Controls.Add(TransparencyBar);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "MainWindow";
			Opacity = 0.8D;
			Text = "Průhledná aplikace";
			((System.ComponentModel.ISupportInitialize)TransparencyBar).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TrackBar TransparencyBar;
		private Label MainHeadingLabel;
		private Label TransparencyLabel;
	}
}
