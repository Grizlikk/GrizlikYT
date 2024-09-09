namespace Program_v_CSharp
{
	struct Souradnice
	{
		public int x, y, z;
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			// Pole, ktere obsahuje polozky podle struktury/tridy "Souradnice"
			Souradnice[] objekty = new Souradnice[2];

			Souradnice pozice1 = new Souradnice();
			pozice1.x = 5;
			pozice1.y = 1;
			pozice1.z = 10;
			// Nastaveni prvni polozky v poli na "pozice1"
			objekty[0] = pozice1;

			Souradnice pozice2 = new Souradnice();
			pozice2.x = 25;
			pozice2.y = 15;
			pozice2.z = 45;
			// Nastaveni druhe polozky v poli na "pozice2"
			objekty[1] = pozice2;

			// Pole narozdil od Listu vzdy vraci odkaz na data, takze bude fungovat jak se strukturou, tak i s tridou
			objekty[0].x = 20;

			VypisPozici(objekty[0]);
			VypisPozici(objekty[1]);
		}

		static void VypisPozici(Souradnice souradnice)
		{
			Console.WriteLine($"x: {souradnice.x}\ty: {souradnice.y}\tz: {souradnice.z}");
		}
	}
}