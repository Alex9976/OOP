using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    class BusCreator : TransportFactory<Bus>
    {
        public override Bus Create(Object[] args)
        {
            return new Bus((string)args[0]);
        }
    }
}
