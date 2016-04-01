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

		public void Progress(int value, string filename)
		{
			prgBar.Invoke(
				new Action(()=> {
					prgBar.Value = value;
					this.Text = filename;
				})
			);
		}
	}
}
