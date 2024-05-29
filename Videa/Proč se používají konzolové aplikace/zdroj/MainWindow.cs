using System.Diagnostics;

namespace Hash_z_textu_GUI
{
	public partial class MainWindow : Form
	{
		private const string HASH_PROG_PATH = "HashZTextu.exe";

		public MainWindow()
		{
			InitializeComponent();
			AlgorithmSelector.SelectedIndex = 0;
		}

		private void CalculateHashButton_Click(object sender, EventArgs e)
		{
			if (!Path.Exists(HASH_PROG_PATH))
			{
				MessageBox.Show($"Aplikace \"{HASH_PROG_PATH}\" nebyla nalezena", "Aplikace nenalezena", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string inputText = InputTextBox.Text;
			string algorithm = AlgorithmSelector.Text;

			if (string.IsNullOrWhiteSpace(inputText))
			{
				MessageBox.Show("Nebyl zadán žádný text pro generování hashe", "Text pro hash nebyl zadán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				InputTextBox.Focus();
				return;
			}

			string arguments = $"{inputText} {algorithm}";

			ProcessStartInfo startInfo = new ProcessStartInfo(HASH_PROG_PATH);
			startInfo.Arguments = arguments;
			startInfo.CreateNoWindow = true;
			startInfo.RedirectStandardOutput = true;
			startInfo.UseShellExecute = false;

			Process process = new Process();
			process.StartInfo = startInfo;
			process.Start();

			string output = process.StandardOutput.ReadToEnd();
			process.WaitForExit();

			output = output.Substring(output.IndexOf(':') + 2);
			HashTextBox.Text = output;
		}

		private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CalculateHashButton_Click(sender, e);
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}
	}
}
