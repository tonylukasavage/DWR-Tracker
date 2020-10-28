using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWTorch : DWItem
    {
        public DWTorch()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Torch";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = false;
            allowsMultiple = true;
            Count = 0;

            ItemInfo = new (string ImagePath, string Name)[2]
            {
                ("torch-grey.png", "Torch"),
                ("torch.png", "Torch")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
        }

        public override int ReadValue()
        {
            return 0;
        }
    }
}
