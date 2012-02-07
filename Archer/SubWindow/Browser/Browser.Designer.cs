namespace Archer
{
	partial class Browser
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.btnBackward = new System.Windows.Forms.ToolStripButton();
			this.btnForward = new System.Windows.Forms.ToolStripButton();
			this.cbAddress = new System.Windows.Forms.ToolStripComboBox();
			this.btnRefresh = new System.Windows.Forms.ToolStripButton();
			this.btnShowConsole = new System.Windows.Forms.ToolStripButton();
			this.btnRunScript = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripTxtAddPath = new System.Windows.Forms.ToolStripTextBox();
			this.btnSelectDOM = new System.Windows.Forms.ToolStripButton();
			this.btnShowError = new System.Windows.Forms.ToolStripButton();
			this.btnFullScreen = new System.Windows.Forms.ToolStripButton();
			this.pbarLoadingProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.tableMain = new System.Windows.Forms.TableLayoutPanel();
			this.webBrowser = new ys.WebBrowserEx();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.toolStrip.SuspendLayout();
			this.tableMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBackward,
            this.btnForward,
            this.cbAddress,
            this.btnRefresh,
            this.btnShowConsole,
            this.btnRunScript,
            this.btnSelectDOM,
            this.btnShowError,
            this.btnFullScreen,
            this.pbarLoadingProgress});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip.Size = new System.Drawing.Size(984, 35);
			this.toolStrip.TabIndex = 0;
			// 
			// btnBackward
			// 
			this.btnBackward.AutoSize = false;
			this.btnBackward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnBackward.Enabled = false;
			this.btnBackward.Image = ((System.Drawing.Image)(resources.GetObject("btnBackward.Image")));
			this.btnBackward.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnBackward.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnBackward.Name = "btnBackward";
			this.btnBackward.Size = new System.Drawing.Size(32, 32);
			this.btnBackward.Text = "Backward(Alt + Arrow Left)";
			this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
			// 
			// btnForward
			// 
			this.btnForward.AutoSize = false;
			this.btnForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnForward.Enabled = false;
			this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
			this.btnForward.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnForward.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnForward.Name = "btnForward";
			this.btnForward.Size = new System.Drawing.Size(32, 32);
			this.btnForward.Text = "Forward(Alt + Arrow Right)";
			this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
			// 
			// cbAddress
			// 
			this.cbAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
			this.cbAddress.MaxDropDownItems = 60;
			this.cbAddress.Name = "cbAddress";
			this.cbAddress.Size = new System.Drawing.Size(580, 35);
			this.cbAddress.Text = "about:blank";
			this.cbAddress.TextChanged += new System.EventHandler(this.cbAddress_TextChanged);
			// 
			// btnRefresh
			// 
			this.btnRefresh.AutoSize = false;
			this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
			this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(32, 32);
			this.btnRefresh.Text = "Refresh(F5)";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnShowConsole
			// 
			this.btnShowConsole.AutoSize = false;
			this.btnShowConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnShowConsole.Image = ((System.Drawing.Image)(resources.GetObject("btnShowConsole.Image")));
			this.btnShowConsole.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnShowConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnShowConsole.Name = "btnShowConsole";
			this.btnShowConsole.Size = new System.Drawing.Size(32, 32);
			this.btnShowConsole.Text = "Script Console(F12)";
			this.btnShowConsole.Click += new System.EventHandler(this.ShowScriptConsole);
			// 
			// btnRunScript
			// 
			this.btnRunScript.AutoSize = false;
			this.btnRunScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTxtAddPath});
			this.btnRunScript.Image = ((System.Drawing.Image)(resources.GetObject("btnRunScript.Image")));
			this.btnRunScript.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnRunScript.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRunScript.Name = "btnRunScript";
			this.btnRunScript.Size = new System.Drawing.Size(40, 32);
			this.btnRunScript.ToolTipText = "Run all the script(shortcut F2)\r\nLeft click list item to run specified script\r\nRi" +
				"ght click list item to edit specified script with default text editor";
			this.btnRunScript.ButtonClick += new System.EventHandler(this.RunAllScript);
			// 
			// toolStripTxtAddPath
			// 
			this.toolStripTxtAddPath.AutoToolTip = true;
			this.toolStripTxtAddPath.ForeColor = System.Drawing.Color.LightSkyBlue;
			this.toolStripTxtAddPath.Name = "toolStripTxtAddPath";
			this.toolStripTxtAddPath.Size = new System.Drawing.Size(100, 23);
			this.toolStripTxtAddPath.Text = "Add New Path";
			this.toolStripTxtAddPath.ToolTipText = "Press TAB to accept the input. Or you can drag the file(s) to here.";
			this.toolStripTxtAddPath.LostFocus += new System.EventHandler(this.AddScriptPath);
			// 
			// btnSelectDOM
			// 
			this.btnSelectDOM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnSelectDOM.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectDOM.Image")));
			this.btnSelectDOM.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSelectDOM.Name = "btnSelectDOM";
			this.btnSelectDOM.Size = new System.Drawing.Size(39, 32);
			this.btnSelectDOM.Text = "&DOM";
			this.btnSelectDOM.ToolTipText = "Select element by click";
			this.btnSelectDOM.Click += new System.EventHandler(this.btnSelectDOM_Click);
			// 
			// btnShowError
			// 
			this.btnShowError.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnShowError.Image = ((System.Drawing.Image)(resources.GetObject("btnShowError.Image")));
			this.btnShowError.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnShowError.Name = "btnShowError";
			this.btnShowError.Size = new System.Drawing.Size(36, 32);
			this.btnShowError.Text = "&Error";
			this.btnShowError.ToolTipText = "Show script error or not";
			this.btnShowError.Click += new System.EventHandler(this.btnShowError_Click);
			// 
			// btnFullScreen
			// 
			this.btnFullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnFullScreen.Image = ((System.Drawing.Image)(resources.GetObject("btnFullScreen.Image")));
			this.btnFullScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFullScreen.Name = "btnFullScreen";
			this.btnFullScreen.Size = new System.Drawing.Size(30, 32);
			this.btnFullScreen.Text = "&Full";
			this.btnFullScreen.ToolTipText = "Switch to Full/Normal Screen(F11)";
			this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
			// 
			// pbarLoadingProgress
			// 
			this.pbarLoadingProgress.AutoSize = false;
			this.pbarLoadingProgress.Margin = new System.Windows.Forms.Padding(5, 2, 1, 1);
			this.pbarLoadingProgress.Name = "pbarLoadingProgress";
			this.pbarLoadingProgress.Size = new System.Drawing.Size(80, 18);
			this.pbarLoadingProgress.Visible = false;
			// 
			// tableMain
			// 
			this.tableMain.ColumnCount = 1;
			this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableMain.Controls.Add(this.toolStrip, 0, 0);
			this.tableMain.Controls.Add(this.webBrowser, 0, 1);
			this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableMain.Location = new System.Drawing.Point(0, 0);
			this.tableMain.Margin = new System.Windows.Forms.Padding(0);
			this.tableMain.Name = "tableMain";
			this.tableMain.RowCount = 2;
			this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableMain.Size = new System.Drawing.Size(984, 662);
			this.tableMain.TabIndex = 2;
			// 
			// webBrowser
			// 
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.Location = new System.Drawing.Point(0, 35);
			this.webBrowser.Margin = new System.Windows.Forms.Padding(0);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.ScriptErrorsSuppressed = true;
			this.webBrowser.Size = new System.Drawing.Size(984, 627);
			this.webBrowser.TabIndex = 1;
			this.webBrowser.NewWindow2 += new System.EventHandler<ys.NewWindow2EventArgs>(this.webBrowser_NewWindow2);
			this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
			this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
			this.webBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser_ProgressChanged);
			this.webBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowser_PreviewKeyDown);
			// 
			// Browser
			// 
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.tableMain);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Browser";
			this.Text = "Browser";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Browser_FormClosing);
			this.Shown += new System.EventHandler(this.Start);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Browser_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Browser_DragEnter);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.tableMain.ResumeLayout(false);
			this.tableMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton btnBackward;
		private System.Windows.Forms.ToolStripButton btnForward;
		private System.Windows.Forms.ToolStripComboBox cbAddress;
		private System.Windows.Forms.ToolStripButton btnRefresh;
		private System.Windows.Forms.ToolStripProgressBar pbarLoadingProgress;
		private System.Windows.Forms.ToolStripSplitButton btnRunScript;
		private System.Windows.Forms.ToolStripButton btnShowConsole;
		private System.Windows.Forms.ToolStripTextBox toolStripTxtAddPath;
		private System.Windows.Forms.TableLayoutPanel tableMain;
		private System.Windows.Forms.ToolStripButton btnShowError;
		private System.Windows.Forms.ToolStripButton btnFullScreen;
		private System.Windows.Forms.ToolTip toolTip;
		private ys.WebBrowserEx webBrowser;
		private System.Windows.Forms.ToolStripButton btnSelectDOM;
	}
}