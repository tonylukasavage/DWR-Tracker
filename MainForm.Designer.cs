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
            this.SpellFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.StatTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.BattleItemFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.RequiredItemFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OptionalItemFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dwPanel1 = new DWR_Tracker.Controls.DWPanel();
            this.SuspendLayout();
            // 
            // SpellFlowPanel
            // 
            this.SpellFlowPanel.Location = new System.Drawing.Point(12, 12);
            this.SpellFlowPanel.Name = "SpellFlowPanel";
            this.SpellFlowPanel.Size = new System.Drawing.Size(171, 266);
            this.SpellFlowPanel.TabIndex = 1;
            // 
            // StatTableLayout
            // 
            this.StatTableLayout.ColumnCount = 2;
            this.StatTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.StatTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.StatTableLayout.Location = new System.Drawing.Point(204, 12);
            this.StatTableLayout.Name = "StatTableLayout";
            this.StatTableLayout.RowCount = 7;
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43299F));
            this.StatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.40206F));
            this.StatTableLayout.Size = new System.Drawing.Size(134, 266);
            this.StatTableLayout.TabIndex = 2;
            // 
            // BattleItemFlowPanel
            // 
            this.BattleItemFlowPanel.Location = new System.Drawing.Point(359, 12);
            this.BattleItemFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BattleItemFlowPanel.Name = "BattleItemFlowPanel";
            this.BattleItemFlowPanel.Size = new System.Drawing.Size(372, 72);
            this.BattleItemFlowPanel.TabIndex = 3;
            // 
            // RequiredItemFlowPanel
            // 
            this.RequiredItemFlowPanel.Location = new System.Drawing.Point(359, 84);
            this.RequiredItemFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RequiredItemFlowPanel.Name = "RequiredItemFlowPanel";
            this.RequiredItemFlowPanel.Size = new System.Drawing.Size(370, 71);
            this.RequiredItemFlowPanel.TabIndex = 4;
            // 
            // OptionalItemFlowPanel
            // 
            this.OptionalItemFlowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OptionalItemFlowPanel.Location = new System.Drawing.Point(359, 155);
            this.OptionalItemFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OptionalItemFlowPanel.Name = "OptionalItemFlowPanel";
            this.OptionalItemFlowPanel.Size = new System.Drawing.Size(370, 133);
            this.OptionalItemFlowPanel.TabIndex = 5;
            // 
            // dwPanel1
            // 
            this.dwPanel1.Location = new System.Drawing.Point(107, 358);
            this.dwPanel1.Name = "dwPanel1";
            this.dwPanel1.Size = new System.Drawing.Size(257, 111);
            this.dwPanel1.TabIndex = 6;
            this.dwPanel1.Text = "dwPanel1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(738, 565);
            this.Controls.Add(this.dwPanel1);
            this.Controls.Add(this.OptionalItemFlowPanel);
            this.Controls.Add(this.RequiredItemFlowPanel);
            this.Controls.Add(this.BattleItemFlowPanel);
            this.Controls.Add(this.StatTableLayout);
            this.Controls.Add(this.SpellFlowPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Dragon Warrior Randomizer Auto-Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel SpellFlowPanel;
        private System.Windows.Forms.TableLayoutPanel StatTableLayout;
        private System.Windows.Forms.FlowLayoutPanel BattleItemFlowPanel;
        private System.Windows.Forms.FlowLayoutPanel RequiredItemFlowPanel;
        private System.Windows.Forms.FlowLayoutPanel OptionalItemFlowPanel;
        private Controls.DWPanel dwPanel1;
    }
}

