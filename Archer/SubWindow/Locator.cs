using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Archer
{
	public partial class Locator : Form
	{
		public Locator(SettingsWnd parent)
		{
			InitializeComponent();

			this.Font = Resource.MainFont;

			this.parent = parent;

			this.StartPosition = FormStartPosition.Manual;
			this.Left = parent.Right - this.Width;
			this.Top = parent.Bottom - this.Height;
		}

		private SettingsWnd parent;

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (!parent.Query(cbInput.Text, true, ckbMatchCase.Checked))
				MessageBox.Show(Resource.EndOfTable);
			else
				AddHistory();
		}

		private void btnPre_Click(object sender, EventArgs e)
		{
			if (!parent.Query(cbInput.Text, false, ckbMatchCase.Checked))
				MessageBox.Show(Resource.HeadOfTable);
			else
				AddHistory();
		}

		private void Locator_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
				case Keys.Enter:
					if (e.Control)
					{
						btnNext_Click(null, null);
						e.Handled = true;
					}
					break;
			}
		}

		private void AddHistory()
		{
			if (cbInput.Text != "" &&
				!cbInput.Items.Contains(cbInput.Text))
			{
				cbInput.Items.Insert(0, cbInput.Text);
				if (cbInput.Items.Count > 100)
					cbInput.Items.RemoveAt(cbInput.Items.Count - 1);
			}
		}
	}
}
