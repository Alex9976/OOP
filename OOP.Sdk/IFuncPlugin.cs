using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Sdk
{
    public interface IFuncPlugin
    {
        string Description { get; set; }
        string ShortName { get; set; }

        void Transform(object source);

        object ReturnState();
    }
}
