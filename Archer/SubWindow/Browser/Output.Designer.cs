namespace Archer
{
	partial class Output
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Output));
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtOutput = new ICSharpCode.TextEditor.TextEditorControl();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMostToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(140, 26);
			// 
			// topMostToolStripMenuItem
			// 
			this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
			this.topMostToolStripMenuItem.ShortcutKeyDisplayString = "T";
			this.topMostToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.topMostToolStripMenuItem.Text = "&Top Most";
			this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutput.IsReadOnly = false;
			this.txtOutput.Location = new System.Drawing.Point(0, 0);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ShowMatchingBracket = false;
			this.txtOutput.ShowVRuler = false;
			this.txtOutput.Size = new System.Drawing.Size(484, 262);
			this.txtOutput.TabIndex = 1;
			// 
			// Output
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(484, 262);
			this.ContextMenuStrip = this.contextMenuStrip;
			this.Controls.Add(this.txtOutput);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Output";
			this.Text = "Output";
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem topMostToolStripMenuItem;
		private ICSharpCode.TextEditor.TextEditorControl txtOutput;

	}
}