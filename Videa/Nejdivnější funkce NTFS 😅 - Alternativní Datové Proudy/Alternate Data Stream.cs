namespace Alternate_Data_Stream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Soubor k překopírování: ");
            string input = Console.ReadLine() ?? "";
            if (input.StartsWith('"') && input.EndsWith('"')) input = input.Substring(1, input.Length - 2);
            Console.Write("Cílový soubor a stream: ");
            string output = Console.ReadLine() ?? "";
            if (output.StartsWith('"') && output.EndsWith('"')) output = output.Substring(1, output.Length - 2);

            try
            {
                using FileStream inputStream = new FileStream(input, FileMode.Open);
                using FileStream outputStream = new FileStream(output, FileMode.Create);

                long bytesLeft = inputStream.Length - inputStream.Position;
                while (bytesLeft > 0)
                {
                    byte[] buffer = new byte[(bytesLeft > 1 << 16) ? 1 << 16 : bytesLeft];
                    inputStream.ReadExactly(buffer);
                    outputStream.Write(buffer);
                    bytesLeft = inputStream.Length - inputStream.Position;
                }

                Console.WriteLine("\nKopírování bylo úspěšně dokončeno.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nPři běhu programu došlo k chybě: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}