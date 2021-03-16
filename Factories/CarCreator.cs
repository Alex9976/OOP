using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class CarCreator : TransportFactory
    {

        public CarCreator()
        {
            Name = "Car";
            ImgPath = "C:\\Users\\alexa\\source\\repos\\OOPLab1\\bin\\Debug\\car.jpg";
        }

        public override string Question1()
        {
            return "Engine Type:";
        }

        public override string Question2()
        {
            return "Autopilot:";
        }

        public override string[] Answer()
        {
            return new string[] { "Petrol", "Diesel", "Gas", "Electricity" };
        }

        public override ITransport Create(Object[] args)
        {
            return new Car((string)args[0], (TEngType)args[1], (bool)args[2]);
        }
    }
}
