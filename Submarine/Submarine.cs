using OOP.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submarine
{
    public enum TTravelWay { automotive = 1, towed, alloyed, drifting }

    [Serializable]
    class Submarine : ITransportPlugin
    {
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public TTravelWay TravelWay { get; set; }

        public bool IsAtomic { get; set; }

        public Submarine()
        {
            Name = "Submarine";
        }

        public Submarine(string Manufacturer, TTravelWay TravelWay, bool IsAtomic)
        {
            this.Manufacturer = Manufacturer;
            this.TravelWay = TravelWay;
            this.IsAtomic = IsAtomic;
            Name = "Submarine";
        }


        public string PrintInfo()
        {
            return $"{TravelWay} sea transport '{Manufacturer}'" + ((IsAtomic) ? " with motor." : ".");
        }

        public void AskInfo(Object[] args)
        {
            Manufacturer = (string)args[0];
            TravelWay = (TTravelWay)args[1];
            IsAtomic = (bool)args[2];
        }

        public Object[] GetInfo()
        {
            Object[] obj = new Object[3];
            obj[0] = Manufacturer;
            obj[1] = TravelWay;
            obj[2] = IsAtomic;
            return obj;
        }
    }

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
            return "Is atomic:";
        }

        public string[] Answer()
        {
            return new string[] { "Automotive", "Towed", "Alloyed", "Drifting" };
        }

        public ITransportPlugin Create(Object[] args)
        {
            return new Submarine((string)args[0], (TTravelWay)args[1], (bool)args[2]);
        }
    }
}
