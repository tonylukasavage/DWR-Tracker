using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWErdricksToken : DWItem
    {
        public DWErdricksToken()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Erdrick's Token";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = true;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("token-grey.png", "Erdrick's Token"),
                ("token.png", "Erdrick's Token")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
