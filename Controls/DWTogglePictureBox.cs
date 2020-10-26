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

        public DWTogglePictureBox()
        {
            InitializeComponent();
            ToolTip = new ToolTip();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
