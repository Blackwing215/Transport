using System;
using Gtk;
using Gdk;
using Cairo;
using System.Collections.Generic;
using System.Threading;
using Glade;


namespace Road111
{
	public partial class MainWindow : Gtk.Window
	{
		String rname;//road name
		int amountTs;//amount of transports
		int roadNumb;// road number
		static FuelList fuelDialog;//fuel dialog window
		static TransportDialog1 tsDialog;//add transport dialog window
		bool timer = false;

		int imW, imH;
		int width, height;
		static uint clock = 10;
		static double roadLength = 500, fault = roadLength / 10000;
		static TimeSpan elapsed = TimeSpan.Zero, moving = TimeSpan.Zero, stop = TimeSpan.Zero;

		public MainWindow() : base(Gtk.WindowType.Toplevel)
		{
			Build();
			GLib.Timeout.Add(clock, new GLib.TimeoutHandler(OnTimer));
		}

		public static double RoadLength
		{
			get { return roadLength; }
		}

		public void setTsLabel(Vehicle transport, Fuel fuel, int road, double speed)
		{
			switch (road)
			{
				case 0:
					label31.Text = transport.Name;
					speedlabel1.Text = Convert.ToString(speed);
					label26.Text = fuel.GetFuel();
					distlabel1.Text = "0";
					info_but1.Sensitive = true;
					if (transport.GetType() != typeof(Horse) && transport.GetType() != typeof(Kscooter))
						lightsbutton1.Sensitive = true;
					break;
				case 1:
					label32.Text = transport.Name;
					speedlabel2.Text = Convert.ToString(speed);
					label27.Text = fuel.GetFuel();
					distlabel2.Text = "0";
					info_but2.Sensitive = true;
					if (transport.GetType() != typeof(Horse) && transport.GetType() != typeof(Kscooter))
						lightsbutton2.Sensitive = true;
					break;
				case 2:
					label33.Text = transport.Name;
					speedlabel3.Text = Convert.ToString(speed);
					label28.Text = fuel.GetFuel();
					distlabel3.Text = "0";
					info_but3.Sensitive = true;
					if (transport.GetType() != typeof(Horse)  && transport.GetType() != typeof(Kscooter))
						lightsbutton3.Sensitive = true;
					break;
				case 3:
					label34.Text = transport.Name;
					speedlabel4.Text = Convert.ToString(speed);
					label29.Text = fuel.GetFuel();
					distlabel4.Text = "0";
					info_but4.Sensitive = true;
					if (transport.GetType() != typeof(Horse) && transport.GetType() != typeof(Kscooter))
						lightsbutton4.Sensitive = true;
					break;
				case 4:
					label35.Text = transport.Name;
					speedlabel5.Text = Convert.ToString(speed);
					label30.Text = fuel.GetFuel();
					distlabel5.Text = "0";
					info_but5.Sensitive = true;
					if (transport.GetType() != typeof(Horse) && transport.GetType() != typeof(Kscooter))
						lightsbutton5.Sensitive = true;
					break;
			}
			QueueDraw();
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}

		protected void TransportInfo1_clicked(object sender, EventArgs e)
		{
			roadNumb = 0;
			if (common1.Active)
				rname = "Обычная";
			if (electrified1.Active)
				rname = "Электро";
			if (railway1.Active)
				rname = "Рельсы";
			Strip r1 = new Strip(rname);
			tsDialog = new TransportDialog1(roadNumb, r1);
			tsDialog.Show();
		}

		protected void OnAddFuelListActionActivated(object sender, EventArgs e)
		{
			if (MainClass.getSystem().getFuelList().Count == 0)
			{

				fuelDialog = new FuelList();
			}
			fuelDialog.Show();
		}

		protected void OnButton2Clicked(object sender, EventArgs e)
		{
			roadNumb = 1;
			if (common2.Active)
				rname = "Обычная";
			if (electrified2.Active)
				rname = "Электро";
			if (railway2.Active)
				rname = "Рельсы";
			Strip r2 = new Strip(rname);
			tsDialog = new TransportDialog1(roadNumb, r2);
			tsDialog.Show();
		}

		protected void OnButton3Clicked(object sender, EventArgs e)
		{
			roadNumb = 2;
			if (common3.Active)
				rname = "Обычная";
			if (electrified2.Active)
				rname = "Электро";
			if (railway3.Active)
				rname = "Рельсы";


			Strip r3 = new Strip(rname);
			tsDialog = new TransportDialog1(roadNumb, r3);
			tsDialog.Show();
		}

