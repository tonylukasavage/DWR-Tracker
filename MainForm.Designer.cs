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
            this.StatPanel.SuspendLayout();
            this.OptionalItemPanel.SuspendLayout();
            this.BattlePanel.SuspendLayout();
            this.QuestPanel.SuspendLayout();
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
            this.BattleItemFlowPanel.Location = new System.Drawing.Point(19, 14);
            this.BattleItemFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BattleItemFlowPanel.Name = "BattleItemFlowPanel";
            this.BattleItemFlowPanel.Size = new System.Drawing.Size(347, 60);
            this.BattleItemFlowPanel.TabIndex = 3;
            // 
            // RequiredItemFlowPanel
            // 
            this.RequiredItemFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.RequiredItemFlowPanel.Location = new System.Drawing.Point(19, 16);
            this.RequiredItemFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RequiredItemFlowPanel.Name = "RequiredItemFlowPanel";
            this.RequiredItemFlowPanel.Size = new System.Drawing.Size(347, 61);
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
            this.SpellPanel.Location = new System.Drawing.Point(212, 12);
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
            this.StatPanel.Location = new System.Drawing.Point(12, 12);
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
            this.OptionalItemPanel.Location = new System.Drawing.Point(12, 222);
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
            this.BattlePanel.Location = new System.Drawing.Point(12, 394);
            this.BattlePanel.MinimumSize = new System.Drawing.Size(107, 58);
            this.BattlePanel.Name = "BattlePanel";
            this.BattlePanel.Size = new System.Drawing.Size(375, 83);
            this.BattlePanel.TabIndex = 9;
            this.BattlePanel.Title = "BATTLE";
            this.BattlePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BattlePanel_Paint);
            // 
            // QuestPanel
            // 
            this.QuestPanel.BackColor = System.Drawing.Color.Black;
            this.QuestPanel.Controls.Add(this.RequiredItemFlowPanel);
            this.QuestPanel.Location = new System.Drawing.Point(12, 309);
            this.QuestPanel.MinimumSize = new System.Drawing.Size(102, 58);
            this.QuestPanel.Name = "QuestPanel";
            this.QuestPanel.Size = new System.Drawing.Size(375, 83);
            this.QuestPanel.TabIndex = 10;
            this.QuestPanel.Title = "QUEST";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(399, 484);
            this.Controls.Add(this.QuestPanel);
            this.Controls.Add(this.BattlePanel);
            this.Controls.Add(this.SpellPanel);
            this.Controls.Add(this.OptionalItemPanel);
            this.Controls.Add(this.StatPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.ResumeLayout(false);

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
    }
}

