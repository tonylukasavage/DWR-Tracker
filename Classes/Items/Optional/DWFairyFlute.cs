using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWFairyFlute : DWItem
    {
        public DWFairyFlute()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Fairy Flute";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = false;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("flute-grey.png", "Fairy Flute"),
                ("flute.png", "Fairy Flute")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
