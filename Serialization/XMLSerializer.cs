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

        public string getXMLString(List<ITransportPlugin> TransportList)
        {
            string Result = "";
            List<object> transports = new List<object>();
            for (int i = 0; i < TransportList.Count; i++)
            {
                transports.Add(TransportList[i]);
            }
            using (StringWriter writer = new StringWriter())
            {
                XMLFormatter.Serialize(writer, transports);
                Result = writer.ToString();
            }
            return Result;
        }

        public List<ITransportPlugin> Deserialize(string Source)
        {
            List<ITransportPlugin> TransportList = new List<ITransportPlugin>();
            using (TextReader reader = new StringReader(Source))
            {
                TransportList.Clear();
                List<object> transports;
                try
                {
                    transports = (List<object>)XMLFormatter.Deserialize(reader);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transports = new List<object>();
                }
                
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
