using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWRainbowDrop : DWItem
    {
        public DWRainbowDrop()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Rainbow Drop";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = true;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("rainbowdrop-grey.png", "Rainbow Drop"),
                ("rainbowdrop.png", "Rainbow Drop")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
