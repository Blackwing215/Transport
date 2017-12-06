using System;
using Gtk;
namespace Road111
{
    public partial class TransportDialog1 : Gtk.Dialog
    {
        private int road;
        private Fuel fuel;
        private Strip strip;
        public TransportDialog1(int r,Strip st)
        {
            this.road = r;
            this.strip = st;
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
                    MainClass.getWin().setFuelLabel("Бензин", road);
                    fuel = new Fuel("Бензин");
                }
                if (this.dizel_rad.Active)
                {
                    MainClass.getWin().setFuelLabel("Дизель",road);
                    fuel = new Fuel("Дизель");
                }
                if (this.electro_rad.Active)
                {
                    MainClass.getWin().setFuelLabel("Электричество",road);
                    fuel = new Fuel("Электричество");
                }
                if (this.gas_rad.Active)
                {
                    MainClass.getWin().setFuelLabel("Газ", road);
                    fuel = new Fuel("Газ");
                }
            }
            if(car_rad.Active)
            {
                foreach(Strip value in Vehicle.stripList())
                {
                }
                MainClass.getSystem().getTransportList().Insert(road-1,new Car());
                MainClass.getWin().setTsLabel("Автомобиль", road,MainClass.getSystem().getTransportList()[road-1].MaxSpeed);
            }
            if (truck_rad.Active)
            {
                MainClass.getSystem().getTransportList().Insert(road-1,new Truck());
                MainClass.getWin().setTsLabel("Грузовик", road,MainClass.getSystem().getTransportList()[road-1].MaxSpeed);
            }
            if (loader_rad.Active)
            {
                MainClass.getSystem().getTransportList().Insert(road - 1, new Loader());
                MainClass.getWin().setTsLabel("Погрузчик", road,MainClass.getSystem().getTransportList()[road - 1].MaxSpeed);
            }
            if (bus_rad.Active)
            {
                MainClass.getSystem().getTransportList().Insert(road - 1, new Bus());
                MainClass.getWin().setTsLabel("Автобус", road,MainClass.getSystem().getTransportList()[road - 1].MaxSpeed);
            }
            if (troll_rad.Active)
            {
                MainClass.getSystem().getTransportList().Insert(road - 1, new Trolleybus());
                MainClass.getWin().setTsLabel("Троллейбус", road,MainClass.getSystem().getTransportList()[road - 1].MaxSpeed);
            }
            if (moto_rad.Active)
            {
                MainClass.getSystem().getTransportList().Insert(road - 1, new Moto());
                MainClass.getWin().setTsLabel("Мотоцикл", road,MainClass.getSystem().getTransportList()[road - 1].MaxSpeed);
            }
            if (horse_rad.Active)
            {
                MainClass.getSystem().getTransportList().Insert(road - 1, new Horse());
                MainClass.getWin().setTsLabel("Гужевая повозка", road,MainClass.getSystem().getTransportList()[road - 1].MaxSpeed);
            }
            if(tram_rad.Active)
            {
                MainClass.getSystem().getTransportList().Insert(road - 1, new Tram());
                MainClass.getWin().setTsLabel("Трамвай", road, MainClass.getSystem().getTransportList()[road - 1].MaxSpeed);
            }
            this.QueueDraw();
            this.Hide();
        }

        protected void Cancel_Button(object sender, EventArgs e)
        {
            this.Destroy();
        }
    }
}
