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
            if(road == 0 || road ==4)
            {
                bike_rad.Sensitive = true;
                radiobutton19.Sensitive = true;
                horse_rad.Sensitive = true;
                this.QueueDraw();
            }
            else
            {
                bike_rad.Sensitive = false;
                radiobutton19.Sensitive = false;
                horse_rad.Sensitive = false; 
                this.QueueDraw();
            }
            if (MainClass.getSystem().getFuelList().Count>0)
            {
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
            
			 if (car_rad.Active && car_rad.Sensitive == true)
			{
				transport = new Car(spinbutton3.Value, spinbutton4.Value, spinbutton1.Value, spinbutton2.Value, spinbutton6.ValueAsInt, entry1.Text);
				Car car = (Car)transport;
				if (car.MaxSpeed < car.Speed)
				{
					transport = null;
				}
			}
            if (truck_rad.Active && truck_rad.Sensitive == true)
			{
				transport = new Truck(spinbutton3.Value, spinbutton4.Value, spinbutton1.Value, spinbutton2.Value, entry1.Text, spinbutton5.Value);
				Truck truck = (Truck)transport;
				if (truck.MaxSpeed < truck.Speed)
				{
					transport = null;
				}

			}
			if (loader_rad.Active && loader_rad.Sensitive == true)
			{
				transport = new Loader(spinbutton3.Value, spinbutton4.Value, spinbutton1.Value, spinbutton2.Value, entry1.Text, spinbutton5.Value);
				Loader loader = (Loader)transport;
				if (loader.MaxSpeed < loader.Speed)
				{
					transport = null;
				}

			}
			if (bus_rad.Active && bus_rad.Sensitive == true)
			{
				transport = new Bus(spinbutton3.Value, spinbutton4.Value, spinbutton1.Value, spinbutton2.Value, spinbutton6.ValueAsInt, entry1.Text);
				Bus bus = (Bus)transport;
				if (bus.MaxSpeed < bus.Speed)
				{
					transport = null;
				}

			}
			if (troll_rad.Active && troll_rad.Sensitive == true)
			{
				transport = new Trolleybus(spinbutton3.Value, spinbutton4.Value, spinbutton6.ValueAsInt, entry1.Text);
				Trolleybus troll = (Trolleybus)transport;
				if (troll.MaxSpeed < troll.Speed)
				{
					transport = null;
				}

			}
			if (moto_rad.Active && moto_rad.Sensitive == true)
			{
				transport = new Moto(spinbutton3.Value, spinbutton4.Value, spinbutton1.Value, spinbutton2.Value, entry1.Text);
				Moto moto = (Moto)transport;
				if (moto.MaxSpeed < moto.Speed)
				{
					transport = null;
				}

			}
			if (horse_rad.Active && horse_rad.Sensitive == true)
			{
				transport = new Horse(spinbutton3.Value, spinbutton4.Value, entry1.Text, spinbutton5.Value);
				Horse horse = (Horse)transport;
				if (horse.MaxSpeed < horse.Speed)
				{
					transport = null;
				}

			}
			if (tram_rad.Active && tram_rad.Sensitive == true)
			{
				transport = new Tram(spinbutton3.Value, spinbutton4.Value, spinbutton6.ValueAsInt, entry1.Text);
				Tram tram = (Tram)transport;
				if (tram.MaxSpeed < tram.Speed)
				{
					transport = null;
				}

			}
			if (bike_rad.Active && bike_rad.Sensitive == true)
			{
				transport = new Bike(spinbutton3.Value, spinbutton4.Value, entry1.Text);
				Bike bike = (Bike)transport;
				if (bike.MaxSpeed < bike.Speed)
				{
					transport = null;
				}

			}
            if (radiobutton19.Active && radiobutton19.Sensitive == true)
			{
				transport = new Kscooter(spinbutton3.Value, spinbutton4.Value, entry1.Text);
				Kscooter kscooter = (Kscooter)transport;
				if (kscooter.MaxSpeed < kscooter.Speed)
				{
					transport = null;
				}

			}
			if (radiobutton21.Active && radiobutton21.Sensitive == true)
			{
				transport = new Tank(spinbutton3.Value, spinbutton4.Value, spinbutton1.Value, spinbutton2.Value, spinbutton6.ValueAsInt, entry1.Text);
				Tank panzer = (Tank)transport;
				if (panzer.MaxSpeed < panzer.Speed || panzer.AmountFuel < panzer.ConsFuel)
				{
					transport = null;
				}

			}
			if (transport != null)
            if (!horse_rad.Active && !bike_rad.Active && !radiobutton19.Active )
            {
                checkStrip();
            }
            else
            {
                checkStrip();
                fOk = true;
            }
            if (fOk && tOk && transport != null)
            {
				if (MainClass.getSystem().getTransportList()[road] == null)
                	MainClass.getWin().addTsN();
				MainClass.getSystem().getTransportList().RemoveAt(road);
                MainClass.getSystem().getTransportList().Insert(road, transport);
                MainClass.getSystem().getTransportList()[road].Fuel = fuel;
                MainClass.getSystem().getTransportList()[road].Strip = strip;
                if (!horse_rad.Active && !bike_rad.Active && !radiobutton19.Active)
                	MainClass.getWin().setTsLabel(transport, fuel, road, transport.MaxSpeed);
                else
                    MainClass.getWin().setTsLabel(transport, new Fuel("-"), road, transport.MaxSpeed);
				MainClass.getSystem().writeJ(road, MainClass.getSystem().getTransportList()[road]);
                MainClass.getWin().QueueDraw();
                this.QueueDraw();
                this.Destroy();
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
                    tOk = true;//совместимость транспорта и типа полосы
                }

            }
            foreach (Fuel value in transport.FuelList())
            {
                if (value.Equals(fuel))
                {
                    fOk = true;//совместимость топлива транспорта и топлива
                }
            }
        }

        protected void OnBikeRadClicked(object sender, EventArgs e)
        {
            buttonOk.Sensitive = true;
            spinbutton1.Sensitive = false;
            spinbutton2.Sensitive = false;
            spinbutton5.Sensitive = false;
            spinbutton6.Sensitive = false;
            QueueDraw();
        }

        protected void OnCarRadClicked(object sender, EventArgs e)
        {
            if(MainClass.getSystem().getFuelList().Count >0)
            {
                buttonOk.Sensitive = true;
            }
            else
            {
                buttonOk.Sensitive = false; 
            }
            spinbutton1.Sensitive = true;
            spinbutton2.Sensitive = true;
            spinbutton6.Sensitive = true;
            spinbutton5.Sensitive = false;
            QueueDraw();
        }
        protected void OnHorseRadClicked(object sender, EventArgs e)
        {
            buttonOk.Sensitive = true;
            spinbutton1.Sensitive = false;
            spinbutton2.Sensitive = false;
            spinbutton6.Sensitive = false;
            spinbutton5.Sensitive = true;
            QueueDraw();
        }

        protected void OnRadiobutton19Clicked(object sender, EventArgs e)
        {
            buttonOk.Sensitive = true;
            spinbutton1.Sensitive = false;
            spinbutton2.Sensitive = false;
            spinbutton5.Sensitive = false;
            spinbutton6.Sensitive = false;
            QueueDraw();
        }

        protected void OnRadiobutton21Clicked(object sender, EventArgs e)
        {
            if (MainClass.getSystem().getFuelList().Count > 0)
            {
                buttonOk.Sensitive = true;
            }
            else
            {
                buttonOk.Sensitive = false;
            }
            spinbutton1.Sensitive = true;
            spinbutton2.Sensitive = true;
            spinbutton5.Sensitive = false;
            spinbutton6.Sensitive = false;
            QueueDraw();
        }

        protected void OnTrollRadClicked(object sender, EventArgs e)
        {if (MainClass.getSystem().getFuelList().Count > 0)
            {
                buttonOk.Sensitive = true;
            }
            else
            {
                buttonOk.Sensitive = false;
            }
            spinbutton1.Sensitive = false;
            spinbutton2.Sensitive = false;
            spinbutton5.Sensitive = false;
            spinbutton6.Sensitive = true;

            QueueDraw();
        }

        protected void OnBusRadClicked(object sender, EventArgs e)
        {
            if (MainClass.getSystem().getFuelList().Count > 0)
            {
                buttonOk.Sensitive = true;
            }
            else
            {
                buttonOk.Sensitive = false;
            }
            spinbutton1.Sensitive = true;
            spinbutton2.Sensitive = true;
            spinbutton5.Sensitive = false;
            spinbutton6.Sensitive = true;

            QueueDraw();
        }

        protected void OnLoaderRadClicked(object sender, EventArgs e)
        {if (MainClass.getSystem().getFuelList().Count > 0)
            {
                buttonOk.Sensitive = true;
            }
            else
            {
                buttonOk.Sensitive = false;
            }
            spinbutton1.Sensitive = true;
            spinbutton2.Sensitive = true;
            spinbutton5.Sensitive = true;
            spinbutton6.Sensitive = false;
            QueueDraw();
        }

        protected void OnTruckRadClicked(object sender, EventArgs e)
        {if (MainClass.getSystem().getFuelList().Count > 0)
            {
                buttonOk.Sensitive = true;
            }
            else
            {
                buttonOk.Sensitive = false;
            }
            spinbutton1.Sensitive = true;
            spinbutton2.Sensitive = true;
            spinbutton5.Sensitive = true;
            spinbutton6.Sensitive = false;
            QueueDraw();
        }

        protected void OnTramRadClicked(object sender, EventArgs e)
        {
            if (MainClass.getSystem().getFuelList().Count > 0)
            {
                buttonOk.Sensitive = true;
            }
            else
            {
                buttonOk.Sensitive = false;
            }
            spinbutton1.Sensitive = false;
            spinbutton2.Sensitive = false;
            spinbutton5.Sensitive = false;
            spinbutton6.Sensitive = true;

        }

        protected void OnMotoRadClicked(object sender, EventArgs e)
        {
            if (MainClass.getSystem().getFuelList().Count > 0)
            {
                buttonOk.Sensitive = true;
            }
            else
            {
                buttonOk.Sensitive = false;
            }
            spinbutton1.Sensitive = true;
            spinbutton2.Sensitive = true;
            spinbutton6.Sensitive = false;
            spinbutton5.Sensitive = false;
            QueueDraw();
        }
    }
}
