using Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmTimer : Form
    {
        public frmTimer()
        {
            InitializeComponent();
        }
        enum enTimerStatus { Closed = 0 , Stopped = 1 , Continued = 2 };
        enTimerStatus _TimerStatus = enTimerStatus.Closed;
        TimeSpan _TimeToCount = new TimeSpan();
        TimeSpan _TimeCounted = TimeSpan.Zero;

        void _LoadTasks()
        {
            DataTable dt = clsTask.ListTasks();
            
            foreach (DataRow dr in dt.Rows)
            {
                cbTasks.Items.Add(dr["TaskName"]);
            }
        }

        private void frmTimer_Load(object sender, EventArgs e)
        {
            _LoadTasks();
        }

        TimeSpan _GetTimeToCount()
        {
            if (nudHours.Value + nudMinutes.Value > 0)
            {
                return new TimeSpan((int)nudHours.Value, (int)nudMinutes.Value, 0);
            }
            else return TimeSpan.Zero;
        }

        void _BeginCount()
        {
            _TimerStatus = enTimerStatus.Continued;
            btnStopOrContinue.Text = "Stop";
            btnStopOrContinue.Visible=true;
            nudHours.Enabled = false;
            nudMinutes.Enabled = false;
            cbTasks.Enabled = false;
            btnStart.Enabled = false;
            pbTimePercentage.Visible = true;
            lblReamingTime.Visible = true;
            pbTimePercentage.Value = 100;
            lblReamingTime.Text = _TimeToCount.ToString(@"hh\:mm\:ss");
            timer1.Start();
        }

        void _SendAlarm()
        {
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.BalloonTipText = _TimeToCount.ToString(@"hh\:mm\:ss") + "end";
            notifyIcon1.ShowBalloonTip(5000);
        }

        void _EndCount()
        {
            _SendAlarm();
            _TimerStatus = enTimerStatus.Closed;
            btnStopOrContinue.Visible = false;
            timer1.Stop();
            nudHours.Enabled = true;
            nudMinutes.Enabled = true;
            cbTasks.Enabled = true;
            btnStart.Enabled = true;
            pbTimePercentage.Visible = false;
            lblReamingTime.Visible = false;
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            if(cbTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Choose task to set time on");
                return;
            }
            _TimeToCount = _GetTimeToCount();
            if(_TimeToCount == TimeSpan.Zero)
            {
                MessageBox.Show("Enter the time you want to set timer on");
                return;
            }

            else
            {
                _BeginCount();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _TimeCounted = _TimeCounted.Add(new TimeSpan(0,0,1));
            float Percentage = (float)(_TimeCounted.TotalSeconds / _TimeToCount.TotalSeconds);
            pbTimePercentage.Value = 100 - (int)(Percentage * 100);
            lblReamingTime.Text = (_TimeToCount - _TimeCounted).ToString(@"hh\:mm\:ss");

            if (_TimeToCount == _TimeCounted) _EndCount();
        }

        

        private void btnStopOrContinue_Click(object sender, EventArgs e)
        {
            btnStopOrContinue.Text = (_TimerStatus == enTimerStatus.Stopped) ? "Continue" : "Stop";
            bool IsTimerStopped = (_TimerStatus != enTimerStatus.Stopped);
            timer1.Enabled = IsTimerStopped;
            _TimerStatus = (_TimerStatus ==enTimerStatus.Stopped) ? enTimerStatus.Continued:enTimerStatus.Stopped;
        }
    }
}
