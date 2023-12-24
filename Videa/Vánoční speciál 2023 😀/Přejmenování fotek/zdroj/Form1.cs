namespace Přejmenování_fotek
{
    public partial class MainWindow : Form
    {
        string[] soubory = new string[0];
        List<string> fotky = new List<string>();
        bool prejmenovani = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TlacitloVybratSoubory_Click(object sender, EventArgs e)
        {
            // Zobrazeni vybrani souboru
            DialogResult vysledek = VybratSouboryDialog.ShowDialog();
            if (vysledek == DialogResult.OK)
            {
                // Ulozeni vsech vybranych souboru
                soubory = VybratSouboryDialog.FileNames;

                // Nastaveni barvy
                ZobrazeniSouboruText.Text = "";
                ZobrazeniSouboruText.ForeColor = Color.Black;

                fotky.Clear();
                foreach (string s in soubory)
                {
                    // Vypis vybranych souboru a vyber fotek
                    ZobrazeniSouboruText.AppendText(s + "\n");
                    if (JeFotka(s))
                    {
                        fotky.Add(s);
                    }
                }
                TlacitkoOdfiltrovatFotky.Enabled = true;
            }
        }

        private void TlacitkoOdfiltrovatFotky_Click(object sender, EventArgs e)
        {
            if (NeplatneZadani())
            {
                return;
            }

            // Nastaveni barvy
            ZobrazeniSouboruText.Text = "";
            ZobrazeniSouboruText.ForeColor = Color.ForestGreen;

            // Vypsani vsech fotek
            foreach (string f in fotky)
            {
                ZobrazeniSouboruText.AppendText(f + "\n");
            }
            TlacitkoNahledNazvu.Enabled = true;
        }

        private void TlacitkoNahledNazvu_Click(object sender, EventArgs e)
        {
            if (NeplatneZadani())
            {
                return;
            }

            // Nastaveni barvy
            ZobrazeniSouboruText.Text = "";
            ZobrazeniSouboruText.ForeColor = Color.Blue;

            // Vypsani vsech fotek a novych nazvu
            string pripona;

            foreach (string f in fotky)
            {
                pripona = new FileInfo(f).Extension;
                // Zmena pripony
                if (MalePismenaPripona.Checked)
                {
                    pripona = pripona.ToLower();
                }
                else if (VelkePismenaPripona.Checked)
                {
                    pripona = pripona.ToUpper();
                }
                ZobrazeniSouboruText.AppendText(f + "   -->   " + VygenerujNazevFotky(f) + pripona + "\n");
            }
            TlacitkoPrejmenovat.Visible = true;
        }

        private void TlacitkoPrejmenovat_Click(object sender, EventArgs e)
        {
            if (FinalniPotvrzeni.Visible == true)
            {
                return;
            }

            // Kontrola pro duplicitni hodnoty
            ZobrazeniSouboruText.ForeColor = Color.FromArgb(192, 0, 0);
            ZobrazeniSouboruText.Text = "Probíhá kontrola pro duplicitní názvy...";
            foreach (string f in fotky)
            {
                foreach (string s in fotky)
                {
                    if (VygenerujNazevFotky(f) == VygenerujNazevFotky(s) && f != s)
                    {
                        ZobrazeniSouboruText.AppendText("\n\nERROR: BYLY NALEZENY DUPLICITNÍ NÁZVY SOUBORŮ!!!\n\n");
                        ZobrazeniSouboruText.AppendText(f + "   -->   " + VygenerujNazevFotky(f) + "\n" + s + "   -->   " + VygenerujNazevFotky(s));
                        return;
                    }
                }
            }
            TlacitkoNahledNazvu_Click(sender, e);

            DialogResult dialog;
            // Dialog 1
            dialog = MessageBox.Show("Tato akce je nevratná, opravdu chcete pokračovat?", "Nevratná akce", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.No)
            {
                return;
            }
            // Dialog 2
            dialog = MessageBox.Show("Ale já si nedělám srandu, tato akce je skutečně nevratná, opravdu chcete pokračovat?", "Nevratná akce", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.No)
            {
                return;
            }
            // Dialog 3
            dialog = MessageBox.Show("POZOR!!!\nPrávě se chystáte provést nevratnou akci, jste si jistí?", "NEVRATNÁ AKCE!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dialog == DialogResult.No)
            {
                return;
            }
            // Dialog 4
            dialog = MessageBox.Show("K provedení této akce je potřeba:\nPotvrzení", "NEVRATNÁ AKCE!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.No)
            {
                return;
            }
            // Dialog 5
            dialog = MessageBox.Show("K provedení této akce je potřeba:\nPotvrzení na potvrzení", "NEVRATNÁ AKCE!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.No)
            {
                return;
            }
            // Dialog 6
            dialog = MessageBox.Show("K provedení této akce je potřeba:\nPotvrzení na potvrzení na potvrzení", "NEVRATNÁ AKCE!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.No)
            {
                return;
            }
            // Dialog 7
            dialog = MessageBox.Show("Tak dobře, ale tohle už je skutečně POSLEDNÍ POTVRZENÍ!", "NEVRATNÁ AKCE!", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            if (dialog == DialogResult.No)
            {
                return;
            }
            FinalniPotvrzeni.Visible = true;
        }

        private void FinalniPotvrzeni_Click(object sender, EventArgs e)
        {
            if (NeplatneZadani())
            {
                return;
            }

            ZobrazeniSouboruText.ForeColor = Color.Brown;
            ZobrazeniSouboruText.Text = "";

            // Prejmenovani fotek
            foreach (string f in fotky)
            {
                if (JeFotka(f))
                {
                    FileInfo file = new FileInfo(f);

                    if (file.Directory != null)
                    {
                        ZobrazeniSouboruText.AppendText("Soubor přejmenován:   " + f.ToString() + "   -->   ");

                        // Prejmenovani souboru
                        string nazev = VygenerujNazevFotky(f);
                        string pripona = file.Extension;
                        if (MalePismenaPripona.Checked)
                        {
                            pripona = pripona.ToLower();
                        }
                        else if (VelkePismenaPripona.Checked)
                        {
                            pripona = pripona.ToUpper();
                        }
                        File.Move(f, file.Directory + "\\" + nazev + pripona);

                        ZobrazeniSouboruText.AppendText(nazev + pripona + "\n");
                    }
                    else
                    {
                        // Error neplatneho nazvu slozky
                        MessageBox.Show("Error: Není specifikován název složky pro umístění!", "ERROR NÁZEV SLOŽKY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            prejmenovani = true;
            FinalniPotvrzeni.Visible = false;
            TlacitkoPrejmenovat.Visible = false;
            TlacitkoNahledNazvu.Enabled = false;
            TlacitkoOdfiltrovatFotky.Enabled = false;
            prejmenovani = false;
        }

        private void MalePismenaPripona_Click(object sender, EventArgs e)
        {
            VelkePismenaPripona.Checked = false;
            OriginalniPripona.Checked = false;
            // Refresh
            if (TlacitkoNahledNazvu.Enabled && !prejmenovani)
            {
                TlacitkoNahledNazvu_Click(sender, e);
            }
        }
        private void VelkePismenaPripona_Click(object sender, EventArgs e)
        {
            MalePismenaPripona.Checked = false;
            OriginalniPripona.Checked = false;
            // Refresh
            if (TlacitkoNahledNazvu.Enabled && !prejmenovani)
            {
                TlacitkoNahledNazvu_Click(sender, e);
            }
        }
        private void OriginalniPripona_Click(object sender, EventArgs e)
        {
            MalePismenaPripona.Checked = false;
            VelkePismenaPripona.Checked = false;
            // Refresh
            if (TlacitkoNahledNazvu.Enabled && !prejmenovani)
            {
                TlacitkoNahledNazvu_Click(sender, e);
            }
        }

        private bool NeplatneZadani()
        {
            // Nastaveni barvy
            ZobrazeniSouboruText.ForeColor = Color.FromArgb(192, 0, 0);
            if (soubory.Length == 0)
            {
                // Kontrola pro praznde pole souboru
                ZobrazeniSouboruText.Text = "Error! Nebyly vybrany zadne soubory";
                return true;
            }
            else if (fotky.Count == 0)
            {
                // Kontrola pro prazdne pole fotek
                ZobrazeniSouboruText.Text = "Error! Zadne ze souboru nejsou fotky";
                return true;
            }
            return false;
        }
        private bool JeFotka(string soubor)
        {
            // Kontrola, jestli je zadany soubor fotka
            FileInfo file = new FileInfo(soubor);
            if (!file.Exists)
            {
                return false;
            }
            // Seznam pripon obrazku
            string[] pripony = new string[8] { ".jpg", ".png", ".jpeg", ".gif", ".pjpeg", ".bmp", ".x-png", ".tiff", };
            foreach (string ext in pripony)
            {
                if (file.Extension.ToLower() == ext)
                {
                    return true;
                }
            }
            return false;
        }
        private string VygenerujNazevFotky(string soubor)
        {
            FileInfo file = new FileInfo(soubor);
            if (!file.Exists)
            {
                return "";
            }
            DateTime datum = file.LastWriteTime;

            // 03.07.2023 15:58:58 --> 20230703_155858

            // Rok
            string nazev = datum.Year.ToString();
            // Mesic
            if (datum.Month <= 9)
            {
                nazev += "0";
            }
            nazev += datum.Month.ToString();
            // Den
            if (datum.Day <= 9)
            {
                nazev += "0";
            }
            nazev += datum.Day.ToString() + "_";

            // Hodiny
            if (datum.Hour <= 9)
            {
                nazev += "0";
            }
            nazev += datum.Hour.ToString();

            // Minuty
            if (datum.Minute <= 9)
            {
                nazev += "0";
            }
            nazev += datum.Minute.ToString();

            // Sekundy
            if (datum.Second <= 9)
            {
                nazev += "0";
            }
            nazev += datum.Second.ToString();

            return nazev;
        }
    }
}