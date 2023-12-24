namespace Program_na_výuku
{
    partial class HlavniAplikace
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HlavniAplikace));
			Background2 = new TextBox();
			Background3 = new TextBox();
			Background1 = new TextBox();
			SlovickoZadavani = new TextBox();
			SlovickoKPrekladu = new TextBox();
			SpravnyPreklad = new TextBox();
			ProgressBarTrenovani = new ProgressBar();
			Background4 = new TextBox();
			TlacitkoSpravne = new Button();
			TlacitkoSpatne = new Button();
			TlacitkoNastaveni = new Button();
			PoznamkaNacitaniNastaveni = new Label();
			TlacitkoSpustitProgram = new Button();
			TlacitkoUkoncit = new Button();
			SuspendLayout();
			// 
			// Background2
			// 
			Background2.BackColor = Color.FromArgb(224, 224, 224);
			Background2.BorderStyle = BorderStyle.FixedSingle;
			Background2.Enabled = false;
			Background2.Location = new Point(25, 140);
			Background2.Multiline = true;
			Background2.Name = "Background2";
			Background2.ReadOnly = true;
			Background2.Size = new Size(500, 90);
			Background2.TabIndex = 0;
			Background2.TabStop = false;
			Background2.WordWrap = false;
			// 
			// Background3
			// 
			Background3.BackColor = Color.FromArgb(224, 224, 224);
			Background3.BorderStyle = BorderStyle.FixedSingle;
			Background3.Enabled = false;
			Background3.Location = new Point(25, 255);
			Background3.Multiline = true;
			Background3.Name = "Background3";
			Background3.ReadOnly = true;
			Background3.Size = new Size(500, 90);
			Background3.TabIndex = 0;
			Background3.TabStop = false;
			Background3.WordWrap = false;
			// 
			// Background1
			// 
			Background1.BackColor = Color.FromArgb(224, 224, 224);
			Background1.BorderStyle = BorderStyle.FixedSingle;
			Background1.Enabled = false;
			Background1.Location = new Point(25, 25);
			Background1.Multiline = true;
			Background1.Name = "Background1";
			Background1.ReadOnly = true;
			Background1.Size = new Size(500, 90);
			Background1.TabIndex = 0;
			Background1.TabStop = false;
			Background1.WordWrap = false;
			// 
			// SlovickoZadavani
			// 
			SlovickoZadavani.AcceptsReturn = true;
			SlovickoZadavani.BackColor = Color.FromArgb(224, 224, 224);
			SlovickoZadavani.BorderStyle = BorderStyle.None;
			SlovickoZadavani.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
			SlovickoZadavani.Location = new Point(26, 158);
			SlovickoZadavani.Multiline = true;
			SlovickoZadavani.Name = "SlovickoZadavani";
			SlovickoZadavani.ReadOnly = true;
			SlovickoZadavani.Size = new Size(495, 54);
			SlovickoZadavani.TabIndex = 6;
			SlovickoZadavani.TabStop = false;
			SlovickoZadavani.Text = "[překlad]";
			SlovickoZadavani.WordWrap = false;
			SlovickoZadavani.KeyDown += SlovickoZadavani_KeyDown;
			// 
			// SlovickoKPrekladu
			// 
			SlovickoKPrekladu.BackColor = Color.FromArgb(224, 224, 224);
			SlovickoKPrekladu.BorderStyle = BorderStyle.None;
			SlovickoKPrekladu.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
			SlovickoKPrekladu.Location = new Point(38, 43);
			SlovickoKPrekladu.Name = "SlovickoKPrekladu";
			SlovickoKPrekladu.ReadOnly = true;
			SlovickoKPrekladu.Size = new Size(486, 54);
			SlovickoKPrekladu.TabIndex = 0;
			SlovickoKPrekladu.TabStop = false;
			SlovickoKPrekladu.Text = "[originál]";
			// 
			// SpravnyPreklad
			// 
			SpravnyPreklad.BackColor = Color.FromArgb(224, 224, 224);
			SpravnyPreklad.BorderStyle = BorderStyle.None;
			SpravnyPreklad.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
			SpravnyPreklad.ForeColor = Color.FromArgb(0, 192, 0);
			SpravnyPreklad.Location = new Point(38, 273);
			SpravnyPreklad.Name = "SpravnyPreklad";
			SpravnyPreklad.ReadOnly = true;
			SpravnyPreklad.Size = new Size(486, 54);
			SpravnyPreklad.TabIndex = 0;
			SpravnyPreklad.TabStop = false;
			SpravnyPreklad.Text = "[správná odpověď]";
			// 
			// ProgressBarTrenovani
			// 
			ProgressBarTrenovani.BackColor = Color.FromArgb(224, 224, 224);
			ProgressBarTrenovani.Location = new Point(25, 360);
			ProgressBarTrenovani.Name = "ProgressBarTrenovani";
			ProgressBarTrenovani.Size = new Size(670, 25);
			ProgressBarTrenovani.Step = 1;
			ProgressBarTrenovani.TabIndex = 0;
			// 
			// Background4
			// 
			Background4.BackColor = Color.Silver;
			Background4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			Background4.Location = new Point(24, 359);
			Background4.Name = "Background4";
			Background4.ReadOnly = true;
			Background4.Size = new Size(672, 27);
			Background4.TabIndex = 0;
			Background4.TabStop = false;
			// 
			// TlacitkoSpravne
			// 
			TlacitkoSpravne.BackColor = Color.FromArgb(224, 255, 224);
			TlacitkoSpravne.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoSpravne.Location = new Point(535, 260);
			TlacitkoSpravne.Name = "TlacitkoSpravne";
			TlacitkoSpravne.Size = new Size(100, 35);
			TlacitkoSpravne.TabIndex = 3;
			TlacitkoSpravne.Text = "SPRÁVNĚ";
			TlacitkoSpravne.UseVisualStyleBackColor = false;
			TlacitkoSpravne.Visible = false;
			TlacitkoSpravne.Click += TlacitkoSpravne_Click;
			// 
			// TlacitkoSpatne
			// 
			TlacitkoSpatne.BackColor = Color.FromArgb(255, 224, 224);
			TlacitkoSpatne.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoSpatne.Location = new Point(535, 305);
			TlacitkoSpatne.Name = "TlacitkoSpatne";
			TlacitkoSpatne.Size = new Size(100, 35);
			TlacitkoSpatne.TabIndex = 4;
			TlacitkoSpatne.Text = "ŠPATNĚ";
			TlacitkoSpatne.UseVisualStyleBackColor = false;
			TlacitkoSpatne.Visible = false;
			TlacitkoSpatne.Click += TlacitkoSpatne_Click;
			// 
			// TlacitkoNastaveni
			// 
			TlacitkoNastaveni.BackColor = Color.FromArgb(224, 224, 224);
			TlacitkoNastaveni.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoNastaveni.Location = new Point(545, 25);
			TlacitkoNastaveni.Name = "TlacitkoNastaveni";
			TlacitkoNastaveni.Size = new Size(150, 35);
			TlacitkoNastaveni.TabIndex = 1;
			TlacitkoNastaveni.Text = "Nastavení";
			TlacitkoNastaveni.UseVisualStyleBackColor = false;
			TlacitkoNastaveni.Click += TlacitkoNastaveni_Click;
			// 
			// PoznamkaNacitaniNastaveni
			// 
			PoznamkaNacitaniNastaveni.AutoSize = true;
			PoznamkaNacitaniNastaveni.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
			PoznamkaNacitaniNastaveni.Location = new Point(540, 343);
			PoznamkaNacitaniNastaveni.Name = "PoznamkaNacitaniNastaveni";
			PoznamkaNacitaniNastaveni.Size = new Size(155, 15);
			PoznamkaNacitaniNastaveni.TabIndex = 0;
			PoznamkaNacitaniNastaveni.Text = "Probíhá načítání nastavení...";
			PoznamkaNacitaniNastaveni.Visible = false;
			// 
			// TlacitkoSpustitProgram
			// 
			TlacitkoSpustitProgram.BackColor = Color.FromArgb(224, 224, 224);
			TlacitkoSpustitProgram.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoSpustitProgram.Location = new Point(545, 75);
			TlacitkoSpustitProgram.Name = "TlacitkoSpustitProgram";
			TlacitkoSpustitProgram.Size = new Size(150, 35);
			TlacitkoSpustitProgram.TabIndex = 2;
			TlacitkoSpustitProgram.Text = "Spustit program";
			TlacitkoSpustitProgram.UseVisualStyleBackColor = false;
			TlacitkoSpustitProgram.Click += TlacitkoSpustitProgram_Click;
			// 
			// TlacitkoUkoncit
			// 
			TlacitkoUkoncit.BackColor = Color.FromArgb(224, 224, 224);
			TlacitkoUkoncit.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoUkoncit.ForeColor = Color.FromArgb(192, 0, 0);
			TlacitkoUkoncit.Location = new Point(545, 125);
			TlacitkoUkoncit.Name = "TlacitkoUkoncit";
			TlacitkoUkoncit.Size = new Size(150, 35);
			TlacitkoUkoncit.TabIndex = 5;
			TlacitkoUkoncit.Text = "KONEC";
			TlacitkoUkoncit.UseVisualStyleBackColor = false;
			TlacitkoUkoncit.Click += TlacitkoUkoncit_Click;
			// 
			// HlavniAplikace
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Silver;
			ClientSize = new Size(705, 397);
			Controls.Add(TlacitkoUkoncit);
			Controls.Add(TlacitkoSpustitProgram);
			Controls.Add(PoznamkaNacitaniNastaveni);
			Controls.Add(TlacitkoNastaveni);
			Controls.Add(TlacitkoSpatne);
			Controls.Add(TlacitkoSpravne);
			Controls.Add(SpravnyPreklad);
			Controls.Add(SlovickoKPrekladu);
			Controls.Add(SlovickoZadavani);
			Controls.Add(Background1);
			Controls.Add(Background3);
			Controls.Add(Background2);
			Controls.Add(ProgressBarTrenovani);
			Controls.Add(Background4);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "HlavniAplikace";
			Text = "Program na výuku";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private TextBox Background2;
        private TextBox Background3;
        private TextBox Background1;
        private TextBox SlovickoZadavani;
        private TextBox SlovickoKPrekladu;
        private TextBox SpravnyPreklad;
        private ProgressBar ProgressBarTrenovani;
        private TextBox Background4;
        private Button TlacitkoSpravne;
        private Button TlacitkoSpatne;
        private Button TlacitkoNastaveni;
        private Label PoznamkaNacitaniNastaveni;
        private Button TlacitkoSpustitProgram;
        private Button TlacitkoUkoncit;
    }
}