using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using DWR_Tracker.Classes;
using DWR_Tracker.Classes.Items;
using DWR_Tracker.Controls;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;

namespace DWR_Tracker
{ 
    public partial class MainForm : Form
    {
        private DWConfiguration Config = DWGlobals.DWConfiguration;
        private DWHero Hero = DWGlobals.Hero;

        public MainForm()
        {
            InitializeComponent();

            // try to find a suitable emulator automatically
            if (!EmulatorConnectionWorker.IsBusy)
            {
                EmulatorConnectionWorker.RunWorkerAsync();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // update UI based on config
            streamerModeToolStripMenuItem.Checked = Config.StreamerMode;
            autoTrackingToolStripMenuItem.Checked = Config.AutoTrackingEnabled;
            MainFormLayoutUpdate();

            //Set initial UI for hero stats
            for (int i = 0; i < Hero.DisplayStats.Length; i++)
            {
                DWStat stat = Hero.DisplayStats[i];
                DWLabel nameLabel = new DWLabel { Text = stat.Name.ToUpper() };
                DWLabel valueLabel = new DWLabel { 
                    Text = stat.Value.ToString(), 
                    TextAlign = ContentAlignment.MiddleRight 
                };
                StatTableLayout.Controls.Add(nameLabel, 0, i);
                StatTableLayout.Controls.Add(valueLabel, 1, i);
                stat.ValueChanged += (sender, e) =>
                {
                    valueLabel.Text = stat.Value.ToString();
                };
            }

            // create spell labels
            for (int i = 0; i < Hero.Spells.Length; i++)
            {
                DWSpell spell = Hero.Spells[i];
                DWSpellLabel label = new DWSpellLabel(spell);

                // position spell in panel
                SpellPanel.Controls.Add(label);
                label.Top = i * 26 + 26;
                label.Left = 15;
                label.Width = SpellPanel.Width;

                // update color on spell value change
                spell.ValueChanged += (sender, e) =>
                {
                    label.ForeColor = spell.HasSpell ?
                        Color.FromArgb(255, 255, 255) :
                        Color.FromArgb(60, 60, 60);
                };
            }

            // set initial UI for all items
            foreach (DWItem item in Hero.QuestItems)
            {
                DWItemBox itemBox = new DWItemBox(item);
                if (item.IsFirstHalfQuestItem)
                {
                    Hero.RainbowDrop.ValueChanged += (sender, e) =>
                    {
                        itemBox.Visible = Hero.RainbowDrop.Value == 0;
                    };
                }
                RequiredItemFlowPanel.Controls.Add(itemBox);
            }

            foreach(DWItem item in Hero.BattleGear)
            {
                BattleItemFlowPanel.Controls.Add(new DWItemBox(item));
            }

            foreach (DWItem item in Hero.OtherItems)
            {
                OptionalItemFlowPanel.Controls.Add(new DWItemBox(item));
            }

            // game state update timer
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += CheckGameState;
            timer.Start();
        }

        private void MainFormLayoutUpdate()
        {
            DWMenuStrip.Visible = DWStatusStrip.Visible = !Config.StreamerMode;
            DWContentPanel.Top = 4 + (DWMenuStrip.Visible ? DWMenuStrip.Height : 0);

            if (Config.StreamerMode)
            {
                this.Height = 512;
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.Height = 558;
            }
        }

        private void Stat_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CheckGameState(object source, ElapsedEventArgs e)
        {
            if (Config.AutoTrackingEnabled && 
                DWGlobals.ProcessReader != default(DWProcessReader))
            {
                Hero.Update();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EmulatorConnectionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
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
        }

        private void EmulatorConnectionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DWProcessReader reader = DWGlobals.ProcessReader;
            if (reader != default(DWProcessReader))
            {
                EmulatorStatusLabel.Text = reader.Process.MainWindowTitle;
                Hero.Update(true);
            }
        }

        private void streamerModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            Config.StreamerMode = mi.Checked = !mi.Checked;
            MainFormLayoutUpdate();
        }

        private void autoTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            Config.AutoTrackingEnabled = mi.Checked = !mi.Checked;
        }
    }

    public class ItemPictureBox
    {
        public DWItem Item;
        public DWItemBox ItemBox;

        public ItemPictureBox(DWItem item, DWItemBox itemBox)
        {
            Item = item;
            ItemBox = itemBox;
        }
    }
}
