using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    public class DWRainbowDrop : DWItem
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

            ItemInfo = new (string ImagePath, string Name, int ExtraValue)[2]
            {
                ("rainbowdrop-grey.png", "Rainbow Drop", 0),
                ("rainbowdrop.png", "Rainbow Drop", 0)
            }.Select(s => (basePath + s.ImagePath, s.Name, s.ExtraValue)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
