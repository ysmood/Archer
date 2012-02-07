using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Web;
using System.Windows.Forms;

namespace Archer
{
	public partial class SettingsWnd : Form
	{
		/// ******** Public Part ********
		
		public SettingsWnd()
		{
			InitializeComponent();

			this.Font = Resource.MainFont;

			dgvType.Items.AddRange(Main.Self.resource.InternalType);
			dgvType.ToolTipText = Main.Self.resource.InternalType_Tip;

			InitDataGridView();

			txtStrokeProp.GotFocus += new EventHandler(txtStrokeProp_GotFocus);
		}

		public void SaveSettings(object sender, EventArgs e)
		{
			Main.Setting.DefaultEditor = txtEditorPath.Text;
			Main.Setting.DefaultBrowser = txtDefaultBrowser.Text;
			Main.Setting.StrokeProperty =  txtStrokeProp.Text;

			if (Main.Self.GestureManager != null)
				Main.Self.GestureManager.StrokeProperty = txtStrokeProp.Text;

			dgv.EndEdit();

			foreach (var a in Main.Self.Arrows)
			{
				a.HotkeyEnabled = false;
			}

			Main.Self.Arrows.Clear();
			for (int i = 0; i < dgv.RowCount; i++)
			{
				if (!string.IsNullOrEmpty((string)dgv["dgvCmd", i].Value))
				{
					Arrow arrow = new Arrow()
					{
						Name = dgv[dgvName.Name, i].Value + "." + dgv[dgvType.Name, i].Value,
						Cmd = dgv[dgvCmd.Name, i].Value + "",
						Encrypted = (dgv[dgvCmd.Name, i].Style.BackColor == encryptedColor ? true : false) + "",
						Arg = dgv[dgvArg.Name, i].Value + "",
						Tag = dgv[dgvTag.Name, i].Value + "",
						HotKey = dgv[dgvHotkey.Name, i].Value + "",
						Count = dgv[dgvCount.Name, i].Value + "",
						GUID = dgv[dgvGUID.Name, i].Value + "",
					};

					if (lstChangedArrowID.Contains(arrow.GUID))
						arrow.Timestamp = DateTime.Now.ToString("u");
					else
						arrow.Timestamp = dgv[dgvTimestamp.Name, i].Value + "";

					if (dgv[dgvHotkeyEnabled.Name, i].Value != null)
						arrow.HotkeyEnabled = (bool)dgv[dgvHotkeyEnabled.Name, i].Value;

					Main.Self.Arrows.Add(arrow);

				}
			}
			Main.Self.UpdateTextInfo();
			Main.Self.SaveUserData();

			if(sender is Button)
				this.Close();
		}
		public bool Query(string s, bool next, bool matchCase)
		{
			StringComparison mc = matchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;
			int currentC = dgv.CurrentCell.ColumnIndex;
			int currentR = dgv.CurrentCell.RowIndex;
			if (next)
			{
				for (int i = ++currentR; i < dgv.RowCount; i++)
				{
					if (!string.IsNullOrEmpty((dgv[currentC, i].Value  + ""))
						&& (dgv[currentC, i].Value  + "").IndexOf(s, mc) >= 0)
					{
						dgv.CurrentCell = dgv[currentC, i];
						return true;
					}
				}
				for (int i = ++currentC; i < dgv.ColumnCount; i++)
				{
					for (int j = 0; j < dgv.RowCount; j++)
					{
						if (!string.IsNullOrEmpty((dgv[i, j].Value  + ""))
						&& (dgv[i, j].Value  + "").IndexOf(s, mc) >= 0)
						{
							dgv.CurrentCell = dgv[i, j];
							return true;
						}
					}
				}
			}
			else
			{
				for (int i = --currentR; i >= 0; i--)
				{
					if (!string.IsNullOrEmpty((dgv[currentC, i].Value  + ""))
						&& (dgv[currentC, i].Value  + "").IndexOf(s, mc) >= 0)
					{
						dgv.CurrentCell = dgv[currentC, i];
						return true;
					}
				}
				for (int i = --currentC; i >= 0; i--)
				{
					for (int j = dgv.RowCount - 1; j >= 0 ; j--)
					{
						if (!string.IsNullOrEmpty((dgv[i, j].Value  + ""))
						&& (dgv[i, j].Value  + "").IndexOf(s, mc) >= 0)
						{
							dgv.CurrentCell = dgv[i, j];
							return true;
						}
					}
				}
			}
			return false;
		}
		public bool IsShown = false;


