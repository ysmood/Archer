using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace ys
{
	public partial class Common
	{
		#region Get IE cache fileName fullCmd by url

		[DllImport("Wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern Boolean GetUrlCacheEntryInfo(String lpxaUrlName, IntPtr lpCacheEntryInfo, ref int lpdwCacheEntryInfoBufferSize);

		private const int ERROR_FILE_NOT_FOUND = 0x2;
		private struct LPINTERNET_CACHE_ENTRY_INFO
		{
			public int dwStructSize;
			IntPtr lpszSourceUrlName;
			public IntPtr lpszLocalFileName;
			int CacheEntryType;
			int dwUseCount;
			int dwHitRate;
			int dwSizeLow;
			int dwSizeHigh;
			System.Runtime.InteropServices.ComTypes.FILETIME LastModifiedTime;
			System.Runtime.InteropServices.ComTypes.FILETIME Expiretime;
			System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
			System.Runtime.InteropServices.ComTypes.FILETIME LastSyncTime;
			IntPtr lpHeaderInfo;
			int dwheaderInfoSize;
			IntPtr lpszFileExtension;
			int dwEemptDelta;
		}

		// 返回 指定URL文件的缓存在本地文件系统中的路径
		public static string GetPathForCachedFile(string fileUrl)
		{
			int cacheEntryInfoBufferSize = 0;
			IntPtr cacheEntryInfoBuffer = IntPtr.Zero;
			int lastError; Boolean result;
			try
			{
				result = GetUrlCacheEntryInfo(fileUrl, IntPtr.Zero, ref cacheEntryInfoBufferSize);
				lastError = Marshal.GetLastWin32Error();
				if (result == false)
				{
					if (lastError == ERROR_FILE_NOT_FOUND) return null;
				}
				cacheEntryInfoBuffer = Marshal.AllocHGlobal(cacheEntryInfoBufferSize);

				result = GetUrlCacheEntryInfo(fileUrl, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSize);
				lastError = Marshal.GetLastWin32Error();
				if (result == true)
				{
					Object strObj = Marshal.PtrToStructure(cacheEntryInfoBuffer, typeof(LPINTERNET_CACHE_ENTRY_INFO));
					LPINTERNET_CACHE_ENTRY_INFO internetCacheEntry = (LPINTERNET_CACHE_ENTRY_INFO)strObj;
					String localFileName = Marshal.PtrToStringAuto(internetCacheEntry.lpszLocalFileName); return localFileName;
				}
				else return null;// fileName not found
			}
			finally
			{
				if (!cacheEntryInfoBuffer.Equals(IntPtr.Zero)) Marshal.FreeHGlobal(cacheEntryInfoBuffer);
			}
		}
		#endregion

		#region Embeded Font

		// Adding a private font (Win2000 and later)
		[DllImport("gdi32.dll", ExactSpelling = true)]
		private static extern IntPtr AddFontMemResourceEx(byte[] pbFont, int cbFont, IntPtr pdv, out uint pcFonts);

		// Cleanup of a private font (Win2000 and later)
		[DllImport("gdi32.dll", ExactSpelling = true)]
		internal static extern bool RemoveFontMemResourceEx(IntPtr fh);

		// Some private holders of font information we are loading
		private static IntPtr m_fh = IntPtr.Zero;
		private static PrivateFontCollection m_pfc = null;

		/////////////////////////////////////
		//
		// The GetEmbededFont procedure takes a size and
		// create a font of that size using the hardcoded
		// from font name it knows about.
		//
		/////////////////////////////////////
		public static Font GetEmbededFont(
			string fontPath,
			float size = 12,
			FontStyle style = FontStyle.Regular,
			GraphicsUnit unit = GraphicsUnit.Pixel)
		{
			Font fnt = null;

			if (null == m_pfc)
			{

				// First load the font as a memory stream
				Stream stmFont = Assembly.GetExecutingAssembly().GetManifestResourceStream(fontPath);

				if (null != stmFont)
				{

					// 
					// GDI+ wants a pointer to memory, GDI wants the memory.
					// We will make them both happy.
					// 

					// First read the font into a buffer
					byte[] rgbyt = new Byte[stmFont.Length];
					stmFont.Read(rgbyt, 0, rgbyt.Length);

					// Then do the unmanaged font (Windows 2000 and later)
					// The reason this works is that GDI+ will create a font object for
					// controls like the RichTextBox and this call will make sure that GDI
					// recognizes the font name, later.
					uint cFonts;
					AddFontMemResourceEx(rgbyt, rgbyt.Length, IntPtr.Zero, out cFonts);

					// Now do the managed font
					IntPtr pbyt = Marshal.AllocCoTaskMem(rgbyt.Length);
					if (null != pbyt)
					{
						Marshal.Copy(rgbyt, 0, pbyt, rgbyt.Length);

						m_pfc = new PrivateFontCollection();
						m_pfc.AddMemoryFont(pbyt, rgbyt.Length);
						Marshal.FreeCoTaskMem(pbyt);
					}
				}
			}

			if (m_pfc.Families.Length > 0)
			{
				// Handy how one of the Font constructors takes a
				// FontFamily object, huh? :-)
				fnt = new Font(m_pfc.Families[0], size, style, unit);
			}

			return fnt;
		}

		#endregion

		#region Windows window api

		public const int WM_QUERYENDSESSION = 0x11;

		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();

		public const int WM_COPYDATA = 0x004A;
		public struct COPYDATASTRUCT
		{
			// 用户定义数据
			public IntPtr dwData;

			// 数据大小
			public int cbData;

			// 指向数据的指针
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
			public string lpData;
		}
		[DllImport("user32.dll", EntryPoint = "SendMessageA")]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, ref COPYDATASTRUCT lParam);

		public delegate bool EnumWindowsProc(int hWnd, int lParam);
		[DllImport("user32.dll")]
		public static extern int EnumWindows(EnumWindowsProc ewp, int lParam);
		[DllImport("user32.dll")]
		public static extern int GetWindowTextLength(int hWnd);
		[DllImport("user32.dll")]
		public static extern int GetWindowText(int hWnd, System.Text.StringBuilder title, int size);

		[DllImport("user32.dll")]
		public static extern int SetForegroundWindow(IntPtr hWnd);

		public static int GW_HWNDNEXT = 2;
		public static int GW_HWNDPREV = 3;
		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindow", SetLastError = true)]
		public static extern IntPtr GetNextWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.U4)] int wFlag);

		public enum WindowState
		{
			SW_HIDE = 0,
			SW_SHOWNORMAL = 1,
			SW_SHOWMINIMIZED = 2,
			SW_SHOWMAXIMIZED = 3,
			SW_SHOWNOACTIVATE = 4,
			SW_SHOW = 5,
			SW_MINIMIZE = 6,
			SW_SHOWMINNOACTIVE = 7,
			SW_SHOWNA = 8,	// Displays the window in its current size and position. This value is similar to SW_SHOW, except that the window is not activated.
			SW_RESTORE = 9,
			SW_SHOWDEFAULT = 10,
			SW_FORCEMINIMIZE = 11,
		}
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, WindowState nCmdShow);
		[DllImport("User32.dll")]
		public static extern bool ShowWindowAsync(IntPtr hWnd, WindowState nCmdShow);
		[DllImport("User32.dll")]
		public static extern bool IsZoomed(IntPtr hwnd);
		[DllImport("user32.dll", EntryPoint = "GetWindowLong")]
		public static extern long GetWindowLong(IntPtr hwnd, int nIndex);
		[DllImport("user32.dll", EntryPoint = "SetWindowLong")]
		public static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);
		[DllImport("user32.dll")]
		public static extern int SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="IpClassName">
		/// The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero. 
		/// If lpClassName points to a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names. 
		/// If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter. 
		/// </param>
		/// <param name="IpWindowName">The window name (the window'path title). If this parameter is NULL, all window names match. </param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

		[DllImport("dwmapi.dll")]
		public static extern IntPtr DwmIsCompositionEnabled(out bool pfEnabled);

		public enum GetWindow_Cmd : uint
		{
			GW_HWNDFIRST = 0,
			GW_HWNDLAST = 1,
			GW_HWNDNEXT = 2,
			GW_HWNDPREV = 3,
			GW_OWNER = 4,
			GW_CHILD = 5,
			GW_ENABLEDPOPUP = 6
		}
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetWindow(IntPtr hWnd, GetWindow_Cmd uCmd);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetClassName(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);
 
		#endregion

		#region Drawing

		[DllImport("User32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
		[DllImport("User32.dll")]
		public static extern void ReleaseDC(IntPtr dc);
		[DllImport("user32.dll")]
		public static extern bool InvalidateRect(IntPtr hwnd, IntPtr lpRect, bool bErase);  

		#endregion

		#region Others

		[DllImport("user32.dll")]
		public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

		public static void SetMouseSpeed(uint speed)
		{
			if (speed > 0 && speed < 21)
			{
				//SPI_SETMOUSESPEED = 0x0071
				//SPIF_SENDCHANGE = 0×2
				SystemParametersInfo(0x0071, 0, speed, 0x2);
			}
		}

		#endregion
	}
}
