using OOP.Sdk;
using OOP.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OOP
{
    public static class Extensions
    {
        private static Dictionary<string, ITransportFactoryPlugin> ReadExtensions(List<Type> objectTypesList)
        {
            var files = Directory.GetFiles("Extensions", "*.dll");
            Dictionary<string, ITransportFactoryPlugin> creatorList = new Dictionary<string, ITransportFactoryPlugin>();

            foreach (var file in files)
            {
                Assembly assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), file));

                Type[] pluginTypes;
                pluginTypes = assembly.GetTypes();

                foreach (var pluginType in pluginTypes)
                {
                    if (pluginType.GetInterface("OOP.Sdk.ITransportFactoryPlugin") != null)
                    {
                        var creatorInstance = Activator.CreateInstance(pluginType);
                        creatorList.Add((pluginType.Name).Substring(0, Math.Abs((pluginType.Name).IndexOf("Creator"))), (ITransportFactoryPlugin)creatorInstance);
                    }
                    if (pluginType.GetInterface("OOP.Sdk.ITransportPlugin") != null)
                    {
                        var creatorInstance = Activator.CreateInstance(pluginType);
                        objectTypesList.Add(creatorInstance.GetType());
                    }
                }
            }
            return creatorList;
        }

        public static void Initialize(Dictionary<string, ITransportFactoryPlugin> TransportFactoryList, ref XMLSerializer XMLSerializer)
        {
            List<Type> objectTypesList = new List<Type>();
            Dictionary<string, ITransportFactoryPlugin> creators = ReadExtensions(objectTypesList);

            Assembly assembly = Assembly.Load("OOP");

            Type[] type = assembly.GetTypes();
            foreach (Type item in type)
            {
                if (item.IsSubclassOf(typeof(TransportFactory)))
                {
                    TransportFactoryList.Add((item.Name).Substring(0, Math.Abs((item.Name).IndexOf("Creator"))), (ITransportFactoryPlugin)Activator.CreateInstance(item));
                }
                if (item.IsSubclassOf(typeof(Transport)))
                {
                    objectTypesList.Add(item);
                }
            }

            foreach (var creator in creators)
            {
                TransportFactoryList.Add(creator.Key, creator.Value);
            }

            Type[] objectTypes = new Type[objectTypesList.Count];
            for (int i = 0; i < objectTypes.Length; i++)
            {
                objectTypes[i] = objectTypesList[i];
            }
            XMLSerializer = new XMLSerializer(objectTypes);
        }
    }
}
