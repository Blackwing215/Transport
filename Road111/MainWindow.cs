using System;
using Gtk;
using System.Collections.Generic;
using System.Threading;
    public partial class MainWindow : Gtk.Window
    {
  
        public static Road111.FuelList dlg1;
        public static Road111.TransportDialog1 dlg;
        public static bool ts1,ts2 = false;
        public MainWindow() : base(Gtk.WindowType.Toplevel)
        {
            Build();
        }
    public void setFuelLabel(String _name)
    {
        label26.Text = _name;
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
            dlg = new Road111.TransportDialog1();
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
            dlg = new Road111.TransportDialog1();
            dlg.Show();
        }
    }

    protected void OnButton3Clicked(object sender, EventArgs e)
    {
    }

    protected void OnButton4Clicked(object sender, EventArgs e)
    {
    }
}