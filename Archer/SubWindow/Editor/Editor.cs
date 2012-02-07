using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using System.Reflection;
using CSharpInterpreter;


namespace Archer
{
	public partial class Editor : Form
	{

		public Editor()
		{
			InitializeComponent();

			this.Font = Resource.MainFont;
			txtCmd.Font = Resource.CodeFont;

			txtCmd.ActiveTextAreaControl.TextArea.AllowDrop = true;
			txtCmd.ActiveTextAreaControl.TextArea.DragEnter += txtCmdEditor_DragEnter;
			txtCmd.ActiveTextAreaControl.TextArea.DragDrop += txtCmdEditor_DragDrop;
		}


		/******** CSharp Common Part ********/

		public const string DummyFileName = "edited.cs";

		private void MainForm_Load(object sender, EventArgs e)
		{
			txtCmd.Document.FoldingManager.FoldingStrategy = new CSharpInterpreter.code_editor.MyFoldStrategy();

			txtCmd.TextChanged += (s, ev) => {
				txtCmd.Document.FoldingManager.UpdateFoldings(null, null);
			};
		}


		private void btnCSharpHighlight_Click(object sender, EventArgs e)
		{
			CSharpHighlight = !CSharpHighlight;
		}
		private void btnResetCode_Click(object sender, EventArgs e)
		{
			if (CSharpHighlight == false) CSharpHighlight = true;

			txtCmd.Text = Resource.CSharpDefaultCode;

			txtCmd.ActiveTextAreaControl.SelectionManager.SetSelection(
				new ICSharpCode.TextEditor.TextLocation(0, 19), new ICSharpCode.TextEditor.TextLocation(23, 19));
			txtCmd.ActiveTextAreaControl.Caret.Line = 19;
			txtCmd.ActiveTextAreaControl.Caret.Column = 23;
			txtCmd.ActiveTextAreaControl.ScrollTo(0);

			txtCmd.Invalidate();
			txtCmd.ActiveTextAreaControl.Invalidate();
			txtCmd.ActiveTextAreaControl.TextArea.Invalidate();
			txtCmd.Document.FoldingManager.UpdateFoldings(null, null);
			txtCmd.Document.FoldingManager.GetFoldingsWithStart(0)[0].IsFolded = true;
			txtCmd.Document.FoldingManager.GetFoldingsWithStart(21)[0].IsFolded = true;
		}

