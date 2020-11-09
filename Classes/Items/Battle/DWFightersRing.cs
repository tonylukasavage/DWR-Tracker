using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Items
{
    public class DWFightersRing : DWItem
    {
        public int AttackPower = 0;

        public DWFightersRing()
        {
            string basePath = DWGlobals.DWImagePath + "Items.";

            Name = "Fighter's Ring";
            ImagePath = "";
            IsBattleGear = true;
            IsRequiredItem = false;
            allowsMultiple = false;
            Count = 1;

            ItemInfo = new (string ImagePath, string Name, int ExtraValue)[2]
            {
                ("fighters_ring-grey.png", "Fighter's Ring", 0),
                ("fighters_ring.png", "Fighter's Ring", 2)
            }.Select(s => (basePath + s.ImagePath, s.Name, s.ExtraValue)).ToArray();
        }

        public override int ReadValue()
        {
            return (DWGlobals.ProcessReader.ReadByte(0xCF) & 0x20) > 0 ? 1 : 0;
        }
        public override void UpdatePictureBox(int value, bool force = false)
        {
            AttackPower = ItemInfo[value].ExtraValue;
            base.UpdatePictureBox(value, force);
        }

    }
}
