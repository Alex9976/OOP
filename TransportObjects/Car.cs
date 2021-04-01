using System;

namespace OOP
{

    [Serializable]
    public sealed class Car : Land
    {
        public bool IsHaveAutopilot { get; set; }

        public Car() 
        {
            Name = "Car";
        }

        public Car(string Manufacturer) : base(Manufacturer) 
        {
            Name = "Car";
        }

        public Car(string Manufacturer, TEngType EngineType, bool IsHaveAutopilot) : base(Manufacturer) 
        {
            this.EngineType = EngineType;
            this.IsHaveAutopilot = IsHaveAutopilot;
            Name = "Car";
        }

        public override string PrintInfo()
        {
            return $"A car '{Manufacturer}' with {EngineType} engine type" + ((IsHaveAutopilot) ? " with autopilot." : ".");
        }

        public override void AskInfo(Object[] args)
        {
            Manufacturer = (string)args[0];
            EngineType = (TEngType)args[1];
            IsHaveAutopilot = (bool)args[2];
        }

        public override Object[] GetInfo()
        {
            Object[] obj = new Object[3];
            obj[0] = Manufacturer;
            obj[1] = EngineType;
            obj[2] = IsHaveAutopilot;
            return obj;
        }

    }
}
