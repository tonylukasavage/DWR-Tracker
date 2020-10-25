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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using DWR_Tracker.Classes;
using DWR_Tracker.Controls;
using Microsoft.Win32.SafeHandles;

namespace DWR_Tracker
{
    public partial class MainForm : Form
    {
        private DWGameReader dwReader;

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
                SpellFlowPanel.Controls.Add(label);
                label.Top = i * 30;
                label.Left = 10;
                label.Text = spell.Name.ToUpper();
                label.Width = SpellFlowPanel.Width;
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

            // add equipment pictures 
            DWEquipment[] equipment = new DWEquipment[6] 
            {  
                DWGlobals.Shield,
                DWGlobals.Armor,
                DWGlobals.Sword,
                DWGlobals.FightersRing,
                DWGlobals.DragonsScale,
                DWGlobals.DeathNecklace
            };
            foreach (DWEquipment equip in equipment)
            {
                equip.PictureBox = new PictureBox();
                equip.ToolTip = new ToolTip();
                EquipmentFlowPanel.Controls.Add(equip.PictureBox);
                equip.UpdatePictureBox(true);
            }

            // add item picture

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

                DWGlobals.Shield.UpdatePictureBox();
                DWGlobals.Armor.UpdatePictureBox();
                DWGlobals.Sword.UpdatePictureBox();

                // ITEMS
                int itemByte = dwReader.GetInt(0xC1, 4);
                for (int i = 0; i < 8; i++)
                {
                    int item = (itemByte >> (i * 4) & 0xF);
                    Console.WriteLine("item " + (i+1) + ": " + DWGlobals.Items[item]);
                }

                // MAGIC KEYS
                int keys = dwReader.GetInt(0xBF, 1);
                Console.WriteLine("keys: " + keys);

                // DRAGONLORD
                int dl = dwReader.GetInt(0xE4, 1) & 0x4;
                Console.WriteLine("DL: " + dl);
            }
        }

    }
}
