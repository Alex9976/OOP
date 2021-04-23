using System;
using System.Collections.Generic;
using System.Text;
using OOP.Sdk;

namespace OOP
{
    class BoatCreator : TransportFactory
    {
        public BoatCreator() 
        {
            ImgPath = "boat.jpg";
        }

        public override string Question1()
        {
            return "Travel Way:";
        }

        public override string Question2()
        {
            return "Motor";
        }

        public override string[] Answer()
        {
            return new string[] { "Automotive", "Towed", "Alloyed", "Drifting" };
        }

        public override ITransportPlugin Create(Object[] args)
        {
            return new Boat((string)args[0], (TTravelWay)args[1], (bool)args[2]);
        }
    }
}
