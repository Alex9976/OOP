using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    class AirplaneCreator : TransportFactory<Airplane>
    {
        public override Airplane Create(Object[] args)
        {
            return new Airplane((string) args[0]);
        }
    }
} 
