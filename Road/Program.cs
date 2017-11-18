using System;
using System.Threading;
using Gtk;
//using Gdk;

namespace Road
{
	class MainClass
	{
		public static ProgressBar roadProgress1 = new ProgressBar();
		public static ProgressBar roadProgress2 = new ProgressBar();
		public static ProgressBar roadProgress3 = new ProgressBar();
		public static ProgressBar roadProgress4 = new ProgressBar();
		public static ProgressBar roadProgress5 = new ProgressBar();

		static bool progressing = false;

		static void Start_Click(object obj, EventArgs args)
		{
			progressing = true;
			if (progressing)
			{
				roadProgress1.Pulse();
				roadProgress2.Pulse();
				roadProgress3.Pulse();
				roadProgress4.Pulse();
				roadProgress5.Pulse();

				Thread.Sleep(100);
			}
		}

		public void StopProgress()
		{
			progressing = false;
		}

		public static void Main(string[] args)
		{
			Application.Init();
			Window win = new Window("Road");
			Table table = new Table(3, 1, false);
			table.BorderWidth = 2;
			Table roads = new Table(3, 3, false);
			roads.BorderWidth = 2;
			Table status = new Table(1, 4, true);
			status.BorderWidth = 2;
			Table buttons = new Table(1, 4, true);
			buttons.BorderWidth = 2;


			roadProgress1.Fraction = 0.0;
			roadProgress1.PulseStep = 0.0;


			roadProgress2.Fraction = 0.0;
			roadProgress2.PulseStep = 0.0;


			roadProgress3.Fraction = 0.0;
			roadProgress3.PulseStep = 0.0;


			roadProgress4.Fraction = 0.0;
			roadProgress4.PulseStep = 0.05;


			roadProgress5.Fraction = 0.0;
			roadProgress5.PulseStep = 0.0;

			Label transportInfo1 = new Label("Transport Info");
			Label transportInfo2 = new Label("Transport Info");
			Label transportInfo3 = new Label("Transport Info");
			Label transportInfo4 = new Label("Transport Info");
			Label transportInfo5 = new Label("Transport Info");

			Button addTransport1 = new Button("Add transport");
			Button addTransport2 = new Button("Add transport");
			Button addTransport3 = new Button("Add transport");
			Button addTransport4 = new Button("Add transport");
			Button addTransport5 = new Button("Add transport");

			VBox roadmodify1 = new VBox();
			VBox roadmodify2 = new VBox();
			VBox roadmodify3 = new VBox();
			VBox roadmodify4 = new VBox();
			VBox roadmodify5 = new VBox();



			RadioButton common1 = new RadioButton(null, "Common");
			common1.Active = true;
			RadioButton tram1 = new RadioButton(common1, "Railway");
			tram1.Active = false;
			RadioButton electrified1 = new RadioButton(tram1, "Electrified");
			electrified1.Active = false;

			RadioButton common2 = new RadioButton("Common");
			common2.Active = true;
			RadioButton tram2 = new RadioButton(common2, "Railway");
			tram2.Active = false;
			RadioButton electrified2 = new RadioButton(tram2, "Electrified");
			electrified2.Active = false;

			RadioButton common3 = new RadioButton("Common");
			common3.Active = true;
			RadioButton tram3 = new RadioButton(common3, "Railway");
			tram3.Active = false;
			RadioButton electrified3 = new RadioButton(tram3, "Electrified");
			electrified3.Active = false;

			RadioButton common4 = new RadioButton("Common");
			common4.Active = true;
			RadioButton tram4 = new RadioButton(common4, "Railway");
			tram4.Active = false;
			RadioButton electrified4 = new RadioButton(tram4, "Electrified");
			electrified4.Active = false;

			RadioButton common5 = new RadioButton("Common");
			common5.Active = true;
			RadioButton tram5 = new RadioButton(common5, "Railway");
			tram5.Active = false;
			RadioButton electrified5 = new RadioButton(tram5, "Electrified");
			electrified5.Active = false;

			roadmodify1.PackStart(common1, true, false, 3);
			roadmodify1.PackStart(tram1, true, false, 3);
			roadmodify1.PackStart(electrified1, true, false, 3);

			roadmodify2.PackStart(common2, true, false, 3);
			roadmodify2.PackStart(tram2, true, false, 3);
			roadmodify2.PackStart(electrified2, true, false, 3);

			roadmodify3.PackStart(common3, true, false, 3);
			roadmodify3.PackStart(tram3, true, false, 3);
			roadmodify3.PackStart(electrified3, true, false, 3);

			roadmodify4.PackStart(common4, true, false, 3);
			roadmodify4.PackStart(tram4, true, false, 3);
			roadmodify4.PackStart(electrified4, true, false, 3);

			roadmodify5.PackStart(common5, true, false, 3);
			roadmodify5.PackStart(tram5, true, false, 3);
			roadmodify5.PackStart(electrified5, true, false, 3);


			Label time = new Label("Elapsed time:");
			Label sumTime = new Label("Total time:");
			Label sumStopTime = new Label("Total stop time:");
			Label transports = new Label("Number of transports:");

			Button start = new Button("START");
			Button stop = new Button("STOP");
			start.Clicked += Start_Click;

			win.Add(table);

			table.Attach(buttons, 0, 1, 0, 1);
			table.Attach(roads, 0, 1, 1, 2);
			table.Attach(status, 0, 1, 2, 3);

			roads.Attach(roadmodify1, 0, 1, 0, 1);
			roads.Attach(roadmodify2, 0, 1, 1, 2);
			roads.Attach(roadmodify3, 0, 1, 2, 3);
			roads.Attach(roadmodify4, 0, 1, 3, 4);
			roads.Attach(roadmodify5, 0, 1, 4, 5);

			roads.Attach(roadProgress1, 1, 2, 0, 1);
			roads.Attach(roadProgress2, 1, 2, 1, 2);
			roads.Attach(roadProgress3, 1, 2, 2, 3);
			roads.Attach(roadProgress4, 1, 2, 3, 4);
			roads.Attach(roadProgress5, 1, 2, 4, 5);

			roads.Attach(addTransport1, 2, 3, 0, 1);
			roads.Attach(addTransport2, 2, 3, 1, 2);
			roads.Attach(addTransport3, 2, 3, 2, 3);
			roads.Attach(addTransport4, 2, 3, 3, 4);
			roads.Attach(addTransport5, 2, 3, 4, 5);

			status.Attach(time, 0, 1, 0, 1);
			status.Attach(sumTime, 1, 2, 0, 1);
			status.Attach(sumStopTime, 2, 3, 0, 1);
			status.Attach(transports, 3, 4, 0, 1);

			buttons.Attach(start, 1, 2, 0, 1);
			buttons.Attach(stop, 2, 3, 0, 1);

			win.ShowAll();

			Application.Run();
		}
	}
}
