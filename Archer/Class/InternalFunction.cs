
//#define TEST


using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using ManagedWinapi;
using System.Net;

namespace Archer
{
	class InternalFunction
	{
		public static bool _RunFunction(string cmds, string args)
		{
			MethodInfo[] ms = typeof(InternalFunction).GetMethods();

			StringReader sr = new StringReader(cmds);
				string cmd = sr.ReadLine();
				cmd_additional = (string.IsNullOrEmpty(args) ? "" : args + "\n") + sr.ReadToEnd();
			sr.Close();

			bool existsInternalFunction = false;

			foreach (var m in ms)
			{
				if (m.IsStatic && m.Name == cmd.Trim())
				{
					try
					{
						object r = m.Invoke(null, null) + "";

						if (r is string && !string.IsNullOrEmpty(r  + ""))
							Clipboard.SetText(r  + "");
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Archer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return false;
					}
					existsInternalFunction = true;
				}
			}
			if (!existsInternalFunction)
			{
				Main.Report(Resource.Exception_InternalFunctionNotExists);
				return false;
			}
			return true;
		}

#if TEST
		public static object _Test()
		{
			
		} 
#endif

		public static object ColorPicker()
		{
			adobe_color_picker_clone_part_1.ColorPicker colorPicker = new adobe_color_picker_clone_part_1.ColorPicker(System.Drawing.Color.Black);
			colorPicker.DrawStyle = adobe_color_picker_clone_part_1.ColorPicker.eDrawStyle.Hue;
			colorPicker.Show();
			return string.Empty;
		}

		public static object Archer_ShowHide()
		{
			Main.Self.ShowHideWindow();
			return null;
		}

		public static object Archer_Settings()
		{
			Main.Self.OpenSettings();
			return null;
		}

		public static object Archer_Close()
		{
			Main.Self.Close();
			return null;
		}

		public static object Archer_Backup()
		{
			string userName;
			string password;

			StringReader sr = new StringReader(cmd_additional);
			userName = sr.ReadLine();
			password = ys.Common.Md5Hash(sr.ReadLine());
			sr.Close();

			ServerContactor sc = new ServerContactor() { AutoPromptPassword = false };
			sc.Show();
			sc.BackupUserData(userName, password);

			return null;
		}

		public static object Archer_Recover()
		{
			string userName;
			string password;

			StringReader sr = new StringReader(cmd_additional);
			userName = sr.ReadLine();
			password = ys.Common.Md5Hash(sr.ReadLine());
			sr.Close();

			ServerContactor sc = new ServerContactor() { AutoPromptPassword = false };
			sc.Show();
			sc.RecoverUserData("Type=Recovery", userName, password);

			return null;
		}

		public static object InjectScript()
		{
			Browser browser = new Browser();

			StringReader sr = new StringReader(cmd_additional);
				browser.Argument = sr.ReadLine();
				browser.AdditionalScript = sr.ReadToEnd();
			sr.Close();

			browser.Show();
			return null;
		}

		public static object InjectScript_jQuery()
		{
			Browser browser = new Browser();
			browser.jQuery = true;

			StringReader sr = new StringReader(cmd_additional);
				browser.Argument = sr.ReadLine();
				browser.AdditionalScript = sr.ReadToEnd();
			sr.Close();

			browser.Show();
			return null;
		}

		public static object GetjQuery()
		{
			return Properties.Resources.jquery;
		}

		public static object OpenTestFile()
		{
			StringReader sr = new StringReader(cmd_additional);
			string[] args = ys.Common.GetArgs(sr.ReadLine());

			if (args == null || args.Length == 0) return null;

			string tempFile = Resource.ArcherTemp + Guid.NewGuid().ToString()
				+ "." + args[0];

			StreamWriter sw = new StreamWriter(tempFile, false, System.Text.Encoding.Default);
			sw.Write(sr.ReadToEnd());
			sw.Close();

			Process pRun = new Process();
			pRun.StartInfo.FileName = ys.Common.GetFileFullPath(args[1]);
			pRun.StartInfo.Arguments = tempFile;
			pRun.Start();

			Main.Setting.OpenFileWithEidtor(tempFile);

			Main.TempFiles.Add(tempFile);
			sr.Close();
			return null;
		}

		public static object ClearAccountCache()
		{
			Main.Setting.UserName = string.Empty;
			Main.Setting.Password = string.Empty;
			Main.Self.Logoff();

			Main.Self.RefreshUI(false);

			Main.Self.SaveUserData();
			return null;
		}

		public static object Upload()
		{

			StringReader sr = new StringReader(cmd_additional);
			string locaFilePath = ys.Common.GetFileFullPath(sr.ReadLine().Trim('"'));
			sr.Close();

			ServerContactor sc = new ServerContactor();
			sc.Show();

			sc.SendFile(Archer.Resource.ArcherFileUpload, locaFilePath, Main.Self.CurrentArrow);

			return null;
		}

		/************ Private Part ****************/

		private static string cmd_additional = "";

	}
}