namespace Program_na_výuku
{
	public partial class Nastaveni : Form
	{
		private VytvoritSouborSlovicek vytvoritSouborSlovicek = new VytvoritSouborSlovicek();

		public Nastaveni()
		{
			InitializeComponent();
		}

		private void TlacitkoVybratSoubory_Click(object sender, EventArgs e)
		{
			DialogResult vysledek = NacistSouborDialog.ShowDialog(this);
			if (vysledek == DialogResult.OK)
			{
				string[] soubory = NacistSouborDialog.FileNames;

				if (ZvoleneSouboryText.Text != string.Empty)
				{
					ZvoleneSouboryText.AppendText("\n");
				}

				for (int i = 0; i < soubory.Length; i++)
				{
					ZvoleneSouboryText.AppendText(soubory[i]);
					if (i < soubory.Length - 1)
					{
						ZvoleneSouboryText.AppendText("\n");
					}
				}
			}
		}

		private void TlacitkoOK_Click(object sender, EventArgs e)
		{
			UkoncitDialog();
		}

		private void ZvolenySouborText_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				UkoncitDialog();
			}
		}

		private void PocetSlovicekText_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				UkoncitDialog();
			}
		}

		private void UkoncitDialog(bool chyba = false)
		{
			DialogResult = DialogResult.OK;
		}

		private void VytvoritSouborSlovicek_Click(object sender, EventArgs e)
		{
			vytvoritSouborSlovicek.ShowDialog();
		}

		private void TlacitkoVycistitVybrane_Click(object sender, EventArgs e)
		{
			ZvoleneSouboryText.Text = string.Empty;
		}
	}
}
