#define _debug

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Archer
{
	public class Core
	{
		public Core()
		{
			UserDataSet.CheckAndFix();
			this.httpServer = HttpServer.Instance;
			resource = new Resource();
		}

		public void Start()
		{
			Thread main = new Thread(new ThreadStart(Main));
			main.Start();
		}

		/// <summary>
		/// Global window to report exception. It will be redesigned as an independent UI window in future.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="shutdown"></param>
		/// <param name="mb"></param>
		/// <returns></returns>
		public static DialogResult Report(string s = "", bool shutdown = false, MessageBoxButtons mb = MessageBoxButtons.OK)
		{
			DialogResult re = MessageBox.Show(s, resource.AssemblyProduct, mb, MessageBoxIcon.Warning);
			if (shutdown) System.Diagnostics.Process.GetCurrentProcess().Kill();
			return re;
		}

		private void Main()
		{
			while (true)
			{
				if (httpServer.MessageQueue.Count == 0)
				{
					Thread.Sleep(1);	// listening
					continue;
				}

				Dictionary<string, string> msg = httpServer.MessageQueue.Dequeue() as Dictionary<string, string>;

				LaunchArrows(msg);
			}
		}

		private bool LaunchArrow(UserDataSet.ArrowRow a, string arg = "")
		{
			string extention = ys.Path.GetExtension(a.Name);
			string cmd = a.Cmd;

			// Crypt
			//if (a.Encrypted)
			//{
			//    if (string.IsNullOrEmpty(Main.Setting.Password))
			//    {
			//        Main.Report(Resource.Exception_DecryptFailed);

			//        AccountManager accountWindow = new AccountManager();
			//        accountWindow.Show();
			//        return false;
			//    }
			//    else
			//    {
			//        try
			//        {
			//            cmd = Crypter.AESString.Decrypt(cmd, Main.Setting.Password);
			//            arg = Crypter.AESString.Decrypt(arg, Main.Setting.Password);
			//        }
			//        catch
			//        {
			//            Main.Report(Resource.Exception_DecryptFailed);

			//            AccountManager accountWindow = new AccountManager();
			//            accountWindow.Show();
			//            return false;
			//        }
			//    }
			//}

			if (extention == string.Empty)
			{
				string type = ys.Path.AutoGetType(cmd);
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
					arg = ys.Path.UnfoldEV(arg);
					string arg_origin = arg;
					string startDir = string.Empty;

					string[] cmds = cmd.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
					int exceptionCount = 0;

					foreach (string item in cmds)
					{
						if (item.StartsWith("*")) startDir = item.TrimStart('*');

						cmd = ys.Path.UnfoldEV(item);
						arg = arg_origin;
						ys.Path.InsertArg(ref cmd, ref arg);
						try
						{
							if (!Directory.Exists(cmd)
								&& Directory.Exists(arg))
								ys.Path.Start(arg);
							else
								ys.Path.Start(cmd, arg, startDir);
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
						//Ionic.Utils.FolderBrowserDialogEx ofdEx = new Ionic.Utils.FolderBrowserDialogEx();
						//ofdEx.Description = string.Format(Resource.ChooseFSO, cmd);
						//ofdEx.ShowEditBox = true;
						//ofdEx.ShowFullPathInEditBox = true;
						//ofdEx.ShowNewFolderButton = true;
						//ofdEx.ShowBothFilesAndFolders = true;
						//ofdEx.SelectedPath = ys.Path.GetAvailableParentDir(cmd);
						//if (ofdEx.ShowDialog() == DialogResult.OK)
						//{
						//    a.Cmd += '\n' + ofdEx.SelectedPath;
						//    try
						//    {
						//        ys.Path.Start(ofdEx.SelectedPath, arg);
						//    }
						//    catch (Exception ex)
						//    {
						//        Report(ex.Message);
						//    }
						//    break;
						//}
						//else
						//    return false;
					}
					else
						return false;
					break;
				#endregion

				#region Url
				case "u":
					try
					{
						ys.Path.Start(ys.Path.GetFileFullPath(UserDataSet.SettingDataTable.DefaultBrowser), cmd + arg);
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
						ys.Path.Start(ys.Path.GetFileFullPath(UserDataSet.SettingDataTable.DefaultBrowser), cmd + argument);
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
					//if (!InternalFunction._RunFunction(cmd, arg))
					//    return false;
					break;
				#endregion

				#region UnknownType
				case "":
					Report(Resource.UnknownType + "\" " + a.Name + ".f \"");
					return false;
				#endregion

				#region _RunFunction C# script
				case "c#":
					//string[] args = ys.ys.Path.GetArgs(arg);

					//// Get the references: args in list that starts with "!".
					//string[] refs = Array.FindAll(args, m => { return m.StartsWith("!"); });
					//for (int i = 0; i < refs.Length; i++)
					//{
					//    refs[i] = refs[i].TrimStart('!');
					//}

					//try
					//{
					//    CSharpInterpreter.CSharpInterpreter.RunFromSrc(cmd, refs, args);
					//}
					//catch (Exception ex)
					//{
					//    Report(ex.Message);
					//}
					break;
				#endregion

				#region _RunFunction registered script
				default:
					//try
					//{
					//    TempFiles.Add(ys.Path.RunTempScript(cmd, extention, arg));
					//}
					//catch (Exception ex)
					//{
					//    Report(ex.Message);
					//    return false;
					//}
					break;
				#endregion
			}
		CountOnce:
			a.Count++;

			return true;
		}

		private void LaunchArrows(Dictionary<string, string> msg)
		{
#if _debug
			DateTime time = DateTime.Now;
#endif
			UserDataSetTableAdapters.ArrowTableAdapter ad = new UserDataSetTableAdapters.ArrowTableAdapter();

			UserDataSet.ArrowDataTable dt = ad.GetData(
				"select * from [Arrow] where [Name] = @Name or [Name] like @Names",
				new Dictionary<string, object> {
					{ "@Name", msg["Name"] },
					{ "@Names", msg["Name"] + ".%" }
				}
			);

			// this method is slower than above
			//var dt = ad.GetData();
			//var row = (from r in dt
			//          where r.Name == msg[dt.NameColumn.ColumnName]
			//          select r).First();

			if (dt.Count == 1)
			{
				LaunchArrow(dt[0], msg["Arg"]);
			}
			else
			{
				foreach (var row in dt)
				{
					LaunchArrow(row);
				}
			}

			ad.Update(dt);
#if _debug
			Console.WriteLine(msg["Name"]);
			Console.WriteLine(msg["Arg"]);
			Console.WriteLine("time: " + DateTime.Now.Subtract(time).TotalMilliseconds + "\r\n");
#endif
		}

		private void ShowHideWindow(bool show)
		{

		}

		private readonly HttpServer httpServer;
		private static Resource resource;
	}
}
