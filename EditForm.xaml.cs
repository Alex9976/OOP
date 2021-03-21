using System;
using System.Linq;
using System.Windows;

namespace OOP
{
    public partial class EditForm : Window
    {

        Object[] obj;
        MainWindow window;
        int Index;

        public EditForm(MainWindow window, int Index)
        {
            InitializeComponent();

            comboLabel.Content = window.TransportFactoryList[window.TransportList[Index].Name].Question1();
            checkBox.Content = window.TransportFactoryList[window.TransportList[Index].Name].Question2();

            string[] elements = window.TransportFactoryList[window.TransportList[Index].Name].Answer();
            for (int i = 0; i < comboBox.Items.Count;)
            {
                comboBox.Items.RemoveAt(i);
            }
            for (int i = 0; i < elements.Length; i++)
            {
                comboBox.Items.Add(elements[i]);
            }

            obj = window.TransportList[Index].GetInfo();

            textBox.Text = (string)obj[0];
            comboBox.SelectedIndex = (int)obj[1];
            checkBox.IsChecked = (bool)obj[2];

            this.window = window;
            this.Index = Index;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            obj[0] = textBox.Text;
            obj[1] = comboBox.SelectedIndex + 1;
            obj[2] = checkBox.IsChecked;

            window.TransportList[Index].AskInfo(obj);

            window.listBox.Items.Clear();

            for (int i = 0; i < window.TransportList.Count; i++)
            {
                window.AddObjectToList(window.TransportFactoryList[window.TransportList[i].Name].ImgPath, i);
            }

            Close();
        }
    }
}
