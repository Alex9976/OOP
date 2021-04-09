using OOP.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP
{
    public partial class SettingsWindow : Window
    {
        Dictionary<string, IFuncPlugin> FuncPluginsList;
        Dictionary<string, bool> FuncPluginsListActivartors;

        public SettingsWindow(Dictionary<string, IFuncPlugin> FuncPluginsList, Dictionary<string, bool> FuncPluginsListActivartors)
        {
            InitializeComponent();
            this.FuncPluginsList = FuncPluginsList;
            this.FuncPluginsListActivartors = FuncPluginsListActivartors;
            

            foreach (var item in FuncPluginsList)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = item.Value.Description;
                checkBox.IsChecked = FuncPluginsListActivartors[item.Key];
                stackPannel.Children.Add(checkBox);
                this.Height += 25;
            }
        }

        private void StackPanel_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() => Update());
            thread.Start();
        }

        private void Update()
        {
            Thread.Sleep(100);
            Dispatcher.Invoke(() =>
            {
                foreach (CheckBox item in stackPannel.Children)
                {
                    foreach (var element in FuncPluginsList)
                    {
                        if (element.Value.Description == (string)item.Content)
                        {
                            if ((bool)item.IsChecked)
                            {
                                FuncPluginsListActivartors[element.Key] = true;
                            }
                            else
                            {
                                FuncPluginsListActivartors[element.Key] = false;
                            }
                        }
                    }

                }
            });
        }

    }
}
