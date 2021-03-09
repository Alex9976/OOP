using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class CarCreator : TransportFactory<Car>
    {

        private CarCreator() { }

        private static CarCreator instance;

        public static CarCreator getInstance()
        {
            if (instance == null)
            {
                instance = new CarCreator();
            }
            return instance;
        }

        public override Car Create(Object[] args)
        {
            return new Car((string)args[0]);
        }
    }
}