		private void txtCmdEditor_DragEnter(object sender, DragEventArgs e)
		{
			try
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (files[0].EndsWith("cs", StringComparison.OrdinalIgnoreCase))
				{
					e.Effect = DragDropEffects.Copy;
				}
				else e.Effect = DragDropEffects.None;
			}
			catch { e.Effect = DragDropEffects.None; }
		}
		private void txtCmdEditor_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (files[0].EndsWith("cs", StringComparison.OrdinalIgnoreCase))
				{
					txtCmd.Text = File.ReadAllText(files[0]);
				}
				//else e.Effect = DragDropEffects.None;
			}
			catch { //e.Effect = DragDropEffects.None;
			}
		}


		/******** Archer Common Part ********/

		public void Show(bool newArrow = false)
		{
			base.Show();
			this.WindowState = FormWindowState.Normal;

			this.newArrow = newArrow;

			if (newArrow)
				currentArrow = new Arrow();
			else
				currentArrow = Main.Self.CurrentArrow;

			if (currentArrow == null) return;

			txtArg.Text = currentArrow.Arg;
			txtCmd.Text = currentArrow.Cmd;
			txtKey.Text = currentArrow.HotKey;
			txtName.Text = currentArrow.Name;
			txtTag.Text = currentArrow.Tag;

			btnHotkeyEnabled.Checked = currentArrow.HotkeyEnabled;
			btnEncrypted.Checked = bool.Parse(currentArrow.Encrypted);

			IsShown = true;

			foreach (var item in txtCmd.Document.FoldingManager.FoldMarker)
				item.IsFolded = true;

			if (ys.Common.GetExtension(currentArrow.Name).ToLower() == "c#"
				|| ys.Common.GetExtension(currentArrow.Name).ToLower() == "cs")
				CSharpHighlight = true;

		}

		public bool IsShown = false;
		public bool CSharpHighlight
		{
			get { return btnCSharpHighlight.Checked; }
			set
			{
				btnCSharpHighlight.Checked = value;

				if (btnCSharpHighlight.Checked)
				{
					txtCmd.SetHighlighting("C#");
				}
				else
				{
					txtCmd.SetHighlighting("");
				}
			}
		}

		private Arrow currentArrow;	// This is important, here'path current arrow may different from the main window'path.
		private bool newArrow;

		private void Save(object sender, EventArgs e)
		{
			if (currentArrow == null) return;

			if (string.IsNullOrEmpty(ys.Common.GetExtension(txtName.Text)))
				txtName.Text += "." + ys.Common.AutoGetType(txtCmd.Text);

			if (currentArrow.Arg != txtArg.Text
				|| currentArrow.HotKey != txtKey.Text
				|| currentArrow.Name != txtName.Text
				|| currentArrow.Tag != txtTag.Text
				|| currentArrow.Cmd != txtCmd.Text /* last check Cmd */)
				currentArrow.Timestamp = DateTime.Now.ToString("u");

			currentArrow.Arg = txtArg.Text;
			currentArrow.Cmd = txtCmd.Text;
			currentArrow.Encrypted = btnEncrypted.Checked.ToString();
			currentArrow.HotKey = txtKey.Text;
			currentArrow.HotkeyEnabled = btnHotkeyEnabled.Checked;
			currentArrow.Name = txtName.Text;
			currentArrow.Tag = txtTag.Text;

			if (newArrow)
				Main.Self.Arrows.Add(currentArrow);

			Main.Self.UpdateTextInfo();
			Main.Self.SaveUserData();

			this.Close();
		}

		// Key Control
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.S | Keys.Control:
					Save(null, null);
					return true;

				case Keys.Escape:
					this.Close();
					return true;

				case Keys.F2:
					txtName.SelectAll();
					txtName.Focus();
					return true;

				case Keys.F5:
					btnRun_Click(null, null);
					return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void btnHotkeyEnabled_Click(object sender, EventArgs e)
		{
			if (txtKey.Text == string.Empty)
			{
				Archer.Main.Report(Resource.Exception_NoHotKey);
				return;
			}

			btnHotkeyEnabled.Checked = !btnHotkeyEnabled.Checked;
			currentArrow.HotkeyEnabled = btnHotkeyEnabled.Checked;
		}

		private void txtName_TextChanged(object sender, EventArgs e)
		{
			string from = ys.Common.GetPreName(currentArrow.Name);
			string to = ys.Common.GetPreName(txtName.Text);
			bool repeat = Main.Self.Arrows.Exists(m =>
			{
				string name =ys.Common.GetPreName(m.Name);
				return name != from && name == to;
			}
			);

			if (repeat)
			{
				toolTip.Show(Resource.Repeated, txtName);
				txtName.BackColor = Color.FromArgb(231, 154, 154);
			}
			else
			{
				toolTip.Hide(txtName);
				txtName.BackColor = Color.White;
			}
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			Arrow a = new Arrow()
			{
				Arg = txtArg.Text,
				Cmd = txtCmd.Text,
				Name = txtName.Text,
			};

			Main.Self.LaunchArrow(a, a.Arg);
		}

		private void cutToolStripButton_Click(object sender, EventArgs e)
		{
			if (txtCmd.ActiveTextAreaControl.SelectionManager.HasSomethingSelected)
				Clipboard.SetText(txtCmd.ActiveTextAreaControl.SelectionManager.SelectedText);
			txtCmd.ActiveTextAreaControl.SelectionManager.RemoveSelectedText();
		}

		private void copyToolStripButton_Click(object sender, EventArgs e)
		{
			if(txtCmd.ActiveTextAreaControl.SelectionManager.HasSomethingSelected)
				Clipboard.SetText(txtCmd.ActiveTextAreaControl.SelectionManager.SelectedText);
		}

		private void pasteToolStripButton_Click(object sender, EventArgs e)
		{
			if (txtCmd.ActiveTextAreaControl.SelectionManager.HasSomethingSelected)
				txtCmd.ActiveTextAreaControl.SelectionManager.RemoveSelectedText();
			txtCmd.ActiveTextAreaControl.TextArea.InsertString(Clipboard.GetText() + "");
		}

		private void helpToolStripButton_Click(object sender, EventArgs e)
		{
			Main.Self.OpenHelp();
		}

		private void encrypt(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(Main.Setting.Password))
			{
				AccountManager accountWindow = new AccountManager();

				// Must be a model window. We need to block this thread.
				accountWindow.ShowDialog(this);
				if (accountWindow.OK)
				{
					encrypt(null, null);
				}
			}
			else
			{

				if (btnEncrypted.Checked)
				{
					try
					{
						txtCmd.Text = Crypter.AESString.Decrypt(
																txtCmd.Text,
																Main.Setting.Password
															);
						txtArg.Text = Crypter.AESString.Decrypt(
																txtArg.Text,
																Main.Setting.Password
															);
						btnEncrypted.Checked = false;
					}
					catch
					{
						Main.Report(Resource.Exception_DecryptFailed);

						AccountManager accountWindow = new AccountManager();
						accountWindow.ShowDialog(this);
						if (accountWindow.OK)
						{
							encrypt(null, null);
						}
					}
				}
				else
				{
					txtCmd.Text = Crypter.AESString.Encrypt(
													txtCmd.Text,
													Main.Setting.Password
												);
					txtArg.Text = Crypter.AESString.Encrypt(
													txtArg.Text,
													Main.Setting.Password
												);
					btnEncrypted.Checked = true;
				}
				txtCmd.Refresh();
			}
		}

		private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			txtName.SelectAll();
			txtName.Focus();
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			txtCmd.ActiveTextAreaControl.SelectionManager.ClearSelection();
			SendKeys.SendWait("^a");
		}

		private void cutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendKeys.SendWait("^x");
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendKeys.SendWait("^c");
		}

		private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			txtCmd.ActiveTextAreaControl.SelectionManager.ClearSelection();
			SendKeys.SendWait("^a");
			SendKeys.SendWait("^c");
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendKeys.SendWait("^v");
		}

		private void txtKey_TextChanged(object sender, EventArgs e)
		{
			if (!btnHotkeyEnabled.Checked)
				btnHotkeyEnabled.Checked = true;
		}
	}
}
