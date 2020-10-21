using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace DWR_Tracker
{
    public partial class Form1 : Form
    {
        const int PROCESS_VM_READ = 0x0010;
        const int FCEUX_OFFSET = 0x3B1388;
        private Process process;
        private IntPtr processHandle;
        private int nesPointer;

        private delegate void SafeCallDelegate(string text);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess,
          int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // load DW font
            PrivateFontCollection private_fonts = new PrivateFontCollection();
            string resource = "DWR_Tracker.Dragon Warrior (NES).ttf";
            // receive resource stream
            Stream fontStream = this.GetType().Assembly.GetManifestResourceStream(resource);

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);

            // create a buffer to read in to
            byte[] fontdata = new byte[fontStream.Length];

            // read the font data from the resource
            fontStream.Read(fontdata, 0, (int)fontStream.Length);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);

            // pass the font to the font collection
            private_fonts.AddMemoryFont(data, (int)fontStream.Length);

            // close the resource stream
            fontStream.Close();

            // free up the unsafe memory
            Marshal.FreeCoTaskMem(data);


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

            // write the current HP
            int hp = GetBytes(0xC5, 1);
            Console.Out.WriteLine("HP: " + hp.ToString());

            label1.Font = new Font(private_fonts.Families[0], 48);

            // 1/2 second timer
            System.Timers.Timer timer = new System.Timers.Timer(500);
            timer.Elapsed += OnTick;
            timer.Start();
        }

        private int GetBytes(int offset, int size)
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

        private int ctr = 0;

        private void UpdateText(string text)
        {
            if (label1.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateText);
                label1.Invoke(d, new object[] { text });
            }
            else
            {
                label1.Text = text;
            }
        }

        private void OnTick(object source, ElapsedEventArgs e)
        {
            UpdateText(ctr++.ToString());
        }


    }
}
