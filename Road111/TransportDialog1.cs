using System;
using Gtk;
namespace Road111
{
    public partial class TransportDialog1 : Gtk.Dialog
    {
        private int road;
        private Fuel fuel;
        private Strip strip;
        private bool tOk = false;
        private bool fOk = false;
        private ExTWindow eror;
        private Vehicle transport;
        public TransportDialog1(int r,Strip st)
        {
            this.road = r;
            this.strip = new Strip(st.Type);
            Build();
            buttonOk.Sensitive = false;
            if (MainClass.getSystem().getFuelList().Count>0)
            {
                buttonOk.Sensitive = true;
                foreach (Fuel value in MainClass.getSystem().getFuelList())
                {
                    if(value.Equals(new Fuel("Бензин")))
                    {
                        this.benzin_rad.Sensitive = true;
                    }
                    if (value.Equals(new Fuel("Дизель")))
                    {
                        this.dizel_rad.Sensitive = true;
                    }
                    if (value.Equals(new Fuel("Электричество")))
                    {
                        this.electro_rad.Sensitive = true;
                    }
                    if (value.Equals(new Fuel("Газ")))
                    {
                        this.gas_rad.Sensitive = true;
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
                    fuel = new Fuel("Бензин");
                }
                if (this.dizel_rad.Active)
                {
                    fuel = new Fuel("Дизель");
                }
                if (this.electro_rad.Active)
                {
                    fuel = new Fuel("Электричество");
                }
                if (this.gas_rad.Active)
                {
                    fuel = new Fuel("Газ");
                }
            }
            if(car_rad.Active)
            {
                MainClass.getSystem().getTransportList().Insert(road, new Car());
                transport = MainClass.getSystem().getTransportList()[road];
            }
            if (truck_rad.Active)
            {
                
                MainClass.getSystem().getTransportList().Insert(road,new Truck());
                transport = MainClass.getSystem().getTransportList()[road];
            }
            if (loader_rad.Active)
            {
                
                MainClass.getSystem().getTransportList().Insert(road, new Loader());
                transport = MainClass.getSystem().getTransportList()[road];

            }
            if (bus_rad.Active)
            {
                
                MainClass.getSystem().getTransportList().Insert(road, new Bus());
                transport = MainClass.getSystem().getTransportList()[road];

            }
            if (troll_rad.Active)
            {
              
                MainClass.getSystem().getTransportList().Insert(road, new Trolleybus());
                transport = MainClass.getSystem().getTransportList()[road];

            }
            if (moto_rad.Active)
            {
                MainClass.getSystem().getTransportList().Insert(road, new Moto());
                transport = MainClass.getSystem().getTransportList()[road];

            }
            if (horse_rad.Active)
            {
                MainClass.getSystem().getTransportList().Insert(road, new Horse());
                transport = MainClass.getSystem().getTransportList()[road];
            }
            if(tram_rad.Active)
            {
                MainClass.getSystem().getTransportList().Insert(road, new Tram());
                transport = MainClass.getSystem().getTransportList()[road];
            }
            checkStrip();
            if (fOk && tOk)
            {
                MainClass.getWin().addTsN();
                MainClass.getWin().setFuelLabel(fuel.GetFuel(), road);
                MainClass.getSystem().getTransportList()[road].Fuel = fuel;
                MainClass.getWin().setTsLabel(transport.Name, road, transport.MaxSpeed);
                this.QueueDraw();
                this.Hide();
            }
            else
            {

                eror = new ExTWindow();
                eror.Show();
                this.Destroy();
            }
                
        }

        protected void Cancel_Button(object sender, EventArgs e)
        {
            this.Destroy();
        }
        private void checkStrip()
        {
            foreach (Strip value in transport.stripList())
            {
                if (value.Equals(strip))
                {
                    tOk = true;
                }

            }
            foreach (Fuel value in transport.FuelList())
            {
                if (value.Equals(fuel))
                {
                    fOk = true;
                }
            }
        }
    }
}
