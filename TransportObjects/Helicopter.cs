using System;

namespace OOP
{

    [Serializable]
    public sealed class Helicopter : Air
    {

        public Helicopter() 
        {
            Name = "Helicopter";
        }

        public Helicopter(string Manufacturer) : base(Manufacturer) 
        {
            Name = "Helicopter";
        }

        public Helicopter(string Manufacturer, TPurpose Purpose, bool IsHaveParachute) : base(Manufacturer) 
        {
            this.Purpose = Purpose;
            this.IsHaveParachute = IsHaveParachute;
            Name = "Helicopter";
        }

        public TPurpose Purpose { get; set; }

        public override string PrintInfo()
        {
            return $"{Purpose} helicopter '{Manufacturer}'" + ((IsHaveParachute) ? " with parachute." : ".");
        }

        public override void AskInfo(Object[] args)
        {
            Manufacturer = (string)args[0];
            Purpose = (TPurpose)args[1];
            IsHaveParachute = (bool)args[2];
        }

        public override Object[] GetInfo()
        {
            Object[] obj = new Object[3];
            obj[0] = Manufacturer;
            obj[1] = Purpose;
            obj[2] = IsHaveParachute;
            return obj;
        }

    }
}
