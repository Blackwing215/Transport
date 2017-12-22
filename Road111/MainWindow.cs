using System;
using Gtk;
using Gdk;
using Cairo;
using System.Collections.Generic;
using System.Threading;
using CairoWarp;
using Glade;

public partial class MainWindow : Gtk.Window
{
    String rname;//road name
    int amountTs;//amount of transports
    int roadNumb;// road number
    static Road111.FuelList fuelDialog;//fuel dialog window
    static Road111.TransportDialog1 tsDialog;//add transport dialog window
    bool timer = false;   

	List<ImageSurface> vehIm = new List<ImageSurface>();
	int imW, imH;
	int width, height;
	static uint roadLength = 50;
	//static DateTime elapsed = new DateTime(2, 1, 1, 0, 0, 0, 0);
	//static DateTime moving = new DateTime(2, 1, 1, 0, 0, 0, 0), stop = new DateTime(2, 1, 1, 0, 0, 0, 0);
	static TimeSpan elapsed = new TimeSpan(0, 1, 1, 1, 250), moving = TimeSpan.Zero, stop = TimeSpan.Zero, clock = new TimeSpan(0, 0, 0, 0, 10);

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
		Build();
	}

	public static uint RoadLength
	{
		get { return roadLength; }
	}

    public void setTsLabel(Road111.Vehicle transport, Road111.Fuel fuel, int Road, double Speed)
    {
        switch (Road)
        {
            case 0:
                label31.Text = transport.Name;
                label37.Text = Convert.ToString(Speed);
                label26.Text = fuel.GetFuel();
                info_but1.Sensitive = true;
                break;
            case 1:
                label32.Text = transport.Name;
                label36.Text = Convert.ToString(Speed);
                label27.Text = fuel.GetFuel();
                info_but2.Sensitive = true;
                break;
            case 2:
                label33.Text = transport.Name;
                label38.Text = Convert.ToString(Speed);
                label28.Text = fuel.GetFuel();
                info_but3.Sensitive = true;
                break;
            case 3:
                label34.Text = transport.Name;
                label39.Text = Convert.ToString(Speed);
                label29.Text = fuel.GetFuel();
                info_but4.Sensitive = true;
                break;
            case 4:
                label35.Text = transport.Name;
                label40.Text = Convert.ToString(Speed);
                label30.Text = fuel.GetFuel();
                info_but5.Sensitive = true;
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
        Road111.Strip r1 = new Road111.Strip(rname);
        tsDialog = new Road111.TransportDialog1(roadNumb, r1);
        tsDialog.Show();
    }

    protected void OnAddFuelListActionActivated(object sender, EventArgs e)
    {
        if (Road111.MainClass.getSystem().getFuelList().Count == 0)
        {

            fuelDialog = new Road111.FuelList();
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
        Road111.Strip r2 = new Road111.Strip(rname);
        tsDialog = new Road111.TransportDialog1(roadNumb, r2);
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


        Road111.Strip r3 = new Road111.Strip(rname);
        tsDialog = new Road111.TransportDialog1(roadNumb, r3);
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
        Road111.Strip r4 = new Road111.Strip(rname);
        tsDialog = new Road111.TransportDialog1(roadNumb, r4);
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
        Road111.Strip r5 = new Road111.Strip(rname);
        tsDialog = new Road111.TransportDialog1(roadNumb, r5);
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
        for (int i = 0; i < Road111.MainClass.getSystem().getTransportList().Count;i++)//пример записи в журнал
        {
			if (Road111.MainClass.getSystem().getTransportList()[i] != null)
            	Road111.MainClass.getSystem().writeJ(i, Road111.MainClass.getSystem().getTransportList()[i]);
         
        }
        Road111.MainClass.getSystem().ViewJournal();//просмотр журнала 
    }

	void ToggleProgress(object sender, EventArgs e)					//Start/Stop button action
	{
		timer = !timer;
		GLib.Timeout.Add((uint)clock.Milliseconds, new GLib.TimeoutHandler(OnTimer));
		SwitchSensetivity();
	}
	bool OnTimer()													//timer for roads animation
	{
		elapsed += clock;
		labelTelapsed.Text = elapsed.ToString();
		if (timer)
		{
			moving += new TimeSpan(0, 0, 0, 0, amountTs * clock.Milliseconds);
			labelTmove.Text = moving.ToString();
		}
		else
		{
			stop += new TimeSpan(0, 0, 0, 0, amountTs* clock.Milliseconds);
			labelTstop.Text = stop.ToString();
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

		cr.SetSourceRGB(0.3, 0.3, 0.3);
		cr.Paint();
		switch (road)														//Drawing railways, if needed
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

		if (Road111.MainClass.getSystem().getTransportList()[road] != null)						//Drawing vehicle, if it is on this strip
		{
			imW = Road111.MainClass.getSystem().getTransportList()[road].Image.Width;
			imH = Road111.MainClass.getSystem().getTransportList()[road].Image.Height;
			cr.SetSourceSurface(Road111.MainClass.getSystem().getTransportList()[road].Image,
								Convert.ToInt32((width / roadLength) * Road111.MainClass.getSystem().getTransportList()[road].Distance),
								(height - imH) / 2);
			cr.Paint();
			if (timer && (width / roadLength) * Road111.MainClass.getSystem().getTransportList()[road].Distance < width - imW)
			{
				double speed = Road111.MainClass.getSystem().getTransportList()[road].Speed;
				Road111.MainClass.getSystem().getTransportList()[road].Distance += 1 * speed * clock.Milliseconds / 3600000;
				if (Road111.MainClass.getSystem().getTransportList()[road].Distance
					% (RoadLength / 10) < (RoadLength / 5000))
				{
					Road111.MainClass.getSystem().writeJ(road, Road111.MainClass.getSystem().getTransportList()[road]);
				}
			}
		}
		switch (road)																			//Drawing wires, if needed
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
		Gtk.Window window = new Gtk.Window("Параметры №" + road);
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
		switch (Road111.MainClass.getSystem().getTransportList()[road].Name)
		{
			case "Автомобиль":
				Road111.Car car = (Road111.Car)Road111.MainClass.getSystem().getTransportList()[road];
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
				break;
			case "Мотоцикл":
				Road111.Moto moto = (Road111.Moto)Road111.MainClass.getSystem().getTransportList()[road];
				iter = tsListStore.AppendValues(moto.Name);
				tsListStore.AppendValues(iter, "Тип:", moto.Type);
				tsListStore.AppendValues(iter, "Марка:", moto.Brand);
				tsListStore.AppendValues(iter, "Тип топлива:", moto.Fuel.GetFuel());
				tsListStore.AppendValues(iter, "Объем бака: ", Convert.ToString(moto.AmountFuel));
				tsListStore.AppendValues(iter, "Расход топлива: ", Convert.ToString(moto.ConsFuel));
				tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(moto.MaxSpeed));
				tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(moto.Speed));
				tsListStore.AppendValues(iter, "Максимальное расстояние: ", Convert.ToString(moto.MaxDist));
				break;
			case "Грузовик":
				Road111.Truck truck = (Road111.Truck)Road111.MainClass.getSystem().getTransportList()[road];
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
				break;
			case "Погрузчик":
				Road111.Loader loader = (Road111.Loader)Road111.MainClass.getSystem().getTransportList()[road];
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
				break;
			case "Автобус":
				Road111.Bus bus = (Road111.Bus)Road111.MainClass.getSystem().getTransportList()[road];
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
				break;
			case "Троллейбус":
				Road111.Trolleybus troll = (Road111.Trolleybus)Road111.MainClass.getSystem().getTransportList()[road];
				iter = tsListStore.AppendValues(troll.Name);
				tsListStore.AppendValues(iter, "Тип:", troll.Type);
				tsListStore.AppendValues(iter, "Марка:", troll.Brand);
				tsListStore.AppendValues(iter, "Тип топлива:", troll.Fuel.GetFuel());
				tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(troll.MaxSpeed));
				tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(troll.Speed));
				tsListStore.AppendValues(iter, "Количество пассажиров: ", Convert.ToString(troll.Passengers));
				break;
			case "Трамвай":
				Road111.Tram tram = (Road111.Tram)Road111.MainClass.getSystem().getTransportList()[road];
				iter = tsListStore.AppendValues(tram.Name);
				tsListStore.AppendValues(iter, "Тип:", tram.Type);
				tsListStore.AppendValues(iter, "Марка:", tram.Brand);
				tsListStore.AppendValues(iter, "Тип топлива:", tram.Fuel.GetFuel());
				tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(tram.MaxSpeed));
				tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(tram.Speed));
				tsListStore.AppendValues(iter, "Количество пассажиров: ", Convert.ToString(tram.Passengers));
				break;
			case "Гужевая повозка":
				Road111.Horse horse = (Road111.Horse)Road111.MainClass.getSystem().getTransportList()[road];
				iter = tsListStore.AppendValues(horse.Name);
				tsListStore.AppendValues(iter, "Тип:", horse.Type);
				tsListStore.AppendValues(iter, "Марка:", horse.Brand);
				tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(horse.MaxSpeed));
				tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(horse.Speed));
				tsListStore.AppendValues(iter, "Грузоподъемность: ", Convert.ToString(horse.Carrying));
				break;
			case "Велосипед":
				Road111.Bike bike = (Road111.Bike)Road111.MainClass.getSystem().getTransportList()[road];
				iter = tsListStore.AppendValues(bike.Name);
				tsListStore.AppendValues(iter, "Тип:", bike.Type);
				tsListStore.AppendValues(iter, "Марка:", bike.Brand);
				tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(bike.MaxSpeed));
				tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(bike.Speed));
				break;
			case "Самокат":
				Road111.Kscooter ks = (Road111.Kscooter)Road111.MainClass.getSystem().getTransportList()[road];
				iter = tsListStore.AppendValues(ks.Name);
				tsListStore.AppendValues(iter, "Тип:", ks.Type);
				tsListStore.AppendValues(iter, "Марка:", ks.Brand);
				tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(ks.MaxSpeed));
				tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(ks.Speed));
				break;
			case "Танк":
				Road111.Tank panzer = (Road111.Tank)Road111.MainClass.getSystem().getTransportList()[road];
				iter = tsListStore.AppendValues(panzer.Name);
				tsListStore.AppendValues(iter, "Тип:", panzer.Type);
				tsListStore.AppendValues(iter, "Марка:", panzer.Brand);
				tsListStore.AppendValues(iter, "Тип топлива:", panzer.Fuel.GetFuel());
				tsListStore.AppendValues(iter, "Объем бака: ", Convert.ToString(panzer.AmountFuel));
				tsListStore.AppendValues(iter, "Расход топлива: ", Convert.ToString(panzer.ConsFuel));
				tsListStore.AppendValues(iter, "Максимальная скорость: ", Convert.ToString(panzer.MaxSpeed));
				tsListStore.AppendValues(iter, "Текущая скорость: ", Convert.ToString(panzer.Speed));
				tsListStore.AppendValues(iter, "Максимальное расстояние: ", Convert.ToString(panzer.MaxDist));
				break;
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
}