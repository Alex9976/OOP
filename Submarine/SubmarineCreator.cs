using OOP.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submarine
{
    class SubmarineCreator : ITransportFactoryPlugin
    {
        public string ImgPath { get; set; }

        public SubmarineCreator()
        {
            ImgPath = "submarine.jpg";
        }

        public string Question1()
        {
            return "Travel Way:";
        }

        public string Question2()
        {
            return "Is atomic";
        }

        public string[] Answer()
        {
            return new string[] { "Automotive", "Towed", "Alloyed", "Drifting" };
        }

        public ITransportPlugin Create(Object[] args)
        {
            return new Submarine((string)args[0], (TSubmarineTravelWay)args[1], (bool)args[2]);
        }
    }
}
