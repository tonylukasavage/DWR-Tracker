using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public string Skill1;
        public float Skill1Chance;
        public string Skill2;
        public float Skill2Chance;

        private float runGroupFactor;
        private const string baseImagePath = "DWR_Tracker.Images.Enemies.";
        private int[] hurtDamage = new int[2] { 9, 16 };
        private int[] hurtmoreDamage = new int[2] { 58, 65 };
        private string[] skill2 = new string[4] { "hurt", "hurtmore", "baby breath", "DL2 breath" };
        private string[] skill1 = new string[4] { "sleep", "stopspell", "heal", "healmore" };

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
        }

        public string GetSkill1(int index)
        {
            return skill1[index];
        }

        public string GetSkill2(int index)
        {
            return skill2[index];
        }

        public Image GetImage()
        {
            string ImagePath = baseImagePath + Name.ToLower().Replace(" ", "_") + ".png";
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(ImagePath);
            Bitmap src = new Bitmap(Image.FromStream(myStream), new Size(64, 64));
            Bitmap dst = new Bitmap(128, 128);
            Graphics g = Graphics.FromImage(dst);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(
                src,
                new Rectangle(0, 0, 128, 128)
            );
            return dst;
        }

        public string[,] GetBattleInfo(DWHero hero)
        {
            int[] damageDealt = DamageDealtRange(hero);
            int[] damageTaken = DamageTakenRange(hero);

            return new string[15, 2]
            {
                // info
                { Name, "" },
                { "HP", HP[0] == HP[1] ? HP[0].ToString() : HP[0] + "-" + HP[1] },
                { "E", XP.ToString() },
                { "G", Gold.ToString() },

                // attack & skills
                { "ATTACK:", "" },
                { "enemy dmg", damageDealt[0] + "-" + damageDealt[1] },
                { "hero dmg", damageTaken[0] + "-" + damageTaken[1] },
                { Skill1, Math.Floor(Skill1Chance * 100).ToString() + "%" },
                { Skill2, Math.Floor(Skill2Chance * 100).ToString() + "%" },
                { "", "" },

                // defense
                { "CHANCE:", "" },
                { "hurt", Math.Floor((1f - HurtResist) * 100).ToString() + "%" },
                { "sleep", Math.Floor((1f - SleepResist) * 100).ToString() + "%" },
                { "dodge", Math.Floor(Evasion * 100).ToString() + "%" },
                { "run", Math.Floor((1f - ChanceToBlockHeroRun(hero)) * 100).ToString() + "%" },

            };
        }

        // TODO: I'm dumb when it comes to probability calculations, so I'm doing
        // this the brute force way. Gotta be a cleaner method, I just don't know it.
        public float ChanceToBlockHeroRun(DWHero hero, bool isBackAttackCheck = false)
        {
            float runFactor = isBackAttackCheck ? 0.25f : runGroupFactor;
            int[] heroArray = Enumerable
                .Range(0, 255)
                .Select(x => x * hero.Agility.Value)
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
            return Strength * 2 <= hero.Strength.Value;
        }

        public float ChanceToBackAttack(DWHero hero)
        {
            return ChanceToBlockHeroRun(hero, true);
        }

        public float HurtShot()
        {
            int dead = 0;
            IEnumerable<int> hurtRange = Enumerable.Range(hurtDamage[0], hurtDamage[1]);
            for (int i = 0; i < HP.Length; i++)
            {
                dead += hurtRange.Where(x => x >= HP[i]).ToArray().Length;
            }
            return dead / (float)(hurtRange.ToArray().Length * HP.Length);
        }

        public float HurtmoreShot()
        {
            int dead = 0;
            IEnumerable<int> hurtmoreRange = Enumerable.Range(hurtmoreDamage[0], hurtmoreDamage[1]);
            for (int i = 0; i < HP.Length; i++)
            {
                dead += hurtmoreRange.Where(x => x >= HP[i]).ToArray().Length;
            }
            return dead / (float)(hurtmoreRange.ToArray().Length * HP.Length);
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
                    (Strength - (hero.DefensePower.Value / 2)) / 4,
                    (Strength - (hero.DefensePower.Value / 2)) / 2
                };
            }
        }

        public int[] DamageTakenRange(DWHero hero)
        {
            return new int[2]
            {
                (hero.AttackPower.Value - (Agility / 2)) / 4,
                (hero.AttackPower.Value - (Agility / 2)) / 2
            };
        }

        public bool IsDefenseBroken(DWHero hero)
        {
            return hero.DefensePower.Value >= Strength;
        }

        public float MaxHPToXPRatio()
        {
            return HP[1] / (float)XP;
        }
    }
}
