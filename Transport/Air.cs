using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{

    abstract class Air : Transport
    {
        public Air(string Manufacturer) : base(Manufacturer) {}

        private float maxAltitude;
        protected float MaxAltitude
        {
            get
            {
                return maxAltitude;
            }
            set
            {
                if (value > 0)
                    maxAltitude = value;
                else maxAltitude = 0;
            }
        }

        private void ChooseAltitude()
        {
            Console.WriteLine("Max altitude, meters:");
            maxAltitude = Convert.ToSingle(Console.ReadLine());
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"You choose a air transport '{Manufacturer}' with maximum altitude {maxAltitude} meters.\n");
        }

        public override void AskInfo()
        {
            ChooseAltitude();
        }

    }
}
