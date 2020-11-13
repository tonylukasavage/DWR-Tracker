using System;

namespace DWR_Tracker.Classes
{
    public class DWStat
    {
        public string Name;
        public int Value = 0;
        public int Offset;
        private int bits;

        public event EventHandler ValueChanged;

        public DWStat(string name, int offset, int _bits = 8)
        {
            Name = name;
            Value = 0;
            Offset = offset;
            bits = _bits;
        }

        public virtual void Update(bool force = false)
        {
            int value = ReadValue();
            if (value != Value || force)
            {
                Value = value;
                OnValueChanged();
            }
        }

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            handler?.Invoke(this, new EventArgs());
        }

        protected virtual int ReadValue()
        {
            switch(bits)
            {
                case 8:
                    return DWGlobals.ProcessReader.ReadByte(Offset);
                case 16:
                    return DWGlobals.ProcessReader.ReadInt16(Offset);
                default:
                    return -1;
            }
        }
    }
}
