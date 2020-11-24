using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DWR_Tracker.Controls
{
    public partial class DWTimer : UserControl
    {
        public DWTimerState state = DWTimerState.Stopped;
        private Stopwatch Stopwatch = new Stopwatch();
        private delegate void SafeCallDelegate();

        public DWTimer()
        {
            InitializeComponent();
            TimeLabel.ForeColor = Color.FromArgb(60, 60, 60);
        }

        private void TimeLabel_Resize(object sender, EventArgs e)
        {
            TimeLabel.FitText(Stopwatch.Elapsed.ToString().Substring(0, 8), 999);
        }

        public void StartTimer()
        {
            state = DWTimerState.Running;
            TimeLabel.ForeColor = Color.FromArgb(255, 255, 255);
            Stopwatch.Start();
        }

        public void StopTimer()
        {
            state = DWTimerState.Stopped;
            TimeLabel.ForeColor = Color.FromArgb(60, 60, 60);
            Stopwatch.Stop();
        }

        public void ResetTimer()
        {
            state = DWTimerState.Stopped;
            TimeLabel.ForeColor = Color.FromArgb(60, 60, 60);
            Stopwatch.Reset();
        }

        public void UpdateTimeLabel()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (TimeLabel.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateUI);
                TimeLabel.Invoke(d, new object[] { });
            }
            else
            {
                TimeLabel.FitText(Stopwatch.Elapsed.ToString().Substring(0, 8), 999);
            }
        }
    }

    public enum DWTimerState
    {
        Stopped,
        Running
    }
}
