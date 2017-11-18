using System;
namespace Road111
{
	public partial class TransportDialog1 : Gtk.Dialog
	{
		public TransportDialog1()
		{
			this.Build();
		}

		protected void Ok_Button(object sender, EventArgs e)
		{
			this.Destroy();
		}

		protected void Cancel_Button(object sender, EventArgs e)
		{
            this.Destroy();
		}
	}
}
