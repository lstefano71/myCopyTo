using SharpShell.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCopyTo
{
	[ComVisible(true)]
	[COMServerAssociation(AssociationType.FileExtension,".mycopy")]
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
			var frm = new frmProgress();
			frm.Show();
			frm.prgBar.Minimum = 1;
			frm.prgBar.Maximum = DragItems.Count();
			var c = 1;
			// TODO: spawn a separate thread for GUI 
			// TOOD: spawn a separate thread for actual copy
			foreach(var source in DragItems) {
				frm.prgBar.Value = c++;
				frm.Text = source;
				var a = File.GetAttributes(source);
				if (a.HasFlag(FileAttributes.Directory)) {
					var t = new DirectoryInfo(Path.Combine(target, Path.GetFileName(source)));					
					CopyFilesRecursively(new DirectoryInfo(source), t);
				} else
					File.Copy(source, Path.Combine(target, Path.GetFileName(source)));
			}
			frm.Close();
		}
		static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
		{
			var od = source.LastWriteTimeUtc;
			target.Create();
			foreach (DirectoryInfo dir in source.GetDirectories()) {
				try {
					CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
				} catch (Exception ex) {
					MessageBox.Show(ex.ToString());
				}				
			}
			foreach (FileInfo file in source.GetFiles()) {				
				try {
					CopyTo(file, Path.Combine(target.FullName, file.Name));
				} catch(Exception ex) {
					MessageBox.Show(ex.ToString());
				}
			}
			target.LastWriteTimeUtc = od;
			source.LastAccessTimeUtc = od;
		}

		private static void CopyTo(FileInfo source, string target)
		{
			var od = source.LastWriteTimeUtc;
			var on = source.FullName;
			source.MoveTo(on + ".xxx");
			source.Refresh();
			var tot = source.Length;
			var buflen = 8192;
			var buf = new byte[buflen];			
			using (var s = source.OpenRead())
			using (var t = File.OpenWrite(target)) {
				t.SetLength(tot);
				t.Seek(0, SeekOrigin.Begin);
				while(tot>0) {
					var toread = (int) Math.Min(buflen, tot);
					var r = s.Read(buf, 0, toread);
					t.Write(buf, 0, r);
					tot -= r;
				}
			}
			File.SetLastWriteTimeUtc(target, od);
			source.MoveTo(on);
		}
	}
}
