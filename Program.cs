// Released to the public domain. Use, modify and relicense at will.

using System;
using System.Windows.Forms;

namespace FragmentFun
{
	class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainView());
		}
	}
}