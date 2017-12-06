using System;
using System.Collections.Generic;
namespace Road111
{
    public partial class FuelList : Gtk.Dialog
    {
        private Fuel benzin = new Fuel("Бензин");
        private Fuel electro = new Fuel("Электричество");
        private Fuel dizel = new Fuel("Дизель");
        private Fuel gas = new Fuel("Газ");
        public FuelList()
        {         
            this.Build();
        }

        protected void OnButtonOkClicked(object sender, EventArgs e)
        {
            if(benzin_but.Active)
            {
                MainClass.getSystem().addFuel(benzin);
            } 
            if(dizel_but.Active)
            {
                MainClass.getSystem().addFuel(dizel);
           
            } 
            if(electro_but.Active)
            {
                MainClass.getSystem().addFuel(electro);
            } 
            if(gas_but.Active)
            {
                MainClass.getSystem().addFuel(gas);
            } 
            this.Hide();
        }
        protected void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Destroy();
        }
    }
}
