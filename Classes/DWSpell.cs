using System;

namespace DWR_Tracker.Classes
{
    public class DWSpell
    {
        public string Name;
        public int Offset;
        public int Bit;
        public bool HasSpell;

        public event EventHandler ValueChanged;

        public DWSpell(string name, int offset, int bit, bool hasSpell = false)
        {
            Name = name;
            Offset = offset;
            Bit = bit;
            HasSpell = hasSpell;
        }

        public int ReadValue()
        {
            return DWGlobals.ProcessReader.ReadByte(Offset) & Bit;
        }

        public void Update(bool force = false)
        {
            Update(ReadValue(), force);
        }

        public void Update(int value, bool force = false)
        {
            bool hasSpell = value > 0;
            if (HasSpell != hasSpell || force)
            {
                HasSpell = hasSpell;
                OnValueChanged();
            }
        }

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            handler?.Invoke(this, new EventArgs());
        }
    }
}
