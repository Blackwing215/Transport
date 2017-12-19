using System;
using Gtk;
using System.Collections.Generic;
using System.Threading;
using Gdk;
using CairoWarp;
using Glade;
public partial class MainWindow : Gtk.Window
{
    public Thread mt;
    public String rname;//road name
    public int amountTs;//amount of transports
    private int roadNumb;// road number
    public bool startLabel = true;
    public static Road111.FuelList fuelDialog;//fuel dialog window
    public static Road111.TransportDialog1 tsDialog;//add transport dialog window
    public static Road111.PropertiWindow info1, info2, info3, info4, info5;//add transport dialog window  
    private bool timer = true;
    protected int da1_x, da1_y, i = 0, j = 0;
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

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

    protected void ToggleProgress(object sender, EventArgs e)
    {
        GLib.Timeout.Add(500, new GLib.TimeoutHandler(OnTimer));
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
        for (int i = 0; i < 5;i++)//пример записи в журнал
        {
            Road111.MainClass.getSystem().writeJ(0, Road111.MainClass.getSystem().getTransportList()[0]);
         
        }
        Road111.MainClass.getSystem().ViewJournal();//просмотр журнала 
    }
    bool OnTimer()
    {
        if (!timer) return false;

        drawingarea1.QueueDraw();
        drawingarea2.QueueDraw();
        drawingarea3.QueueDraw();
        drawingarea4.QueueDraw();
        drawingarea5.QueueDraw();
        return true;
    }
    protected void OnDrawingarea1ExposeEvent(object o, ExposeEventArgs args)
    {
        Drawing(o);
    }

    protected void OnDrawingarea2ExposeEvent(object o, ExposeEventArgs args)
    {
        Drawing(o);
    }

    protected void OnDrawingarea3ExposeEvent(object o, ExposeEventArgs args)
    {
        Drawing(o);
    }

    protected void OnDrawingarea4ExposeEvent(object o, ExposeEventArgs args)
    {
        Drawing(o);
    }

    protected void OnDrawingarea5ExposeEvent(object o, ExposeEventArgs args)
    {
        Drawing(o);
    }

    protected void Drawing(object o)
    {
        DrawingArea area = (DrawingArea)o;
       /* Cairo.Context cr = Gdk.CairoHelper.Create(area.GdkWindow);

        cr.LineWidth = 9;
        cr.SetSourceRGB(0.7, 0.2, 0.0);*/

        int width, height;
        width = drawingarea1.Allocation.Width;
        height = drawingarea1.Allocation.Height;

        double d = width < height ? width : height;

        /*cr.Translate(d / 2, height / 2);
        cr.Arc(j, 0, d / 2 - 10, 0, 2 * Math.PI);
        cr.StrokePreserve();

        cr.SetSourceRGB(0.3, 0.4, 0.6);
        cr.Fill();
        */
        //if (timer) 
        j += 5;

        //QueueDraw();
    }
   
}