using System;
using Gtk;
namespace Road111
{
    public partial class TransportDialog1 : Gtk.Dialog
    {
        private int road;
        public TransportDialog1(int r)
        {
            this.road = r;
            Build();
            if (MainClass.getSystem().getFuelList().Count>0)
            {
                foreach (Fuel value in MainClass.getSystem().getFuelList())
                {
                    if(value.equals(new Fuel("Бензин")))
                    {
                        this.benzin_rad.Sensitive = true;
                    }
                    if (value.equals(new Fuel("Дизель")))
                    {
                        this.dizel_rad.Sensitive = true;
                    }
                    if (value.equals(new Fuel("Электричество")))
                    {
                        this.electro_rad.Sensitive = true;
                    }
                }
                this.QueueDraw();
            }
        }
        protected void Ok_Button(object sender, EventArgs e)
        {
            if (MainClass.getSystem().getFuelList().Count > 0)
            {
                if (this.benzin_rad.Active)
                {
                    MainClass.getWin().setFuelLabel("Бензин",road);
                }
                if (this.dizel_rad.Active)
                {
                    MainClass.getWin().setFuelLabel("Дизель",road);
                }
                if (this.electro_rad.Active)
                {
                    MainClass.getWin().setFuelLabel("Электричество",road);
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
