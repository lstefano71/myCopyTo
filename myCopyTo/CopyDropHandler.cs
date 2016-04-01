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
			var sources = DragItems.ToArray();
			Task.Run(() => {
				var frm = new frmProgress();
				frm.Show();
				frm.prgBar.Minimum = 1;
				frm.prgBar.Maximum = sources.Length;
				Task.Run(async () => {
					var c = 1;
					foreach (var source in sources) {
						frm.Progress(c++, source);
						var a = File.GetAttributes(source);
						if (a.HasFlag(FileAttributes.Directory)) {
							var t = new DirectoryInfo(Path.Combine(target, Path.GetFileName(source)));
							await CopyFilesRecursively(new DirectoryInfo(source), t);
						} else
							File.Copy(source, Path.Combine(target, Path.GetFileName(source)));
					}
					frm.Close();
				});
			});
		}
		static async Task CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
		{
			var od = source.LastWriteTimeUtc;
			target.Create();
			foreach (DirectoryInfo dir in source.GetDirectories()) {
				try {
					await CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
				} catch (Exception ex) {
					if(DialogResult.Cancel== MessageBox.Show(ex.ToString(),dir.FullName,MessageBoxButtons.OKCancel)) {
						return;
					}
				}				
			}
			foreach (FileInfo file in source.GetFiles()) {				
				try {
					await CopyTo(file, Path.Combine(target.FullName, file.Name));
				} catch(Exception ex) {
					if (DialogResult.Cancel == MessageBox.Show(ex.ToString(), file.FullName, MessageBoxButtons.OKCancel)) {
						return;
					}
				}
			}
			target.LastWriteTimeUtc = od;
			source.LastWriteTimeUtc = od;
		}

		private static async Task CopyTo(FileInfo source, string target)
		{
			var od = source.LastWriteTimeUtc;
			var on = source.FullName;
			source.MoveTo(on + ".xxx");
			source.Refresh();
			var tot = source.Length;
			var buflen = 8192;
			var buf = new byte[buflen];
			using (var s = source.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var t = File.OpenWrite(target)) {
				t.SetLength(0);
				t.Seek(0, SeekOrigin.Begin);
				await s.CopyToAsync(t);
				//while(tot>0) {
				//	var toread = (int) Math.Min(buflen, tot);
				//	var r = s.Read(buf, 0, toread);
				//	t.Write(buf, 0, r);
				//	tot -= r;
				//}
			}
			File.SetLastWriteTimeUtc(target, od);
			source.MoveTo(on);
		}
	}
}
