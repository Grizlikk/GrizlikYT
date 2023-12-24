namespace Program_na_výuku
{
	public partial class HlavniAplikace : Form
	{
		// Pole podle tridy Slovicko
		private List<Slovicko> slovicka = new List<Slovicko>();

		// Dialog nastaveni
		private Nastaveni nastaveniDialog = new Nastaveni();

		private bool probihaTrenovani = false;

		// Kolik slovicek se ma celkem vypsat
		private int pocetOpakovani;
		// Celkovy pocet slovicek v poli "slovicka"
		private int celkemSlovicek;
		// Kolikrat uz uzivatel odpovedel na slovicko
		private int pocetOdpovedi;
		// Kolikrat uzivatel odpovedel spravne na slovicko
		private int pocetSpravnychOdpovedi;

		private RezimVypisu rezimVypisu;

		/// <summary>
		/// Nahodne vybrane poradove cislo slovicka z pole slovicek
		/// </summary>
		private int cisloSlovicka;
		private Random rnd = new Random();

		private bool spravnaOdpoved;

		public HlavniAplikace()
		{
			InitializeComponent();
		}

		private void TlacitkoNastaveni_Click(object sender, EventArgs e)
		{
			nastaveniDialog.ShowDialog();

			PoznamkaNacitaniNastaveni.Visible = true;
			NacistNastaveni(nastaveniDialog);
			NacistSlovicka(nastaveniDialog);
			PoznamkaNacitaniNastaveni.Visible = false;
		}

		private void TlacitkoSpustitProgram_Click(object sender, EventArgs e)
		{
			if (!PlatneNastaveniPredSpustenim())
			{
				return;
			}

			// Nastaveni progress baru
			ProgressBarTrenovani.Maximum = pocetOpakovani + 1;
			ProgressBarTrenovani.Value = 1;

			// Nastaveni barvy
			SlovickoZadavani.ForeColor = Color.Black;
			SpravnyPreklad.ForeColor = Color.FromArgb(0, 192, 0);

			// Zacatek procvicovani slovicek
			TlacitkoNastaveni.Enabled = false;
			TlacitkoSpustitProgram.Enabled = false;
			SlovickoZadavani.ReadOnly = false;
			SlovickoZadavani.TabStop = true;
			TlacitkoUkoncit.TabStop = false;
			probihaTrenovani = true;

			ZobrazitNoveSlovicko();
		}

		// Kontrola pro stisknuti enteru
		private void SlovickoZadavani_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				// Odebrani enteru
				e.SuppressKeyPress = true;

				if (probihaTrenovani)
				{
					SpravnyPreklad.Text = slovicka[cisloSlovicka].Vypis();
					SlovickoZadavani.TabStop = false;
					PrepnutiTlacitekSpravnosti();
				}
			}
		}

		private void TlacitkoSpravne_Click(object sender, EventArgs e)
		{
			spravnaOdpoved = true;
			PokracovatPoZvoleniSpravnosti();
		}
		private void TlacitkoSpatne_Click(object sender, EventArgs e)
		{
			spravnaOdpoved = false;
			PokracovatPoZvoleniSpravnosti();
		}

		private void TlacitkoUkoncit_Click(object sender, EventArgs e)
		{
			// Pokud probiha trenovani, pozastavit a zobrazit vysledky
			if (probihaTrenovani)
			{
				probihaTrenovani = false;
				PrepnutiTlacitekSpravnosti(false);
				ZobrazeniUspesnosti();
				return;
			}

			DialogResult ukoncit = MessageBox.Show("Ukončit program?", "Konec", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (ukoncit == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		/// <summary>
		/// Nacte nastaveni z obrazovky Nastaveni, jako typ vypisu nebo pocet slovicek
		/// </summary>
		/// <param name="dialogNastaveni">Odkaz na tabulku s nastavenim, odkud se hodnoty budou cist</param>
		private void NacistNastaveni(Nastaveni dialogNastaveni)
		{
			// Nacteni poctu opakovani
			string pocetSlov = dialogNastaveni.PocetSlovicekText.Text;
			int.TryParse(pocetSlov, out pocetOpakovani);

			// Nacteni rezimu vypisu
			if (dialogNastaveni.PrepinacOriginalNaPreklad.Checked)
			{
				rezimVypisu = RezimVypisu.OriginalNaPreklad;
			}
			else if (dialogNastaveni.PrepinacPrekladNaOriginal.Checked)
			{
				rezimVypisu = RezimVypisu.PrekladNaOriginal;
			}
			else if (dialogNastaveni.PrepinacNahodnyVypis.Checked)
			{
				rezimVypisu = RezimVypisu.NahodnyVypis;
			}
			else
			{
				ObecneFunkce.Error("V programu došlo k nerozpoznané výjimce, program bude nyní ukončen...\n\nDůvod chyby: Nastavení režimu výpisu nebylo možné rozpoznat!", "Error - Režim výpisu", true);
				return;
			}
		}

		/// <summary>
		/// Nacte slovicka z jednoho nebo vice souboru, zadanych v tabulkce nastaveni
		/// </summary>
		/// <param name="dialogNastaveni">Odkaz na tabulku nastaveni, odkud se prectou cesty k souborum slovicek</param>
		private void NacistSlovicka(Nastaveni dialogNastaveni)
		{
			slovicka.Clear();

			string[] soubory = dialogNastaveni.ZvoleneSouboryText.Text.Split('\n');
			foreach (string cesta in soubory)
			{
				try
				{
					SouborSlovicek souborSlovicek = new SouborSlovicek(cesta, rezimVypisu);
					souborSlovicek.NacistSlovickaZeSouboru();
					slovicka.AddRange(souborSlovicek.SlovickaList);
				}
				catch
				{

				}
			}
		}

		/// <summary>
		/// Zkontroluje, zda je vse spravne nastavene pred spustenim programu
		/// </summary>
		/// <returns>Vraci "true" pokud je vse nastaveno spravne, jinak vraci "false"</returns>
		private bool PlatneNastaveniPredSpustenim()
		{
			// Nastaveni promennych pro beh programu
			celkemSlovicek = slovicka.Count;
			pocetOdpovedi = 0;
			pocetSpravnychOdpovedi = 0;


			// Overeni slovicek
			if (celkemSlovicek <= 0)
			{
				ObecneFunkce.Error("Počet slovíček musí být větší než nula", "Chyba počtu slovíček", ikonaChyby: MessageBoxIcon.Warning);
				return false;
			}

			// Overeni poctu opakovani
			if (pocetOpakovani <= 0)
			{
				ObecneFunkce.Error("Počet opakování slovíček musí být kladné celé číslo", "Chyba počtu opakování", ikonaChyby: MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		/// <summary>
		/// Vygenerovani a zobrazeni noveho slovicka z nahodne pozice
		/// </summary>
		private void ZobrazitNoveSlovicko()
		{
			// Vygenerovani nahodne pozice pro slovicko
			cisloSlovicka = rnd.Next(0, celkemSlovicek);

			// Vypsani slovicka
			SlovickoKPrekladu.Text = slovicka[cisloSlovicka].Vypis();

			// Nastaveni textovych poli
			SpravnyPreklad.Text = "";
			SlovickoZadavani.Text = "";
			SlovickoZadavani.TabStop = true;
			SlovickoZadavani.Focus();
		}

		/// <summary>
		/// Zobrazi nebo skryje tlacitka "Spravne" a "Spatne"
		/// </summary>
		/// <param name="zobrazit">Nova hodnota pro viditelnost tlacitek</param>
		private void PrepnutiTlacitekSpravnosti(bool zobrazit = true)
		{
			TlacitkoSpravne.Visible = zobrazit;
			TlacitkoSpatne.Visible = zobrazit;
			if (zobrazit)
			{
				TlacitkoSpravne.Focus();
			}
		}

		/// <summary>
		/// Pokracovani po odkliknuti tlacitka "Spravne" nebo "Spatne"
		/// </summary>
		private void PokracovatPoZvoleniSpravnosti()
		{
			pocetOdpovedi++;

			if (spravnaOdpoved)
			{
				pocetSpravnychOdpovedi++;
			}
			PrepnutiTlacitekSpravnosti(false);

			if (pocetOdpovedi == pocetOpakovani)
			{
				probihaTrenovani = false;
				ProgressBarTrenovani.Value = ProgressBarTrenovani.Maximum;
				ZobrazeniUspesnosti();
				return;
			}

			ProgressBarTrenovani.Value = pocetOdpovedi + 1;
			ZobrazitNoveSlovicko();
		}

		/// <summary>
		/// Zobrazeni uspesnosti po ukonceni programu, resetovani programu pro moznost spusteni dalsiho procvicovani
		/// </summary>
		private void ZobrazeniUspesnosti()
		{
			double uspesnost = 0;
			Color barva = Color.DarkBlue;

			SlovickoKPrekladu.Text = "Správných odpovědí:";
			SlovickoZadavani.Text = pocetSpravnychOdpovedi.ToString() + " z " + pocetOdpovedi.ToString();

			if (pocetOdpovedi > 0)
			{
				uspesnost = Math.Round(Convert.ToDouble(pocetSpravnychOdpovedi) / Convert.ToDouble(pocetOdpovedi) * 100, 3);
				barva = BarvaUspesnosti(uspesnost, true);
			}

			SpravnyPreklad.Text = "Úspěšnost: " + uspesnost.ToString() + " %";

			// Nastaveni poli pro vypis
			SlovickoZadavani.ForeColor = barva;
			SpravnyPreklad.ForeColor = barva;
			SlovickoZadavani.ReadOnly = true;

			RestartOkna();
		}

		/// <summary>
		/// Vygenerovani barvy pro text uspesnosti
		/// Barva jde od cervene, pres zlutou az k zelene v zavislosti na poctu spravne zodpovezenych slovicek
		/// </summary>
		/// <param name="uspesnost">Podil spravne zodpovezenych slovicek a celkoveho mnozstvi zadanych slovicek</param>
		/// <param name="procentualne">Jestli je hodnota "uspesnost" zadana v procentech</param>
		/// <returns>Odstin barvy v zavislosti na uspesnosti</returns>
		private Color BarvaUspesnosti(double uspesnost, bool procentualne = false)
		{
			// Procentuali zadani uspesnosti
			if (!procentualne)
			{
				uspesnost *= 100;
			}
			if (uspesnost > 100)
			{
				uspesnost = 100;
			}

			double urovenCervena;
			double urovenZelena;

			// Uroven cervene barvy
			if (uspesnost <= 50)
			{
				urovenCervena = 100;
			}
			else
			{
				urovenCervena = -2 * uspesnost + 200;
			}

			// Uroven zelene barvy
			if (uspesnost >= 50)
			{
				urovenZelena = 100;
			}
			else
			{
				urovenZelena = 2 * uspesnost;
			}

			int cervena = (int)Math.Round(urovenCervena * 2);
			int zelena = (int)Math.Round(urovenZelena * 2);

			return Color.FromArgb(cervena, zelena, 0);
		}

		/// <summary>
		/// Pripravi policka na opetovne spusteni po ukonceni trenovani
		/// </summary>
		private void RestartOkna()
		{
			TlacitkoNastaveni.Enabled = true;
			TlacitkoSpustitProgram.Enabled = true;
			TlacitkoUkoncit.TabStop = true;
			SlovickoZadavani.TabStop = false;
		}
	}
}