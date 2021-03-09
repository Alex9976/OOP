using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class BusCreator : TransportFactory<Bus>
    {

        private BusCreator() { }

        private static BusCreator instance;

        public static BusCreator getInstance()
        {
            if (instance == null)
            {
                instance = new BusCreator();
            }
            return instance;
        }

        public override Bus Create(Object[] args)
        {
            return new Bus((string)args[0]);
        }
    }
}
