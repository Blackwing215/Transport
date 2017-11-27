using System;
using Gtk;
using Glade;
using System.Collections.Generic;
namespace Road111
{
	class MainClass
	{
        private static Sys system;
        private static  MainWindow win;
		public static void Main(string[] args)
		{
            system = new Sys();
      		Application.Init();
            win = new MainWindow();
            win.Show();
			Application.Run();
		}
        public static MainWindow getWin()
        {
            return win;
        }
        public static Sys getSystem()
        {
            return system;
        }
	}
}
