namespace Archer
{
	partial class AccountManager
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountManager));
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.linkRegister = new System.Windows.Forms.LinkLabel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabAccount = new System.Windows.Forms.TabPage();
			this.btnRecover = new System.Windows.Forms.Button();
			this.btnBackup = new System.Windows.Forms.Button();
			this.linkForgetPassword = new System.Windows.Forms.LinkLabel();
			this.tabChangePassword = new System.Windows.Forms.TabPage();
			this.txtUserName2 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtConfirm = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtCurrentPassword = new System.Windows.Forms.TextBox();
			this.txtNewPassword = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.btnChangePassword = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.tabControl.SuspendLayout();
			this.tabAccount.SuspendLayout();
			this.tabChangePassword.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtUserName
			// 
			this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtUserName.Location = new System.Drawing.Point(81, 18);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(192, 20);
			this.txtUserName.TabIndex = 0;
			this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.Location = new System.Drawing.Point(81, 55);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '●';
			this.txtPassword.Size = new System.Drawing.Size(191, 20);
			this.txtPassword.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "User Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Password:";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Image = global::Archer.Properties.Resources.OK;
			this.btnOk.Location = new System.Drawing.Point(227, 92);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(46, 30);
			this.btnOk.TabIndex = 4;
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackgroundImage = global::Archer.Properties.Resources.Cancel;
			this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(171, 92);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(46, 30);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// linkRegister
			// 
			this.linkRegister.ActiveLinkColor = System.Drawing.Color.Turquoise;
			this.linkRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkRegister.AutoSize = true;
			this.linkRegister.LinkColor = System.Drawing.Color.DodgerBlue;
			this.linkRegister.Location = new System.Drawing.Point(152, 137);
			this.linkRegister.Name = "linkRegister";
			this.linkRegister.Size = new System.Drawing.Size(104, 13);
			this.linkRegister.TabIndex = 6;
			this.linkRegister.TabStop = true;
			this.linkRegister.Text = "Get an new account";
			this.linkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegister_LinkClicked);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabAccount);
			this.tabControl.Controls.Add(this.tabChangePassword);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(302, 190);
			this.tabControl.TabIndex = 9;
			// 
			// tabAccount
			// 
			this.tabAccount.Controls.Add(this.btnRecover);
			this.tabAccount.Controls.Add(this.btnBackup);
			this.tabAccount.Controls.Add(this.linkForgetPassword);
			this.tabAccount.Controls.Add(this.txtUserName);
			this.tabAccount.Controls.Add(this.linkRegister);
			this.tabAccount.Controls.Add(this.txtPassword);
			this.tabAccount.Controls.Add(this.btnCancel);
			this.tabAccount.Controls.Add(this.label1);
			this.tabAccount.Controls.Add(this.btnOk);
			this.tabAccount.Controls.Add(this.label2);
			this.tabAccount.Location = new System.Drawing.Point(4, 22);
			this.tabAccount.Name = "tabAccount";
			this.tabAccount.Padding = new System.Windows.Forms.Padding(3);
			this.tabAccount.Size = new System.Drawing.Size(294, 164);
			this.tabAccount.TabIndex = 0;
			this.tabAccount.Text = "Account";
			this.tabAccount.UseVisualStyleBackColor = true;
			// 
			// btnRecover
			// 
			this.btnRecover.BackgroundImage = global::Archer.Properties.Resources.Recovery;
			this.btnRecover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRecover.Location = new System.Drawing.Point(76, 92);
			this.btnRecover.Name = "btnRecover";
			this.btnRecover.Size = new System.Drawing.Size(46, 30);
			this.btnRecover.TabIndex = 3;
			this.toolTip.SetToolTip(this.btnRecover, "Recover settings from server.\r\nIf Ctrl pressed, Archer will recover to the second" +
					" last version.");
			this.btnRecover.UseVisualStyleBackColor = true;
			this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
			// 
			// btnBackup
			// 
			this.btnBackup.BackgroundImage = global::Archer.Properties.Resources.Backup;
			this.btnBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnBackup.Location = new System.Drawing.Point(18, 92);
			this.btnBackup.Name = "btnBackup";
			this.btnBackup.Size = new System.Drawing.Size(46, 30);
			this.btnBackup.TabIndex = 2;
			this.toolTip.SetToolTip(this.btnBackup, "Backup settings to server");
			this.btnBackup.UseVisualStyleBackColor = true;
			this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
			// 
			// linkForgetPassword
			// 
			this.linkForgetPassword.ActiveLinkColor = System.Drawing.Color.Turquoise;
			this.linkForgetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkForgetPassword.AutoSize = true;
			this.linkForgetPassword.LinkColor = System.Drawing.Color.DodgerBlue;
			this.linkForgetPassword.Location = new System.Drawing.Point(39, 137);
			this.linkForgetPassword.Name = "linkForgetPassword";
			this.linkForgetPassword.Size = new System.Drawing.Size(85, 13);
			this.linkForgetPassword.TabIndex = 5;
			this.linkForgetPassword.TabStop = true;
			this.linkForgetPassword.Text = "Forgot password";
			this.linkForgetPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForgetPassword_LinkClicked);
			// 
			// tabChangePassword
			// 
			this.tabChangePassword.Controls.Add(this.txtUserName2);
			this.tabChangePassword.Controls.Add(this.label6);
			this.tabChangePassword.Controls.Add(this.txtConfirm);
			this.tabChangePassword.Controls.Add(this.label5);
			this.tabChangePassword.Controls.Add(this.txtCurrentPassword);
			this.tabChangePassword.Controls.Add(this.txtNewPassword);
			this.tabChangePassword.Controls.Add(this.button1);
			this.tabChangePassword.Controls.Add(this.label3);
			this.tabChangePassword.Controls.Add(this.btnChangePassword);
			this.tabChangePassword.Controls.Add(this.label4);
			this.tabChangePassword.Location = new System.Drawing.Point(4, 22);
			this.tabChangePassword.Name = "tabChangePassword";
			this.tabChangePassword.Padding = new System.Windows.Forms.Padding(3);
			this.tabChangePassword.Size = new System.Drawing.Size(294, 164);
			this.tabChangePassword.TabIndex = 1;
			this.tabChangePassword.Text = "Change Password";
			this.tabChangePassword.UseVisualStyleBackColor = true;
			// 
			// txtUserName2
			// 
			this.txtUserName2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtUserName2.Location = new System.Drawing.Point(105, 10);
			this.txtUserName2.Name = "txtUserName2";
			this.txtUserName2.Size = new System.Drawing.Size(166, 20);
			this.txtUserName2.TabIndex = 17;
			this.txtUserName2.TextChanged += new System.EventHandler(this.txtUserName2_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(35, 14);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 13);
			this.label6.TabIndex = 18;
			this.label6.Text = "User Name:";
			// 
			// txtConfirm
			// 
			this.txtConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtConfirm.Location = new System.Drawing.Point(104, 94);
			this.txtConfirm.Name = "txtConfirm";
			this.txtConfirm.PasswordChar = '●';
			this.txtConfirm.Size = new System.Drawing.Size(165, 20);
			this.txtConfirm.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(53, 98);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Confirm:";
			// 
			// txtCurrentPassword
			// 
			this.txtCurrentPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCurrentPassword.Location = new System.Drawing.Point(104, 38);
			this.txtCurrentPassword.Name = "txtCurrentPassword";
			this.txtCurrentPassword.PasswordChar = '●';
			this.txtCurrentPassword.Size = new System.Drawing.Size(166, 20);
			this.txtCurrentPassword.TabIndex = 0;
			// 
			// txtNewPassword
			// 
			this.txtNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNewPassword.Location = new System.Drawing.Point(104, 66);
			this.txtNewPassword.Name = "txtNewPassword";
			this.txtNewPassword.PasswordChar = '●';
			this.txtNewPassword.Size = new System.Drawing.Size(165, 20);
			this.txtNewPassword.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.BackgroundImage = global::Archer.Properties.Resources.Cancel;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(167, 122);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(46, 30);
			this.button1.TabIndex = 4;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Current Password:";
			// 
			// btnChangePassword
			// 
			this.btnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChangePassword.Image = global::Archer.Properties.Resources.OK;
			this.btnChangePassword.Location = new System.Drawing.Point(224, 122);
			this.btnChangePassword.Name = "btnChangePassword";
			this.btnChangePassword.Size = new System.Drawing.Size(46, 30);
			this.btnChangePassword.TabIndex = 3;
			this.btnChangePassword.UseVisualStyleBackColor = true;
			this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(81, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "New Password:";
			// 
			// AccountManager
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(302, 190);
			this.Controls.Add(this.tabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(279, 149);
			this.Name = "AccountManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Account Manager";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccountManager_FormClosed);
			this.Shown += new System.EventHandler(this.AccountManager_Shown);
			this.tabControl.ResumeLayout(false);
			this.tabAccount.ResumeLayout(false);
			this.tabAccount.PerformLayout();
			this.tabChangePassword.ResumeLayout(false);
			this.tabChangePassword.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.LinkLabel linkRegister;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabAccount;
		private System.Windows.Forms.TabPage tabChangePassword;
		private System.Windows.Forms.TextBox txtConfirm;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCurrentPassword;
		private System.Windows.Forms.TextBox txtNewPassword;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnChangePassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkForgetPassword;
		private System.Windows.Forms.TextBox txtUserName2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnRecover;
		private System.Windows.Forms.Button btnBackup;
		private System.Windows.Forms.ToolTip toolTip;

	}
}