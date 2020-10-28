using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWDragonsScale : DWItem
    {
        public DWDragonsScale()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Nothing";
            ImagePath = "";
            IsBattleGear = true;
            IsRequiredItem = false;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("dragon_scale-grey.png", "Nothing"),
                ("dragon_scale.png", "Fighter's Ring")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return (DWGlobals.DWGameReader.GetInt(0xCF, 1) & 0x10) > 0 ? 1 : 0;
        }
    }
}
