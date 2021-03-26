using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Sdk
{
    public interface ITransportFactoryPlugin
    {
        string ImgPath { get; set; }

        string Question1();

        string Question2();

        string[] Answer();

        ITransportPlugin Create(Object[] args);
    }
}
