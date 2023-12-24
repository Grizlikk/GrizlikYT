namespace Program_na_výuku
{
	internal class SouborSlovicek
	{
		#region Definice promennych
		private string obsahSouboru = string.Empty;
		/// <summary>
		/// Surove data v souboru tak, jak jsou ulozena
		/// </summary>
		public string ObsahSouboru
		{
			get => obsahSouboru;
			set => NacistSlovickaZTextovehoRetezce(value);
		}

		private string cestaKSouboru;
		/// <summary>
		/// Cesta k souboru slovicek
		/// </summary>
		public string CestaKSouboru
		{
			get => cestaKSouboru;
		}

		private List<Slovicko> slovickaList = new List<Slovicko>();
		/// <summary>
		/// Seznam slovicek nactenych ze souboru
		/// </summary>
		public List<Slovicko> SlovickaList
		{
			get => slovickaList;
		}

		private RezimVypisu rezimVypisuSlovicek;
		/// <summary>
		/// Rezim vypisu slovicek
		/// </summary>
		public RezimVypisu RezimVypisuSlovicek
		{
			get => rezimVypisuSlovicek;
			set => rezimVypisuSlovicek = value;
		}

		#endregion

		/// <summary>
		/// Definovat novy soubor slovicek
		/// </summary>
		/// <param name="cestaKSouboru">Uplna cesta k souboru slovicek</param>
		/// <exception cref="ArgumentException">Cesta k souboru je prazdna</exception>
		public SouborSlovicek(string cestaKSouboru, RezimVypisu rezimVypisu = RezimVypisu.NahodnyVypis)
		{
			if (cestaKSouboru == string.Empty)
			{
				throw new ArgumentException("Cesta k souboru nebyla specifikovana");
			}

			this.cestaKSouboru = cestaKSouboru;
			rezimVypisuSlovicek = rezimVypisu;
		}

		/// <summary>
		/// Nacte obsah souboru na zadane ceste
		/// </summary>
		public void NacistSlovickaZeSouboru()
		{
			if (File.Exists(cestaKSouboru))
			{
				obsahSouboru = File.ReadAllText(cestaKSouboru);
			}
			AktualizovatSeznamSlovicek();
		}
		private void NacistSlovickaZTextovehoRetezce(string textSlovicek)
		{
			obsahSouboru = textSlovicek;
			AktualizovatSeznamSlovicek();
		}
		/// <summary>
		/// Ulozit slovicka do souboru ve specifikovanem umisteni
		/// </summary>
		/// <param name="cesta">Cesta k souboru k ulozeni, pokud neni zadana, pouzije se defaultni cesta zadana v konstruktoru</param>
		/// <param name="vytvoritSoubor">Jestlize soubor neexistuje, ma se soubor vytvorit?</param>
		/// <exception cref="FileNotFoundException">Soubor neexistuje a neni specifikovan pro vytvoreni</exception>
		public void UlozitSlovickaDoSouboru(string cesta = "", bool vytvoritSoubor = true)
		{
			string soubor = (cesta == string.Empty) ? cestaKSouboru : cesta;
			if (!File.Exists(soubor) && !vytvoritSoubor)
			{
				throw new FileNotFoundException("Zadany soubor neexistuje");
			}
			File.WriteAllText(soubor, obsahSouboru);
		}

		/// <summary>
		/// Aktualizovat pole slovicek, aby se shodovalo s textovou formou obsahu souboru slovicek
		/// </summary>
		private void AktualizovatSeznamSlovicek()
		{
			slovickaList.Clear();
			string[] rozdelenyObsah = obsahSouboru.Split(';');
			// Odstraneni mezer a prazdnych pozic
			rozdelenyObsah = rozdelenyObsah.Select(x => x.Trim()).ToArray();
			rozdelenyObsah = rozdelenyObsah.Where(x => !string.IsNullOrEmpty(x)).ToArray();

			for (int i = 0; i < rozdelenyObsah.Length - 1; i += 2)
			{
				// Na pozici [i] je original, na pozici [i+1] je preklad
				slovickaList.Add(new Slovicko(rozdelenyObsah[i], rozdelenyObsah[i + 1], rezimVypisuSlovicek));
			}
			AktualizovatObsahSouboruSlovicek();
		}
		/// <summary>
		/// Aktualizovat textovou formu obsahu slovicek, aby se shodovala s polem slovicek
		/// </summary>
		private void AktualizovatObsahSouboruSlovicek()
		{
			obsahSouboru = string.Empty;
			for (int i = 0; i < slovickaList.Count; i++)
			{
				obsahSouboru += $"{slovickaList[i].SlovickoOriginal};{slovickaList[i].SlovickoPreklad}";
				if (i != slovickaList.Count - 1)
				{
					obsahSouboru += ";";
				}
			}
		}

		/// <summary>
		/// Pridat nove slovicko do souboru slovicek
		/// </summary>
		/// <param name="slovicko">Slovicko k pridani</param>
		public void PridejSlovicko(Slovicko slovicko)
		{
			obsahSouboru += $";{slovicko.SlovickoOriginal};{slovicko.SlovickoPreklad}";
			AktualizovatSeznamSlovicek();
		}
		/// <summary>
		/// Odebere slovicko na zadanem indexu
		/// </summary>
		/// <param name="index">Index slovicka k odebrani zacinajici od nuly</param>
		/// <exception cref="ArgumentException">Zadana hodnota indexu neodpovida rozsahu pole slovicek</exception>
		public void OdeberSlovicko(int index)
		{
			if (index < 0 || index > slovickaList.Count - 1)
			{
				throw new ArgumentException("Zadana hodnota indexu lezi mimo pole");
			}

			slovickaList.RemoveAt(index);

			AktualizovatObsahSouboruSlovicek();
		}
		/// <summary>
		/// Odebere rozsah slovicek na zadanych krajnich indexech a vsechny slovicka mezi nimi
		/// </summary>
		/// <param name="indexMin">Zacatek rozsahu, od ktereho se zacne mazat (vcetne)</param>
		/// <param name="indexMax">Konec rozsahu, do ktereho se ma mazat (vcetne)</param>
		/// <exception cref="ArgumentException">Zadane hodnoty indexu lezi mimo pole slovicek</exception>
		public void OdeberRozsahSlovicek(int indexMin, int indexMax)
		{
			if (indexMin > indexMax)
			{
				int temp = indexMin;
				indexMin = indexMax;
				indexMax = temp;
			}

			if (indexMin < 0 || indexMax > slovickaList.Count - 1)
			{
				throw new ArgumentException("Zadany rozsah neodpovida velikosti pole");
			}

			int pocet = indexMax - indexMin + 1;
			slovickaList.RemoveRange(indexMin, pocet);

			AktualizovatObsahSouboruSlovicek();
		}
	}
}
