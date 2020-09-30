using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_autoupdater
{
    public class PathStrings
    {
        //Destinations (replace with yours)
        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static string AppExecutablePath = "\\wpfautoupdater\\Application\\";

        //URLS (replace with yours)
        public static string VersionURL = "https://www.notlyze.de/Github/wpfautoupdater/version.txt";
        public static string AppExecutableURL = "https://www.notlyze.de/Github/wpfautoupdater/wpf%20autoupdater.exe";
    }
}
