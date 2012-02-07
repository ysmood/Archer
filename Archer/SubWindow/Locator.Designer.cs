namespace Archer
{
	partial class Locator
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param strName="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
			this.cbInput = new System.Windows.Forms.ComboBox();
			this.btnPre = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.ckbMatchCase = new System.Windows.Forms.CheckBox();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// cbInput
			// 
			this.cbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
			this.cbInput.FormattingEnabled = true;
			this.cbInput.Location = new System.Drawing.Point(7, 12);
			this.cbInput.Name = "cbInput";
			this.cbInput.Size = new System.Drawing.Size(259, 21);
			this.cbInput.TabIndex = 0;
			// 
			// btnPre
			// 
			this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPre.Location = new System.Drawing.Point(110, 38);
			this.btnPre.Name = "btnPre";
			this.btnPre.Size = new System.Drawing.Size(75, 23);
			this.btnPre.TabIndex = 2;
			this.btnPre.Text = "Previous";
			this.toolTip.SetToolTip(this.btnPre, "Enter");
			this.btnPre.UseVisualStyleBackColor = true;
			this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(191, 38);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 23);
			this.btnNext.TabIndex = 1;
			this.btnNext.Text = "Next";
			this.toolTip.SetToolTip(this.btnNext, "Ctrl + Enter");
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// ckbMatchCase
			// 
			this.ckbMatchCase.AutoSize = true;
			this.ckbMatchCase.Location = new System.Drawing.Point(12, 42);
			this.ckbMatchCase.Name = "ckbMatchCase";
			this.ckbMatchCase.Size = new System.Drawing.Size(82, 17);
			this.ckbMatchCase.TabIndex = 3;
			this.ckbMatchCase.Text = "Match case";
			this.ckbMatchCase.UseVisualStyleBackColor = true;
			// 
			// Locator
			// 
			this.AcceptButton = this.btnPre;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(273, 72);
			this.Controls.Add(this.ckbMatchCase);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPre);
			this.Controls.Add(this.cbInput);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(289, 103);
			this.Name = "Locator";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Locator";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Locator_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbInput;
		private System.Windows.Forms.Button btnPre;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.CheckBox ckbMatchCase;
		private System.Windows.Forms.ToolTip toolTip;
	}
}