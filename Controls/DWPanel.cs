using DWR_Tracker.Classes;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DWR_Tracker.Controls
{
    public partial class DWPanel : Panel
    {
        private string title = "Title";

        [Category("DW Properties")]
        [Description("Title of the DWPanel")]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                TitleLabel.Text = title;
                Invalidate();
            }
        }

        public DWPanel()
        {
            InitializeComponent();
            Controls.Add(TitleLabel);
            TitleLabel.Font = new Font(DWGlobals.DWFont.GetFamily(), 12);
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            MinimumSize = Size.Add(TitleLabel.Size, new Size(40, 40));
            GraphicsPath path = RoundedRect(new Rectangle(6, 6, Width - 12, Height - 12), 8);
            Pen pen = new Pen(Color.FromArgb(255, 255, 255), 4);
            pe.Graphics.DrawPath(pen, path);

            TitleLabel.Left = Size.Width / 2 - TitleLabel.Size.Width / 2;
        }

        public GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
