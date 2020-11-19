using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using DWR_Tracker.Classes;
using DWR_Tracker.Controls;
using Newtonsoft.Json;

namespace DWR_Tracker
{
    public partial class MainForm : Form
    {
        private DWConfiguration Config = DWGlobals.DWConfiguration;
        private DWHero Hero = DWGlobals.Hero;
        private bool inBattle = false;
        private int heightChrome = 837;
        private int heightChromeless = 791;

        public MainForm()
        {
            InitializeComponent();

            // try to find a suitable emulator automatically
            if (!EmulatorConnectionWorker.IsBusy)
            {
                EmulatorConnectionWorker.RunWorkerAsync();
            }
        }

        private delegate void UpdateEnemyDelegate(DWEnemy enemy);
        private void UpdateEnemy(DWEnemy enemy)
        {
            if (EnemyPanel.InvokeRequired)
            {
                var d = new UpdateEnemyDelegate(UpdateEnemy);
                EnemyPanel.Invoke(d, new object[] { enemy });
            }
            else
            {
                // update enemy image 
                EnemyPanelPictureBox.Image = enemy.GetImage();

                // clear enemy stats table
                while (EnemyStatsTable.Controls.Count > 0)
                {
                    EnemyStatsTable.Controls[0].Dispose();
                }
                while (EnemyInfoTable.Controls.Count > 0)
                {
                    EnemyInfoTable.Controls[0].Dispose();
                }

                // add enemy stats to table
                string[,] stats = enemy.GetBattleInfo(Hero);
                for (int i = 0; i < stats.GetLength(0); i++)
                {
                    string name = stats[i, 0];
                    string value = stats[i, 1];

                    if (i == 0)
                    {
                        EnemyNameLabel.TextAlign = ContentAlignment.TopCenter;
                        EnemyNameLabel.FitText(name);
                    }
                    else
                    {
                        TableLayoutPanel table = i < 4 ? EnemyInfoTable : EnemyStatsTable;
                        bool isHeader = name == "ATTACK" || name == "DEFENSE";
                        int row = i < 4 ? i - 1 : i - 4;

                        DWLabel nameLabel = new DWLabel { TextAlign = ContentAlignment.MiddleLeft };
                        table.Controls.Add(nameLabel, 0, row);
                        nameLabel.FitText(name, true, isHeader ? FontStyle.Bold : FontStyle.Regular);

                        DWLabel valueLabel = new DWLabel { TextAlign = ContentAlignment.MiddleRight };
                        table.Controls.Add(valueLabel, 1, row);
                        valueLabel.FitText(value, true);
                    } 
                } 
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // update UI based on config
            streamerModeToolStripMenuItem.Checked = Config.StreamerMode;
            autoTrackingToolStripMenuItem.Checked = Config.AutoTrackingEnabled;
            MainFormLayoutUpdate();

            // hide enemy panel initially
            EnemyPanel.Visible = false;

            // draw rounded background box for enemy image
            PictureBox pb = EnemyPanelPictureBox;
            Rectangle r = new Rectangle(0, 0, pb.Width, pb.Height);
            GraphicsPath gp = new GraphicsPath();
            int d = 20;
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            pb.Region = new Region(gp);

            // set the hero's name
            Hero.NameChanged += (sender, e) => 
            {
                this.Invoke(() => StatPanel.Title = Hero.Name);
            };

            //Set initial UI for hero stats
            for (int i = 0; i < Hero.DisplayStats.Length; i++)
            {
                DWStat stat = Hero.DisplayStats[i];
                DWLabel nameLabel = new DWLabel { Text = stat.Name.ToUpper() };
                DWLabel valueLabel = new DWLabel { 
                    Text = stat.Value.ToString(), 
                    TextAlign = ContentAlignment.MiddleRight 
                };
                StatTableLayout.Controls.Add(nameLabel, 0, i);
                StatTableLayout.Controls.Add(valueLabel, 1, i);
                stat.ValueChanged += (sender, e) =>
                {
                    this.Invoke(() => valueLabel.Text = stat.Value.ToString());
                };
            }

            // create spell labels
            for (int i = 0; i < Hero.Spells.Length; i++)
            {
                DWSpell spell = Hero.Spells[i];
                DWSpellLabel label = new DWSpellLabel(spell);

                // position spell in panel
                SpellPanel.Controls.Add(label);
                label.Top = i * 26 + 26;
                label.Left = 15;
                label.Width = SpellPanel.Width;

                // update color on spell value change
                spell.ValueChanged += (sender, e) =>
                {
                    this.Invoke(() => label.ForeColor = spell.HasSpell ?
                        Color.FromArgb(255, 255, 255) :
                        Color.FromArgb(60, 60, 60));
                };
            }

            // set initial UI for all items
            foreach (DWItem item in Hero.QuestItems)
            {
                DWItemBox itemBox = new DWItemBox(item);
                if (item.IsFirstHalfQuestItem)
                {
                    Hero.RainbowDrop.ValueChanged += (sender, e) =>
                    {
                        this.Invoke(() => itemBox.Visible = Hero.RainbowDrop.Value == 0);
                    };
                }
                RequiredItemFlowPanel.Controls.Add(itemBox);
            }

            foreach(DWItem item in Hero.BattleGear)
            {
                BattleItemFlowPanel.Controls.Add(new DWItemBox(item));
            }

            foreach (DWItem item in Hero.OtherItems)
            {
                OptionalItemFlowPanel.Controls.Add(new DWItemBox(item));
            }

            // setup info panel


            // game state update timer
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += CheckGameState;
            timer.Start();
        }

        private void MainFormLayoutUpdate()
        {
            DWMenuStrip.Visible = DWStatusStrip.Visible = !Config.StreamerMode;
            DWContentPanel.Top = 4 + (DWMenuStrip.Visible ? DWMenuStrip.Height : 0);

            if (Config.StreamerMode)
            {
                this.Height = heightChromeless;
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.Height = heightChrome;
            }
        }

        private void Stat_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CheckGameState(object source, ElapsedEventArgs e)
        {
            if (Config.AutoTrackingEnabled && 
                DWGlobals.ProcessReader != default(DWProcessReader))
            {
                int statusByte = DWGlobals.ProcessReader.Read(0x3, 1, 1)[0];
                bool inBattleCheck = statusByte == 3;

                if (!inBattle && inBattleCheck)
                {
                    inBattle = true;
                    int enemyIndex = DWGlobals.ProcessReader.ReadByte(0xE0);
                    int location = DWGlobals.ProcessReader.ReadByte(0x45);
                    if (location != 0)
                    {
                        UpdateEnemy(DWGlobals.Enemies[enemyIndex]);
                    }
                    this.Invoke(() => EnemyPanel.Visible = true);
                    // UpdateInfoPanel(EnemyPanel, true);
                }
                else if (inBattle && !inBattleCheck)
                {
                    inBattle = false;
                    this.Invoke(() => EnemyPanel.Visible = false);
                    //UpdateInfoPanel(EnemyPanel, false);
                }

                Hero.Update();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EmulatorConnectionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // load all configured emulators from emulators.json
            StreamReader r = new StreamReader("emulators.json");
            string json = r.ReadToEnd();
            dynamic array = JsonConvert.DeserializeObject(json);
            foreach (var item in array)
            {
                string name = item.name;
                foreach (var vItem in item.versions)
                {
                    // assign json items
                    string version = vItem.version;
                    string dll = vItem.dll;
                    int arch = vItem.arch;
                    string[] offsets = vItem.offsets.ToObject<string[]>();

                    if (vItem.sramOffsets == null)
                    {
                        Console.WriteLine("[WARNING] no sram offsets for {0} {1}", name, version);
                        continue;
                    }
                    string[] sramOffsets = vItem.sramOffsets.ToObject<string[]>();

                    if (vItem.romOffsets == null)
                    {
                        Console.WriteLine("[WARNING] no rom offsets for {0} {1}", name, version);
                        continue;
                    }
                    string[] romOffsets = vItem.romOffsets.ToObject<string[]>();

                    // find emulator process
                    Process[] processes = Process.GetProcessesByName(name);
                    if (processes.Length < 1) { continue; }

                    foreach (Process p in processes)
                    {
                        Console.Out.WriteLine(p.MainWindowTitle);
                        DWProcessReader reader = new DWProcessReader(p);

                        IntPtr baseOffset = reader.FindOffset(dll, offsets);
                        if (baseOffset == (IntPtr)(-1))
                        {
                            Console.WriteLine("[ERROR] Couldn't find NES pointer for {0}", p.ProcessName);
                            continue;
                        }
                        reader.BaseOffset = baseOffset;

                        IntPtr sramOffset = reader.FindOffset(dll, sramOffsets);
                        if (sramOffset == (IntPtr)(-1))
                        {
                            Console.WriteLine("[ERROR] Couldn't find NES sram pointer for {0}", p.ProcessName);
                            continue;
                        }
                        reader.SramOffset = sramOffset;

                        IntPtr romOffset = reader.FindOffset(dll, romOffsets);
                        if (romOffset == (IntPtr)(-1))
                        {
                            Console.WriteLine("[ERROR] Couldn't find NES rom pointer for {0}", p.ProcessName);
                            continue;
                        }
                        reader.RomOffset = romOffset;

                        // TODO: Base offset doesn't take us to this part of memory
                        // find "DRAGON WARRIOR" at offset +0xFFE0
                        //string identifier = reader.ReadString(0xFFE0, 14);
                        //if (identifier != "DRAGON WARRIOR")
                        //{
                        //    continue;
                        //}

                        // found our emulator
                        DWGlobals.ProcessReader = reader;
                        break;
                    }

                    if (DWGlobals.ProcessReader != default(DWProcessReader)) { break; }
                }
            } 
        }

        private void EmulatorConnectionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DWProcessReader reader = DWGlobals.ProcessReader;
            if (reader != default(DWProcessReader))
            {
                // update emulator name in status bar
                EmulatorStatusLabel.Text = reader.Process.MainWindowTitle;

                // execute first hero update
                Hero.Update(true);

                // update all enemy skills and attack patterns
                for (int i = 0; i < DWGlobals.Enemies.Length; i++)
                {
                    DWEnemy enemy = DWGlobals.Enemies[i];
                    int pattern = reader.Read((0x9E4B + (i * 0x10)) + 3, 1, 2)[0];
                    enemy.Skill2Chance = (pattern & 0x3) / 4f;
                    enemy.Skill2 = enemy.GetSkill2((pattern >> 2) & 0x3);
                    enemy.Skill1Chance = ((pattern >> 4) & 0x3) / 4f;
                    enemy.Skill1 = enemy.GetSkill1((pattern >> 6) & 0x3);
                }
            }
        }

        private void streamerModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            Config.StreamerMode = mi.Checked = !mi.Checked;
            MainFormLayoutUpdate();
        }

        private void autoTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            Config.AutoTrackingEnabled = mi.Checked = !mi.Checked;
        }
    }

    public class ItemPictureBox
    {
        public DWItem Item;
        public DWItemBox ItemBox;

        public ItemPictureBox(DWItem item, DWItemBox itemBox)
        {
            Item = item;
            ItemBox = itemBox;
        }
    }
}
