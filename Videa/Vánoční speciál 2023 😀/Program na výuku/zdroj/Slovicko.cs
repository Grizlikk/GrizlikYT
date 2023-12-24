namespace Program_na_výuku
{
	internal class Slovicko
	{
		private bool prvniSpusteniVypisu = true;
		private bool posledniNahodnyVypisOriginal;

		private string slovickoOriginal = string.Empty;
		public string SlovickoOriginal
		{
			get => slovickoOriginal;
			set { slovickoOriginal = value; }
		}
		private string slovickoPreklad = string.Empty;
		public string SlovickoPreklad
		{
			get => slovickoPreklad;
			set { slovickoPreklad = value; }
		}
		private RezimVypisu rezimVypisuSlovicek;
		public RezimVypisu RezimVypisuSlovicek
		{
			get => rezimVypisuSlovicek;
		}

		private Random random = new Random();

		/// <summary>
		/// Vytvori novy objekt reprezentujici slovicko s cizim a ceskym prekladem
		/// </summary>
		/// <param name="original">Slovicko v cizim jazyce</param>
		/// <param name="preklad">Preklad slovicka</param>
		/// <param name="rezimVypisu">Nastaveny rezim vypisu slovicek</param>
		public Slovicko(string original, string preklad, RezimVypisu rezimVypisu = RezimVypisu.NahodnyVypis)
		{
			original = original.Trim();
			preklad = preklad.Trim();
			if (original == string.Empty)
			{
				throw new ArgumentException("Cizi preklad nespecifikovan");
			}
			if (preklad == string.Empty)
			{
				throw new ArgumentException("Cesky preklad nespecifikovan");
			}
			if (original.Contains(';'))
			{
				throw new ArgumentException("Cizi preklad obsahuje strednik");
			}
			if (preklad.Contains(';'))
			{
				throw new ArgumentException("Cesky preklad obsahuje strednik");
			}

			slovickoOriginal = original;
			slovickoPreklad = preklad;

			rezimVypisuSlovicek = rezimVypisu;
		}

		public string Vypis()
		{
			string vypis = string.Empty;

			switch (rezimVypisuSlovicek)
			{
				// Preklad z ciziho jazyka do cestiny
				case RezimVypisu.OriginalNaPreklad:
					vypis = prvniSpusteniVypisu ? slovickoOriginal : slovickoPreklad;
					break;

				// Preklad z cestiny do ciziho jazyka
				case RezimVypisu.PrekladNaOriginal:
					vypis = prvniSpusteniVypisu ? slovickoPreklad : slovickoOriginal;
					break;

				// Nahodny preklad
				case RezimVypisu.NahodnyVypis:
					if (prvniSpusteniVypisu)
					{
						posledniNahodnyVypisOriginal = random.NextSingle() >= 0.5f;
						vypis = posledniNahodnyVypisOriginal ? slovickoOriginal : slovickoPreklad;
						break;
					}
					vypis = posledniNahodnyVypisOriginal ? slovickoPreklad : slovickoOriginal;
					break;
			}

			prvniSpusteniVypisu = !prvniSpusteniVypisu;
			if (vypis == string.Empty)
			{
				ObecneFunkce.Error("V programu došlo k nerozpoznané výjimce, program bude nyní ukončen...\n\nDůvod chyby: Hodnota \"vypis\" nesmí být prázdný textový řetězec!", "Error", true);
			}
			return vypis;
		}
	}
}
