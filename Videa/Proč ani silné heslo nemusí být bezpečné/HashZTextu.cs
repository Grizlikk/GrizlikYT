using System.Security.Cryptography;
using System.Text;

namespace HashZTextu
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Overeni vstupu
			if (args.Length < 2)
			{
				Napoveda();
				return;
			}
			if (string.IsNullOrEmpty(args[0]) || string.IsNullOrEmpty(args[1]))
			{
				Napoveda();
				return;
			}

			// Nacteni a priprava promennych
			byte[] text = Encoding.UTF8.GetBytes(args[0].Trim());
			string algoritmus = args[1].Trim().ToLower();
			byte[]? hash = null;

			// Generovani hashe
			switch (algoritmus)
			{
				case "md5":
					hash = MD5.HashData(text);
					break;
				case "sha1":
					hash = SHA1.HashData(text);
					break;
				case "sha256":
					hash = SHA256.HashData(text);
					break;
				case "sha384":
					hash = SHA384.HashData(text);
					break;
				case "sha512":
					hash = SHA512.HashData(text);
					break;
				default:
					Napoveda();
					break;
			}

			// Vypis
			if (hash == null) return;

			Console.WriteLine($"\n{algoritmus.ToUpper()}: {string.Join("", hash.Select(x => x.ToString("X").ToLower()).ToArray())}\n");
		}

		private static void Napoveda()
		{
			Console.WriteLine();
			Console.WriteLine("Použití: HashZTextu.exe <TEXT> <ALGORITMUS>\n");
			Console.WriteLine("Vygeneruje hash z textu <TEXT> pomocí zadaného algoritmu <ALGORITMUS>\n");
			Console.WriteLine("Příklady:");
			Console.WriteLine("HashZTextu.exe 1234 MD5");
			Console.WriteLine("HashZTextu.exe heslo SHA256\n\n");
			Console.WriteLine("Podporované algoritmy: MD5, SHA1, SHA256, SHA384, SHA512");
			Console.WriteLine();
		}
	}
}
