using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class AirplaneCreator : TransportFactory<Airplane>
    {

        private AirplaneCreator() { }

        private static AirplaneCreator instance;

        public static AirplaneCreator getInstance()
        {
            if (instance == null)
            {
                instance = new AirplaneCreator();
            }
            return instance;
        }

        public override Airplane Create(Object[] args)
        {
            return new Airplane((string) args[0]);
        }
    }
} 
