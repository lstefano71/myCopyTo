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
			this.prgBarMain = new System.Windows.Forms.ProgressBar();
			this.prgBarSub = new System.Windows.Forms.ProgressBar();
			this.lblSource = new System.Windows.Forms.Label();
			this.lblTarget = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// prgBarMain
			// 
			this.prgBarMain.Location = new System.Drawing.Point(12, 80);
			this.prgBarMain.Name = "prgBarMain";
			this.prgBarMain.Size = new System.Drawing.Size(569, 23);
			this.prgBarMain.TabIndex = 0;
			this.prgBarMain.UseWaitCursor = true;
			// 
			// prgBarSub
			// 
			this.prgBarSub.Location = new System.Drawing.Point(12, 109);
			this.prgBarSub.Name = "prgBarSub";
			this.prgBarSub.Size = new System.Drawing.Size(569, 23);
			this.prgBarSub.TabIndex = 1;
			this.prgBarSub.UseWaitCursor = true;
			// 
			// lblSource
			// 
			this.lblSource.AutoSize = true;
			this.lblSource.Location = new System.Drawing.Point(12, 9);
			this.lblSource.Name = "lblSource";
			this.lblSource.Size = new System.Drawing.Size(41, 13);
			this.lblSource.TabIndex = 2;
			this.lblSource.Text = "Source";
			// 
			// lblTarget
			// 
			this.lblTarget.AutoSize = true;
			this.lblTarget.Location = new System.Drawing.Point(12, 34);
			this.lblTarget.Name = "lblTarget";
			this.lblTarget.Size = new System.Drawing.Size(38, 13);
			this.lblTarget.TabIndex = 3;
			this.lblTarget.Text = "Target";
			// 
			// frmProgress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(593, 144);
			this.Controls.Add(this.lblTarget);
			this.Controls.Add(this.lblSource);
			this.Controls.Add(this.prgBarSub);
			this.Controls.Add(this.prgBarMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmProgress";
			this.Text = "myCopy";
			this.UseWaitCursor = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.ProgressBar prgBarMain;
		public System.Windows.Forms.ProgressBar prgBarSub;
		private System.Windows.Forms.Label lblSource;
		private System.Windows.Forms.Label lblTarget;
	}
}

