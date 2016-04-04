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

		Stopwatch _timer = new Stopwatch();
		double _total;

		public void StatStart()
		{
			_timer.Restart();
			_total = 0;
		}
		public void StatAddBytes(long bytes)
		{
			_total += bytes;
			var s = GetSpeed();
			Invoke(
				new Action(() => {
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

		public void ProgressMain(int value, string filename)
		{
			Invoke(
				new Action(() => {
					prgBarMain.Value = value;
					lblSource.Text = filename;
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
	}
}
