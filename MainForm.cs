using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
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
                SpellLabel label = new SpellLabel(spell);
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
                StatLabel label = new StatLabel { Text = stat.Value.ToString(), TextAlign = ContentAlignment.MiddleRight };
                stat.Label = label;
                StatTableLayout.Controls.Add(new StatLabel { Text = stat.Name.ToUpper() }, 0, i);
                StatTableLayout.Controls.Add(label, 1, i);
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
            }
        }

    }
}
