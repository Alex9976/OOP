using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    sealed class Bus : Land
    {

        private bool isHaveInfoPanel;

        public Bus(string Manufacturer) : base(Manufacturer) { }

        public Bus(string Manufacturer, TEngType EngineType, bool isHaveInfoPanel) : base(Manufacturer)
        {
            this.EngineType = EngineType;
            this.isHaveInfoPanel = isHaveInfoPanel;
        }

        private void SetupInfoPanel()
        {
            Console.WriteLine("Setup info panel? (y/n)");
            if (Console.ReadLine() == "y")
                isHaveInfoPanel = true;
            else
                isHaveInfoPanel = false;
        }

        public override string PrintInfo()
        {
            return $"bus '{Manufacturer}' with {EngineType} engine type" + ((isHaveInfoPanel) ? "with info panel." : ".");
        }

        public override void AskInfo()
        {
            Console.WriteLine("Bus\n");
            base.AskInfo();
            SetupInfoPanel();
        }
    }
}
