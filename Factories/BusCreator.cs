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
        }


        public override ITransport Create(Object[] args)
        {
            return new Bus((string)args[0], (TEngType)args[1], (bool)args[2]);
        }
    }
}
