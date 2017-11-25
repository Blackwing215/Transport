using System;
using Gtk;
namespace Road111
{
    public partial class TransportDialog1 : Gtk.Dialog
    {
        public static bool ben = false;
        public TransportDialog1()
        {
            Build();
            if (MainWindow.fuel_label)
            {
                entry9.Sensitive = true;
                if (MainWindow.benzin_label)
                {
                    this.benzin_rad.Sensitive = true;
                }
                if (MainWindow.dizel_label)
                {
                    this.dizel_rad.Sensitive = true;
                }
                if (MainWindow.electro_label)
                {
                    this.electro_rad.Sensitive = true;
                }
                this.QueueDraw();
            }
        }
        protected void Ok_Button(object sender, EventArgs e)
        {
            if (MainWindow.fuel_label)
            {
                if (this.benzin_rad.Active)
                {
                    MainClass.win.setFuelLabel("Бензин");
                }
                if (this.dizel_rad.Active)
                {
                    MainClass.win.setFuelLabel("Дизель");
                }
                if (this.electro_rad.Active)
                {
                    MainClass.win.setFuelLabel("Электричество");
                }
                this.QueueDraw();
            }
            this.Hide();
        }

        protected void Cancel_Button(object sender, EventArgs e)
        {
            this.Destroy();
        }
    }
}
