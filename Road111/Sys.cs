using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelLibrary.SpreadSheet;
namespace Road111
{
    public class Sys
    {
        private List<Fuel> listF;
        private List<Vehicle> listT;
		private List<Strip> listS;
        private Excel.Application journal;
        private string file = "Journal.xls";
        private Workbook workbook;
        private Worksheet worksheet;
        public void addFuel(Fuel _name)
        {
            listF.Add(_name); 
        }
        public Sys()
        {
             workbook = new Workbook();  
             worksheet = new Worksheet("Журнал"); 
            workbook.Worksheets.Add(worksheet);  
             workbook.Save(file);  
            listF = new List<Fuel>();
            listT = new List<Vehicle>(5);
			listS = new List<Strip>(5);
            for (int i = 0; i < 5; i++)
            {
				listS.Insert(i, new Strip());
            }
			for (int i = 0; i < 5; i++)
			{
				listT.Insert(i, null);
			}
        }

        public List<Fuel> getFuelList()
        {
            return listF;
        }
        public List<Vehicle> getTransportList()
        {
            return listT;
        }

        public void writeJ(int road, Vehicle veh)//запись в журнал
        {
			Workbook book = Workbook.Load(file);
			Worksheet sheet = book.Worksheets[0];
			if (Road111.MainClass.getSystem().getTransportList()[road] != null)
			{
				//создание файла

				if (veh.Stop_C == 0)
				{
					sheet.Cells[0, road] = new Cell(veh.Name);
					veh.Stop_C++;
				}
				else
				{
					if (veh.Distance % (MainWindow.RoadLength / 10) < (MainWindow.RoadLength / 50))
					{
						sheet.Cells[veh.Stop_C, road] = new Cell(veh.Distance);
						//sheet.Cells[veh.Stop_C, road] = new Cell(veh.Stop_C*50);
						veh.Stop_C++;
					}
				}
				book.Worksheets.Add(sheet);
				book.Save(file);
				//чтение файла  
			}
        }
        public void ViewJournal()
        {
            Gtk.Window window = new Gtk.Window("Journal");
            window.SetSizeRequest(500, 200);

            Gtk.TreeView tree = new Gtk.TreeView();
            window.Add(tree);

            Gtk.TreeViewColumn tsColumn = new Gtk.TreeViewColumn();
            tsColumn.Title = "Транспортное средство";

            Gtk.CellRendererText tsNameCell = new Gtk.CellRendererText();

            tsColumn.PackStart(tsNameCell, true);

            Gtk.TreeViewColumn distanceColumn = new Gtk.TreeViewColumn();
            distanceColumn.Title = "Запись";

            Gtk.CellRendererText distanceTitleCell = new Gtk.CellRendererText();
            distanceColumn.PackStart(distanceTitleCell, true);

            tree.AppendColumn(tsColumn);
            tree.AppendColumn(distanceColumn);

            tsColumn.AddAttribute(tsNameCell, "text", 0);
            distanceColumn.AddAttribute(distanceTitleCell, "text", 1);

            Gtk.TreeStore tsListStore = new Gtk.TreeStore(typeof(string), typeof(string));
            Gtk.TreeIter iter;
            Workbook book = Workbook.Load(file);
            Worksheet sheet = book.Worksheets[0];
            for (int i = 0; i < listT.Count;i++)
            {
				if (listT[i] != null)
				{
					iter = tsListStore.AppendValues(Convert.ToString(sheet.Cells[0, i]));
					for (int j = 1; j < listT[i].Stop_C; j++)
						tsListStore.AppendValues(iter, " ", Convert.ToString(sheet.Cells[j, i]));
				}
            }
            tree.Model = tsListStore;

            window.ShowAll();
        }
    }
}
