using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    class Helicopter : Air
    {
        public Helicopter(string Manufacturer) : base(Manufacturer) { }

        private bool isHaveParachute;

        private void Parachute()
        {
            Console.WriteLine("Is have parachute? (y/n)");
            if (Console.ReadLine() == "y")
                HaveParachute();
            else
                HaveNotParachute();
        }

        private void HaveParachute()
        {
            isHaveParachute = true;
        }

        private void HaveNotParachute()
        {
            isHaveParachute = false;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"You choose a helicopter '{Manufacturer}' with maximum altitude {MaxAltitude} meters" +
                              ((isHaveParachute) ? " with parachute.\n" : ".\n"));
        }

        public override void AskInfo()
        {
            Console.WriteLine("Helicopter\n");
            base.AskInfo();
            Parachute();
        }

    }
}
