using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DWR_Tracker.Classes
{
    class DWProcessReader
    {
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess,
            bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess,
          IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        internal static extern void GetNativeSystemInfo(ref SystemInfo lpSystemInfo);

        [DllImport("kernel32.dll")]
        internal static extern void GetSystemInfo(ref SystemInfo lpSystemInfo);

        [DllImport("kernel32.dll")]
        public static extern bool IsWow64Process(IntPtr hProcess, out bool lpSystemInfo);
        public bool IsWow64Process(Process process)
        {
            bool retVal = false;
            IsWow64Process(process.Handle, out retVal);
            return retVal;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SystemInfo
        {
            public ushort wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public UIntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        }

        internal const int PROCESS_VM_READ = 0x0010;
        internal const ushort ProcessorArchitectureIntel = 0;
        internal const ushort ProcessorArchitectureIa64 = 6;
        internal const ushort ProcessorArchitectureAmd64 = 9;
        internal const ushort ProcessorArchitectureUnknown = 0xFFFF;

        public Process Process;
        public IntPtr ProcessHandle;
        public string Arch;
        public IntPtr BaseOffset = (IntPtr)0;
        public IntPtr SramOffset = (IntPtr)0;
        public IntPtr RomOffset = (IntPtr)0;
        public IntPtr MapOffset = (IntPtr)0;

        public DWProcessReader(Process process)
        {
            // store process 
            Process = process;
            ProcessHandle = OpenProcess(PROCESS_VM_READ, false, Process.Id);

            // get target process architecture
            SystemInfo native = new SystemInfo();
            GetNativeSystemInfo(ref native);
            if (native.wProcessorArchitecture == ProcessorArchitectureIntel)
            {
                Arch = "32";
            } else
            {
                Arch = IsWow64Process(process) ? "32" : "64";
            }
        }

        public IntPtr FindOffset(string dll, string[] strOffsets)
        {
            int[] offsets = new int[strOffsets.Length];
            IntPtr baseOffset;

            // convert string pointers to IntPtr
            for (int i = 0; i < offsets.Length; i++)
            {
                offsets[i] = Convert.ToInt32(strOffsets[i].Substring(2), 16);
            }

            // get initial offset from main process or dll
            if (dll != default(string))
            {
                // Find the dll module
                IEnumerable<ProcessModule> dlls = Process.Modules.Cast<ProcessModule>();
                IEnumerable<ProcessModule> targets = dlls.Where(m => {
                    return m.FileName.Contains(dll);
                });
                ProcessModule dllModule = targets.First();
                if (dllModule == default(ProcessModule))
                {
                    Console.WriteLine("[ERROR] couldn't find " + dll);
                    return (IntPtr)(-1);
                }
                baseOffset = dllModule.BaseAddress;
            }
            else
            {
                baseOffset = Process.MainModule.BaseAddress;
            }

            // traverse the series of offsets to find the final base offset
            int bytesRead = 0;
            int length = Arch == "32" ? 4 : 8;
            byte[] bytes = new byte[length];
            foreach (int offset in offsets)
            {
                ReadProcessMemory(ProcessHandle, IntPtr.Add(baseOffset, offset),
                    bytes, bytes.Length, ref bytesRead);
                baseOffset = (IntPtr)(Arch == "32" ?
                    BitConverter.ToInt32(bytes, 0) :
                    BitConverter.ToInt64(bytes, 0));
            }

            return baseOffset;
        }

        public byte[] Read(int offset, int size, int readType = 0)
        {
            int bytesRead = 0;
            byte[] bytes = new byte[size];
            IntPtr baseOffset = readType == 0 ? BaseOffset : 
                (readType == 1 ? SramOffset : (readType == 2 ? RomOffset : MapOffset));

            if (!ReadProcessMemory(ProcessHandle, IntPtr.Add(baseOffset, offset), bytes,
                bytes.Length, ref bytesRead))
            {
                Console.WriteLine(GetLastError());
            }
            return bytes;
        }

        public byte ReadByte(int offset)
        {
            return Read(offset, 1)[0];
        }

        public short ReadInt16(int offset)
        {
            return BitConverter.ToInt16(Read(offset, 2), 0);
        }

        public int ReadInt32(int offset)
        {
            return BitConverter.ToInt32(Read(offset, 4), 0);
        }

        public long ReadInt64(int offset)
        {
            return BitConverter.ToInt64(Read(offset, 8), 0);
        }

        public string ReadString(int offset, int length)
        {
            byte[] bytes = Read(offset, length);
            return Encoding.UTF8.GetString(bytes, 0, length);
        }
    }
}
