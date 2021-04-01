using System;

namespace OOP
{
    [Serializable]
    public sealed class Boat : Sea
    {
        
        public Boat() 
        {
            Name = "Boat";
        }

        public Boat(string Manufacturer) : base(Manufacturer) 
        {
            Name = "Boat";
        }

        public Boat(string Manufacturer, TTravelWay TravelWay, bool IsHaveMotor) : base(Manufacturer) 
        {
            this.TravelWay = TravelWay;
            this.IsHaveMotor = IsHaveMotor;
            Name = "Boat";
        }

        public bool IsHaveMotor { get; set; }

        public override string PrintInfo()
        {
            return $"A {TravelWay} sea transport '{Manufacturer}'" + ((IsHaveMotor) ? " with motor." : ".");
        }

        public override void AskInfo(Object[] args)
        {
            Manufacturer = (string)args[0];
            TravelWay = (TTravelWay)args[1];
            IsHaveMotor = (bool)args[2];
        }

        public override Object[] GetInfo()
        {
            Object[] obj = new Object[3];
            obj[0] = Manufacturer;
            obj[1] = TravelWay;
            obj[2] = IsHaveMotor;
            return obj;
        }
    }
}
