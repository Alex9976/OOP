using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    abstract class Transport
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public float Cost { get; set; }

        public Transport(string name)
        {
            this.Name = name;
        }

    }
}
