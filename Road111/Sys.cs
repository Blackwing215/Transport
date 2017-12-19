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
            /*for (int i = 0; i < 5;i++)
            {
                listT.Add(new Vehicle());
            }*/
        }
        public List<Fuel> getFuelList()
        {
            return listF;
        }
        public List<Vehicle> getTransportList()
        {
            return listT;
        }
        public void writeJ(int road,Vehicle veh)//запись в журнал
        {
<<<<<<< HEAD
            //создание файла
            Workbook book = Workbook.Load(file);
            Worksheet sheet = book.Worksheets[0];
            if(veh.Stop_C == 0)
            {
                sheet.Cells[0, road] = new Cell(veh.Name);
                veh.Stop_C++;
            }
            else
            {
                sheet.Cells[veh.Stop_C, road] = new Cell(veh.Distance);
                veh.Stop_C++;
            }
            book.Worksheets.Add(sheet);  
            book.Save(file);  
            //чтение файла  
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
                iter = tsListStore.AppendValues(Convert.ToString(sheet.Cells[0, i]));
                for (int j = 1; j < listT[i].Stop_C;j++)
                    tsListStore.AppendValues(iter, " ",Convert.ToString(sheet.Cells[j, i]));
            }
            tree.Model = tsListStore;

            window.ShowAll();
=======
                Excel.Application ObjExcel = new Excel.Application();
                ObjExcel.Visible = true;
                Excel.Workbook ObjWorkBook;
                Excel.Worksheet ObjWorkSheet;
                ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
                ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
                ObjWorkSheet.Cells[3, 1] = "51";
                ObjExcel.Quit();
>>>>>>> MaxBranch
        }
    }
}
