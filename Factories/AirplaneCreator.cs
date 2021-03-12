using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class AirplaneCreator : TransportFactory
    {

        public AirplaneCreator() 
        {
            Name = "Airplane";
        }

        public override ITransport Create(Object[] args)
        {
            return new Airplane((string) args[0], (int)args[1], (TEngine)args[2]);
        }
    }
} 
