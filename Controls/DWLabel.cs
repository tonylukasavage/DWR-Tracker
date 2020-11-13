using DWR_Tracker.Classes;
using System.Drawing;
using System.Windows.Forms;

namespace DWR_Tracker.Controls
{
    public partial class DWLabel : Label
    {
        public DWLabel()
        {
            InitializeComponent();
            Font = new Font(DWGlobals.DWFont.GetFamily(), 12);
            ForeColor = Color.FromArgb(255, 255, 255);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
