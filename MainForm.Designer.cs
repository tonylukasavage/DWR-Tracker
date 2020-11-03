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
            this.StatTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.BattleItemFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.RequiredItemFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OptionalItemFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SpellPanel = new DWR_Tracker.Controls.DWPanel();
            this.StatPanel = new DWR_Tracker.Controls.DWPanel();
            this.OptionalItemPanel = new DWR_Tracker.Controls.DWPanel();
            this.BattlePanel = new DWR_Tracker.Controls.DWPanel();
            this.QuestPanel = new DWR_Tracker.Controls.DWPanel();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.EmulatorStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.EmulatorConnectionWorker = new System.ComponentModel.BackgroundWorker();
            this.showMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatPanel.SuspendLayout();
            this.OptionalItemPanel.SuspendLayout();
            this.BattlePanel.SuspendLayout();
            this.QuestPanel.SuspendLayout();
            this.MainMenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatTableLayout
            // 
            this.StatTableLayout.ColumnCount = 2;
            this.StatTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.StatTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
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
            this.StatTableLayout.Size = new System.Drawing.Size(163, 172);
            this.StatTableLayout.TabIndex = 2;
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
            // RequiredItemFlowPanel
            // 
            this.RequiredItemFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.RequiredItemFlowPanel.Location = new System.Drawing.Point(16, 16);
            this.RequiredItemFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RequiredItemFlowPanel.Name = "RequiredItemFlowPanel";
            this.RequiredItemFlowPanel.Size = new System.Drawing.Size(359, 61);
            this.RequiredItemFlowPanel.TabIndex = 4;
            // 
            // OptionalItemFlowPanel
            // 
            this.OptionalItemFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.OptionalItemFlowPanel.Location = new System.Drawing.Point(13, 15);
            this.OptionalItemFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OptionalItemFlowPanel.Name = "OptionalItemFlowPanel";
            this.OptionalItemFlowPanel.Size = new System.Drawing.Size(181, 55);
            this.OptionalItemFlowPanel.TabIndex = 5;
            // 
            // SpellPanel
            // 
            this.SpellPanel.BackColor = System.Drawing.Color.Black;
            this.SpellPanel.Location = new System.Drawing.Point(212, 34);
            this.SpellPanel.MinimumSize = new System.Drawing.Size(110, 58);
            this.SpellPanel.Name = "SpellPanel";
            this.SpellPanel.Size = new System.Drawing.Size(178, 295);
            this.SpellPanel.TabIndex = 6;
            this.SpellPanel.Text = "dwPanel1";
            this.SpellPanel.Title = "SPELLS";
            // 
            // StatPanel
            // 
            this.StatPanel.BackColor = System.Drawing.Color.Black;
            this.StatPanel.Controls.Add(this.StatTableLayout);
            this.StatPanel.Location = new System.Drawing.Point(12, 34);
            this.StatPanel.MinimumSize = new System.Drawing.Size(97, 58);
            this.StatPanel.Name = "StatPanel";
            this.StatPanel.Size = new System.Drawing.Size(194, 210);
            this.StatPanel.TabIndex = 7;
            this.StatPanel.Text = "dwPanel1";
            this.StatPanel.Title = "STATS";
            // 
            // OptionalItemPanel
            // 
            this.OptionalItemPanel.BackColor = System.Drawing.Color.Black;
            this.OptionalItemPanel.Controls.Add(this.OptionalItemFlowPanel);
            this.OptionalItemPanel.Location = new System.Drawing.Point(12, 244);
            this.OptionalItemPanel.MinimumSize = new System.Drawing.Size(40, 58);
            this.OptionalItemPanel.Name = "OptionalItemPanel";
            this.OptionalItemPanel.Size = new System.Drawing.Size(194, 85);
            this.OptionalItemPanel.TabIndex = 8;
            this.OptionalItemPanel.Title = "";
            // 
            // BattlePanel
            // 
            this.BattlePanel.BackColor = System.Drawing.Color.Black;
            this.BattlePanel.Controls.Add(this.BattleItemFlowPanel);
            this.BattlePanel.Location = new System.Drawing.Point(12, 416);
            this.BattlePanel.MinimumSize = new System.Drawing.Size(107, 58);
            this.BattlePanel.Name = "BattlePanel";
            this.BattlePanel.Size = new System.Drawing.Size(375, 83);
            this.BattlePanel.TabIndex = 9;
            this.BattlePanel.Title = "BATTLE";
            // 
            // QuestPanel
            // 
            this.QuestPanel.BackColor = System.Drawing.Color.Black;
            this.QuestPanel.Controls.Add(this.RequiredItemFlowPanel);
            this.QuestPanel.Location = new System.Drawing.Point(12, 331);
            this.QuestPanel.MinimumSize = new System.Drawing.Size(102, 58);
            this.QuestPanel.Name = "QuestPanel";
            this.QuestPanel.Size = new System.Drawing.Size(375, 83);
            this.QuestPanel.TabIndex = 10;
            this.QuestPanel.Title = "QUEST";
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(399, 24);
            this.MainMenuStrip.TabIndex = 11;
            this.MainMenuStrip.Text = "menuStrip1";
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
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.connectToolStripMenuItem.Text = "Connect...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMenuToolStripMenuItem,
            this.showStatusToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EmulatorStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 512);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(399, 22);
            this.StatusStrip.TabIndex = 12;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // EmulatorStatusLabel
            // 
            this.EmulatorStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.EmulatorStatusLabel.Name = "EmulatorStatusLabel";
            this.EmulatorStatusLabel.Size = new System.Drawing.Size(50, 17);
            this.EmulatorStatusLabel.Text = "FCCEUX";
            // 
            // EmulatorConnectionWorker
            // 
            this.EmulatorConnectionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.EmulatorConnectionWorker_DoWork);
            this.EmulatorConnectionWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.EmulatorConnectionWorker_RunWorkerCompleted);
            // 
            // showMenuToolStripMenuItem
            // 
            this.showMenuToolStripMenuItem.Checked = true;
            this.showMenuToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMenuToolStripMenuItem.Name = "showMenuToolStripMenuItem";
            this.showMenuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.showMenuToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.showMenuToolStripMenuItem.Text = "Show Menu";
            // 
            // showStatusToolStripMenuItem
            // 
            this.showStatusToolStripMenuItem.Checked = true;
            this.showStatusToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showStatusToolStripMenuItem.Name = "showStatusToolStripMenuItem";
            this.showStatusToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.showStatusToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.showStatusToolStripMenuItem.Text = "Show Status";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(399, 534);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.QuestPanel);
            this.Controls.Add(this.BattlePanel);
            this.Controls.Add(this.SpellPanel);
            this.Controls.Add(this.OptionalItemPanel);
            this.Controls.Add(this.StatPanel);
            this.Controls.Add(this.MainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Dragon Warrior Randomizer Auto-Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.StatPanel.ResumeLayout(false);
            this.StatPanel.PerformLayout();
            this.OptionalItemPanel.ResumeLayout(false);
            this.OptionalItemPanel.PerformLayout();
            this.BattlePanel.ResumeLayout(false);
            this.BattlePanel.PerformLayout();
            this.QuestPanel.ResumeLayout(false);
            this.QuestPanel.PerformLayout();
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
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
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel EmulatorStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker EmulatorConnectionWorker;
        private System.Windows.Forms.ToolStripMenuItem showMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStatusToolStripMenuItem;
    }
}

