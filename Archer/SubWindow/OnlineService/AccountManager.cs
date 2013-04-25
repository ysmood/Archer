using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Archer
{
	public partial class AccountManager : Form
	{
		public AccountManager()
		{
			InitializeComponent();

			this.Font = Main.DefaultFont;

			txtUserName.Text = Main.Setting.UserName;
		}
		public bool OK = false;
		public bool TryAgainWindow
		{
			set
			{
				btnBackup.Enabled = !value;
				btnRecover.Enabled = !value;
			}
			get
			{
				return !btnBackup.Enabled;
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Main.Setting.UserName = txtUserName.Text;
			// MD5
			Main.Setting.Password = ys.Common.Md5Hash(txtPassword.Text);

			OK = true;

			Main.Self.RefreshUI(false);

			this.Close();
		}

		private void btnChangePassword_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtConfirm.Text)
				&& txtNewPassword.Text == txtConfirm.Text)
			{
				ChangePassword();
			}
			else
			{
				Main.Report(Resource.ChangePasswordError);
			}
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ChangePassword()
		{
			ServerContactor sc = new ServerContactor();
			sc.Show(this);
			sc.ChangePassword(ys.Common.Md5Hash(txtConfirm.Text));

			txtNewPassword.Text = string.Empty;
			txtConfirm.Text = string.Empty;
		}

		private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ys.Common.Start(Resource.ArcherRegister);
		}
		private void linkForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ys.Common.Start(Resource.ArcherResetPassword);
		}

		private void btnBackup_Click(object sender, EventArgs e)
		{
			if(Main.Setting.Password == "" ||
				(Main.Setting.Password != "" && txtPassword.Text != "")
			)
				btnOk_Click(null, null);

			Main.Self.Backup(null, null);
			this.Close();
		}
		private void btnRecover_Click(object sender, EventArgs e)
		{
			if (Main.Setting.Password == "" ||
				(Main.Setting.Password != "" && txtPassword.Text != "")
			)
				btnOk_Click(null, null);

			if(ModifierKeys == Keys.Control)
				Main.Self.Recover("RecoveryPrevious", null);
			else
				Main.Self.Recover(null, null);
			this.Close();
		}

		private void AccountManager_Shown(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtUserName.Text))
			{
				txtUserName.Focus();
			}
			else
			{
				txtPassword.Focus();
			}
		}

		private void AccountManager_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Dispose();
		}

	}
}
