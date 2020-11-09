using DWR_Tracker.Classes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes
{
    public class DWHero
    {
        // stats
        public string Name;
        public int Level;
        public int Strength;
        public int Agility;
        public int MaxHP;
        public int CurrentHP;
        public int MaxMP;
        public int CurrentMP;

        public int AttackPower
        {
            get
            {
                return Strength + 
                    Sword.AttackPower + 
                    FightersRing.AttackPower +
                    DeathNecklace.AttackPower;
            }
        }

        public int DefensePower
        {
            get
            {
                return (int)Math.Floor(Agility / (decimal)2) + 
                    Armor.DefensePower + 
                    Shield.DefensePower +
                    DragonsScale.DefensePower;
            }
        }

        // equipment
        public DWSword Sword;
        public DWArmor Armor;
        public DWShield Shield;

        // Items
        public DWFightersRing FightersRing;
        public DWDeathNecklace DeathNecklace;
        public DWDragonsScale DragonsScale;

        public DWHero()
        {

        }
    }
}
