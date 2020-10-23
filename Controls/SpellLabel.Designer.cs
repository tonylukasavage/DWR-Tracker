namespace DWR_Tracker.Controls
{
    partial class SpellLabel
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SpellLabel
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ForeColor = System.Drawing.Color.White;
            this.Click += new System.EventHandler(this.SpellLabel_Click);
            this.MouseEnter += new System.EventHandler(this.SpellLabel_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SpellLabel_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
