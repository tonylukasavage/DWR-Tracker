using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWR_Tracker.Classes
{
    public class DWConfiguration
    {
        private bool? autoTrackingEnabled = null;
        public bool AutoTrackingEnabled
        {
            get { return getBool(ref autoTrackingEnabled, "AutoTrackingEnabled", true); }
            set { setBool(ref autoTrackingEnabled, "AutoTrackingEnabled", value); }
        }

        private bool? streamerMode = null;
        public bool StreamerMode
        {
            get { return getBool(ref streamerMode, "StreamerMode", false); }
            set { setBool(ref streamerMode, "StreamerMode", value); }
        }

        public DWConfiguration()
        {

        }

        private bool getBool(ref bool? obj, string key, bool defaultValue = true)
        {
            if (obj == null)
            {
                var settings = ConfigurationManager.AppSettings;
                try
                {
                    obj = (bool?)bool.Parse(settings[key]);
                    return (bool)obj;
                }
                catch
                {
                    setBool(ref obj, key, defaultValue);
                    return (bool)obj;
                }
            }
            else
            {
                return (bool)obj;
            }
        }

        public void setBool(ref bool? obj, string key, bool value)
        {
            // set property value
            obj = value;

            // write property to config file
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            var settings = config.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value.ToString());
            }
            else
            {
                settings[key].Value = value.ToString();
            }
            config.Save(ConfigurationSaveMode.Minimal);
        }

    }
}
