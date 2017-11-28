using System;
using Gtk;
using System.Collections.Generic;
using System.Threading;
    public partial class MainWindow : Gtk.Window
    {
  
        public static Road111.FuelList dlg1;
        public static Road111.TransportDialog1 dlg;
        public static bool ts1,ts2,ts3,ts4,ts5 = false;
        public MainWindow() : base(Gtk.WindowType.Toplevel)
        {
            Build();
        }
    public void setFuelLabel(String _name,int Road)
    {
        if(Road == 1)
        label26.Text = _name;
        if (Road == 2)
            label27.Text = _name;
        if (Road == 3)
            label28.Text = _name;
        if (Road == 4)
            label29.Text = _name;
        if (Road == 5)
            label30.Text = _name;
        QueueDraw();
    }
        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }

        protected void TransportInfo1_clicked(object sender, EventArgs e)
        {
        if (ts1 == false)
        {
            dlg = new Road111.TransportDialog1(1);
            dlg.Show();
        }
           
        }

        protected void ToggleProgress(object sender, EventArgs e)
        {
            progressbar1.Pulse();
            progressbar2.Pulse();
            progressbar3.Pulse();
            progressbar4.Pulse();
            progressbar5.Pulse();
        }
        protected void OnAddFuelListActionActivated(object sender, EventArgs e)
        {
        if (Road111.MainClass.getSystem().getFuelList().Count == 0)
        {
            
            dlg1 = new Road111.FuelList();
        }
            dlg1.Show(); 
        }

    protected void OnButton2Clicked(object sender, EventArgs e)
    {
        if (ts2 == false)
        {
            dlg = new Road111.TransportDialog1(2);
            dlg.Show();
        }
    }

    protected void OnButton3Clicked(object sender, EventArgs e)
    {
        if (ts3 == false)
        {
            dlg = new Road111.TransportDialog1(3);
            dlg.Show();
        }
    }

    protected void OnButton4Clicked(object sender, EventArgs e)
    {
        if (ts4 == false)
        {
            dlg = new Road111.TransportDialog1(4);
            dlg.Show();
        }
    }

    protected void OnButton5Clicked(object sender, EventArgs e)
    {
        if (ts5 == false)
        {
            dlg = new Road111.TransportDialog1(5);
            dlg.Show();
        }
    }
}