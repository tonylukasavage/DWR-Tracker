using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace DWR_Tracker.Classes
{
    class DWFont
    {
        const string resource = "DWR_Tracker.Fonts.Dragon Warrior (NES).ttf";
        private PrivateFontCollection fonts;

        public DWFont()
        {
            fonts = new PrivateFontCollection();
            Stream fontStream = this.GetType().Assembly.GetManifestResourceStream(resource);
            System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);

            byte[] fontdata = new byte[fontStream.Length];
            fontStream.Read(fontdata, 0, (int)fontStream.Length);
            Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
            fonts.AddMemoryFont(data, (int)fontStream.Length);
            fontStream.Close();

            // free up the unsafe memory
            Marshal.FreeCoTaskMem(data);
        }

        public FontFamily GetFamily()
        {
            return fonts.Families[0];
        }
    }
}
