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
	class Copier
	{
		frmProgress _frm;
		string[] _sources;
		string _target;
		byte[] buf = new byte[524288];

		public Copier(string[] sources, string target)
		{
			_sources = sources;
			_target = target;
		}

		public Copier() : base()
		{
		}

		public async Task Go()
		{
			_frm = new frmProgress();
			_frm.Show();
			try {
				await GoCopy();
			} catch (Exception ex) {
				myLog(ex.ToString());
			} finally {
				_frm.Close();
			}
		}

		static void myLog(string message)
		{
			Debugger.Log(0, "", "myCopy: " + message);
		}

		async Task GoCopy()
		{
			var c = 0;
			_frm.ProgressAddSteps(_sources.Length);
			foreach (var source in _sources) {
				if (_frm.Canceled)
					return;
				_frm.StatStart();
				myLog($"source: {source}");
				_frm.ProgressMain(source);
				var a = File.GetAttributes(source);
				if (a.HasFlag(FileAttributes.Directory)) {
					var t = new DirectoryInfo(Path.Combine(_target, Path.GetFileName(source)));
					await CopyFilesRecursively(new DirectoryInfo(source), t); 
				} else {
					var tf = Path.Combine(_target, Path.GetFileName(source));
					await CopyTo(new FileInfo(source), tf); 
				}
			}
			myLog($"Copied: {c} objects");
		}
		async Task CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
		{
			myLog($"Copy: {source.FullName}");
			var od = source.LastWriteTimeUtc;
			target.Create();
			var dirs = source.GetDirectories();
			_frm.ProgressAddSteps(dirs.Length);
			foreach (var dir in dirs) {
				_frm.ProgressMain();
				if (_frm.Canceled)
					return;
				try {
					await CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
				} catch (Exception ex) {
					if (DialogResult.Cancel == MessageBox.Show(ex.ToString(), dir.FullName, MessageBoxButtons.OKCancel)) {
						return;
					}
				}
			}
			_frm.StatStart();
			var files = source.GetFiles();
			_frm.ProgressAddSteps(files.Length);
			foreach (var file in files) {
				_frm.ProgressMain();
				if (_frm.Canceled)
					return;
				try {
					await CopyTo(file, Path.Combine(target.FullName, file.Name));
				} catch (Exception ex) {
					if (DialogResult.Cancel == MessageBox.Show(ex.ToString(), file.FullName, MessageBoxButtons.OKCancel)) {
						return;
					}
				}
			}
			await Task.WhenAll(SetDate(target, od), SetDate(source, od));
		}

		private static async Task SetDate(DirectoryInfo target, DateTime od)
		{
			var done = false;
			var tried = 0;
			while (!done) {
				try {
					target.LastWriteTimeUtc = od;
					done = true;
				} catch {
					myLog($"SetDate: {target.FullName}, tried: {tried}");
					await Task.Delay(100);
					tried++;
					if (tried > 10)
						done = true;
				}
			}
		}

		private static async Task SetDate(string target, DateTime od)
		{
			var done = false;
			var tried = 0;
			while (!done) {
				try {
					File.SetLastWriteTimeUtc(target, od);
					done = true;
				} catch {
					myLog($"SetDate: {target}, tried: {tried}");
					await Task.Delay(100);
					tried++;
					if (tried > 10)
						done = true;
				}
			}
		}

		private async Task CopyTo(FileInfo source, string target)
		{
			if (_frm.Canceled)
				return;

			myLog($"CopyTo: {source.FullName}");
			var od = source.LastWriteTimeUtc;
			var on = source.FullName;
			var tot = source.Length;
			_frm.ProgressSubStart(tot, source.FullName, target, buf.Length);
			long copied = 0;
			source.MoveTo(on + ".xxx");
			using (var s = source.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var t = File.OpenWrite(target + ".xxx")) {
				t.SetLength(0);
				t.Seek(0, SeekOrigin.Begin);
				while (tot - copied > 0 && !_frm.Canceled) {
					_frm.ProgressSub(copied, buf.Length);
					var toread = (int)Math.Min(buf.Length, tot);
					var r = await s.ReadAsync(buf, 0, toread);
					await t.WriteAsync(buf, 0, r);
					copied += r;
					_frm.StatAddBytes(r);
				}
			}

			source.MoveTo(on);
			if (File.Exists(target))
				File.Delete(target);

			File.Move(target + ".xxx", target);
			if (_frm.Canceled)
				File.Delete(target);
			else 
				await SetDate(target, od);
		}

	}

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
