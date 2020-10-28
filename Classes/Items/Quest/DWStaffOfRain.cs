using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWStaffOfRain : DWItem
    {
        public DWStaffOfRain()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Staff of Rain";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = true;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("staff_of_rain-grey.png", "Staff of Rain"),
                ("staff_of_rain.png", "Staff of Rain")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
