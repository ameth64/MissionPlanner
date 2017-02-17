using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using log4net;
using System.Reflection;
using System.IO;
using MissionPlanner.Utilities;

namespace MissionPlanner.Log
{
    public partial class PosDownLoadCurrent : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        SerialStatus status = SerialStatus.Connecting;
        bool closed;
        string logfile = "";
        uint receivedbytes; // current log file
        uint tallyBytes; // previous downloaded logs
        uint totalBytes; // total expected
        enum SerialStatus
        {
            Connecting,
            Createfile,
            Closefile,
            Reading,
            Waiting,
            Done
        }
        public PosDownLoadCurrent()
        {
            InitializeComponent();
        }

        void RunOnUIThread(Action a)
        {
            if (closed || this.IsDisposed)
            {
                return;
            }
            this.BeginInvoke(new Action(() =>
            {
                try
                {
                    a();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(LogStrings.UnhandledException + e.ToString());
                }
            }));
        }

        private void UpdateProgress(uint min, uint max, uint current)
        {
            RunOnUIThread(() =>
            {
                progressBar1.Minimum = (int)min;
                progressBar1.Maximum = (int)max;
                progressBar1.Value = (int)current;
                progressBar1.Visible = (current < max);
                
                if (current < max)
                {
                    labelBytes.Text = current.ToString();
                }
                else
                {
                    labelBytes.Text = "";
                }
            });

        }

        void comPort_Progress(int progress, string status)
        {
            receivedbytes = (uint)progress;

            if (status == "")
                status = "0";

            UpdateProgress(0, 100, uint.Parse(status));
        }

        private string MakeValidFileName(string fileName)
        {
            return fileName.Replace('/', '-').Replace('\\', '-').Replace(':', '-').Replace('?', ' ').Replace('"', '\'').Replace('<', '[').Replace('>', ']').Replace('|', ' ');
        }

        public void Pos_DownLoad_Thread()
        {
            System.Threading.Thread t11 = new System.Threading.Thread(delegate () { StartDownLoadPosCurrent(); });
            t11.Name = "PoS download single thread";
            t11.Start();
        }

        public void StartDownLoadPosCurrent()
        {
            //log.Info("GetPos " + no);

            MainV2.comPort.Progress += comPort_Progress;

            status = SerialStatus.Reading;

            // used for log fn
            MAVLink.MAVLinkMessage hbpacket = MainV2.comPort.getHeartBeat();

            if (hbpacket != null)
                log.Info("Got hbpacket length: " + hbpacket.Length);

            // get df log from mav
            using (var ms = MainV2.comPort.GetPos(0))
            {
                if (ms != null)
                    log.Info("Got pos length: " + ms.Length);

                ms.Seek(0, SeekOrigin.Begin);

                status = SerialStatus.Done;

                MAVLink.mavlink_heartbeat_t hb = (MAVLink.mavlink_heartbeat_t)MainV2.comPort.DebugPacket(hbpacket);

                logfile = Settings.Instance.LogDir + Path.DirectorySeparatorChar
                          + MainV2.comPort.MAV.aptype.ToString() + Path.DirectorySeparatorChar
                          + hbpacket.sysid + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pos.bin";

                // make log dir
                Directory.CreateDirectory(Path.GetDirectoryName(logfile));

                log.Info("about to write: " + logfile);
                // save memorystream to file
                using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(logfile)))
                {
                    byte[] buffer = new byte[256 * 1024];
                    while (ms.Position < ms.Length)
                    {
                        int read = ms.Read(buffer, 0, buffer.Length);
                        bw.Write(buffer, 0, read);
                    }
                }
            }

            log.Info("about to convertbin: " + logfile);

            // create ascii log
            BinaryLog.ConvertBin(logfile, logfile + ".txt");

            //update the new filename
            logfile = logfile + ".txt";

            // rename file if needed
            log.Info("about to GetFirstGpsTime: " + logfile);
            // get gps time of assci log
            DateTime logtime = new DFLog().GetFirstGpsTime(logfile);
            string newlogfilename = "";
            // rename log is we have a valid gps time
            if (logtime != DateTime.MinValue)
            {
                 newlogfilename = Settings.Instance.LogDir + Path.DirectorySeparatorChar
                                        + MainV2.comPort.MAV.aptype.ToString() + Path.DirectorySeparatorChar
                                        + hbpacket.sysid + Path.DirectorySeparatorChar +
                                        logtime.ToString("-yyyy-MM-dd-HH-mm-ss") + ".txt";
                try
                {
                    File.Move(logfile, newlogfilename);
                    // rename bin as well
                    File.Move(logfile.Replace(".txt", ""), newlogfilename.Replace(".txt", ".bin"));
                    logfile = newlogfilename;
                }
                catch
                {
                    CustomMessageBox.Show(Strings.ErrorRenameFile + " " + logfile + "\nto " + newlogfilename,
                        Strings.ERROR);
                }
            }

            MainV2.comPort.Progress -= comPort_Progress;
            MainV2.instance.posdownlaoding = false;
            if(newlogfilename!="")
                System.Diagnostics.Process.Start("notepad.exe", newlogfilename);
            else
                System.Diagnostics.Process.Start("notepad.exe", logfile);

            status = SerialStatus.Done;
            Close();
            //return logfile;
        }

        protected override void OnClosed(EventArgs e)
        {
            this.closed = true;
            MainV2.comPort.Progress -= comPort_Progress;
            MainV2.instance.posdownlaoding = false;
            base.OnClosed(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (status == SerialStatus.Reading)
            {
                if (CustomMessageBox.Show(LogStrings.CancelDownload, "取消下载", MessageBoxButtons.YesNo) ==
                    System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                MainV2.instance.posdownlaoding = false;
            }

            base.OnClosing(e);
        }
    }
}
