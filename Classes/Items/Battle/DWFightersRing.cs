using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWFightersRing : DWItem
    {
        public DWFightersRing()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Fighter's Ring";
            ImagePath = "";
            IsBattleGear = true;
            IsRequiredItem = false;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("fighters_ring-grey.png", "Fighter's Ring"),
                ("fighters_ring.png", "Fighter's Ring")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return (DWGlobals.DWGameReader.GetInt(0xCF, 1) & 0x20) > 0 ? 1 : 0;
        }
    }
}
