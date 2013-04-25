using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Archer
{
	/// <summary>
	/// Seetings about Archer.
	/// </summary>
	public class Setting
	{
		/// <summary>
		/// sdhfksh
		/// </summary>
		public string DefaultBrowser { get; set; }
		public string DefaultEditor { get; set; }
		public string StrokeProperty { get; set; }
		public string NotifyIcon
		{
			get
			{
				if (Main.Self.notifyIcon != null)
					return Main.Self.notifyIcon.Visible.ToString();
				else
					return true.ToString();
			}
			set
			{
				Main.Self.notifyIcon.Visible = Convert.ToBoolean(value);
			}
		}
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Cookie { get; set; }
		public string CSRF { get; set; }

		public void OpenFileWithEidtor(string filePath)
		{
			string editorPath = ys.Common.GetFileFullPath(DefaultEditor);
			if (File.Exists(editorPath))
				ys.Common.Start(editorPath, filePath);
			else
				Main.Report(Archer.Resource.Exception_EditorOpen);
		}
	}
}
