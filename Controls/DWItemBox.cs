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
    public partial class DWItemBox : Panel
    {
        public ToolTip ToolTip;
        public DWItem Item;

        public DWItemBox(DWItem item)
        {
            InitializeComponent();
            AutoSize = true;
            Item = item;
            ToolTip = new ToolTip();
            Controls.Add(PictureBox);

            if (item.ShowCount)
            {
                CountLabel.Text = "";
                CountLabel.Font = new Font(DWGlobals.DWFont.GetFamily(), 12);
                CountLabel.AutoSize = true;
                CountLabel.Left = 26;
                CountLabel.Top = 35;
                Controls.Add(CountLabel);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (!DWGlobals.AutoTrackingEnabled)
            {
                int value = Item.Value;
                int max = Item.ItemInfo.Length;
                if (value + 1 == max)
                {
                    Item.UpdatePictureBox(0, true);
                }
                else
                {
                    Item.UpdatePictureBox(value + 1, true);
                }
            }
        }
    }
}
