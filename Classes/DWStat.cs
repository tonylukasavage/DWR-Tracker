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
        public DWStatLabel Label;
        private delegate void SafeCallDelegate(string text);

        public DWStat(string name, int offset)
        {
            Name = name;
            Value = 0;
            Offset = offset;
        }

        public void UpdateLabel(bool force = false)
        {
            if (Label == default(DWStatLabel)) { return; }

            int value;
            if (Name == "nxt")
            {
                int currentLevel = DWGlobals.Stats[0].Value;

                // At the end of the game your level gets set to 255
                if (currentLevel == 255) { return; }

                // TODO: make this less brittle
                value = DWGlobals.LevelNexts[DWGlobals.Stats[0].Value];
            }
            else
            {
                value = DWGlobals.ProcessReader.ReadByte(Offset);
            }

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
