using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ChatClassroom
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var assembly = typeof(Program).Assembly;
			var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
			var id = attribute.Value;

			using (Mutex mutex = new Mutex(false, "Global\\" + id))
			{
				if (!mutex.WaitOne(0, false))
				{
					MessageBox.Show("Program already running", "Program already running!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Login());
			}


		}
	}
}
