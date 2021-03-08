using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    class HelicopterCreator : TransportFactory<Helicopter>
    {
        public override Helicopter Create(Object[] args)
        {
            return new Helicopter((string)args[0]);
        }
    }
}
