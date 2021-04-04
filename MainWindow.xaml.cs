using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OOP.Sdk;
using OOP.Serialization;

namespace OOP
{
    public partial class MainWindow : Window
    {
        public Dictionary<string, ITransportFactoryPlugin> TransportFactoryList = new Dictionary<string, ITransportFactoryPlugin>();
        public List<ITransportPlugin> TransportList = new List<ITransportPlugin>();
        BinarySerializer BinarySerializer = new BinarySerializer();
        XMLSerializer XMLSerializer;
        bool IsComponentsInitialized = false;
        object[] Parameters = new object[3];

        public MainWindow()
        {
            InitializeComponent();

            Extensions.Initialize(TransportFactoryList, ref XMLSerializer);
            foreach (var item in TransportFactoryList)
            {
                comboMain.Items.Add(item.Key);
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

        public void AddObjectToList(string Img, int Element)
        {
            StackPanel stackPanel = new StackPanel { Width = 550, Height = 79 };
            stackPanel.Orientation = Orientation.Horizontal;
            try
            {
                stackPanel.Children.Add(new Image
                {
                    Source = new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Images/", Img))),
                    Stretch = Stretch.Fill,
                    Width = 124,
                    Height = 74
                });
            }
            catch
            {
                MessageBox.Show("Loading image error");
            }

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
            XMLSerializer.Serialize(TransportList);
        }

        private void btnXMLload_Click(object sender, RoutedEventArgs e)
        {
            TransportList = XMLSerializer.Deserialize();

            listBox.Items.Clear();
            for (int i = 0; i < TransportList.Count; i++)
            {
                AddObjectToList(TransportFactoryList[TransportList[i].Name].ImgPath, i);
            }

        }

        private void btnBinsave_Click(object sender, RoutedEventArgs e)
        {
            BinarySerializer.Serialize(TransportList);
        }

        private void btnBinload_Click(object sender, RoutedEventArgs e)
        {
            TransportList = BinarySerializer.Deserialize();
            listBox.Items.Clear();

            for (int i = 0; i < TransportList.Count; i++)
            {
                try
                {
                    AddObjectToList(TransportFactoryList[TransportList[i].Name].ImgPath, i);
                }
                catch (KeyNotFoundException ex)
                {
                    string errorMessage = ex.Message.ToString();
                    MessageBox.Show(errorMessage.Substring(0, errorMessage.IndexOf(".")) + ": " + TransportList[i].Name);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                TransportList.RemoveAt(listBox.SelectedIndex);
                listBox.Items.Clear();

                for (int i = 0; i < TransportList.Count; i++)
                {
                    AddObjectToList(TransportFactoryList[TransportList[i].Name].ImgPath, i);
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                EditForm editForm = new EditForm(this, listBox.SelectedIndex);
                editForm.Show();
            }
        }
    }
}
