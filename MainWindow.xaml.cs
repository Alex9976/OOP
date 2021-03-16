using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.IO;
using System.Text.Json;

namespace OOP
{
    public partial class MainWindow : Window
    {
        Dictionary<string, TransportFactory> TransportList = new Dictionary<string, TransportFactory>();

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
                    TransportList.Add((item.Name).Substring(0, Math.Abs((item.Name).IndexOf("Creator"))), (TransportFactory)Activator.CreateInstance(item));
                }
            }

            comboLabel.Content = TransportList["Airplane"].Question1();
            checkBox.Content = TransportList["Airplane"].Question2();
            string[] elements = TransportList["Airplane"].Answer();
            for (int i = 0; i < elements.Length; i++)
            {
                comboBox.Items.Add(elements[i]);
            }
            comboBox.SelectedIndex = 0;

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

            comboLabel.Content = TransportList[comboMain.SelectedItem.ToString()].Question1();
            checkBox.Content = TransportList[comboMain.SelectedItem.ToString()].Question2();

            string[] elements = TransportList[comboMain.SelectedItem.ToString()].Answer();
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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            Parameters[0] = textBox.Text;
            Parameters[1] = comboBox.SelectedIndex + 1;
            Parameters[2] = checkBox.IsChecked;          

            foreach (string Name in TransportList.Keys)
            {
                if (Name == comboMain.SelectedItem.ToString())
                {
                    var transport = TransportList[Name].Create(Parameters);
                    MessageBox.Show(transport.PrintInfo());
                    string json = JsonSerializer.Serialize(transport, typeof(Airplane));
                    using (FileStream file = new FileStream("transport.json", FileMode.OpenOrCreate))
                    {
                        //JsonSerializer.Serialize(file, transport);
                        Console.WriteLine("Data has been saved to file");
                    }
                }
            }
        }


    }
}
