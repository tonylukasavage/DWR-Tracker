using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWFairyWater : DWItem
    {
        public DWFairyWater()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Fairy Water";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = false;
            allowsMultiple = true;
            ShowCount = true;
            Count = 0;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("fairy_water-grey.png", "Fairy Water"),
                ("fairy_water.png", "Fairy Water")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
