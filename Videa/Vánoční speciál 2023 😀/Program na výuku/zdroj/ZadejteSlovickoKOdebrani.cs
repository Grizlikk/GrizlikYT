using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_na_výuku
{
	public partial class ZadejteSlovickoKOdebrani : Form
	{
		public ZadejteSlovickoKOdebrani()
		{
			InitializeComponent();
		}

		private void TlacitkoOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
		private void SlovickoKOdebrani_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				DialogResult = DialogResult.OK;
			}
		}
	}
}
