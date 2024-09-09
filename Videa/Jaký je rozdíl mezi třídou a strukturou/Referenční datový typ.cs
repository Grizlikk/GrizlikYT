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
			Souradnice poziceHrace=new Souradnice();
			poziceHrace.x = 5;
			poziceHrace.y = 1;
			poziceHrace.z = 10;
			// Predavani "poziceHrace" do funkce: V pripade struktury jako kopii dat, v pripade tridy jako odkaz na data
			VypisPozici(poziceHrace);
			VypisPozici(poziceHrace);
		}

		// V pripade, ze "Souradnice" je struktura, funkce prebira KOPII dat struktury
		// V pripade, ze "Souradnice" je trida, funkce prebira ODKAZ na data v pameti
		static void VypisPozici(Souradnice souradnice)
		{
			Console.WriteLine($"x: {souradnice.x}\ty: {souradnice.y}\tz: {souradnice.z}");
			// Uprava dat v pripade struktury neovlivni originalni promennou, v pripade tridy ano
			souradnice.x = 20;
		}
	}
}