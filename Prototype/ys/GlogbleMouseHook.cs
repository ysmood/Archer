using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ys
{
	public class GlogbleMouseHook
	{
		public event MouseActiveHandler OnMouseActivity;
		public delegate bool MouseActiveHandler(object sender, MouseMessage wMsg, MouseHookStruct lMsg);
		public delegate int GlobalHookProc(int nCode, Int32 wParam, IntPtr lParam);

		public void Start()
		{
			// install Mouse hook 
			if (hMouseHook == 0)
			{
				// Create an instance of HookProc.
				MouseHookProcedure = new GlobalHookProc(MouseHookProc);

				hMouseHook = SetWindowsHookEx(
						14, // WH_MOUSE_LL, monitors low-level mouse input events
						MouseHookProcedure,
						Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),
						0
					);

				//If SetWindowsHookEx fails.
				if (hMouseHook == 0)
				{
					Stop();
                    throw new Exception("SetWindowsHookEx failed. Please uncheck the \"Enable the Visual Studio hosting process\" in project property.");
				}
			} 
		}

		public void Stop()
		{
			bool retMouse = true;
			if (hMouseHook != 0)
			{
				retMouse = UnhookWindowsHookEx(hMouseHook);
				hMouseHook = 0;
			}
			//If UnhookWindowsHookEx fails.
			if (!retMouse) throw new Exception("UnhookWindowsHookEx failed.");
		}

		private int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
		{
			bool handled = false;
			// if ok and someone listens to our events
			if ((nCode >= 0) && (OnMouseActivity != null))
			{
				MouseHookStruct mouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
				handled = OnMouseActivity(this, (MouseMessage)wParam, mouseHookStruct);
			}
			if (handled)
				return 1;
			else
				return CallNextHookEx(hMouseHook, nCode, wParam, lParam);
		}

		//Import for SetWindowsHookEx function.
		//Use this function to install a hook.
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern int SetWindowsHookEx(int idHook, GlobalHookProc lpfn,
			IntPtr hInstance, int threadId);

		//Import for UnhookWindowsHookEx.
		//Call this function to uninstall the hook.
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern bool UnhookWindowsHookEx(int idHook);

		//Import for CallNextHookEx.
		//Use this function to pass the hook information to next hook procedure in chain.
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern int CallNextHookEx(int idHook, int nCode,
			Int32 wParam, IntPtr lParam);

		[StructLayout(LayoutKind.Sequential)]
		public struct MouseHookStruct
		{
			/// <summary>
			/// Specifies a POINT structure that contains the x- and y-coordinates of the cursor, in screen coordinates.
			/// </summary>
			public POINT Point;

			public UInt32 MouseData;
			public UInt32 Flags;
			public UInt32 Time;
			public UInt32 ExtraInfo;
		}

		public enum MouseMessage : int
		{
			Move = 0x200,
			LDown = 0x201,
			RDown = 0x204,
			MDown = 0x207,
			LUp = 0x202,
			RUp = 0x205,
			MUp = 0x208,
			LDoubleClick = 0x203,
			RDoubleClick = 0x206,
			MDoubleClick = 0x209,
		}

		static int hMouseHook = 0;			//Declare mouse hook handle as int.
		GlobalHookProc MouseHookProcedure;		//Declare MouseHookProcedure as HookProc type.
	}

	public struct POINT	// Integer value, the WPF Point contains double float value.
	{
		public int X;
		public int Y;
	}
}
