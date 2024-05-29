namespace Hash_z_textu_GUI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			HashTextBox = new TextBox();
			HashLabel = new Label();
			TextLabel = new Label();
			InputTextBox = new TextBox();
			CalculateHashButton = new Button();
			AlgorithmSelector = new ComboBox();
			SuspendLayout();
			// 
			// HashTextBox
			// 
			HashTextBox.BackColor = Color.FromArgb(224, 224, 224);
			HashTextBox.BorderStyle = BorderStyle.FixedSingle;
			HashTextBox.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
			HashTextBox.Location = new Point(67, 74);
			HashTextBox.Name = "HashTextBox";
			HashTextBox.ReadOnly = true;
			HashTextBox.Size = new Size(1012, 27);
			HashTextBox.TabIndex = 4;
			HashTextBox.Text = "955db0b81ef1989b4a4dfeae8061a9a6";
			// 
			// HashLabel
			// 
			HashLabel.AutoSize = true;
			HashLabel.BackColor = Color.Transparent;
			HashLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
			HashLabel.Location = new Point(12, 78);
			HashLabel.Name = "HashLabel";
			HashLabel.Size = new Size(54, 20);
			HashLabel.TabIndex = 0;
			HashLabel.Text = "HASH:";
			// 
			// TextLabel
			// 
			TextLabel.AutoSize = true;
			TextLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
			TextLabel.Location = new Point(13, 33);
			TextLabel.Name = "TextLabel";
			TextLabel.Size = new Size(49, 20);
			TextLabel.TabIndex = 0;
			TextLabel.Text = "TEXT:";
			// 
			// InputTextBox
			// 
			InputTextBox.BackColor = Color.FromArgb(224, 224, 224);
			InputTextBox.BorderStyle = BorderStyle.FixedSingle;
			InputTextBox.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
			InputTextBox.Location = new Point(67, 30);
			InputTextBox.Name = "InputTextBox";
			InputTextBox.Size = new Size(1012, 27);
			InputTextBox.TabIndex = 1;
			InputTextBox.Text = "heslo";
			InputTextBox.KeyDown += InputTextBox_KeyDown;
			// 
			// CalculateHashButton
			// 
			CalculateHashButton.Font = new Font("Microsoft Sans Serif", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 238);
			CalculateHashButton.Location = new Point(1085, 74);
			CalculateHashButton.Name = "CalculateHashButton";
			CalculateHashButton.Size = new Size(130, 27);
			CalculateHashButton.TabIndex = 3;
			CalculateHashButton.Text = "Vypočítat HASH";
			CalculateHashButton.UseVisualStyleBackColor = true;
			CalculateHashButton.Click += CalculateHashButton_Click;
			// 
			// AlgorithmSelector
			// 
			AlgorithmSelector.BackColor = Color.FromArgb(224, 224, 224);
			AlgorithmSelector.DropDownStyle = ComboBoxStyle.DropDownList;
			AlgorithmSelector.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
			AlgorithmSelector.FormattingEnabled = true;
			AlgorithmSelector.ImeMode = ImeMode.NoControl;
			AlgorithmSelector.Items.AddRange(new object[] { "MD5", "SHA1", "SHA256", "SHA384", "SHA512" });
			AlgorithmSelector.Location = new Point(1085, 30);
			AlgorithmSelector.MaxDropDownItems = 5;
			AlgorithmSelector.Name = "AlgorithmSelector";
			AlgorithmSelector.Size = new Size(130, 28);
			AlgorithmSelector.TabIndex = 2;
			// 
			// MainWindow
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Silver;
			ClientSize = new Size(1227, 131);
			Controls.Add(AlgorithmSelector);
			Controls.Add(CalculateHashButton);
			Controls.Add(TextLabel);
			Controls.Add(InputTextBox);
			Controls.Add(HashLabel);
			Controls.Add(HashTextBox);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "MainWindow";
			Text = "Hash z textu";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox HashTextBox;
		private Label HashLabel;
		private Label TextLabel;
		private TextBox InputTextBox;
		private Button CalculateHashButton;
		private ComboBox AlgorithmSelector;
	}
}
