using System;

namespace OOPLab1
{
    class Program
    {
        static void Main(string[] args)
        {

            Transport[] transport = new Transport[] { new Car("Audi"), new Bus("MAN"), new Airplane("Airbus"), new Helicopter("Robinson"), new Boat("Tornado") };
            for (int i = 0; i < transport.Length; i++)
            {
                transport[i].AskInfo();
                transport[i].PrintInfo();
            }

        }
    }
}