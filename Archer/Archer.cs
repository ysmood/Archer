/*
 *	Archer - a desktop tool to speed up your daily operation.
 *	For further information, visit http://code.google.com/p/ys-archer/
 *	Copyright (C) 2011 y.path.
 *
 *	This program is free software: you can redistribute it and/or modify
 *	it under the terms of the GNU General Public License as published by
 *	the Free Software Foundation, either version 3 of the License, or
 *	(at your option) any later version.
 *
 *	This program is distributed in the hope that it will be useful,
 *	but WITHOUT ANY WARRANTY; without even the implied warranty of
 *	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *	GNU General Public License for more details.
 *
 *	You should have received a copy of the GNU General Public License
 *	along with this program.  If not, see http://www.gnu.org/licenses/.
 */

#define DotNet20

#define DEBUG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using ys;
using System.Drawing;

namespace Archer
{
	public partial class Main : Form
	{
		/// ******** Pulic Part ********

		// Try to cut down comment in the code and make the member name brief.
		// Make it easy to find out the outline of the project.

		public Main()
		{
			Main.Self = this;
			
			InitializeComponent();
			
			this.Font = Resource.MainFont;

			InitGlobalHotKey();

			if(RefreshUI())
			{
				// Backup the UserData.xml fileName.
				try
				{
					File.Copy(Resource.UserData, Resource.UserData + ".backup", true);
				}
				catch { }
			}

			if (Main.Setting.UserName == "")
				Account(null, null);

			// If command line list exists, run it first.
			if (Environment.GetCommandLineArgs().Length > 1)
			{
				RunCommandLine(Environment.CommandLine);
			}

			StartCheckAndUpdate(null, null);
		}

		/// <summary>
		/// Archer main window itsself, a quick handle.
		/// </summary>
		public static Main Self;
		/// <summary>
		/// Global window to report exception. It will be redesigned as an independent UI window in future.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="shutdown"></param>
		/// <param name="mb"></param>
		/// <returns></returns>
		public static DialogResult Report(string s = "", bool shutdown = false, MessageBoxButtons mb = MessageBoxButtons.OK)
		{
			DialogResult re = MessageBox.Show(s, Self.resource.AssemblyProduct, mb, MessageBoxIcon.Warning);
			if (shutdown) System.Diagnostics.Process.GetCurrentProcess().Kill();
			return re;
		}

		public void ShowHideWindow()
		{
			ShowHideWindow(null, null);
		}
		/// <summary>
		/// Refresh UI will also reload all user data from fileName UserData.xml.
		/// </summary>
		public bool RefreshUI(bool loadUserData = true)
		{
			bool result = false;

			if (loadUserData)
			{
				Setting.DefaultBrowser = resource.DefaultLocalBrowser;
				Setting.DefaultEditor = "notepad.exe";
				Setting.StrokeProperty = "#CCFF1100,5,20";
				
				foreach (var a in arrows)
					a.HotkeyEnabled = false;

				result = LoadUserData();

				if (GestureManager != null)
					GestureManager.StrokeProperty = Setting.StrokeProperty;
			}
			UpdateTextInfo();

			if (settingsWnd != null && settingsWnd.IsShown && !settingsWnd.IsDisposed)
				settingsWnd.Show();
			if (editor != null && editor.IsShown && !editor.IsDisposed)
				editor.Show();

			runOnStartToolStripMenuItem.Checked = File.Exists(
				Environment.GetFolderPath(Environment.SpecialFolder.Startup)
				+ @"\\" + resource.AssemblyProduct + ".lnk"
			);

			#region Language

			// This part is remained for future.

			#endregion

			this.Text = resource.AssemblyProduct
				+ " " + resource.AssemblyVersion
				+ " - " + Setting.UserName;
			notifyIcon.Text = this.Text;

			// Create a flag to expose the title of the main window.
			File.WriteAllText(Resource.ArcherTemp, this.Text);

			return result;
		}
		public void UpdateTextInfo()
		{
			string temp = cbName.Text;
			cbName.Text = string.Empty;

			SortArrows();
			if (cbName.DataSource != null)
				(cbName.DataSource as BindingSource).ResetBindings(false);
			cbName.Text = temp;
			cbName_TextChanged(null, null);
		}
		public void Logoff()
		{
			cbArg.Items.Clear();
		}

