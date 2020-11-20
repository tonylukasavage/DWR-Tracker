using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes
{
    public class DWMap
    {
        public string Name;
        public string ImagePath;

        public DWMap(string name, string imageName)
        {
            Name = name;
            ImagePath = "DWR_Tracker.Images.Maps." + imageName;
        }

        public Image GetImage()
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(ImagePath);
            Bitmap src = new Bitmap(Image.FromStream(myStream)); //, new Size(64, 64));
            return src;
            //Bitmap dst = new Bitmap(128, 128);
            //Graphics g = Graphics.FromImage(dst);
            //g.InterpolationMode = InterpolationMode.NearestNeighbor;
            //g.DrawImage(
            //    src,
            //    new Rectangle(0, 0, 128, 128)
            //);
            //return dst;
        }
    }
}
