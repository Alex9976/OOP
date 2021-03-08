using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab1
{
    abstract class TransportFactory<T>
    {

        public abstract T Create(Object[] args);

    }
}
