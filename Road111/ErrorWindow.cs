using System;
namespace Road111
{
    public partial class ErrorWindow : Gtk.Window
    {
        public ErrorWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
