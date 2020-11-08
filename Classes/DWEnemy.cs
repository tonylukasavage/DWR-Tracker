using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWR_Tracker.Classes
{
    class DWEnemy
    {
        public int[] HP;
        public int Agility;
        public int XP;
        public int Gold;
        public float HurtResist;
        public float SleepResist;
        public float Evasion;
        public int RunAt25Str;
        public int Hero50Run;
        public int Hero75Run;
        public int SleepInsteadOfRun;
        public int[] ThreeShot;
        public int[] TwoShot;
        public int[] OneShot;
        public int BackAttack25;
        public float StopspellCap;
        public float MHPToXPRatio;
        public float HurtmoreOneShot;
        public int HurtBreakEven;
        public int BrokenCap;

        public PictureBox PictureBox;

        public DWEnemy() { }
    }
}
