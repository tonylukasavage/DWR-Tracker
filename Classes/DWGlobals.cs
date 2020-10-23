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
            new DWStat("lvl", 1, 0xC7),
            new DWStat("str", 1, 0xC8),
            new DWStat("agi", 1, 0xC9),
            new DWStat("hp", 1, 0xCA),
            new DWStat("mp", 1, 0xCB),
            new DWStat("atk", 1, 0xCC),
            new DWStat("def", 1, 0xCD)
        };

    }
}
