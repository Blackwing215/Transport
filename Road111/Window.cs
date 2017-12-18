using System;
namespace Road111
{
    public partial class Window : Gtk.Window
    {
        public Window() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            nodeview2.AppendColumn("Artist", new Gtk.CellRendererText(), "text", 0);     
        }
    }
}
