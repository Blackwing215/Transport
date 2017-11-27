using System;
using System.Collections.Generic;
namespace Road111
{
    public class Sys
    {
        private List<Fuel> listF;
        public void addFuel(Fuel _name)
        {
            listF.Add(_name); 
        }
        public Sys()
        {
            listF = new List<Fuel>();
        }
        public List<Fuel> getFuelList()
        {
            return listF;
        }
    }
}
