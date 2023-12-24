namespace Přejmenování_fotek
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
            TlacitloVybratSoubory = new Button();
            VybratSouboryDialog = new OpenFileDialog();
            ZobrazeniSouboruText = new RichTextBox();
            TlacitkoOdfiltrovatFotky = new Button();
            TlacitkoNahledNazvu = new Button();
            TlacitkoPrejmenovat = new Button();
            FinalniPotvrzeni = new Button();
            MalePismenaPripona = new RadioButton();
            VelkePismenaPripona = new RadioButton();
            OriginalniPripona = new RadioButton();
            SuspendLayout();
            // 
            // TlacitloVybratSoubory
            // 
            TlacitloVybratSoubory.BackColor = Color.FromArgb(224, 224, 224);
            TlacitloVybratSoubory.Location = new Point(758, 12);
            TlacitloVybratSoubory.Name = "TlacitloVybratSoubory";
            TlacitloVybratSoubory.Size = new Size(114, 25);
            TlacitloVybratSoubory.TabIndex = 1;
            TlacitloVybratSoubory.Text = "Vybrat soubory";
            TlacitloVybratSoubory.UseVisualStyleBackColor = false;
            TlacitloVybratSoubory.Click += TlacitloVybratSoubory_Click;
            // 
            // VybratSouboryDialog
            // 
            VybratSouboryDialog.FileName = "VybratSouboryDialog";
            VybratSouboryDialog.Multiselect = true;
            // 
            // ZobrazeniSouboruText
            // 
            ZobrazeniSouboruText.BackColor = Color.FromArgb(224, 224, 224);
            ZobrazeniSouboruText.BorderStyle = BorderStyle.None;
            ZobrazeniSouboruText.ForeColor = Color.Black;
            ZobrazeniSouboruText.Location = new Point(12, 12);
            ZobrazeniSouboruText.Name = "ZobrazeniSouboruText";
            ZobrazeniSouboruText.ReadOnly = true;
            ZobrazeniSouboruText.Size = new Size(740, 437);
            ZobrazeniSouboruText.TabIndex = 4;
            ZobrazeniSouboruText.Text = "";
            // 
            // TlacitkoOdfiltrovatFotky
            // 
            TlacitkoOdfiltrovatFotky.BackColor = Color.FromArgb(224, 224, 224);
            TlacitkoOdfiltrovatFotky.Enabled = false;
            TlacitkoOdfiltrovatFotky.Location = new Point(758, 43);
            TlacitkoOdfiltrovatFotky.Name = "TlacitkoOdfiltrovatFotky";
            TlacitkoOdfiltrovatFotky.Size = new Size(114, 25);
            TlacitkoOdfiltrovatFotky.TabIndex = 5;
            TlacitkoOdfiltrovatFotky.Text = "Odfiltrovat fotky";
            TlacitkoOdfiltrovatFotky.UseVisualStyleBackColor = false;
            TlacitkoOdfiltrovatFotky.Click += TlacitkoOdfiltrovatFotky_Click;
            // 
            // TlacitkoNahledNazvu
            // 
            TlacitkoNahledNazvu.BackColor = Color.FromArgb(224, 224, 224);
            TlacitkoNahledNazvu.Enabled = false;
            TlacitkoNahledNazvu.Location = new Point(758, 74);
            TlacitkoNahledNazvu.Name = "TlacitkoNahledNazvu";
            TlacitkoNahledNazvu.Size = new Size(114, 25);
            TlacitkoNahledNazvu.TabIndex = 6;
            TlacitkoNahledNazvu.Text = "Náhled názvů";
            TlacitkoNahledNazvu.UseVisualStyleBackColor = false;
            TlacitkoNahledNazvu.Click += TlacitkoNahledNazvu_Click;
            // 
            // TlacitkoPrejmenovat
            // 
            TlacitkoPrejmenovat.BackColor = Color.FromArgb(224, 224, 224);
            TlacitkoPrejmenovat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TlacitkoPrejmenovat.ForeColor = Color.Red;
            TlacitkoPrejmenovat.Location = new Point(758, 105);
            TlacitkoPrejmenovat.Name = "TlacitkoPrejmenovat";
            TlacitkoPrejmenovat.Size = new Size(114, 25);
            TlacitkoPrejmenovat.TabIndex = 7;
            TlacitkoPrejmenovat.Text = "PŘEJMENOVAT";
            TlacitkoPrejmenovat.UseVisualStyleBackColor = false;
            TlacitkoPrejmenovat.Visible = false;
            TlacitkoPrejmenovat.Click += TlacitkoPrejmenovat_Click;
            // 
            // FinalniPotvrzeni
            // 
            FinalniPotvrzeni.BackColor = Color.Red;
            FinalniPotvrzeni.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FinalniPotvrzeni.ForeColor = Color.White;
            FinalniPotvrzeni.Location = new Point(758, 384);
            FinalniPotvrzeni.Name = "FinalniPotvrzeni";
            FinalniPotvrzeni.Size = new Size(114, 65);
            FinalniPotvrzeni.TabIndex = 8;
            FinalniPotvrzeni.Text = "FINÁLNÍ POTVRZENÍ PŘEJMENOVÁNÍ\r\n";
            FinalniPotvrzeni.UseVisualStyleBackColor = false;
            FinalniPotvrzeni.Visible = false;
            FinalniPotvrzeni.Click += FinalniPotvrzeni_Click;
            // 
            // MalePismenaPripona
            // 
            MalePismenaPripona.AutoSize = true;
            MalePismenaPripona.BackColor = Color.Silver;
            MalePismenaPripona.Checked = true;
            MalePismenaPripona.Location = new Point(765, 136);
            MalePismenaPripona.Name = "MalePismenaPripona";
            MalePismenaPripona.Size = new Size(102, 34);
            MalePismenaPripona.TabIndex = 9;
            MalePismenaPripona.TabStop = true;
            MalePismenaPripona.Text = "Malé písmena \r\npro příponu";
            MalePismenaPripona.TextAlign = ContentAlignment.MiddleCenter;
            MalePismenaPripona.UseVisualStyleBackColor = false;
            MalePismenaPripona.Click += MalePismenaPripona_Click;
            // 
            // VelkePismenaPripona
            // 
            VelkePismenaPripona.AutoSize = true;
            VelkePismenaPripona.BackColor = Color.Silver;
            VelkePismenaPripona.Location = new Point(765, 176);
            VelkePismenaPripona.Name = "VelkePismenaPripona";
            VelkePismenaPripona.Size = new Size(103, 34);
            VelkePismenaPripona.TabIndex = 10;
            VelkePismenaPripona.Text = "Velké písmena \r\npro příponu";
            VelkePismenaPripona.TextAlign = ContentAlignment.MiddleCenter;
            VelkePismenaPripona.UseVisualStyleBackColor = false;
            VelkePismenaPripona.Click += VelkePismenaPripona_Click;
            // 
            // OriginalniPripona
            // 
            OriginalniPripona.AutoSize = true;
            OriginalniPripona.BackColor = Color.Silver;
            OriginalniPripona.Location = new Point(765, 216);
            OriginalniPripona.Name = "OriginalniPripona";
            OriginalniPripona.Size = new Size(113, 34);
            OriginalniPripona.TabIndex = 11;
            OriginalniPripona.Text = "Nechat původní \r\npříponu  ";
            OriginalniPripona.TextAlign = ContentAlignment.MiddleCenter;
            OriginalniPripona.UseVisualStyleBackColor = false;
            OriginalniPripona.Click += OriginalniPripona_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(880, 457);
            Controls.Add(OriginalniPripona);
            Controls.Add(VelkePismenaPripona);
            Controls.Add(MalePismenaPripona);
            Controls.Add(FinalniPotvrzeni);
            Controls.Add(TlacitkoPrejmenovat);
            Controls.Add(TlacitkoNahledNazvu);
            Controls.Add(TlacitkoOdfiltrovatFotky);
            Controls.Add(ZobrazeniSouboruText);
            Controls.Add(TlacitloVybratSoubory);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(900, 500);
            MinimumSize = new Size(900, 500);
            Name = "MainWindow";
            Text = "Přejmenování fotek";
            ResumeLayout(false);
            PerformLayout();
        }

        private void MalePismenaPripona_Click1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private Button TlacitloVybratSoubory;
        private OpenFileDialog VybratSouboryDialog;
        private RichTextBox ZobrazeniSouboruText;
        private Button TlacitkoOdfiltrovatFotky;
        private Button TlacitkoNahledNazvu;
        private Button TlacitkoPrejmenovat;
        private Button FinalniPotvrzeni;
        private RadioButton MalePismenaPripona;
        private RadioButton VelkePismenaPripona;
        private RadioButton OriginalniPripona;
    }
}