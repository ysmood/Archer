namespace Archer
{
    partial class Editor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
			this.txtCmd = new ICSharpCode.TextEditor.TextEditorControl();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.btnRun = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.tableMain = new System.Windows.Forms.TableLayoutPanel();
			this.panelTop = new System.Windows.Forms.Panel();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.lbKey = new System.Windows.Forms.Label();
			this.txtTag = new System.Windows.Forms.TextBox();
			this.txtArg = new System.Windows.Forms.TextBox();
			this.lbTag = new System.Windows.Forms.Label();
			this.lbArg = new System.Windows.Forms.Label();
			this.lbName = new System.Windows.Forms.Label();
			this.toolStripCmd = new System.Windows.Forms.ToolStrip();
			this.toolStripLbCmd = new System.Windows.Forms.ToolStripLabel();
			this.btnEncrypted = new System.Windows.Forms.ToolStripButton();
			this.btnHotkeyEnabled = new System.Windows.Forms.ToolStripButton();
			this.btnResetCode = new System.Windows.Forms.ToolStripButton();
			this.btnCSharpHighlight = new System.Windows.Forms.ToolStripButton();
			this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.lbParserThread = new System.Windows.Forms.ToolStripStatusLabel();
			this.keyPrompter = new ys.Control.KeyPrompter();
			this.contextMenu.SuspendLayout();
			this.tableMain.SuspendLayout();
			this.panelTop.SuspendLayout();
			this.toolStripCmd.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtCmd
			// 
			this.txtCmd.AllowDrop = true;
			this.txtCmd.ContextMenuStrip = this.contextMenu;
			this.txtCmd.ConvertTabsToSpaces = true;
			this.txtCmd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCmd.IsReadOnly = false;
			this.txtCmd.Location = new System.Drawing.Point(3, 95);
			this.txtCmd.Name = "txtCmd";
			this.txtCmd.ShowVRuler = false;
			this.txtCmd.Size = new System.Drawing.Size(611, 342);
			this.txtCmd.TabIndex = 0;
			this.txtCmd.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtCmdEditor_DragDrop);
			this.txtCmd.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtCmdEditor_DragEnter);
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenameToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.copyAllToolStripMenuItem,
            this.pasteToolStripMenuItem});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(123, 136);
			// 
			// RenameToolStripMenuItem
			// 
			this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
			this.RenameToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.RenameToolStripMenuItem.Text = "Rename";
			this.RenameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.cutToolStripMenuItem.Text = "Cut";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// copyAllToolStripMenuItem
			// 
			this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
			this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.copyAllToolStripMenuItem.Text = "Copy All";
			this.copyAllToolStripMenuItem.Click += new System.EventHandler(this.copyAllToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
			// 
			// imgList
			// 
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			this.imgList.Images.SetKeyName(0, "Icons.16x16.Class.png");
			this.imgList.Images.SetKeyName(1, "Icons.16x16.Method.png");
			this.imgList.Images.SetKeyName(2, "Icons.16x16.Property.png");
			this.imgList.Images.SetKeyName(3, "Icons.16x16.Field.png");
			this.imgList.Images.SetKeyName(4, "Icons.16x16.Enum.png");
			this.imgList.Images.SetKeyName(5, "Icons.16x16.NameSpace.png");
			this.imgList.Images.SetKeyName(6, "Icons.16x16.Event.png");
			// 
			// btnRun
			// 
			this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRun.BackgroundImage = global::Archer.Properties.Resources.Run;
			this.btnRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRun.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnRun.Location = new System.Drawing.Point(562, 3);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(46, 30);
			this.btnRun.TabIndex = 5;
			this.toolTip.SetToolTip(this.btnRun, "Run Current Script(F5)");
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.BackgroundImage = global::Archer.Properties.Resources.OK;
			this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnOk.Location = new System.Drawing.Point(504, 3);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(46, 30);
			this.btnOk.TabIndex = 4;
			this.toolTip.SetToolTip(this.btnOk, "Ctrl + S");
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.Save);
			// 
			// txtName
			// 
			this.txtName.BackColor = System.Drawing.Color.White;
			this.txtName.Location = new System.Drawing.Point(54, 9);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(98, 22);
			this.txtName.TabIndex = 0;
			this.toolTip.SetToolTip(this.txtName, "Press F2 to focus here");
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// tableMain
			// 
			this.tableMain.ColumnCount = 1;
			this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableMain.Controls.Add(this.panelTop, 0, 0);
			this.tableMain.Controls.Add(this.toolStripCmd, 0, 1);
			this.tableMain.Controls.Add(this.statusStrip, 0, 3);
			this.tableMain.Controls.Add(this.txtCmd, 0, 2);
			this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableMain.Location = new System.Drawing.Point(0, 0);
			this.tableMain.Name = "tableMain";
			this.tableMain.RowCount = 4;
			this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
			this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.tableMain.Size = new System.Drawing.Size(617, 462);
			this.tableMain.TabIndex = 7;
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.keyPrompter);
			this.panelTop.Controls.Add(this.btnRun);
			this.panelTop.Controls.Add(this.btnOk);
			this.panelTop.Controls.Add(this.txtKey);
			this.panelTop.Controls.Add(this.lbKey);
			this.panelTop.Controls.Add(this.txtTag);
			this.panelTop.Controls.Add(this.txtArg);
			this.panelTop.Controls.Add(this.txtName);
			this.panelTop.Controls.Add(this.lbTag);
			this.panelTop.Controls.Add(this.lbArg);
			this.panelTop.Controls.Add(this.lbName);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTop.Location = new System.Drawing.Point(3, 3);
			this.panelTop.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(611, 65);
			this.panelTop.TabIndex = 9;
			// 
			// txtKey
			// 
			this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKey.BackColor = System.Drawing.Color.White;
			this.txtKey.Location = new System.Drawing.Point(347, 39);
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(114, 22);
			this.txtKey.TabIndex = 3;
			this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// lbKey
			// 
			this.lbKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbKey.AutoSize = true;
			this.lbKey.Location = new System.Drawing.Point(308, 42);
			this.lbKey.Name = "lbKey";
			this.lbKey.Size = new System.Drawing.Size(30, 16);
			this.lbKey.TabIndex = 7;
			this.lbKey.Text = "Key:";
			this.lbKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTag
			// 
			this.txtTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTag.BackColor = System.Drawing.Color.White;
			this.txtTag.Location = new System.Drawing.Point(54, 39);
			this.txtTag.Name = "txtTag";
			this.txtTag.Size = new System.Drawing.Size(237, 22);
			this.txtTag.TabIndex = 2;
			// 
			// txtArg
			// 
			this.txtArg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtArg.BackColor = System.Drawing.Color.White;
			this.txtArg.Location = new System.Drawing.Point(202, 9);
			this.txtArg.Name = "txtArg";
			this.txtArg.Size = new System.Drawing.Size(286, 22);
			this.txtArg.TabIndex = 1;
			// 
			// lbTag
			// 
			this.lbTag.AutoSize = true;
			this.lbTag.Location = new System.Drawing.Point(16, 42);
			this.lbTag.Name = "lbTag";
			this.lbTag.Size = new System.Drawing.Size(30, 16);
			this.lbTag.TabIndex = 9;
			this.lbTag.Text = "Tag:";
			this.lbTag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbArg
			// 
			this.lbArg.AutoSize = true;
			this.lbArg.Location = new System.Drawing.Point(163, 12);
			this.lbArg.Name = "lbArg";
			this.lbArg.Size = new System.Drawing.Size(30, 16);
			this.lbArg.TabIndex = 8;
			this.lbArg.Text = "Arg:";
			this.lbArg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Location = new System.Drawing.Point(9, 12);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(42, 16);
			this.lbName.TabIndex = 6;
			this.lbName.Text = "Name:";
			this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripCmd
			// 
			this.toolStripCmd.BackColor = System.Drawing.Color.White;
			this.toolStripCmd.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLbCmd,
            this.btnEncrypted,
            this.btnHotkeyEnabled,
            this.btnResetCode,
            this.btnCSharpHighlight,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
			this.toolStripCmd.Location = new System.Drawing.Point(0, 68);
			this.toolStripCmd.Name = "toolStripCmd";
			this.toolStripCmd.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStripCmd.Size = new System.Drawing.Size(617, 24);
			this.toolStripCmd.TabIndex = 8;
			// 
			// toolStripLbCmd
			// 
			this.toolStripLbCmd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripLbCmd.Margin = new System.Windows.Forms.Padding(14, 1, 0, 2);
			this.toolStripLbCmd.Name = "toolStripLbCmd";
			this.toolStripLbCmd.Size = new System.Drawing.Size(36, 21);
			this.toolStripLbCmd.Text = "Cmd:";
			// 
			// btnEncrypted
			// 
			this.btnEncrypted.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnEncrypted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnEncrypted.Image = ((System.Drawing.Image)(resources.GetObject("btnEncrypted.Image")));
			this.btnEncrypted.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEncrypted.Name = "btnEncrypted";
			this.btnEncrypted.Size = new System.Drawing.Size(64, 21);
			this.btnEncrypted.Text = "E&ncrypted";
			this.btnEncrypted.Click += new System.EventHandler(this.encrypt);
			// 
			// btnHotkeyEnabled
			// 
			this.btnHotkeyEnabled.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnHotkeyEnabled.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnHotkeyEnabled.Image = ((System.Drawing.Image)(resources.GetObject("btnHotkeyEnabled.Image")));
			this.btnHotkeyEnabled.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnHotkeyEnabled.Name = "btnHotkeyEnabled";
			this.btnHotkeyEnabled.Size = new System.Drawing.Size(94, 21);
			this.btnHotkeyEnabled.Text = "Hotkey &Enabled";
			this.btnHotkeyEnabled.Click += new System.EventHandler(this.btnHotkeyEnabled_Click);
			// 
			// btnResetCode
			// 
			this.btnResetCode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnResetCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnResetCode.Image = ((System.Drawing.Image)(resources.GetObject("btnResetCode.Image")));
			this.btnResetCode.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnResetCode.Name = "btnResetCode";
			this.btnResetCode.Size = new System.Drawing.Size(70, 21);
			this.btnResetCode.Text = "&Reset Code";
			this.btnResetCode.Click += new System.EventHandler(this.btnResetCode_Click);
			// 
			// btnCSharpHighlight
			// 
			this.btnCSharpHighlight.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnCSharpHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnCSharpHighlight.Image = ((System.Drawing.Image)(resources.GetObject("btnCSharpHighlight.Image")));
			this.btnCSharpHighlight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCSharpHighlight.Name = "btnCSharpHighlight";
			this.btnCSharpHighlight.Size = new System.Drawing.Size(79, 21);
			this.btnCSharpHighlight.Text = "C# &Highlight";
			this.btnCSharpHighlight.Click += new System.EventHandler(this.btnCSharpHighlight_Click);
			// 
			// cutToolStripButton
			// 
			this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
			this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripButton.Name = "cutToolStripButton";
			this.cutToolStripButton.Size = new System.Drawing.Size(23, 21);
			this.cutToolStripButton.Text = "C&ut";
			this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripButton_Click);
			// 
			// copyToolStripButton
			// 
			this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
			this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripButton.Name = "copyToolStripButton";
			this.copyToolStripButton.Size = new System.Drawing.Size(23, 21);
			this.copyToolStripButton.Text = "&Copy";
			this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripButton_Click);
			// 
			// pasteToolStripButton
			// 
			this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
			this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripButton.Name = "pasteToolStripButton";
			this.pasteToolStripButton.Size = new System.Drawing.Size(23, 21);
			this.pasteToolStripButton.Text = "&Paste";
			this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
			// 
			// helpToolStripButton
			// 
			this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
			this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpToolStripButton.Name = "helpToolStripButton";
			this.helpToolStripButton.Size = new System.Drawing.Size(23, 21);
			this.helpToolStripButton.Text = "He&lp";
			this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbParserThread});
			this.statusStrip.Location = new System.Drawing.Point(0, 440);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(617, 22);
			this.statusStrip.TabIndex = 7;
			this.statusStrip.Text = "statusStrip1";
			// 
			// lbParserThread
			// 
			this.lbParserThread.BackColor = System.Drawing.Color.Transparent;
			this.lbParserThread.Name = "lbParserThread";
			this.lbParserThread.Size = new System.Drawing.Size(39, 17);
			this.lbParserThread.Text = "Status";
			// 
			// keyPrompter
			// 
			this.keyPrompter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.keyPrompter.BackColor = System.Drawing.Color.Transparent;
			this.keyPrompter.Location = new System.Drawing.Point(467, 39);
			this.keyPrompter.Margin = new System.Windows.Forms.Padding(3, 48, 3, 48);
			this.keyPrompter.Name = "keyPrompter";
			this.keyPrompter.Size = new System.Drawing.Size(141, 22);
			this.keyPrompter.TabIndex = 0;
			this.keyPrompter.TabStop = false;
			// 
			// Editor
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(617, 462);
			this.Controls.Add(this.tableMain);
			this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "Editor";
			this.Text = "Editor";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.contextMenu.ResumeLayout(false);
			this.tableMain.ResumeLayout(false);
			this.tableMain.PerformLayout();
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.toolStripCmd.ResumeLayout(false);
			this.toolStripCmd.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

		private ICSharpCode.TextEditor.TextEditorControl txtCmd;
		internal System.Windows.Forms.ImageList imgList;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.TableLayoutPanel tableMain;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel lbParserThread;
		private System.Windows.Forms.ToolStrip toolStripCmd;
		private System.Windows.Forms.ToolStripLabel toolStripLbCmd;
		private System.Windows.Forms.ToolStripButton btnHotkeyEnabled;
		private System.Windows.Forms.ToolStripButton btnResetCode;
		private System.Windows.Forms.ToolStripButton btnCSharpHighlight;
		private System.Windows.Forms.Panel panelTop;
		private ys.Control.KeyPrompter keyPrompter;
		private System.Windows.Forms.TextBox txtTag;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.TextBox txtArg;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lbTag;
		private System.Windows.Forms.Label lbArg;
		private System.Windows.Forms.Label lbKey;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.ToolStripButton cutToolStripButton;
		private System.Windows.Forms.ToolStripButton copyToolStripButton;
		private System.Windows.Forms.ToolStripButton pasteToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton helpToolStripButton;
		private System.Windows.Forms.ToolStripButton btnEncrypted;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem RenameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
    }
}

