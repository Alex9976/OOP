﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class HelicopterCreator : TransportFactory
    {

        public HelicopterCreator() 
        {
            Name = "Helicopter";
            ImgPath = "";
        }

        public override string Question1()
        {
            return "Purpose:";
        }

        public override string Question2()
        {
            return "Parachute:";
        }

        public override string[] Answer()
        {
            return new string[] { "Multipurpose", "Passenger", "Transport", "Search", "Agricultural" };
        }


        public override ITransport Create(Object[] args)
        {
            return new Helicopter((string)args[0], (TPurpose)args[1], (bool)args[2]);
        }
    }
}