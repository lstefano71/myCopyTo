using SharpShell.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCopyTo
{

	[ComVisible(true)]
	[COMServerAssociation(AssociationType.FileExtension, ".mycopy")]
	class CopyDropHandler : SharpShell.SharpDropHandler.SharpDropHandler
	{
		protected override void DragEnter(DragEventArgs dragEventArgs)
		{
			dragEventArgs.Effect = DragDropEffects.Copy;
		}

		protected override void Drop(DragEventArgs dragEventArgs)
		{
			var target = Path.GetDirectoryName(SelectedItemPath);
			target = Path.Combine(target, Path.GetFileNameWithoutExtension(SelectedItemPath));
			var sources = DragItems.ToArray();

			new Copier(sources, target).Go();
		}
	}

}
