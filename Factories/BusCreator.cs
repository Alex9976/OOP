using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class BusCreator : TransportFactory
    {

        public BusCreator() 
        {
            Name = "Bus";
            ImgPath = "";
        }

        public override string Question1()
        {
            return "Engine Type:";
        }

        public override string Question2()
        {
            return "Info Panel:";
        }

        public override string[] Answer()
        {
            return new string[] { "Petrol", "Diesel", "Gas", "Electricity" };
        }


        public override ITransport Create(Object[] args)
        {
            return new Bus((string)args[0], (TEngType)args[1], (bool)args[2]);
        }
    }
}
