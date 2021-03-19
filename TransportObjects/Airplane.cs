using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OOP
{
    [Serializable]
    public sealed class Airplane : Air
    {

        public Airplane()
        {
            Name = "Airplane";
        }

        public Airplane(string Manufacturer) : base(Manufacturer)
        {
            Name = "Airplane";
        }

        public Airplane(string Manufacturer, TEngine Engine, bool IsHaveParachute) : base(Manufacturer)
        {
            this.Engine = Engine;
            this.IsHaveParachute = IsHaveParachute;
            Name = "Airplane";
        }

        public TEngine Engine { get; set; }

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
                    break;
                default:
                    Console.WriteLine("Choosed default value");
                    Engine = TEngine.jet;
                    break;
            }
        }

        public override string PrintInfo()
        {
            return $"airplane '{Manufacturer}' with {Engine} engine" + ((IsHaveParachute) ? " with parachute." : ".");
        }

        public override void AskInfo()
        {
            Console.WriteLine("Airplane\n");
            base.AskInfo();
            ChooseEngine();
        }

    }
}
