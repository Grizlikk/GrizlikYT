namespace Program_na_výuku
{
	partial class ZadejteSlovickoKOdebrani
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZadejteSlovickoKOdebrani));
			PoznamkaSlovickoKOdebrani = new Label();
			SlovickoKOdebrani = new TextBox();
			TlacitkoOK = new Button();
			PoznamkaPlatnostRozsahu = new Label();
			SuspendLayout();
			// 
			// PoznamkaSlovickoKOdebrani
			// 
			PoznamkaSlovickoKOdebrani.AutoSize = true;
			PoznamkaSlovickoKOdebrani.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
			PoznamkaSlovickoKOdebrani.Location = new Point(12, 9);
			PoznamkaSlovickoKOdebrani.Name = "PoznamkaSlovickoKOdebrani";
			PoznamkaSlovickoKOdebrani.Size = new Size(419, 21);
			PoznamkaSlovickoKOdebrani.TabIndex = 1;
			PoznamkaSlovickoKOdebrani.Text = "Zadejte číslo (12) nebo rozsah* (4-10) slovíček k odebrání";
			// 
			// SlovickoKOdebrani
			// 
			SlovickoKOdebrani.BackColor = Color.FromArgb(224, 224, 224);
			SlovickoKOdebrani.BorderStyle = BorderStyle.FixedSingle;
			SlovickoKOdebrani.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			SlovickoKOdebrani.Location = new Point(12, 61);
			SlovickoKOdebrani.Name = "SlovickoKOdebrani";
			SlovickoKOdebrani.Size = new Size(316, 33);
			SlovickoKOdebrani.TabIndex = 1;
			SlovickoKOdebrani.TextAlign = HorizontalAlignment.Center;
			SlovickoKOdebrani.KeyDown += SlovickoKOdebrani_KeyDown;
			// 
			// TlacitkoOK
			// 
			TlacitkoOK.BackColor = Color.FromArgb(235, 235, 235);
			TlacitkoOK.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoOK.ImeMode = ImeMode.NoControl;
			TlacitkoOK.Location = new Point(341, 62);
			TlacitkoOK.Name = "TlacitkoOK";
			TlacitkoOK.Size = new Size(90, 31);
			TlacitkoOK.TabIndex = 2;
			TlacitkoOK.Text = "OK";
			TlacitkoOK.UseVisualStyleBackColor = false;
			TlacitkoOK.Click += TlacitkoOK_Click;
			// 
			// PoznamkaPlatnostRozsahu
			// 
			PoznamkaPlatnostRozsahu.AutoSize = true;
			PoznamkaPlatnostRozsahu.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
			PoznamkaPlatnostRozsahu.Location = new Point(12, 34);
			PoznamkaPlatnostRozsahu.Name = "PoznamkaPlatnostRozsahu";
			PoznamkaPlatnostRozsahu.Size = new Size(303, 21);
			PoznamkaPlatnostRozsahu.TabIndex = 3;
			PoznamkaPlatnostRozsahu.Text = "*Rozsah platí včetně obou krajních pozic";
			// 
			// ZadejteSlovickoKOdebrani
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Silver;
			ClientSize = new Size(443, 101);
			Controls.Add(PoznamkaPlatnostRozsahu);
			Controls.Add(TlacitkoOK);
			Controls.Add(SlovickoKOdebrani);
			Controls.Add(PoznamkaSlovickoKOdebrani);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "ZadejteSlovickoKOdebrani";
			Text = "Zvolte slovíčka k odebrání";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label PoznamkaSlovickoKOdebrani;
		public TextBox SlovickoKOdebrani;
		private Button TlacitkoOK;
		private Label PoznamkaPlatnostRozsahu;
	}
}