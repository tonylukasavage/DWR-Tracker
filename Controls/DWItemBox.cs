using DWR_Tracker.Classes;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DWR_Tracker.Controls
{
    public partial class DWItemBox : Panel
    {
        public ToolTip ToolTip;
        public DWItem Item;

        private Size imageSize = new Size(50,50);
        private delegate void SafeCallDelegate();

        public DWItemBox(DWItem item)
        {
            InitializeComponent();

            AutoSize = true;
            Item = item;
            ToolTip = new ToolTip();

            PictureBox.Size = imageSize;
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

            item.ValueChanged += (sender, r) =>
            {
                UpdateUI();
            };
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void UpdateUI()
        {
            if (PictureBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateUI);
                PictureBox.Invoke(d, new object[] { });
            }
            else
            {
                ToolTip.SetToolTip(PictureBox, Name);
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                Stream myStream = myAssembly.GetManifestResourceStream(Item.ImagePath);
                PictureBox.Image = new Bitmap(Image.FromStream(myStream), imageSize);

                if (Item.ShowCount)
                {
                    CountLabel.Text = Item.Count.ToString();
                    CountLabel.Visible = Item.Count > 0;
                    CountLabel.BringToFront();
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (!DWGlobals.DWConfiguration.AutoTrackingEnabled)
            {
                int value = Item.Value;
                int count = Item.Count;

                if (Item.ShowCount)
                {
                    count = count == 6 ? 0 : count + 1;
                    value = count > 0 ? 1 : 0;
                }
                else if (value + 1 == Item.ItemInfo.Length)
                {
                    value = 0;
                } 
                else
                {
                    value = Item.Value + 1;
                }

                Item.Update(value, count, true);
            }
        }
    }
}
