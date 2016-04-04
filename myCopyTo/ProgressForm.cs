using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCopyTo
{
	public partial class frmProgress : Form
	{
		public frmProgress()
		{
			InitializeComponent();
		}

		public void ProgressMain(int value, string filename)
		{
			Invoke(
				new Action(()=> {
					prgBarMain.Value = value;
					lblSource.Text = filename;
				})
			);
		}

		public void ProgressSub(long value, int step)
		{
			Invoke(
				new Action(() => {
					prgBarSub.Value = (int) (value / step);
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
	}
}
