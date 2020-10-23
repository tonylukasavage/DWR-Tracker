using DWR_Tracker.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes
{
    class DWStat
    {
        public string Name;
        public int Value;
        public int Offset;
        public StatLabel Label;
        private delegate void SafeCallDelegate(string text);

        public DWStat(string name, int offset)
        {
            Name = name;
            Value = 0;
            Offset = offset;
        }

        public void UpdateLabel(bool force = false)
        {
            if (Label == default(StatLabel)) { return; }

            DWGameReader dwReader = DWGlobals.DWGameReader;
            int value = dwReader.GetInt(Offset, 1);

            if (value != Value || force)
            {
                UpdateText(value.ToString());
            }
            Value = value;
        }

        private void UpdateText(string text)
        {
            if (Label.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateText);
                Label.Invoke(d, new object[] { text });
            }
            else
            {
                Label.Text = text;
            }
        }
    }
}
