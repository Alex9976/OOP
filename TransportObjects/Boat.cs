using System;
using System.Collections.Generic;
using System.Text;

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
            return $"{TravelWay} sea transport '{Manufacturer}'" + ((IsHaveMotor) ? " with motor." : ".");
        }

        public override void AskInfo()
        {
            base.AskInfo();
        }
    }
}
