using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public static bool progress = false;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void TransportInfo1_clicked(object sender, EventArgs e)
	{
		Road111.TransportDialog1 dlg = new Road111.TransportDialog1();
		dlg.Show();
	}

	protected void ToggleProgress(object sender, EventArgs e)
	{
		progressbar1.Pulse();
		progressbar2.Pulse();
		progressbar3.Pulse();
		progressbar4.Pulse();
		progressbar5.Pulse();
	}

}
