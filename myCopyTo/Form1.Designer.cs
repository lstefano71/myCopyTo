namespace myCopyTo
{
	partial class frmProgress
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
			if (disposing && (components != null)) {
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
			this.prgBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// prgBar
			// 
			this.prgBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.prgBar.Location = new System.Drawing.Point(0, 0);
			this.prgBar.Name = "prgBar";
			this.prgBar.Size = new System.Drawing.Size(593, 35);
			this.prgBar.TabIndex = 0;
			this.prgBar.UseWaitCursor = true;
			// 
			// frmProgress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(593, 35);
			this.Controls.Add(this.prgBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmProgress";
			this.UseWaitCursor = true;
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.ProgressBar prgBar;
	}
}

