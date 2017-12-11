using System;
namespace Road111
{
    public partial class PropertiWindow : Gtk.Window
    {
        public PropertiWindow(String name) :
                base(Gtk.WindowType.Toplevel)
        {

            this.Build();
            this.Title = name;
        }
        protected void OnButton266Clicked(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void setParametrs(Vehicle ts)
        {
            switch(ts.Name)
            {
                case "Автомобиль":
                    Car car = (Car)ts;
                    this.label6.Text = car.Name;
                    this.label14.Text = car.Type;
                    this.label15.Text = car.Fuel.GetFuel();
                    this.label16.Text = Convert.ToString(car.amFuel);
                    this.label24.Text = Convert.ToString(car.rasF);
                    this.label17.Text = Convert.ToString(car.MaxSpeed);
                    this.label22.Text = Convert.ToString(car.Speed);
                    this.label19.Text = Convert.ToString("-");
                    this.label18.Text = car.Brand;
                    this.label26.Text = Convert.ToString(car.Dist);
                    this.label20.Text = Convert.ToString(car.Pass);
                    break;
                case "Мотоцикл":
                    Moto moto = (Moto)ts;
                    this.label6.Text = moto.Name;
                    this.label14.Text = moto.Type;
                    this.label15.Text = moto.Fuel.GetFuel();
                    this.label16.Text = Convert.ToString(moto.amFuel);
                    this.label24.Text = Convert.ToString(moto.rasF);
                    this.label17.Text = Convert.ToString(moto.MaxSpeed);
                    this.label19.Text = Convert.ToString("-");
                    this.label22.Text = Convert.ToString(moto.Speed);
                    this.label20.Text = "-";
                    this.label18.Text = moto.Brand;
                    break;
                case "Грузовик":
                    Truck truck = (Truck)ts;
                    this.label6.Text = truck.Name;
                    this.label14.Text = truck.Type;
                    this.label15.Text = truck.Fuel.GetFuel();
                    this.label16.Text = truck.amFuel.ToString("G");//Convert.ToString(s.amFuel);
                    this.label24.Text = truck.rasF.ToString("G");//Convert.ToString(s.rasF);
                    this.label17.Text = Convert.ToString(truck.MaxSpeed);
                    this.label22.Text = Convert.ToString(truck.Speed);
                    this.label19.Text = Convert.ToString(truck.Carrying);
                    this.label18.Text = truck.Brand;
                    break;
                case "Погрузчик":
                    Loader loader = (Loader)ts;
                    this.label6.Text = loader.Name;
                    this.label14.Text = loader.Type;
                    this.label15.Text = loader.Fuel.GetFuel();
                    this.label16.Text = loader.amFuel.ToString("G");//Convert.ToString(s.amFuel);
                    this.label24.Text = loader.rasF.ToString("G");//Convert.ToString(s.rasF);
                    this.label17.Text = Convert.ToString(loader.MaxSpeed);
                    this.label22.Text = Convert.ToString(loader.Speed);
                    this.label19.Text = Convert.ToString(loader.Carrying);
                    this.label18.Text = loader.Brand;
                    break;
                case "Автобус":
                    Bus bus = (Bus)ts;
                    this.label6.Text = bus.Name;
                    this.label14.Text = bus.Type;
                    this.label15.Text = bus.Fuel.GetFuel();
                    this.label16.Text = Convert.ToString(bus.amFuel);
                    this.label24.Text = Convert.ToString(bus.rasF);
                    this.label17.Text = Convert.ToString(bus.MaxSpeed);
                    this.label22.Text = Convert.ToString(bus.Speed);
                    this.label19.Text = Convert.ToString("-");
                    this.label18.Text = bus.Brand;
                    this.label26.Text = Convert.ToString(bus.Dist);
                    this.label20.Text = Convert.ToString(bus.Pass);
                    break;
                case "Троллейбус":
                    Trolleybus troll = (Trolleybus)ts;
                    this.label6.Text = troll.Name;
                    this.label14.Text = troll.Type;
                    this.label15.Text = troll.Fuel.GetFuel();
                    this.label16.Text = "-";
                    this.label24.Text = "-";
                    this.label17.Text = Convert.ToString(troll.MaxSpeed);
                    this.label22.Text = Convert.ToString(troll.Speed);
                    this.label19.Text = Convert.ToString("-");
                    this.label18.Text = troll.Brand;
                    this.label26.Text = Convert.ToString(500);
                    this.label20.Text = Convert.ToString(troll.Pass);
                    break;
                case "Трамвай":
                    Tram tram = (Tram)ts;
                    this.label6.Text = tram.Name;
                    this.label14.Text = tram.Type;
                    this.label15.Text = tram.Fuel.GetFuel();
                    this.label16.Text = "-";
                    this.label24.Text = "-";
                    this.label17.Text = Convert.ToString(tram.MaxSpeed);
                    this.label22.Text = Convert.ToString(tram.Speed);
                    this.label19.Text = Convert.ToString("-");
                    this.label18.Text = tram.Brand;
                    this.label26.Text = Convert.ToString(500);
                    this.label20.Text = Convert.ToString(tram.Pass);
                    break;
                case "Гужевая повозка":
                    Horse horse = (Horse)ts;
                    this.label6.Text = horse.Name;
                    this.label14.Text = horse.Type;
                    this.label15.Text = "-";
                    this.label17.Text = Convert.ToString(horse.MaxSpeed);
                    this.label22.Text = Convert.ToString(horse.Speed);
                    this.label19.Text = Convert.ToString(horse.Carrying);
                    this.label18.Text = horse.Brand;
                    break;
            }

            this.QueueDraw();
        }
    }
}
