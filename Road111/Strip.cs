using System;
using System.Collections.Generic;
namespace Road111
{
    public class Strip
    {
        private String type;
        public Strip()
        {
        }
        public Strip(String name)
        {
            this.type = name;
        }
        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        public bool Equals(Strip s)
        {
            if (this.Type.Equals(s.Type))
                return true;
            else
                return false;
                
        }
    }
}
