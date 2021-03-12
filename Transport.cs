using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    abstract class Transport : ITransport
    {
        public string Manufacturer { get; set; }

        public Transport(string Manufacturer)
        {
            this.Manufacturer = Manufacturer;
        }

        public abstract string PrintInfo();
        public abstract void AskInfo();

    }
}
