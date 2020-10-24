using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWR_Tracker.Classes
{
    class DWEquipment
    {
        const int offset = 0xBE;
        public string Type;
        public int Value;
        public PictureBox PictureBox;

        public DWEquipment(string type)
        {
            Type = type;
            Value = 0;
        }

        public void UpdatePictureBox()
        {
            if (PictureBox == default(PictureBox)) { return; }

            DWGameReader dwReader = DWGlobals.DWGameReader;
            int byteValue = dwReader.GetInt(offset, 1);
            string resource = "";
            int value = 0;

            if (Type == "Shield")
            {
                value = byteValue & 0x3;
                resource = DWGlobals.ShieldImages[value];
            }
            else if (Type == "Armor")
            {
                value = (byteValue >> 2) & 0x7;
                resource = DWGlobals.ArmorImages[value];
            }
            else if (Type == "Sword")
            {
                value = (byteValue >> 5) & 0x7;
                resource = DWGlobals.SwordImages[value];
            }

            if (Value != value) 
            { 
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                Stream myStream = myAssembly.GetManifestResourceStream(resource);
                PictureBox.Image = Image.FromStream(myStream);
            }
            Value = value;
        }


    }
}
