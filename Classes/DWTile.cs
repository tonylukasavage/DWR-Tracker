using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes
{
    public class DWTile
    {
        public string Name;
        public string ImagePath;
        public Image Image;

        public DWTile(string name, string imageName)
        {
            Name = name;

            if (imageName != "")
            {
                ImagePath = "DWR_Tracker.Images.Tiles." + imageName;
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                Stream myStream = myAssembly.GetManifestResourceStream(ImagePath);
                Image = new Bitmap(Image.FromStream(myStream), new Size(16, 16));
            }
        }
    }
}
