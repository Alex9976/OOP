using System;
using System.Collections.Generic;
using System.Text;
using OOP.Sdk;

namespace OOP
{
    class HelicopterCreator : TransportFactory
    {
        public HelicopterCreator() 
        {
            ImgPath = "helicopter.jpg";
        }

        public override string Question1()
        {
            return "Purpose:";
        }

        public override string Question2()
        {
            return "Parachute";
        }

        public override string[] Answer()
        {
            return new string[] { "Multipurpose", "Passenger", "Transport", "Search", "Agricultural" };
        }


        public override ITransportPlugin Create(Object[] args)
        {
            return new Helicopter((string)args[0], (TPurpose)args[1], (bool)args[2]);
        }
    }
}
