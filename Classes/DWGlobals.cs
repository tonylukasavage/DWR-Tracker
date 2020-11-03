using DWR_Tracker.Classes.Items;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes
{
    static class DWGlobals
    {
        public static bool AutoTrackingEnabled = true;
        public static bool ShowMenu = true;
        public static bool ShowStatus = false;

        public static DWFont DWFont = new DWFont();
        public static string DWImagePath = "DWR_Tracker.Images.";
        public static DWProcessReader ProcessReader;

        public static DWItem[] BattleItems = new DWItem[6]
        {
            new DWSword(),
            new DWArmor(),
            new DWShield(),
            new DWFightersRing(),
            new DWDragonsScale(),
            new DWDeathNecklace()
        };

        public static DWItem[] QuestItems = new DWItem[6]
        {
            new DWHarpOrStaff(),
            new DWStonesOfSunlight(),
            new DWErdricksToken(),
            new DWRainbowDrop(),
            new DWBridge(),
            new DWBallOfLight()
        };

        public static DWItem[] OptionalItems = new DWItem[3]
        {
            new DWMagicKey(),
            new DWFairyFlute(),
            new DWGwaelinsLove()
        };

        public static DWItem[] ExtraItems = new DWItem[5]
        {
            new DWTorch(),
            new DWFairyWater(),
            new DWWings(),
            new DWCursedBelt(),
            new DWHerb()
        };

        public static DWSpell[] Spells = new DWSpell[10]
        {
            new DWSpell("heal", 0xCE, 0x1),
            new DWSpell("hurt", 0xCE, 0x2),
            new DWSpell("sleep", 0xCE, 0x4),
            new DWSpell("radiant", 0xCE, 0x8),
            new DWSpell("stopspell", 0xCE, 0x10),
            new DWSpell("outside", 0xCE, 0x20),
            new DWSpell("return", 0xCE, 0x40),
            new DWSpell("repel", 0xCE, 0x80),
            new DWSpell("healmore", 0xCF, 0x1),
            new DWSpell("hurtmore", 0xCF, 0x2)
        };

        public static DWStat[] Stats = new DWStat[7]
        {
            new DWStat("lvl", 0xC7),
            new DWStat("str", 0xC8),
            new DWStat("agi", 0xC9),
            new DWStat("hp", 0xCA),
            new DWStat("mp", 0xCB),
            new DWStat("atk", 0xCC),
            new DWStat("def", 0xCD)
        };

        public static string[] InventoryItems = new string[16]
        {
            "Nothing",
            "Torch",
            "Fairy Water",
            "Wings",
            "Dragon's Scale",
            "Fairy Flute",
            "Fighter's Ring",
            "Erdrick's Token",
            "Gwaelin's Love",
            "Cursed Belt",
            "Silver Harp",
            "Death Necklace",
            "Stones of Sunlight",
            "Staff of Rain",
            "Rainbow Drop",
            "Herb"
        };

    }
}
