using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWHerb : DWItem
    {
        public DWHerb()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Herb";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = false;
            allowsMultiple = true;
            Count = 0;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("herb-grey.png", "Herb"),
                ("herb.png", "Herb")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
