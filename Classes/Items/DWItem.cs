using DWR_Tracker.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWR_Tracker.Classes
{
    public abstract class DWItem
    {
        public string Name;
        public int Value;
        public string ImagePath;
        public bool IsBattleGear;
        public bool IsRequiredItem;
        public bool allowsMultiple;
        public bool forceOwnRead = false;
        public bool ShowCount = false;
        public int Count;
        public (string ImagePath, string Name)[] ItemInfo;
        public DWItemBox ItemBox;
        private delegate void SafeCallDelegate();

        public abstract int ReadValue();

        public void UpdatePictureBox(bool force = false)
        {
            if (ItemBox == default(DWItemBox)) { return; }
            UpdatePictureBox(ReadValue(), force);
        }

        public void UpdatePictureBox(int value, bool force = false)
        {
            if (Value != value || force)
            {
                Name = ItemInfo[value].Name;
                ImagePath = ItemInfo[value].ImagePath;
                UpdatePictureBoxProperties();
            }
            Value = value;
        }

        public void UpdatePictureBox(int value, int count, bool force = false)
        {
            bool countChanged = Count != count;
            Count = count;
            UpdatePictureBox(value, force || countChanged);
        }

        private void UpdatePictureBoxProperties()
        {
            PictureBox pictureBox = ItemBox.PictureBox;
            if (pictureBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdatePictureBoxProperties);
                pictureBox.Invoke(d, new object[] { });
            }
            else
            {
                ItemBox.ToolTip.SetToolTip(pictureBox, Name);
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                Stream myStream = myAssembly.GetManifestResourceStream(ImagePath);
                pictureBox.Image = (Image)(new Bitmap(Image.FromStream(myStream), new Size(50, 50)));

                if (ShowCount)
                {
                    ItemBox.CountLabel.Text = Count.ToString();
                    ItemBox.CountLabel.Visible = Count > 0;
                    ItemBox.CountLabel.BringToFront();
                }
            }
        }
    }
}