		/// ******** Private Part ********

		private Locator locator;
		private TextBox currentTxtCell;
		private List<string> lstChangedArrowID = new List<string>();

		private Color encryptedColor = Color.FromArgb(255, 255, 219, 233);

		// Key control
		private void WindowKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.S:
					if (e.Control)
					{
						SaveSettings(null, null);
						this.Close();
					}
					return;

				case Keys.V:
					if (e.Control
						&& dgv.Focused)
					{
						if (dgv.CurrentCell != null
							&& !dgv.IsCurrentCellInEditMode)
						{
							dgv.BeginEdit(true);
							if (dgv.EditingControl is TextBox)
							{
								dgv.EditingControl.Text = Clipboard.GetText();
								(dgv.EditingControl as TextBox).SelectAll();
							}
						}
						return;
					}
					else
						break;

				case Keys.Back:
				case Keys.Delete:
					if (!dgv.Focused) return;

					foreach (DataGridViewCell item in dgv.SelectedCells)
					{
						if (item is DataGridViewTextBoxCell)
						{
							item.Value = string.Empty;
						}
					}
					break;

				case Keys.F1:
					Main.Self.OpenHelp();
					break;

				case Keys.F3:
					if(!keyPrompter.Focused)
						btnOpen_Click(null, null);
					return;

				case Keys.O:
					if (e.Control)
					{
						btnOpen_Click(null, null);
					}
					return;

				case Keys.F:
					if (e.Control)
					{
						ShowLocator(null, null);
					}
					return;

