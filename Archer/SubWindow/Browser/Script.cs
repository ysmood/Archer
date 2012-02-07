using System;
using System.IO;
using System.Net;

namespace Archer
{
	public class Script
	{
		public Script(string path)
		{
			if (path.Contains("?"))
			{
				path = path.Replace("?", "");
				AutoRun = false;
			}

			string fileName = path.Substring(path.LastIndexOf('\\') + 1);
			if (string.IsNullOrEmpty(fileName))
				fileName = path.Substring(path.LastIndexOf('/') + 1);

			FilePath = path;
			FileName = fileName;
		}

		public bool AutoRun = true;
		public string FilePath;
		public string FileName;
		public string Code
		{
			get
			{
				if (!File.Exists(FilePath))
				{
					if (!File.Exists(tempFile))
					{
						new WebClient().DownloadFile(FilePath, tempFile);
						Main.TempFiles.Add(tempFile);
						FilePath = tempFile;
					}
				}
				StreamReader sr = new StreamReader(FilePath);
				string text = sr.ReadToEnd();
				sr.Close();
				return text;
			}
		}
		private string tempFile = Resource.ArcherTemp
								+ Guid.NewGuid().ToString();
	}

}
