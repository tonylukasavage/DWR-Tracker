using System;
using System.Windows.Forms;

namespace DWR_Tracker
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MainForm());
        }
    }

    public static class ControlExtensions
    {
        public static void Invoke(this Control Control, Action Action)
        {
            Control.Invoke(Action);
        }
    }
}
