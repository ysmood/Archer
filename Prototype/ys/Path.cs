using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace ys
{
	class Path
	{
		private class QueueChar : Queue<char>
		{
			public new String ToString()
			{
				return new string(this.ToArray());
			}
		}
		/// <summary>
		/// Parse command line arguments and return a string list.
		/// </summary>
		/// <param name="input">Raw input</param>
		/// <param name="removeEmpty">Remove empty item.</param>
		/// <param name="index">The position in the array where copying is to begin.</param>
		/// <returns></returns>
		public static String[] GetArgs(string input, bool removeEmpty = true, int index = 0)
		{
			const char quotSymbol = '"';
			const char spaceSymbol = ' ';
			const char tabSymbol = '\t';

			List<string> list = new List<string>();
			Stack<char> quot = new Stack<char>();
			QueueChar arg = new QueueChar();

			foreach (char i in input)
			{
				switch (i)
				{
					case quotSymbol:
						switch (quot.Count)
						{
							case 0:
							case 1:
								quot.Push(i);
								break;

							case 2:	// used to eacape qout
								arg.Enqueue(quot.Pop());
								break;
						}
						break;

					case spaceSymbol:
					case tabSymbol:
						switch (quot.Count)
						{
							case 0:
								list.Add(arg.ToString());
								arg.Clear();
								break;

							case 1:
								arg.Enqueue(i);
								break;

							case 2:
								list.Add(arg.ToString());
								arg.Clear();
								quot.Clear();
								break;
						}
						break;

					default:
						switch (quot.Count)
						{
							case 0:
							case 1:
								arg.Enqueue(i);
								break;

							case 2:
								list.Add(arg.ToString());
								arg.Enqueue(i);
								break;
						}
						break;
				}
			}

			if (arg.Count > 0)
			{
				list.Add(arg.ToString());
			}

			list.RemoveRange(0, index);

			if (removeEmpty)
				list.RemoveAll((m) => { return m == ""; });

			return list.ToArray();
		}

		private static Regex regEnvironmentVariable = new Regex(@"%.+%", RegexOptions.Compiled);
		public static string UnfoldEV(string s)
		{
			if (s.IndexOf('\n') >= 0) return s;

			if (Directory.Exists(s))
				s = new DirectoryInfo(s).FullName;

			return regEnvironmentVariable.Replace(s, (m) =>
			{
				return Environment.GetEnvironmentVariable(m.Value.Replace("%", ""));
			});
		}

		public static void InsertArg(ref string cmd, ref string arg, bool urlEncode = false)
		{
			string[] args = GetArgs(arg.Trim());
			cmd = cmd.Trim();
			string temp;
			Regex r;

			// Syntax: <name default/>
			r = new Regex(@"< (?<name>[^\<|^/|^\>|^\s]*)    (  ( \s+(?<default>[^\<|^/|^\>]+) ) | (?<default>\s*)  )/>",
					RegexOptions.IgnorePatternWhitespace);
			cmd = r.Replace(cmd,
				m =>
				{
					return "<" + m.Groups["default"].Value + "/>";
				}
			);

			for (int i = 0; i < args.Length; i++)
			{
				r = new Regex(@"<([^\<|^/|^\>]*)/>");
				if (urlEncode)
					temp = r.Replace(cmd, Uri.EscapeDataString(args[i]), 1);
				else
					temp = r.Replace(cmd, args[i], 1);
				if (cmd != temp)
				{
					cmd = temp;
					arg = arg.Replace(args[i], "");
				}
			}
			cmd = r.Replace(cmd, m => { return m.Groups["name"].Value; });

			// Remove empty quotes.
			arg = arg.Replace("\"\"", "");

			if (urlEncode)
				arg = Uri.EscapeDataString(arg.Trim());
		}

		public static string GetExtension(string name)
		{
			if (string.IsNullOrEmpty(name))
				return string.Empty;
			int index = name.LastIndexOf('.');
			if (index >= 0 && index < name.Length - 1)
			{
				return name.Substring(index + 1);
			}
			else
				return string.Empty;
		}

		public static string GetAvailableParentDir(string path)
		{
			int index = path.LastIndexOf('\\');
			if (index < 0)
				return string.Empty;

			string upOneLevel = path.Remove(index);
			if (Directory.Exists(upOneLevel))
				return upOneLevel;
			else
				return GetAvailableParentDir(upOneLevel);
		}

		public static void RemoveSame(ref List<string> list)
		{
			for (int i = 0; i < list.Count; i++)
				for (int j = i + 1; j < list.Count; j++)
					if (list[i] == list[j])
					{
						list.RemoveAt(j);
						i = 0;
						break;
					}
		}

		/// <summary>
		/// Remove the extension of the name, and return the rest part.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="firstDot">Only to get the string before first dot</param>
		/// <returns></returns>
		public static string GetPreName(string name, bool firstDot = false)
		{
			if (name == null) return string.Empty;

			int index;
			if (firstDot)
				index = name.IndexOf('.');
			else
				index = name.LastIndexOf('.');
			if (index >= 0)
			{
				return name.Remove(index);
			}
			else
				return name;
		}

		public static string AutoGetType(string cmd)
		{
			if (string.IsNullOrEmpty(cmd))
				return string.Empty;

			cmd = cmd.Trim('\"', ' ');

			if (!cmd.Contains("\n"))
			{
				if (Directory.Exists(UnfoldEV(cmd))
					|| File.Exists(GetFileFullPath(cmd)))
				{
					return "f";
				}

				if (IsUrl(cmd))
				{
					return "u";
				}

				if (cmd.StartsWith("@")
					|| cmd.StartsWith("~"))
				{
					return "s";
				}
			}

			if (cmd.Contains("<html>")) return "html";
			if (cmd.Contains("<?php")) return "php";
			if (cmd.Contains("var")) return "js";
			if (cmd.Contains("dim")) return "vbs";
			if (cmd.Contains("set")) return "bat";
			if (cmd.Contains("elif")) return "python";

			return string.Empty;
		}

		public static string GetFileFullPath(string fileName)
		{
			try
			{
				string fileNameEx = UnfoldEV(fileName.Trim('\"', '\n'));
				if (GetExtension(fileNameEx) == string.Empty)
					fileNameEx = fileNameEx + ".exe";
				if (File.Exists(fileNameEx))
					return System.IO.Path.GetFullPath(fileNameEx);

				// Find in environment variable.
				var values = Environment.GetEnvironmentVariable("PATH");
				try
				{
					foreach (var path in values.Split(';'))
					{
						var fullPath = System.IO.Path.Combine(path, fileNameEx);
						if (File.Exists(fullPath))
							return fullPath;
					}
				}
				catch { }

				// Find in registery.
				string LocalAppPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\";
				RegistryKey key = Registry.LocalMachine.OpenSubKey(LocalAppPath, false);
				string keyName = Array.Find(key.GetSubKeyNames(), m => { return m.ToUpper() == fileNameEx.ToUpper(); });
				return Registry.LocalMachine.OpenSubKey(LocalAppPath + keyName).GetValue(string.Empty).ToString();
			}
			catch (Exception)
			{
				return fileName;
			}
		}

		private static Regex regUpperDir = new Regex(@"(?<UpperDir>.+)[\\/].+", RegexOptions.Compiled);
		public static string GetUpperDir(string path)
		{
			path = path.Trim('"').TrimEnd('\\');
			return regUpperDir.Match(path).Groups["UpperDir"].Value;
		}

		private static Regex regIsUrl = new Regex(@"^(http|ftp|www).+", RegexOptions.Compiled);
		public static bool IsUrl(string url)
		{
			try
			{
				new Uri(url);
			}
			catch
			{
				return false;
			}

			if (url.Contains("\n"))
				return false;
			else if (regIsUrl.IsMatch(url))
				return true;
			else
			{
				regIsUrl = new Regex(@"(.+\.com)|(.+\.cn)|(.+\.net)|(.+\.org)|(.+\.edu)");
				if (regIsUrl.IsMatch(url))
					return true;
				else
					return false;
			}
		}

		public static string Md5Hash(string input)
		{
			System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();

			byte[] data = md5Hasher.ComputeHash(System.Text.Encoding.Default.GetBytes(input + ""));

			System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();

			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}
			return sBuilder.ToString();
		}

		public static void Start(string path, string args = "", string startDir = null)
		{
			if (string.IsNullOrEmpty(startDir))
			{
				startDir = GetUpperDir(path);

				if (string.IsNullOrEmpty(startDir))
				{
					startDir = Environment.GetFolderPath(Environment.SpecialFolder.System);
				}
			}
			using (Process p = new Process())
			{
				p.StartInfo.Arguments = args;
				p.StartInfo.WorkingDirectory = startDir;
				p.StartInfo.FileName = path;
				p.Start();
			}
		}
	}
}
