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
        private DWItem[] QuestItemsStart = DWGlobals.QuestItems.Take(3).ToArray();
        private DWItem[] QuestItemsEnd = DWGlobals.QuestItems.Skip(3).Take(3).ToArray();

        private delegate void SafeCallDelegate(Image image);

        public MainForm()
        {
            InitializeComponent();

            // try to find a suitable emulator automatically
            if (!EmulatorConnectionWorker.IsBusy)
            {
                EmulatorConnectionWorker.RunWorkerAsync();
            }
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            // update UI based on config
            streamerModeToolStripMenuItem.Checked = Config.StreamerMode;
            autoTrackingToolStripMenuItem.Checked = Config.AutoTrackingEnabled;
            MainFormLayoutUpdate();

            // create spell labels
            for (int i = 0; i < DWGlobals.Spells.Length; i++)
            {
                DWSpell spell = DWGlobals.Spells[i];
                DWSpellLabel label = new DWSpellLabel(spell);
                spell.Label = label;
                label.AutoSize = true;
                SpellPanel.Controls.Add(label);
                label.Top = i * 26 + 26;
                label.Left = 15;
                label.Text = spell.Name.ToUpper();
                label.Width = SpellPanel.Width;
            }

            // populate stat table
            for (int i = 0; i < DWGlobals.Stats.Length; i++)
            {
                DWStat stat = DWGlobals.Stats[i];
                DWStatLabel label = new DWStatLabel { Text = stat.Value.ToString(), TextAlign = ContentAlignment.MiddleRight };
                stat.Label = label;
                StatTableLayout.Controls.Add(new DWStatLabel { Text = stat.Name.ToUpper() }, 0, i);
                StatTableLayout.Controls.Add(label, 1, i);
            }

            // add item pictures 
            (DWItem[] Items, FlowLayoutPanel Panel)[] groups = new (DWItem[], FlowLayoutPanel)[3]
            {
                (DWGlobals.BattleItems, BattleItemFlowPanel),
                (DWGlobals.QuestItems, RequiredItemFlowPanel),
                (DWGlobals.OptionalItems, OptionalItemFlowPanel)
            };
            foreach ((DWItem[] Items, FlowLayoutPanel Panel) group in groups)
            {
                foreach (DWItem item in group.Items)
                {
                    DWItemBox itemBox = new DWItemBox(item);
                    item.ItemBox = itemBox;
                    itemBox.PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    group.Panel.Controls.Add(itemBox);
                    item.UpdatePictureBox(0, 0, true);
                }
            }

            // game state update timer
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += CheckGameState;
            timer.Start();
        }

        private void CheckGameState(object source, ElapsedEventArgs e)
        {
            if (Config.AutoTrackingEnabled && 
                DWGlobals.ProcessReader != default(DWProcessReader))
            {
                foreach (DWSpell spell in DWGlobals.Spells)
                {
                    spell.UpdateLabel();
                }

                foreach (DWStat stat in DWGlobals.Stats)
                {
                    stat.UpdateLabel();
                }

                foreach (DWItem item in DWGlobals.BattleItems)
                {
                    item.UpdatePictureBox();
                }

                // Get an dictionary of all items (excluding sword, armor, shield, and keys)
                // with the item name as the key, its count as the value
                Dictionary<string, int> items = new Dictionary<string, int>();
                int itemByte = DWGlobals.ProcessReader.ReadInt32(0xC1);
                for (int i = 0; i < 8; i++)
                {
                    int itemValue = (itemByte >> (i * 4) & 0xF);
                    string itemName = DWGlobals.InventoryItems[itemValue];
                    if (itemName == "Nothing")
                    {
                        continue;
                    }
                    else if (items.ContainsKey(itemName))
                    {
                        items[itemName]++;
                    }
                    else
                    {
                        items.Add(itemName, 1);
                    }                    
                }

                // All items necessary to complete the game (excluding keys)
                foreach (DWItem item in DWGlobals.QuestItems)
                {
                    if (item is DWHarpOrStaff)
                    {
                        int value = 0;
                        if (items.ContainsKey("Staff of Rain"))
                        {
                            value = 2;
                        }
                        else if (items.ContainsKey("Silver Harp"))
                        {
                            value = 1;
                        }
                        item.UpdatePictureBox(value, 1);
                    }
                    else if (item is DWBridge || item is DWBallOfLight)
                    {
                        item.UpdatePictureBox(item.ReadValue(), 1);
                    }
                    else if (items.ContainsKey(item.Name))
                    {
                        if (item.forceOwnRead)
                        {
                            item.UpdatePictureBox(item.ReadValue(), 1);
                        }
                        else
                        {
                            item.UpdatePictureBox(1, items[item.Name]);
                        }
                    }
                    else
                    {
                        item.UpdatePictureBox(0, 0);
                    }
                }

                // process all optional quest items (excluding key)
                foreach (DWItem item in DWGlobals.OptionalItems)
                {
                    if (item is DWMagicKey) { continue; }

                    if (items.ContainsKey(item.Name))
                    {
                        item.UpdatePictureBox(1, items[item.Name]);
                    }
                    else
                    {
                        item.UpdatePictureBox(0, 0);
                    }
                }

                // Special handling for key count
                DWMagicKey magicKey = (DWMagicKey)DWGlobals.OptionalItems[0];
                int keys = magicKey.ReadValue();
                if (keys != magicKey.Count)
                {
                    magicKey.UpdatePictureBox(keys > 0 ? 1 : 0, keys, false);
                }
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
            // set emulator name in status bar
            DWProcessReader reader = DWGlobals.ProcessReader;
            if (reader != default(DWProcessReader))
            {
                EmulatorStatusLabel.Text = reader.Process.MainWindowTitle;
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
