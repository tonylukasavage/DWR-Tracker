namespace DWR_Tracker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DWMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamerModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoTrackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DWStatusStrip = new System.Windows.Forms.StatusStrip();
            this.EmulatorStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.EmulatorConnectionWorker = new System.ComponentModel.BackgroundWorker();
            this.DWContentPanel = new System.Windows.Forms.Panel();
            this.BattlePanel = new DWR_Tracker.Controls.DWPanel();
            this.BattleItemFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OptionalItemPanel = new DWR_Tracker.Controls.DWPanel();
            this.OptionalItemFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.QuestPanel = new DWR_Tracker.Controls.DWPanel();
            this.RequiredItemFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.StatPanel = new DWR_Tracker.Controls.DWPanel();
            this.StatTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SpellPanel = new DWR_Tracker.Controls.DWPanel();
            this.CombatPanel = new DWR_Tracker.Controls.DWPanel();
            this.EnemyPanel = new System.Windows.Forms.Panel();
            this.EnemyInfoTable = new System.Windows.Forms.TableLayoutPanel();
            this.EnemyNameLabel = new DWR_Tracker.Controls.DWLabel();
            this.EnemyPanelPictureBox = new System.Windows.Forms.PictureBox();
            this.EnemyStatsTable = new System.Windows.Forms.TableLayoutPanel();
            this.DWMenuStrip.SuspendLayout();
            this.DWStatusStrip.SuspendLayout();
            this.DWContentPanel.SuspendLayout();
            this.BattlePanel.SuspendLayout();
            this.OptionalItemPanel.SuspendLayout();
            this.QuestPanel.SuspendLayout();
            this.StatPanel.SuspendLayout();
            this.CombatPanel.SuspendLayout();
            this.EnemyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPanelPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DWMenuStrip
            // 
            this.DWMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.DWMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.DWMenuStrip.Name = "DWMenuStrip";
            this.DWMenuStrip.Size = new System.Drawing.Size(393, 24);
            this.DWMenuStrip.TabIndex = 11;
            this.DWMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.connectToolStripMenuItem.Text = "Connect...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.streamerModeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // streamerModeToolStripMenuItem
            // 
            this.streamerModeToolStripMenuItem.Name = "streamerModeToolStripMenuItem";
            this.streamerModeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.streamerModeToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.streamerModeToolStripMenuItem.Text = "Streamer Mode";
            this.streamerModeToolStripMenuItem.Click += new System.EventHandler(this.streamerModeToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoTrackingToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // autoTrackingToolStripMenuItem
            // 
            this.autoTrackingToolStripMenuItem.Checked = true;
            this.autoTrackingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoTrackingToolStripMenuItem.Name = "autoTrackingToolStripMenuItem";
            this.autoTrackingToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.autoTrackingToolStripMenuItem.Text = "Auto Tracking";
            this.autoTrackingToolStripMenuItem.Click += new System.EventHandler(this.autoTrackingToolStripMenuItem_Click);
            // 
            // DWStatusStrip
            // 
            this.DWStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EmulatorStatusLabel});
            this.DWStatusStrip.Location = new System.Drawing.Point(0, 776);
            this.DWStatusStrip.Name = "DWStatusStrip";
            this.DWStatusStrip.Size = new System.Drawing.Size(393, 22);
            this.DWStatusStrip.SizingGrip = false;
            this.DWStatusStrip.TabIndex = 12;
            this.DWStatusStrip.Text = "statusStrip1";
            // 
            // EmulatorStatusLabel
            // 
            this.EmulatorStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.EmulatorStatusLabel.Name = "EmulatorStatusLabel";
            this.EmulatorStatusLabel.Size = new System.Drawing.Size(86, 17);
            this.EmulatorStatusLabel.Text = "Not connected";
            // 
            // EmulatorConnectionWorker
            // 
            this.EmulatorConnectionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.EmulatorConnectionWorker_DoWork);
            this.EmulatorConnectionWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.EmulatorConnectionWorker_RunWorkerCompleted);
            // 
            // DWContentPanel
            // 
            this.DWContentPanel.Controls.Add(this.BattlePanel);
            this.DWContentPanel.Controls.Add(this.OptionalItemPanel);
            this.DWContentPanel.Controls.Add(this.QuestPanel);
            this.DWContentPanel.Controls.Add(this.StatPanel);
            this.DWContentPanel.Controls.Add(this.SpellPanel);
            this.DWContentPanel.Location = new System.Drawing.Point(0, 27);
            this.DWContentPanel.Name = "DWContentPanel";
            this.DWContentPanel.Size = new System.Drawing.Size(386, 464);
            this.DWContentPanel.TabIndex = 13;
            // 
            // BattlePanel
            // 
            this.BattlePanel.BackColor = System.Drawing.Color.Black;
            this.BattlePanel.Controls.Add(this.BattleItemFlowPanel);
            this.BattlePanel.Location = new System.Drawing.Point(0, 384);
            this.BattlePanel.MinimumSize = new System.Drawing.Size(144, 56);
            this.BattlePanel.Name = "BattlePanel";
            this.BattlePanel.Size = new System.Drawing.Size(387, 83);
            this.BattlePanel.TabIndex = 9;
            this.BattlePanel.Title = "BATTLE";
            // 
            // BattleItemFlowPanel
            // 
            this.BattleItemFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.BattleItemFlowPanel.Location = new System.Drawing.Point(13, 15);
            this.BattleItemFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BattleItemFlowPanel.Name = "BattleItemFlowPanel";
            this.BattleItemFlowPanel.Size = new System.Drawing.Size(356, 60);
            this.BattleItemFlowPanel.TabIndex = 3;
            // 
            // OptionalItemPanel
            // 
            this.OptionalItemPanel.BackColor = System.Drawing.Color.Black;
            this.OptionalItemPanel.Controls.Add(this.OptionalItemFlowPanel);
            this.OptionalItemPanel.Location = new System.Drawing.Point(203, 298);
            this.OptionalItemPanel.MinimumSize = new System.Drawing.Size(40, 56);
            this.OptionalItemPanel.Name = "OptionalItemPanel";
            this.OptionalItemPanel.Size = new System.Drawing.Size(184, 85);
            this.OptionalItemPanel.TabIndex = 8;
            this.OptionalItemPanel.Title = "";
            // 
            // OptionalItemFlowPanel
            // 
            this.OptionalItemFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.OptionalItemFlowPanel.Location = new System.Drawing.Point(7, 15);
            this.OptionalItemFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OptionalItemFlowPanel.Name = "OptionalItemFlowPanel";
            this.OptionalItemFlowPanel.Size = new System.Drawing.Size(186, 55);
            this.OptionalItemFlowPanel.TabIndex = 5;
            // 
            // QuestPanel
            // 
            this.QuestPanel.BackColor = System.Drawing.Color.Black;
            this.QuestPanel.Controls.Add(this.RequiredItemFlowPanel);
            this.QuestPanel.Location = new System.Drawing.Point(3, 299);
            this.QuestPanel.MinimumSize = new System.Drawing.Size(128, 56);
            this.QuestPanel.Name = "QuestPanel";
            this.QuestPanel.Size = new System.Drawing.Size(194, 83);
            this.QuestPanel.TabIndex = 10;
            this.QuestPanel.Title = "QUEST";
            // 
            // RequiredItemFlowPanel
            // 
            this.RequiredItemFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.RequiredItemFlowPanel.Location = new System.Drawing.Point(16, 16);
            this.RequiredItemFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RequiredItemFlowPanel.Name = "RequiredItemFlowPanel";
            this.RequiredItemFlowPanel.Size = new System.Drawing.Size(359, 61);
            this.RequiredItemFlowPanel.TabIndex = 4;
            // 
            // StatPanel
            // 
            this.StatPanel.BackColor = System.Drawing.Color.Black;
            this.StatPanel.Controls.Add(this.StatTableLayout);
            this.StatPanel.Location = new System.Drawing.Point(3, 3);
            this.StatPanel.MinimumSize = new System.Drawing.Size(128, 56);
            this.StatPanel.Name = "StatPanel";
            this.StatPanel.Size = new System.Drawing.Size(194, 295);
            this.StatPanel.TabIndex = 7;
            this.StatPanel.Text = "dwPanel1";
            this.StatPanel.Title = "STATS";
            // 
            // StatTableLayout
            // 
            this.StatTableLayout.ColumnCount = 2;
            this.StatTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.80981F));
            this.StatTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.19019F));
            this.StatTableLayout.Location = new System.Drawing.Point(17, 25);
            this.StatTableLayout.Name = "StatTableLayout";
            this.StatTableLayout.RowCount = 7;
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.40206F));
            this.StatTableLayout.Size = new System.Drawing.Size(163, 260);
            this.StatTableLayout.TabIndex = 2;
            // 
            // SpellPanel
            // 
            this.SpellPanel.BackColor = System.Drawing.Color.Black;
            this.SpellPanel.Location = new System.Drawing.Point(203, 3);
            this.SpellPanel.MinimumSize = new System.Drawing.Size(144, 56);
            this.SpellPanel.Name = "SpellPanel";
            this.SpellPanel.Size = new System.Drawing.Size(184, 295);
            this.SpellPanel.TabIndex = 6;
            this.SpellPanel.Text = "dwPanel1";
            this.SpellPanel.Title = "SPELLS";
            // 
            // CombatPanel
            // 
            this.CombatPanel.BackColor = System.Drawing.Color.Black;
            this.CombatPanel.Controls.Add(this.EnemyPanel);
            this.CombatPanel.Location = new System.Drawing.Point(3, 497);
            this.CombatPanel.MinimumSize = new System.Drawing.Size(112, 56);
            this.CombatPanel.Name = "CombatPanel";
            this.CombatPanel.Size = new System.Drawing.Size(383, 276);
            this.CombatPanel.TabIndex = 14;
            this.CombatPanel.Title = "INFO";
            // 
            // EnemyPanel
            // 
            this.EnemyPanel.Controls.Add(this.EnemyInfoTable);
            this.EnemyPanel.Controls.Add(this.EnemyNameLabel);
            this.EnemyPanel.Controls.Add(this.EnemyPanelPictureBox);
            this.EnemyPanel.Controls.Add(this.EnemyStatsTable);
            this.EnemyPanel.Location = new System.Drawing.Point(14, 15);
            this.EnemyPanel.Name = "EnemyPanel";
            this.EnemyPanel.Size = new System.Drawing.Size(352, 250);
            this.EnemyPanel.TabIndex = 1;
            // 
            // EnemyInfoTable
            // 
            this.EnemyInfoTable.ColumnCount = 2;
            this.EnemyInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.EnemyInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.EnemyInfoTable.Location = new System.Drawing.Point(3, 177);
            this.EnemyInfoTable.Name = "EnemyInfoTable";
            this.EnemyInfoTable.RowCount = 3;
            this.EnemyInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyInfoTable.Size = new System.Drawing.Size(148, 70);
            this.EnemyInfoTable.TabIndex = 3;
            // 
            // EnemyNameLabel
            // 
            this.EnemyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.EnemyNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.EnemyNameLabel.Location = new System.Drawing.Point(8, 10);
            this.EnemyNameLabel.Name = "EnemyNameLabel";
            this.EnemyNameLabel.Size = new System.Drawing.Size(143, 24);
            this.EnemyNameLabel.TabIndex = 2;
            this.EnemyNameLabel.Text = "name";
            // 
            // EnemyPanelPictureBox
            // 
            this.EnemyPanelPictureBox.BackColor = System.Drawing.Color.SlateGray;
            this.EnemyPanelPictureBox.Location = new System.Drawing.Point(15, 37);
            this.EnemyPanelPictureBox.Name = "EnemyPanelPictureBox";
            this.EnemyPanelPictureBox.Size = new System.Drawing.Size(128, 128);
            this.EnemyPanelPictureBox.TabIndex = 1;
            this.EnemyPanelPictureBox.TabStop = false;
            // 
            // EnemyStatsTable
            // 
            this.EnemyStatsTable.ColumnCount = 2;
            this.EnemyStatsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.EnemyStatsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.EnemyStatsTable.Location = new System.Drawing.Point(172, 10);
            this.EnemyStatsTable.Name = "EnemyStatsTable";
            this.EnemyStatsTable.RowCount = 11;
            this.EnemyStatsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyStatsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyStatsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyStatsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyStatsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.EnemyStatsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyStatsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyStatsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyStatsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyStatsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyStatsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.EnemyStatsTable.Size = new System.Drawing.Size(180, 237);
            this.EnemyStatsTable.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(393, 798);
            this.Controls.Add(this.CombatPanel);
            this.Controls.Add(this.DWContentPanel);
            this.Controls.Add(this.DWStatusStrip);
            this.Controls.Add(this.DWMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.DWMenuStrip;
            this.Name = "MainForm";
            this.Text = "Dragon Warrior Randomizer Auto-Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DWMenuStrip.ResumeLayout(false);
            this.DWMenuStrip.PerformLayout();
            this.DWStatusStrip.ResumeLayout(false);
            this.DWStatusStrip.PerformLayout();
            this.DWContentPanel.ResumeLayout(false);
            this.BattlePanel.ResumeLayout(false);
            this.BattlePanel.PerformLayout();
            this.OptionalItemPanel.ResumeLayout(false);
            this.OptionalItemPanel.PerformLayout();
            this.QuestPanel.ResumeLayout(false);
            this.QuestPanel.PerformLayout();
            this.StatPanel.ResumeLayout(false);
            this.StatPanel.PerformLayout();
            this.CombatPanel.ResumeLayout(false);
            this.CombatPanel.PerformLayout();
            this.EnemyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPanelPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel StatTableLayout;
        private System.Windows.Forms.FlowLayoutPanel BattleItemFlowPanel;
        private System.Windows.Forms.FlowLayoutPanel RequiredItemFlowPanel;
        private System.Windows.Forms.FlowLayoutPanel OptionalItemFlowPanel;
        private Controls.DWPanel SpellPanel;
        private Controls.DWPanel StatPanel;
        private Controls.DWPanel OptionalItemPanel;
        private Controls.DWPanel BattlePanel;
        private Controls.DWPanel QuestPanel;
        private System.Windows.Forms.MenuStrip DWMenuStrip;
        private System.Windows.Forms.StatusStrip DWStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel EmulatorStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker EmulatorConnectionWorker;
        private System.Windows.Forms.Panel DWContentPanel;
        private System.Windows.Forms.ToolStripMenuItem streamerModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoTrackingToolStripMenuItem;
        private Controls.DWPanel CombatPanel;
        private System.Windows.Forms.Panel EnemyPanel;
        private System.Windows.Forms.TableLayoutPanel EnemyStatsTable;
        private System.Windows.Forms.PictureBox EnemyPanelPictureBox;
        private Controls.DWLabel EnemyNameLabel;
        private System.Windows.Forms.TableLayoutPanel EnemyInfoTable;
    }
}

