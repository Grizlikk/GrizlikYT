namespace Program_na_výuku
{       
	// Rezimy vypisu
	public enum RezimVypisu
	{
		OriginalNaPreklad = 0,
		PrekladNaOriginal = 1,
		NahodnyVypis = 2
	}

	internal class ObecneFunkce
	{
		/// <summary>
		/// Zobrazeni chyboveho hlaseni
		/// </summary>
		/// <param name="chyba">Text chyboveho hlaseni</param>
		/// <param name="nadpisChyby">Nadpis chyboveho hlaseni</param>
		/// <param name="ukoncit">Okamzite ukonceni programu po odkliknuti chyboveho hlaseni</param>
		/// <param name="ikonaChyby">Ikona zobrazene chyby</param>
		/// <param name="moznosti">Moznosti odpovedi na chybove hlaseni</param>
		/// <param name="defaultniMoznost">Defaultni moznost odpovedi</param>
		/// <returns>Zvolena odpoved na chybove hlaseni</returns>
		public static DialogResult Error(string chyba, string nadpisChyby = "Error", bool ukoncit = false, MessageBoxIcon ikonaChyby = MessageBoxIcon.Error, MessageBoxButtons moznosti = MessageBoxButtons.OK, MessageBoxDefaultButton defaultniMoznost = MessageBoxDefaultButton.Button1)
		{
			DialogResult vysledek = MessageBox.Show(chyba, nadpisChyby, moznosti, ikonaChyby, defaultniMoznost);
			if (ukoncit)
			{
				Application.Exit();
			}
			return vysledek;
		}
	}
}
