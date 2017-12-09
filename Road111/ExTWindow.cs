using System;
namespace Road111
{
    public partial class ExTWindow : Gtk.Window
    {
        public ExTWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            this.Destroy();
        }
    }
}
