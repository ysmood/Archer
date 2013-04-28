using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Net;

namespace Archer
{
	public partial class ServerContactor : Form
	{
		/// <summary>
		/// Handle online services.
		/// </summary>
		/// <param name="autoClose">Auto close window after task finished.</param>
		/// <param name="autoCloseTime">Set time out. Unit: millisecond.</param>
		public ServerContactor(bool autoClose = true, int autoCloseTime = 1000)
		{
			InitializeComponent();

			this.Font = Resource.MainFont;

			this.autoClose = autoClose;
			this.autoCloseTime = autoCloseTime;
		}

		public bool Logged_in = false;

		public void ShareArrow(Arrow arrow)
		{
			if (canceled) return;

			string data = "";

			System.Reflection.PropertyInfo[] pis = typeof(Arrow).GetProperties();
			foreach (var p in pis)
			{
				if (p.PropertyType == typeof(string) && p.GetValue(arrow, null) != null)
					data += p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(arrow, null).ToString()) + "&";
			}

			Report("Name: " + arrow.Name);
			Report("Tag: " + arrow.Tag);
			SendString(Resource.ArcherSctiptStore_Share, data);
		}
		public void DeleteArrow(string guid, string date)
		{
			if (canceled) return;

			string data = "";

			data += "GUID=" + HttpUtility.UrlEncode(guid)
				+ "&DateTime=" + HttpUtility.UrlEncode(date);

			Report(Resource.Deleting);
			Report("GUID: " + guid);
			SendString(Resource.ArcherSctiptStore_Delete, data);
		}
		public void BackupUserData(string userName = "", string password = "")
		{
			if (canceled) return;

			if (Main.Report(Resource.BackupWarning, false, MessageBoxButtons.YesNo)
				!= System.Windows.Forms.DialogResult.Yes)
			{
				Report(Resource.Canceled);
				return;
			}

			Main.Self.SaveUserData();

			try
			{
				StreamReader sr = new StreamReader(Resource.UserData);
				string data = "Type=Backup"
						+ "&UserData=" + HttpUtility.UrlEncode(sr.ReadToEnd());
				sr.Close();

				Report(Resource.Backuping);

				BackgroundWorker bgw = new BackgroundWorker();

				string postData = GetAuthInfo(userName, password) + data;

				bgw.DoWork += (o, e) =>
				{
					try
					{
						e.Result = ys.Common.HttpPost(Resource.ArcherOnlineService, postData);
						bgw.Dispose();
					}
					catch (Exception ex)
					{
						e.Result = ex.Message;
						MessageBox.Show(ex.Message);
					}
				};
				bgw.RunWorkerCompleted += (o, e) =>
				{
					switch (e.Result.ToString())
					{
						case "auth_error":
							Report(Resource.AuthenticateError);

							if (!string.IsNullOrEmpty(userName)) break;

							AccountManager accountWindow = new AccountManager();
							// Must be a model window. We need to block this thread.
							accountWindow.TryAgainWindow = true;
							accountWindow.ShowDialog(this);
							if (accountWindow.OK)
							{
								postData = GetAuthInfo(userName, password) + data;
								bgw.RunWorkerAsync();
							}
							else
							{
								Report(Resource.Canceled);
								if (autoClose)
									AutoCloseWindow();
							}
							break;

						case "server_failed":
							Report(Resource.ServerFailed);
							break;

						case "server_done":
							Report(Resource.ServerDone);
							if (autoClose) AutoCloseWindow();
							break;

						default:
							Report(e.Result.ToString());
							break;
					}
				};
				bgw.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				Report(ex.Message);
			}

		}
		public void RecoverUserData(string type = "Type=Recovery", string userName = "", string password = "")
		{
			if (canceled) return;

			if (Main.Report(Resource.RecoveryWarning, false, MessageBoxButtons.YesNo)
				!= System.Windows.Forms.DialogResult.Yes)
			{
				Report(Resource.Canceled);
				return;
			}

			Report(Resource.Recovering);

			BackgroundWorker bgw = new BackgroundWorker();

			string postData = GetAuthInfo(userName, password) + type;

			bgw.DoWork += (o, e) =>
			{
				try
				{
					e.Result = ys.Common.HttpPost(Resource.ArcherOnlineService, postData);
					bgw.Dispose();
				}
				catch (Exception ex)
				{
					e.Result = ex.Message;
					MessageBox.Show(ex.Message);
				}
			};
			bgw.RunWorkerCompleted += (o, e) =>
			{
				string r = e.Result.ToString();
				switch (r)
				{
					case "auth_error":
						Report(Resource.AuthenticateError);

						if (!string.IsNullOrEmpty(userName)) break;

						AccountManager accountWindow = new AccountManager();
						// Must be a model window. We need to block this thread.
						accountWindow.TryAgainWindow = true;
						accountWindow.ShowDialog(this);
						if (accountWindow.OK)
						{
							postData = GetAuthInfo(userName, password) + type;
							bgw.RunWorkerAsync();
						}
						else
						{
							Report(Resource.Canceled);
							if (autoClose)
								AutoCloseWindow();
						}
						break;

					case "server_failed":
						Report(Resource.DownloadFailed);
						break;

					default:
						Report(Resource.DownloadSucceeded);
						try
						{
							StreamWriter sw = new StreamWriter(Resource.UserData);
							sw.Write(r);
							sw.Close();
							Main.Self.RefreshUI();
							Report(Resource.RecoveryDone);
						}
						catch (Exception ex)
						{
							Report(ex.Message);
						}

						if (autoClose) AutoCloseWindow();
						break;
				}
			};
			bgw.RunWorkerAsync();
		}
		public void ChangePassword(string newPassword)
		{
			string data = "Type=ChangePassword"
					+ "&NewPassword=" + HttpUtility.UrlEncode(newPassword);

			Report(Resource.Communicating);
			SendString(Resource.ArcherOnlineService, data, false);
		}

