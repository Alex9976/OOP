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

        public MainWindow()
        {
            InitializeComponent();


            Assembly assembly = Assembly.Load("OOP");

            Type[] type = assembly.GetTypes();
            foreach (Type item in type)
            {
                if (item.IsSubclassOf(typeof(TransportFactory)))
                {
                    comboBox.Items.Add((item.Name).Substring(0, Math.Abs((item.Name).IndexOf("Creator"))));
                    TransportList.Add((item.Name).Substring(0, Math.Abs((item.Name).IndexOf("Creator"))), (TransportFactory)Activator.CreateInstance(item));
                }
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CarWPanel.Visibility = Visibility.Hidden;
            BusWPanel.Visibility = Visibility.Hidden;
            AirplaneWPanel.Visibility = Visibility.Hidden;
            HelicopterWPanel.Visibility = Visibility.Hidden;
            BoatWPanel.Visibility = Visibility.Hidden;
            
            switch (comboBox.SelectedItem.ToString())
            {
                case "Car":
                    CarWPanel.Visibility = Visibility.Visible;
                    break;
                case "Bus":
                    BusWPanel.Visibility = Visibility.Visible;
                    break;
                case "Airplane":
                    AirplaneWPanel.Visibility = Visibility.Visible;
                    break;
                case "Helicopter":
                    HelicopterWPanel.Visibility = Visibility.Visible;
                    break;
                case "Boat":
                    BoatWPanel.Visibility = Visibility.Visible;
                    break;
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            object[] Parameters = new object[3];
            Parameters[0] = textBoxManufacturer.Text;
            switch (comboBox.SelectedItem.ToString())
            {
                case "Car":
                    Parameters[1] = comboCarEngType.SelectedIndex + 1;
                    Parameters[2] = checkCarAP.IsChecked;
                    break;
                case "Bus":
                    Parameters[1] = comboBusEngType.SelectedIndex + 1;
                    Parameters[2] = checkBusIP.IsChecked;
                    break;
                case "Airplane":
                    Parameters[1] = Convert.ToInt32(AirplaneMaxAlt.Text);
                    Parameters[2] = comboAirplaneEngType.SelectedIndex + 1;
                    break;
                case "Helicopter":
                    Parameters[1] = Convert.ToInt32(AirplaneMaxAlt.Text);
                    Parameters[2] = HelicopterParachute.IsChecked;
                    break;
                case "Boat":
                    Parameters[1] = Convert.ToDecimal(BoatMaxSpeed.Text);
                    break;
            }
            foreach (string Name in TransportList.Keys)
            {
                if (Name == comboBox.SelectedItem.ToString())
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
