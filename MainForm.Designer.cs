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
            this.EquipmentFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ArmorPictureBox = new System.Windows.Forms.PictureBox();
            this.EquipmentFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArmorPictureBox)).BeginInit();
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
            // EquipmentFlowPanel
            // 
            this.EquipmentFlowPanel.Controls.Add(this.ArmorPictureBox);
            this.EquipmentFlowPanel.Location = new System.Drawing.Point(238, 298);
            this.EquipmentFlowPanel.Name = "EquipmentFlowPanel";
            this.EquipmentFlowPanel.Size = new System.Drawing.Size(257, 202);
            this.EquipmentFlowPanel.TabIndex = 3;
            // 
            // ArmorPictureBox
            // 
            this.ArmorPictureBox.Location = new System.Drawing.Point(3, 3);
            this.ArmorPictureBox.Name = "ArmorPictureBox";
            this.ArmorPictureBox.Size = new System.Drawing.Size(97, 99);
            this.ArmorPictureBox.TabIndex = 0;
            this.ArmorPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(566, 565);
            this.Controls.Add(this.EquipmentFlowPanel);
            this.Controls.Add(this.StatTableLayout);
            this.Controls.Add(this.SpellFlowPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.EquipmentFlowPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArmorPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel SpellFlowPanel;
        private System.Windows.Forms.TableLayoutPanel StatTableLayout;
        private System.Windows.Forms.FlowLayoutPanel EquipmentFlowPanel;
        private System.Windows.Forms.PictureBox ArmorPictureBox;
    }
}

