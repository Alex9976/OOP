using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    abstract class Transport
    {
        public string Manufacturer { get; set; }

        public Transport(string Manufacturer)
        {
            this.Manufacturer = Manufacturer;
        }

        public abstract void PrintInfo();
        public abstract void AskInfo();

    }
}
