using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{

    abstract class Land : Transport
    {
        public TEngType EngineType { get; set; }

        public Land(string Manufacturer) : base(Manufacturer) { }

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

        public override string PrintInfo()
        {
            return $"You choose a land transport '{Manufacturer}' with {EngineType} engine type";
        }

        public override void AskInfo()
        {
            ChooseEngineType();
        }

    }
}