		// Settings: user data handling
		public bool LoadUserData()
		{
			if (!File.Exists(Resource.UserData)) return false;

			arrows.Clear();

			XmlReader xr = XmlReader.Create(Resource.UserData);
			try
			{
				PropertyInfo[] pis;

				while (xr.Read())
				{
					/// Now Archer is English only. This part is reserved for future.
					#region Language
					//if (xr.Name == "Language")
					//{
					//    int i = 0;
					//    while (xr.MoveToNextAttribute())
					//    {
					//        string n = xr.Name;
					//        string v = xr.GetAttribute(i++);

					//        System.Reflection.FieldInfo[] fieldInfoes = resource.GetExtension().GetFields();
					//        foreach (System.Reflection.FieldInfo fieldInfo in fieldInfoes)
					//        {
					//            if (fieldInfo.Name == n && fieldInfo.FieldType == typeof(string) && fieldInfo.IsStatic)
					//                fieldInfo.SetValue(resource, v);
					//        }
					//    }
					//    xr.Skip();
					//}
					#endregion

					#region Arrows
					if (xr.Name == typeof(Arrow).Name)
					{
						int i = 0;
						Arrow a = new Arrow();
						while (xr.MoveToNextAttribute())
						{
							string n = xr.Name;
							string v = xr.GetAttribute(i++);

							pis = a.GetType().GetProperties();
							foreach (var p in pis)
							{
								if (p.PropertyType == typeof(string) && n == p.Name)
									p.SetValue(a, v, null);
							}
						}
						arrows.Add(a);
						xr.Skip();
					}
					#endregion

					#region Setting

					pis = typeof(Setting).GetProperties();
					foreach (var p in pis)
					{
						if (xr.Name == p.Name)
						{
							int i = 0;
							while (xr.MoveToNextAttribute())
							{
								string n = xr.Name;
								string v = xr.GetAttribute(i++);

								if (n == "Value")
									p.SetValue(Setting, v, null);
							}
							xr.Skip();
						}
					}

					#endregion
				}
			}
			catch (Exception ex)
			{
				Report(Resource.Exception_IllegalInitValue + "\n\n" + ex.Message, false);
				xr.Close();
				return false;
			}
			xr.Close();

			return true;
		}
		public void SaveUserData()
		{
			XmlWriterSettings Settings = new XmlWriterSettings();
			Settings.Indent = true;
			Settings.NewLineChars = "\r\n\r\n";

			XmlWriter xw;
			try
			{
				xw = XmlWriter.Create(Resource.UserData, Settings);
			}
			catch (Exception ex)
			{
				Report(ex.Message);
				return;
			}

			xw.WriteStartDocument(true);
			xw.WriteComment(
				this.resource.AssemblyProduct + " " +
				this.resource.AssemblyVersion + "  " +
				this.resource.AssemblyCopyright
			);
			xw.WriteStartElement(this.resource.AssemblyProduct);

			PropertyInfo[] pis;

			#region Settings

			pis = Setting.GetType().GetProperties();
			foreach (var p in pis)
			{
				xw.WriteStartElement(p.Name);
				xw.WriteAttributeString("Value", p.GetValue(Setting, null) + "");
				xw.WriteEndElement();
			}

			#endregion

			#region Arrows
			foreach (Arrow a in arrows)
			{
				xw.WriteStartElement(typeof(Arrow).Name);
				pis = a.GetType().GetProperties();
				foreach (PropertyInfo p in pis)
				{
					if (p.PropertyType == typeof(string) && p.GetValue(a, null) != null)
						xw.WriteAttributeString(p.Name, p.GetValue(a, null).ToString());
				}
				xw.WriteEndElement();
			}

			#endregion

			#region Language
			//xw.WriteStartElement("Language");
			//System.Reflection.FieldInfo[] fieldInfoes = resource.GetType().GetFields();
			//foreach (System.Reflection.FieldInfo fieldInfo in fieldInfoes)
			//{
			//    if (fieldInfo.IsStatic && fieldInfo.FieldType == typeof(String))
			//        xw.WriteAttributeString(fieldInfo.Name, (string)fieldInfo.GetValue(resource));
			//}

			//xw.WriteEndElement();
			#endregion
			xw.Close();
		}

		public void OpenSettings()
		{
			OpenSettings(null, null);
		}
		public void OpenHelp()
		{
			OpenDocumentation(null, null);
		}

		public List<Arrow> Arrows
		{
			get { return arrows; }
			set { arrows = value; }
		}
		public Arrow CurrentArrow
		{
			get { return currentArrow; }
		}
		public void SortArrows()
		{
			arrows.Sort((a, b) => { return a.Name.CompareTo(b.Name); });
		}

