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
        public int Count;
        public (string ImagePath, string Name)[] ItemInfo;
        public DWTogglePictureBox PictureBox;
        private delegate void SafeCallDelegate();

        public abstract int ReadValue();

        public void UpdatePictureBox(bool force = false)
        {
            if (PictureBox == default(DWTogglePictureBox)) { return; }

            DWGameReader dwReader = DWGlobals.DWGameReader;
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

        private void UpdatePictureBoxProperties()
        {
            if (PictureBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdatePictureBoxProperties);
                PictureBox.Invoke(d, new object[] {});
            }
            else
            {
                PictureBox.ToolTip.SetToolTip(PictureBox, Name);
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                Stream myStream = myAssembly.GetManifestResourceStream(ImagePath);
                PictureBox.Image = Image.FromStream(myStream);
            }
        }
    }
}
