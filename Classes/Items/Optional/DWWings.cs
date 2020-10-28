using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWWings : DWItem
    {
        public DWWings()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Wings";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = false;
            allowsMultiple = true;
            Count = 0;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("wings-grey.png", "Wings"),
                ("wings.png", "Wings")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
