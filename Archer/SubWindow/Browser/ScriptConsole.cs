using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Archer
{
	public partial class ScriptConsole : Form
	{
		public ScriptConsole(Browser browser, string code = null)
		{
			InitializeComponent();

			this.browser = browser;

			this.Font = Resource.MainFont;

			txtCode.Font = Resource.CodeFont;
			txtCode.SetHighlighting("C#");

			if (code != null)
				txtCode.Text = code;
		}
		public new bool TopMost
		{
			get { return btnTopMost.Checked; }
			set
			{
				btnTopMost.Checked = value;
				base.TopMost = value;
			}
		}

		private Browser browser;

		private void btnRunScript_Click(object sender, EventArgs e)
		{
			browser.InjectAndRunScript(txtCode.Text);
		}

		private void ScriptConsole_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					btnRunScript_Click(null, null);
					break;
				case Keys.Escape:
					this.Close();
					break;
			}
		}

		private void btnOutput_Click(object sender, EventArgs e)
		{
			browser.ShowOutput();
		}

		private void btnTopMost_Click(object sender, EventArgs e)
		{
			this.TopMost = !this.TopMost;
		}

		private void ScriptConsole_Load(object sender, EventArgs e)
		{
			txtCode.Document.FoldingManager.FoldingStrategy = new CSharpInterpreter.code_editor.MyFoldStrategy();
			txtCode.Document.FoldingManager.UpdateFoldings(null, null);
			txtCode.TextChanged += (oo, ee) =>
			{
				txtCode.Document.FoldingManager.UpdateFoldings(null, null);
			};
		}
	}
}
