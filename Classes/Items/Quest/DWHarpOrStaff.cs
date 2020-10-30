using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWHarpOrStaff : DWItem
    {
        public DWHarpOrStaff()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Silver Harp";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = true;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[3]
            {
                ("harp-grey.png", "Silver Harp"),
                ("harp.png", "Silver Harp"),
                ("staff_of_rain.png", "Staff of Rain")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
