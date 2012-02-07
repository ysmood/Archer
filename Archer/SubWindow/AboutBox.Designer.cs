namespace Archer
{
	partial class AboutBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			this.labelProductName = new System.Windows.Forms.Label();
			this.labelCopyright = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lnkArcherHome = new System.Windows.Forms.LinkLabel();
			this.lnkProjectHome = new System.Windows.Forms.LinkLabel();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.panel1, 0, 2);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 3;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(208, 86);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logoPictureBox.Image = global::Archer.Properties.Resources.ys;
			this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
			this.logoPictureBox.Name = "logoPictureBox";
			this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 2);
			this.logoPictureBox.Size = new System.Drawing.Size(44, 50);
			this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.logoPictureBox.TabIndex = 12;
			this.logoPictureBox.TabStop = false;
			// 
			// labelProductName
			// 
			this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelProductName.Location = new System.Drawing.Point(56, 12);
			this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 12, 3, 0);
			this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new System.Drawing.Size(149, 16);
			this.labelProductName.TabIndex = 19;
			this.labelProductName.Text = "Product Name and Version";
			// 
			// labelCopyright
			// 
			this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelCopyright.Location = new System.Drawing.Point(56, 38);
			this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 10, 3, 0);
			this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size(149, 17);
			this.labelCopyright.TabIndex = 21;
			this.labelCopyright.Text = "Copyright";
			// 
			// panel1
			// 
			this.tableLayoutPanel.SetColumnSpan(this.panel1, 2);
			this.panel1.Controls.Add(this.lnkArcherHome);
			this.panel1.Controls.Add(this.lnkProjectHome);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 59);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(202, 24);
			this.panel1.TabIndex = 25;
			// 
			// lnkArcherHome
			// 
			this.lnkArcherHome.ActiveLinkColor = System.Drawing.Color.MediumSpringGreen;
			this.lnkArcherHome.AutoSize = true;
			this.lnkArcherHome.LinkColor = System.Drawing.Color.DodgerBlue;
			this.lnkArcherHome.Location = new System.Drawing.Point(3, 3);
			this.lnkArcherHome.Name = "lnkArcherHome";
			this.lnkArcherHome.Size = new System.Drawing.Size(69, 13);
			this.lnkArcherHome.TabIndex = 27;
			this.lnkArcherHome.TabStop = true;
			this.lnkArcherHome.Text = "Archer Home";
			this.lnkArcherHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkArcherHome_LinkClicked);
			// 
			// lnkProjectHome
			// 
			this.lnkProjectHome.ActiveLinkColor = System.Drawing.Color.MediumSpringGreen;
			this.lnkProjectHome.AutoSize = true;
			this.lnkProjectHome.LinkColor = System.Drawing.Color.DodgerBlue;
			this.lnkProjectHome.Location = new System.Drawing.Point(78, 3);
			this.lnkProjectHome.Name = "lnkProjectHome";
			this.lnkProjectHome.Size = new System.Drawing.Size(71, 13);
			this.lnkProjectHome.TabIndex = 26;
			this.lnkProjectHome.TabStop = true;
			this.lnkProjectHome.Text = "Project Home";
			this.lnkProjectHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProjectHome_LinkClicked);
			// 
			// AboutBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(214, 92);
			this.Controls.Add(this.tableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AboutBox_KeyDown);
			this.tableLayoutPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelProductName;
		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.PictureBox logoPictureBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.LinkLabel lnkProjectHome;
		private System.Windows.Forms.LinkLabel lnkArcherHome;
	}
}
