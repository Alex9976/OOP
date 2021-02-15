using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    class Sea : Transport
    {
        public Sea(string Manufacturer) : base(Manufacturer) { }

        private float maxSpeed { get; set; }
        protected float MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                if (value > 0)
                    maxSpeed = value;
                else maxSpeed = 0;
            }
        }

        private void ChooseAltitude()
        {
            Console.WriteLine("Max speed, knots:");
            maxSpeed = Convert.ToInt32(Console.ReadLine());
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"You choose a sea transport '{Manufacturer}' with maximum altitude {maxSpeed} knots \n");
        }

        public override void AskInfo()
        {
            ChooseAltitude();
        }

    }
}
