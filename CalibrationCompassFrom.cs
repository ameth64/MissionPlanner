using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;

namespace MissionPlanner
{
    public partial class CalibrationCompassFrom : Form
    {
        private const float rad2deg = (float)(180 / Math.PI);
        private const float deg2rad = (float)(1.0 / rad2deg);
        private const int THRESHOLD_OFS_RED = 600;
        private const int THRESHOLD_OFS_YELLOW = 400;
        private bool startup;

        private enum CompassNumber
        {
            Compass1 = 0,
            Compass2,
            Compass3
        };

        public void Activate()
        {
            if (!MainV2.comPort.BaseStream.IsOpen)
            {
                Enabled = false;
                return;
            }
            Enabled = true;

            startup = true;

            // General Compass Settings

            if (MainV2.comPort.MAV.param["COMPASS_DEC"] != null)
            {
                var dec = MainV2.comPort.MAV.param["COMPASS_DEC"].Value * rad2deg;

                var min = (dec - (int)dec) * 60;

                //TXT_declination_deg.Text = ((int)dec).ToString("0");
                //TXT_declination_min.Text = min.ToString("0");
            }

            if (!MainV2.comPort.MAV.param.ContainsKey("COMPASS_OFS_X"))
            {
                Enabled = false;
                return;
            }

            int offset1_x = (int)MainV2.comPort.MAV.param["COMPASS_OFS_X"];
            int offset1_y = (int)MainV2.comPort.MAV.param["COMPASS_OFS_Y"];
            int offset1_z = (int)MainV2.comPort.MAV.param["COMPASS_OFS_Z"];
            // Turn offsets red if any offset exceeds a threshold, or all values are 0 (not yet calibrated)
            if (absmax(offset1_x, offset1_y, offset1_z) > THRESHOLD_OFS_RED)
                LBL_compass1_offset.ForeColor = Color.Red;
            else if (absmax(offset1_x, offset1_y, offset1_z) > THRESHOLD_OFS_YELLOW)
                LBL_compass1_offset.ForeColor = Color.Yellow;
            else if (offset1_x == 0 && offset1_y == 0 & offset1_z == 0)
                LBL_compass1_offset.ForeColor = Color.Red;
            else
                LBL_compass1_offset.ForeColor = Color.Green;


            LBL_compass1_offset.Text = "OFFSETS  X: " +
                                       offset1_x.ToString() +
                                       ",   Y: " + offset1_y.ToString() +
                                       ",   Z: " + offset1_z.ToString();


            // Compass 2 settings
            if (MainV2.comPort.MAV.param.ContainsKey("COMPASS_EXTERN2"))
            {

                int offset2_x = (int)MainV2.comPort.MAV.param["COMPASS_OFS2_X"];
                int offset2_y = (int)MainV2.comPort.MAV.param["COMPASS_OFS2_Y"];
                int offset2_z = (int)MainV2.comPort.MAV.param["COMPASS_OFS2_Z"];

                if (absmax(offset2_x, offset2_y, offset2_z) > THRESHOLD_OFS_RED)
                    LBL_compass2_offset.ForeColor = Color.Red;
                else if (absmax(offset2_x, offset2_y, offset2_z) > THRESHOLD_OFS_YELLOW)
                    LBL_compass2_offset.ForeColor = Color.Yellow;
                else if (offset2_x == 0 && offset2_y == 0 & offset2_z == 0)
                    LBL_compass2_offset.ForeColor = Color.Red;
                else
                    LBL_compass2_offset.ForeColor = Color.Green;


                LBL_compass2_offset.Text = "OFFSETS  X: " +
                                           offset2_x.ToString() +
                                           ",   Y: " + offset2_y.ToString() +
                                           ",   Z: " + offset2_z.ToString();
            }
            else
            {
                groupBoxCompass2.Hide();
            }

            if (MainV2.comPort.MAV.param.ContainsKey("COMPASS_EXTERN3"))
            {

                int offset3_x = (int)MainV2.comPort.MAV.param["COMPASS_OFS3_X"];
                int offset3_y = (int)MainV2.comPort.MAV.param["COMPASS_OFS3_Y"];
                int offset3_z = (int)MainV2.comPort.MAV.param["COMPASS_OFS3_Z"];

                if (absmax(offset3_x, offset3_y, offset3_z) > THRESHOLD_OFS_RED)
                    LBL_compass3_offset.ForeColor = Color.Red;
                else if (absmax(offset3_x, offset3_y, offset3_z) > THRESHOLD_OFS_YELLOW)
                    LBL_compass3_offset.ForeColor = Color.Yellow;
                else if (offset3_x == 0 && offset3_y == 0 & offset3_z == 0)
                    LBL_compass3_offset.ForeColor = Color.Red;
                else
                    LBL_compass3_offset.ForeColor = Color.Green;


                LBL_compass3_offset.Text = "OFFSETS  X: " +
                                           offset3_x.ToString() +
                                           ",   Y: " + offset3_y.ToString() +
                                           ",   Z: " + offset3_z.ToString();
            }
            else
            {
                groupBoxCompass3.Hide();
            }

            mavlinkComboBoxfitness.setup(ParameterMetaDataRepository.GetParameterOptionsInt("COMPASS_CAL_FIT",
                    MainV2.comPort.MAV.cs.firmware.ToString()), "COMPASS_CAL_FIT", MainV2.comPort.MAV.param);

            //ShowRelevantFields();

            startup = false;
        }

