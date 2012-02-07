using System;
using System.Collections.Generic;
using System.Text;
using ys;
using System.Drawing;

namespace Archer
{
	public class GestureManger
	{
		public GestureManger()
		{
			InitGlobalMouseHook();

			CheckAero();

			if (isAeroEffectOn)
			{
				strokeCanvas = new StrokeCanvas();
				strokeCanvas.Show();
				strokeCanvas.Visible = false;
				gStroke = strokeCanvas.CreateGraphics();
			}
			else
			{
				desktopDC = ys.Common.GetDC(IntPtr.Zero);
				gStroke = Graphics.FromHdc(desktopDC);  
			}

			gStroke.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
		}
		~GestureManger()
		{
			mouseHook.Stop();
		}

		public string StrokeProperty
		{
			get
			{
				if (isAeroEffectOn)
				{
					return "#"
						+ ((int)Math.Round(strokeCanvas.Opacity * 255)).ToString("X")
						+ penStroke.Color.ToArgb().ToString("X").Substring(2) + ","
						+ (int)penStroke.Width + ","
						+ ditherThreshold;
				}
				else
				{
					return "#"
						+ penStroke.Color.ToArgb().ToString("X") + ","
						+ (int)penStroke.Width + ","
						+ ditherThreshold;
				}
			}
			set
			{
				if (isAeroEffectOn)
				{
					try
					{
						string[] props = value.Trim('#').Replace(" ", "").Split(',');
						strokeCanvas.Opacity = Convert.ToInt32(props[0].Substring(0, 2), 16) / 255.0;
						penStroke.Color = Color.FromArgb(Convert.ToInt32(props[0], 16));
						penStroke.Width = int.Parse(props[1]);
						ditherThreshold = int.Parse(props[2]);
					}
					catch (Exception ex)
					{
						Main.Report(ex.Message);
					}
				}
				else
				{
					try
					{
						string[] props = value.Trim('#').Replace(" ", "").Split(',');
						penStroke.Color = Color.FromArgb(Convert.ToInt32(props[0], 16));
						penStroke.Width = int.Parse(props[1]);
						ditherThreshold = int.Parse(props[2]);
					}
					catch (Exception ex)
					{
						Main.Report(ex.Message);
					}
				}
				penStroke.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
			}
		}

		public bool GestureEnabled
		{
			get { return gestureEnabled; }
			set
			{
				gestureEnabled = value;
				if (value)
					mouseHook.Start();
				else
					mouseHook.Stop();
			}
		}

		private bool gestureEnabled = false;
		private ys.GlogbleMouseHook mouseHook;

		// OS that doesn't have Aero effect.
		private IntPtr desktopDC = IntPtr.Zero;

		// OS that has Aero effect.
		private StrokeCanvas strokeCanvas;
		private Graphics gStroke;
		/// <summary>
		/// The DWM has a big effect on the performace of draw graphics by DC.
		/// If it is turned off, the best choice to draw directly on screen is DC.
		/// Else draw on a transparent bg window is better.
		/// </summary>
		private void CheckAero()
		{
			try
			{
				ys.Common.DwmIsCompositionEnabled(out isAeroEffectOn);
			}
			catch
			{
				isAeroEffectOn = false;
			}
		}

		private bool isAeroEffectOn = false;
		private bool showTrace = false;
		private POINT ptAnchor;
		private int ditherThreshold;
		private Pen penStroke = new Pen(Color.Red);
		private POINT ptStart;
		private string lastStoke;
		private string mouseStroke;
		private bool release = true;

		// Init Mouse Control
		private void InitGlobalMouseHook()
		{
			mouseHook = new GlogbleMouseHook();
			mouseHook.OnMouseActivity += new GlogbleMouseHook.MouseActiveHandler(mouseHook_OnMouseActivity);
		}
		private bool mouseHook_OnMouseActivity(object sender, GlogbleMouseHook.MouseMessage wMsg, GlogbleMouseHook.MouseHookStruct lMsg)
		{
			switch (wMsg)
			{
				case GlogbleMouseHook.MouseMessage.RDown:
					if (release) release = false;
					else
					{
						release = true;
						return false;
					}
					showTrace = true;
					mouseStroke = "@";
					lastStoke = string.Empty;
					ptStart = ptAnchor = lMsg.Point;
					return true;

				case GlogbleMouseHook.MouseMessage.Move:
					if (showTrace)
					{
						int dx = lMsg.Point.X - ptAnchor.X;
						int dy = lMsg.Point.Y - ptAnchor.Y;

						if (dx * dx + dy * dy > ditherThreshold * ditherThreshold)
						{
							if (isAeroEffectOn)
							{
								// Prevent the command from affecting the canvas window.
								if (strokeCanvas.IsDisposed
									|| strokeCanvas == null)
								{
									strokeCanvas = new StrokeCanvas();
									strokeCanvas.Show();
									gStroke = strokeCanvas.CreateGraphics();
								}
								if (!strokeCanvas.Visible)
								{
									ys.Common.ShowWindow(strokeCanvas.Handle, Common.WindowState.SW_SHOWNA);
									if (strokeCanvas.WindowState != System.Windows.Forms.FormWindowState.Maximized)
										strokeCanvas.WindowState = System.Windows.Forms.FormWindowState.Maximized;
								}
							}

							gStroke.DrawLine(penStroke, ptAnchor.X, ptAnchor.Y, lMsg.Point.X, lMsg.Point.Y);
							ptAnchor = lMsg.Point;

							string stroke = string.Empty;
							if (dx > Math.Abs(dy) && dx > 0)
								stroke += ">";
							else if (Math.Abs(dx) > Math.Abs(dy) && dx < 0)
								stroke += "<";
							else if (dy > Math.Abs(dx) && dy > 0)
								stroke += "v";
							else if (Math.Abs(dy) > Math.Abs(dx) && dy < 0)
								stroke += "^";

							if (stroke != lastStoke)
								mouseStroke += stroke;

							lastStoke = stroke;
						}
					}
					return false;

				case GlogbleMouseHook.MouseMessage.RUp:
					if (!release)
					{
						showTrace = false;

						// If mouse move little, invoke the default mosue event.
						if (Math.Pow(lMsg.Point.X - ptStart.X, 2) + Math.Pow(lMsg.Point.Y - ptStart.Y, 2) <= ditherThreshold * ditherThreshold)
						{
							ys.StrokeParser.SendStrokes("MR");
						}
						else
						{
							release = true;

							if (isAeroEffectOn)
							{
								// Clear the stroke on screen
								strokeCanvas.Refresh();
								strokeCanvas.Visible = false;
							}
							else
							{
								ys.Common.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
							}
							LaunchArrows();
						}
						return true;
					}
					else
						return false;

				default:
					return false;
			}
		}

		private void LaunchArrows()
		{
			Arrow a = Main.Self.Arrows.Find(m => { return m.HotKey.Replace(" ", "").ToLower() == mouseStroke.ToLower(); });
			if (a != null && a.HotkeyEnabled)
				Main.Self.LaunchArrows(a, null);
		}
	}
}
