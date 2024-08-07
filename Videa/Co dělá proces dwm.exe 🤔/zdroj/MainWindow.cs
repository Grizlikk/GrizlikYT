namespace Průhledná_aplikace
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void TransparencyBar_ValueChanged(object sender, EventArgs e)
		{
			TransparencyLabel.Text = $"Neprůhlednost: {TransparencyBar.Value} %";
			Opacity = (double)TransparencyBar.Value / 100;
		}
	}
}
