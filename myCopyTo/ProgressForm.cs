using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCopyTo
{
	public partial class frmProgress : Form
	{
		public bool Canceled = false;
		Stopwatch _timer = new Stopwatch();
		double _total;

		public void StatStart()
		{
			_timer.Restart();
			_total = 0;
		}
		public void StatAddBytes(long bytes)
		{
			Invoke(
				new Action(() => {
					_total += bytes;
					var s = GetSpeed();
					lblStat.Text = $"{FormatByteSize(s)}/s";
				})
			);
		}

		public double GetSpeed()
		{
			// bytes/s
			return _total / _timer.Elapsed.TotalSeconds;
		}

		public frmProgress()
		{
			InitializeComponent();
		}

		public void ProgressMain(string filename)
		{
			ProgressMain();
			Invoke(
				new Action(() => {
					Text = "myCopy: " + filename;
				})
			);
		}

		internal void ProgressMain()
		{
			Invoke(
				new Action(() => {
					prgBarMain.Value++;
				})
			);
		}

		internal void ProgressAddSteps(int steps)
		{
			Invoke(
				new Action(() => {
					prgBarMain.Maximum += steps;
				})
			);

		}

		public void ProgressSub(long value, int step)
		{
			Invoke(
				new Action(() => {
					prgBarSub.Value = (int)(value / step);
				})
			);
		}

		internal void ProgressSubStart(long max, string source, string target, int step)
		{
			Invoke(
				new Action(() => {
					prgBarSub.Maximum = (int)(max / step);
					lblSource.Text = "Source: " + source;
					lblTarget.Text = "Target: " + target;
				})
			);
		}

		public static string FormatByteSize(double fileSize)
		{
			FileSizeUnit unit = FileSizeUnit.B;
			while (fileSize >= 1024 && unit < FileSizeUnit.YB) {
				fileSize = fileSize / 1024;
				unit++;
			}
			return string.Format("{0:0.##} {1}", fileSize, unit);
		}		

		/// <summary>
		/// Converts a numeric value into a string that represents the number expressed as a size value in bytes,
		/// kilobytes, megabytes, or gigabytes, depending on the size.
		/// </summary>
		/// <param name="fileInfo"></param>
		/// <returns>The converted string.</returns>
		public static string FormatByteSize(FileInfo fileInfo)
		{
			return FormatByteSize(fileInfo.Length);
		}
		public enum FileSizeUnit : byte
		{
			B,
			KB,
			MB,
			GB,
			TB,
			PB,
			EB,
			ZB,
			YB
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Canceled = true;
		}

		private void frmProgress_Load(object sender, EventArgs e)
		{
			ControlBox = false;
			prgBarMain.Minimum = 0;
			prgBarMain.Maximum = 0;
			lblStat.Text = "";
		}
	}
}
