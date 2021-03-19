using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{

    abstract class TransportFactory
    {

        public string ImgPath { get; set; }

        public abstract string Question1();

        public abstract string Question2();

        public abstract string[] Answer();

        public abstract Transport Create(Object[] args);

    }
}
