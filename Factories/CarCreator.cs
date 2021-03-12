using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class CarCreator : TransportFactory
    {

        public CarCreator()
        {
            Name = "Car";
        }

        public override ITransport Create(Object[] args)
        {
            return new Car((string)args[0], (TEngType)args[1], (bool)args[2]);
        }
    }
}
