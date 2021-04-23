using Newtonsoft.Json;
using OOP.Sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMLToJSONTransformer
{
    public class XMLToJSONTransformer : IFuncPlugin
    {
        public string Description { get; set; } 
        public string ShortName { get; set; } 

        public XMLToJSONTransformer()
        {
            Description = "Transform XML to JSON";
            ShortName = "XMLtoJSON";
        }

        public void Transform(object Source, string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml((string)Source);
            string JsonString = JsonConvert.SerializeXmlNode(doc);
            using (FileStream file = new FileStream(fileName + ".json", FileMode.Create))
            {
                byte[] buffer = System.Text.Encoding.Default.GetBytes(JsonString);
                file.Write(buffer, 0, buffer.Length);
            }
        }

        public object ReturnState(string fileName)
        {
            string JSONString;
            using (FileStream file = new FileStream(fileName + ".json", FileMode.OpenOrCreate))
            {
                byte[] array = new byte[file.Length];
                file.Read(array, 0, array.Length);
                JSONString = System.Text.Encoding.Default.GetString(array);
            }
            XNode XMLString = JsonConvert.DeserializeXNode(JSONString);

            return XMLString.ToString();
        }

    }
}
