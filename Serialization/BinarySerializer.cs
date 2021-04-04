using OOP.Sdk;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace OOP.Serialization
{
    sealed class BinarySerializer
    {
        private BinaryFormatter BinFormatter;

        public BinarySerializer()
        {
            BinFormatter = new BinaryFormatter();
            BinFormatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            BinFormatter.Binder = new CustomSerializationBinder();
        }

        public void Serialize(List<ITransportPlugin> TransportList)
        {
            using (FileStream file = new FileStream("Transport.dat", FileMode.Create))
            {
                BinFormatter.Serialize(file, TransportList);
            }
        }

        public List<ITransportPlugin> Deserialize()
        {
            List<ITransportPlugin> TransportList = new List<ITransportPlugin>();
            using (FileStream file = new FileStream("Transport.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    TransportList = (List<ITransportPlugin>)BinFormatter.Deserialize(file);
                }
                catch (SerializationException)
                {
                    MessageBox.Show("Serialization error");
                }
            }
            return TransportList;
        }
    }
}
