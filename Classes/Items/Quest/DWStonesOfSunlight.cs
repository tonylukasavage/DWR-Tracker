using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWStonesOfSunlight : DWItem
    {
        public DWStonesOfSunlight()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Stones of Sunlight";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = true;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("stones_of_sunlight-grey.png", "Stones of Sunlight"),
                ("stones_of_sunlight.png", "Stones of Sunlight")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