				case Keys.W:
					if (e.Control)
					{
						this.Close();
					}
					return;
			}
		}

		// Window process
		private void InitDataGridView()
		{
			this.Text = this.Text + " [ Total Arrows: " + Main.Self.Arrows.Count + " ]";
			txtEditorPath.Text = Main.Setting.DefaultEditor;
			txtDefaultBrowser.Text = Main.Setting.DefaultBrowser;
			txtStrokeProp.Text = Main.Self.GestureManager == null ? Main.Setting.StrokeProperty : Main.Self.GestureManager.StrokeProperty;
			ckbNotifyIcon.Checked = Main.Self.notifyIcon.Visible;
			dgv.Rows.Clear();

			for (int i = 0; i < Main.Self.Arrows.Count; i++)
			{
				dgv.Rows.Add(
					ys.Common.GetPreName(Main.Self.Arrows[i].Name),
					Main.Self.Arrows[i].Cmd,
					null,
					Main.Self.Arrows[i].Arg,
					Main.Self.Arrows[i].Tag,
					Main.Self.Arrows[i].HotKey,
					string.IsNullOrEmpty(Main.Self.Arrows[i].HotKey as string) ? false : Main.Self.Arrows[i].HotkeyEnabled,
					Main.Self.Arrows[i].Count,
					Main.Self.Arrows[i].Timestamp,
					Main.Self.Arrows[i].GUID
				);
				SetArrowType(dgv[dgvType.Name, i], ys.Common.GetExtension(Main.Self.Arrows[i].Name));

				if (bool.Parse(Main.Self.Arrows[i].Encrypted))
				{
					dgv[dgvCmd.Name, i].Style.BackColor = encryptedColor;
					dgv[dgvArg.Name, i].Style.BackColor = encryptedColor;
				}
			}

			dgv.Focus();

			dgv.CurrentCell = dgv[dgvName.Name, dgv.RowCount - 1];	// Move focus to the end of the table.
		}
		private void WindowShown(object sender, EventArgs e)
		{
			IsShown = true;

			MarkSameName(null, null);
		}
		private void btnOpen_Click(object sender, EventArgs e)
		{
			Main.Setting.OpenFileWithEidtor(Resource.UserData);
			SaveSettings(null, null);
			this.Close();
		}
		private void ShowLocator(object sender, EventArgs e)
		{
			if (locator == null
				|| locator.IsDisposed)
			{
				locator = new Locator(this);
				locator.Show();
			}
			else
				locator.Activate();
		}
		private void Settings_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (locator != null
				&& !locator.IsDisposed)
			{
				locator.Close();
			}
		}
		
		// Cell edit events
		private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (currentTxtCell != null)
			{
				currentTxtCell.TextChanged -= txtCurrentCell_TextChanged;
			}
			
			// Enable hotkey
			if (dgv.CurrentCell.OwningColumn == dgvHotkey
				&& !string.IsNullOrEmpty(dgv[dgvHotkey.Name, e.RowIndex].Value + ""))
			{
				if (CheckHotkey(e.RowIndex))
					dgv[dgvHotkeyEnabled.Name, e.RowIndex].Value = true;
				else
				{
					Main.Report(Resource.Exception_HotKeyFailed);
					dgv[dgvHotkey.Name, e.RowIndex].Value = string.Empty;
				}
			}
			
			// Wipe out white space.
			if (!string.IsNullOrEmpty(dgv.CurrentCell.Value + "")
				&& (dgv.CurrentCell.OwningColumn == dgvName || dgv.CurrentCell.OwningColumn == dgvType)
				&& dgv.CurrentCell.Value.ToString().Contains(" "))
			{
				Main.Report(Resource.Exception_WhiteSpaceNotAllowed);
				dgv.CurrentCell.Value = dgv.CurrentCell.Value.ToString().Replace(" ", string.Empty);
			}

			// Auto get type
			if (dgv.CurrentCell.OwningColumn == dgvName || dgv.CurrentCell.OwningColumn == dgvCmd)
			{
				if (string.IsNullOrEmpty(dgv[dgvType.Name, e.RowIndex].Value + ""))
				{
					string type = ys.Common.AutoGetType(dgv[dgvCmd.Name, e.RowIndex].Value + "");
					dgv[dgvType.Name, e.RowIndex].Value = type;
				}
			}

			// Check Changes
			string guid = dgv[dgvGUID.Name, e.RowIndex].Value + "";
			Arrow a = Main.Self.Arrows.Find(m => { return m.GUID == guid; });
			if (a != null)
			{
				if (a.Arg != dgv[dgvGUID.Name, e.RowIndex].Value + ""
					|| a.HotKey != dgv[dgvHotkey.Name, e.RowIndex].Value + ""
					|| a.Name != dgv[dgvName.Name, e.RowIndex].Value + ""
					|| a.Tag != dgv[dgvTag.Name, e.RowIndex].Value + ""
					|| a.Cmd != dgv[dgvCmd.Name, e.RowIndex].Value + "" /* last check Cmd */)
				{
					lstChangedArrowID.Add(guid);
				}
			}
		}
		private void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) // If set type manually.
		{
			if (dgv.CurrentCell.OwningColumn == dgvType)
			{
				SetArrowType(dgv.CurrentCell, e.FormattedValue);
			}
		}
		private void dgv_DragDrop(object sender, DragEventArgs e)
		{
			if (!(dgv.CurrentCell is DataGridViewTextBoxCell)) return;

			if (dgv.CurrentCell.RowIndex == dgv.Rows.Count)
				dgv.Rows.Add(1);

			if (e.Data.GetDataPresent(typeof(String)))
			{
				dgv.CurrentCell.Value = e.Data.GetData(DataFormats.Text) + "";
			}
			else if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					foreach (var path in (e.Data.GetData(DataFormats.FileDrop) as String[]))
					{
						dgv.CurrentCell.Value += "\"" + path + "\" ";
					}
				}
			}
		}
		private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			switch (dgv.CurrentCell.OwningColumn.Name)
			{
				case "dgvName":
					currentTxtCell = e.Control as TextBox;
					currentTxtCell.TextChanged += txtCurrentCell_TextChanged;
					break;

				case "dgvCmd":
				case "dgvArg":
					currentTxtCell = e.Control as TextBox;
					currentTxtCell.Multiline = true;
					currentTxtCell.WordWrap = false;
					currentTxtCell.MaxLength = 2147483647;
					break;

				case "dgvHotkey":
					currentTxtCell = e.Control as TextBox;
					currentTxtCell.AutoCompleteMode = AutoCompleteMode.Suggest;
					currentTxtCell.AutoCompleteSource = AutoCompleteSource.CustomSource;
					currentTxtCell.AutoCompleteCustomSource.Clear();
					currentTxtCell.AutoCompleteCustomSource.AddRange(Enum.GetNames(typeof(Keys)));
					break;

				case "dgvType":
					ComboBox cbCurrentCell = e.Control as ComboBox;
					cbCurrentCell.DropDownStyle = ComboBoxStyle.DropDown;
					break;
			}
		}
		private void SetArrowType(DataGridViewCell cell, object type)
		{
			if (!dgvType.Items.Contains(type))
			{
				dgvType.Items.Add(type);
			}
			cell.Value = type;
		}
		private bool CheckHotkey(int index)
		{
			string hotkey = dgv[dgvHotkey.Name, index].Value  + "";
			if (!string.IsNullOrEmpty(hotkey))
			{
				foreach (DataGridViewRow row in dgv.Rows)
				{
					if (row.Index != index
						&& !string.IsNullOrEmpty((row.Cells[4].Value  + ""))
						&& (row.Cells[4].Value  + "").Replace(" ","") == hotkey.Replace(" ", ""))
					{
						return false;
					}
				}
			}
			else
			{
				return false;
			}
			return true;
		}
		private void txtCurrentCell_TextChanged(object sender, EventArgs e)
		{
			string extension;
			foreach (DataGridViewCell cell in dgv.SelectedCells)
			{
				if (dgv.Columns[cell.ColumnIndex].Name != dgvName.Name) continue;
				extension = ys.Common.GetExtension(cell.Value + "");
				if(!string.IsNullOrEmpty(extension))
					cell.Value = ys.Common.GetPreName((sender as TextBox).Text) + "." + extension;
				else
					cell.Value = ys.Common.GetPreName((sender as TextBox).Text);
			}
		}
		private void reverseCheckMenuItem_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewCell item in dgv.SelectedCells)
			{
				if (item.ColumnIndex == dgv.Columns[dgvHotkeyEnabled.Name].Index
					&& item.Value != null)
				{
					item.Value = !(bool)item.Value;
				}
			}
		}
		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right
					&& e.ColumnIndex >= 0
					&& e.RowIndex >= 0
					&& !dgv.SelectedCells.Contains(dgv[e.ColumnIndex, e.RowIndex]))
				dgv.CurrentCell = dgv[e.ColumnIndex, e.RowIndex];
		}
		private void MarkSameName(object sender, EventArgs e)
		{
			for (int i = 0; i < dgv.Rows.Count; i++)
			{
				for (int j = i + 1; j < dgv.Rows.Count; j++)
				{
					if (ys.Common.GetPreName((string)dgv[dgvName.Name, i].Value)
						== ys.Common.GetPreName((string)dgv[dgvName.Name, j].Value))
					{
						Color clr = Color.FromArgb(Convert.ToInt32("FFFFFFB1", 16));
						dgv[dgvName.Name, i].Style.BackColor = clr;
						dgv[dgvName.Name, j].Style.BackColor = clr;
					}
				}
			}
		}

		private void insertRowMenuItem_Click(object sender, EventArgs e)
		{
			if (dgv.CurrentCell != null)
			{
				dgv.Rows.Insert(dgv.CurrentRow.Index, 1);
			}
		}
		private void duplicateRowMenuItem_Click(object sender, EventArgs e)
		{
			if (dgv.CurrentCell != null)
			{
				if (dgv.SelectedRows.Count == 0)
				{
					Main.Report(Resource.Exception_NoRowSelected);
				}
				else
				{

					int index = 0;
					foreach (DataGridViewRow r in dgv.SelectedRows)
					{
						index = index > r.Index ? index : r.Index;
					}
					index++;

					foreach (DataGridViewRow r in dgv.SelectedRows)
					{
						DataGridViewRow row = r.Clone() as DataGridViewRow;
						foreach (DataGridViewColumn item in dgv.Columns)
						{
							if (item == dgvCount)
								row.Cells[item.DisplayIndex].Value = 0;
							else if (item == dgvTimestamp)
								row.Cells[item.DisplayIndex].Value = DateTime.Now.ToString("u");
							else if (item == dgvGUID)
								row.Cells[item.DisplayIndex].Value = Guid.NewGuid().ToString();
							else
								row.Cells[item.DisplayIndex].Value = r.Cells[item.DisplayIndex].Value;
						}

						dgv.Rows.Insert(index, row);
					}
				}
			}
		}
		private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Main.Report(Resource.DeleteArrowConfirm, false, MessageBoxButtons.YesNo)
				!= System.Windows.Forms.DialogResult.Yes)
				return;

			bool[] indexs = new bool[dgv.RowCount];
			if (dgv.SelectedCells.Count > 0)
			{
				List<DataGridViewRow> lstRow = new List<DataGridViewRow>();

				foreach (DataGridViewCell item in dgv.SelectedCells)
				{
					if (indexs[item.RowIndex])
						continue;
					else
					{
						lstRow.Add(item.OwningRow);
						indexs[item.RowIndex] = true;
					}
				}
				foreach (var item in lstRow)
				{
					try
					{
						dgv.Rows.Remove(item);
					}
					catch (Exception ex)
					{
						Main.Report(ex.Message);
					}
				}
			}
		}
		private void ckbNotifyIcon_CheckedChanged(object sender, EventArgs e)
		{
			Main.Self.notifyIcon.Visible = ckbNotifyIcon.Checked;
		}
		private void txtStrokeProp_GotFocus(object sender, EventArgs e)
		{
			toolTip.Show(Resource.StrokePropertyTip, txtStrokeProp);
		}

		private void ctmDataGrid_Opened(object sender, EventArgs e)
		{
			encryptMenuItem.Checked = dgv[dgvCmd.Name, dgv.CurrentRow.Index].Style.BackColor == encryptedColor;
		}

		private void encrypt(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(Main.Setting.Password))
			{
				AccountManager accountWindow = new AccountManager();
				
				// Must be a model window. We need to block this thread.
				accountWindow.Show();
				if (accountWindow.OK)
				{
					encrypt(null, null);
				}
			}
			else
			{
				DataGridViewCell cell_cmd = dgv[dgvCmd.Name, dgv.CurrentRow.Index] as DataGridViewCell;
				DataGridViewCell cell_arg = dgv[dgvArg.Name, dgv.CurrentRow.Index] as DataGridViewCell;

				if (encryptMenuItem.Checked)
				{
					try
					{
						cell_cmd.Value = Crypter.AESString.Decrypt(
																cell_cmd.Value.ToString(),
																Main.Setting.Password
															);
						cell_cmd.Style.BackColor = cell_cmd.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(255, 240, 240, 240);

						cell_arg.Value = Crypter.AESString.Decrypt(
																cell_arg.Value.ToString(),
																Main.Setting.Password
															);
						cell_arg.Style.BackColor = cell_arg.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(255, 240, 240, 240);

						encryptMenuItem.Checked = false;
					}
					catch
					{
						Main.Report(Resource.Exception_DecryptFailed);

						AccountManager accountWindow = new AccountManager();
						accountWindow.Show();
						if (accountWindow.OK)
						{
							encrypt(null, null);
						}
					}
				}
				else
				{
					cell_cmd.Value = Crypter.AESString.Encrypt(
													cell_cmd.Value.ToString(),
													Main.Setting.Password
												);
					cell_cmd.Style.BackColor = encryptedColor;
					cell_arg.Value = Crypter.AESString.Encrypt(
													cell_arg.Value.ToString(),
													Main.Setting.Password
												);
					cell_arg.Style.BackColor = encryptedColor;
					encryptMenuItem.Checked = true;
				}
			}
		}

		// Script Store
		private void OpenScriptStore(object sender, EventArgs e)
		{
			Browser browser = new Browser();
			StringReader sr = new StringReader(Resource.ArcherSctiptStore);
			browser.Argument = sr.ReadLine();
			browser.AdditionalScript = sr.ReadToEnd();
			sr.Close();
			browser.Show();
		}
		private void ShareArrow(object sender, EventArgs e)
		{
			if (dgv.CurrentCell != null)
			{
				int row = dgv.CurrentCell.RowIndex;
				Arrow arrow = new Arrow()
				{
					Name = dgv[dgvName.Name, row].Value + "." + dgv[dgvType.Name, row].Value,
					Cmd = dgv[dgvCmd.Name, row].Value + "",
					Arg = dgv[dgvArg.Name, row].Value + "",
					Tag = dgv[dgvTag.Name, row].Value + "",
					HotKey = dgv[dgvHotkey.Name, row].Value + "",
					Count = "0",
					Timestamp = dgv[dgvTimestamp.Name, row].Value + "",
					GUID = dgv[dgvGUID.Name, row].Value + "",
				};

				ServerContactor share = new ServerContactor();
				share.Show();
				share.ShareArrow(arrow);
			}
		}


		// Drag and drop
		private void common_Enter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}
		private void common_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string fullName = (e.Data.GetData(DataFormats.FileDrop) as String[])[0];
				(sender as TextBox).Text = fullName;
			}
		}
	}
}
