using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWMagicKey : DWItem
    {
        public DWMagicKey()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Magic Key";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = false;
            allowsMultiple = true;
            ShowCount = true;
            Count = 0;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("key-grey.png", "Magic Key"),
                ("key.png", "Magic Key")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return DWGlobals.ProcessReader.ReadByte(0xBF);
        }
    }
}
