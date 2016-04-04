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
			this.lblStat = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// prgBarMain
			// 
			this.prgBarMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.prgBarMain.Location = new System.Drawing.Point(12, 117);
			this.prgBarMain.Name = "prgBarMain";
			this.prgBarMain.Size = new System.Drawing.Size(569, 23);
			this.prgBarMain.TabIndex = 0;
			this.prgBarMain.UseWaitCursor = true;
			// 
			// prgBarSub
			// 
			this.prgBarSub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.prgBarSub.Location = new System.Drawing.Point(12, 146);
			this.prgBarSub.Name = "prgBarSub";
			this.prgBarSub.Size = new System.Drawing.Size(569, 23);
			this.prgBarSub.TabIndex = 1;
			this.prgBarSub.UseWaitCursor = true;
			// 
			// lblSource
			// 
			this.lblSource.AutoSize = true;
			this.lblSource.Location = new System.Drawing.Point(12, 9);
			this.lblSource.MaximumSize = new System.Drawing.Size(569, 0);
			this.lblSource.Name = "lblSource";
			this.lblSource.Size = new System.Drawing.Size(41, 13);
			this.lblSource.TabIndex = 2;
			this.lblSource.Text = "Source";
			this.lblSource.UseWaitCursor = true;
			// 
			// lblTarget
			// 
			this.lblTarget.AutoSize = true;
			this.lblTarget.Location = new System.Drawing.Point(12, 47);
			this.lblTarget.MaximumSize = new System.Drawing.Size(569, 0);
			this.lblTarget.Name = "lblTarget";
			this.lblTarget.Size = new System.Drawing.Size(38, 13);
			this.lblTarget.TabIndex = 3;
			this.lblTarget.Text = "Target";
			this.lblTarget.UseWaitCursor = true;
			// 
			// lblStat
			// 
			this.lblStat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStat.AutoSize = true;
			this.lblStat.Location = new System.Drawing.Point(12, 91);
			this.lblStat.Name = "lblStat";
			this.lblStat.Size = new System.Drawing.Size(24, 13);
			this.lblStat.TabIndex = 4;
			this.lblStat.Text = "0/0";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(505, 91);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmProgress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(593, 181);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblStat);
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
			this.Load += new System.EventHandler(this.frmProgress_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.ProgressBar prgBarMain;
		public System.Windows.Forms.ProgressBar prgBarSub;
		private System.Windows.Forms.Label lblSource;
		private System.Windows.Forms.Label lblTarget;
		private System.Windows.Forms.Label lblStat;
		private System.Windows.Forms.Button btnCancel;
	}
}

