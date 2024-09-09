namespace Program_v_CSharp
{
	class Souradnice
	{
		public int x, y, z;
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			Souradnice pozice1=new Souradnice();
			pozice1.x = 5;
			pozice1.y = 1;
			pozice1.z = 10;
			// Prirazeni jedne promenne do druhe, v pripade struktury se data zkopiruji, v pripade tridy se zkopiruje jen odkaz
			Souradnice pozice2 = pozice1;

			VypisPozici(pozice1);
			VypisPozici(pozice2);
			// Pokud je "Souradnice" struktura, promenne "pozice1" a "pozice2" jsou na sobe nezavisle a upravi se pouze "pozice1"
			// Pokud je "Souradnice" trida, promenne "pozice1" i "pozice2" odkazuji na stejna data v pameti, takze pri zmene dat se prepisou hodnoty obou objektu
			pozice1.x = 25;
			VypisPozici(pozice1);
			VypisPozici(pozice2);
		}

		static void VypisPozici(Souradnice souradnice)
		{
			Console.WriteLine($"x: {souradnice.x}\ty: {souradnice.y}\tz: {souradnice.z}");
		}
	}
}