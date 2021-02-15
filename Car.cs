using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    class Car : Land
    {
        private bool isHaveAutopilot;

        public Car(string Manufacturer) : base(Manufacturer) { }

        private void SetupAutopilot()
        {
            Console.WriteLine("Setup autopilot? (y/n)");
            if (Console.ReadLine() == "y")
                InstallAutopilot();
            else
                UninstallAutopilot();
        }

        private void InstallAutopilot()
        {
            isHaveAutopilot = true;
        }

        private void UninstallAutopilot()
        {
            isHaveAutopilot = false;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"You choose a car '{Manufacturer}' with {EngineType} engine type " +
                              ((isHaveAutopilot) ? "with autopilot.\n" : ".\n"));
        }

        public override void AskInfo()
        {
            base.AskInfo();
            SetupAutopilot();
        }

    }
}
