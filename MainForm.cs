using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DWR_Tracker
{ 
    public partial class MainForm : Form
    {
        private DWGameReader dwReader;
        private delegate void SafeCallDelegate(Image image);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // initialize reading DW from fceux
            dwReader = DWGlobals.DWGameReader;
            dwReader.Init();

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

                    if (item.ShowCount)
                    {
                        item.UpdatePictureBox(0, 0, true);
                    }
                    else
                    {
                        item.UpdatePictureBox(true);
                    }
                }
            }

            // game state update timer
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += CheckGameState;
            timer.Start();
        }

        private void CheckGameState(object source, ElapsedEventArgs e)
        {
            if (DWGlobals.AutoTrackingEnabled)
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

                Dictionary<string, int> items = new Dictionary<string, int>();
                int itemByte = dwReader.GetInt(0xC1, 4);
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

                foreach (DWItem item in DWGlobals.QuestItems)
                {
 
                    if (items.ContainsKey(item.Name))
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

                foreach (DWItem item in DWGlobals.OptionalItems)
                {
                    if (items.ContainsKey(item.Name))
                    {
                        item.UpdatePictureBox(1, items[item.Name]);
                    }
                    else
                    {
                        item.UpdatePictureBox(0, 0);
                    }
                }

                DWMagicKey magicKey = (DWMagicKey)DWGlobals.OptionalItems[0];
                int keys = magicKey.ReadValue();
                if (keys != magicKey.Count)
                {
                    magicKey.UpdatePictureBox(keys > 0 ? 1 : 0, keys, false);
                }
            }
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
