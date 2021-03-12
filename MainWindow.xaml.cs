using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP
{
    public partial class MainWindow : Window
    {
        Dictionary<string, TransportFactory> list = new Dictionary<string, TransportFactory>();

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
                    list.Add((item.Name).Substring(0, Math.Abs((item.Name).IndexOf("Creator"))), (TransportFactory)Activator.CreateInstance(item));
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
            object[] obj = new object[3];
            obj[0] = textBoxManufacturer.Text;
            switch (comboBox.SelectedItem.ToString())
            {
                case "Car":
                    obj[1] = comboCarEngType.SelectedIndex + 1;
                    obj[2] = checkCarAP.IsChecked;
                    break;
                case "Bus":
                    obj[1] = comboBusEngType.SelectedIndex + 1;
                    obj[2] = checkBusIP.IsChecked;
                    break;
                case "Airplane":
                    obj[1] = Convert.ToInt32(AirplaneMaxAlt.Text);
                    obj[2] = comboAirplaneEngType.SelectedIndex + 1;
                    break;
                case "Helicopter":
                    obj[1] = Convert.ToInt32(AirplaneMaxAlt.Text);
                    obj[2] = HelicopterParachute.IsChecked;
                    break;
                case "Boat":
                    obj[1] = Convert.ToDecimal(BoatMaxSpeed.Text);
                    break;
            }
            foreach (string Name in list.Keys)
            {
                if (Name == comboBox.SelectedItem.ToString())
                {
                    var a = list[Name].Create(obj);
                    MessageBox.Show(a.PrintInfo());
                }
            }
        }

        
    }
}
