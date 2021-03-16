using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OOP
{
    public partial class MainWindow : Window
    {
        Dictionary<string, TransportFactory> TransportFactoryList = new Dictionary<string, TransportFactory>();
        List<ITransport> TransportList = new List<ITransport>();
        int j = 0;

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

            comboLabel.Content = TransportFactoryList["Airplane"].Question1();
            checkBox.Content = TransportFactoryList["Airplane"].Question2();
            string[] elements = TransportFactoryList["Airplane"].Answer();
            for (int i = 0; i < elements.Length; i++)
            {
                comboBox.Items.Add(elements[i]);
            }
            comboBox.SelectedIndex = 0;

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
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

                    StackPanel stackPanel = new StackPanel { Width = 550, Height = 79};
                    stackPanel.Orientation = Orientation.Horizontal;
                    stackPanel.Children.Add(new Image
                    {
                        Source = new BitmapImage(new Uri(TransportFactoryList[Name].ImgPath)),
                        Stretch = Stretch.Fill,
                        Width = 124,
                        Height = 74
                    });
                    Label label = new Label { Width = 420, Height = 31 };
                    label.Content = TransportList[TransportList.Count - 1].PrintInfo();
                    stackPanel.Children.Add(label);

                    listBox.Items.Add(stackPanel);

                }
                    
            }
        }


    }
}
