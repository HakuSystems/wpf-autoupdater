using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_autoupdater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Creates Location on the Desktop with the folder name "wpfautoupdater"
                Directory.CreateDirectory(PathStrings.desktopPath + "\\wpfautoupdater");
                //Opens CheckUpdateWindow
                CheckUpdateWindow checkUpdate = new CheckUpdateWindow();
                checkUpdate.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                //If there Are Errors
                MessageBox.Show(ex.Message, "MainWindow.xaml.cs - WindowLoaded");
            }
        }
    }
}
