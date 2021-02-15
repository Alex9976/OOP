using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    enum TEngType { petrol = 1, diesel, gas, electricity } 

    abstract class Land : Transport
    {
        public TEngType EngineType;

        public Land(string name) : base(name){}

        private void ChooseEngineType()
        {
            Console.WriteLine("1. Petrol, 2. Diesel, 3. Gas 4. Electricity");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    EngineType = TEngType.petrol;
                    break;
                case 2:
                    EngineType = TEngType.diesel;
                    break;
                case 3:
                    EngineType = TEngType.gas;
                    break;
                case 4:
                    EngineType = TEngType.electricity;
                    break;
                default:
                    Console.WriteLine("Choosed default value");
                    EngineType = TEngType.petrol;
                    break;
            }
        }

    }
}
