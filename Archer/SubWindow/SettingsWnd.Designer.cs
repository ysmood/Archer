namespace Archer
{
	partial class SettingsWnd
	{
		private System.Windows.Forms.TableLayoutPanel tbMain;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnScriptStore;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.CheckBox ckbNotifyIcon;
		private System.Windows.Forms.TextBox txtDefaultBrowser;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEditorPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgv;

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWnd));
			this.tbMain = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtStrokeProp = new System.Windows.Forms.TextBox();
			this.keyPrompter = new ys.Control.KeyPrompter();
			this.btnScriptStore = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.ckbNotifyIcon = new System.Windows.Forms.CheckBox();
			this.txtDefaultBrowser = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEditorPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvCmd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvType = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.dgvArg = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvHotkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvHotkeyEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dgvCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ctmDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.insertRowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.duplicateRowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.quickSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reverseCheckMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.shareScriptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.encryptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.tbMain.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.ctmDataGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbMain
			// 
			this.tbMain.ColumnCount = 1;
			this.tbMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tbMain.Controls.Add(this.panel1, 0, 0);
			this.tbMain.Controls.Add(this.dgv, 0, 1);
			this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbMain.Location = new System.Drawing.Point(0, 0);
			this.tbMain.Name = "tbMain";
			this.tbMain.RowCount = 2;
			this.tbMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
			this.tbMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tbMain.Size = new System.Drawing.Size(964, 565);
			this.tbMain.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtStrokeProp);
			this.panel1.Controls.Add(this.keyPrompter);
			this.panel1.Controls.Add(this.btnScriptStore);
			this.panel1.Controls.Add(this.btnOk);
			this.panel1.Controls.Add(this.btnOpen);
			this.panel1.Controls.Add(this.ckbNotifyIcon);
			this.panel1.Controls.Add(this.txtDefaultBrowser);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtEditorPath);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(958, 36);
			this.panel1.TabIndex = 1;
			// 
			// txtStrokeProp
			// 
			this.txtStrokeProp.BackColor = System.Drawing.Color.White;
			this.txtStrokeProp.Location = new System.Drawing.Point(689, 8);
			this.txtStrokeProp.Name = "txtStrokeProp";
			this.txtStrokeProp.Size = new System.Drawing.Size(112, 20);
			this.txtStrokeProp.TabIndex = 8;
			this.txtStrokeProp.Text = "#FFFFFFFF, 3, 10";
			this.toolTip.SetToolTip(this.txtStrokeProp, "Mouse stroke property:\r\nARGB color, stroke width, unit line length(pixel).");
			// 
			// keyPrompter
			// 
			this.keyPrompter.BackColor = System.Drawing.Color.Transparent;
			this.keyPrompter.Location = new System.Drawing.Point(390, 8);
			this.keyPrompter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.keyPrompter.Name = "keyPrompter";
			this.keyPrompter.Size = new System.Drawing.Size(150, 21);
			this.keyPrompter.TabIndex = 7;
			// 
			// btnScriptStore
			// 
			this.btnScriptStore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnScriptStore.Image = global::Archer.Properties.Resources.ScriptStore;
			this.btnScriptStore.Location = new System.Drawing.Point(908, 3);
			this.btnScriptStore.Name = "btnScriptStore";
			this.btnScriptStore.Size = new System.Drawing.Size(46, 30);
			this.btnScriptStore.TabIndex = 1;
			this.toolTip.SetToolTip(this.btnScriptStore, "Get online script resources.");
			this.btnScriptStore.UseVisualStyleBackColor = true;
			this.btnScriptStore.Click += new System.EventHandler(this.OpenScriptStore);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Image = global::Archer.Properties.Resources.OK;
			this.btnOk.Location = new System.Drawing.Point(858, 3);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(46, 30);
			this.btnOk.TabIndex = 0;
			this.toolTip.SetToolTip(this.btnOk, "Ctrl + S");
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.SaveSettings);
			// 
			// btnOpen
			// 
			this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpen.Image = global::Archer.Properties.Resources.OpenAsText;
			this.btnOpen.Location = new System.Drawing.Point(807, 3);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(46, 30);
			this.btnOpen.TabIndex = 2;
			this.toolTip.SetToolTip(this.btnOpen, "Ctrl + O or F3, Open the data file in default editor");
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// ckbNotifyIcon
			// 
			this.ckbNotifyIcon.AutoSize = true;
			this.ckbNotifyIcon.Location = new System.Drawing.Point(553, 10);
			this.ckbNotifyIcon.Name = "ckbNotifyIcon";
			this.ckbNotifyIcon.Size = new System.Drawing.Size(104, 17);
			this.ckbNotifyIcon.TabIndex = 6;
			this.ckbNotifyIcon.Text = "Show notify icon";
			this.ckbNotifyIcon.UseVisualStyleBackColor = true;
			this.ckbNotifyIcon.CheckedChanged += new System.EventHandler(this.ckbNotifyIcon_CheckedChanged);
			// 
			// txtDefaultBrowser
			// 
			this.txtDefaultBrowser.AllowDrop = true;
			this.txtDefaultBrowser.BackColor = System.Drawing.Color.White;
			this.txtDefaultBrowser.Location = new System.Drawing.Point(66, 8);
			this.txtDefaultBrowser.Name = "txtDefaultBrowser";
			this.txtDefaultBrowser.Size = new System.Drawing.Size(125, 20);
			this.txtDefaultBrowser.TabIndex = 3;
			this.txtDefaultBrowser.Text = "iexplore.exe";
			this.toolTip.SetToolTip(this.txtDefaultBrowser, "Accept drag and drop operation");
			this.txtDefaultBrowser.DragDrop += new System.Windows.Forms.DragEventHandler(this.common_DragDrop);
			this.txtDefaultBrowser.DragEnter += new System.Windows.Forms.DragEventHandler(this.common_Enter);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Browser:";
			// 
			// txtEditorPath
			// 
			this.txtEditorPath.AllowDrop = true;
			this.txtEditorPath.BackColor = System.Drawing.Color.White;
			this.txtEditorPath.Location = new System.Drawing.Point(252, 8);
			this.txtEditorPath.Name = "txtEditorPath";
			this.txtEditorPath.Size = new System.Drawing.Size(125, 20);
			this.txtEditorPath.TabIndex = 4;
			this.txtEditorPath.Text = "notepad.exe";
			this.toolTip.SetToolTip(this.txtEditorPath, "Accept drag and drop operation");
			this.txtEditorPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.common_DragDrop);
			this.txtEditorPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.common_Enter);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(197, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Editor:";
			// 
			// dgv
			// 
			this.dgv.AllowDrop = true;
			this.dgv.AllowUserToOrderColumns = true;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeight = 26;
			this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvName,
            this.dgvCmd,
            this.dgvType,
            this.dgvArg,
            this.dgvTag,
            this.dgvHotkey,
            this.dgvHotkeyEnabled,
            this.dgvCount,
            this.dgvTimestamp,
            this.dgvGUID,
            this.dgvBlank});
			this.dgv.ContextMenuStrip = this.ctmDataGrid;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(3, 45);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgv.RowHeadersWidth = 26;
			this.dgv.RowTemplate.Height = 23;
			this.dgv.Size = new System.Drawing.Size(958, 517);
			this.dgv.TabIndex = 0;
			this.toolTip.SetToolTip(this.dgv, "Accept drag and drop operation");
			this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
			this.dgv.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDown);
			this.dgv.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_CellValidating);
			this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
			this.dgv.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgv_DragDrop);
			this.dgv.DragEnter += new System.Windows.Forms.DragEventHandler(this.common_Enter);
			// 
			// dgvName
			// 
			this.dgvName.Frozen = true;
			this.dgvName.HeaderText = "Name";
			this.dgvName.Name = "dgvName";
			this.dgvName.Width = 80;
			// 
			// dgvCmd
			// 
			this.dgvCmd.HeaderText = "Cmd(Command)";
			this.dgvCmd.MaxInputLength = 10000000;
			this.dgvCmd.Name = "dgvCmd";
			this.dgvCmd.Width = 260;
			// 
			// dgvType
			// 
			this.dgvType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
			this.dgvType.DropDownWidth = 150;
			this.dgvType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.dgvType.HeaderText = "Type";
			this.dgvType.MaxDropDownItems = 15;
			this.dgvType.Name = "dgvType";
			this.dgvType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dgvType.Width = 50;
			// 
			// dgvArg
			// 
			this.dgvArg.HeaderText = "Arg(Argument)";
			this.dgvArg.Name = "dgvArg";
			this.dgvArg.Width = 120;
			// 
			// dgvTag
			// 
			this.dgvTag.HeaderText = "Tag";
			this.dgvTag.Name = "dgvTag";
			this.dgvTag.Width = 160;
			// 
			// dgvHotkey
			// 
			this.dgvHotkey.HeaderText = "Key(HotKey)";
			this.dgvHotkey.Name = "dgvHotkey";
			// 
			// dgvHotkeyEnabled
			// 
			this.dgvHotkeyEnabled.HeaderText = "Enabled";
			this.dgvHotkeyEnabled.Name = "dgvHotkeyEnabled";
			this.dgvHotkeyEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dgvHotkeyEnabled.Width = 60;
			// 
			// dgvCount
			// 
			this.dgvCount.HeaderText = "Count";
			this.dgvCount.Name = "dgvCount";
			this.dgvCount.ReadOnly = true;
			this.dgvCount.Width = 50;
			// 
			// dgvTimestamp
			// 
			this.dgvTimestamp.HeaderText = "Timestamp";
			this.dgvTimestamp.Name = "dgvTimestamp";
			this.dgvTimestamp.ReadOnly = true;
			this.dgvTimestamp.Width = 160;
			// 
			// dgvGUID
			// 
			this.dgvGUID.FillWeight = 200F;
			this.dgvGUID.HeaderText = "GUID";
			this.dgvGUID.Name = "dgvGUID";
			this.dgvGUID.ReadOnly = true;
			this.dgvGUID.Width = 260;
			// 
			// dgvBlank
			// 
			this.dgvBlank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dgvBlank.HeaderText = "";
			this.dgvBlank.Name = "dgvBlank";
			// 
			// ctmDataGrid
			// 
			this.ctmDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertRowMenuItem,
            this.duplicateRowMenuItem,
            this.deleteRowToolStripMenuItem,
            this.toolStripSeparator1,
            this.quickSearchToolStripMenuItem,
            this.reverseCheckMenuItem,
            this.toolStripSeparator3,
            this.shareScriptMenuItem,
            this.toolStripSeparator2,
            this.encryptMenuItem});
			this.ctmDataGrid.Name = "ctmDataGrid";
			this.ctmDataGrid.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ctmDataGrid.Size = new System.Drawing.Size(202, 176);
			this.ctmDataGrid.Opened += new System.EventHandler(this.ctmDataGrid_Opened);
			// 
			// insertRowMenuItem
			// 
			this.insertRowMenuItem.Name = "insertRowMenuItem";
			this.insertRowMenuItem.ShortcutKeyDisplayString = "";
			this.insertRowMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.insertRowMenuItem.Size = new System.Drawing.Size(201, 22);
			this.insertRowMenuItem.Text = "Insert Row";
			this.insertRowMenuItem.Click += new System.EventHandler(this.insertRowMenuItem_Click);
			// 
			// duplicateRowMenuItem
			// 
			this.duplicateRowMenuItem.Name = "duplicateRowMenuItem";
			this.duplicateRowMenuItem.ShortcutKeyDisplayString = "";
			this.duplicateRowMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
			this.duplicateRowMenuItem.Size = new System.Drawing.Size(201, 22);
			this.duplicateRowMenuItem.Text = "Duplicate Row(s)";
			this.duplicateRowMenuItem.Click += new System.EventHandler(this.duplicateRowMenuItem_Click);
			// 
			// deleteRowToolStripMenuItem
			// 
			this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
			this.deleteRowToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.deleteRowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
			this.deleteRowToolStripMenuItem.Text = "Delete Row(s)";
			this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
			// 
			// quickSearchToolStripMenuItem
			// 
			this.quickSearchToolStripMenuItem.Name = "quickSearchToolStripMenuItem";
			this.quickSearchToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.quickSearchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.quickSearchToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
			this.quickSearchToolStripMenuItem.Text = "Quick Search";
			this.quickSearchToolStripMenuItem.Click += new System.EventHandler(this.ShowLocator);
			// 
			// reverseCheckMenuItem
			// 
			this.reverseCheckMenuItem.Name = "reverseCheckMenuItem";
			this.reverseCheckMenuItem.ShortcutKeyDisplayString = "";
			this.reverseCheckMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.reverseCheckMenuItem.Size = new System.Drawing.Size(201, 22);
			this.reverseCheckMenuItem.Text = "Reverse Check";
			this.reverseCheckMenuItem.Click += new System.EventHandler(this.reverseCheckMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(198, 6);
			// 
			// shareScriptMenuItem
			// 
			this.shareScriptMenuItem.Name = "shareScriptMenuItem";
			this.shareScriptMenuItem.ShortcutKeyDisplayString = "";
			this.shareScriptMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.shareScriptMenuItem.Size = new System.Drawing.Size(201, 22);
			this.shareScriptMenuItem.Text = "Share Arrow";
			this.shareScriptMenuItem.Click += new System.EventHandler(this.ShareArrow);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(198, 6);
			// 
			// encryptMenuItem
			// 
			this.encryptMenuItem.Name = "encryptMenuItem";
			this.encryptMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.encryptMenuItem.Size = new System.Drawing.Size(201, 22);
			this.encryptMenuItem.Text = "Encrypt";
			this.encryptMenuItem.Click += new System.EventHandler(this.encrypt);
			// 
			// SettingsWnd
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(964, 565);
			this.Controls.Add(this.tbMain);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(600, 300);
			this.Name = "SettingsWnd";
			this.Text = "Settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
			this.Shown += new System.EventHandler(this.WindowShown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WindowKeyDown);
			this.tbMain.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ctmDataGrid.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ys.Control.KeyPrompter keyPrompter;
		private System.Windows.Forms.ContextMenuStrip ctmDataGrid;
		private System.Windows.Forms.ToolStripMenuItem insertRowMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quickSearchToolStripMenuItem;
		private System.Windows.Forms.TextBox txtStrokeProp;
		private System.Windows.Forms.ToolStripMenuItem reverseCheckMenuItem;
		private System.Windows.Forms.ToolStripMenuItem shareScriptMenuItem;
		private System.Windows.Forms.ToolStripMenuItem duplicateRowMenuItem;
		private System.Windows.Forms.ToolStripMenuItem encryptMenuItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvCmd;
		private System.Windows.Forms.DataGridViewComboBoxColumn dgvType;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvArg;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvTag;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvHotkey;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dgvHotkeyEnabled;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvCount;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvTimestamp;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvGUID;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvBlank;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}