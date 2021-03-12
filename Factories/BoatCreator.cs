using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class BoatCreator : TransportFactory
    {

        public BoatCreator() 
        {
            Name = "Boat";
        }

        public override ITransport Create(Object[] args)
        {
            return new Boat((string)args[0], (float)args[1]);
        }
    }
}