		protected void OnButton4Clicked(object sender, EventArgs e)
		{
			roadNumb = 3;
			if (common4.Active)
				rname = "Обычная";
			if (electrified4.Active)
				rname = "Электро";
			if (railway4.Active)
				rname = "Рельсы";
			Strip r4 = new Strip(rname);
			tsDialog = new TransportDialog1(roadNumb, r4);
			tsDialog.Show();
		}

		protected void OnButton5Clicked(object sender, EventArgs e)
		{
			roadNumb = 4;
			if (common5.Active)
				rname = "Обычная";
			if (electrified5.Active)
				rname = "Электро";
			if (railway5.Active)
				rname = "Рельсы";
			Strip r5 = new Strip(rname);
			tsDialog = new TransportDialog1(roadNumb, r5);
			tsDialog.Show();
		}

		public void addTsN()
		{
			amountTs++;
			labelNTR.Text = Convert.ToString(amountTs);
			QueueDraw();
		}

		protected void OnInfoBut1Clicked(object sender, EventArgs e)
		{
			ViewProperties(0);
		}
		protected void OnInfoBut2Clicked(object sender, EventArgs e)
		{
			ViewProperties(1);
		}

		protected void OnInfoBut3Clicked(object sender, EventArgs e)
		{
			ViewProperties(2);
		}

		protected void OnInfoBut4Clicked(object sender, EventArgs e)
		{
			ViewProperties(3);
		}

		void OnInfoBut5Clicked(object sender, EventArgs e)
		{
			ViewProperties(4);
		}

		void OnJournalActionActivated(object sender, EventArgs e)
		{
			MainClass.getSystem().ViewJournal();//просмотр журнала 
		}

		void ToggleProgress(object sender, EventArgs e)                 //Start/Stop button action
		{
			timer = !timer;
			SwitchSensetivity();
		}
		bool OnTimer()                                                  //timer for roads animation
		{
			elapsed += TimeSpan.FromMilliseconds(clock);
			if (elapsed.Milliseconds == 0) labelTelapsed.Text = elapsed.ToString();
			if (timer)
			{
				moving += TimeSpan.FromMilliseconds(amountTs * clock);
				if (moving.Milliseconds == 0) labelTmove.Text = moving.ToString();
			}
			else
			{
				stop += TimeSpan.FromMilliseconds(amountTs * clock);
				if (stop.Milliseconds == 0) labelTstop.Text = stop.ToString();
			}
			QueueDraw();
			return true;
		}

		protected void OnDrawingarea1ExposeEvent(object o, ExposeEventArgs args)
		{
			width = drawingarea1.Allocation.Width;
			height = drawingarea1.Allocation.Height;
			DrawingPicCar(o, 0);
		}

		protected void OnDrawingarea2ExposeEvent(object o, ExposeEventArgs args)
		{
			DrawingPicCar(o, 1);
		}

		protected void OnDrawingarea3ExposeEvent(object o, ExposeEventArgs args)
		{
			DrawingPicCar(o, 2);
		}

		protected void OnDrawingarea4ExposeEvent(object o, ExposeEventArgs args)
		{
			DrawingPicCar(o, 3);
		}

		protected void OnDrawingarea5ExposeEvent(object o, ExposeEventArgs args)
		{
			DrawingPicCar(o, 4);
		}

