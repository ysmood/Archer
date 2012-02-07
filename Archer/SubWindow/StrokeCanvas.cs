using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Archer
{
	public partial class StrokeCanvas : Form
	{
		public StrokeCanvas()
		{
			InitializeComponent();

			// The TransparentKey and BackColor can only be Grey.
			// Because when Opacity is below 1, the Stroke color will be mixed with the
			// BackColor before painted to the control.
			this.BackColor = Color.White;
			this.TransparencyKey = this.BackColor;

			// Prevent the window capture the mosue focus, and flashing.
			const int GWL_EXSTYLE = -20;
			const int WS_EX_TRANSPARENT = 0x20;
			const int WS_EX_LAYERED = 0x80000;
			ys.Common.SetWindowLong(Handle, -20, ys.Common.GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED);
		}

		private void StrokeCanvas_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
		}
	}
}
