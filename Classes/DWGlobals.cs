namespace DWR_Tracker.Classes
{
    static class DWGlobals
    {
        public static DWConfiguration DWConfiguration = new DWConfiguration();
        public static DWFont DWFont = new DWFont();
        public static string DWImagePath = "DWR_Tracker.Images.";
        public static DWProcessReader ProcessReader;

        public static DWHero Hero = new DWHero();

        // This only covers fast leveling
        public static int[] LevelNexts = new int[30]
        {
            0, 5, 17, 35, 82, 165,337, 600, 975, 1500, 2175, 3000, 4125, 5625, 7500,
            9750, 12000, 14250, 16500, 19500, 22500, 25500, 28500, 31500, 34500,
            37500, 40500, 43500, 46500, 49151
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

        public static DWEnemy[] Enemies = new DWEnemy[4]
        {
            new DWEnemy("Blue Slime", new int[2] { 2, 2 }, 5, 3, 1, 2, 0, 0, 1/64f, 1, 0),
            new DWEnemy("Red Slime", new int[2] { 3, 3 }, 7, 3, 2, 4, 0, 0, 1/64f, 1, 0),
            new DWEnemy("Drakee", new int[2] { 4, 5 }, 9, 6, 3, 6, 0, 0, 1/64f, 1, 0),
            new DWEnemy("Ghost", new int[2] { 6, 7 }, 11, 8, 4, 8, 0, 0, 1/16f, 1, 1/16f),
        };
    }
}
