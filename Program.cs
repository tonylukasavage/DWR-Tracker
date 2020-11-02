using DWR_Tracker.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            // load all configured emulators from emulators.json
            StreamReader r = new StreamReader("emulators.json");
            string json = r.ReadToEnd();
            dynamic array = JsonConvert.DeserializeObject(json);
            foreach (var item in array)
            {
                string name = item.name;
                foreach (var vItem in item.versions)
                {
                    // assign json items
                    string version = vItem.version;
                    string dll = vItem.dll;
                    int arch = vItem.arch;
                    string[] offsets = vItem.offsets.ToObject<string[]>();

                    // find emulator process
                    Process[] processes = Process.GetProcessesByName(name);
                    if (processes.Length < 1) { continue; }

                    foreach (Process p in processes)
                    {
                        Console.Out.WriteLine(p.MainWindowTitle);
                        DWProcessReader reader = new DWProcessReader(p);
                        IntPtr baseOffset = reader.SetBaseOffset(dll, offsets);
                        if (baseOffset == (IntPtr)(-1))
                        {
                            Console.WriteLine("ERROR: Couldn't find NES pointer for " + p.ProcessName);
                            continue;
                        }

                        // TODO: Base offset doesn't take us to this part of memory
                        // find "DRAGON WARRIOR" at offset +0xFFE0
                        //string identifier = reader.ReadString(0xFFE0, 14);
                        //if (identifier != "DRAGON WARRIOR")
                        //{
                        //    continue;
                        //}

                        // found our emulator
                        DWGlobals.ProcessReader = reader;
                        break;
                    }

                    if (DWGlobals.ProcessReader != default(DWProcessReader)) { break; }
                }
            }

            Application.Run(new MainForm());
        }
    }
}
