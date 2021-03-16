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
                }
            }
        }


    }
}
