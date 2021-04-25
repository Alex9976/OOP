using OOP.Sdk;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace OOP.Adapters
{
    class ArchiverAdapter : IFuncPlugin
    {
        public string Description { get; set; }
        public string ShortName { get; set; }
        private Archiver.Archiver archiver = new Archiver.Archiver();
        private BinaryFormatter binaryFormatter = new BinaryFormatter();

        public ArchiverAdapter()
        {
            Description = "Archive data";
            ShortName = "Archiver";
            binaryFormatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            binaryFormatter.Binder = new CustomSerializationBinder();
        }

        public void Transform(object Source, string fileName)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, Source);
                    var data = archiver.Form(memoryStream.ToArray());
                    File.WriteAllBytes(fileName + ".arc", data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public object ReturnState(string fileName)
        {
            byte[] data = null, stream = null;
            try
            {
                data = File.ReadAllBytes(fileName + ".arc");
                stream = archiver.Deform(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            object Result = new object();
            try
            {
                using (MemoryStream memoryStream = new MemoryStream(stream))
                {
                    Result = binaryFormatter.Deserialize(memoryStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }
    }
}
