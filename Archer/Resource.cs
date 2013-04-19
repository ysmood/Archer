using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Archer
{
	public class Resource
	{
		/// <summary>
		/// Mainly about strings that used in UI.
		/// </summary>
		public Resource()
		{
			InitFont();
		}

		private void InitFont()
		{
			bool isWin7 = (Environment.OSVersion.Version.Major > 6)
				|| (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 1);
			if (isWin7) return;

			string safeFontName = "SimSun";
			string DefaultFontFaceName = (string)Microsoft.Win32.Registry.GetValue(
				@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\GRE_Initialize",
				"GUIFont.Facename",
				safeFontName
			);

			MainFont = new System.Drawing.Font(DefaultFontFaceName, 12, FontStyle.Regular, GraphicsUnit.Pixel);
		}

		#region Font

		/// <summary>
		/// Default font for window. Consola is a sans mono font for programer.
		/// I am trying to find a alternative to consola, since it is a none-free product.
		/// </summary>
		public static Font MainFont = ys.Common.GetEmbededFont("Archer.Others.consola.ttf");
		public static Font CodeFont = ys.Common.GetEmbededFont("Archer.Others.consola.ttf", 13);
//		public static Font MainFont = ys.Common.GetEmbededFont("Archer.Others.DejaVuSansMono.ttf");
//		public static Font MainFont = ys.Common.GetEmbededFont("Archer.Others.Inconsolata.ttf");
//		public static Font MainFont = ys.Common.GetEmbededFont("Archer.Others.Inconsolata.ttf",15);

		#endregion

		#region String
		public static string UserData = Directory.GetParent(Application.ExecutablePath) + "\\UserData.xml";

		public static string ArcherHome = "http://ysmood.org/archer";
		public static string ArcherProjectHome = "https://github.com/ysmood/Archer";
		public static string ArcherDeploy = "http://ysmood.org/archer/deploy";
		public static string ArcherSctiptStore = "http://ysmood.org/archer/store";
		public static string ArcherSctiptStore_Share = "http://ysmood.org/archer/store/share";
		public static string ArcherSctiptStore_Delete = "http://ysmood.org/archer/store/delete";
		public static string ArcherOnlineService = "http://ysmood.org/archer/service";
		public static string ArcherRegister = "http://ysmood.org/archer/register";
		public static string ArcherResetPassword = "http://ysmood.org/archer/register/reset";
		public static string ArcherFileUpload = "http://ysmood.org/archer/upload";
		public static string ArcherTemp = Environment.GetEnvironmentVariable("TEMP") + "\\" + "Archer-";


		public static string ShowHide = "Show/Hide Archer";
		public static string ManagerTitle = "Settings";
		public static string ArrowCount = "Arrows: ";
		public static string Repeated = "Name repeated.";
		public static string Null = "Null";
		public static string NoMatchItem = "No match item.";
		public static string HeadOfTable = "No Matched Item before current cell.";
		public static string EndOfTable = "No Matched Item after current cell.";
		public static string Forward = "Forward >";
		public static string Backward = "< Backward";
		public static string CopiedToClipboard = "Copied to clipboard";

		public static string CannotFindFile = "Cannot find the file";
		public static string UnknownType = "Unknown Command Type, please add a type extention to the Name manually.\n\n Such as ";

		public static string Multiline = "Multiline...";
		public static string RunOnStart = "Run on System Startup";
		public static string Open = "Open";
		public static string Help = "Help";
		public static string Exit = "Exit";
		public static string MoveFileComplete = "Move File Complete";

		// Server contact
		public static string Communicating = "Communicating...";
		public static string Downloading = "Downloading...";
		public static string Deleting = "Deleting...";
		public static string Backuping = "Backup...";
		public static string Recovering = "Recovery...";
		public static string AuthenticateError = "User name or password error. Please try again.";
		public static string ServerDone = "Server Done";
		public static string DownloadSucceeded = "Download Succeeded.";
		public static string ServerFailed = "Server Failed.";
		public static string DownloadFailed = "Download Failed.";
		public static string ArrowSafetyWarning = "Safety warning: Allow this website to add arrow to your local storage?";
		public static string Canceled = "Canceled";
		public static string BackupWarning = "Backup:\nThis action will overwrite your remote data, are you sure?";
		public static string RecoveryWarning = "Recovery:\nThis action will overwrite your current data, are you sure?";
		public static string RecoveryDone = "Recovery Done.";
		public static string AutoClose = "Window will be closed after ";
		public static string ChangePasswordError = "Password: Empty or do not match each other.";
		public static string NewerVersionFound = "New version found";
		public static string NewVersionInfo =
@"Click Here to Update to a New Version.
Current Version: {0}
Latest Version : {1}
{2}";
		public static string NoNewerVersion = "No Newer Version Found";


		public static string DeleteArrowConfirm = "Delete arrow(s)?";

		public static string AddNewPath = "Add New Path";
		public static string StrokePropertyTip = "Mouse stroke property:\n ARGB color, stroke width, unit line length(pixel).";

		public static string ChooseFSO = "Missed Path \"{0}\"\nChoose a folder or a file:";

		public static string Exception_FileNotFound = "File not found.";
		public static string Exception_FSONotFound = "File system object not found, try to relocate it?";
		public static string Exception_DocumentNotReady = "Document Not Ready, please wait a second.";
		public static string Exception_NoCurrentArrow = "No arrow is selected.";
		public static string Exception_OnlyOneInstance = "Only allow one Archer instance.";
		public static string Exception_CannotSaveSettings = "Cannot save settings, please insure that you have the authority to access files in this directory.";
		public static string Exception_IllegalInitValue = "Encounter illegal Settings. Archer will startup with default Settings.";
		public static string Exception_EditorOpen = "Can't open the file, please check the Editor path and the user data file.";
		public static string Exception_NoRowSelected = "Please at least selecte one row.";
		public static string Exception_BrowserNotFound = "Cannot find the browser by the default browser path, please check your seting.";
		public static string Exception_HotKeyFailed = "Statement illegal or the hotkey may have been registered by Archer or local system.";
		public static string Exception_DownloadFailed = "Download Failed.";
		public static string Exception_CannotSaveFile = "Cannot save the file, please insure that you have the authority to access files in this directory.";
		public static string Exception_NoHotKey = "Please set a hotkey first.";
		public static string Exception_WhiteSpaceNotAllowed = "Cannot contain white space in this statement.";
		public static string Exception_StrokeFailed = "Stroke statement illegal, please check your syntax.";
		public static string Exception_InternalFunctionNotExists = "Internal function not exists: ";
		public static string Exception_DecryptFailed = "Decrypt failed, please check your password.";

		public string InternalType_Tip =
@"f : file or folder
u : url link
t : text via selection
c : copy and paste Cmd and Arg
s : stroke of hardware inputs
i : internal function
c#: c# script";

		public string[] InternalType = { "f", "u", "t", "c", "s", "i", "c#" };

		public string DefaultLocalBrowser
		{
			get
			{
				string path = string.Empty;
				string userChoice = string.Empty;
				try
				{
					userChoice = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice", false).GetValue("Progid").ToString();
				}
				catch (Exception)
				{
				}
				if (userChoice.ToUpper() == "IE.HTTP")
					path = "iexplore.exe";
				else
					path = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command", false).GetValue("").ToString();
				return ys.Common.GetArgs(path)[0];
			}
		}
		#endregion

		#region Code Stream

		public static string CreateAutoStartShortcut =
@"set f = createObject(""wscript.shell"").createShortcut(""{0}"") 
with f 
	.TargetPath = ""{1}"" 
	.hotKey = ""Alt+F1"" 
	.WorkingDirectory = ""{2}"" 
	.save() 
end with";

		public static string SelfUpdate =
@"WScript.Sleep 300
set args = WScript.Arguments
set fso = CreateObject(""Scripting.FileSystemObject"")
set ws = createObject(""wscript.shell"")
temp = args(0)
zipFile = args(1)
extractTo = args(2)

Main

sub Main
	on error resume next
	
	set shell = CreateObject(""Shell.Application"")
	set itemsInZip = shell.NameSpace(zipFile).Items
	
	fso.CreateFolder temp
	shell.NameSpace(temp).CopyHere(itemsInZip)

	maxTimeOut = 10
	do
		fso.CopyFolder temp & ""\*"", extractTo, true
		fso.CopyFile temp & ""\*"", extractTo, true
		
		if Err.Number = 70 then	' If Archer is still running, loop.
			if maxTimeOut = 0 then
				msgbox ""Self update failed, please update Archer manually.""
				ws.run ""http://ysmood.org/archerd""
				ClearTempFile
				exit sub
			else
				maxTimeOut = maxTimeOut - 1
			end if
			
			WScript.Sleep 1000
			Err.Clear
		else
			exit do
		end if
	loop
	
	ClearTempFile
	ws.run chr(34) & extractTo & ""\Archer.exe"" & chr(34)
end sub

sub ClearTempFile
	fso.GetFile(zipFile).Delete
	fso.GetFolder(temp).Delete
	fso.getFile(WScript.ScriptFullName).Delete
end sub";

		public static string CSharpDefaultCode = 
@"#region
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CSharpExecutor
{
	public class Executor
	{
		public string Execute(string[] args)
		{
			object re=null;
#endregion

//Insert your code here

#region
			if (re!=null) return re.ToString(); else return null;
		}
	}
}
#endregion";

		#endregion

		#region Assembly Information
		public string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion
	}
}
