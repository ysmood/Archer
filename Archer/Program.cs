using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace Archer
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			bool create;
			using (Mutex mu = new Mutex(true, Application.ProductName, out create))
			{
				if (create)
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);

					if (ys.Common.HaveAuthorityRight()) Application.Run(new Main());
				}
				// Only allow one Archer instance.
				// Active the opened Archer.
				// Not a safe way, but in this method only takes one line.
				else
				{
					IntPtr PreWindow = ys.Common.FindWindow(null, File.ReadAllText(Archer.Resource.ArcherTemp));

					ys.Common.COPYDATASTRUCT data = new ys.Common.COPYDATASTRUCT()
					{
						dwData = (IntPtr)100,
						cbData = System.Text.Encoding.Default.GetBytes(System.Environment.CommandLine).Length + 1,
						lpData = System.Environment.CommandLine
					};
					ys.Common.SendMessage(PreWindow, ys.Common.WM_COPYDATA, 0, ref data);
				}
			}
		}
	}
}
