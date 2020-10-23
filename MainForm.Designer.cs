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
            this.SpellFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.StatTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // SpellFlowPanel
            // 
            this.SpellFlowPanel.Location = new System.Drawing.Point(0, 12);
            this.SpellFlowPanel.Name = "SpellFlowPanel";
            this.SpellFlowPanel.Size = new System.Drawing.Size(183, 378);
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
            this.StatTableLayout.Size = new System.Drawing.Size(134, 224);
            this.StatTableLayout.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(221, 293);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 211);
            this.panel1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(566, 565);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StatTableLayout);
            this.Controls.Add(this.SpellFlowPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel SpellFlowPanel;
        private System.Windows.Forms.TableLayoutPanel StatTableLayout;
        private System.Windows.Forms.Panel panel1;
    }
}

