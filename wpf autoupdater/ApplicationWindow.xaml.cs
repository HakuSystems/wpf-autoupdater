using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpf_autoupdater
{
    /// <summary>
    /// Interaction logic for ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        public ApplicationWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            versionNumber.Content = "V" + Application.ResourceAssembly.ManifestModule.Assembly.GetName().Version.ToString() + " - Current Application Version";
            infoText.Text = "This program is an example on how to Auto Download any application. \n Maybe im gonna add a method where \n the program automaticly opens the newest Version.";
        }
    }
}
