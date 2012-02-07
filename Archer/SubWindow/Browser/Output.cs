using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Archer
{
	public partial class Output : Form
	{
		public Output()
		{
			InitializeComponent();

			this.Font = Archer.Resource.MainFont;
		}
		public new bool TopMost
		{
			get { return topMostToolStripMenuItem.Checked; }
			set
			{
				topMostToolStripMenuItem.Checked = value;
				base.TopMost = value;
			}
		}

		public void Append(string output)
		{
			txtOutput.Text += output;
		}
		private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.TopMost = !this.TopMost;
		}

		private int count = 0;
	}
}
