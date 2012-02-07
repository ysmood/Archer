using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;
using System.Collections.Generic;

namespace ys
{
	public static class IconManager
	{

		#region DllImports

		struct SHFILEINFO
		{
			/// <summary> 
			/// Handle to the icon that represents the fileName. You are responsible for 
			/// destroying this handle with DestroyIcon when you no longer need it.  
			/// </summary> 
			public IntPtr hIcon;

			/// <summary> 
			/// Index of the icon image within the system image list. 
			/// </summary> 
			public IntPtr iIcon;

			/// <summary> 
			/// Array of values that indicates the attributes of the fileName object. 
			/// For information about these values, see the IShellFolder::GetAttributesOf 
			/// method. 
			/// </summary> 
			public uint dwAttributes;

			/// <summary> 
			/// String that contains the name of the fileName as it appears in the Microsoft 
			/// Windows Shell, or the path and fileName name of the fileName that contains the 
			/// icon representing the fileName. 
			/// </summary> 
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;

			/// <summary> 
			/// String that describes the type of fileName. 
			/// </summary> 
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		};

		[Flags]
		enum FileInfoFlags : int
		{
			/// <summary> 
			/// Retrieve the handle to the icon that represents the fileName and the index  
			/// of the icon within the system image list. The handle is copied to the  
			/// hIcon member of the structure specified by psfi, and the index is copied  
			/// to the iIcon member. 
			/// </summary> 
			SHGFI_ICON = 0x000000100,
			/// <summary> 
			/// Indicates that the function should not attempt to access the fileName  
			/// specified by pszPath. Rather, it should act as if the fileName specified by  
			/// pszPath exists with the fileName attributes passed in dwFileAttributes. 
			/// </summary> 
			SHGFI_USEFILEATTRIBUTES = 0x000000010
		}

		[DllImport("Shell32", CharSet = CharSet.Auto)]
		extern static IntPtr SHGetFileInfo(
			string pszPath,
			int dwFileAttributes,
			out SHFILEINFO psfi,
			int cbFileInfo,
			FileInfoFlags uFlags);

		#endregion

		/// <summary> 
		/// Two constants extracted from the FileInfoFlags, the only that are 
		/// meaningfull for the user of this class. 
		/// </summary> 
		public enum SystemIconSize : int
		{
			Large = 0x000000000,
			Small = 0x000000001
		}


		public static Icon IconFromExtensionShell(string extension, SystemIconSize size)
		{
			//add '.' if nessesry 
			if (extension[0] != '.') extension = '.' + extension;

			//temp struct for getting fileName shell info 
			SHFILEINFO fileInfo = new SHFILEINFO();

			SHGetFileInfo(
				extension,
				0,
				out fileInfo,
				Marshal.SizeOf(fileInfo),
				FileInfoFlags.SHGFI_ICON | FileInfoFlags.SHGFI_USEFILEATTRIBUTES | (FileInfoFlags)size);

			return Icon.FromHandle(fileInfo.hIcon);
		}
	}
}