using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OOP
{
    [XmlInclude(typeof(Airplane))]
    [XmlInclude(typeof(Boat))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Helicopter))]
    [Serializable]
    public abstract class Transport
    {
        public string Manufacturer { get; set; }

        public string Name { get; set; }

        public Transport() { }

        public Transport(string Manufacturer)
        {
            this.Manufacturer = Manufacturer;
        }

        public abstract string PrintInfo();

        public abstract void AskInfo(Object[] args);

        public abstract Object[] GetInfo();

    }
}
