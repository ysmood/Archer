namespace ys.Control
{
	partial class KeyPrompter
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param scriptName="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.txtKeyPrompter = new System.Windows.Forms.TextBox();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// txtKeyPrompter
			// 
			this.txtKeyPrompter.AcceptsReturn = true;
			this.txtKeyPrompter.AcceptsTab = true;
			this.txtKeyPrompter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
			this.txtKeyPrompter.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.txtKeyPrompter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtKeyPrompter.ForeColor = System.Drawing.Color.Gray;
			this.txtKeyPrompter.Location = new System.Drawing.Point(0, 0);
			this.txtKeyPrompter.Multiline = true;
			this.txtKeyPrompter.Name = "txtKeyPrompter";
			this.txtKeyPrompter.ReadOnly = true;
			this.txtKeyPrompter.Size = new System.Drawing.Size(150, 23);
			this.txtKeyPrompter.TabIndex = 6;
			this.txtKeyPrompter.Text = "key code prompter";
			this.txtKeyPrompter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyPrompter.WordWrap = false;
			this.txtKeyPrompter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyPrompter_KeyDown);
			// 
			// KeyPrompter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.txtKeyPrompter);
			this.Name = "KeyPrompter";
			this.Size = new System.Drawing.Size(150, 23);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtKeyPrompter;
		private System.Windows.Forms.ToolTip toolTip;
	}
}