        // Find the maximum absolute value of three values. Used to detect abnormally high or
        // low compass offsets.
        private int absmax(int val1, int val2, int val3)
        {
            return Math.Max(Math.Max(Math.Abs(val1), Math.Abs(val2)), Math.Abs(val3));
        }

        public void Deactivate()
        {
            timer1.Stop();
        }
        public CalibrationCompassFrom()
        {
            InitializeComponent();
        }

        private List<MAVLink.mavlink_mag_cal_progress_t> mprog = new List<MAVLink.mavlink_mag_cal_progress_t>();
        private List<MAVLink.mavlink_mag_cal_report_t> mrep = new List<MAVLink.mavlink_mag_cal_report_t>();

        private bool ReceviedPacket(MAVLink.MAVLinkMessage packet)
        {
            if (packet.msgid == (byte)MAVLink.MAVLINK_MSG_ID.MAG_CAL_PROGRESS)
            {
                var mprog = packet.ToStructure<MAVLink.mavlink_mag_cal_progress_t>();

                lock (this.mprog)
                {
                    this.mprog.Add(mprog);
                }

                return true;
            }
            else if (packet.msgid == (byte)MAVLink.MAVLINK_MSG_ID.MAG_CAL_REPORT)
            {
                var mrep = packet.ToStructure<MAVLink.mavlink_mag_cal_report_t>();

                lock (this.mrep)
                {
                    this.mrep.Add(mrep);
                }

                return true;
            }

            return true;
        }

        private KeyValuePair<MAVLink.MAVLINK_MSG_ID, Func<MAVLink.MAVLinkMessage, bool>> packetsub1;
        private KeyValuePair<MAVLink.MAVLINK_MSG_ID, Func<MAVLink.MAVLinkMessage, bool>> packetsub2;

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_obmagresult.Clear();
            int compasscount = 0;
            int completecount = 0;
            lock (mprog)
            {
                // somewhere to save our %
                Dictionary<byte, byte> status = new Dictionary<byte, byte>();
                foreach (var item in mprog)
                {
                    status[item.compass_id] = item.completion_pct;
                }

                // message for user
                string message = "";
                foreach (var item in status)
                {
                    try
                    {
                        if (item.Key == 0)
                            horizontalProgressBar1.Value = item.Value;
                        if (item.Key == 1)
                            horizontalProgressBar2.Value = item.Value;
                        if (item.Key == 2)
                            horizontalProgressBar3.Value = item.Value;
                    }
                    catch { }

                    message += "id:" + item.Key + " " + item.Value.ToString() + "% ";
                    compasscount++;
                }
                lbl_obmagresult.AppendText(message + "\n");
            }

