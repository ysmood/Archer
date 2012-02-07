using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ys.Control
{
	public partial class KeyPrompter : UserControl
	{
		public KeyPrompter()
		{
			InitializeComponent();

			txtKeyPrompter.GotFocus += txtKeyPrompter_GotFocus;
		}

		public new bool Focused
		{
			get { return txtKeyPrompter.Focused; }
		}

		private void txtKeyPrompter_GotFocus(object sender, EventArgs e)
		{
			if (txtKeyPrompter.Text != "Win")
				txtKeyPrompter.Text = "Please press a key";
		}

		private void txtKeyPrompter_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Alt)
					txtKeyPrompter.Text = "Alt";
				else if (e.Control)
					txtKeyPrompter.Text = "Ctrl";
				else if (e.Shift)
					txtKeyPrompter.Text = "Shift";
				else if (e.KeyData.ToString().Contains("Win"))
					txtKeyPrompter.Text = "Win";
				else
					txtKeyPrompter.Text = e.KeyData.ToString();

				Clipboard.SetText(txtKeyPrompter.Text);
				toolTip.Show(Archer.Resource.CopiedToClipboard, txtKeyPrompter, new Point(0, txtKeyPrompter.Height), 800);

				e.Handled = true;
				e.SuppressKeyPress = true;

			}
			catch
			{
			}
		}
	}
}
