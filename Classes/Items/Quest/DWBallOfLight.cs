using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    public class DWBallOfLight : DWItem
    {
        public DWBallOfLight()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Ball of Light";
            ImagePath = "";
            IsBattleGear = false;
            IsRequiredItem = true;
            allowsMultiple = false;
            forceOwnRead = true;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name, int ExtraValue)[2]
            {
                ("ball-grey.png", "Ball of Light", 0),
                ("ball.png", "Ball of Light", 0)
            }.Select(s => (basePath + s.ImagePath, s.Name, s.ExtraValue)).ToArray();
        }

        public override int ReadValue()
        {
            return (DWGlobals.ProcessReader.ReadByte(0xE4) & 0x4) > 0 ? 1 : 0;
        }
    }
}
