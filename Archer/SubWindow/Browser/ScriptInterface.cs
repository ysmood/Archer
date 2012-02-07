using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Archer
{
	[System.Runtime.InteropServices.ComVisible(true)]
	public class ScriptInterface
	{
		public ScriptInterface(Browser browser)
		{
			this.browser = browser;
		}

		public bool save_cache(string from, string to = "", bool overwirte = false)
		{
			try
			{
				string path = ys.Common.GetPathForCachedFile(from);

				try
				{
					File.Copy(path, to, overwirte);
				}
				catch
				{
					FileInfo info = new FileInfo(path);
					try
					{
						File.Copy(path, to.TrimEnd('\\') + "\\" + info.Name, overwirte);
					}
					catch
					{
						try
						{
							string dir = to.Remove(to.LastIndexOf('\\'));
							Directory.CreateDirectory(dir);
							if (dir == to.TrimEnd('\\'))
								File.Copy(path, dir + "\\" + info.Name, overwirte);
							else
								File.Copy(path, dir + "\\" + new FileInfo(to).Name, overwirte);
						}
						catch (Exception ex)
						{
							Main.Report(ex.Message);
						}
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				Main.Report(ex.Message);
				return false;
			}
		}

		public bool run(string path)
		{
			try
			{
				ys.Common.Start(path);
				return true;
			}
			catch (Exception ex)
			{
				Main.Report(ex.Message);
				return false;
			}
		}

		public string hash(string s)
		{
			try
			{
				return ys.Common.Md5Hash(s);
			}
			catch (Exception ex)
			{
				Main.Report(ex.Message);
				return null;
			}
		}

		public object js(string code)
		{
			if (jsHost == null)
				jsHost = new MSScriptControl.ScriptControl() { Language = "jscript" };
			return jsHost.Eval(code);
		}

		public object vbs(string code)
		{
			if (vbsHost == null)
				vbsHost = new MSScriptControl.ScriptControl() { Language = "vbscript" };
			return vbsHost.Eval(code);
		}

		public bool echo(string output, bool topMost = false)
		{
			browser.ShowOutput(output, topMost);
			return true;
		}

		public string title
		{
			get { return browser.Text; }
			set
			{
				browser.Text = value;
			}
		}

		public string archer
		{
			get { return Main.Self.Text; }
		}

		public bool add_arrow(string name, string cmd, string arg, string tag,
			string hotkey, string enabled,string encrypted, string timestamp, string guid)
		{
			// First check safety, the script in an arrow may attack user'path computer.
			string report = Resource.ArrowSafetyWarning + "\n>> Name : " + name + "\n>> Tag : " + tag;
			if (Main.Report(report, false, MessageBoxButtons.YesNo)
				== DialogResult.Yes)
			{
				Arrow a = new Arrow()
				{
					Name = name,
					Cmd = cmd,
					Arg = arg,
					Tag = tag,
					HotKey = hotkey,
					HotkeyEnabled = bool.Parse(enabled),
					Encrypted = encrypted,
					Timestamp = timestamp,
					GUID = guid,
				};
				Main.Self.Arrows.Add(a);
				return true;
			}
			else
				return false;
		}

		public bool del_arrow(string guid, string date)
		{
			ServerContactor delArrow = new ServerContactor();
			delArrow.Show();
			delArrow.DeleteArrow(guid, date);

			browser.Refresh();
			
			return true;
		}

		public bool refresh_archer()
		{
			Main.Self.UpdateTextInfo();
			return true;
		}

		public bool resize(int width, int height)
		{
			browser.WindowState = FormWindowState.Normal;
			browser.Width = width;
			browser.Height = height;
			return true;
		}

		private Browser browser;
		private MSScriptControl.ScriptControl jsHost;
		private MSScriptControl.ScriptControl vbsHost;
	}
}
