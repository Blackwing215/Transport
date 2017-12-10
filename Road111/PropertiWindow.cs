using System;
namespace Road111
{
    public partial class PropertiWindow : Gtk.Window
    {
        public PropertiWindow(String name) :
                base(Gtk.WindowType.Toplevel)
        {

            this.Build();
            this.Title = name;
        }
        protected void OnButton266Clicked(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void setParametrs(Vehicle ts)
        {
            this.label6.Text = ts.Name;
            this.label14.Text = ts.Type;
            this.label15.Text = ts.Fuel.GetFuel();
            this.label17.Text = Convert.ToString(ts.MaxSpeed);
            this.QueueDraw();
        }
    }
}
