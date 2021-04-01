using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal sealed class CustomSerializationBinder : SerializationBinder
    {

        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;
            try
            {
                string ToAssemblyName = assemblyName.Split(',')[0];

                Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();

                foreach (Assembly ass in Assemblies)
                {

                    if (ass.FullName.Split(',')[0] == ToAssemblyName)
                    {
                        typeToDeserialize = ass.GetType(typeName);
                        break;
                    }

                }
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
            return typeToDeserialize;
        }
    }
}
