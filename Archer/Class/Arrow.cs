using ys;
using System.Windows.Forms;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Archer
{
	public class Arrow
	{
		public Arrow()
		{
			timestamp = DateTime.Now.ToString("u");
			guid = Guid.NewGuid().ToString();
		}
		public bool HotkeyEnabled
		{
			get
			{
				if (hotkey != null)
					return hotkey.Enabled;
				else
				{
					return hotkeyEnabled;
				}
			}
			set
			{
				if (hotkey != null)
				{
					if (value != hotkey.Enabled)
						try
						{
							hotkey.Enabled = value;
						}
						catch (Exception ex)
						{
							hotkey = null;
							Main.Report(Resource.Exception_HotKeyFailed + "\n\nArrow name: " + this.Name + "\n\nHotkey Statement: " + this.strHotkey + "\n\n" + ex.Message);
							strHotkey = string.Empty;
						}
				}
				hotkeyEnabled = value;
			}
		}

		public string Name
		{
			get { return strName; }
			set { strName = value; }
		}
		public string Cmd
		{
			get { return strCmd; }
			set { strCmd = value.Replace("\r\n", "\n").Replace("\n", "\r\n"); }
		}
		public string Arg
		{
			get { return strArg; }
			set { strArg = value; }
		}
		public string Tag
		{
			get { return strTag; }
			set { strTag = value; }
		}
		public string HotKey
		{
			get
			{
				return strHotkey;
			}
			set
			{
				// Prevent register repeatly.
				if (strHotkey.Replace(" ", "") == value.Replace(" ", "")) 
					return;
				else if (value.StartsWith("@"))
				{
					strHotkey = value;
					return;
				}
				else
					strHotkey = value;

				if (string.IsNullOrEmpty(value))
					return;

				// Auto format the statement
				string[] keyItems = strHotkey.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				
				// Start to parse and register hotkey.
				HotkeyEnabled = false;
				hotkey = new ManagedWinapi.Hotkey();
				hotkey.HotkeyPressed += (o, e) =>
				{
					Main.Self.LaunchArrows(this, null);
					Main.Self.UpdateTextInfo();
				};
				try
				{

					foreach (var item in keyItems)
					{
						switch (item)
						{
							case "alt":
								hotkey.Alt = true;
								break;
							case "ctrl":
								hotkey.Ctrl = true;
								break;
							case "shift":
								hotkey.Shift = true;
								break;
							case "win":
								hotkey.WindowsKey = true;
								break;
							default:
								int num = 0;
								string code = item;
								if (int.TryParse(code, out num))
								{
									code = "d" + num;
								}
								hotkey.KeyCode = (Keys)Enum.Parse(typeof(Keys), code, true);
								break;
						}
					}
				}
				catch (Exception ex)
				{
					hotkey = null;
					Main.Report(Resource.Exception_HotKeyFailed + "\n\nArrow name: " + this.Name + "\n\nHotkey Statement: " + this.strHotkey + "\n\n" + ex.Message);
					strHotkey = string.Empty;
				}
			}
		}
		public string Count
		{
			get { return intCount.ToString("00000"); }
			set 
			{
				int numCount = 0;
				int.TryParse(value, out numCount);
				intCount = numCount; 
			}
		}
		/// <summary>
		/// Same as HotkeyEnabled, this was only used in Data input.
		/// </summary>
		public string Enabled
		{
			get { return HotkeyEnabled.ToString(); }
			set { HotkeyEnabled = bool.Parse(value); }
		}
		public string Encrypted
		{
			get { return encrypted.ToString(); }
			set { encrypted = bool.Parse(value); }
		}
		public string Timestamp
		{
			get
			{
				if (string.IsNullOrEmpty(timestamp))
					timestamp = DateTime.Now.ToString("u");
				return timestamp;
			}
			set
			{
				timestamp = value;
			}
		}
		public string GUID
		{
			get
			{
				if (string.IsNullOrEmpty(guid))
					guid = Guid.NewGuid().ToString();
				return guid;
			}
			set
			{
				guid = value;
			}
		}
		public void CountOnce()
		{
			intCount++;
		}

		private string strName = "";
		private string strCmd = "";
		private string strArg = "";
		private string strTag = "";
		private string strHotkey = "";
		private int intCount = 0;
		private bool encrypted = false;
		private string timestamp = "";
		private string guid = "";

		private bool hotkeyEnabled = false;
		private ManagedWinapi.Hotkey hotkey;
	}
}
