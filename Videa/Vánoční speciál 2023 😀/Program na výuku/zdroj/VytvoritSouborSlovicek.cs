namespace Program_na_výuku
{
	public partial class VytvoritSouborSlovicek : Form
	{
		private SouborSlovicek? souborSlovicek;

		private readonly Color barvaPozadiTlacitka = Color.FromArgb(224, 224, 224);
		private readonly Color barvaPozadiTlacitkaNeulozeno = Color.FromArgb(255, 175, 175);

		private bool ulozeniCooldown = false;
		private bool ulozitPoCooldownu = false;

		public VytvoritSouborSlovicek()
		{
			InitializeComponent();
		}

		private void TlacitkoNovySoubor_Click(object sender, EventArgs e)
		{
			DialogResult vysledek = UlozitSouborDialog.ShowDialog();

			if (vysledek == DialogResult.OK)
			{
				souborSlovicek = new SouborSlovicek(UlozitSouborDialog.FileName);
				SouborZvolen();
			}
		}
		private void TlacitkoUlozitSoubor_Click(object sender, EventArgs e)
		{
			TlacitkoUlozitSoubor.BackColor = barvaPozadiTlacitka;

			Thread vlaknoUlozeniSouboru = new Thread(new ThreadStart(UlozitDoSouboru));
			vlaknoUlozeniSouboru.Start();
		}
		private void TlacitkoOtevritSoubor_Click(object sender, EventArgs e)
		{
			DialogResult vysledek = NacistSouborDialog.ShowDialog();
			if (vysledek == DialogResult.OK)
			{
				souborSlovicek = new SouborSlovicek(NacistSouborDialog.FileName);
				souborSlovicek.NacistSlovickaZeSouboru();
				SouborZvolen();
			}
		}
		private void TlacitkoPridat_Click(object sender, EventArgs e)
		{
			if (souborSlovicek == null)
			{
				ObecneFunkce.Error("V programu došlo k nerozpoznané výjimce, program bude nyní ukončen...\n\nDůvod chyby: Soubor slovíček k uložení obsahu nebyl správně specifikován", "Error - Soubor slovíček", true);
				return;
			}
			bool ulozeno = false;

			try
			{
				Slovicko slovickoKPridani = new Slovicko(SlovickoCiziJazykText.Text, SlovickoCeskyText.Text);
				souborSlovicek.PridejSlovicko(slovickoKPridani);
				ulozeno = true;
			}
			catch (ArgumentException argex)
			{
				DialogResult vysledek;
				switch (argex.Message)
				{
					case "Cesky preklad nespecifikovan":
						ObecneFunkce.Error("Český překlad není zadaný", "Neplatné zadání", ikonaChyby: MessageBoxIcon.Warning);
						SlovickoCeskyText.Focus();
						break;
					case "Cizi preklad nespecifikovan":
						ObecneFunkce.Error("Cizi překlad není zadaný", "Neplatné zadání", ikonaChyby: MessageBoxIcon.Warning);
						SlovickoCiziJazykText.Focus();
						break;
					case "Cesky preklad obsahuje strednik":
						vysledek = ObecneFunkce.Error("Český překlad obsahuje středník\nChcete jej odebrat a pokračovat v ukládání?", "Středník", false, MessageBoxIcon.Warning, MessageBoxButtons.YesNo);
						if (vysledek == DialogResult.Yes)
						{
							// Odebere se strednik a data se pokusi ulozit znovu
							SlovickoCeskyText.Text = OdebratZnak(SlovickoCeskyText.Text, ';');
							TlacitkoPridat_Click(sender, e);
						}
						break;
					case "Cizi preklad obsahuje strednik":
						vysledek = ObecneFunkce.Error("Cizí překlad obsahuje středník\nChcete jej odebrat a pokračovat v ukládání?", "Středník", false, MessageBoxIcon.Warning, MessageBoxButtons.YesNo);
						if (vysledek == DialogResult.Yes)
						{
							// Odebere se strednik a data se pokusi ulozit znovu
							SlovickoCiziJazykText.Text = OdebratZnak(SlovickoCiziJazykText.Text, ';');
							TlacitkoPridat_Click(sender, e);
						}
						break;
				}
			}

			if (ulozeno)
			{
				SlovickoCeskyText.Text = string.Empty;
				SlovickoCiziJazykText.Text = string.Empty;
				SlovickoCiziJazykText.Focus();
				ObsahSlovicekZmenen(sender, e);
				VypsatObsahSouboruSlovicek();
			}
		}
		private void TlacitkoOdebrat_Click(object sender, EventArgs e)
		{
			if (souborSlovicek == null)
			{
				ObecneFunkce.Error("V programu došlo k nerozpoznané výjimce, program bude nyní ukončen...\n\nDůvod chyby: Soubor slovíček k odebrání obsahu nebyl správně specifikován", "Error - Soubor slovíček", true);
				return;
			}

			if (souborSlovicek.SlovickaList.Count <= 0)
			{
				return;
			}

			ZadejteSlovickoKOdebrani slovickoKOdebraniDialog = new ZadejteSlovickoKOdebrani();
			slovickoKOdebraniDialog.ShowDialog();

			string odebrani = slovickoKOdebraniDialog.SlovickoKOdebrani.Text;
			odebrani = OdebratZnak(odebrani, ' ');

			if (!OdebratSlovickaPodleIndexu(odebrani))
			{
				ObecneFunkce.Error("Neplatné zadání rozsahu nebo slovíčka k odebrání!\nSoubor zůstává nezměněn", "Neplatné zadání", ikonaChyby: MessageBoxIcon.Warning);
				return;
			}

			VypsatObsahSouboruSlovicek();

			ObsahSlovicekZmenen(sender, e);
			SlovickoCiziJazykText.Focus();
		}

		private void SlovickoCiziJazykText_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				TlacitkoPridat_Click(sender, e);
				e.SuppressKeyPress = true;
			}
		}
		private void SlovickoCeskyText_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				TlacitkoPridat_Click(sender, e);
				e.SuppressKeyPress = true;
			}
		}

		private void PrepinacAutomatickeUkladani_CheckedChanged(object sender, EventArgs e)
		{
			if (PrepinacAutomatickeUkladani.Checked)
			{
				TlacitkoUlozitSoubor_Click(sender, e);
			}
		}
		private void PrepinacZdrojovyVypisSouboru_CheckedChanged(object sender, EventArgs e)
		{
			if (souborSlovicek == null)
			{
				ObecneFunkce.Error("V programu došlo k nerozpoznané výjimce, program bude nyní ukončen...\n\nDůvod chyby: Soubor slovíček k obnovení obsahu nebyl správně specifikován", "Error - Soubor slovíček", true);
				return;
			}

			SlovickaVypisText.ReadOnly = !PrepinacZdrojovyVypisSouboru.Checked;

			if (!PrepinacZdrojovyVypisSouboru.Checked)
			{
				souborSlovicek.ObsahSouboru = SlovickaVypisText.Text;
			}

			VypsatObsahSouboruSlovicek();
		}

		private void SlovickaVypisText_KeyDown(object sender, KeyEventArgs e)
		{
			// Odebrani zvuku chyby pri stisknuti klavesy
			if (!PrepinacZdrojovyVypisSouboru.Checked)
			{
				e.SuppressKeyPress = true;
				return;
			}

			ObsahSlovicekZmenen(sender, e);
		}

		/// <summary>
		/// Nastaveni okna po zvoleni souboru
		/// </summary>
		private void SouborZvolen()
		{
			if (souborSlovicek == null)
			{
				ObecneFunkce.Error("V programu došlo k nerozpoznané výjimce, program bude nyní ukončen...\n\nDůvod chyby: Soubor slovíček nebyl správně specifikován", "Error - Soubor slovíček", true);
				return;
			}

			ResetOkna();
			CestaKSouboruText.Text = souborSlovicek.CestaKSouboru;

			VypsatObsahSouboruSlovicek();

			CestaKSouboruText.Enabled = true;
			TlacitkoUlozitSoubor.Enabled = true;
			TlacitkoPridat.Enabled = true;
			TlacitkoOdebrat.Enabled = true;
			SlovickoCeskyText.Enabled = true;
			SlovickoCiziJazykText.Enabled = true;
			SlovickaVypisText.Enabled = true;
			PrepinacAutomatickeUkladani.Enabled = true;
			PrepinacZdrojovyVypisSouboru.Enabled = true;

			SlovickoCiziJazykText.Focus();
		}

		/// <summary>
		/// Reset vsech oken do vychoziho stavu
		/// </summary>
		private void ResetOkna()
		{
			CestaKSouboruText.Text = string.Empty;
			SlovickoCeskyText.Text = string.Empty;
			SlovickoCiziJazykText.Text = string.Empty;
			SlovickaVypisText.Text = string.Empty;
			TlacitkoUlozitSoubor.BackColor = barvaPozadiTlacitka;
		}

		private void VypsatObsahSouboruSlovicek()
		{
			if (souborSlovicek == null)
			{
				ObecneFunkce.Error("V programu došlo k nerozpoznané výjimce, program bude nyní ukončen...\n\nDůvod chyby: Soubor slovíček k výpisu obsahu nebyl správně specifikován", "Error - Soubor slovíček", true);
				return;
			}

			if (PrepinacZdrojovyVypisSouboru.Checked)
			{
				SlovickaVypisText.Text = souborSlovicek.ObsahSouboru;
				return;
			}

			SlovickaVypisText.Text = string.Empty;

			for (int i = 0; i < souborSlovicek.SlovickaList.Count; i++)
			{
				string original = souborSlovicek.SlovickaList[i].SlovickoOriginal;
				string preklad = souborSlovicek.SlovickaList[i].SlovickoPreklad;
				SlovickaVypisText.Text += $"[{i + 1}.]\t{original} --- {preklad}\n";
			}

			if (SlovickaVypisText.Text == string.Empty)
			{
				SlovickaVypisText.Text = "[Soubor je prázdný]";
			}
		}

		private string OdebratZnak(string text, char znak)
		{
			string vysledek = string.Empty;

			foreach (char c in text)
			{
				if (c != znak)
				{
					vysledek += c;
				}
			}

			return vysledek;
		}

		/// <summary>
		/// Ulozi data do souboru a v pripade potreby ze souboru vymaze stare data
		/// </summary>
		private void UlozitDoSouboru()
		{
			if (ulozeniCooldown)
			{
				ulozitPoCooldownu = true;
				return;
			}

			ulozeniCooldown = true;
			Thread resetUlozeniCooldown = new Thread(new ThreadStart(ResetUlozeniCooldown));
			resetUlozeniCooldown.Start();

			if (souborSlovicek == null)
			{
				ObecneFunkce.Error("V programu došlo k nerozpoznané výjimce, program bude nyní ukončen...\n\nDůvod chyby: Soubor slovíček k zapsání obsahu nebyl správně specifikován", "Error - Soubor slovíček", true);
				return;
			}

			if (PrepinacZdrojovyVypisSouboru.Checked)
			{
				if (SlovickaVypisText.InvokeRequired)
				{
					Thread.Sleep(20);
					SlovickaVypisText.Invoke(delegate { souborSlovicek.ObsahSouboru = SlovickaVypisText.Text; });
				}
				else
				{
					souborSlovicek.ObsahSouboru = SlovickaVypisText.Text;
				}
			}

			souborSlovicek.UlozitSlovickaDoSouboru();
		}

		private bool OdebratSlovickaPodleIndexu(string indexy)
		{
			if (souborSlovicek == null)
			{
				return false;
			}

			try
			{
				if (!indexy.Contains('-'))
				{
					souborSlovicek.OdeberSlovicko(int.Parse(indexy) - 1);
					return true;
				}

				string[] dvaIndexy = indexy.Split('-');
				souborSlovicek.OdeberRozsahSlovicek(int.Parse(dvaIndexy[0]) - 1, int.Parse(dvaIndexy[1]) - 1);
				return true;
			}
			catch
			{
				return false;
			}
		}

		private void ObsahSlovicekZmenen(object sender, EventArgs e)
		{
			if (PrepinacAutomatickeUkladani.Checked)
			{
				TlacitkoUlozitSoubor_Click(sender, e);
			}
			else
			{
				TlacitkoUlozitSoubor.BackColor = barvaPozadiTlacitkaNeulozeno;
			}
		}

		private void ResetUlozeniCooldown()
		{
			Thread.Sleep(2000);
			ulozeniCooldown = false;

			if (ulozitPoCooldownu)
			{
				ulozitPoCooldownu = false;
				TlacitkoUlozitSoubor_Click(this, new EventArgs());
			}
		}
	}
}