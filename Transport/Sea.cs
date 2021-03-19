using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{

    [Serializable]
    public abstract class Sea : Transport
    {

        public Sea() { }

        public Sea(string Manufacturer) : base(Manufacturer) { }

        public TTravelWay TravelWay { get; set; }

        public void ChooseTravelWay()
        {
            Console.WriteLine("1. Automotive, 2. Towed, 3. Alloyed 4. Drifting");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    TravelWay = TTravelWay.automotive;
                    break;
                case 2:
                    TravelWay = TTravelWay.towed;
                    break;
                case 3:
                    TravelWay = TTravelWay.alloyed;
                    break;
                case 4:
                    TravelWay = TTravelWay.drifting;
                    break;
                default:
                    Console.WriteLine("Choosed default value");
                    TravelWay = TTravelWay.automotive;
                    break;
            }
        }


        public override string PrintInfo()
        {
            return $"You choose a {TravelWay} sea transport '{Manufacturer}'";
        }

        public override void AskInfo()
        {
            ChooseTravelWay();
        }

    }
}
