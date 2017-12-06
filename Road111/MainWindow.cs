using System;
using Gtk;
using System.Collections.Generic;
using System.Threading;
    public partial class MainWindow : Gtk.Window
    {
        public Thread mt;
        public bool thLabel = false;
        public bool startLabel = true;
        public static Road111.FuelList dlg1;
        public static Road111.TransportDialog1 dlg;
        public static bool ts1,ts2,ts3,ts4,ts5 = false;
        public MainWindow() : base(Gtk.WindowType.Toplevel)
        {
            Build();
        }
    public void setTsLabel(String _name,int Road,double Speed)
    {
        if (Road == 1)
        {
            label31.Text = _name;
            label37.Text = Convert.ToString(Speed);
        }
        if (Road == 2)
        {
            label32.Text = _name;
            label36.Text = Convert.ToString(Speed);
        }
        if (Road == 3)
        {
            label33.Text = _name;
            label38.Text = Convert.ToString(Speed);
        }
        if (Road == 4)
        {
            label34.Text = _name;
            label39.Text = Convert.ToString(Speed);
        }
        if (Road == 5)
        {
            label35.Text = _name;
            label40.Text = Convert.ToString(Speed);
        }
        QueueDraw();
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
        String r1name="";
        if (common1.Active)
            r1name = "Обычная";
        if (electrified1.Active)
            r1name = "Электро";
        if (railway1.Active)
            r1name = "Рельсы";
        Road111.Strip r1 = new Road111.Strip(r1name);
        if (ts1 == false)
        {
            dlg = new Road111.TransportDialog1(1,r1);
            dlg.Show();
        }
           
        }

        protected void ToggleProgress(object sender, EventArgs e)
        {
            this.mt = new Thread(pulse);
            this.mt.Start();
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
        String r2name = "";
        if (common2.Active)
            r2name = "Обычная";
        if (electrified2.Active)
            r2name = "Электро";
        if (railway2.Active)
            r2name = "Рельсы";
        Road111.Strip r2 = new Road111.Strip(r2name);
        if (ts2 == false)
        {
            dlg = new Road111.TransportDialog1(2,r2);
            dlg.Show();
        }
    }

    protected void OnButton3Clicked(object sender, EventArgs e)
    {
        String r3name = "";
        if (common3.Active)
            r3name = "Обычная";
        if (electrified2.Active)
            r3name = "Электро";
        if (railway3.Active)
            r3name = "Рельсы";
        Road111.Strip r3 = new Road111.Strip(r3name);
        if (ts3 == false)
        {
            dlg = new Road111.TransportDialog1(3,r3);
            dlg.Show();
        }
    }

    protected void OnButton4Clicked(object sender, EventArgs e)
    {
        String r4name = "";
        if (common4.Active)
            r4name = "Обычная";
        if (electrified4.Active)
            r4name = "Электро";
        if (railway4.Active)
            r4name = "Рельсы";
        Road111.Strip r4 = new Road111.Strip(r4name);
        if (ts4 == false)
        {
            dlg = new Road111.TransportDialog1(4,r4);
            dlg.Show();
        }
    }

    protected void OnButton5Clicked(object sender, EventArgs e)
    {
        String r5name = "";
        if (common5.Active)
            r5name = "Обычная";
        if (electrified5.Active)
            r5name = "Электро";
        if (railway5.Active)
            r5name = "Рельсы";
        Road111.Strip r5 = new Road111.Strip(r5name);
        if (ts5 == false)
        {
            dlg = new Road111.TransportDialog1(5,r5);
            dlg.Show();
        }
    }
    public void pulse()
    {
        for (int i = 0; i < 100;i++)
        {
            progressbar1.Pulse();
            progressbar2.Pulse();
            progressbar3.Pulse();
            progressbar4.Pulse();
            progressbar5.Pulse();
            QueueDraw();
            Thread.Sleep(100);
        }
    }
}