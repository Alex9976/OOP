using System;

namespace OOP
{
    [Serializable]
    public abstract class Land : Transport
    {
        public TEngType EngineType { get; set; }

        public Land() { }

        public Land(string Manufacturer) : base(Manufacturer) { }

        public override string PrintInfo()
        {
            return $"You choose a land transport '{Manufacturer}' with {EngineType} engine type";
        }

        public override void AskInfo(Object[] args) { }

        public override Object[] GetInfo()
        {
            return new Object[1];
        }
    }
}
