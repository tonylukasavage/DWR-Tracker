using DWR_Tracker.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWR_Tracker
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Read configuration
            var appSettings = ConfigurationManager.AppSettings;
            DWGlobals.AutoTrackingEnabled =
                bool.Parse(appSettings["AutoTrackingEnabled"] ?? "False");
            DWGlobals.ShowMenu =
                bool.Parse(appSettings["ShowMenu"] ?? "False");
            DWGlobals.ShowStatus =
                bool.Parse(appSettings["ShowStatus"] ?? "False");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MainForm());
        }
    }
}
