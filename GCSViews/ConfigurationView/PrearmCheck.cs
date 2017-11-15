using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class PrearmCheck : Form
    {
        Timer time;
        string compass, airspeed;
        public PrearmCheck()
        {
            InitializeComponent();
            compass = CHK_compass.Text;
            airspeed = CHK_airspeed.Text;
        }

        public void Prearmcheckload(bool[] check)
        {
            
            CHK_servo.Checked = check[0];
            this.CHK_servo.CheckedChanged += new System.EventHandler(this.CHK_CheckedChanged);
            CHK_compass.Checked = check[1];
            this.CHK_compass.CheckedChanged += new System.EventHandler(this.CHK_CheckedChanged);
            CHK_airspeed.Checked = check[2];
            this.CHK_airspeed.CheckedChanged += new System.EventHandler(this.CHK_CheckedChanged);
            CHK_cam.Checked = check[3];
            this.CHK_cam.CheckedChanged += new System.EventHandler(this.CHK_CheckedChanged);
            CHK_rotoridle.Checked = check[4];
            this.CHK_rotoridle.CheckedChanged += new System.EventHandler(this.CHK_CheckedChanged);
            CHK_rcinput.Checked = check[5];
            this.CHK_rcinput.CheckedChanged += new System.EventHandler(this.CHK_CheckedChanged);
        }

        private void BTN_Camera_Click(object sender, EventArgs e)
        {
            try
            {
                MainV2.comPort.setDigicamControl(true);
            }
            catch
            {
                CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
            }
        }

        private void my_show(object sender, EventArgs e)
        {
            time = new Timer();
            time.Tick += new System.EventHandler(this.timer1_Tick);
            time.Interval = 100;

            time.Start();
            btn_logspace.BackColor = Color.White;
            BTN_Camera.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CurrentState cs = MainV2.comPort.MAV.cs;
            string s;
            s = CHK_compass.Text;
            CHK_compass.Text = compass + ":" + cs.yaw.ToString("0");
            CHK_airspeed.Text = airspeed + ":" + cs.airspeed.ToString("0");
        }

        private void PrearmCheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            time.Stop();
        }


        private void btn_logspace_Click(object sender, EventArgs e)
        {
            List<MAVLink.mavlink_log_entry_t> logEntries;
            if (MainV2.comPort.BaseStream.IsOpen)
            {
                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    try
                    {
                        btn_logspace.Text = "计算剩余空间时间稍长请等待";
                        btn_logspace.BackColor = Color.Brown;
                        btn_logspace.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        // AppendSerialLog(LogStrings.UnhandledException + ex.ToString());
                    }

                });
                logEntries = MainV2.comPort.GetLogList();
            }
            else
            {
                MessageBox.Show("必须先连接飞控", "错误");
                return;
            }

            ulong logspace = 0;
            for(int i=0;i<logEntries.Count;i++)
            {
                logspace += logEntries[i].size/1024/1024;
            }
            btn_logspace.Text = logspace.ToString() + "MB";

            if(8000 - logspace > 1000)
            {
                MessageBox.Show("飞控存储空间已用" + ((float)((float)logspace / 8000) * 100).ToString("0.0")+"%");
            }
            else
            {
                MessageBox.Show("飞控存储空间已用" + ((float)((float)logspace / 8000) * 100).ToString("0.0") + "%必须清除无用数据否则无法记录pos信息","警告！");
            }

        }

        private void CHK_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            switch (chk.Name)
            {
                case "CHK_servo":
                    MainV2.instance.HsdevInterface.prearmcheck[0] = CHK_servo.Checked;
                    break;
                case "CHK_compass":
                    MainV2.instance.HsdevInterface.prearmcheck[1] = CHK_compass.Checked;
                    break;
                case "CHK_airspeed":
                    MainV2.instance.HsdevInterface.prearmcheck[2] = CHK_airspeed.Checked;
                    break;
                case "CHK_cam":
                    MainV2.instance.HsdevInterface.prearmcheck[3] = CHK_cam.Checked;
                    break;
                case "CHK_rotoridle":
                    MainV2.instance.HsdevInterface.prearmcheck[4] = CHK_rotoridle.Checked;
                    break;
                case "CHK_rcinput":
                    MainV2.instance.HsdevInterface.prearmcheck[5] = CHK_rcinput.Checked;
                    break;
            }
            
        }
    }
}
