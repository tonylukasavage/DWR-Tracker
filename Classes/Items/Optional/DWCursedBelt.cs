using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWCursedBelt : DWItem
    {
        public DWCursedBelt()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Cursed Belt";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = false;
            allowsMultiple = true;
            ShowCount = true;
            Count = 0;

            ItemInfo = new (string ImagePath, string Name, int ExtraValue)[2]
            {
                ("cursed_belt.png", "Cursed Belt", 0),
                ("cursed_belt.png", "Cursed Belt", 0)
            }.Select(s => (basePath + s.ImagePath, s.Name, s.ExtraValue)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
