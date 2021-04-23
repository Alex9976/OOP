using System;

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

        public override string PrintInfo()
        {
            return $"A airplane '{Manufacturer}' with {Engine} engine" + ((IsHaveParachute) ? " with parachute." : ".");
        }

        public override void AskInfo(Object[] args)
        {
            Manufacturer = (string)args[0];
            Engine = (TEngine)args[1];
            IsHaveParachute = (bool)args[2];
        }

        public override Object[] GetInfo()
        {
            Object[] obj = new Object[3];
            obj[0] = Manufacturer;
            obj[1] = Engine;
            obj[2] = IsHaveParachute;
            return obj;
        }
    }
}
