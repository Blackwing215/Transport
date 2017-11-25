
// This file has been generated by the GUI designer. Do not modify.
namespace Road111
{
	public partial class TransportDialog1
	{
		private global::Gtk.Table table5;

		private global::Gtk.Entry entry7;

		private global::Gtk.Entry entry9;

		private global::Gtk.HBox hbox3;

		private global::Gtk.RadioButton benzin_rad;

		private global::Gtk.RadioButton dizel_rad;

		private global::Gtk.RadioButton electro_rad;

		private global::Gtk.Label Param1;

		private global::Gtk.Label Param2;

		private global::Gtk.Label Param3;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Button buttonOk;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Road111.TransportDialog1
			this.Name = "Road111.TransportDialog1";
			this.WindowPosition = ((global::Gtk.WindowPosition)(2));
			this.Resizable = false;
			// Internal child Road111.TransportDialog1.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(3));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.table5 = new global::Gtk.Table(((uint)(4)), ((uint)(2)), false);
			this.table5.Name = "table5";
			this.table5.RowSpacing = ((uint)(10));
			this.table5.ColumnSpacing = ((uint)(6));
			// Container child table5.Gtk.Table+TableChild
			this.entry7 = new global::Gtk.Entry();
			this.entry7.Sensitive = false;
			this.entry7.CanFocus = true;
			this.entry7.Name = "entry7";
			this.entry7.Text = global::Mono.Unix.Catalog.GetString("param 1 value");
			this.entry7.IsEditable = true;
			this.entry7.InvisibleChar = '●';
			this.table5.Add(this.entry7);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table5[this.entry7]));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.entry9 = new global::Gtk.Entry();
			this.entry9.Sensitive = false;
			this.entry9.CanFocus = true;
			this.entry9.Name = "entry9";
			this.entry9.Text = global::Mono.Unix.Catalog.GetString("param 3 value");
			this.entry9.IsEditable = true;
			this.entry9.InvisibleChar = '●';
			this.table5.Add(this.entry9);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table5[this.entry9]));
			w3.TopAttach = ((uint)(2));
			w3.BottomAttach = ((uint)(3));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.benzin_rad = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Бензин"));
			this.benzin_rad.Sensitive = false;
			this.benzin_rad.CanFocus = true;
			this.benzin_rad.Name = "benzin_rad";
			this.benzin_rad.Active = false;
			this.benzin_rad.DrawIndicator = true;
			this.benzin_rad.UseUnderline = true;
			this.benzin_rad.Group = new global::GLib.SList(global::System.IntPtr.Zero);
			this.hbox3.Add(this.benzin_rad);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.benzin_rad]));
			w4.Position = 0;
			// Container child hbox3.Gtk.Box+BoxChild
			this.dizel_rad = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Дизель"));
			this.dizel_rad.Sensitive = false;
			this.dizel_rad.CanFocus = true;
			this.dizel_rad.Name = "dizel_rad";
			this.dizel_rad.Active = false;
			this.dizel_rad.DrawIndicator = true;
			this.dizel_rad.UseUnderline = true;
			this.dizel_rad.Group = this.benzin_rad.Group;
			this.hbox3.Add(this.dizel_rad);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.dizel_rad]));
			w5.Position = 1;
			// Container child hbox3.Gtk.Box+BoxChild
			this.electro_rad = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Электричество"));
			this.electro_rad.Sensitive = false;
			this.electro_rad.CanFocus = true;
			this.electro_rad.Name = "electro_rad";
			this.electro_rad.Active = false;
			this.electro_rad.DrawIndicator = true;
			this.electro_rad.UseUnderline = true;
			this.electro_rad.Group = this.benzin_rad.Group;
			this.hbox3.Add(this.electro_rad);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.electro_rad]));
			w6.Position = 2;
			this.table5.Add(this.hbox3);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table5[this.hbox3]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.Param1 = new global::Gtk.Label();
			this.Param1.Name = "Param1";
			this.Param1.LabelProp = global::Mono.Unix.Catalog.GetString("Тип");
			this.table5.Add(this.Param1);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table5[this.Param1]));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.Param2 = new global::Gtk.Label();
			this.Param2.Name = "Param2";
			this.Param2.LabelProp = global::Mono.Unix.Catalog.GetString("Топливо");
			this.table5.Add(this.Param2);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table5[this.Param2]));
			w9.TopAttach = ((uint)(1));
			w9.BottomAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.Param3 = new global::Gtk.Label();
			this.Param3.Name = "Param3";
			this.Param3.Xalign = 0F;
			this.Param3.LabelProp = global::Mono.Unix.Catalog.GetString("Скорость");
			this.table5.Add(this.Param3);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table5[this.Param3]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			w1.Add(this.table5);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(w1[this.table5]));
			w11.Position = 0;
			// Internal child Road111.TransportDialog1.ActionArea
			global::Gtk.HButtonBox w12 = this.ActionArea;
			w12.Name = "dialog1_ActionArea";
			w12.Spacing = 10;
			w12.BorderWidth = ((uint)(5));
			w12.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget(this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w13 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w12[this.buttonCancel]));
			w13.Expand = false;
			w13.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget(this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w14 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w12[this.buttonOk]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 673;
			this.DefaultHeight = 521;
			this.Show();
			this.buttonCancel.Clicked += new global::System.EventHandler(this.Cancel_Button);
			this.buttonOk.Clicked += new global::System.EventHandler(this.Ok_Button);
		}
	}
}
