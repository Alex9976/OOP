using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    class BoatCreator : TransportFactory<Boat>
    {
        public override Boat Create(Object[] args)
        {
            return new Boat((string)args[0]);
        }
    }
}
