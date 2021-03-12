using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{

    abstract class TransportFactory
    {

        public static string Name { get; set; }

        public abstract ITransport Create(Object[] args);

    }
}
