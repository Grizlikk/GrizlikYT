namespace Program_na_výuku
{
    partial class VytvoritSouborSlovicek
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VytvoritSouborSlovicek));
			PoznamkaCestaKSouboru = new Label();
			CestaKSouboruText = new TextBox();
			TlacitkoOtevritSoubor = new Button();
			TlacitkoUlozitSoubor = new Button();
			TlacitkoPridat = new Button();
			PoznamkaSlovickoCesky = new Label();
			SlovickoCeskyText = new TextBox();
			PoznamkaSlovickoCiziJazyk = new Label();
			SlovickoCiziJazykText = new TextBox();
			SlovickaVypisText = new RichTextBox();
			PoznamkaVypisSouboru = new Label();
			PrepinacZdrojovyVypisSouboru = new CheckBox();
			PrepinacAutomatickeUkladani = new CheckBox();
			NacistSouborDialog = new OpenFileDialog();
			UlozitSouborDialog = new SaveFileDialog();
			TlacitkoNovySoubor = new Button();
			TlacitkoOdebrat = new Button();
			SuspendLayout();
			// 
			// PoznamkaCestaKSouboru
			// 
			PoznamkaCestaKSouboru.AutoSize = true;
			PoznamkaCestaKSouboru.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
			PoznamkaCestaKSouboru.Location = new Point(12, 12);
			PoznamkaCestaKSouboru.Name = "PoznamkaCestaKSouboru";
			PoznamkaCestaKSouboru.Size = new Size(127, 21);
			PoznamkaCestaKSouboru.TabIndex = 0;
			PoznamkaCestaKSouboru.Text = "Cesta k souboru";
			// 
			// CestaKSouboruText
			// 
			CestaKSouboruText.BackColor = Color.FromArgb(224, 224, 224);
			CestaKSouboruText.BorderStyle = BorderStyle.FixedSingle;
			CestaKSouboruText.Enabled = false;
			CestaKSouboruText.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			CestaKSouboruText.Location = new Point(12, 38);
			CestaKSouboruText.Name = "CestaKSouboruText";
			CestaKSouboruText.ReadOnly = true;
			CestaKSouboruText.Size = new Size(1060, 25);
			CestaKSouboruText.TabIndex = 0;
			CestaKSouboruText.TabStop = false;
			CestaKSouboruText.Text = "C:\\Users\\User\\Documents\\Slovicka\\soubor.txt";
			// 
			// TlacitkoOtevritSoubor
			// 
			TlacitkoOtevritSoubor.BackColor = Color.FromArgb(224, 224, 224);
			TlacitkoOtevritSoubor.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoOtevritSoubor.Location = new Point(876, 72);
			TlacitkoOtevritSoubor.Name = "TlacitkoOtevritSoubor";
			TlacitkoOtevritSoubor.Size = new Size(95, 35);
			TlacitkoOtevritSoubor.TabIndex = 2;
			TlacitkoOtevritSoubor.Text = "Otevřít";
			TlacitkoOtevritSoubor.UseVisualStyleBackColor = false;
			TlacitkoOtevritSoubor.Click += TlacitkoOtevritSoubor_Click;
			// 
			// TlacitkoUlozitSoubor
			// 
			TlacitkoUlozitSoubor.BackColor = Color.FromArgb(224, 224, 224);
			TlacitkoUlozitSoubor.Enabled = false;
			TlacitkoUlozitSoubor.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoUlozitSoubor.Location = new Point(977, 72);
			TlacitkoUlozitSoubor.Name = "TlacitkoUlozitSoubor";
			TlacitkoUlozitSoubor.Size = new Size(95, 35);
			TlacitkoUlozitSoubor.TabIndex = 3;
			TlacitkoUlozitSoubor.Text = "Uložit";
			TlacitkoUlozitSoubor.UseVisualStyleBackColor = false;
			TlacitkoUlozitSoubor.Click += TlacitkoUlozitSoubor_Click;
			// 
			// TlacitkoPridat
			// 
			TlacitkoPridat.BackColor = Color.FromArgb(224, 224, 224);
			TlacitkoPridat.Enabled = false;
			TlacitkoPridat.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoPridat.Location = new Point(977, 113);
			TlacitkoPridat.Name = "TlacitkoPridat";
			TlacitkoPridat.Size = new Size(95, 35);
			TlacitkoPridat.TabIndex = 7;
			TlacitkoPridat.Text = "Přidat";
			TlacitkoPridat.UseVisualStyleBackColor = false;
			TlacitkoPridat.Click += TlacitkoPridat_Click;
			// 
			// PoznamkaSlovickoCesky
			// 
			PoznamkaSlovickoCesky.AutoSize = true;
			PoznamkaSlovickoCesky.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
			PoznamkaSlovickoCesky.Location = new Point(500, 92);
			PoznamkaSlovickoCesky.Name = "PoznamkaSlovickoCesky";
			PoznamkaSlovickoCesky.Size = new Size(115, 21);
			PoznamkaSlovickoCesky.TabIndex = 0;
			PoznamkaSlovickoCesky.Text = "Slovíčko česky";
			// 
			// SlovickoCeskyText
			// 
			SlovickoCeskyText.BackColor = Color.FromArgb(224, 224, 224);
			SlovickoCeskyText.BorderStyle = BorderStyle.FixedSingle;
			SlovickoCeskyText.Enabled = false;
			SlovickoCeskyText.Font = new Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point);
			SlovickoCeskyText.Location = new Point(500, 117);
			SlovickoCeskyText.Name = "SlovickoCeskyText";
			SlovickoCeskyText.Size = new Size(471, 27);
			SlovickoCeskyText.TabIndex = 6;
			SlovickoCeskyText.Text = "Ahoj";
			SlovickoCeskyText.KeyDown += SlovickoCeskyText_KeyDown;
			// 
			// PoznamkaSlovickoCiziJazyk
			// 
			PoznamkaSlovickoCiziJazyk.AutoSize = true;
			PoznamkaSlovickoCiziJazyk.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
			PoznamkaSlovickoCiziJazyk.Location = new Point(12, 92);
			PoznamkaSlovickoCiziJazyk.Name = "PoznamkaSlovickoCiziJazyk";
			PoznamkaSlovickoCiziJazyk.Size = new Size(172, 21);
			PoznamkaSlovickoCiziJazyk.TabIndex = 0;
			PoznamkaSlovickoCiziJazyk.Text = "Slovíčko v cizím jazyce";
			// 
			// SlovickoCiziJazykText
			// 
			SlovickoCiziJazykText.BackColor = Color.FromArgb(224, 224, 224);
			SlovickoCiziJazykText.BorderStyle = BorderStyle.FixedSingle;
			SlovickoCiziJazykText.Enabled = false;
			SlovickoCiziJazykText.Font = new Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point);
			SlovickoCiziJazykText.Location = new Point(12, 117);
			SlovickoCiziJazykText.Name = "SlovickoCiziJazykText";
			SlovickoCiziJazykText.Size = new Size(471, 27);
			SlovickoCiziJazykText.TabIndex = 5;
			SlovickoCiziJazykText.Text = "Hello";
			SlovickoCiziJazykText.KeyDown += SlovickoCiziJazykText_KeyDown;
			// 
			// SlovickaVypisText
			// 
			SlovickaVypisText.BackColor = Color.FromArgb(224, 224, 224);
			SlovickaVypisText.BorderStyle = BorderStyle.FixedSingle;
			SlovickaVypisText.Enabled = false;
			SlovickaVypisText.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			SlovickaVypisText.ImeMode = ImeMode.NoControl;
			SlovickaVypisText.Location = new Point(12, 185);
			SlovickaVypisText.Name = "SlovickaVypisText";
			SlovickaVypisText.ReadOnly = true;
			SlovickaVypisText.Size = new Size(1060, 360);
			SlovickaVypisText.TabIndex = 0;
			SlovickaVypisText.TabStop = false;
			SlovickaVypisText.Text = "[1.]\tHello --- Ahoj\n[2.]\tWhy? --- Proč?\n[3.]\tSomeone --- Někdo\n[4.]\tHow are you? --- Jak se máš?";
			SlovickaVypisText.KeyDown += SlovickaVypisText_KeyDown;
			// 
			// PoznamkaVypisSouboru
			// 
			PoznamkaVypisSouboru.AutoSize = true;
			PoznamkaVypisSouboru.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
			PoznamkaVypisSouboru.Location = new Point(12, 160);
			PoznamkaVypisSouboru.Name = "PoznamkaVypisSouboru";
			PoznamkaVypisSouboru.Size = new Size(207, 21);
			PoznamkaVypisSouboru.TabIndex = 0;
			PoznamkaVypisSouboru.Text = "Slovíčka uložené v souboru";
			// 
			// PrepinacZdrojovyVypisSouboru
			// 
			PrepinacZdrojovyVypisSouboru.AutoSize = true;
			PrepinacZdrojovyVypisSouboru.Enabled = false;
			PrepinacZdrojovyVypisSouboru.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			PrepinacZdrojovyVypisSouboru.Location = new Point(800, 160);
			PrepinacZdrojovyVypisSouboru.Name = "PrepinacZdrojovyVypisSouboru";
			PrepinacZdrojovyVypisSouboru.Size = new Size(164, 21);
			PrepinacZdrojovyVypisSouboru.TabIndex = 10;
			PrepinacZdrojovyVypisSouboru.Text = "Zdrojový výpis souboru";
			PrepinacZdrojovyVypisSouboru.UseVisualStyleBackColor = true;
			PrepinacZdrojovyVypisSouboru.CheckedChanged += PrepinacZdrojovyVypisSouboru_CheckedChanged;
			// 
			// PrepinacAutomatickeUkladani
			// 
			PrepinacAutomatickeUkladani.AutoSize = true;
			PrepinacAutomatickeUkladani.Enabled = false;
			PrepinacAutomatickeUkladani.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			PrepinacAutomatickeUkladani.Location = new Point(640, 160);
			PrepinacAutomatickeUkladani.Name = "PrepinacAutomatickeUkladani";
			PrepinacAutomatickeUkladani.Size = new Size(150, 21);
			PrepinacAutomatickeUkladani.TabIndex = 9;
			PrepinacAutomatickeUkladani.Text = "Automatické ukládání";
			PrepinacAutomatickeUkladani.UseVisualStyleBackColor = true;
			PrepinacAutomatickeUkladani.CheckedChanged += PrepinacAutomatickeUkladani_CheckedChanged;
			// 
			// UlozitSouborDialog
			// 
			UlozitSouborDialog.DefaultExt = "txt";
			UlozitSouborDialog.Filter = "Textové dokumenty|*.txt|Všechny soubory|*.*";
			// 
			// TlacitkoNovySoubor
			// 
			TlacitkoNovySoubor.BackColor = Color.FromArgb(224, 224, 224);
			TlacitkoNovySoubor.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoNovySoubor.Location = new Point(775, 72);
			TlacitkoNovySoubor.Name = "TlacitkoNovySoubor";
			TlacitkoNovySoubor.Size = new Size(95, 35);
			TlacitkoNovySoubor.TabIndex = 1;
			TlacitkoNovySoubor.Text = "Nový";
			TlacitkoNovySoubor.UseVisualStyleBackColor = false;
			TlacitkoNovySoubor.Click += TlacitkoNovySoubor_Click;
			// 
			// TlacitkoOdebrat
			// 
			TlacitkoOdebrat.BackColor = Color.FromArgb(224, 224, 224);
			TlacitkoOdebrat.Enabled = false;
			TlacitkoOdebrat.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoOdebrat.Location = new Point(977, 155);
			TlacitkoOdebrat.Name = "TlacitkoOdebrat";
			TlacitkoOdebrat.Size = new Size(95, 26);
			TlacitkoOdebrat.TabIndex = 11;
			TlacitkoOdebrat.Text = "Odebrat";
			TlacitkoOdebrat.UseVisualStyleBackColor = false;
			TlacitkoOdebrat.Click += TlacitkoOdebrat_Click;
			// 
			// VytvoritSouborSlovicek
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Silver;
			ClientSize = new Size(1084, 557);
			Controls.Add(TlacitkoOdebrat);
			Controls.Add(TlacitkoNovySoubor);
			Controls.Add(PrepinacAutomatickeUkladani);
			Controls.Add(PrepinacZdrojovyVypisSouboru);
			Controls.Add(PoznamkaVypisSouboru);
			Controls.Add(SlovickaVypisText);
			Controls.Add(SlovickoCiziJazykText);
			Controls.Add(PoznamkaSlovickoCiziJazyk);
			Controls.Add(SlovickoCeskyText);
			Controls.Add(PoznamkaSlovickoCesky);
			Controls.Add(TlacitkoPridat);
			Controls.Add(TlacitkoUlozitSoubor);
			Controls.Add(TlacitkoOtevritSoubor);
			Controls.Add(CestaKSouboruText);
			Controls.Add(PoznamkaCestaKSouboru);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "VytvoritSouborSlovicek";
			Text = "Editor souborů slovíček";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label PoznamkaCestaKSouboru;
		private TextBox CestaKSouboruText;
		private Button TlacitkoOtevritSoubor;
		private Button TlacitkoUlozitSoubor;
		private Button TlacitkoPridat;
		private Label PoznamkaSlovickoCesky;
		private TextBox SlovickoCeskyText;
		private Label PoznamkaSlovickoCiziJazyk;
		private TextBox SlovickoCiziJazykText;
		private RichTextBox SlovickaVypisText;
		private Label PoznamkaVypisSouboru;
		private CheckBox PrepinacZdrojovyVypisSouboru;
		private CheckBox PrepinacAutomatickeUkladani;
		private OpenFileDialog NacistSouborDialog;
		private SaveFileDialog UlozitSouborDialog;
		private Button TlacitkoNovySoubor;
		private Button TlacitkoOdebrat;
	}
}