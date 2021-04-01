using System;

namespace OOP
{

    [Serializable]
    public abstract class Sea : Transport
    {

        public Sea() { }

        public Sea(string Manufacturer) : base(Manufacturer) { }

        public TTravelWay TravelWay { get; set; }

        public override string PrintInfo()
        {
            return $"You choose a {TravelWay} sea transport '{Manufacturer}'";
        }

        public override void AskInfo(Object[] args) { }

        public override Object[] GetInfo()
        {
            return new Object[1];
        }

    }
}
