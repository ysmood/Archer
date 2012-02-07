/******************************************************************/
/*****                                                        *****/
/*****     Project:           Adobe Color Picker Clone 1      *****/
/*****     Filename:          ColorPicker.cs               *****/
/*****     Original Author:   Danny Blanchard                 *****/
/*****                        - scrabcakes@gmail.com          *****/
/*****     Updates:	                                          *****/
/*****      3/28/2005 - Initial Version : Danny Blanchard     *****/
/*****                                                        *****/
/******************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;

namespace adobe_color_picker_clone_part_1
{
	/// <summary>
	/// Summary description for ColorPicker.
	/// </summary>
	public class ColorPicker : System.Windows.Forms.Form
	{
		#region Class Variables

		private AdobeColors.HSL		m_hsl;
		private Color				m_rgb;
		private AdobeColors.CMYK	m_cmyk;
		private IntPtr hDeviceContext;
		private bool captureScreenOn = false;
		private nPoint ptCurrentMouse = new nPoint();
		private Bitmap bmpCapture = new Bitmap(20, 20);

		public enum eDrawStyle
		{
			Hue,
			Saturation,
			Brightness,
			Red,
			Green,
			Blue
		}


		#endregion

		#region Designer Generated Variables

		private System.Windows.Forms.Button m_cmd_OK;
		private System.Windows.Forms.Button m_cmd_Cancel;
		private System.Windows.Forms.NumericUpDown num_Hue;
		private System.Windows.Forms.NumericUpDown num_Sat;
		private System.Windows.Forms.NumericUpDown num_Black;
		private System.Windows.Forms.NumericUpDown num_Red;
		private System.Windows.Forms.NumericUpDown num_Green;
		private System.Windows.Forms.NumericUpDown num_Blue;
		private System.Windows.Forms.NumericUpDown num_Cyan;
		private System.Windows.Forms.NumericUpDown num_Magenta;
		private System.Windows.Forms.NumericUpDown num_Yellow;
		private System.Windows.Forms.NumericUpDown num_K;
		private System.Windows.Forms.TextBox m_txt_Hex;
		private System.Windows.Forms.RadioButton m_rbtn_Hue;
		private System.Windows.Forms.RadioButton m_rbtn_Sat;
		private System.Windows.Forms.RadioButton m_rbtn_Black;
		private System.Windows.Forms.RadioButton m_rbtn_Red;
		private System.Windows.Forms.RadioButton m_rbtn_Green;
		private System.Windows.Forms.RadioButton m_rbtn_Blue;
		private System.Windows.Forms.Label m_lbl_HexPound;
		private System.Windows.Forms.Label m_lbl_Cyan;
		private System.Windows.Forms.Label m_lbl_Magenta;
		private System.Windows.Forms.Label m_lbl_Yellow;
		private System.Windows.Forms.Label m_lbl_K;
		private System.Windows.Forms.Label m_lbl_Primary_Color;
		private System.Windows.Forms.Label m_lbl_Secondary_Color;
		private VerticalColorSlider m_ctrl_ThinBox;
		private ColorBox m_ctrl_BigBox;
		private System.Windows.Forms.Label m_lbl_Hue_Symbol;
		private System.Windows.Forms.Label m_lbl_Saturation_Symbol;
		private System.Windows.Forms.Label m_lbl_Black_Symbol;
		private System.Windows.Forms.Label m_lbl_Cyan_Symbol;
		private System.Windows.Forms.Label m_lbl_Magenta_Symbol;
		private System.Windows.Forms.Label m_lbl_Yellow_Symbol;
		private Label label1;
		private Label lbCursorPos;
		private PictureBox pbColorWheel;
		private GroupBox groupScreenPicker;
		private ToolTip toolTip;
		private IContainer components;
		private PictureBox pbMagnifier;

		#endregion

//		private IContainer components;

		#region Constructors / Destructors

		public ColorPicker(Color starting_color)
		{
			InitializeComponent();
			this.Font = Archer.Resource.MainFont;

			m_rgb = starting_color;
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			hDeviceContext = GetDC(IntPtr.Zero);

			UpdateUI();

			m_ctrl_BigBox.HSL = m_hsl;
			m_ctrl_ThinBox.HSL = m_hsl;

			m_lbl_Primary_Color.BackColor = starting_color;
			m_lbl_Secondary_Color.BackColor = starting_color;
			
			m_rbtn_Hue.Checked = true;

			this.WriteHexData(m_rgb);
		}


		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				ReleaseDC(IntPtr.Zero, hDeviceContext);

				//if (components != null)
				//{
				//    components.Dispose();
				//}
			}
			base.Dispose( disposing );
		}


		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			adobe_color_picker_clone_part_1.AdobeColors.HSL hsl1 = new adobe_color_picker_clone_part_1.AdobeColors.HSL();
			adobe_color_picker_clone_part_1.AdobeColors.HSL hsl2 = new adobe_color_picker_clone_part_1.AdobeColors.HSL();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPicker));
			this.m_cmd_OK = new System.Windows.Forms.Button();
			this.m_cmd_Cancel = new System.Windows.Forms.Button();
			this.num_Hue = new System.Windows.Forms.NumericUpDown();
			this.num_Sat = new System.Windows.Forms.NumericUpDown();
			this.num_Black = new System.Windows.Forms.NumericUpDown();
			this.num_Red = new System.Windows.Forms.NumericUpDown();
			this.num_Green = new System.Windows.Forms.NumericUpDown();
			this.num_Blue = new System.Windows.Forms.NumericUpDown();
			this.num_Cyan = new System.Windows.Forms.NumericUpDown();
			this.num_Magenta = new System.Windows.Forms.NumericUpDown();
			this.num_Yellow = new System.Windows.Forms.NumericUpDown();
			this.num_K = new System.Windows.Forms.NumericUpDown();
			this.m_txt_Hex = new System.Windows.Forms.TextBox();
			this.m_rbtn_Hue = new System.Windows.Forms.RadioButton();
			this.m_rbtn_Sat = new System.Windows.Forms.RadioButton();
			this.m_rbtn_Black = new System.Windows.Forms.RadioButton();
			this.m_rbtn_Red = new System.Windows.Forms.RadioButton();
			this.m_rbtn_Green = new System.Windows.Forms.RadioButton();
			this.m_rbtn_Blue = new System.Windows.Forms.RadioButton();
			this.m_lbl_HexPound = new System.Windows.Forms.Label();
			this.m_lbl_Cyan = new System.Windows.Forms.Label();
			this.m_lbl_Magenta = new System.Windows.Forms.Label();
			this.m_lbl_Yellow = new System.Windows.Forms.Label();
			this.m_lbl_K = new System.Windows.Forms.Label();
			this.m_lbl_Primary_Color = new System.Windows.Forms.Label();
			this.m_lbl_Secondary_Color = new System.Windows.Forms.Label();
			this.m_lbl_Hue_Symbol = new System.Windows.Forms.Label();
			this.m_lbl_Saturation_Symbol = new System.Windows.Forms.Label();
			this.m_lbl_Black_Symbol = new System.Windows.Forms.Label();
			this.m_lbl_Cyan_Symbol = new System.Windows.Forms.Label();
			this.m_lbl_Magenta_Symbol = new System.Windows.Forms.Label();
			this.m_lbl_Yellow_Symbol = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lbCursorPos = new System.Windows.Forms.Label();
			this.pbColorWheel = new System.Windows.Forms.PictureBox();
			this.pbMagnifier = new System.Windows.Forms.PictureBox();
			this.groupScreenPicker = new System.Windows.Forms.GroupBox();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.m_ctrl_BigBox = new adobe_color_picker_clone_part_1.ColorBox();
			this.m_ctrl_ThinBox = new adobe_color_picker_clone_part_1.VerticalColorSlider();
			((System.ComponentModel.ISupportInitialize)(this.num_Hue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Sat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Black)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Red)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Green)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Blue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Cyan)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Magenta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Yellow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_K)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbColorWheel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbMagnifier)).BeginInit();
			this.groupScreenPicker.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_cmd_OK
			// 
			this.m_cmd_OK.BackColor = System.Drawing.Color.Transparent;
			this.m_cmd_OK.BackgroundImage = global::Archer.Properties.Resources.OK;
			this.m_cmd_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.m_cmd_OK.Location = new System.Drawing.Point(471, 18);
			this.m_cmd_OK.Name = "m_cmd_OK";
			this.m_cmd_OK.Size = new System.Drawing.Size(49, 30);
			this.m_cmd_OK.TabIndex = 4;
			this.m_cmd_OK.UseVisualStyleBackColor = false;
			this.m_cmd_OK.Click += new System.EventHandler(this.m_cmd_OK_Click);
			// 
			// m_cmd_Cancel
			// 
			this.m_cmd_Cancel.BackColor = System.Drawing.Color.Transparent;
			this.m_cmd_Cancel.BackgroundImage = global::Archer.Properties.Resources.Cancel;
			this.m_cmd_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.m_cmd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cmd_Cancel.Location = new System.Drawing.Point(471, 59);
			this.m_cmd_Cancel.Name = "m_cmd_Cancel";
			this.m_cmd_Cancel.Size = new System.Drawing.Size(49, 30);
			this.m_cmd_Cancel.TabIndex = 5;
			this.m_cmd_Cancel.UseVisualStyleBackColor = false;
			this.m_cmd_Cancel.Click += new System.EventHandler(this.m_cmd_Cancel_Click);
			// 
			// num_Hue
			// 
			this.num_Hue.Location = new System.Drawing.Point(371, 110);
			this.num_Hue.Maximum = new decimal(new int[] {
			360,
			0,
			0,
			0});
			this.num_Hue.Name = "num_Hue";
			this.num_Hue.Size = new System.Drawing.Size(42, 20);
			this.num_Hue.TabIndex = 6;
			this.num_Hue.ValueChanged += new System.EventHandler(this.num_Hue_Changed);
			// 
			// num_Sat
			// 
			this.num_Sat.Location = new System.Drawing.Point(371, 137);
			this.num_Sat.Name = "num_Sat";
			this.num_Sat.Size = new System.Drawing.Size(42, 20);
			this.num_Sat.TabIndex = 7;
			this.num_Sat.ValueChanged += new System.EventHandler(this.num_Sat_Changed);
			// 
			// num_Black
			// 
			this.num_Black.Location = new System.Drawing.Point(371, 164);
			this.num_Black.Name = "num_Black";
			this.num_Black.Size = new System.Drawing.Size(42, 20);
			this.num_Black.TabIndex = 8;
			this.num_Black.ValueChanged += new System.EventHandler(this.num_Black_Changed);
			// 
			// num_Red
			// 
			this.num_Red.Location = new System.Drawing.Point(371, 196);
			this.num_Red.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.num_Red.Name = "num_Red";
			this.num_Red.Size = new System.Drawing.Size(42, 20);
			this.num_Red.TabIndex = 9;
			this.num_Red.ValueChanged += new System.EventHandler(this.num_Red_Changed);
			// 
			// num_Green
			// 
			this.num_Green.Location = new System.Drawing.Point(371, 223);
			this.num_Green.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.num_Green.Name = "num_Green";
			this.num_Green.Size = new System.Drawing.Size(42, 20);
			this.num_Green.TabIndex = 10;
			this.num_Green.ValueChanged += new System.EventHandler(this.num_Green_Changed);
			// 
			// num_Blue
			// 
			this.num_Blue.Location = new System.Drawing.Point(371, 250);
			this.num_Blue.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.num_Blue.Name = "num_Blue";
			this.num_Blue.Size = new System.Drawing.Size(42, 20);
			this.num_Blue.TabIndex = 11;
			this.num_Blue.ValueChanged += new System.EventHandler(this.num_Blue_Changed);
			// 
			// num_Cyan
			// 
			this.num_Cyan.Location = new System.Drawing.Point(465, 110);
			this.num_Cyan.Name = "num_Cyan";
			this.num_Cyan.Size = new System.Drawing.Size(42, 20);
			this.num_Cyan.TabIndex = 15;
			this.num_Cyan.ValueChanged += new System.EventHandler(this.num_Cyan_Changed);
			// 
			// num_Magenta
			// 
			this.num_Magenta.Location = new System.Drawing.Point(465, 137);
			this.num_Magenta.Name = "num_Magenta";
			this.num_Magenta.Size = new System.Drawing.Size(42, 20);
			this.num_Magenta.TabIndex = 16;
			this.num_Magenta.ValueChanged += new System.EventHandler(this.num_Magenta_Changed);
			// 
			// num_Yellow
			// 
			this.num_Yellow.Location = new System.Drawing.Point(465, 164);
			this.num_Yellow.Name = "num_Yellow";
			this.num_Yellow.Size = new System.Drawing.Size(42, 20);
			this.num_Yellow.TabIndex = 17;
			this.num_Yellow.ValueChanged += new System.EventHandler(this.num_Yellow_Changed);
			// 
			// num_K
			// 
			this.num_K.Location = new System.Drawing.Point(465, 191);
			this.num_K.Name = "num_K";
			this.num_K.Size = new System.Drawing.Size(42, 20);
			this.num_K.TabIndex = 18;
			this.num_K.ValueChanged += new System.EventHandler(this.num_K_Changed);
			// 
			// m_txt_Hex
			// 
			this.m_txt_Hex.Location = new System.Drawing.Point(447, 250);
			this.m_txt_Hex.MaxLength = 6;
			this.m_txt_Hex.Name = "m_txt_Hex";
			this.m_txt_Hex.Size = new System.Drawing.Size(67, 20);
			this.m_txt_Hex.TabIndex = 19;
			this.m_txt_Hex.Text = "Null";
			this.m_txt_Hex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_txt_Hex.TextChanged += new System.EventHandler(this.m_txt_Hex_Changed);
			// 
			// m_rbtn_Hue
			// 
			this.m_rbtn_Hue.Location = new System.Drawing.Point(327, 107);
			this.m_rbtn_Hue.Name = "m_rbtn_Hue";
			this.m_rbtn_Hue.Size = new System.Drawing.Size(42, 26);
			this.m_rbtn_Hue.TabIndex = 20;
			this.m_rbtn_Hue.Text = "H:";
			this.m_rbtn_Hue.CheckedChanged += new System.EventHandler(this.m_rbtn_Hue_CheckedChanged);
			// 
			// m_rbtn_Sat
			// 
			this.m_rbtn_Sat.Location = new System.Drawing.Point(327, 134);
			this.m_rbtn_Sat.Name = "m_rbtn_Sat";
			this.m_rbtn_Sat.Size = new System.Drawing.Size(42, 26);
			this.m_rbtn_Sat.TabIndex = 21;
			this.m_rbtn_Sat.Text = "S:";
			this.m_rbtn_Sat.CheckedChanged += new System.EventHandler(this.m_rbtn_Sat_CheckedChanged);
			// 
			// m_rbtn_Black
			// 
			this.m_rbtn_Black.Location = new System.Drawing.Point(327, 161);
			this.m_rbtn_Black.Name = "m_rbtn_Black";
			this.m_rbtn_Black.Size = new System.Drawing.Size(42, 26);
			this.m_rbtn_Black.TabIndex = 22;
			this.m_rbtn_Black.Text = "B:";
			this.m_rbtn_Black.CheckedChanged += new System.EventHandler(this.m_rbtn_Black_CheckedChanged);
			// 
			// m_rbtn_Red
			// 
			this.m_rbtn_Red.Location = new System.Drawing.Point(327, 193);
			this.m_rbtn_Red.Name = "m_rbtn_Red";
			this.m_rbtn_Red.Size = new System.Drawing.Size(42, 26);
			this.m_rbtn_Red.TabIndex = 23;
			this.m_rbtn_Red.Text = "R:";
			this.m_rbtn_Red.CheckedChanged += new System.EventHandler(this.m_rbtn_Red_CheckedChanged);
			// 
			// m_rbtn_Green
			// 
			this.m_rbtn_Green.Location = new System.Drawing.Point(327, 220);
			this.m_rbtn_Green.Name = "m_rbtn_Green";
			this.m_rbtn_Green.Size = new System.Drawing.Size(42, 26);
			this.m_rbtn_Green.TabIndex = 24;
			this.m_rbtn_Green.Text = "G:";
			this.m_rbtn_Green.CheckedChanged += new System.EventHandler(this.m_rbtn_Green_CheckedChanged);
			// 
			// m_rbtn_Blue
			// 
			this.m_rbtn_Blue.Location = new System.Drawing.Point(327, 247);
			this.m_rbtn_Blue.Name = "m_rbtn_Blue";
			this.m_rbtn_Blue.Size = new System.Drawing.Size(42, 26);
			this.m_rbtn_Blue.TabIndex = 25;
			this.m_rbtn_Blue.Text = "B:";
			this.m_rbtn_Blue.CheckedChanged += new System.EventHandler(this.m_rbtn_Blue_CheckedChanged);
			// 
			// m_lbl_HexPound
			// 
			this.m_lbl_HexPound.Location = new System.Drawing.Point(433, 253);
			this.m_lbl_HexPound.Name = "m_lbl_HexPound";
			this.m_lbl_HexPound.Size = new System.Drawing.Size(12, 15);
			this.m_lbl_HexPound.TabIndex = 27;
			this.m_lbl_HexPound.Text = "#";
			// 
			// m_lbl_Cyan
			// 
			this.m_lbl_Cyan.Location = new System.Drawing.Point(439, 113);
			this.m_lbl_Cyan.Name = "m_lbl_Cyan";
			this.m_lbl_Cyan.Size = new System.Drawing.Size(28, 18);
			this.m_lbl_Cyan.TabIndex = 31;
			this.m_lbl_Cyan.Text = "C:";
			// 
			// m_lbl_Magenta
			// 
			this.m_lbl_Magenta.Location = new System.Drawing.Point(439, 140);
			this.m_lbl_Magenta.Name = "m_lbl_Magenta";
			this.m_lbl_Magenta.Size = new System.Drawing.Size(28, 17);
			this.m_lbl_Magenta.TabIndex = 32;
			this.m_lbl_Magenta.Text = "M:";
			// 
			// m_lbl_Yellow
			// 
			this.m_lbl_Yellow.Location = new System.Drawing.Point(439, 168);
			this.m_lbl_Yellow.Name = "m_lbl_Yellow";
			this.m_lbl_Yellow.Size = new System.Drawing.Size(28, 17);
			this.m_lbl_Yellow.TabIndex = 33;
			this.m_lbl_Yellow.Text = "Y:";
			// 
			// m_lbl_K
			// 
			this.m_lbl_K.Location = new System.Drawing.Point(439, 194);
			this.m_lbl_K.Name = "m_lbl_K";
			this.m_lbl_K.Size = new System.Drawing.Size(28, 17);
			this.m_lbl_K.TabIndex = 34;
			this.m_lbl_K.Text = "K:";
			// 
			// m_lbl_Primary_Color
			// 
			this.m_lbl_Primary_Color.BackColor = System.Drawing.Color.Gray;
			this.m_lbl_Primary_Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lbl_Primary_Color.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.m_lbl_Primary_Color.Location = new System.Drawing.Point(11, 21);
			this.m_lbl_Primary_Color.Name = "m_lbl_Primary_Color";
			this.m_lbl_Primary_Color.Size = new System.Drawing.Size(60, 60);
			this.m_lbl_Primary_Color.TabIndex = 36;
			this.toolTip.SetToolTip(this.m_lbl_Primary_Color, "When you drag on this box, press arrow keys to move precisely. Shift + Arrow key " +
					"will move 10 pixel each time");
			this.m_lbl_Primary_Color.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_lbl_Primary_Color_MouseDown);
			this.m_lbl_Primary_Color.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lbl_Primary_Color_MouseUp);
			// 
			// m_lbl_Secondary_Color
			// 
			this.m_lbl_Secondary_Color.Location = new System.Drawing.Point(18, 43);
			this.m_lbl_Secondary_Color.Name = "m_lbl_Secondary_Color";
			this.m_lbl_Secondary_Color.Size = new System.Drawing.Size(90, 19);
			this.m_lbl_Secondary_Color.TabIndex = 37;
			this.m_lbl_Secondary_Color.Visible = false;
			this.m_lbl_Secondary_Color.Click += new System.EventHandler(this.m_lbl_Secondary_Color_Click);
			// 
			// m_lbl_Hue_Symbol
			// 
			this.m_lbl_Hue_Symbol.Location = new System.Drawing.Point(414, 114);
			this.m_lbl_Hue_Symbol.Name = "m_lbl_Hue_Symbol";
			this.m_lbl_Hue_Symbol.Size = new System.Drawing.Size(20, 22);
			this.m_lbl_Hue_Symbol.TabIndex = 40;
			this.m_lbl_Hue_Symbol.Text = "бу";
			// 
			// m_lbl_Saturation_Symbol
			// 
			this.m_lbl_Saturation_Symbol.Location = new System.Drawing.Point(414, 143);
			this.m_lbl_Saturation_Symbol.Name = "m_lbl_Saturation_Symbol";
			this.m_lbl_Saturation_Symbol.Size = new System.Drawing.Size(20, 22);
			this.m_lbl_Saturation_Symbol.TabIndex = 41;
			this.m_lbl_Saturation_Symbol.Text = "%";
			// 
			// m_lbl_Black_Symbol
			// 
			this.m_lbl_Black_Symbol.Location = new System.Drawing.Point(414, 170);
			this.m_lbl_Black_Symbol.Name = "m_lbl_Black_Symbol";
			this.m_lbl_Black_Symbol.Size = new System.Drawing.Size(20, 22);
			this.m_lbl_Black_Symbol.TabIndex = 42;
			this.m_lbl_Black_Symbol.Text = "%";
			// 
			// m_lbl_Cyan_Symbol
			// 
			this.m_lbl_Cyan_Symbol.Location = new System.Drawing.Point(508, 115);
			this.m_lbl_Cyan_Symbol.Name = "m_lbl_Cyan_Symbol";
			this.m_lbl_Cyan_Symbol.Size = new System.Drawing.Size(19, 23);
			this.m_lbl_Cyan_Symbol.TabIndex = 43;
			this.m_lbl_Cyan_Symbol.Text = "%";
			// 
			// m_lbl_Magenta_Symbol
			// 
			this.m_lbl_Magenta_Symbol.Location = new System.Drawing.Point(508, 142);
			this.m_lbl_Magenta_Symbol.Name = "m_lbl_Magenta_Symbol";
			this.m_lbl_Magenta_Symbol.Size = new System.Drawing.Size(19, 23);
			this.m_lbl_Magenta_Symbol.TabIndex = 44;
			this.m_lbl_Magenta_Symbol.Text = "%";
			// 
			// m_lbl_Yellow_Symbol
			// 
			this.m_lbl_Yellow_Symbol.Location = new System.Drawing.Point(508, 169);
			this.m_lbl_Yellow_Symbol.Name = "m_lbl_Yellow_Symbol";
			this.m_lbl_Yellow_Symbol.Size = new System.Drawing.Size(19, 22);
			this.m_lbl_Yellow_Symbol.TabIndex = 45;
			this.m_lbl_Yellow_Symbol.Text = "%";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(508, 198);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 22);
			this.label1.TabIndex = 46;
			this.label1.Text = "%";
			// 
			// lbCursorPos
			// 
			this.lbCursorPos.AutoSize = true;
			this.lbCursorPos.Location = new System.Drawing.Point(320, 85);
			this.lbCursorPos.MinimumSize = new System.Drawing.Size(60, 0);
			this.lbCursorPos.Name = "lbCursorPos";
			this.lbCursorPos.Size = new System.Drawing.Size(65, 13);
			this.lbCursorPos.TabIndex = 47;
			this.lbCursorPos.Text = "Position(0,0)";
			this.lbCursorPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pbColorWheel
			// 
			this.pbColorWheel.BackgroundImage = global::Archer.Properties.Resources.ColorWheel;
			this.pbColorWheel.Location = new System.Drawing.Point(5, 8);
			this.pbColorWheel.Name = "pbColorWheel";
			this.pbColorWheel.Size = new System.Drawing.Size(260, 260);
			this.pbColorWheel.TabIndex = 49;
			this.pbColorWheel.TabStop = false;
			this.pbColorWheel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbColorWheel_MouseDown);
			// 
			// pbMagnifier
			// 
			this.pbMagnifier.BackColor = System.Drawing.Color.Gainsboro;
			this.pbMagnifier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbMagnifier.Location = new System.Drawing.Point(78, 21);
			this.pbMagnifier.Name = "pbMagnifier";
			this.pbMagnifier.Size = new System.Drawing.Size(60, 60);
			this.pbMagnifier.TabIndex = 50;
			this.pbMagnifier.TabStop = false;
			this.toolTip.SetToolTip(this.pbMagnifier, "Click and drag on the left box");
			// 
			// groupScreenPicker
			// 
			this.groupScreenPicker.Controls.Add(this.pbMagnifier);
			this.groupScreenPicker.Controls.Add(this.m_lbl_Primary_Color);
			this.groupScreenPicker.Controls.Add(this.m_lbl_Secondary_Color);
			this.groupScreenPicker.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.groupScreenPicker.Location = new System.Drawing.Point(313, 2);
			this.groupScreenPicker.Name = "groupScreenPicker";
			this.groupScreenPicker.Size = new System.Drawing.Size(149, 102);
			this.groupScreenPicker.TabIndex = 51;
			this.groupScreenPicker.TabStop = false;
			this.groupScreenPicker.Text = "Screen Drag Picker";
			this.toolTip.SetToolTip(this.groupScreenPicker, "Click and drag on the left box");
			// 
			// m_ctrl_BigBox
			// 
			this.m_ctrl_BigBox.DrawStyle = adobe_color_picker_clone_part_1.ColorBox.eDrawStyle.Hue;
			hsl1.H = 0D;
			hsl1.L = 1D;
			hsl1.S = 1D;
			this.m_ctrl_BigBox.HSL = hsl1;
			this.m_ctrl_BigBox.Location = new System.Drawing.Point(62, 65);
			this.m_ctrl_BigBox.Name = "m_ctrl_BigBox";
			this.m_ctrl_BigBox.RGB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.m_ctrl_BigBox.Size = new System.Drawing.Size(145, 145);
			this.m_ctrl_BigBox.TabIndex = 39;
			this.m_ctrl_BigBox.Scroll += new adobe_color_picker_clone_part_1.EventHandler(this.m_ctrl_BigBox_Scroll);
			// 
			// m_ctrl_ThinBox
			// 
			this.m_ctrl_ThinBox.BackColor = System.Drawing.Color.White;
			this.m_ctrl_ThinBox.DrawStyle = adobe_color_picker_clone_part_1.VerticalColorSlider.eDrawStyle.Hue;
			hsl2.H = 0D;
			hsl2.L = 1D;
			hsl2.S = 1D;
			this.m_ctrl_ThinBox.HSL = hsl2;
			this.m_ctrl_ThinBox.Location = new System.Drawing.Point(270, 8);
			this.m_ctrl_ThinBox.Name = "m_ctrl_ThinBox";
			this.m_ctrl_ThinBox.RGB = System.Drawing.Color.Red;
			this.m_ctrl_ThinBox.Size = new System.Drawing.Size(40, 260);
			this.m_ctrl_ThinBox.TabIndex = 38;
			this.m_ctrl_ThinBox.Scroll += new adobe_color_picker_clone_part_1.EventHandler(this.m_ctrl_ThinBox_Scroll);
			// 
			// ColorPicker
			// 
			this.AcceptButton = this.m_cmd_OK;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.m_cmd_Cancel;
			this.ClientSize = new System.Drawing.Size(527, 278);
			this.Controls.Add(this.lbCursorPos);
			this.Controls.Add(this.groupScreenPicker);
			this.Controls.Add(this.num_Blue);
			this.Controls.Add(this.num_Green);
			this.Controls.Add(this.num_Red);
			this.Controls.Add(this.num_Black);
			this.Controls.Add(this.num_Sat);
			this.Controls.Add(this.num_Hue);
			this.Controls.Add(this.num_K);
			this.Controls.Add(this.num_Yellow);
			this.Controls.Add(this.num_Magenta);
			this.Controls.Add(this.num_Cyan);
			this.Controls.Add(this.m_cmd_Cancel);
			this.Controls.Add(this.m_cmd_OK);
			this.Controls.Add(this.m_txt_Hex);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_lbl_Yellow_Symbol);
			this.Controls.Add(this.m_lbl_Magenta_Symbol);
			this.Controls.Add(this.m_lbl_Cyan_Symbol);
			this.Controls.Add(this.m_lbl_Black_Symbol);
			this.Controls.Add(this.m_lbl_Saturation_Symbol);
			this.Controls.Add(this.m_lbl_Hue_Symbol);
			this.Controls.Add(this.m_ctrl_BigBox);
			this.Controls.Add(this.m_ctrl_ThinBox);
			this.Controls.Add(this.m_lbl_K);
			this.Controls.Add(this.m_lbl_Yellow);
			this.Controls.Add(this.m_lbl_Magenta);
			this.Controls.Add(this.m_lbl_Cyan);
			this.Controls.Add(this.m_lbl_HexPound);
			this.Controls.Add(this.m_rbtn_Blue);
			this.Controls.Add(this.m_rbtn_Green);
			this.Controls.Add(this.m_rbtn_Red);
			this.Controls.Add(this.m_rbtn_Black);
			this.Controls.Add(this.m_rbtn_Sat);
			this.Controls.Add(this.m_rbtn_Hue);
			this.Controls.Add(this.pbColorWheel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "ColorPicker";
			this.Text = "Color Picker";
			((System.ComponentModel.ISupportInitialize)(this.num_Hue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Sat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Black)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Red)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Green)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Blue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Cyan)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Magenta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Yellow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_K)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbColorWheel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbMagnifier)).EndInit();
			this.groupScreenPicker.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion

		#region Events

		#region General Events

		private void m_cmd_OK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			Clipboard.SetText(HexColor);
			this.Close();
		}


		private void m_cmd_Cancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}


		#endregion

		#region Primary Picture Box (m_ctrl_BigBox)

		private void m_ctrl_BigBox_Scroll(object sender, System.EventArgs e)
		{
			m_hsl = m_ctrl_BigBox.HSL;
			m_rgb = AdobeColors.HSL_to_RGB(m_hsl);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			UpdateUI();

			m_ctrl_ThinBox.HSL = m_hsl;

			m_lbl_Primary_Color.BackColor = m_rgb;
			m_lbl_Primary_Color.Update();
		}


		#endregion

		#region Secondary Picture Box (m_ctrl_ThinBox)

		private void m_ctrl_ThinBox_Scroll(object sender, System.EventArgs e)
		{
			m_hsl = m_ctrl_ThinBox.HSL;
			m_rgb = AdobeColors.HSL_to_RGB(m_hsl);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			UpdateUI();

			m_ctrl_BigBox.HSL = m_hsl;

			m_lbl_Primary_Color.BackColor = m_rgb;
			m_lbl_Primary_Color.Update();
		}


		#endregion

		#region Hex Box (m_txt_Hex)

		private void m_txt_Hex_Changed(object sender, System.EventArgs e)
		{
			try
			{
				m_rgb = Color.FromArgb(Convert.ToInt32(m_txt_Hex.Text, 16));
			}
			catch (Exception ex)
			{
				Archer.Main.Report(ex.Message);
			}
			
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			UpdateUI(sender);
		}


		#endregion

		#region Color Boxes

		private void m_lbl_Secondary_Color_Click(object sender, System.EventArgs e)
		{
			m_rgb = m_lbl_Secondary_Color.BackColor;
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);

			m_ctrl_BigBox.HSL = m_hsl;
			m_ctrl_ThinBox.HSL = m_hsl;

			m_lbl_Primary_Color.BackColor = m_rgb;
			m_lbl_Primary_Color.Update();

			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			UpdateUI();
		}


		#endregion

		#region Radio Buttons

		private void m_rbtn_Hue_CheckedChanged(object sender, System.EventArgs e)
		{
			if ( m_rbtn_Hue.Checked )
			{
				m_ctrl_ThinBox.DrawStyle = VerticalColorSlider.eDrawStyle.Hue;
				m_ctrl_BigBox.DrawStyle = ColorBox.eDrawStyle.Hue;
			}
		}


		private void m_rbtn_Sat_CheckedChanged(object sender, System.EventArgs e)
		{
			if ( m_rbtn_Sat.Checked )
			{
				m_ctrl_ThinBox.DrawStyle = VerticalColorSlider.eDrawStyle.Saturation;
				m_ctrl_BigBox.DrawStyle = ColorBox.eDrawStyle.Saturation;
			}
		}


		private void m_rbtn_Black_CheckedChanged(object sender, System.EventArgs e)
		{
			if ( m_rbtn_Black.Checked )
			{
				m_ctrl_ThinBox.DrawStyle = VerticalColorSlider.eDrawStyle.Brightness;
				m_ctrl_BigBox.DrawStyle = ColorBox.eDrawStyle.Brightness;
			}
		}


		private void m_rbtn_Red_CheckedChanged(object sender, System.EventArgs e)
		{
			if ( m_rbtn_Red.Checked )
			{
				m_ctrl_ThinBox.DrawStyle = VerticalColorSlider.eDrawStyle.Red;
				m_ctrl_BigBox.DrawStyle = ColorBox.eDrawStyle.Red;
			}
		}


		private void m_rbtn_Green_CheckedChanged(object sender, System.EventArgs e)
		{
			if ( m_rbtn_Green.Checked )
			{
				m_ctrl_ThinBox.DrawStyle = VerticalColorSlider.eDrawStyle.Green;
				m_ctrl_BigBox.DrawStyle = ColorBox.eDrawStyle.Green;
			}
		}


		private void m_rbtn_Blue_CheckedChanged(object sender, System.EventArgs e)
		{
			if ( m_rbtn_Blue.Checked )
			{
				m_ctrl_ThinBox.DrawStyle = VerticalColorSlider.eDrawStyle.Blue;
				m_ctrl_BigBox.DrawStyle = ColorBox.eDrawStyle.Blue;
			}
		}


		#endregion

		#region Code Boxes


		private void num_Hue_Changed(object sender, System.EventArgs e)
		{
			m_hsl.H = (double)num_Hue.Value / 360;

			m_rgb = AdobeColors.HSL_to_RGB(m_hsl);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			UpdateUI(sender);
		}


		private void num_Sat_Changed(object sender, System.EventArgs e)
		{
			m_hsl.S = (double)num_Sat.Value / 100;

			m_rgb = AdobeColors.HSL_to_RGB(m_hsl);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			UpdateUI(sender);
		}


		private void num_Black_Changed(object sender, System.EventArgs e)
		{
			m_hsl.L = (double)num_Black.Value / 100;

			m_rgb = AdobeColors.HSL_to_RGB(m_hsl);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			UpdateUI(sender);
		}


		private void num_Red_Changed(object sender, System.EventArgs e)
		{
			m_rgb = Color.FromArgb((int)num_Red.Value, m_rgb.G, m_rgb.B);

			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			UpdateUI(sender);
		}


		private void num_Green_Changed(object sender, System.EventArgs e)
		{
			m_rgb = Color.FromArgb(m_rgb.R, (int)num_Green.Value, m_rgb.B);

			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			UpdateUI(sender);
		}


		private void num_Blue_Changed(object sender, System.EventArgs e)
		{
			m_rgb = Color.FromArgb(m_rgb.R, m_rgb.G, (int)num_Blue.Value);
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			UpdateUI(sender);
		}


		private void num_Cyan_Changed(object sender, System.EventArgs e)
		{
			m_cmyk.C = (double)num_Cyan.Value/100;

			m_rgb = AdobeColors.CMYK_to_RGB(m_cmyk);
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);

			UpdateUI(sender);
		}


		private void num_Magenta_Changed(object sender, System.EventArgs e)
		{
			m_cmyk.M = (double)num_Magenta.Value / 100;

			m_rgb = AdobeColors.CMYK_to_RGB(m_cmyk);
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);

			UpdateUI(sender);
		}


		private void num_Yellow_Changed(object sender, System.EventArgs e)
		{
			m_cmyk.Y = (double)num_Yellow.Value / 100;

			m_rgb = AdobeColors.CMYK_to_RGB(m_cmyk);
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);

			UpdateUI(sender);
		}


		private void num_K_Changed(object sender, System.EventArgs e)
		{
			m_cmyk.K = (double)num_K.Value / 100;

			m_rgb = AdobeColors.CMYK_to_RGB(m_cmyk);
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);

			UpdateUI(sender);
		}


		#endregion

		private void pbColorWheel_MouseDown(object sender, MouseEventArgs e)
		{
			GetCursorPos(out ptCurrentMouse);
			Color c = GetPixelColor(ptCurrentMouse.X, ptCurrentMouse.Y);
			if (AdobeColors.RGB_to_HSL(c).S == 1)
			{
				m_lbl_Primary_Color.BackColor = c;
				m_lbl_Primary_Color.Update();

				m_rgb = c;
				m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
				m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

				UpdateUI(sender);

				pbColorWheel.Refresh();
				Graphics g = pbColorWheel.CreateGraphics();
				int diameter = 12;
				g.DrawEllipse(Pens.Black, new Rectangle(e.X - diameter / 2, e.Y - diameter / 2, diameter, diameter));
				g.DrawEllipse(Pens.White, new Rectangle(e.X - diameter / 2 + 1, e.Y - diameter / 2 + 1, diameter - 2, diameter - 2));
			}
		}

		#endregion

		#region Private Functions

		private void WriteHexData(Color rgb)
		{
			string red = Convert.ToString(rgb.R, 16);
			if ( red.Length < 2 ) red = "0" + red;
			string green = Convert.ToString(rgb.G, 16);
			if ( green.Length < 2 ) green = "0" + green;
			string blue = Convert.ToString(rgb.B, 16);
			if ( blue.Length < 2 ) blue = "0" + blue;

			m_txt_Hex.Text = red.ToUpper() + green.ToUpper() + blue.ToUpper();
			m_txt_Hex.Update();
		}

		private void UpdateUI(object sender = null)
		{
			if (sender != null && !(sender as Control).Focused)
				return;

			m_ctrl_BigBox.HSL = m_hsl;
			m_ctrl_ThinBox.HSL = m_hsl;
			m_lbl_Primary_Color.BackColor = m_rgb;

			if(sender != m_txt_Hex) WriteHexData(m_rgb);

			num_Hue.Value = (int)Math.Round(m_hsl.H * 360);
			num_Sat.Value = (int)Math.Round(m_hsl.S * 100);
			num_Black.Value = (int)Math.Round(m_hsl.L * 100);
			num_Cyan.Value = (int)Math.Round(m_cmyk.C * 100);
			num_Magenta.Value = (int)Math.Round(m_cmyk.M * 100);
			num_Yellow.Value = (int)Math.Round(m_cmyk.Y * 100);
			num_K.Value = (int)Math.Round(m_cmyk.K * 100);
			num_Red.Value =			m_rgb.R;
			num_Green.Value =		m_rgb.G;
			num_Blue.Value =		m_rgb.B;

			num_Hue.Update();
			num_Sat.Update();
			num_Black.Update();
			num_Cyan.Update();
			num_Magenta.Update();
			num_Yellow.Update();
			num_K.Update();
			num_Red.Update();
			num_Green.Update();
			num_Blue.Update();
		}

		[DllImport("user32.dll")]
		static extern IntPtr GetDC(IntPtr hwnd);

		[DllImport("user32.dll")]
		static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

		[DllImport("gdi32.dll")]
		static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

		[DllImport("user32.dll")]
		private static extern bool GetCursorPos(out nPoint p);

		public struct nPoint
		{
			public int X;
			public int Y;
		}

		[DllImport("user32.dll", EntryPoint = "SetCursorPos")]
		private static extern bool SetCursorPos(int X, int Y);

		private Color GetPixelColor(int x, int y)
		{
			uint pixel = GetPixel(hDeviceContext, x, y);
			Color color = Color.FromArgb(
				(int)(pixel & 0x000000FF),
				(int)(pixel & 0x0000FF00) >> 8,
				(int)(pixel & 0x00FF0000) >> 16
			);
			return color;
		}

		private void m_lbl_Primary_Color_MouseDown(object sender, MouseEventArgs e)
		{
			m_lbl_Primary_Color.MouseMove -= m_lbl_Primary_Color_MouseMove;

			if (Archer.Main.Self.GestureManager != null)
				Archer.Main.Self.GestureManager.GestureEnabled = false;

			m_lbl_Primary_Color.Capture = true;
			m_lbl_Primary_Color.Cursor = new Cursor(new MemoryStream(Archer.Properties.Resources.ColorPicker));
			m_lbl_Primary_Color.MouseMove += m_lbl_Primary_Color_MouseMove;
			captureScreenOn = true;
		}
		
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (captureScreenOn)
			{
				int captureMoveGain = 1;
				if (Control.ModifierKeys == Keys.Shift)
				{
					captureMoveGain = 10;
					keyData = keyData ^ Keys.Shift;
				}
				switch (keyData)
				{
					case Keys.Left:
						SetCursorPos(ptCurrentMouse.X - captureMoveGain, ptCurrentMouse.Y);
						return true;
					case Keys.Right:
						SetCursorPos(ptCurrentMouse.X + captureMoveGain, ptCurrentMouse.Y);
						return true;
					case Keys.Up:
						SetCursorPos(ptCurrentMouse.X, ptCurrentMouse.Y - captureMoveGain);
						return true;
					case Keys.Down:
						SetCursorPos(ptCurrentMouse.X, ptCurrentMouse.Y + captureMoveGain);
						return true;
				}
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void m_lbl_Primary_Color_MouseMove(object sender, MouseEventArgs e)
		{
			GetCursorPos(out ptCurrentMouse);
			lbCursorPos.Text = "Position(" + (ptCurrentMouse.X + 1) + "," + (ptCurrentMouse.Y + 1) + ")";
			lbCursorPos.Update();

			Graphics g = Graphics.FromImage(bmpCapture);
			g.CopyFromScreen(ptCurrentMouse.X - 10, ptCurrentMouse.Y - 10, 0, 0, new Size(20, 20));
			
			g = pbMagnifier.CreateGraphics();
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			g.DrawImage(
				bmpCapture,
				new Rectangle(0,0,60,60),
				new Rectangle(0,0,20,20),
				GraphicsUnit.Pixel
			);

			Color cTarget = bmpCapture.GetPixel(10, 10);
			
			g.DrawRectangle(new Pen(Color.FromArgb(255, 255, 255, 255)), 28, 28, 4, 4);
			g.DrawRectangle(new Pen(Color.FromArgb(255, 50, 50, 50)), 27, 27, 6, 6);

			m_lbl_Primary_Color.BackColor = cTarget;
			m_lbl_Primary_Color.Update();
			
			m_rgb = cTarget;
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			m_ctrl_BigBox.HSL = m_hsl;
			m_ctrl_ThinBox.HSL = m_hsl;
			m_lbl_Primary_Color.BackColor = m_rgb;

			UpdateUI();
		}

		private void m_lbl_Primary_Color_MouseUp(object sender, MouseEventArgs e)
		{
			m_lbl_Primary_Color.MouseMove -= m_lbl_Primary_Color_MouseMove;

			if (Archer.Main.Self.GestureManager != null)
				Archer.Main.Self.GestureManager.GestureEnabled = true;

			m_lbl_Primary_Color.Capture = false;
			m_lbl_Primary_Color.Cursor = Cursors.Default;

			captureScreenOn = false;
		}

		#endregion

		#region Public Methods

		public Color PrimaryColor
		{
			get
			{
				return m_rgb;
			}
			set
			{
				m_rgb = value;
				m_hsl = AdobeColors.RGB_to_HSL(m_rgb);

				UpdateUI();

				m_ctrl_BigBox.HSL = m_hsl;
				m_ctrl_ThinBox.HSL = m_hsl;

				m_lbl_Primary_Color.BackColor = m_rgb;
			}
		}

		public string HexColor
		{
			get { return m_txt_Hex.Text; }
		}

		public eDrawStyle DrawStyle
		{
			get
			{
				if ( m_rbtn_Hue.Checked )
					return eDrawStyle.Hue;
				else if ( m_rbtn_Sat.Checked )
					return eDrawStyle.Saturation;
				else if ( m_rbtn_Black.Checked )
					return eDrawStyle.Brightness;
				else if ( m_rbtn_Red.Checked )
					return eDrawStyle.Red;
				else if ( m_rbtn_Green.Checked )
					return eDrawStyle.Green;
				else if ( m_rbtn_Blue.Checked )
					return eDrawStyle.Blue;
				else
					return eDrawStyle.Hue;
			}
			set
			{
				switch(value)
				{
					case eDrawStyle.Hue :
						m_rbtn_Hue.Checked = true;
						break;
					case eDrawStyle.Saturation :
						m_rbtn_Sat.Checked = true;
						break;
					case eDrawStyle.Brightness :
						m_rbtn_Black.Checked = true;
						break;
					case eDrawStyle.Red :
						m_rbtn_Red.Checked = true;
						break;
					case eDrawStyle.Green :
						m_rbtn_Green.Checked = true;
						break;
					case eDrawStyle.Blue :
						m_rbtn_Blue.Checked = true;
						break;
					default :
						m_rbtn_Hue.Checked = true;
						break;
				}
			}
		}


		#endregion
	}
}
