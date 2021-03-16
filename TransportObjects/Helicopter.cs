using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    sealed class Helicopter : Air
    {
        public Helicopter(string Manufacturer) : base(Manufacturer) { }

        public Helicopter(string Manufacturer, TPurpose Purpose, bool IsHaveParachute) : base(Manufacturer) 
        {
            this.Purpose = Purpose;
            this.IsHaveParachute = IsHaveParachute;
        }

        public TPurpose Purpose { get; set; }

        public void ChoosePurpose()
        {
            Console.WriteLine("1. Multipurpose, 2. Passenger, 3. Transport 4. Search 5. Agricultural");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Purpose = TPurpose.multipurpose;
                    break;
                case 2:
                    Purpose = TPurpose.passenger;
                    break;
                case 3:
                    Purpose = TPurpose.transport;
                    break;
                case 4:
                    Purpose = TPurpose.search;
                    break;
                case 5:
                    Purpose = TPurpose.agricultural;
                    break;
                default:
                    Console.WriteLine("Choosed default value");
                    Purpose = TPurpose.multipurpose;
                    break;
            }
        }

        public override string PrintInfo()
        {
            return $"{Purpose} helicopter '{Manufacturer}'" + ((IsHaveParachute) ? " with parachute." : ".");
        }

        public override void AskInfo()
        {
            Console.WriteLine("Helicopter\n");
            base.AskInfo();
            ChoosePurpose();
        }

    }
}
