using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class HelicopterCreator : TransportFactory<Helicopter>
    {

        private HelicopterCreator() { }

        private static HelicopterCreator instance;

        public static HelicopterCreator getInstance()
        {
            if (instance == null)
            {
                instance = new HelicopterCreator();
            }
            return instance;
        }

        public override Helicopter Create(Object[] args)
        {
            return new Helicopter((string)args[0]);
        }
    }
}
