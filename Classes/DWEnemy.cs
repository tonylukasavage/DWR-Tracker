using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWR_Tracker.Classes
{
    public class DWEnemy
    {
        public string Name;
        public int[] HP;
        public int Strength;
        public int Agility;
        public int XP;
        public int Gold;
        public float HurtResist;
        public float SleepResist;
        public float Evasion;
        public int RunGroup;
        public float StopspellCap;
        private float runGroupFactor;
        public PictureBox PictureBox;

        private const string baseImagePath = "DWR_Tracker.Images.Enemies.";
        private int[] hurtDamage = new int[2] { 9, 16 };
        private int[] hurtmoreDamage = new int[2] { 58, 65 };

        public DWEnemy(string name, int[] hp, int strength, int agility, int xp, 
            int gold, float hurtResist, float sleepResist, float evasion, int runGroup,  
            float stopspellCap)
        {
            Name = name;
            HP = hp;
            Strength = strength;
            Agility = agility;
            XP = xp;
            Gold = gold;
            HurtResist = hurtResist;
            SleepResist = sleepResist;
            Evasion = evasion;
            RunGroup = runGroup;
            StopspellCap = stopspellCap;
            runGroupFactor = (new float[4] { 0.25f, 0.375f, 0.5f, 1.0f })[runGroup - 1];

            // load enemy image from embedded resource and scale up
            string ImagePath = baseImagePath + Name.ToLower().Replace(" ", "_") + ".png";
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(ImagePath);
            Bitmap src = new Bitmap(Image.FromStream(myStream), new Size(64, 64));
            Bitmap dst = new Bitmap(256, 256);
            Graphics g = Graphics.FromImage(dst);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(
                src,
                new Rectangle(0, 0, 256, 256)
            );

            // instantiate and configure the picture box
            PictureBox = new PictureBox();
            PictureBox.Image = dst;
            PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        // TODO: I'm dumb when it comes to probability calculations, so I'm doing
        // this the brute force way. Gotta be a cleaner method, I just don't know it.
        public float ChanceToBlockHeroRun(DWHero hero, bool isBackAttackCheck = false)
        {
            float runFactor = isBackAttackCheck ? 0.25f : runGroupFactor;
            int[] heroArray = Enumerable
                .Range(0, 255)
                .Select(x => x * hero.Agility)
                .ToArray();
            int[] enemyArray = Enumerable
                .Range(0, 255)
                .Select(x => (int)Math.Floor(x * Agility * runFactor))
                .ToArray();

            int enemyWin = 0;
            for (int i = 0; i < heroArray.Length; i++)
            {
                for (int j = 0; j < enemyArray.Length; j++)
                {
                    if (heroArray[i] < enemyArray[j])
                    {
                        enemyWin++;
                    }
                }
            }
            return enemyWin / (float)(heroArray.Length * enemyArray.Length);
        }

        public bool Run25DueToHeroStrength(DWHero hero)
        {
            return Strength * 2 <= hero.Strength;
        }

        public float ChanceToBackAttack(DWHero hero)
        {
            return ChanceToBlockHeroRun(hero, true);
        }

        public float HurtShot()
        {
            int dead = 0;
            for (int i = 0; i < HP.Length; i++)
            {
                dead += Enumerable.Range(hurtDamage[0], hurtDamage[1])
                    .Where(x => x >= HP[i]).ToArray().Length;
            }
            return dead / (float)(hurtDamage.Length * HP.Length);
        }

        public float HurtmoreShot()
        {
            int dead = 0;
            for (int i = 0; i < HP.Length; i++)
            {
                dead += Enumerable.Range(hurtmoreDamage[0], hurtmoreDamage[1])
                    .Where(x => x >= HP[i]).ToArray().Length;
            }
            return dead / (float)(hurtmoreDamage.Length * HP.Length);
        }

        public int[] DamageDealtRange(DWHero hero)
        {
            if (IsDefenseBroken(hero))
            {
                return new int[2]
                {
                    0,
                    (Strength + 4) / 6
                };
            }
            else
            {
                return new int[2]
                {
                    (Strength - (hero.DefensePower / 2)) / 4,
                    (Strength - (hero.DefensePower / 2)) / 2
                };
            }
        }

        public int[] DamageTakenRange(DWHero hero)
        {
            return new int[2]
            {
                (hero.AttackPower - (Agility / 2)) / 4,
                (hero.AttackPower - (Agility / 2)) / 2
            };
        }

        public bool IsDefenseBroken(DWHero hero)
        {
            return hero.DefensePower >= Strength;
        }

        public float MaxHPToXPRatio()
        {
            return HP[1] / (float)XP;
        }
    }
}
