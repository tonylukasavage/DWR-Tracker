using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWGwaelinsLove : DWItem
    {
        public DWGwaelinsLove()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Gwaelin's Love";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = false;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("gwaelin-grey.png", "Gwaelin's Love"),
                ("gwaelin.png", "Gwaelin's Love")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