            lock (mrep)
            {
                // somewhere to save our answer
                Dictionary<byte, MAVLink.mavlink_mag_cal_report_t> status = new Dictionary<byte, MAVLink.mavlink_mag_cal_report_t>();
                foreach (var item in mrep)
                {
                    if (item.compass_id == 0 && item.ofs_x == 0)
                        continue;

                    status[item.compass_id] = item;
                }

                // message for user
                foreach (var item in status.Values)
                {
                    lbl_obmagresult.AppendText("id:" + item.compass_id + " x:" + item.ofs_x.ToString("0.0") + " y:" + item.ofs_y.ToString("0.0") + " z:" +
                                             item.ofs_z.ToString("0.0") + " fit:" + item.fitness.ToString("0.0") + " " + (MAVLink.MAG_CAL_STATUS)item.cal_status + "\n");

                    try
                    {
                        if (item.compass_id == 0)
                            horizontalProgressBar1.Value = 100;
                        if (item.compass_id == 1)
                            horizontalProgressBar2.Value = 100;
                        if (item.compass_id == 2)
                            horizontalProgressBar3.Value = 100;
                    }
                    catch { }

                    if ((MAVLink.MAG_CAL_STATUS)item.cal_status != MAVLink.MAG_CAL_STATUS.MAG_CAL_SUCCESS)
                    {
                        //CustomMessageBox.Show(Strings.CommandFailed);
                    }

                    if (item.autosaved == 1)
                    {
                        completecount++;
                        timer1.Interval = 1000;
                    }
                }

                if (compasscount == completecount && compasscount != 0)
                {
                    BUT_OBmagcalcancel.Enabled = false;
                    BUT_OBmagcalaccept.Enabled = false;
                    timer1.Stop();
                    Activate();
                    CustomMessageBox.Show("校准完成，请重启飞控。");
                }
            }
        }


        private void BUT_OBmagcalstart_Click(object sender, EventArgs e)
        {
            try
            {
                MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_START_MAG_CAL, 0, 1, 1, 0, 0, 0, 0);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
                CustomMessageBox.Show("Failed to start MAG CAL, check the autopilot is still responding.\n" + ex.ToString(), Strings.ERROR);
                return;
            }

            mprog.Clear();
            mrep.Clear();
            horizontalProgressBar1.Value = 0;
            horizontalProgressBar2.Value = 0;
            horizontalProgressBar3.Value = 0;

            packetsub1 = MainV2.comPort.SubscribeToPacketType(MAVLink.MAVLINK_MSG_ID.MAG_CAL_PROGRESS, ReceviedPacket);
            packetsub2 = MainV2.comPort.SubscribeToPacketType(MAVLink.MAVLINK_MSG_ID.MAG_CAL_REPORT, ReceviedPacket);

            BUT_OBmagcalaccept.Enabled = true;
            BUT_OBmagcalcancel.Enabled = true;
            timer1.Start();
        }

        private void BUT_OBmagcalaccept_Click(object sender, EventArgs e)
        {
            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_ACCEPT_MAG_CAL, 0, 0, 1, 0, 0, 0, 0);

            MainV2.comPort.UnSubscribeToPacketType(packetsub1);
            MainV2.comPort.UnSubscribeToPacketType(packetsub2);

            timer1.Stop();
        }

        private void BUT_OBmagcalcancel_Click(object sender, EventArgs e)
        {
            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_CANCEL_MAG_CAL, 0, 0, 1, 0, 0, 0, 0);

            MainV2.comPort.UnSubscribeToPacketType(packetsub1);
            MainV2.comPort.UnSubscribeToPacketType(packetsub2);

            timer1.Stop();
        }
    }
}
