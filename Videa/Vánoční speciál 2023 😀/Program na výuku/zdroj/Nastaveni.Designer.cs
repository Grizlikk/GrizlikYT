namespace Program_na_výuku
{
    partial class Nastaveni
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nastaveni));
			TlacitkoVybratSoubory = new Button();
			PoznamkaVybratRezimVypisu = new Label();
			PrepinacOriginalNaPreklad = new RadioButton();
			PrepinacPrekladNaOriginal = new RadioButton();
			PrepinacNahodnyVypis = new RadioButton();
			NacistSouborDialog = new OpenFileDialog();
			TlacitkoOK = new Button();
			PoznamkaPocetSlovicek = new Label();
			PocetSlovicekText = new TextBox();
			ZvoleneSouboryText = new RichTextBox();
			TlacitkoVytvoritSouborSlovicek = new Button();
			PoznamkaZvoleneSoubory = new Label();
			TlacitkoVycistitVybrane = new Button();
			SuspendLayout();
			// 
			// TlacitkoVybratSoubory
			// 
			TlacitkoVybratSoubory.BackColor = Color.FromArgb(235, 235, 235);
			TlacitkoVybratSoubory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoVybratSoubory.Location = new Point(462, 66);
			TlacitkoVybratSoubory.Name = "TlacitkoVybratSoubory";
			TlacitkoVybratSoubory.Size = new Size(110, 30);
			TlacitkoVybratSoubory.TabIndex = 1;
			TlacitkoVybratSoubory.Text = "Vybrat soubory";
			TlacitkoVybratSoubory.UseVisualStyleBackColor = false;
			TlacitkoVybratSoubory.Click += TlacitkoVybratSoubory_Click;
			// 
			// PoznamkaVybratRezimVypisu
			// 
			PoznamkaVybratRezimVypisu.AutoSize = true;
			PoznamkaVybratRezimVypisu.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
			PoznamkaVybratRezimVypisu.ImeMode = ImeMode.NoControl;
			PoznamkaVybratRezimVypisu.Location = new Point(12, 75);
			PoznamkaVybratRezimVypisu.Name = "PoznamkaVybratRezimVypisu";
			PoznamkaVybratRezimVypisu.Size = new Size(152, 17);
			PoznamkaVybratRezimVypisu.TabIndex = 0;
			PoznamkaVybratRezimVypisu.Text = "Režim překladu slovíček";
			// 
			// PrepinacOriginalNaPreklad
			// 
			PrepinacOriginalNaPreklad.AutoSize = true;
			PrepinacOriginalNaPreklad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			PrepinacOriginalNaPreklad.ImeMode = ImeMode.NoControl;
			PrepinacOriginalNaPreklad.Location = new Point(12, 102);
			PrepinacOriginalNaPreklad.Name = "PrepinacOriginalNaPreklad";
			PrepinacOriginalNaPreklad.Size = new Size(131, 19);
			PrepinacOriginalNaPreklad.TabIndex = 3;
			PrepinacOriginalNaPreklad.TabStop = true;
			PrepinacOriginalNaPreklad.Text = "Cizí jazyk -> Čeština";
			PrepinacOriginalNaPreklad.UseVisualStyleBackColor = true;
			// 
			// PrepinacPrekladNaOriginal
			// 
			PrepinacPrekladNaOriginal.AutoSize = true;
			PrepinacPrekladNaOriginal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			PrepinacPrekladNaOriginal.ImeMode = ImeMode.NoControl;
			PrepinacPrekladNaOriginal.Location = new Point(12, 127);
			PrepinacPrekladNaOriginal.Name = "PrepinacPrekladNaOriginal";
			PrepinacPrekladNaOriginal.Size = new Size(131, 19);
			PrepinacPrekladNaOriginal.TabIndex = 4;
			PrepinacPrekladNaOriginal.TabStop = true;
			PrepinacPrekladNaOriginal.Text = "Čeština -> Cizí jazyk";
			PrepinacPrekladNaOriginal.UseVisualStyleBackColor = true;
			// 
			// PrepinacNahodnyVypis
			// 
			PrepinacNahodnyVypis.AutoSize = true;
			PrepinacNahodnyVypis.Checked = true;
			PrepinacNahodnyVypis.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			PrepinacNahodnyVypis.ImeMode = ImeMode.NoControl;
			PrepinacNahodnyVypis.Location = new Point(12, 153);
			PrepinacNahodnyVypis.Name = "PrepinacNahodnyVypis";
			PrepinacNahodnyVypis.Size = new Size(104, 19);
			PrepinacNahodnyVypis.TabIndex = 5;
			PrepinacNahodnyVypis.TabStop = true;
			PrepinacNahodnyVypis.Text = "Náhodný výpis";
			PrepinacNahodnyVypis.UseVisualStyleBackColor = true;
			// 
			// NacistSouborDialog
			// 
			NacistSouborDialog.Multiselect = true;
			// 
			// TlacitkoOK
			// 
			TlacitkoOK.BackColor = Color.FromArgb(235, 235, 235);
			TlacitkoOK.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoOK.ImeMode = ImeMode.NoControl;
			TlacitkoOK.Location = new Point(482, 145);
			TlacitkoOK.Name = "TlacitkoOK";
			TlacitkoOK.Size = new Size(90, 30);
			TlacitkoOK.TabIndex = 6;
			TlacitkoOK.Text = "OK";
			TlacitkoOK.UseVisualStyleBackColor = false;
			TlacitkoOK.Click += TlacitkoOK_Click;
			// 
			// PoznamkaPocetSlovicek
			// 
			PoznamkaPocetSlovicek.AutoSize = true;
			PoznamkaPocetSlovicek.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
			PoznamkaPocetSlovicek.ImeMode = ImeMode.NoControl;
			PoznamkaPocetSlovicek.Location = new Point(190, 75);
			PoznamkaPocetSlovicek.Name = "PoznamkaPocetSlovicek";
			PoznamkaPocetSlovicek.Size = new Size(93, 17);
			PoznamkaPocetSlovicek.TabIndex = 0;
			PoznamkaPocetSlovicek.Text = "Počet slovíček";
			// 
			// PocetSlovicekText
			// 
			PocetSlovicekText.BackColor = Color.FromArgb(224, 224, 224);
			PocetSlovicekText.BorderStyle = BorderStyle.FixedSingle;
			PocetSlovicekText.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			PocetSlovicekText.Location = new Point(190, 95);
			PocetSlovicekText.Name = "PocetSlovicekText";
			PocetSlovicekText.Size = new Size(97, 33);
			PocetSlovicekText.TabIndex = 2;
			PocetSlovicekText.Text = "25";
			PocetSlovicekText.TextAlign = HorizontalAlignment.Center;
			PocetSlovicekText.KeyDown += PocetSlovicekText_KeyDown;
			// 
			// ZvoleneSouboryText
			// 
			ZvoleneSouboryText.BackColor = Color.FromArgb(224, 224, 224);
			ZvoleneSouboryText.BorderStyle = BorderStyle.FixedSingle;
			ZvoleneSouboryText.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
			ZvoleneSouboryText.Location = new Point(12, 35);
			ZvoleneSouboryText.Name = "ZvoleneSouboryText";
			ZvoleneSouboryText.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
			ZvoleneSouboryText.Size = new Size(560, 25);
			ZvoleneSouboryText.TabIndex = 7;
			ZvoleneSouboryText.Text = "";
			ZvoleneSouboryText.WordWrap = false;
			ZvoleneSouboryText.KeyDown += ZvolenySouborText_KeyDown;
			// 
			// TlacitkoVytvoritSouborSlovicek
			// 
			TlacitkoVytvoritSouborSlovicek.BackColor = Color.FromArgb(235, 235, 235);
			TlacitkoVytvoritSouborSlovicek.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoVytvoritSouborSlovicek.ImeMode = ImeMode.NoControl;
			TlacitkoVytvoritSouborSlovicek.Location = new Point(345, 105);
			TlacitkoVytvoritSouborSlovicek.Name = "TlacitkoVytvoritSouborSlovicek";
			TlacitkoVytvoritSouborSlovicek.Size = new Size(228, 30);
			TlacitkoVytvoritSouborSlovicek.TabIndex = 9;
			TlacitkoVytvoritSouborSlovicek.Text = "Vytvořit nebo upravit soubor slovíček";
			TlacitkoVytvoritSouborSlovicek.UseVisualStyleBackColor = false;
			TlacitkoVytvoritSouborSlovicek.Click += VytvoritSouborSlovicek_Click;
			// 
			// PoznamkaZvoleneSoubory
			// 
			PoznamkaZvoleneSoubory.AutoSize = true;
			PoznamkaZvoleneSoubory.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
			PoznamkaZvoleneSoubory.ImeMode = ImeMode.NoControl;
			PoznamkaZvoleneSoubory.Location = new Point(12, 15);
			PoznamkaZvoleneSoubory.Name = "PoznamkaZvoleneSoubory";
			PoznamkaZvoleneSoubory.Size = new Size(167, 17);
			PoznamkaZvoleneSoubory.TabIndex = 0;
			PoznamkaZvoleneSoubory.Text = "Aktuálně zvolené soubory";
			// 
			// TlacitkoVycistitVybrane
			// 
			TlacitkoVycistitVybrane.BackColor = Color.FromArgb(235, 235, 235);
			TlacitkoVycistitVybrane.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			TlacitkoVycistitVybrane.ForeColor = Color.DarkRed;
			TlacitkoVycistitVybrane.Location = new Point(392, 68);
			TlacitkoVycistitVybrane.Name = "TlacitkoVycistitVybrane";
			TlacitkoVycistitVybrane.Size = new Size(64, 26);
			TlacitkoVycistitVybrane.TabIndex = 8;
			TlacitkoVycistitVybrane.Text = "Vyčistit";
			TlacitkoVycistitVybrane.UseVisualStyleBackColor = false;
			TlacitkoVycistitVybrane.Click += TlacitkoVycistitVybrane_Click;
			// 
			// Nastaveni
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Silver;
			ClientSize = new Size(584, 186);
			Controls.Add(TlacitkoVycistitVybrane);
			Controls.Add(PoznamkaZvoleneSoubory);
			Controls.Add(TlacitkoVytvoritSouborSlovicek);
			Controls.Add(ZvoleneSouboryText);
			Controls.Add(PocetSlovicekText);
			Controls.Add(PoznamkaPocetSlovicek);
			Controls.Add(TlacitkoOK);
			Controls.Add(PrepinacNahodnyVypis);
			Controls.Add(PrepinacPrekladNaOriginal);
			Controls.Add(PrepinacOriginalNaPreklad);
			Controls.Add(PoznamkaVybratRezimVypisu);
			Controls.Add(TlacitkoVybratSoubory);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "Nastaveni";
			Text = "Nastavení";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button TlacitkoVybratSoubory;
        private Label PoznamkaVybratRezimVypisu;
        public RadioButton PrepinacOriginalNaPreklad;
        public RadioButton PrepinacPrekladNaOriginal;
        public RadioButton PrepinacNahodnyVypis;
        private OpenFileDialog NacistSouborDialog;
        private Button TlacitkoOK;
        private Label PoznamkaPocetSlovicek;
        public TextBox PocetSlovicekText;
        public RichTextBox ZvoleneSouboryText;
        private Button TlacitkoVytvoritSouborSlovicek;
		private Label PoznamkaZvoleneSoubory;
		private Button TlacitkoVycistitVybrane;
	}
}