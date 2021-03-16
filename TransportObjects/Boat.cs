using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    sealed class Boat : Sea
    {
        public Boat(string Manufacturer) : base(Manufacturer) { }

        public Boat(string Manufacturer, TTravelWay TravelWay, bool IsHaveMotor) : base(Manufacturer) 
        {
            this.TravelWay = TravelWay;
            this.IsHaveMotor = IsHaveMotor;
        }

        public bool IsHaveMotor { get; set; }

        public override string PrintInfo()
        {
            return $"You choose a {TravelWay} sea transport '{Manufacturer}'" + ((IsHaveMotor) ? " with motor." : ".");
        }

        public override void AskInfo()
        {
            base.AskInfo();
        }
    }
}
