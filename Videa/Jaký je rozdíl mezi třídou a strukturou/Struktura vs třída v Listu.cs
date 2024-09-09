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
			// List, ktery obsahuje polozky podle struktury/tridy "Souradnice"
			List<Souradnice> objekty = new List<Souradnice>();

			Souradnice pozice1 = new Souradnice();
			pozice1.x = 5;
			pozice1.y = 1;
			pozice1.z = 10;
			// Pridani "pozice1" do Listu "objekty"
			objekty.Add(pozice1);

			Souradnice pozice2 = new Souradnice();
			pozice2.x = 25;
			pozice2.y = 15;
			pozice2.z = 45;
			// Pridani "pozice2" do Listu "objekty"
			objekty.Add(pozice2);

			// Pristup k promenne v Listu pres index vrati polozku stejnym stylem, jako v pripade predavani do funkce
			// Pokud je "Souradnice" trida, vrati se odkaz na data, ktera lze upravit
			// Pokud je "Souradnice" struktura, vrati se kopie dat, kterou ale upravovat nelze a kod se tedy nespusti
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