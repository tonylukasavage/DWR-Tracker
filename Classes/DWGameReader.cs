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
        // const int MESEN_OFFSET = 0x042E0F30;
        // const int MESEN_OFFSET = 0x42E0EE8;
        private Process process;
        private IntPtr processHandle;
        private Int64 nesPointer;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, 
            bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess,
          Int64 lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public DWGameReader()
        {

        }

        public void Init()
        {
            // Attempt to automatically find DWR 


            // get the process
            process = Process.GetProcessesByName("fceux")[0];
            processHandle = OpenProcess(PROCESS_VM_READ, false, process.Id);
            Console.Out.WriteLine(process.MainWindowTitle);

            // get pointer to nes game RAM
            nesPointer = GetFceuxBasePointer();
            // nesPointer = GetMesenBasePointer();
            Console.WriteLine(nesPointer.ToString());
        }

        public int GetInt(int offset, int size = 1)
        {
            byte[] bytes = new byte[size];
            int bytesRead = 0;
            ReadProcessMemory((int)processHandle, nesPointer + offset, bytes, bytes.Length, ref bytesRead);

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

        public string GetString(int offset, int size = 1)
        {
            byte[] bytes = new byte[size];
            int bytesRead = 0;
            ReadProcessMemory((int)processHandle, nesPointer + offset, bytes, bytes.Length, ref bytesRead);
            return Encoding.UTF8.GetString(bytes, offset, bytesRead);
        }

        private int GetFceuxBasePointer()
        {
            int bytesRead = 0;
            byte[] bytes = new byte[4];
            ReadProcessMemory((int)processHandle, (int)(process.MainModule.BaseAddress + FCEUX_OFFSET),
                bytes, bytes.Length, ref bytesRead);
            return BitConverter.ToInt32(bytes, 0);
        }

        private Int64 GetMesenBasePointer()
        {
            // Find the MesenCore.dll module
            IEnumerable<ProcessModule> dlls = process.Modules.Cast<ProcessModule>();
            IEnumerable<ProcessModule> targets = dlls.Where(m => {
                return m.FileName.Contains("MesenCore.dll");
            });
            ProcessModule dll = targets.First();
            if (dll == default(ProcessModule))
            {
                Console.WriteLine("ERROR: couldn't find MesenCore.dll");
            }

            // Start at base address and traverse pointer offsets til we get to the
            // NES RAM base address
            Int64 baseOffset = dll.BaseAddress.ToInt64();
            Int64[] offsets = new Int64[5] { 0x042E0F30, 0, 0x58, 0xC90, 0x58 };
            // Int64[] offsets = new Int64[5] { 0, MESEN_OFFSET, 0x118, 0, 0xB8, 0x58 };
            int bytesRead = 0;
            byte[] bytes = new byte[8];

            Console.WriteLine("baseOffset: {0:X}", baseOffset);
            foreach (Int64 offset in offsets)
            {
                // Console.WriteLine("new offset: {0:X}", baseOffset + offset);
                ReadProcessMemory((int)processHandle, baseOffset + offset,
                    bytes, bytes.Length, ref bytesRead);
                baseOffset = BitConverter.ToInt64(bytes, 0);
                Console.WriteLine("baseOffset: {0:X}", baseOffset);
            }

            return baseOffset;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