		// Launch Arrow
		/// <summary>
		/// Base arrow launch method
		/// </summary>
		/// <param name="a"></param>
		/// <param name="args">Argument to send to this arrow.</param>
		/// <param name="urlEncode">Whether insert urlEncode argument to the Cmd.</param>
		/// <returns>If launch succeed, returns true.</returns>
		public bool LaunchArrow(Arrow a, string arg = "")
		{
			string extention = Common.GetExtension(a.Name);
			string cmd = a.Cmd;

			// Crypt
			if (bool.Parse(a.Encrypted))
			{
				if (string.IsNullOrEmpty(Main.Setting.Password))
				{
					Main.Report(Resource.Exception_DecryptFailed);

					AccountManager accountWindow = new AccountManager();
					accountWindow.Show();
					return false;
				}
				else
				{
					try
					{
						cmd = Crypter.AESString.Decrypt(cmd, Main.Setting.Password);
						arg = Crypter.AESString.Decrypt(arg, Main.Setting.Password);
					}
					catch
					{
						Main.Report(Resource.Exception_DecryptFailed);

						AccountManager accountWindow = new AccountManager();
						accountWindow.Show();
						return false;
					}
				}
			}

			if (extention == string.Empty)
			{
				string type = Common.AutoGetType(cmd);
				if (type != string.Empty)
				{
					a.Name = a.Name.TrimEnd('.') + "." + type;
				}
				extention = type;
			}
			switch (extention.ToLower())
			{
				#region fileName system object
				case "f":
					arg = Common.UnfoldEV(arg);
					string arg_origin = arg;
					string startDir = string.Empty;

					string[] cmds = cmd.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
					int exceptionCount = 0;

					foreach(string item in cmds)
					{
						if (item.StartsWith("*")) startDir = item.TrimStart('*').Trim(new char[] { '\r', '\n', '"' });

						cmd = Common.UnfoldEV(item);
						arg = arg_origin;
						Common.InsertArg(ref cmd, ref arg);
						try
						{
							if (!Directory.Exists(cmd)
								&& Directory.Exists(arg))
								ys.Common.Start(arg);
							else
								ys.Common.Start(cmd, arg, startDir);
							goto CountOnce;
						}
						catch
						{
							exceptionCount++;
						}
					}

					if (exceptionCount == cmds.Length &&
						Report(Resource.Exception_FSONotFound, false, MessageBoxButtons.OKCancel) == DialogResult.OK)
					{
						Ionic.Utils.FolderBrowserDialogEx ofdEx = new Ionic.Utils.FolderBrowserDialogEx();
						ofdEx.Description = string.Format(Resource.ChooseFSO, cmd);
						ofdEx.ShowEditBox = true;
						ofdEx.ShowFullPathInEditBox = true;
						ofdEx.ShowNewFolderButton = true;
						ofdEx.ShowBothFilesAndFolders = true;
						ofdEx.SelectedPath = ys.Common.GetAvailableParentDir(cmd);
						if (ofdEx.ShowDialog() == DialogResult.OK)
						{
							a.Cmd += '\n' + ofdEx.SelectedPath;
							try
							{
								ys.Common.Start(ofdEx.SelectedPath, arg);
							}
							catch (Exception ex)
							{
								Report(ex.Message);
							}
							break;
						}
						else
							return false;
					}
					else
						return false;
				#endregion

				#region Url
				case "u":
					Common.InsertArg(ref cmd, ref arg, ModifierKeys != Keys.Control);
					try
					{
						ys.Common.Start(ys.Common.GetFileFullPath(Setting.DefaultBrowser), cmd + arg);
					}
					catch
					{
						Report(Resource.Exception_BrowserNotFound);
						return false;
					}
					break;
				#endregion

				#region Text selected
				case "t":
					string temp = Clipboard.GetText();	// Keep the pre content of the clipboard.
					try
					{
						SendKeys.SendWait("^c");
						string argument = Clipboard.GetText();
						Common.InsertArg(ref cmd, ref argument, ModifierKeys != Keys.Control);
						ys.Common.Start(ys.Common.GetFileFullPath(Setting.DefaultBrowser), cmd + argument);
					}
					catch (Exception ex)
					{
						Report(ex.Message);
						return false;
					}
					try
					{
						Clipboard.SetText(temp);
					}
					catch { }
					break;
				#endregion

				#region Copy and paste Cmd
				case "c":
					try
					{
						Clipboard.SetText(cmd + arg);
						ShowHideWindow(false);
						SendKeys.SendWait("^v");
					}
					catch (Exception ex)
					{
						Report(ex.Message);
					}
					break;
				#endregion

				#region Stroke of hardware inputs
				case "s":
					try
					{
						if (currentArrow == a)
						{
							ys.StrokeParser.SendStrokes(cmd + arg, a.HotKey);
						}
						else
							ys.StrokeParser.SendStrokes(cmd, a.HotKey);
					}
					catch (Exception ex)
					{
						Report(ex.Message);
					}
					break;
				#endregion

				#region Internal function
				case "i":
					if (!InternalFunction._RunFunction(cmd, arg))
						return false;
					break;
				#endregion

				#region UnknownType
				case "":
					Report(Resource.UnknownType + "\" " + a.Name + ".f \"");
					return false;
				#endregion

				#region _RunFunction C# script
				case "c#":
					string[] args = ys.Common.GetArgs(arg);

					// Get the references: args in list that starts with "!".
					string[] refs = Array.FindAll(args, m=> { return m.StartsWith("!"); });
					for (int i = 0; i < refs.Length; i++)
					{
						refs[i] = refs[i].TrimStart('!');
					}

					try
					{
						CSharpInterpreter.CSharpInterpreter.RunFromSrc(cmd, refs, args);
					}
					catch (Exception ex)
					{
						Report(ex.Message);
					}
					break;
				#endregion

				#region _RunFunction registered script
				default:
					try
					{
						TempFiles.Add(Common.RunTempScript(cmd, extention, arg));
					}
					catch (Exception ex)
					{
						Report(ex.Message);
						return false;
					}
					break;
				#endregion
			}
		CountOnce:
			a.CountOnce();

			return true;
		}
		public void LaunchArrows(object sender, EventArgs e)
		{
			// If Argument box have lost focus, text in it will be reserved.
			bool clearArgBox = cbArg.Focused;

			// If Name box have the focus, run all the same named arrows.
			bool runAll = cbName.Focused || sender is Arrow;

			ShowHideWindow(false);

			string name;

			if (sender is Arrow)
				name = ((Arrow)sender).Name;
			else
				name = cbName.Text;

			List<Arrow> ars = arrows.FindAll(
				m =>
				{
					if (runAll)
						return Common.GetPreName(m.Name, true) == Common.GetPreName(name, true);
					else
						return m.Name == name;
				}
			);

			bool launchSucceeded = true;

			if (ars.Count == 0)
			{
				if (cbName.Text == string.Empty)
				{
					try
					{
						ys.Common.Start(cbArg.Text);
						ShowHideWindow(false);
					}
					catch
					{
						Report(Resource.NoMatchItem);
						launchSucceeded = false;
					}
				}
				else
				{
					try
					{
						ys.Common.Start(cbName.Text, cbArg.Text);
					}
					catch
					{
						Report(Resource.NoMatchItem);
						launchSucceeded = false;
					}
				}
			}
			else
			{
				if (runAll)
				{
					foreach (var a in ars)
					{
						launchSucceeded = LaunchArrow(a, a.Arg);
					}
				}
				else
				{
					launchSucceeded = LaunchArrow(ars[0], lbArg.Text);
				}
			}

			if (cbArg.Text != "" &&
				!cbArg.Items.Contains(cbArg.Text))
			{
				cbArg.Items.Insert(0, cbArg.Text);
				if (cbArg.Items.Count > 100)
					cbArg.Items.RemoveAt(cbArg.Items.Count - 1);
			}

			if (clearArgBox)
				cbArg.Text = string.Empty;

			UpdateTextInfo();
			SaveUserData();

			if (!launchSucceeded) ShowHideWindow(true);
		}

