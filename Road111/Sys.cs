using System;
using System.Collections.Generic;
namespace Road111
{
    public class Sys
    {
        private List<Fuel> listF;
        private List<Vehicle> listT;
        public void addFuel(Fuel _name)
        {
            listF.Add(_name); 
        }
        public Sys()
        {
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
    }
}
