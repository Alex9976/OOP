using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class BoatCreator : TransportFactory<Boat>
    {

        private BoatCreator() { }

        private static BoatCreator instance;

        public static BoatCreator getInstance()
        {
            if (instance == null)
            {
                instance = new BoatCreator();
            }
            return instance;
        }

        public override Boat Create(Object[] args)
        {
            return new Boat((string)args[0]);
        }
    }
}