		public Resource resource = new Resource();
		public static List<string> TempFiles = new List<string>();
		public GestureManger GestureManager;
		public bool Gesture
		{
			get { return gestureMenuItem.Checked; }
			set
			{
				if (GestureManager == null)
				{
					GestureManager = new GestureManger();
					GestureManager.StrokeProperty = Setting.StrokeProperty;
				}

				GestureManager.GestureEnabled = value;
				gestureMenuItem.Checked = value;
			}
		}

		public static Setting Setting = new Setting();


		// Online service.
		public void ShareArrow(object sender, EventArgs e)
		{
			if (currentArrow == null) return;

			ServerContactor share = new ServerContactor();
			share.Show();
			share.ShareArrow(currentArrow);
		}
		public void Backup(object sender, EventArgs e)
		{
			ServerContactor sc = new ServerContactor();
			sc.Show();
			sc.BackupUserData();
		}
		public void Recover(object sender, EventArgs e)
		{
			ServerContactor sc = new ServerContactor();
			sc.Show();
			if(sender is string)
				sc.RecoverUserData("Type=" + sender as string);

			sc.RecoverUserData();
		}
		public void Account(object sender, EventArgs e)
		{
			if (accountWnd == null || accountWnd.IsDisposed)
			{
				accountWnd = new AccountManager();
				accountWnd.ShowDialog();
			}
		}
		private void StartCheckAndUpdate(object sender, EventArgs eventArg)
		{
			string deployUrl = Resource.ArcherDeploy
								+ "?r=a&info=" + System.Web.HttpUtility.UrlEncode(this.Text)
								+ "&os=" + Environment.OSVersion.Version.Major;

			Dictionary<string, string> deployInfo = new Dictionary<string, string>();

			if (bgwUpdateChecker != null && bgwUpdateChecker.IsBusy)
			{
				bgwUpdateChecker.CancelAsync();
				bgwUpdateChecker.Dispose();
			}

			bgwUpdateChecker = new BackgroundWorker();
			bgwUpdateChecker.WorkerSupportsCancellation = true;

			bgwUpdateChecker.DoWork += (o, e) =>
			{
				try
				{
					if (sender == null)
						System.Threading.Thread.Sleep(1000 * 60 * 3);

					WebClient client = new WebClient();

					WebRequest wr = WebRequest.Create(deployUrl);
					WebResponse re = wr.GetResponse();

					fastJSON.JsonParser jsonParser = new fastJSON.JsonParser(new StreamReader(re.GetResponseStream()).ReadToEnd());
					Dictionary<string, object> raw = jsonParser.Decode() as Dictionary<string, object>;

					foreach (var item in raw)
						deployInfo.Add(item.Key, item.Value as string);

					if (deployInfo["version"].CompareTo(resource.AssemblyVersion) > 0)
						e.Result = true;
					else
						e.Result = false;
				}
				catch (Exception)
				{
					e.Result = false;
				}
			};
			bgwUpdateChecker.RunWorkerCompleted += (o, e) =>
			{
				if ((bool)e.Result)
				{
					if (sender == null)
						notifyIcon.ShowBalloonTip(5000, Resource.NewerVersionFound,
							string.Format(Resource.NewVersionInfo,
								resource.AssemblyVersion,
								deployInfo["version"],
								deployInfo["info"]
							),
							ToolTipIcon.Info
						);

					notifyIcon.BalloonTipClicked -= balloonTipClicked;
					balloonTipClicked = (oo, ee) =>
					{
						string dir = AppDomain.CurrentDomain.BaseDirectory;
						string tempDir = Resource.ArcherTemp + Guid.NewGuid().ToString();
						string file = Resource.ArcherTemp + Guid.NewGuid().ToString() + ".zip";

						Downloader uw = new Downloader();
						uw.Show();
						uw.Completed += (ooo, eee) =>
						{
							ys.Common.RunTempScript(Resource.SelfUpdate, "vbs", tempDir, file, dir);
							this.Close();
						};
						uw.StartDownload(
							deployInfo["url"],
							file
						);
					};
					if (sender != null)
						balloonTipClicked(null, null);
					else
						notifyIcon.BalloonTipClicked += balloonTipClicked;
				}
				else if (sender != null)
				{
					notifyIcon.ShowBalloonTip(5000,
						Resource.NoNewerVersion,
						" ",
						ToolTipIcon.Info);
				}
			};
			bgwUpdateChecker.RunWorkerAsync();
		}


		/// ******** Private Part ******** 


		private ManagedWinapi.Hotkey globalHotKey_ShowHideArcher;
		private ManagedWinapi.Hotkey globalHotKey_HotkeysSwitch;
		private ManagedWinapi.Hotkey globalHotKey_Account;

