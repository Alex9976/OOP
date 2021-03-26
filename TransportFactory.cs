using System;
using System.Collections.Generic;
using System.Text;
using OOP.Sdk;

namespace OOP
{

    public abstract class TransportFactory : ITransportFactoryPlugin
    {

        public string ImgPath { get; set; }

        public abstract string Question1();

        public abstract string Question2();

        public abstract string[] Answer();

        public abstract ITransportPlugin Create(Object[] args);

    }
}
