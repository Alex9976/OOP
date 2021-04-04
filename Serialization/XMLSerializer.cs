using OOP.Sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace OOP.Serialization
{
    public sealed class XMLSerializer
    {
        private XmlSerializer XMLFormatter;

        public XMLSerializer(Type[] objectTypes)
        {
            XMLFormatter = new XmlSerializer(typeof(List<object>), objectTypes);
        }

        public void Serialize(List<ITransportPlugin> TransportList)
        {
            using (FileStream file = new FileStream("Transport.xml", FileMode.Create))
            {
                List<object> transports = new List<object>();
                for (int i = 0; i < TransportList.Count; i++)
                {
                    transports.Add(TransportList[i]);
                }
                XMLFormatter.Serialize(file, transports);
            }
        }

        public List<ITransportPlugin> Deserialize()
        {
            List<ITransportPlugin> TransportList = new List<ITransportPlugin>();
            using (FileStream file = new FileStream("Transport.xml", FileMode.OpenOrCreate))
            {
                TransportList.Clear();
                List<object> transports = (List<object>)XMLFormatter.Deserialize(file);
                for (int i = 0; i < transports.Count; i++)
                {
                    try
                    {
                        TransportList.Add((ITransportPlugin)transports[i]);
                    }
                    catch (InvalidCastException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            return TransportList;
        }
    }
}
