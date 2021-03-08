using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    class CarCreator : TransportFactory<Car>
    {
        public override Car Create(Object[] args)
        {
            return new Car((string)args[0]);
        }
    }
}
