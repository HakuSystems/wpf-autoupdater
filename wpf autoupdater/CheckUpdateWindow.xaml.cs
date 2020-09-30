using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for CheckUpdateWindow.xaml
    /// </summary>
    public partial class CheckUpdateWindow : Window
    {
        public CheckUpdateWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //example (V + 1.0.0.0)
            versionNumber.Content = "V" + Application.ResourceAssembly.ManifestModule.Assembly.GetName().Version.ToString();
            //Creates httpClient
            HttpClient httpClient = new HttpClient();
            //Uses PathStrings.cs to get the Current Version
            var result = await httpClient.GetAsync(PathStrings.VersionURL);
            var strServerVersion = await result.Content.ReadAsStringAsync();
            var serverVersion = Version.Parse(strServerVersion);
            var thisVersion = Application.ResourceAssembly.ManifestModule.Assembly.GetName().Version;
            //Trys to Check if Server File "version.txt" has the same Version as the Assembly Version
            try
            {
                if (serverVersion > thisVersion)
                {
                    //open actual downloader
                    UpdateWindow update = new UpdateWindow();
                    update.Show();
                    this.Close();
                }
                else
                {
                    //else if up to date
                    MessageBox.Show("up to date.");
                }
            }
            catch (Exception ex)
            {
                //if there are Errors
                MessageBox.Show(ex.Message, "CheckUpdateWindow.xaml.cs - WindowLoaded");
            }
        }
    }
}
