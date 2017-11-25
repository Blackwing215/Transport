using System;
using Gtk;
using Glade;
using System.Collections.Generic;
namespace Road111
{
	class MainClass
	{     
        public static List<Fuel> listF = new List<Fuel>();
        public static MainWindow win;
		public static void Main(string[] args)
		{
      		Application.Init();
            win = new MainWindow();
            win.Show();
			Application.Run();
		}
	}
}
