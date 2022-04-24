using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_autoupdater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string serverVersion = "https://nanosdk.net/EasyExtractUnitypackage/version.txt"; //website - .txt bc fuck json this is just a example project this is why i use .txt instead of json :)
        public string serverApplicationLoc = "https://nanosdk.net/EasyExtractUnitypackage/EasyExtractUnitypackage.exe"; //website exe
        public static string serverVersNumber;
        public string serverApplicationName; //output name
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCheck();
        }

        private async void UpdateCheck()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetAsync(serverVersion);
            var strServerVersion = await result.Content.ReadAsStringAsync();
            var serverVersionParsed = Version.Parse(strServerVersion);
            var currentVersion = Application.ResourceAssembly.ManifestModule.Assembly.GetName().Version;

            serverVersNumber = serverVersionParsed.ToString();
            serverApplicationName = $"YourApplicationName V{serverVersNumber}.exe";

            if (serverVersionParsed > currentVersion)
            {
                if (MessageBox.Show("YourApplicationName V" + serverVersNumber + " is Ready to Download, do you want to download it?", "UpdateCheck", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //User Pressed YES
                    using (WebClient client = new WebClient()){
                        client.DownloadFileAsync(new Uri(serverApplicationLoc), serverApplicationName);
                        client.DownloadProgressChanged += Client_DownloadProgressChanged;
                        client.DownloadFileCompleted += Client_DownloadFileCompleted;
                    }
                }
                else
                {
                    //User Pressed NO
                    MessageBox.Show("Running on Old Version now.","UpdateCheck");
                    ApplicationWindow application = new ApplicationWindow();
                    application.Show();
                    Close();
                }
            }
            progressBarOnWindow.Visibility = Visibility.Collapsed;

        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Complete, Starting new App now", "UpdateCheck");
            Process.Start(serverApplicationName, Directory.GetCurrentDirectory());
            Close();
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarOnWindow.Visibility = Visibility.Visible;
            progressBarOnWindow.Value = e.ProgressPercentage;
        }
    }
}
