using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    enum TEngine { jet = 1, turboprop }

    class Airplane : Air
    {
        public Airplane(string Manufacturer) : base(Manufacturer) { }

        private TEngine Engine { get; set; }

        private void ChooseEngine()
        {
            Console.WriteLine("1. Jet, 2. Turboprop");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Engine = TEngine.jet;
                    break;
                case 2:
                    Engine = TEngine.turboprop;
                    if (MaxAltitude > 10000)
                        MaxAltitude = 10000;
                    break;
                default:
                    Console.WriteLine("Choosed default value");
                    Engine = TEngine.jet;
                    break;
            }
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"You choose a air transport '{Manufacturer}' wih {Engine} engine, with maximum altitude {MaxAltitude} meters.\n");
        }

        public override void AskInfo()
        {
            Console.WriteLine("Airplane\n");
            base.AskInfo();
            ChooseEngine();
        }

    }
}
