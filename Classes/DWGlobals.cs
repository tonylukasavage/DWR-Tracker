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
        public static DWConfiguration DWConfiguration = new DWConfiguration();
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

        // This only covers fast leveling
        public static int[] LevelNexts = new int[30]
        {
            0, 5, 17, 35, 82, 165,337, 600, 975, 1500, 2175, 3000, 4125, 5625, 7500,
            9750, 12000, 14250, 16500, 19500, 22500, 25500, 28500, 31500, 34500,
            37500, 40500, 43500, 46500, 49151
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

        public static DWStat[] Stats = new DWStat[10]
        {
            new DWStat("lvl", 0xC7),
            new DWStat("str", 0xC8),
            new DWStat("agi", 0xC9),
            new DWStat("hp", 0xCA),
            new DWStat("mp", 0xCB),
            new DWStat("atk", 0xCC),
            new DWStat("def", 0xCD),
            new DWStat("gld", 0xBC),
            new DWStat("exp", 0xBA),

            // TODO: grab this from RAM once I figure out how to find the pointer 
            // path to it. I know the table starts at 0xB35B, but need the pointer.
            new DWStat("nxt", 0)
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
