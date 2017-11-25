using System;
using System.Collections.Generic;
namespace Road111
{
    public class Fuel
    {
        private string type;
        public Fuel(string name)
        {
            type = name;
        }
        protected void SetFuel(string _type)
        {
            type = _type;
        }
        public String GetFuel()
        {
            return type;
        }
    }
}
