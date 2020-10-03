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
using System.Windows.Shapes;

namespace wpf_autoupdater
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();
        }
        //Downloaded File name (Custom, can be changed.)
        string downloadedapplicationName = "wpfautoupdaterUpdated.exe";

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
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
                    //Displaying the newest versionNumber
                    versionNumber.Content = "Downloading: V" + serverVersion;

                    //Creates WebClient
                    WebClient client = new WebClient();
                    //Uses PathStrings.cs to Create a Folder to the Desktop (\wpfautoupdater\Application\)
                    Directory.CreateDirectory(PathStrings.desktopPath + PathStrings.AppExecutablePath);
                    //Creates new private voids
                    client.DownloadProgressChanged += client_DownloadProgressChanged;
                    client.DownloadFileCompleted += client_DownloadFileCompleted;
                    //Downloads the Actual File and Puts the file to \wpfautoupdater\Application\ and renames it to "wpfautoupdaterUpdated"
                    client.DownloadFileAsync(new Uri(PathStrings.AppExecutableURL), PathStrings.desktopPath + PathStrings.AppExecutablePath + downloadedapplicationName);
                }
                else
                {
                    //else if up to date open actual application
                    ApplicationWindow application = new ApplicationWindow();
                    application.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                //if there are Errors
                MessageBox.Show(ex.Message, "UpdateWindow.xaml.cs - WindowLoaded");
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Indicates Progress in bytes and MB
            progressInfo.Content = $"{e.BytesReceived} Bytes ({e.BytesReceived / 1046576} MB) Downloaded.";
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //when Downloaded then open Downloaded application (or file)
            try
            {
                //Opens small Window for more Information
                MessageBox.Show("Download Finished, New Application will now run.", "Information");
                //Gets folder path and downloadedapplicationName and opens it
                Process.Start(PathStrings.desktopPath + PathStrings.AppExecutablePath + downloadedapplicationName);
                //Closes old program
                this.Close();
            }
            catch (Exception ex)
            {
                //if there are Errors
                MessageBox.Show(ex.Message, "UpdateWindow.xaml.cs DownloadFileCompleted");
            }
        }
    }
}
