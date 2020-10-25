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
        public static DWFont DWFont = new DWFont();
        public static DWGameReader DWGameReader = new DWGameReader();
        public static string DWImagePath = "DWR_Tracker.Images.";

        public static enum DWItemTypes
        {
            Battle = 1,
            Inventory = 2,
            Multiple = 3,
            Quest = 4
        }

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

        public static DWEquipment Shield = new DWEquipment("Shield");
        public static DWEquipment Armor = new DWEquipment("Armor");
        public static DWEquipment Sword = new DWEquipment("Sword");
        public static DWEquipment FightersRing = new DWEquipment("Fighter's Ring");
        public static DWEquipment DragonsScale = new DWEquipment("Dragon's Scale");
        public static DWEquipment DeathNecklace = new DWEquipment("Death Necklace");
        public static DWEquipment MagicKey = new DWEquipment("Magic Key");
        public static DWEquipment FairyFlute = new DWEquipment("Fairy Flute");

        public static string[] FightersRingImages = new string[2]
        {
            "DWR_Tracker.Images.Items.fighters_ring-grey.png",
            "DWR_Tracker.Images.Items.fighters_ring.png"
        };

        public static string[] DragonsScaleImages = new string[2]
        {
            "DWR_Tracker.Images.Items.dragon_scale-grey.png",
            "DWR_Tracker.Images.Items.dragon_scale.png"
        };

        public static string[] DeathNecklaceImages = new string[2]
        {
            "DWR_Tracker.Images.Items.reckless_necklace_th-grey.png",
            "DWR_Tracker.Images.Items.reckless_necklace_th.png"
        };

        public static string[] MagicKeyImages = new string[2]
        {
            "DWR_Tracker.Images.Items.key-grey.png",
            "DWR_Tracker.Images.Items.key.png"
        };

        public static string[] FairyFluteImages = new string[2]
        {
            "DWR_Tracker.Images.Items.flute-grey.png",
            "DWR_Tracker.Images.Items.flute.png"
        };

        public static string[] Shields = new string[4]
        {
            "None",
            "Small Shield",
            "Large Shield",
            "Silver Shield"
        };

        public static string[] ShieldImages = new string[4]
        {
            "DWR_Tracker.Images.Shields.shield-no.png",
            "DWR_Tracker.Images.Shields.small.png",
            "DWR_Tracker.Images.Shields.large.png",
            "DWR_Tracker.Images.Shields.silver.png"
        };

        public static string[] Armors = new string[8]
        {
            "None",
            "Clothes",
            "Leather Armor",
            "Chain Mail",
            "Half Plate",
            "Full Plate",
            "Magic Armor",
            "Erdrick's Armor"
        };

        public static string[] ArmorImages = new string[8]
        {
            "DWR_Tracker.Images.Armors.armor-no.png",
            "DWR_Tracker.Images.Armors.clothes.png",
            "DWR_Tracker.Images.Armors.leather.png",
            "DWR_Tracker.Images.Armors.chain.png",
            "DWR_Tracker.Images.Armors.half.png",
            "DWR_Tracker.Images.Armors.full.png",
            "DWR_Tracker.Images.Armors.magic.png",
            "DWR_Tracker.Images.Armors.erdricks.png"
        };

        public static string[] Swords = new string[8]
        {
            "None",
            "Bamboo Pole",
            "Club",
            "Copper Sword",
            "Hand Axe",
            "Broad Sword",
            "Flame Sword",
            "Erdrick's Sword"
        };

        public static string[] SwordImages = new string[8]
        {
            "DWR_Tracker.Images.Swords.weapon-no.png",
            "DWR_Tracker.Images.Swords.bamboo.png",
            "DWR_Tracker.Images.Swords.club.png",
            "DWR_Tracker.Images.Swords.copper.png",
            "DWR_Tracker.Images.Swords.axe.png",
            "DWR_Tracker.Images.Swords.broad.png",
            "DWR_Tracker.Images.Swords.flame.png",
            "DWR_Tracker.Images.Swords.erdricks.png"
        };

        public static string[] Items = new string[16]
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
