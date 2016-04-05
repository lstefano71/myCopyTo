using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCopyTo
{
	static class Program
	{

		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var exe = Assembly.GetEntryAssembly().Location;
			var target = Path.Combine(Path.GetDirectoryName(exe), Path.GetFileNameWithoutExtension(exe));
			var sources = args;

			var copy = new Copier(sources, target);
			copy.Go().Wait();
		}
	}
}
