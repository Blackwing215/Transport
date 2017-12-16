using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
namespace Road111
{
    public class Sys
    {
        private List<Fuel> listF;
        private List<Vehicle> listT;
        private Excel.Application journal;
        public void addFuel(Fuel _name)
        {
            listF.Add(_name); 
        }
        public Sys()
        {
            File.Create("mike.doc");
            listF = new List<Fuel>();
            listT = new List<Vehicle>(5);
            for (int i = 0; i < 5;i++)
            {
                listT.Add(new Vehicle());
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
        public void writeJ()
        {
            try
            {
                Excel.Application ObjExcel = new Excel.Application();
                Excel.Workbook ObjWorkBook;
                Excel.Worksheet ObjWorkSheet;
                ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
                ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
                ObjWorkSheet.Cells[3, 1] = "51";
                ObjWorkBook.SaveAs("log.xlsx", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive,
         Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                ObjExcel.Quit();
            }
            catch (Exception exc)
            {
                Console.WriteLine("dfdf");
            }
        }
    }
}
