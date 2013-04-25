namespace Archer
{
	partial class Main
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.tbpMain = new System.Windows.Forms.TableLayoutPanel();
			this.panelButton = new System.Windows.Forms.Panel();
			this.btnHelp = new System.Windows.Forms.Button();
			this.btnHome = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnSettings = new System.Windows.Forms.Button();
			this.groupBoxInfo = new System.Windows.Forms.GroupBox();
			this.ctmNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gestureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.editArrowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newArrowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.delCurrentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.onlineServiceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.shareArrowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.scriptStoreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.changeAccountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.backupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recoverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runOnStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.checkUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutBoxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtName = new System.Windows.Forms.TextBox();
			this.pbIcon = new System.Windows.Forms.PictureBox();
			this.lbCount = new System.Windows.Forms.Label();
			this.lbHotKey = new System.Windows.Forms.Label();
			this.lbTag = new System.Windows.Forms.Label();
			this.lbArg = new System.Windows.Forms.Label();
			this.lbCmd = new System.Windows.Forms.Label();
			this.lbName = new System.Windows.Forms.Label();
			this.splitInput = new System.Windows.Forms.SplitContainer();
			this.cbName = new System.Windows.Forms.ComboBox();
			this.cbArg = new System.Windows.Forms.ComboBox();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.tbpMain.SuspendLayout();
			this.panelButton.SuspendLayout();
			this.groupBoxInfo.SuspendLayout();
			this.ctmNotifyIcon.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
			this.splitInput.Panel1.SuspendLayout();
			this.splitInput.Panel2.SuspendLayout();
			this.splitInput.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbpMain
			// 
			this.tbpMain.BackColor = System.Drawing.Color.Transparent;
			this.tbpMain.ColumnCount = 2;
			this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
			this.tbpMain.Controls.Add(this.panelButton, 1, 0);
			this.tbpMain.Controls.Add(this.groupBoxInfo, 0, 0);
			this.tbpMain.Controls.Add(this.splitInput, 0, 1);
			this.tbpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbpMain.Location = new System.Drawing.Point(0, 0);
			this.tbpMain.Name = "tbpMain";
			this.tbpMain.RowCount = 2;
			this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tbpMain.Size = new System.Drawing.Size(452, 201);
			this.tbpMain.TabIndex = 0;
			// 
			// panelButton
			// 
			this.panelButton.Controls.Add(this.btnHelp);
			this.panelButton.Controls.Add(this.btnHome);
			this.panelButton.Controls.Add(this.btnOK);
			this.panelButton.Controls.Add(this.btnSettings);
			this.panelButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelButton.Location = new System.Drawing.Point(397, 3);
			this.panelButton.Name = "panelButton";
			this.panelButton.Size = new System.Drawing.Size(52, 163);
			this.panelButton.TabIndex = 2;
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnHelp.Image = global::Archer.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(3, 110);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(46, 30);
			this.btnHelp.TabIndex = 2;
			this.toolTip.SetToolTip(this.btnHelp, "F1");
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.OpenDocumentation);
			// 
			// btnHome
			// 
			this.btnHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnHome.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnHome.Image = global::Archer.Properties.Resources.Home;
			this.btnHome.Location = new System.Drawing.Point(3, 75);
			this.btnHome.Name = "btnHome";
			this.btnHome.Size = new System.Drawing.Size(46, 30);
			this.btnHome.TabIndex = 1;
			this.toolTip.SetToolTip(this.btnHome, "Ctrl + F1");
			this.btnHome.UseVisualStyleBackColor = true;
			this.btnHome.Click += new System.EventHandler(this.OpenArcherHome);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Image = global::Archer.Properties.Resources.OK;
			this.btnOK.Location = new System.Drawing.Point(3, 40);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(46, 30);
			this.btnOK.TabIndex = 0;
			this.toolTip.SetToolTip(this.btnOK, "Enter or Win + A.\r\nIf Argument box have lost focus, text in it will be reserved.");
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.LaunchArrows);
			// 
			// btnSettings
			// 
			this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSettings.Image = global::Archer.Properties.Resources.Settings;
			this.btnSettings.Location = new System.Drawing.Point(3, 5);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(46, 30);
			this.btnSettings.TabIndex = 2;
			this.toolTip.SetToolTip(this.btnSettings, "Ctrl + S");
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.OpenSettings);
			// 
			// groupBoxInfo
			// 
			this.groupBoxInfo.BackColor = System.Drawing.Color.Transparent;
			this.groupBoxInfo.ContextMenuStrip = this.ctmNotifyIcon;
			this.groupBoxInfo.Controls.Add(this.txtName);
			this.groupBoxInfo.Controls.Add(this.pbIcon);
			this.groupBoxInfo.Controls.Add(this.lbCount);
			this.groupBoxInfo.Controls.Add(this.lbHotKey);
			this.groupBoxInfo.Controls.Add(this.lbTag);
			this.groupBoxInfo.Controls.Add(this.lbArg);
			this.groupBoxInfo.Controls.Add(this.lbCmd);
			this.groupBoxInfo.Controls.Add(this.lbName);
			this.groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.groupBoxInfo.Location = new System.Drawing.Point(3, 3);
			this.groupBoxInfo.Name = "groupBoxInfo";
			this.groupBoxInfo.Size = new System.Drawing.Size(388, 163);
			this.groupBoxInfo.TabIndex = 2;
			this.groupBoxInfo.TabStop = false;
			this.toolTip.SetToolTip(this.groupBoxInfo, "Press F2 to edit current arrow\r\nCtrl + M to open context menu\r\nDrag item(s) to cr" +
        "eate new arrow(s)");
			this.groupBoxInfo.DragEnter += new System.Windows.Forms.DragEventHandler(this.Archer_DragEnter);
			// 
			// ctmNotifyIcon
			// 
			this.ctmNotifyIcon.BackColor = System.Drawing.Color.White;
			this.ctmNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideToolStripMenuItem,
            this.gestureMenuItem,
            this.toolStripSeparator1,
            this.editArrowMenuItem,
            this.newArrowMenuItem,
            this.delCurrentMenuItem,
            this.toolStripSeparator2,
            this.onlineServiceMenuItem,
            this.settingsToolStripMenuItem,
            this.runOnStartToolStripMenuItem,
            this.toolStripSeparator3,
            this.checkUpdateMenuItem,
            this.helpMenuItem,
            this.aboutBoxMenuItem,
            this.exitToolStripMenuItem});
			this.ctmNotifyIcon.Name = "ctmNotifyIcon";
			this.ctmNotifyIcon.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ctmNotifyIcon.Size = new System.Drawing.Size(165, 308);
			// 
			// showHideToolStripMenuItem
			// 
			this.showHideToolStripMenuItem.Image = global::Archer.Properties.Resources._Icon_Archer_16_;
			this.showHideToolStripMenuItem.Name = "showHideToolStripMenuItem";
			this.showHideToolStripMenuItem.ShortcutKeyDisplayString = "Win+A";
			this.showHideToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.showHideToolStripMenuItem.Text = "Archer";
			this.showHideToolStripMenuItem.Click += new System.EventHandler(this.ShowHideWindow);
			// 
			// gestureMenuItem
			// 
			this.gestureMenuItem.Name = "gestureMenuItem";
			this.gestureMenuItem.ShortcutKeyDisplayString = "Win+Shift+A";
			this.gestureMenuItem.Size = new System.Drawing.Size(164, 22);
			this.gestureMenuItem.Text = "Gesture";
			this.gestureMenuItem.Click += new System.EventHandler(this.disableGestureMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
			// 
			// editArrowMenuItem
			// 
			this.editArrowMenuItem.Name = "editArrowMenuItem";
			this.editArrowMenuItem.ShortcutKeyDisplayString = "F2";
			this.editArrowMenuItem.Size = new System.Drawing.Size(164, 22);
			this.editArrowMenuItem.Text = "Edit Arrow";
			this.editArrowMenuItem.Click += new System.EventHandler(this.ShowEditor);
			// 
			// newArrowMenuItem
			// 
			this.newArrowMenuItem.Name = "newArrowMenuItem";
			this.newArrowMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
			this.newArrowMenuItem.Size = new System.Drawing.Size(164, 22);
			this.newArrowMenuItem.Text = "New Arrow";
			this.newArrowMenuItem.Click += new System.EventHandler(this.newNewArrow);
			// 
			// delCurrentMenuItem
			// 
			this.delCurrentMenuItem.Image = global::Archer.Properties.Resources.Cancel;
			this.delCurrentMenuItem.Name = "delCurrentMenuItem";
			this.delCurrentMenuItem.ShortcutKeyDisplayString = "Ctrl+D";
			this.delCurrentMenuItem.Size = new System.Drawing.Size(164, 22);
			this.delCurrentMenuItem.Text = "Delete Arrow";
			this.delCurrentMenuItem.Click += new System.EventHandler(this.DeleteArrow);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
			// 
			// onlineServiceMenuItem
			// 
			this.onlineServiceMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shareArrowMenuItem,
            this.scriptStoreMenuItem,
            this.toolStripSeparator4,
            this.changeAccountMenuItem,
            this.toolStripSeparator5,
            this.backupMenuItem,
            this.recoverMenuItem});
			this.onlineServiceMenuItem.Name = "onlineServiceMenuItem";
			this.onlineServiceMenuItem.Size = new System.Drawing.Size(164, 22);
			this.onlineServiceMenuItem.Text = "Online Service";
			// 
			// shareArrowMenuItem
			// 
			this.shareArrowMenuItem.Name = "shareArrowMenuItem";
			this.shareArrowMenuItem.ShortcutKeyDisplayString = "Ctrl+R";
			this.shareArrowMenuItem.Size = new System.Drawing.Size(163, 22);
			this.shareArrowMenuItem.Text = "Share Arrow";
			this.shareArrowMenuItem.Click += new System.EventHandler(this.ShareArrow);
			// 
			// scriptStoreMenuItem
			// 
			this.scriptStoreMenuItem.Name = "scriptStoreMenuItem";
			this.scriptStoreMenuItem.Size = new System.Drawing.Size(163, 22);
			this.scriptStoreMenuItem.Text = "Script Store";
			this.scriptStoreMenuItem.Click += new System.EventHandler(this.scriptStoreMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(160, 6);
			// 
			// changeAccountMenuItem
			// 
			this.changeAccountMenuItem.Name = "changeAccountMenuItem";
			this.changeAccountMenuItem.ShortcutKeyDisplayString = "Win+Ctrl+A";
			this.changeAccountMenuItem.Size = new System.Drawing.Size(163, 22);
			this.changeAccountMenuItem.Text = "Account";
			this.changeAccountMenuItem.Click += new System.EventHandler(this.Account);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(160, 6);
			// 
			// backupMenuItem
			// 
			this.backupMenuItem.Image = global::Archer.Properties.Resources.Backup;
			this.backupMenuItem.Name = "backupMenuItem";
			this.backupMenuItem.Size = new System.Drawing.Size(163, 22);
			this.backupMenuItem.Text = "Backup User Data";
			this.backupMenuItem.Click += new System.EventHandler(this.Backup);
			// 
			// recoverMenuItem
			// 
			this.recoverMenuItem.Image = global::Archer.Properties.Resources.Recovery;
			this.recoverMenuItem.Name = "recoverMenuItem";
			this.recoverMenuItem.Size = new System.Drawing.Size(163, 22);
			this.recoverMenuItem.Text = "Recover User Data";
			this.recoverMenuItem.Click += new System.EventHandler(this.Recover);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Image = global::Archer.Properties.Resources.Settings;
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.OpenSettings);
			// 
			// runOnStartToolStripMenuItem
			// 
			this.runOnStartToolStripMenuItem.Name = "runOnStartToolStripMenuItem";
			this.runOnStartToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.runOnStartToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.runOnStartToolStripMenuItem.Text = "Run on Startup";
			this.runOnStartToolStripMenuItem.Click += new System.EventHandler(this.SetRunOnStart);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
			// 
			// checkUpdateMenuItem
			// 
			this.checkUpdateMenuItem.Name = "checkUpdateMenuItem";
			this.checkUpdateMenuItem.ShortcutKeyDisplayString = "";
			this.checkUpdateMenuItem.Size = new System.Drawing.Size(164, 22);
			this.checkUpdateMenuItem.Text = "Update";
			this.checkUpdateMenuItem.Click += new System.EventHandler(this.StartCheckAndUpdate);
			// 
			// helpMenuItem
			// 
			this.helpMenuItem.Image = global::Archer.Properties.Resources.Help;
			this.helpMenuItem.Name = "helpMenuItem";
			this.helpMenuItem.ShortcutKeyDisplayString = "F1";
			this.helpMenuItem.Size = new System.Drawing.Size(164, 22);
			this.helpMenuItem.Text = "Help";
			this.helpMenuItem.Click += new System.EventHandler(this.OpenDocumentation);
			// 
			// aboutBoxMenuItem
			// 
			this.aboutBoxMenuItem.Image = global::Archer.Properties.Resources.notifyIcon1;
			this.aboutBoxMenuItem.Name = "aboutBoxMenuItem";
			this.aboutBoxMenuItem.ShortcutKeyDisplayString = "";
			this.aboutBoxMenuItem.Size = new System.Drawing.Size(164, 22);
			this.aboutBoxMenuItem.Text = "About";
			this.aboutBoxMenuItem.Click += new System.EventHandler(this.ShowAboutBox);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Q";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtName.Location = new System.Drawing.Point(70, 12);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(160, 20);
			this.txtName.TabIndex = 14;
			this.txtName.Visible = false;
			this.txtName.WordWrap = false;
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
			this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
			// 
			// pbIcon
			// 
			this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pbIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbIcon.Location = new System.Drawing.Point(339, 113);
			this.pbIcon.Name = "pbIcon";
			this.pbIcon.Size = new System.Drawing.Size(32, 32);
			this.pbIcon.TabIndex = 13;
			this.pbIcon.TabStop = false;
			this.toolTip.SetToolTip(this.pbIcon, "Click to open its parent path if it has one.\r\nCtrl + P");
			this.pbIcon.Visible = false;
			this.pbIcon.Click += new System.EventHandler(this.OpenParentDir);
			// 
			// lbCount
			// 
			this.lbCount.AutoSize = true;
			this.lbCount.Location = new System.Drawing.Point(67, 130);
			this.lbCount.MinimumSize = new System.Drawing.Size(100, 15);
			this.lbCount.Name = "lbCount";
			this.lbCount.Size = new System.Drawing.Size(100, 15);
			this.lbCount.TabIndex = 9;
			this.lbCount.Text = "0";
			this.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip.SetToolTip(this.lbCount, "How many times you have used this arrow");
			this.lbCount.UseMnemonic = false;
			// 
			// lbHotKey
			// 
			this.lbHotKey.AutoSize = true;
			this.lbHotKey.Location = new System.Drawing.Point(67, 107);
			this.lbHotKey.Name = "lbHotKey";
			this.lbHotKey.Size = new System.Drawing.Size(25, 13);
			this.lbHotKey.TabIndex = 11;
			this.lbHotKey.Text = "Null";
			this.lbHotKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip.SetToolTip(this.lbHotKey, "Global hot key");
			this.lbHotKey.UseMnemonic = false;
			// 
			// lbTag
			// 
			this.lbTag.AutoSize = true;
			this.lbTag.Location = new System.Drawing.Point(67, 84);
			this.lbTag.Name = "lbTag";
			this.lbTag.Size = new System.Drawing.Size(25, 13);
			this.lbTag.TabIndex = 8;
			this.lbTag.Text = "Null";
			this.lbTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip.SetToolTip(this.lbTag, "Tag and comments here");
			this.lbTag.UseMnemonic = false;
			// 
			// lbArg
			// 
			this.lbArg.AutoSize = true;
			this.lbArg.Location = new System.Drawing.Point(67, 60);
			this.lbArg.MaximumSize = new System.Drawing.Size(0, 15);
			this.lbArg.Name = "lbArg";
			this.lbArg.Size = new System.Drawing.Size(25, 13);
			this.lbArg.TabIndex = 7;
			this.lbArg.Text = "Null";
			this.lbArg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip.SetToolTip(this.lbArg, "Arguments accept drag and drop operation");
			this.lbArg.UseMnemonic = false;
			// 
			// lbCmd
			// 
			this.lbCmd.AutoSize = true;
			this.lbCmd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbCmd.Location = new System.Drawing.Point(67, 37);
			this.lbCmd.MaximumSize = new System.Drawing.Size(0, 15);
			this.lbCmd.Name = "lbCmd";
			this.lbCmd.Size = new System.Drawing.Size(25, 13);
			this.lbCmd.TabIndex = 6;
			this.lbCmd.Text = "Null";
			this.lbCmd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip.SetToolTip(this.lbCmd, "Press F3 or click to copy Cmd into the clipboard.\r\nIf Ctrl pressed, Archer will t" +
        "ry to copy the path of parent folder.");
			this.lbCmd.UseMnemonic = false;
			this.lbCmd.Click += new System.EventHandler(this.lbCmd_Click);
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbName.Location = new System.Drawing.Point(67, 14);
			this.lbName.MaximumSize = new System.Drawing.Size(0, 15);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(25, 13);
			this.lbName.TabIndex = 5;
			this.lbName.Text = "Null";
			this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip.SetToolTip(this.lbName, "Press F6 or click to rename current arrow\r\nPress F5 to reload all the data and re" +
        "fresh the UI");
			this.lbName.UseMnemonic = false;
			this.lbName.Click += new System.EventHandler(this.lbName_Click);
			// 
			// splitInput
			// 
			this.tbpMain.SetColumnSpan(this.splitInput, 2);
			this.splitInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitInput.Location = new System.Drawing.Point(3, 172);
			this.splitInput.Name = "splitInput";
			// 
			// splitInput.Panel1
			// 
			this.splitInput.Panel1.Controls.Add(this.cbName);
			// 
			// splitInput.Panel2
			// 
			this.splitInput.Panel2.Controls.Add(this.cbArg);
			this.splitInput.Size = new System.Drawing.Size(446, 26);
			this.splitInput.SplitterDistance = 142;
			this.splitInput.SplitterWidth = 5;
			this.splitInput.TabIndex = 0;
			this.splitInput.TabStop = false;
			// 
			// cbName
			// 
			this.cbName.AllowDrop = true;
			this.cbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbName.BackColor = System.Drawing.Color.White;
			this.cbName.FormattingEnabled = true;
			this.cbName.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.cbName.Location = new System.Drawing.Point(3, 0);
			this.cbName.Name = "cbName";
			this.cbName.Size = new System.Drawing.Size(139, 21);
			this.cbName.TabIndex = 0;
			this.toolTip.SetToolTip(this.cbName, resources.GetString("cbName.ToolTip"));
			this.cbName.TextChanged += new System.EventHandler(this.cbName_TextChanged);
			this.cbName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbName_KeyUp);
			// 
			// cbArg
			// 
			this.cbArg.AllowDrop = true;
			this.cbArg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbArg.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbArg.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
			this.cbArg.BackColor = System.Drawing.Color.White;
			this.cbArg.FormattingEnabled = true;
			this.cbArg.Location = new System.Drawing.Point(0, 0);
			this.cbArg.Name = "cbArg";
			this.cbArg.Size = new System.Drawing.Size(296, 21);
			this.cbArg.TabIndex = 0;
			this.toolTip.SetToolTip(this.cbArg, "Input arguments here.\r\nPress Ctrl+Enter, launch arrow with auto url encode Arg of" +
        "f.\r\nDrag item(s) here to get path(s).");
			this.cbArg.TextChanged += new System.EventHandler(this.cbArg_TextChanged);
			this.cbArg.DragDrop += new System.Windows.Forms.DragEventHandler(this.cbArg_DragDrop);
			this.cbArg.DragEnter += new System.Windows.Forms.DragEventHandler(this.cbArg_DragEnter);
			this.cbArg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbArg_KeyUp);
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.ctmNotifyIcon;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Archer";
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ShowHideWindow);
			// 
			// toolTip
			// 
			this.toolTip.BackColor = System.Drawing.Color.White;
			// 
			// Main
			// 
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = global::Archer.Properties.Resources.MainWindow;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(452, 201);
			this.Controls.Add(this.tbpMain);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(460, 228);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Archer";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Shown += new System.EventHandler(this.Archer_Shown);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Archer_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Archer_DragEnter);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Archer_KeyDown);
			this.tbpMain.ResumeLayout(false);
			this.panelButton.ResumeLayout(false);
			this.groupBoxInfo.ResumeLayout(false);
			this.groupBoxInfo.PerformLayout();
			this.ctmNotifyIcon.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
			this.splitInput.Panel1.ResumeLayout(false);
			this.splitInput.Panel2.ResumeLayout(false);
			this.splitInput.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tbpMain;
		private System.Windows.Forms.Panel panelButton;
		private System.Windows.Forms.GroupBox groupBoxInfo;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.Button btnHome;
		private System.Windows.Forms.Label lbCount;
		private System.Windows.Forms.Label lbHotKey;
		private System.Windows.Forms.Label lbTag;
		private System.Windows.Forms.Label lbArg;
		private System.Windows.Forms.Label lbCmd;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.ContextMenuStrip ctmNotifyIcon;
		private System.Windows.Forms.ToolStripMenuItem showHideToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runOnStartToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.SplitContainer splitInput;
		private System.Windows.Forms.ComboBox cbArg;
		private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
		public System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ComboBox cbName;
		private System.Windows.Forms.ToolStripMenuItem gestureMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editArrowMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkUpdateMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutBoxMenuItem;
		private System.Windows.Forms.ToolStripMenuItem delCurrentMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newArrowMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem onlineServiceMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backupMenuItem;
		private System.Windows.Forms.ToolStripMenuItem recoverMenuItem;
		private System.Windows.Forms.ToolStripMenuItem shareArrowMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeAccountMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scriptStoreMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.PictureBox pbIcon;
		private System.Windows.Forms.TextBox txtName;
	}
}

