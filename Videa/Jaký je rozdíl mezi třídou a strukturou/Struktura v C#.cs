namespace Program_v_CSharp
{
	// Definice nove struktury "Souradnice"
	struct Souradnice
	{
		public int x, y, z;
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			// Vytvoreni nove struktury se v C# provadi pomoci "new"
			Souradnice poziceHrace=new Souradnice();
			poziceHrace.x = 5;
			poziceHrace.y = 1;
			poziceHrace.z = 10;
			// Predani struktury do funkce
			VypisPozici(poziceHrace);
		}

		static void VypisPozici(Souradnice souradnice)
		{
			Console.WriteLine($"x: {souradnice.x}\ty: {souradnice.y}\tz: {souradnice.z}");
		}
	}
}