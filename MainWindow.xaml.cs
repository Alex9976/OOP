using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace OOP
{
    public partial class MainWindow : Window
    {
        Dictionary<string, TransportFactory> TransportFactoryList = new Dictionary<string, TransportFactory>();
        List<Transport> TransportList = new List<Transport>();
        XmlSerializer XMLFormatter = new XmlSerializer(typeof(List<Transport>));
        BinaryFormatter BinFormatter = new BinaryFormatter();

        string ProgrammPath = Directory.GetCurrentDirectory();
        bool IsComponentsInitialized = false;
        object[] Parameters = new object[3];

        public MainWindow()
        {
            InitializeComponent();

            Assembly assembly = Assembly.Load("OOP");

            Type[] type = assembly.GetTypes();
            foreach (Type item in type)
            {
                if (item.IsSubclassOf(typeof(TransportFactory)))
                {
                    comboMain.Items.Add((item.Name).Substring(0, Math.Abs((item.Name).IndexOf("Creator"))));
                    TransportFactoryList.Add((item.Name).Substring(0, Math.Abs((item.Name).IndexOf("Creator"))), (TransportFactory)Activator.CreateInstance(item));
                }
            }
            
            IsComponentsInitialized = true;
            comboMain.SelectedIndex = 0;
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            Parameters[0] = textBox.Text;
            Parameters[1] = comboBox.SelectedIndex + 1;
            Parameters[2] = checkBox.IsChecked;          

            foreach (string Name in TransportFactoryList.Keys)
            {
                if (Name == comboMain.SelectedItem.ToString())
                {
                    TransportList.Add(TransportFactoryList[Name].Create(Parameters));

                    AddObjectToList(TransportFactoryList[Name].ImgPath, TransportList.Count - 1);

                }
                    
            }
        }

        private void AddObjectToList(string Img, int Element)
        {
            StackPanel stackPanel = new StackPanel { Width = 550, Height = 79 };
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.Children.Add(new Image
            {
                Source = new BitmapImage(new Uri(ProgrammPath + "\\" + Img)),
                Stretch = Stretch.Fill,
                Width = 124,
                Height = 74
            });
            Label label = new Label { Width = 420, Height = 31 };
            label.Content = TransportList[Element].PrintInfo();
            stackPanel.Children.Add(label);

            listBox.Items.Add(stackPanel);
        }

        private void comboMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsComponentsInitialized)
            {
                comboLabel.Content = TransportFactoryList[comboMain.SelectedItem.ToString()].Question1();
                checkBox.Content = TransportFactoryList[comboMain.SelectedItem.ToString()].Question2();

                string[] elements = TransportFactoryList[comboMain.SelectedItem.ToString()].Answer();
                for (int i = 0; i < comboBox.Items.Count;)
                {
                    comboBox.Items.RemoveAt(i);
                }
                for (int i = 0; i < elements.Length; i++)
                {
                    comboBox.Items.Add(elements[i]);
                }
                comboBox.SelectedIndex = 0;
            }
            
        }

        

        private void btnXMLsave_Click(object sender, RoutedEventArgs e)
        {

            using (FileStream file = new FileStream("Transport.xml", FileMode.OpenOrCreate))
            {
                XMLFormatter.Serialize(file, TransportList);
            }
        }

        private void btnXMLload_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream file = new FileStream("Transport.xml", FileMode.OpenOrCreate))
            {
                TransportList = (List<Transport>)XMLFormatter.Deserialize(file);
            }

            listBox.Items.Clear();
            
            for (int i = 0; i < TransportList.Count; i++)
            {
                AddObjectToList(TransportFactoryList[TransportList[i].Name].ImgPath, i);
            }

        }

        private void btnBinsave_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream file = new FileStream("Transport.dat", FileMode.OpenOrCreate))
            {
                BinFormatter.Serialize(file, TransportList);
            }
        }

        private void btnBinload_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream file = new FileStream("Transport.dat", FileMode.OpenOrCreate))
            {
                TransportList = (List<Transport>)BinFormatter.Deserialize(file);

                listBox.Items.Clear();

                for (int i = 0; i < TransportList.Count; i++)
                {
                    AddObjectToList(TransportFactoryList[TransportList[i].Name].ImgPath, i);
                }
            }
        }
    }
}
