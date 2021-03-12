using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    sealed class Helicopter : Air
    {
        public Helicopter(string Manufacturer) : base(Manufacturer) { }

        public Helicopter(string Manufacturer, int MaxAltitude, bool isHaveParachute) : base(Manufacturer) 
        {
            this.MaxAltitude = MaxAltitude;
            this.isHaveParachute = isHaveParachute;
        }

        private bool isHaveParachute;

        private void Parachute()
        {
            Console.WriteLine("Is have parachute? (y/n)");
            if (Console.ReadLine() == "y")
                isHaveParachute = true;
            else
                isHaveParachute = false;
        }

        public override string PrintInfo()
        {
            return $"You choose a helicopter '{Manufacturer}' with maximum altitude {MaxAltitude} meters" +
                              ((isHaveParachute) ? " with parachute." : ".");
        }

        public override void AskInfo()
        {
            Console.WriteLine("Helicopter\n");
            base.AskInfo();
            Parachute();
        }

    }
}
