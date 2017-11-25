﻿using System;
using Gtk;
using System.Collections.Generic;
using System.Threading;
    public partial class MainWindow : Gtk.Window
    {
    public static bool benzin_label = false;
    public static bool electro_label = false;
    public static bool dizel_label = false;
    public static bool fuel_label = false;
        public static bool progress = false;
        public static bool lab = false;
        public static Road111.FuelList dlg1;
        public static Road111.TransportDialog1 dlg;
        public static bool ts1 = false;
        public static bool fuel_list = false;
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
        if (fuel_list == false)
        {
            fuel_list = true;
            dlg1 = new Road111.FuelList();
        }
            dlg1.Show(); 
        }
    }