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
    public partial class DWTogglePictureBox : PictureBox
    {
        public ToolTip ToolTip;
        public DWItem Item;
        public Label CountLabel;

        public DWTogglePictureBox(DWItem item)
        {
            InitializeComponent();
            Item = item;
            ToolTip = new ToolTip();
            
            if (item.ShowCount)
            {
                CountLabel = new Label();
                CountLabel.Text = "";
                CountLabel.Font = new Font(DWGlobals.DWFont.GetFamily(), 8);
                CountLabel.AutoSize = true;
                //CountLabel.Left = Left;
                //CountLabel.Top = Top;
                Controls.Add(CountLabel);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void DWTogglePictureBox_Click(object sender, EventArgs e)
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
