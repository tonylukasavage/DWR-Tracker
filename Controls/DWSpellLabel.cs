using DWR_Tracker.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DWR_Tracker.Controls
{
    public partial class DWSpellLabel : DWLabel
    {
        private DWSpell Spell;

        public DWSpellLabel(DWSpell spell) : base()
        {
            InitializeComponent();
            Spell = spell;
            ForeColor = Color.FromArgb(60, 60, 60);
            AutoSize = true;
            Text = spell.Name.ToUpper();
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
            Spell.Update(Spell.HasSpell ? 1 : 0, true);
        }

        private void SpellLabel_Click(object sender, EventArgs e)
        {
            if (!DWGlobals.DWConfiguration.AutoTrackingEnabled)
            {
                Spell.Update(!Spell.HasSpell ? 1 : 0);
            }
        }
    }
}
