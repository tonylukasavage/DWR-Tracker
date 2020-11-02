using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWArmor : DWItem
    {
        public DWArmor()
        {
            string basePath = DWGlobals.DWImagePath + "Armors.";

            Name = "Nothing";
            ImagePath = "";
            IsBattleGear = true;
            IsRequiredItem = false;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[8]
            {
                ("armor-no.png", "Nothing"),
                ("clothes.png", "Clothes"),
                ("leather.png", "Leather Armor"),
                ("chain.png", "Chain Mail"),
                ("half.png", "Half Plate"),
                ("full.png", "Full Plate"),
                ("magic.png", "Magic Armor"),
                ("erdricks.png", "Erdrick's Armor")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return (DWGlobals.ProcessReader.ReadByte(0xBE) >> 2) & 0x7;
        }
    }
}
