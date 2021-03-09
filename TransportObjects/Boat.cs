using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    sealed class Boat : Sea
    {
        public Boat(string Manufacturer) : base(Manufacturer) { }

        public Boat(string Manufacturer, float MaxSpeed) : base(Manufacturer) 
        {
            this.MaxSpeed = MaxSpeed;
        }
    }
}
