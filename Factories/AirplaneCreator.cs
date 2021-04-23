using System;
using System.Collections.Generic;
using System.Text;
using OOP.Sdk;

namespace OOP
{
    class AirplaneCreator : TransportFactory
    {
        public AirplaneCreator() 
        {
            ImgPath = "airplane.jpg";
        }

        public override string Question1()
        {
            return "Engine:";
        }

        public override string Question2()
        {
            return "Parachute";
        }

        public override string[] Answer()
        {
            return new string[] { "Jet", "Turboprop" };
        }

        public override ITransportPlugin Create(Object[] args)
        {
            return new Airplane((string)args[0], (TEngine)args[1], (bool)args[2]);
        }
    }
} 
