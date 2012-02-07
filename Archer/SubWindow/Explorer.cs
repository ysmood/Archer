using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Archer
{
	public partial class Explorer : Form
	{
		// ******** Public Part ******** 

		public Explorer()
		{
			InitializeComponent();

			this.Font = ys.Common.GetEmbededFont("Archer.Others.consola.ttf");
		}

		public new void Show()
		{
			this.StartPosition = FormStartPosition.Manual;
			this.Left = Main.Self.Right;
			this.Top = Main.Self.Top;
			base.Show();
		}

		public void Navi(string url)
		{
			webBrowser.Navigate(url);
		}

		public void FocusContent()
		{
			btnForward.Focus();
			SendKeys.Send("\t");
		}

		// ******** Private Part ********

		private void btnBackward_Click(object sender, EventArgs e)
		{
			webBrowser.GoBack();
		}

		private void btnForward_Click(object sender, EventArgs e)
		{
			webBrowser.GoForward();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Control | Keys.W:
						this.Close();
					break;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			this.Text = System.Web.HttpUtility.UrlDecode(e.Url.AbsolutePath);
		}
	}
}
