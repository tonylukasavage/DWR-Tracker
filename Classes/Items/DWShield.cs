using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWShield : DWItem
    {
        public DWShield()
        {
            string basePath = DWGlobals.DWImagePath + "Shields.";

            Name = "Nothing";
            ImagePath = "";
            IsBattleGear = true;
            IsRequiredItem = false;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[4]
            {
                ("shield-no.png", "Nothing"),
                ("small.png", "Small Shield"),
                ("large.png", "Large Shield"),
                ("silver.png", "Silver Shield")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return DWGlobals.DWGameReader.GetInt(0xBE, 1) & 0x3;
        }
    }
}
