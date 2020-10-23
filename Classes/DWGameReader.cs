using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes
{
    class DWGameReader
    {
        const int PROCESS_VM_READ = 0x0010;
        const int FCEUX_OFFSET = 0x3B1388;
        private Process process;
        private IntPtr processHandle;
        private int nesPointer;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess,
          int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public DWGameReader()
        {

        }

        public void Init()
        {
            // get the process
            process = Process.GetProcessesByName("fceux")[0];
            processHandle = OpenProcess(PROCESS_VM_READ, false, process.Id);
            Console.Out.WriteLine(process.MainWindowTitle);

            // get pointer to nes game RAM
            int bytesRead = 0;
            byte[] bytes = new byte[4];
            ReadProcessMemory((int)processHandle, (int)(process.MainModule.BaseAddress + FCEUX_OFFSET),
                bytes, bytes.Length, ref bytesRead);
            nesPointer = BitConverter.ToInt32(bytes, 0);
        }

        public int GetInt(int offset, int size = 1)
        {
            byte[] bytes = new byte[size];
            int bytesRead = 0;
            ReadProcessMemory((int)processHandle, (int)(nesPointer + offset), bytes, bytes.Length, ref bytesRead);

            switch (size)
            {
                case 1:
                    return (int)bytes[0];
                case 2:
                    return BitConverter.ToInt16(bytes, 0);
                case 4:
                    return BitConverter.ToInt32(bytes, 0);
                default:
                    return -1;
            }
        }
    }
}
