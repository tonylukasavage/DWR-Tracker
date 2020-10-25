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
        public string Type;
        public string Name;
        public int Value;
        public PictureBox PictureBox;
        public ToolTip ToolTip;

        public DWEquipment(string type)
        {
            Type = type;
            Value = 0;
        }

        public void UpdatePictureBox(bool force = false)
        {
            if (PictureBox == default(PictureBox)) { return; }

            DWGameReader dwReader = DWGlobals.DWGameReader;
            int byteValue;
            string resource = "";
            int value = 0;
            string name = "nothing";

            if (Type == "Shield" || Type == "Sword" || Type == "Armor")
            {
                byteValue = dwReader.GetInt(0xBE, 1);
            }
            else if (Type == "Fighter's Ring" || Type == "Dragon's Scale" || Type == "Death Necklace")
            {
                byteValue = dwReader.GetInt(0xCF, 1);
            }
            else
            {
                return;
            }

            if (Type == "Shield")
            {
                value = byteValue & 0x3;
                name = DWGlobals.Shields[value];
                resource = DWGlobals.ShieldImages[value];
            }
            else if (Type == "Armor")
            {
                value = (byteValue >> 2) & 0x7;
                name = DWGlobals.Armors[value];
                resource = DWGlobals.ArmorImages[value];
            }
            else if (Type == "Sword")
            {
                value = (byteValue >> 5) & 0x7;
                name = DWGlobals.Swords[value];
                resource = DWGlobals.SwordImages[value];
            } 
            else if (Type == "Fighter's Ring")
            {
                value = (byteValue & 0x20) > 0 ? 1 : 0;
                name = "Fighter's Ring";
                resource = DWGlobals.FightersRingImages[value];
            }
            else if (Type == "Dragon's Scale")
            {
                value = (byteValue & 0x10) > 0 ? 1 : 0;
                name = "Dragon's Scale";
                resource = DWGlobals.DragonsScaleImages[value];
            }
            else if (Type == "Death Necklace")
            {
                value = (byteValue & 0x80) > 0 ? 1 : 0;
                name = "Death Necklace";
                resource = DWGlobals.DeathNecklaceImages[value];
            }

            if (Value != value || force) 
            { 
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                Stream myStream = myAssembly.GetManifestResourceStream(resource);
                PictureBox.Image = Image.FromStream(myStream);
                ToolTip.SetToolTip(PictureBox, name);
            }
            Name = name;
            Value = value;
        }


    }
}