		private SettingsWnd settingsWnd;
		private AccountManager accountWnd;
		private Explorer explorer;
		private Editor editor;
		BackgroundWorker bgwUpdateChecker;
		private EventHandler balloonTipClicked;

		private List<Arrow> arrows = new List<Arrow>();
		private Arrow currentArrow = new Arrow();
		private Arrow preArrow = new Arrow();

		private void disableGestureMenuItem_Click(object sender, EventArgs e)
		{
			Gesture = !Gesture;
		}

		private void SetRunOnStart(object sender, EventArgs e)
		{
			runOnStartToolStripMenuItem.Checked = !runOnStartToolStripMenuItem.Checked;
			if (runOnStartToolStripMenuItem.Checked)
			{
				string temp = Common.RunTempScript(
					string.Format(Resource.CreateAutoStartShortcut,
						Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + resource.AssemblyProduct + ".lnk",
						Application.ExecutablePath,
						Directory.GetParent(Application.ExecutablePath).FullName
					),
					"vbs"
				);
				TempFiles.Add(temp);
			}
			else
			{
				File.Delete(
					Environment.GetFolderPath(Environment.SpecialFolder.Startup)
					+ "\\" + resource.AssemblyProduct + ".lnk"
				);
			}
		}

		// Init Keyboard Control
		private void InitGlobalHotKey()
		{
			// Show hide Archer
			globalHotKey_ShowHideArcher = new ManagedWinapi.Hotkey();
			globalHotKey_ShowHideArcher.WindowsKey = true;
			globalHotKey_ShowHideArcher.KeyCode = Keys.A;
			globalHotKey_ShowHideArcher.HotkeyPressed += (o, e) =>
			{
				if (this.Visible
					&& ys.Common.GetForegroundWindow() == this.Handle)
				{
					LaunchArrows(null, null);
				}
				else
				{
					ShowHideWindow(null, null);
				}
			};
			try
			{
				globalHotKey_ShowHideArcher.Enabled = true;
			}
			catch (Exception ex)
			{
				Report(Resource.Exception_HotKeyFailed + "\n\n" + ex.Message);
			}

			// Hotkeys Switch
			globalHotKey_HotkeysSwitch = new ManagedWinapi.Hotkey();
			globalHotKey_HotkeysSwitch.WindowsKey = true;
			globalHotKey_HotkeysSwitch.Shift = true;
			globalHotKey_HotkeysSwitch.KeyCode = Keys.A;
			globalHotKey_HotkeysSwitch.HotkeyPressed += (o, e) =>
			{
				Gesture = !Gesture;
			};
			try
			{
				globalHotKey_HotkeysSwitch.Enabled = true;
			}
			catch (Exception ex)
			{
				Report(Resource.Exception_HotKeyFailed + "\n\n" + ex.Message);
			}

			// Account settings
			globalHotKey_Account = new ManagedWinapi.Hotkey();
			globalHotKey_Account.WindowsKey = true;
			globalHotKey_Account.Ctrl = true;
			globalHotKey_Account.KeyCode = Keys.A;
			globalHotKey_Account.HotkeyPressed += (o, e) =>
			{
				Account(null, null);
			};
			try
			{
				globalHotKey_Account.Enabled = true;
			}
			catch (Exception ex)
			{
				Report(Resource.Exception_HotKeyFailed + "\n\n" + ex.Message);
			}
		}
		private void Archer_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
			switch (e.KeyCode)
			{
				case Keys.Escape:
					if (txtName.Focused)
					{
						txtName.Text = string.Empty;
						txtName.Visible = false;
					}
					else
						ShowHideWindow(false);
					break;

				case Keys.D:
					if (e.Control)
						DeleteArrow(null, null);
					break;

				case Keys.M:
					if (e.Control)
						ctmNotifyIcon.Show();
					break;

				case Keys.N:
					if (e.Control)
						newNewArrow(null, null);
					break;

				case Keys.R:
					if (e.Control)
						ShareArrow(null, null);
					break;

				case Keys.P:
					if (e.Control)
						OpenParentDir(null, null);
					break;

				case Keys.Enter:
					if (txtName.Focused)
					{
						txtName_Enter(null, null);
						txtName.Visible = false;
					}
					else if (e.Control)
						LaunchArrows(false, null); 
					else
						LaunchArrows(null, null);
					break;

				case Keys.V:	// Clear Name input box and focus next box with clipboard text.
					if (e.Alt)
					{
						cbName.Text = string.Empty;
						cbArg.Text = Clipboard.GetText();
						cbArg.Focus();
					}
					break;
				
				case Keys.F1:
					if (e.Control)
						OpenArcherStore(null, null);
					else
						OpenDocumentation(null, null);
					break;

				case Keys.F2:
					ShowEditor(null, null);
					break;

				case Keys.F3:
					lbCmd_Click(null, null);
					break;

				case Keys.F5:
					RefreshUI();
					break;

				case Keys.F6:
					lbName_Click(null, null);
					break;

				case Keys.S:
					if (e.Control)
					{
						if (settingsWnd == null || settingsWnd.IsDisposed)
							settingsWnd = new SettingsWnd();
						if (!settingsWnd.Visible)
							OpenSettings(null, null);
						else
						{
							settingsWnd.SaveSettings(null, null);
							settingsWnd.Close();
						}
					}
					break;
				
				case Keys.Q:
					if (e.Control)
					{
						this.Close();
					}
					break;
				
				default:
					e.Handled = false;
					break;
			}
		}
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (cbName.Focused)
			{
				switch (keyData)
				{
					case Keys.Space:
					case Keys.Tab:
						cbArg.Focus();
						cbName.SelectionLength = 0;
						cbArg.SelectAll();

						string path = Common.UnfoldEV(lbCmd.Text);
						if (Directory.Exists(path))
						{
							ShowExplorer(path);
							cbArg.Text = path.TrimEnd('\\');
							cbArg.SelectionStart = path.Length;
							SendKeys.Send("\\");
						}
						return true;
				}
			}
			else if (cbArg.Focused)
			{
				switch (keyData)
				{
					case Keys.Tab:
						if (explorer != null
							&& !explorer.IsDisposed)
						{
							explorer.Activate();
							explorer.FocusContent();
						}
						break;
				}
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Message process
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == ys.Common.WM_COPYDATA)
			{
				ys.Common.COPYDATASTRUCT data = new ys.Common.COPYDATASTRUCT();
				data = (ys.Common.COPYDATASTRUCT)m.GetLParam(data.GetType());

				RunCommandLine(data.lpData);
			}
			else if (m.Msg == ys.Common.WM_QUERYENDSESSION)
			{
				this.Close();
			}
			else
				base.WndProc(ref m);
		}
		private void RunCommandLine(string data)
		{
			string[] args = ys.Common.GetArgs(data);

			if (args.Length == 1)
			{
				ShowHideWindow(true);
				return;
			}

			cbName.Text = args[1];
			if (args.Length > 2)
			{
				Regex reg = new Regex(@"(^("".+?""\s+))|(^.+?\s+)");
				lbArg.Text = reg.Replace(reg.Replace(data, ""), "");
			}

			LaunchArrows(null, null);
		}

		// UI events
		private void Archer_Shown(object sender, EventArgs e)
		{
			BindingSource bindingName = new BindingSource();
			bindingName.DataSource = arrows;
			cbName.DataSource = bindingName;
			cbName.DisplayMember = "Name";
			cbName.SelectAll();

			if (Environment.GetCommandLineArgs().Length > 1)
				ShowHideWindow(false);
		}
		private void cbArg_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}
		private void cbArg_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(String)))
			{
				cbArg.Text = e.Data.GetData(DataFormats.Text) + "";
			}
			else if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					foreach (var path in (e.Data.GetData(DataFormats.FileDrop) as String[]))
					{
						cbArg.Text += "\"" + path + "\" ";
					}
				}
			}
		}
		private void Archer_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Link;
		}
		private void Archer_DragDrop(object sender, DragEventArgs e)
		{
			this.Activate();

			if (e.Data.GetDataPresent(typeof(String)))
			{
				string s = e.Data.GetData(DataFormats.Text) + "";
				if (ys.Common.IsUrl(s))
				{
					Regex reg = new Regex(@"(www\.)|(\.com)|(\.cn)|(\.net)|(\.org)|(\.edu)");
					Arrows.Add(new Arrow()
						{
							Cmd = s,
							Name = s = reg.Replace(new Uri(s).Host,"") + ".u",
						}
					);
					RefreshUI(false);
					cbName.Text = s;
					lbName_Click(null, null);
				}
				else
					cbArg.Text = s;
			}
			else if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					string n = string.Empty;
					foreach (var path in (e.Data.GetData(DataFormats.FileDrop) as String[]))
					{
						Arrows.Add(new Arrow()
							{
								Name = n = Path.GetFileName(path).Replace(" ","_") + "." + ys.Common.AutoGetType(path),
								Cmd = path,
							}
						);
					}

					RefreshUI(false);
					cbName.Text = n;
					lbName_Click(null, null);
				}
			}
		}
		private void cbName_TextChanged(object sender, EventArgs e)
		{
			currentArrow = arrows.Find(m => { return m.Name == cbName.Text; });

			if (currentArrow == preArrow) return;

			pbIcon.Visible = false;

			if (currentArrow != null)
			{
				lbName.Text = currentArrow.Name;

				// This will save the CPU on rendering text.
				if (currentArrow.Cmd.Length > 300)
				{
					lbCmd.Text = Resource.Multiline;
					lbCmd.ForeColor = Color.DeepSkyBlue;
				}
				else
				{
					lbCmd.Text = currentArrow.Cmd.StartsWith("*") ? currentArrow.Cmd.Substring(currentArrow.Cmd.IndexOf('\n') + 1) : currentArrow.Cmd;
					lbCmd.ForeColor = this.ForeColor;
				}

				#region Set Icon
				Bitmap icon = null;

				string extension = ys.Common.GetExtension(currentArrow.Name);
				switch (extension)
				{
					case "f":
						string[] cmds = currentArrow.Cmd.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
						foreach (var item in cmds)
						{
							if (Directory.Exists(ys.Common.UnfoldEV(item)))
							{
								icon = Properties.Resources.Folder;
								break;
							}
							else
							{ 
								try
								{
									icon = Icon.ExtractAssociatedIcon(ys.Common.GetFileFullPath(item)).ToBitmap();
									break;
								}
								catch { }
							}
						}
						break;

					case "u":
						try
						{
							string faviconPath = ys.Common.GetPathForCachedFile("http://" + new Uri(currentArrow.Cmd).Host + "/favicon.ico");
							if (faviconPath != null)
								icon = new Icon(faviconPath).ToBitmap();
							else
								icon = Icon.ExtractAssociatedIcon(ys.Common.GetFileFullPath(Main.Setting.DefaultBrowser)).ToBitmap();
						}
						catch { }
						break;

					case "t":
						try
						{
							icon = Icon.ExtractAssociatedIcon(ys.Common.GetFileFullPath(Main.Setting.DefaultBrowser)).ToBitmap();
						}
						catch { }
						break;

					case "c":
						icon = Properties.Resources.T;
						break;

					case "s":
						icon = Properties.Resources.S;
						break;

					case "i":
						icon = Properties.Resources.ArcherIcon.ToBitmap();
						break;

					case "c#":
						icon = Properties.Resources.CSharp;
						break;

					default:
						try
						{
							icon = ys.IconManager.IconFromExtensionShell(extension,ys.IconManager.SystemIconSize.Large).ToBitmap();
						}
						catch { }
						break;
				}

				if (icon != null)
				{
					pbIcon.BackgroundImage = icon;
					pbIcon.Visible = true;
				}
				#endregion


				// Encrypted
				if (bool.Parse(currentArrow.Encrypted))
				{
					lbCmd.ForeColor = Color.MediumVioletRed;
				}

				// HotkeyEnabled
				if (currentArrow.HotkeyEnabled)
				{
					lbHotKey.ForeColor = Color.ForestGreen;
				}
				else
				{
					lbHotKey.ForeColor = this.ForeColor;
				}

				if (ys.Common.GetForegroundWindow() == this.Handle
					&& sender != null)
				{
					cbArg.Text = currentArrow.Arg;
				}

				lbArg.Text = cbArg.Text;
				lbTag.Text = currentArrow.Tag;
				lbHotKey.Text = currentArrow.HotKey;
				lbCount.Text = currentArrow.Count;
			}
			else
			{
				lbName.Text = "";
				lbCmd.Text = "";
				lbArg.Text = "";
				lbTag.Text = "";
				lbHotKey.Text = "";
				lbCount.Text = "";
			}

			preArrow = currentArrow;
		}
		private void cbName_KeyUp(object sender, KeyEventArgs e)
		{
			cbName_TextChanged(null, null);
		}
		private void cbArg_TextChanged(object sender, EventArgs e)
		{
			if (currentArrow != null)
			{
				lbArg.Text = cbArg.Text.Trim(' ');
			}
		}
		private void cbArg_KeyUp(object sender, KeyEventArgs e)
		{
			cbArg_TextChanged(null, null);
		}
		private void lbCmd_Click(object sender, EventArgs e)
		{
			if (currentArrow != null)
			{
				string fullCmd = currentArrow.Cmd;
				string arg;
				string arg_origin = cbArg.Text;

				if (ys.Common.GetExtension(currentArrow.Name) == "f")
				{
					string[] cmds = fullCmd.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

					foreach (string item in cmds)
					{
						arg = arg_origin;
						fullCmd = item;
						ys.Common.InsertArg(ref fullCmd, ref arg);

						string path = ys.Common.UnfoldEV(fullCmd);
						if (Directory.Exists(path))
						{
							fullCmd = new DirectoryInfo(path).FullName;
							break;
						}
						else if (File.Exists(ys.Common.GetFileFullPath(fullCmd)))
						{
							fullCmd = ys.Common.GetFileFullPath(fullCmd);
							break;
						}
					}
				}
				else
				{
					arg = arg_origin;
					ys.Common.InsertArg(ref fullCmd, ref arg);
				}


				if (ModifierKeys == Keys.Control) // If Ctrl pressed, open browser folder.
				{
					fullCmd = ys.Common.GetUpperDir(fullCmd);
				}

				if (fullCmd != string.Empty)
					Clipboard.SetText(fullCmd);
				toolTip.Show(Resource.CopiedToClipboard, lbCmd, new System.Drawing.Point(0, lbCmd.Height), 800);

				currentArrow.CountOnce();
				lbCount.Text = currentArrow.Count;
			}
		}
		private void lbName_Click(object sender, EventArgs e)
		{
			if (currentArrow != null)
			{
				string from = currentArrow.Name;
				txtName.Visible = true;
				txtName.Focus();
				txtName.Text = from;
				txtName.SelectAll();
			}
		}
		private void txtName_Enter(object sender, EventArgs e)
		{
			if (currentArrow == null) return;

			string from = currentArrow.Name;
			string to = txtName.Text.Replace(' ', '_');

			if (txtName.Text.Length > 0 &&
				from != to)
			{
				currentArrow.Name = to;
				txtName.Visible = false;

				UpdateTextInfo();
				SaveUserData();
				cbName.Text = to;
			}

			txtName.Text = string.Empty;
		}
		private void txtName_Leave(object sender, EventArgs e)
		{
			txtName_Enter(null, null);
			txtName.Visible = false;
		}
		private void txtName_TextChanged(object sender, EventArgs e)
		{
			string from = ys.Common.GetPreName(currentArrow.Name);
			string to = ys.Common.GetPreName(txtName.Text);
			bool repeat = Main.Self.Arrows.Exists(m =>
			{
				string name = ys.Common.GetPreName(m.Name);
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
		private void ChangeAccount(object sender, EventArgs e)
		{
			AccountManager accountWindow = new AccountManager();
			accountWindow.Show(this);
		}
		private void DeleteArrow(object sender, EventArgs e)
		{
			if (Report(Resource.DeleteArrowConfirm, false, MessageBoxButtons.YesNo)
				!= System.Windows.Forms.DialogResult.Yes)
				return;

			if (currentArrow != null)
			{
				txtName_Leave(null, null);
				arrows.Remove(currentArrow);
				UpdateTextInfo();
			}
		}
		private void OpenParentDir(object sender, EventArgs e)
		{
			if (currentArrow != null
				&& ys.Common.GetExtension(currentArrow.Name) == "f")
			{
				string[] cmds = currentArrow.Cmd.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var item in cmds)
				{
					try
					{
						ys.Common.Start(ys.Common.GetUpperDir(ys.Common.GetFileFullPath(item)));
						break;
					}
					catch
					{
					}
				}
			}
		}


		// Start, hide, close window part
		protected override void OnClosing(CancelEventArgs e)
		{
			if (notifyIcon != null)
			{
				e.Cancel = true;
				ShowHideWindow(false);
			}
		}
		private new void Close()
		{
			SaveUserData();

			notifyIcon.Dispose();
			notifyIcon = null;

			TempFiles.Add(Resource.ArcherTemp);
			foreach (var temp in TempFiles)
			{
				try
				{
					File.Delete(temp);
				}
				catch (Exception ex)
				{
					Report(ex.Message);
				}
			}

			base.Close();
		}
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void OpenArcherStore(object sender, EventArgs e)
		{
			Browser browser = new Browser();
			StringReader sr = new StringReader(Resource.ArcherSctiptStore);
			browser.Argument = sr.ReadLine();
			browser.AdditionalScript = sr.ReadToEnd();
			sr.Close();
			browser.Show();
		}
		private void ShowHideWindow(object o, EventArgs e)
		{
			if (o is NotifyIcon)
			{
				ShowHideWindow(true);
				return;
			}

			if (this.Visible)
			{
				if (ys.Common.GetForegroundWindow() != this.Handle)
				{
					if (this.WindowState != FormWindowState.Normal)
						this.WindowState = FormWindowState.Normal;
					this.Activate();
				}
				else
				{
					ShowHideWindow(false);
				}

			}
			else
			{
				ShowHideWindow(true);

				if (this.WindowState != FormWindowState.Normal)
					this.WindowState = FormWindowState.Normal;

			}
		}
		private void ShowHideWindow(bool show)
		{
			if (this.IsDisposed) return;

			if (show)
			{
				if (!this.ShowInTaskbar)
					this.ShowInTaskbar = true;

				this.Visible = true;
				this.Activate();
				cbName.Focus();
			}
			else
			{
				this.Visible = false;
				txtName.Text = string.Empty;
				txtName.Visible = false;
			}
			if (explorer != null) explorer.Visible = false;
		}
		private void ShowAboutBox(object sender, EventArgs e)
		{
			AboutBox aboutBox = new AboutBox();
			aboutBox.Show();
		}
		private void scriptStoreMenuItem_Click(object sender, EventArgs e)
		{
			Browser browser = new Browser();
			StringReader sr = new StringReader(Resource.ArcherSctiptStore);
			browser.Argument = sr.ReadLine();
			browser.AdditionalScript = sr.ReadToEnd();
			sr.Close();
			browser.Show();
		}


		// Function window part
		private void OpenSettings(object sender, EventArgs e)
		{
			cbName.Focus();
			if (settingsWnd == null || settingsWnd.IsDisposed)
				settingsWnd = new SettingsWnd();
			settingsWnd.Show();
			settingsWnd.WindowState = FormWindowState.Normal;
			settingsWnd.Activate();
		}
		private void newNewArrow(object sender, EventArgs e)
		{
			string path = ys.Common.GetFileFullPath(Clipboard.GetText());
			if (ys.Common.IsUrl(path))
			{
				Regex reg = new Regex(@"(www\.)|(\.com)|(\.cn)|(\.net)|(\.org)|(\.edu)");
				Arrows.Add(new Arrow()
				{
					Cmd = path,
					Name = path = reg.Replace(new Uri(path).Host, "") + ".u",
				}
				);
				RefreshUI(false);
				cbName.Text = path;
				lbName_Click(null, null);
				return;
			}
			else if (Directory.Exists(path)
				|| File.Exists(path))
			{
				Arrows.Add(new Arrow()
				{
					Cmd = path,
					Name = path = Path.GetFileName(path).Replace(" ", "_") + "." + ys.Common.AutoGetType(path),
				}
				);
				RefreshUI(false);
				cbName.Text = path;
				lbName_Click(null, null);
				return;
			}

			if (editor == null || editor.IsDisposed)
				editor = new Editor();
			editor.Show(true);
			editor.Activate();
		}
		private void ShowEditor(object sender, EventArgs e)
		{
			cbName.Focus();
			if (currentArrow == null)
			{
				Report(Resource.Exception_NoCurrentArrow);
				return;
			}
			if (editor == null || editor.IsDisposed)
				editor = new Editor();
			editor.Show();
			editor.Activate();
		}
		private void ShowExplorer(string path)
		{
			if (explorer == null || explorer.IsDisposed)
				explorer = new Explorer();
			explorer.Show();
			explorer.Activate();

			this.Activate();

			explorer.Navi(path);
		}
		private void OpenDocumentation(object sender, EventArgs e)
		{
			try
			{
				ys.Common.Start(Directory.GetParent(Application.ExecutablePath) + "\\Archer.chm");
			}
			catch (Exception ex)
			{
				Report(ex.Message);
			}
		}
	}
}
