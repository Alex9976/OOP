using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Sdk
{
    public interface ITransportPlugin
    {
        string Name { get; set; }

        string PrintInfo();
        void AskInfo(Object[] args);
        Object[] GetInfo();
    }
}