		protected void DrawingPicCar(object o, int road)
		{
			DrawingArea area = (DrawingArea)o;
			Cairo.Context cr = Gdk.CairoHelper.Create(area.GdkWindow);

			width = area.Allocation.Width;
			height = area.Allocation.Height;
			bool lights = false;

			cr.SetSourceRGB(0.3, 0.3, 0.3);
			cr.Paint();
			switch (road)                                                       //Drawing railways, if needed
			{
				case 0:
					if (railway1.Active)
					{
						for (int k = 0; k < width / (height / 8); k++)
						{
							cr.LineWidth = height / 30;
							cr.SetSourceRGB(0.4, 0.3, 0.15);
							cr.MoveTo(k * height / 8, 2 * height / 9);
							cr.LineTo(k * height / 8, 7 * height / 9);
							cr.Stroke();
						}
						cr.LineWidth = height / 20;
						cr.SetSourceRGB(0.75, 0.75, 0.75);
						cr.MoveTo(0, height / 3);
						cr.LineTo(width, height / 3);
						cr.MoveTo(0, 2 * height / 3);
						cr.LineTo(width, 2 * height / 3);
						cr.Stroke();
					}
					break;
				case 1:
					if (railway2.Active)
					{
						for (int k = 0; k < width / (height / 8); k++)
						{
							cr.LineWidth = height / 30;
							cr.SetSourceRGB(0.4, 0.3, 0.15);
							cr.MoveTo(k * height / 8, 2 * height / 9);
							cr.LineTo(k * height / 8, 7 * height / 9);
							cr.Stroke();
						}
						cr.LineWidth = height / 20;
						cr.SetSourceRGB(0.75, 0.75, 0.75);
						cr.MoveTo(0, height / 3);
						cr.LineTo(width, height / 3);
						cr.MoveTo(0, 2 * height / 3);
						cr.LineTo(width, 2 * height / 3);
						cr.Stroke();
					}
					break;
				case 2:
					if (railway3.Active)
					{
						for (int k = 0; k < width / (height / 8); k++)
						{
							cr.LineWidth = height / 30;
							cr.SetSourceRGB(0.4, 0.3, 0.15);
							cr.MoveTo(k * height / 8, 2 * height / 9);
							cr.LineTo(k * height / 8, 7 * height / 9);
							cr.Stroke();
						}
						cr.LineWidth = height / 20;
						cr.SetSourceRGB(0.75, 0.75, 0.75);
						cr.MoveTo(0, height / 3);
						cr.LineTo(width, height / 3);
						cr.MoveTo(0, 2 * height / 3);
						cr.LineTo(width, 2 * height / 3);
						cr.Stroke();
					}
					break;
				case 3:
					if (railway4.Active)
					{
						for (int k = 0; k < width / (height / 8); k++)
						{
							cr.LineWidth = height / 30;
							cr.SetSourceRGB(0.4, 0.3, 0.15);
							cr.MoveTo(k * height / 8, 2 * height / 9);
							cr.LineTo(k * height / 8, 7 * height / 9);
							cr.Stroke();
						}
						cr.LineWidth = height / 20;
						cr.SetSourceRGB(0.75, 0.75, 0.75);
						cr.MoveTo(0, height / 3);
						cr.LineTo(width, height / 3);
						cr.MoveTo(0, 2 * height / 3);
						cr.LineTo(width, 2 * height / 3);
						cr.Stroke();
					}
					break;
				case 4:
					if (railway5.Active)
					{
						for (int k = 0; k < width / (height / 8); k++)
						{
							cr.LineWidth = height / 30;
							cr.SetSourceRGB(0.4, 0.3, 0.15);
							cr.MoveTo(k * height / 8, 2 * height / 9);
							cr.LineTo(k * height / 8, 7 * height / 9);
							cr.Stroke();
						}
						cr.LineWidth = height / 20;
						cr.SetSourceRGB(0.75, 0.75, 0.75);
						cr.MoveTo(0, height / 3);
						cr.LineTo(width, height / 3);
						cr.MoveTo(0, 2 * height / 3);
						cr.LineTo(width, 2 * height / 3);
						cr.Stroke();
					}
					break;
			}

			switch (road)
			{
				case 0:
					lights = lightsbutton1.Active;
					break;
				case 1:
					lights = lightsbutton2.Active;
					break;
				case 2:
					lights = lightsbutton3.Active;
					break;
				case 3:
					lights = lightsbutton4.Active;
					break;
				case 4:
					lights = lightsbutton5.Active;
					break;
			}
			if (MainClass.getSystem().getTransportList()[road] != null)                     //Drawing vehicle, if it is on this strip
			{
				imW = MainClass.getSystem().getTransportList()[road].Image.Width;
				imH = MainClass.getSystem().getTransportList()[road].Image.Height;
				double scale = (width - imW) / roadLength;
				double dist = MainClass.getSystem().getTransportList()[road].Distance;
				int scaledDist = Convert.ToInt32(scale * dist);

				if (lights)
				{
					LinearGradient lg = new LinearGradient(scaledDist + 3*imH/5, height / 2, scaledDist + 5 * imW / 3, height / 2);
					lg.AddColorStop(0, new Cairo.Color(1, 1, 0, 1));
					lg.AddColorStop(1, new Cairo.Color(1, 1, 0, 0));
					cr.SetSource(lg);
					if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Moto) 
					    || MainClass.getSystem().getTransportList()[road].GetType() == typeof(Bike))
					{
						cr.MoveTo(scaledDist + imW - 50, height / 2);
						cr.LineTo(scaledDist + 5 * imW / 3, height / 2 - 2 * imH / 3);
						cr.LineTo(scaledDist + 5 * imW / 3, height / 2 + 2 * imH / 3);
						cr.ClosePath();
					}
					else
					{
						if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Tank)
						   || MainClass.getSystem().getTransportList()[road].GetType() == typeof(Loader))
						{
							cr.MoveTo(scaledDist + imW - 100, height / 2 - imH / 4);
							cr.LineTo(scaledDist + 5 * imW / 3, height / 2 - 2 * imH / 3 - imH / 4);
							cr.LineTo(scaledDist + 5 * imW / 3, height / 2 + 2 * imH / 3 - imH / 4);
							cr.ClosePath();
							cr.Fill();
							cr.MoveTo(scaledDist + imW - 100, height / 2 + imH / 4);
							cr.LineTo(scaledDist + 5 * imW / 3, height / 2 - 2 * imH / 3 + imH / 4);
							cr.LineTo(scaledDist + 5 * imW / 3, height / 2 + 2 * imH / 3 + imH / 4);
							cr.ClosePath();
						}
						else
						{
							cr.MoveTo(scaledDist + imW - 50, height / 2 - imH / 6);
							cr.LineTo(scaledDist + 5 * imW / 3, height / 2 - 2 * imH / 3 - imH / 6);
							cr.LineTo(scaledDist + 5 * imW / 3, height / 2 + 2 * imH / 3 - imH / 6);
							cr.ClosePath();
							cr.Fill();
							cr.MoveTo(scaledDist + imW - 50, height / 2 + imH / 6);
							cr.LineTo(scaledDist + 5 * imW / 3, height / 2 - 2 * imH / 3 + imH / 6);
							cr.LineTo(scaledDist + 5 * imW / 3, height / 2 + 2 * imH / 3 + imH / 6);
							cr.ClosePath();
						}
					}
					cr.Fill();
				}


				cr.SetSourceSurface(MainClass.getSystem().getTransportList()[road].Image, scaledDist,	(height - imH) / 2);
				cr.Paint();

				if (timer && scaledDist < width - imW)
				{
					double speed = MainClass.getSystem().getTransportList()[road].StartSpeed + 
					                        (MainClass.getSystem().getTransportList()[road].MaxSpeed - 
					                         MainClass.getSystem().getTransportList()[road].StartSpeed) 
					                        * (dist/(2*roadLength));
					MainClass.getSystem().getTransportList()[road].Speed = speed;
					dist += 20 * speed * clock / 3600000;
					switch (road)
					{
						case 0:
							distlabel1.Text = Convert.ToString(Convert.ToInt32(dist));
							speedlabel1.Text = Convert.ToString(Convert.ToInt32(speed));
							break;
						case 1:
							distlabel2.Text = Convert.ToString(Convert.ToInt32(dist));
							speedlabel2.Text = Convert.ToString(Convert.ToInt32(speed));
							break;
						case 2:
							distlabel3.Text = Convert.ToString(Convert.ToInt32(dist));
							speedlabel3.Text = Convert.ToString(Convert.ToInt32(speed));
							break;
						case 3:
							distlabel4.Text = Convert.ToString(Convert.ToInt32(dist));
							speedlabel4.Text = Convert.ToString(Convert.ToInt32(speed));
							break;
						case 4:
							distlabel5.Text = Convert.ToString(Convert.ToInt32(dist));
							speedlabel5.Text = Convert.ToString(Convert.ToInt32(speed));
							break;
					}
					MainClass.getSystem().getTransportList()[road].Distance = dist;
																									//Writing in journal
					if (dist > 0 && dist % (roadLength / 10) <= fault && Convert.ToInt32(scale * dist / (roadLength / 10)) 
					    != MainClass.getSystem().getTransportList()[road].Stop_C - 2)
							MainClass.getSystem().writeJ(road, MainClass.getSystem().getTransportList()[road]);
				}
			}
			switch (road)                                                                           //Drawing wires, if needed
			{
				case 0:
					if (railway1.Active || electrified1.Active)
					{
						cr.LineWidth = height / 30;
						cr.SetSourceRGB(0.1, 0.0, 0.0);
						cr.MoveTo(0, 2 * height / 5);
						cr.LineTo(width, 2 * height / 5);
						cr.MoveTo(0, 3 * height / 5);
						cr.LineTo(width, 3 * height / 5);
						cr.Stroke();
					}
					break;
				case 1:
					if (railway2.Active || electrified2.Active)
					{
						cr.LineWidth = height / 30;
						cr.SetSourceRGB(0.1, 0.0, 0.0);
						cr.MoveTo(0, 2 * height / 5);
						cr.LineTo(width, 2 * height / 5);
						cr.MoveTo(0, 3 * height / 5);
						cr.LineTo(width, 3 * height / 5);
						cr.Stroke();
					}
					break;
				case 2:
					if (railway3.Active || electrified3.Active)
					{
						cr.LineWidth = height / 30;
						cr.SetSourceRGB(0.1, 0.0, 0.0);
						cr.MoveTo(0, 2 * height / 5);
						cr.LineTo(width, 2 * height / 5);
						cr.MoveTo(0, 3 * height / 5);
						cr.LineTo(width, 3 * height / 5);
						cr.Stroke();
					}
					break;
				case 3:
					if (railway4.Active || electrified4.Active)
					{
						cr.LineWidth = height / 30;
						cr.SetSourceRGB(0.1, 0.0, 0.0);
						cr.MoveTo(0, 2 * height / 5);
						cr.LineTo(width, 2 * height / 5);
						cr.MoveTo(0, 3 * height / 5);
						cr.LineTo(width, 3 * height / 5);
						cr.Stroke();
					}
					break;
				case 4:
					if (railway5.Active || electrified5.Active)
					{
						cr.LineWidth = height / 30;
						cr.SetSourceRGB(0.1, 0.0, 0.0);
						cr.MoveTo(0, 2 * height / 5);
						cr.LineTo(width, 2 * height / 5);
						cr.MoveTo(0, 3 * height / 5);
						cr.LineTo(width, 3 * height / 5);
						cr.Stroke();
					}
					break;
			}
			cr.Dispose();
		}

		public void ViewProperties(int road)
		{
            Gtk.Window window = new Gtk.Window("Транспортное средство №" + (road+1));
			window.SetSizeRequest(500, 200);

			Gtk.TreeView tree = new Gtk.TreeView();
			window.Add(tree);

			Gtk.TreeViewColumn tsColumn = new Gtk.TreeViewColumn();
			tsColumn.Title = "Транспортное средство";

			Gtk.CellRendererText tsNameCell = new Gtk.CellRendererText();

			tsColumn.PackStart(tsNameCell, true);

			Gtk.TreeViewColumn distanceColumn = new Gtk.TreeViewColumn();
			distanceColumn.Title = "Запись";

			Gtk.CellRendererText distanceTitleCell = new Gtk.CellRendererText();
			distanceColumn.PackStart(distanceTitleCell, true);

			tree.AppendColumn(tsColumn);
			tree.AppendColumn(distanceColumn);

			tsColumn.AddAttribute(tsNameCell, "text", 0);
			distanceColumn.AddAttribute(distanceTitleCell, "text", 1);

			Gtk.TreeStore tsListStore = new Gtk.TreeStore(typeof(string), typeof(string));
			Gtk.TreeIter iter;
            if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Car))
            {
				Car car = MainClass.getSystem().getTransportList()[road] as Car;
                iter = tsListStore.AppendValues(car.Name);
                tsListStore.AppendValues(iter, "Тип:", car.Type);
                tsListStore.AppendValues(iter, "Марка:", car.Brand);
                tsListStore.AppendValues(iter, "Тип топлива:", car.Fuel.GetFuel());
                tsListStore.AppendValues(iter, "Объем бака: ", Convert.ToString(car.AmountFuel));
                tsListStore.AppendValues(iter, "Расход топлива: ", Convert.ToString(car.ConsFuel));
                tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(car.MaxSpeed));
                tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(car.Speed));
                tsListStore.AppendValues(iter, "Максимальное расстояние: ", Convert.ToString(car.MaxDist));
                tsListStore.AppendValues(iter, "Количество пассажиров: ", Convert.ToString(car.Passengers));
            }
            if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Moto))
            {
                Moto moto = (Moto)MainClass.getSystem().getTransportList()[road];
                iter = tsListStore.AppendValues(moto.Name);
                tsListStore.AppendValues(iter, "Тип:", moto.Type);
                tsListStore.AppendValues(iter, "Марка:", moto.Brand);
                tsListStore.AppendValues(iter, "Тип топлива:", moto.Fuel.GetFuel());
                tsListStore.AppendValues(iter, "Объем бака: ", Convert.ToString(moto.AmountFuel));
                tsListStore.AppendValues(iter, "Расход топлива: ", Convert.ToString(moto.ConsFuel));
                tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(moto.MaxSpeed));
                tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(moto.Speed));
                tsListStore.AppendValues(iter, "Максимальное расстояние: ", Convert.ToString(moto.MaxDist));
            }
            if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Truck))
            {
                Truck truck = (Truck)MainClass.getSystem().getTransportList()[road];
                iter = tsListStore.AppendValues(truck.Name);
                tsListStore.AppendValues(iter, "Тип:", truck.Type);
                tsListStore.AppendValues(iter, "Марка:", truck.Brand);
                tsListStore.AppendValues(iter, "Тип топлива:", truck.Fuel.GetFuel());
                tsListStore.AppendValues(iter, "Объем бака: ", Convert.ToString(truck.AmountFuel));
                tsListStore.AppendValues(iter, "Расход топлива: ", Convert.ToString(truck.ConsFuel));
                tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(truck.MaxSpeed));
                tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(truck.Speed));
                tsListStore.AppendValues(iter, "Максимальное расстояние: ", Convert.ToString(truck.MaxDist));
                tsListStore.AppendValues(iter, "Грузоподъемность: ", Convert.ToString(truck.Carrying));
            }
            if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Loader))
            {
                Loader loader = (Loader)MainClass.getSystem().getTransportList()[road];
                iter = tsListStore.AppendValues(loader.Name);
                tsListStore.AppendValues(iter, "Тип:", loader.Type);
                tsListStore.AppendValues(iter, "Марка:", loader.Brand);
                tsListStore.AppendValues(iter, "Тип топлива:", loader.Fuel.GetFuel());
                tsListStore.AppendValues(iter, "Объем бака: ", Convert.ToString(loader.AmountFuel));
                tsListStore.AppendValues(iter, "Расход топлива: ", Convert.ToString(loader.ConsFuel));
                tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(loader.MaxSpeed));
                tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(loader.Speed));
                tsListStore.AppendValues(iter, "Максимальное расстояние: ", Convert.ToString(loader.MaxDist));
                tsListStore.AppendValues(iter, "Грузоподъемность: ", Convert.ToString(loader.Carrying));
            }
            if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Bus))
            {
                Bus bus = (Bus)MainClass.getSystem().getTransportList()[road];
                iter = tsListStore.AppendValues(bus.Name);
                tsListStore.AppendValues(iter, "Тип:", bus.Type);
                tsListStore.AppendValues(iter, "Марка:", bus.Brand);
                tsListStore.AppendValues(iter, "Тип топлива:", bus.Fuel.GetFuel());
                tsListStore.AppendValues(iter, "Объем бака: ", Convert.ToString(bus.AmountFuel));
                tsListStore.AppendValues(iter, "Расход топлива: ", Convert.ToString(bus.ConsFuel));
                tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(bus.MaxSpeed));
                tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(bus.Speed));
                tsListStore.AppendValues(iter, "Максимальное расстояние: ", Convert.ToString(bus.MaxDist));
                tsListStore.AppendValues(iter, "Количество пассажиров: ", Convert.ToString(bus.Passengers));
            }
            if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Trolleybus))
            {
                Trolleybus troll = (Trolleybus)MainClass.getSystem().getTransportList()[road];
                iter = tsListStore.AppendValues(troll.Name);
                tsListStore.AppendValues(iter, "Тип:", troll.Type);
                tsListStore.AppendValues(iter, "Марка:", troll.Brand);
                tsListStore.AppendValues(iter, "Тип топлива:", troll.Fuel.GetFuel());
                tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(troll.MaxSpeed));
                tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(troll.Speed));
                tsListStore.AppendValues(iter, "Количество пассажиров: ", Convert.ToString(troll.Passengers));
            }
            if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Tram))
            {
                Tram tram = (Tram)MainClass.getSystem().getTransportList()[road];
                iter = tsListStore.AppendValues(tram.Name);
                tsListStore.AppendValues(iter, "Тип:", tram.Type);
                tsListStore.AppendValues(iter, "Марка:", tram.Brand);
                tsListStore.AppendValues(iter, "Тип топлива:", tram.Fuel.GetFuel());
                tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(tram.MaxSpeed));
                tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(tram.Speed));
                tsListStore.AppendValues(iter, "Количество пассажиров: ", Convert.ToString(tram.Passengers));
            }
            if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Horse))
            {
                Horse horse = (Horse)MainClass.getSystem().getTransportList()[road];
                iter = tsListStore.AppendValues(horse.Name);
                tsListStore.AppendValues(iter, "Тип:", horse.Type);
                tsListStore.AppendValues(iter, "Марка:", horse.Brand);
                tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(horse.MaxSpeed));
                tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(horse.Speed));
                tsListStore.AppendValues(iter, "Грузоподъемность: ", Convert.ToString(horse.Carrying));
            }
            if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Bike))
            {
                Bike bike = (Bike)MainClass.getSystem().getTransportList()[road];
                iter = tsListStore.AppendValues(bike.Name);
                tsListStore.AppendValues(iter, "Тип:", bike.Type);
                tsListStore.AppendValues(iter, "Марка:", bike.Brand);
                tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(bike.MaxSpeed));
                tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(bike.Speed));
            }
			if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Kscooter))
            {
                Kscooter ks = (Kscooter)MainClass.getSystem().getTransportList()[road];
                iter = tsListStore.AppendValues(ks.Name);
                tsListStore.AppendValues(iter, "Тип:", ks.Type);
                tsListStore.AppendValues(iter, "Марка:", ks.Brand);
                tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(ks.MaxSpeed));
                tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(ks.Speed));
            }
            if (MainClass.getSystem().getTransportList()[road].GetType() == typeof(Tank))
            {
                Tank panzer = (Tank)MainClass.getSystem().getTransportList()[road];
                iter = tsListStore.AppendValues(panzer.Name);
                tsListStore.AppendValues(iter, "Тип:", panzer.Type);
                tsListStore.AppendValues(iter, "Марка:", panzer.Brand);
                tsListStore.AppendValues(iter, "Тип топлива:", panzer.Fuel.GetFuel());
                tsListStore.AppendValues(iter, "Объем бака: ", Convert.ToString(panzer.AmountFuel));
                tsListStore.AppendValues(iter, "Расход топлива: ", Convert.ToString(panzer.ConsFuel));
                tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(panzer.MaxSpeed));
                tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(panzer.Speed));
                tsListStore.AppendValues(iter, "Максимальное расстояние: ", Convert.ToString(panzer.MaxDist));
            }

			tree.Model = tsListStore;

			window.ShowAll();
		}

		void StripTypeToggled(object sender, EventArgs e)
		{ QueueDraw(); }

		void SwitchSensetivity()
		{
			common1.Sensitive = !common1.Sensitive;
			common2.Sensitive = !common2.Sensitive;
			common3.Sensitive = !common3.Sensitive;
			common4.Sensitive = !common4.Sensitive;
			common5.Sensitive = !common5.Sensitive;
			railway1.Sensitive = !railway1.Sensitive;
			railway2.Sensitive = !railway2.Sensitive;
			railway3.Sensitive = !railway3.Sensitive;
			railway4.Sensitive = !railway4.Sensitive;
			railway5.Sensitive = !railway5.Sensitive;
			electrified1.Sensitive = !electrified1.Sensitive;
			electrified2.Sensitive = !electrified2.Sensitive;
			electrified3.Sensitive = !electrified3.Sensitive;
			electrified4.Sensitive = !electrified4.Sensitive;
			electrified5.Sensitive = !electrified5.Sensitive;
			button1.Sensitive = !button1.Sensitive;
			button2.Sensitive = !button2.Sensitive;
			button3.Sensitive = !button3.Sensitive;
			button4.Sensitive = !button4.Sensitive;
			button5.Sensitive = !button5.Sensitive;
		}

		protected void OnViewJournalActionActivated(object sender, EventArgs e)
		{
			MainClass.getSystem().ViewJournal();
		}

		protected void OnFuelActionActivated(object sender, EventArgs e)
		{
			if (MainClass.getSystem().getFuelList().Count == 0)
			{

				fuelDialog = new FuelList();
			}
			fuelDialog.Show();
		}
	}
}