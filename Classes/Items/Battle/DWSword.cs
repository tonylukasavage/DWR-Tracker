using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    class DWSword : DWItem
    {
        public DWSword()
        {
            string basePath = DWGlobals.DWImagePath + "Swords.";

            Name = "Nothing";
            ImagePath = "";
            IsBattleGear = true;
            IsRequiredItem = false;
            allowsMultiple = false;
            Count = 1;
            
            ItemInfo = new (string ImagePath, string Name)[8]
            {
                ("weapon-no.png", "Nothing"),
                ("bamboo.png", "Bamboo Pole"),
                ("club.png", "Club"),
                ("copper.png", "Copper Sword"),
                ("axe.png", "Hand Axe"),
                ("broad.png", "Brroad Sword"),
                ("flame.png", "Flame Sword"),
                ("erdricks.png", "Erdrick's Sword")
            }.Select(s => (basePath + s.ImagePath, s.Name)).ToArray();
    }

        public override int ReadValue()
        {
            return (DWGlobals.ProcessReader.ReadByte(0xBE) >> 5) & 0x7;
        }
    }
}
