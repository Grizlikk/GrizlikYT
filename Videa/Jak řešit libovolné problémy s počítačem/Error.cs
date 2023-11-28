namespace Program
{
	class Program
	{
		private static void Error()
		{
			System.Windows.Forms.MessageBox.Show("Byla detekována chyba, protože došlo k chybě :D", "Process Hacker 2", MessageBoxButtons.OK, (MessageBoxIcon)48-32*new Random().Next(2));
		}

		public static void Main(string[] args)
		{
			List<Thread> threads = new List<Thread>();
			while(true)
			{
				threads.Add(new Thread(new ThreadStart(Error)));
				threads[threads.Count - 1].Start();
				Thread.Sleep(new Random().Next(100,500));
			}
		}
	}
}