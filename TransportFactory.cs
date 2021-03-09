using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    abstract class TransportFactory<T>
    {

        public abstract T Create(Object[] args);

    }
}