		public void SendFile(string url, string filePath, Arrow a, bool allowRetry = true)
		{
			BackgroundWorker bgw = new BackgroundWorker();
			bgw.WorkerSupportsCancellation = true;

			bgw.DoWork += (o, e) =>
			{
				Dictionary<string, string> header = new Dictionary<string, string>()
				{
					{ "UserName", Main.Setting.UserName },
					{ "Password", Main.Setting.Password },
					{ "GUID", a.GUID }
				};

				try
				{
					e.Result = ys.Common.HttpUpload(url, header, filePath);
					bgw.Dispose();
				}
				catch (Exception ex)
				{
					e.Result = ex.Message;
					MessageBox.Show(ex.Message);
				}
			};
			bgw.RunWorkerCompleted += (o, e) =>
			{
				string r = e.Result.ToString();
				switch (r)
				{
					case "auth_error":
						Report(Resource.AuthenticateError);

						if (!allowRetry) break;

						AccountManager accountWindow = new AccountManager();
						// Must be a model window. We need to block this thread.
						accountWindow.TryAgainWindow = true;
						accountWindow.ShowDialog(this);
						if (accountWindow.OK)
						{
							bgw.RunWorkerAsync();
						}
						else
						{
							Report(Resource.Canceled);
							if (autoClose)
								AutoCloseWindow();
						}
						break;

					case "server_failed":
						Report(Resource.ServerFailed);
						break;

					case "server_done":
						Report(Resource.ServerDone);
						if (autoClose) AutoCloseWindow();
						break;

					default:
						Report(r);

						a.Cmd += '\n' + r;

						Clipboard.SetText(r);

						if (autoClose) AutoCloseWindow();
						break;
				}
			};
			bgw.RunWorkerAsync();
		}

		private bool autoClose;
		private int autoCloseTime;
		private bool canceled = false;

		private string GetAuthInfo(string userName = "", string password = "")
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
			{
				return "UserName=" + HttpUtility.UrlEncode(Main.Setting.UserName) + "&" +
				"Password=" + HttpUtility.UrlEncode(Main.Setting.Password) + "&";
			}
			else
			{
				return "UserName=" + HttpUtility.UrlEncode(userName) + "&" +
				"Password=" + HttpUtility.UrlEncode(password) + "&";
			}
		}

		private void Report(string state)
		{
			txtState.Text += "\r\n\r\n>> " + state;

			txtState.Select(txtState.TextLength, 0);
			txtState.ScrollToCaret();
		}
		private void This_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
			}
		}
		private void AutoCloseWindow()
		{
			Report(Resource.AutoClose + autoCloseTime + "ms");

			Timer tmr = new Timer()
			{
				Interval = autoCloseTime,
				Enabled = true
			};
			tmr.Tick += (oo, ee) =>
			{
				tmr.Stop();
				this.Close();
			};
			tmr.Start();
		}
		private void SendString(string url, string data, bool allowRetry = true)
		{
			BackgroundWorker bgw = new BackgroundWorker();

			string postData = GetAuthInfo() + data;

			bgw.DoWork += (o, e) =>
			{
				try
				{
					e.Result = ys.Common.HttpPost(url, postData);
					bgw.Dispose();
				}
				catch (Exception ex)
				{
					e.Result = ex.Message;
					MessageBox.Show(ex.Message);
				}
			};
			bgw.RunWorkerCompleted += (o, e) =>
			{
				switch (e.Result.ToString())
				{
					case "auth_error":
						Report(Resource.AuthenticateError);

						if (!allowRetry) break;

						AccountManager accountWindow = new AccountManager();
						// Must be a model window. We need to block this thread.
						accountWindow.TryAgainWindow = true;
						accountWindow.ShowDialog(this);
						if (accountWindow.OK)
						{
							postData = GetAuthInfo() + data;
							bgw.RunWorkerAsync();
						}
						else
						{
							Report(Resource.Canceled);
							if (autoClose)
								AutoCloseWindow();
						}
						break;

					case "server_failed":
						Report(Resource.ServerFailed);
						break;

					case "server_done":
						Report(Resource.ServerDone);
						if (autoClose) AutoCloseWindow();
						break;

					default:
						Report(e.Result.ToString());
						break;
				}
			};
			bgw.RunWorkerAsync();
		}
	}
}
