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
    public String rname;//road name
    public int amountTs;//amount of transports
    private int roadNumb;// road number
    public bool startLabel = true;
    public static Road111.FuelList fuelDialog;//fuel dialog window
    public static Road111.TransportDialog1 tsDialog;//add transport dialog window
    public static Road111.PropertiWindow info1, info2, info3, info4, info5;//add transport dialog window  
    private bool timer = false;   

	protected List<ImageSurface> vehIm = new List<ImageSurface>();
	protected int i = 0, imW, imH;
	int width, height;
	static uint time = 10, roadLength = 50;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
		try
		{
			vehIm.Insert(0, new ImageSurface("pictures\\Car.png"));
			vehIm.Insert(1, new ImageSurface("pictures\\Car.png"));
			vehIm.Insert(2, new ImageSurface("pictures\\Truck.png"));
			vehIm.Insert(3, new ImageSurface("pictures\\Tram.png"));
			vehIm.Insert(4, new ImageSurface("pictures\\Bus.png"));

			//vehIm.Insert(0, new ImageSurface("C:\\Users\\Max\\Documents\\GitHub\\Transport\\Road111\\pictures\\Car.png"));
			//vehIm.Insert(1, new ImageSurface("C:\\Users\\Max\\Documents\\GitHub\\Transport\\Road111\\pictures\\Car.png"));
			//vehIm.Insert(2, new ImageSurface("C:\\Users\\Max\\Documents\\GitHub\\Transport\\Road111\\pictures\\Truck.png"));
			//vehIm.Insert(3, new ImageSurface("C:\\Users\\Max\\Documents\\GitHub\\Transport\\Road111\\pictures\\Tram.png"));
			//vehIm.Insert(4, new ImageSurface("C:\\Users\\Max\\Documents\\GitHub\\Transport\\Road111\\pictures\\Bus.png"));
		}
		catch
		{
			Console.WriteLine("File not found");
			Environment.Exit(1);
		}
		Build();
		width = drawingarea1.Allocation.Width;
		//for (int road = 0; road < 5; road++)
		//	dist.Insert(road, 0);

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
        label41.Text = Convert.ToString(amountTs);
        QueueDraw();
    }
    private void setStrip()
    {

    }

    protected void OnInfoBut1Clicked(object sender, EventArgs e)
    {
        if (info1 == null)
        {
            info1 = new Road111.PropertiWindow("Полоса №1");
            info1.setParametrs(Road111.MainClass.getSystem().getTransportList()[0]);
            info1.Show();
        }
        else
        {
            info1.Show();
        }
    }
    protected void OnInfoBut2Clicked(object sender, EventArgs e)
    {
        if (info2 == null)
        {
            info2 = new Road111.PropertiWindow("Полоса №2");
            info2.setParametrs(Road111.MainClass.getSystem().getTransportList()[1]);
            info2.Show();
        }
        else
        {
            info2.Show();
        }
    }

    protected void OnInfoBut3Clicked(object sender, EventArgs e)
    {
        if (info3 == null)
        {
            info3 = new Road111.PropertiWindow("Полоса №3");
            info3.setParametrs(Road111.MainClass.getSystem().getTransportList()[2]);
            info3.Show();
        }
        else
        {
            info3.Show();
        }
    }

    protected void OnInfoBut4Clicked(object sender, EventArgs e)
    {
        if (info4 == null)
        {
            info4 = new Road111.PropertiWindow("Полоса №4");
            info4.setParametrs(Road111.MainClass.getSystem().getTransportList()[3]);
            info4.Show();
        }
        else
        {
            info4.Show();
        }
    }

    protected void OnInfoBut5Clicked(object sender, EventArgs e)
    {
        if (info5 == null)
        {
            info5 = new Road111.PropertiWindow("Полоса №5");
            info5.setParametrs(Road111.MainClass.getSystem().getTransportList()[4]);
            info5.Show();
        }
        else
        {
            info5.Show();
        }
    }
    protected void OnJournalActionActivated(object sender, EventArgs e)
    {
        for (int i = 0; i < Road111.MainClass.getSystem().getTransportList().Count;i++)//пример записи в журнал
        {
			if (Road111.MainClass.getSystem().getTransportList()[i] != null)
            	Road111.MainClass.getSystem().writeJ(i, Road111.MainClass.getSystem().getTransportList()[i]);
         
        }
        Road111.MainClass.getSystem().ViewJournal();//просмотр журнала 
    }

	protected void ToggleProgress(object sender, EventArgs e)		//Start/Stop button action
	{
		timer = !timer;
		GLib.Timeout.Add(time, new GLib.TimeoutHandler(OnTimer));
	}

	bool OnTimer()													//timer for roads animation
	{
		if (!timer) return false;
		QueueDraw();
		return true;
	}

	protected void OnDrawingarea1ExposeEvent(object o, ExposeEventArgs args)
	{
		DrawingPicCar(o, 0);
		width = drawingarea1.Allocation.Width;
		height = drawingarea1.Allocation.Height;
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
		imW = vehIm[road].Width;
		imH = vehIm[road].Height;

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

			cr.SetSourceSurface(vehIm[road],
								Convert.ToInt32((width / roadLength) * Road111.MainClass.getSystem().getTransportList()[road].Distance),
								(height - imH) / 2);
			cr.Paint();
			if (timer && (width / roadLength) * Road111.MainClass.getSystem().getTransportList()[road].Distance < width - imW)
			{
				double speed = Road111.MainClass.getSystem().getTransportList()[road].Speed;
				Road111.MainClass.getSystem().getTransportList()[road].Distance += 1 * speed * time / 3600000;
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
	}

	protected void OnCommon1Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnRailway1Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnElectrified1Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnCommon2Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnRailway2Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnElectrified2Toggled(object sender, EventArgs e)
	{
	}

	protected void OnCommon3Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnRailway3Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnElectrified3Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnCommon4Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnRailway4Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnElectrified4Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnCommon5Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnRailway5Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}

	protected void OnElectrified5Toggled(object sender, EventArgs e)
	{
		QueueDraw();
	}
}