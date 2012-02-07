namespace Archer
{
	partial class ServerContactor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerContactor));
			this.txtState = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtState
			// 
			this.txtState.BackColor = System.Drawing.Color.White;
			this.txtState.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtState.Location = new System.Drawing.Point(0, 0);
			this.txtState.Multiline = true;
			this.txtState.Name = "txtState";
			this.txtState.ReadOnly = true;
			this.txtState.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtState.Size = new System.Drawing.Size(344, 162);
			this.txtState.TabIndex = 2;
			this.txtState.Text = ">> Connect to server...";
			// 
			// ServerContactor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(344, 162);
			this.Controls.Add(this.txtState);
			this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "ServerContactor";
			this.Text = "Server Contactor";
			this.Load += new System.EventHandler(this.ServerContactor_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.This_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtState;

	}
}