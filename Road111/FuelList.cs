using System;
using System.Collections.Generic;
namespace Road111
{
    public partial class FuelList : Gtk.Dialog
    {
        public Fuel benzin = new Fuel("Бензин");
        public Fuel electro = new Fuel("Электричество");
        public Fuel dizel = new Fuel("Дизель");
        public FuelList()
        {
            this.Build();
        }

        protected void OnButtonOkClicked(object sender, EventArgs e)
        {
            if(benzin_but.Active)
            {
                MainWindow.fuel_label = true;
                MainWindow.benzin_label = true;
            } 
            if(dizel_but.Active)
            {
                MainWindow.fuel_label = true;
                MainWindow.dizel_label = true;
            } 
            if(electro_but.Active)
            {
                MainWindow.fuel_label = true;
                MainWindow.electro_label = true;
            } 
            this.Hide();
        }
        protected void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Destroy();
        }
    }
}
