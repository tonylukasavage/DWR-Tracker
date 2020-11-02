using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWBridge : DWItem
    {
        public DWBridge()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Charlock Bridge";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = true;
            allowsMultiple = false;
            forceOwnRead = true;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("bridge-grey.png", "Charlock Bridge"),
                ("bridge.png", "Charlock Bridge")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return (DWGlobals.ProcessReader.ReadByte(0xCF) & 0x80) > 0 ? 1 : 0;
        }
    }
}
