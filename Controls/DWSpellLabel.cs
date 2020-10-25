using DWR_Tracker.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWR_Tracker.Controls
{
    public partial class DWSpellLabel : Label
    {
        private DWSpell Spell;

        public DWSpellLabel(DWSpell spell)
        {
            InitializeComponent();
            Spell = spell;
            Font = new Font(DWGlobals.DWFont.GetFamily(), 12);
            ForeColor = Color.FromArgb(60, 60, 60);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void SpellLabel_MouseEnter(object sender, EventArgs e)
        {
            ForeColor = Color.FromArgb(140, 140, 255);
        }

        private void SpellLabel_MouseLeave(object sender, EventArgs e)
        {
            Spell.UpdateLabel(Spell.HasSpell, true);
        }

        private void SpellLabel_Click(object sender, EventArgs e)
        {
            if (!DWGlobals.AutoTrackingEnabled)
            {
                Spell.UpdateLabel(!Spell.HasSpell);
            }
        }
    }
}
