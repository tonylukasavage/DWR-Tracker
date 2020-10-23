using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DWR_Tracker.Controls;

namespace DWR_Tracker.Classes
{
    public class DWSpell
    {
        public string Name;
        public int Offset;
        public int Bit;
        public bool HasSpell;
        public SpellLabel Label;

        public DWSpell(string name, int offset, int bit, bool hasSpell = false)
        {
            Name = name;
            Offset = offset;
            Bit = bit;
            HasSpell = hasSpell;
        }

        public void UpdateLabel()
        {
            if (Label == default(SpellLabel)) { return; }

            DWGameReader dwReader = DWGlobals.DWGameReader;
            UpdateLabel((dwReader.GetInt(Offset) & Bit) > 0);
        }

        public void UpdateLabel(bool hasSpell, bool force = false)
        {
            if (HasSpell != hasSpell || force)
            {
                Label.ForeColor = hasSpell ? Color.FromArgb(255, 255, 255) : Color.FromArgb(60, 60, 60);
            }
            HasSpell = hasSpell;
        }
    }
}
