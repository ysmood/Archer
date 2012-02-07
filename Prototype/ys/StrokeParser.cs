using System;
using System.Threading;
using System.Windows.Forms;
using ManagedWinapi;
using Archer;

namespace ys
{
	class StrokeParser
	{

		/// <summary>
		/// These commands are only commands that cannot be achieved by keyboard and mosue simulation easily.
		/// It'path better to keep the Stroke Parser clean and flexible, and don't make functions repeated.
		/// </summary>
		public enum CommonCommand
		{
			Min,		// Minimize window. If window is maximized, restore it.
			Max,		// Maximize window. If window is maximized, minimize it.
			Top,		// Make current window top most, or normalize it.
		}

		public static bool SendStrokes(string input, string releaseFunctionKey = "")
		{
			string[] strokes = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var s in strokes)
			{
				switch (s.Substring(0, 1))
				{
					case "~":
						SendStroke(s.Substring(1), StrokeBehavior.Press);
						break;
					case "!":
						SendStroke(s.Substring(1), StrokeBehavior.Release);
						break;
					case "@":
						System.Threading.Thread.Sleep(int.Parse(s.Substring(1)));
						break;
					default:
						if (!RunCommonCommand(s))
							SendStroke(s, StrokeBehavior.PressAndRelease);
						break;
				}
			}
			return true;
		}

		/// <summary>
		/// Both keyboard and mosue have keys, these are their common behavior types.
		/// </summary>
		private enum StrokeBehavior
		{
			Press,
			Release,
			PressAndRelease,
		}

		private static KeyboardKey.DoublePoint ptMouse = new KeyboardKey.DoublePoint() { X = 0, Y = 0 };

		private static void SendStroke(string stroke, StrokeBehavior behavior)
		{
			stroke = stroke.ToLower();

			Keys key = Keys.None;
			switch (stroke)
			{
				case "alt":
					key = Keys.Menu;
					break;
				case "ctrl":
					key = Keys.ControlKey;
					break;
				case "shift":
					key = Keys.ShiftKey;
					break;
				case "win":
					key = Keys.LWin;
					break;
				default:
					int num = 0;
					string code = stroke;
					if (int.TryParse(code, out num))
					{
						code = "d" + num;
					}
					try
					{
						key = (Keys)Enum.Parse(typeof(Keys), code, true);
					}
					catch { }
					break;
			}
			if (key != Keys.None)
			{
				KeyboardKey k = new KeyboardKey(key);
				switch (behavior)
				{
					case StrokeBehavior.Press:
						k.Press();
						break;
					case StrokeBehavior.Release:
						k.Release();
						break;
					case StrokeBehavior.PressAndRelease:
						k.PressAndRelease();
						break;
				}
			}
			else if (stroke.Length >= 2)
			{
				string head = stroke.Substring(0, 2);

				KeyboardKey.MouseAbsolutePos = false;
				switch (head)
				{
					case "mv":
						if (stroke.Contains("%"))
						{
							stroke = stroke.Replace("%", "");
							KeyboardKey.MouseAbsolutePos = true;
						}
						string[] xy = stroke.Substring(2).Trim('(', ')').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
						ptMouse.X = Double.Parse(xy[0]);
						ptMouse.Y = double.Parse(xy[1]);
						if (KeyboardKey.MouseAbsolutePos) { ptMouse.X *= 655.35; ptMouse.Y *= 655.35; }
						KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.Move, ptMouse, 0, 0);
						break;
					case "ml":
						switch (behavior)
						{
							case StrokeBehavior.Press:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.LeftDown, ptMouse, 0, 0);
								break;
							case StrokeBehavior.Release:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.LeftUp, ptMouse, 0, 0);
								break;
							case StrokeBehavior.PressAndRelease:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.LeftDown, ptMouse, 0, 0);
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.LeftUp, ptMouse, 0, 0);
								break;
						}
						break;
					case "mr":
						switch (behavior)
						{
							case StrokeBehavior.Press:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.RightDown, ptMouse, 0, 0);
								break;
							case StrokeBehavior.Release:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.RightUp, ptMouse, 0, 0);
								break;
							case StrokeBehavior.PressAndRelease:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.RightDown, ptMouse, 0, 0);
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.RightUp, ptMouse, 0, 0);
								break;
						}
						break;
					case "mm":
						switch (behavior)
						{
							case StrokeBehavior.Press:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.MiddleDown, ptMouse, 0, 0);
								break;
							case StrokeBehavior.Release:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.MiddleUp, ptMouse, 0, 0);
								break;
							case StrokeBehavior.PressAndRelease:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.MiddleDown, ptMouse, 0, 0);
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.MiddleUp, ptMouse, 0, 0);
								break;
						}
						break;
					case "mw":
						int delta = int.Parse(stroke.Substring(2).Trim('(', ')'));
						KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.Wheel, ptMouse, delta, 0);
						break;
					case "m1":
					case "m2":
						int x = int.Parse(head.Substring(1, 1));
						switch (behavior)
						{
							case StrokeBehavior.Press:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.XDown, ptMouse, x, 0);
								break;
							case StrokeBehavior.Release:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.XUp, ptMouse, x, 0);
								break;
							case StrokeBehavior.PressAndRelease:
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.XDown, ptMouse, x, 0);
								KeyboardKey.InjectMouseEvent(KeyboardKey.MouseFlag.XUp, ptMouse, x, 0);
								break;
						}
						break;

					default:
						throw new Exception(Archer.Resource.Exception_StrokeFailed);
				}
			}
			else
			{
				Core.Report(Archer.Resource.Exception_StrokeFailed);
			}
		}

		private static bool RunCommonCommand(string stroke)
		{
			CommonCommand commandName;
			try
			{
				commandName = (CommonCommand)Enum.Parse(typeof(CommonCommand), stroke, true);
			}
			catch
			{
				return false;
			}

			IntPtr ptr = ys.Win32.GetForegroundWindow();

			switch (commandName)
			{
				case CommonCommand.Min:
					new Thread(new ThreadStart(() =>
							{
								// If window is maximized, restore it.
								if (ys.Win32.IsZoomed(ptr))
									ys.Win32.ShowWindowAsync(ptr, ys.Win32.WindowState.SW_RESTORE);
								else if ((ys.Win32.GetWindowLong(ptr, -16) & 0x00020000) == 0x00020000)
									ys.Win32.ShowWindowAsync(ptr, ys.Win32.WindowState.SW_SHOWMINIMIZED);
							}
						)
					).Start();
					break;

				case CommonCommand.Max:
					new Thread(new ThreadStart(() =>
							{
								if (ys.Win32.IsZoomed(ptr))
									ys.Win32.ShowWindowAsync(ptr, ys.Win32.WindowState.SW_SHOWMINIMIZED);
								else
									ys.Win32.ShowWindowAsync(ptr, Win32.WindowState.SW_SHOWMAXIMIZED);
							}
						)
					).Start();
					break;

				case CommonCommand.Top:
					new Thread(new ThreadStart(() =>
							{
								//int HWND_TOPMOST = -1;
								//int HWND_NOTOPMOST = -2;
								//int WS_EX_TOPMOST = 0x00000008;
								//int GWL_EXSTYLE = -20;
								if ((ys.Win32.GetWindowLong(ptr, -20) & 0x00000008) == 0x00000008)
									ys.Win32.SetWindowPos(ptr, -2, 0, 0, 0, 0, 0x1 | 0x2);
								else
									ys.Win32.SetWindowPos(ptr, -1, 0, 0, 0, 0, 0x1 | 0x2);
							}
						)
					).Start();
					break;

				default:
					return false;
			}
			return true;
		}
	}
}
