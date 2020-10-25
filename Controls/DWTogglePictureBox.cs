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
        public string DWName;
        public string[] ImagePaths;
        public int DWValue;
        public ToolTip ToolTip;

        public DWTogglePictureBox(string name, string type, string[] imagePaths)
        {
            InitializeComponent();
            ImagePaths = imagePaths;
            DWName = "none";
            DWType = type;
            DWValue = 0;
            ToolTip = new ToolTip();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
