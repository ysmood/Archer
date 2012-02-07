namespace Archer
{
	partial class ScriptConsole
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptConsole));
			this.toolStripCmd = new System.Windows.Forms.ToolStrip();
			this.btnRunScript = new System.Windows.Forms.ToolStripButton();
			this.btnOutput = new System.Windows.Forms.ToolStripButton();
			this.btnTopMost = new System.Windows.Forms.ToolStripButton();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.txtCode = new ICSharpCode.TextEditor.TextEditorControl();
			this.toolStripCmd.SuspendLayout();
			this.panelBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripCmd
			// 
			this.toolStripCmd.BackColor = System.Drawing.Color.White;
			this.toolStripCmd.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRunScript,
            this.btnOutput,
            this.btnTopMost});
			this.toolStripCmd.Location = new System.Drawing.Point(0, 0);
			this.toolStripCmd.Name = "toolStripCmd";
			this.toolStripCmd.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStripCmd.Size = new System.Drawing.Size(584, 25);
			this.toolStripCmd.TabIndex = 4;
			// 
			// btnRunScript
			// 
			this.btnRunScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRunScript.Image = ((System.Drawing.Image)(resources.GetObject("btnRunScript.Image")));
			this.btnRunScript.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRunScript.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
			this.btnRunScript.Name = "btnRunScript";
			this.btnRunScript.Size = new System.Drawing.Size(85, 22);
			this.btnRunScript.Text = "Run Script(F5)";
			this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
			// 
			// btnOutput
			// 
			this.btnOutput.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnOutput.Image")));
			this.btnOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOutput.Name = "btnOutput";
			this.btnOutput.Size = new System.Drawing.Size(66, 22);
			this.btnOutput.Text = "&Output(O)";
			this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
			// 
			// btnTopMost
			// 
			this.btnTopMost.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnTopMost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnTopMost.Image = ((System.Drawing.Image)(resources.GetObject("btnTopMost.Image")));
			this.btnTopMost.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTopMost.Name = "btnTopMost";
			this.btnTopMost.Size = new System.Drawing.Size(77, 22);
			this.btnTopMost.Text = "&Top Most(T)";
			this.btnTopMost.Click += new System.EventHandler(this.btnTopMost_Click);
			// 
			// panelBottom
			// 
			this.panelBottom.BackColor = System.Drawing.Color.White;
			this.panelBottom.Controls.Add(this.txtCode);
			this.panelBottom.Controls.Add(this.toolStripCmd);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBottom.Location = new System.Drawing.Point(0, 0);
			this.panelBottom.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(584, 362);
			this.panelBottom.TabIndex = 1;
			// 
			// txtCode
			// 
			this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCode.IsReadOnly = false;
			this.txtCode.Location = new System.Drawing.Point(0, 25);
			this.txtCode.Margin = new System.Windows.Forms.Padding(0);
			this.txtCode.Name = "txtCode";
			this.txtCode.ShowVRuler = false;
			this.txtCode.Size = new System.Drawing.Size(584, 337);
			this.txtCode.TabIndex = 5;
			// 
			// ScriptConsole
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 362);
			this.Controls.Add(this.panelBottom);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "ScriptConsole";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Script Console";
			this.Load += new System.EventHandler(this.ScriptConsole_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScriptConsole_KeyDown);
			this.toolStripCmd.ResumeLayout(false);
			this.toolStripCmd.PerformLayout();
			this.panelBottom.ResumeLayout(false);
			this.panelBottom.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripCmd;
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.ToolStripButton btnRunScript;
		private System.Windows.Forms.ToolStripButton btnOutput;
		private System.Windows.Forms.ToolStripButton btnTopMost;
		private ICSharpCode.TextEditor.TextEditorControl txtCode;
	}
}