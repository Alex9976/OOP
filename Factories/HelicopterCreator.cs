using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class HelicopterCreator : TransportFactory
    {

        public HelicopterCreator() 
        {
            Name = "Helicopter";
        }

        public override ITransport Create(Object[] args)
        {
            return new Helicopter((string)args[0], (int)args[1], (bool)args[2]);
        }
    }
}
