using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{

    [Serializable]
    public abstract class Air : Transport
    {

        public Air() { }

        public Air(string Manufacturer) : base(Manufacturer) {}

        public bool IsHaveParachute { get; set; }

        public void Parachute()
        {
            Console.WriteLine("Is have parachute? (y/n)");
            if (Console.ReadLine() == "y")
                IsHaveParachute = true;
            else
                IsHaveParachute = false;
        }

        public override string PrintInfo()
        {
            return $"You choose a air transport '{Manufacturer}'" + ((IsHaveParachute) ? " with parachute." : ".");
        }

        public override void AskInfo()
        {
            Parachute();
        }

    }
}
