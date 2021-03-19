using System;

namespace OOP
{

    [Serializable]
    public sealed class Bus : Land
    {

        public bool IsHaveInfoPanel { get; set; }

        public Bus() 
        {
            Name = "Bus";
        }

        public Bus(string Manufacturer) : base(Manufacturer) 
        {
            Name = "Bus";
        }

        public Bus(string Manufacturer, TEngType EngineType, bool IsHaveInfoPanel) : base(Manufacturer)
        {
            this.EngineType = EngineType;
            this.IsHaveInfoPanel = IsHaveInfoPanel;
            Name = "Bus";
        }

        public override string PrintInfo()
        {
            return $"bus '{Manufacturer}' with {EngineType} engine type" + ((IsHaveInfoPanel) ? "with info panel." : ".");
        }

        public override void AskInfo(Object[] args)
        {
            Manufacturer = (string)args[0];
            EngineType = (TEngType)args[1];
            IsHaveInfoPanel = (bool)args[2];
        }

        public override Object[] GetInfo()
        {
            Object[] obj = new Object[3];
            obj[0] = Manufacturer;
            obj[1] = EngineType;
            obj[2] = IsHaveInfoPanel;
            return obj;
        }
    }
}
