using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    sealed class Car : Land
    {
        private bool isHaveAutopilot;

        public Car(string Manufacturer) : base(Manufacturer) { }

        public Car(string Manufacturer, TEngType EngineType, bool isHaveAutopilot) : base(Manufacturer) 
        {
            this.EngineType = EngineType;
            this.isHaveAutopilot = isHaveAutopilot;
        }

        private void SetupAutopilot()
        {
            Console.WriteLine("Setup autopilot? (y/n)");
            if (Console.ReadLine() == "y")
                isHaveAutopilot = true;
            else
                isHaveAutopilot = false;
        }

        public override string PrintInfo()
        {
            return $"car '{Manufacturer}' with {EngineType} engine type" + ((isHaveAutopilot) ? " with autopilot." : ".");
        }

        public override void AskInfo()
        {
            Console.WriteLine("Car transport\n");
            base.AskInfo();
            SetupAutopilot();
        }

    }
}
