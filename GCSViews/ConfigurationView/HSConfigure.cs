using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MissionPlanner.Utilities;
using MissionPlanner.Controls;
using System.Threading;
using MissionPlanner.Comms;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class HSConfigure : MyUserControl,IActivate
    {

        public void Activate()
        {

        }

        private void Resize(object sender, EventArgs e)
        {

        }

        public HSConfigure()
        {
            InitializeComponent();
            redminval.Enabled = false;
            redmaxval.Enabled = false;

            whiteminval.Enabled = false;
            whitemaxval.Enabled = false;

            greenminval.Enabled = false;
            greenmaxval.Enabled = false;

            enablespeech.Enabled = false;
            enableautoonlyspeech.Enabled = false;
            enablecolor.Enabled = false;
            voicecontent.Enabled = false;

            HSdatagridview.Columns.Add("hsdatagrid", "飞行数据");
            HSdatagridview.Columns.Add("hsdatagrid2", "name");
            HSdatagridview.RowsDefaultCellStyle.ForeColor = Color.Black;
            for (int i=0;i<MainV2.instance.HsdevInterface.leftlabels.Count;i++)
            {
                HSdatagridview.Rows.Add(MainV2.instance.HsdevInterface.leftlabels[i].label.Text, 
                    MainV2.instance.HsdevInterface.leftlabels[i].label.Name);
            }
            for (int i = 0; i < MainV2.instance.HsdevInterface.rightlabels.Count; i++)
            {
                HSdatagridview.Rows.Add(MainV2.instance.HsdevInterface.rightlabels[i].label.Text,
                    MainV2.instance.HsdevInterface.rightlabels[i].label.Name);
            }
            HSdatagridview.Columns[1].Visible = false;
            HSdatagridview.Columns[0].ReadOnly = true;

            if (MainV2.comPort.BaseStream.IsOpen)
            {
                BTN_disconnect.Enabled = true;
                BTN_Connect.Enabled = false;
            }
            else
            {
                BTN_disconnect.Enabled = false;
                BTN_Connect.Enabled = true;
            }

            //_connectionControl = toolStripConnectionControl.ConnectionControl;
            _connectionControl.CMB_baudrate.TextChanged += this.CMB_baudrate_TextChanged;
            _connectionControl.CMB_serialport.SelectedIndexChanged += this.CMB_serialport_SelectedIndexChanged;
            _connectionControl.CMB_serialport.Click += this.CMB_serialport_Click;
            // _connectionControl.cmb_sysid.Click += cmb_sysid_Click;
            _connectionControl.cmb_sysid.Visible = false;

           // _connectionControl.ShowLinkStats += (sender, e) => ShowConnectionStatsForm();


        }

        private void CMB_serialport_Click(object sender, EventArgs e)
        {
            string oldport = _connectionControl.CMB_serialport.Text;
            PopulateSerialportList();
            if (_connectionControl.CMB_serialport.Items.Contains(oldport))
                _connectionControl.CMB_serialport.Text = oldport;
        }

        private void PopulateSerialportList()
        {
            _connectionControl.CMB_serialport.Items.Clear();
            _connectionControl.CMB_serialport.Items.Add("AUTO");
            _connectionControl.CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
            _connectionControl.CMB_serialport.Items.Add("TCP");
            _connectionControl.CMB_serialport.Items.Add("UDP");
            _connectionControl.CMB_serialport.Items.Add("UDPCl");
        }


        private void CMB_baudrate_TextChanged(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            int baud = 0;
            for (int i = 0; i < _connectionControl.CMB_baudrate.Text.Length; i++)
                if (char.IsDigit(_connectionControl.CMB_baudrate.Text[i]))
                {
                    sb.Append(_connectionControl.CMB_baudrate.Text[i]);
                    baud = baud * 10 + _connectionControl.CMB_baudrate.Text[i] - '0';
                }
            if (_connectionControl.CMB_baudrate.Text != sb.ToString())
            {
                _connectionControl.CMB_baudrate.Text = sb.ToString();
            }
        }

        private void CMB_serialport_SelectedIndexChanged(object sender, EventArgs e)
        {
                // check for saved baud rate and restore
                if (Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"] != null)
                {
                    _connectionControl.CMB_baudrate.Text =
                        Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"];
                }
        }

        private void hsdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            redminval.Enabled = true;
            redmaxval.Enabled = true;

            whiteminval.Enabled = true;
            whitemaxval.Enabled = true;

            greenminval.Enabled = true;
            greenmaxval.Enabled = true;

            enablecolor.Enabled = true;
            enablespeech.Enabled = true;
            enableautoonlyspeech.Enabled = true;
            voicecontent.Enabled = false;

            panel1.BackColor = Color.Red;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.Green;
            BTN_Save.BackColor = Color.White;

            if (HSSetting.hsdatas.ContainsKey(HSdatagridview.Rows[e.RowIndex].Cells[e.ColumnIndex+1].Value.ToString()))
            {
                HSSetting.hsdatainfo hsdata = HSSetting.hsdatas[HSdatagridview.Rows[e.RowIndex].Cells[e.ColumnIndex+1].Value.ToString()];
                HSDataName.Text = HSdatagridview.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if(hsdata.enablecolor)
                {
                    redminval.Text = hsdata.redminvalue.ToString("0.00");
                    redmaxval.Text = hsdata.redmaxvalue.ToString("0.00");

                    whiteminval.Text = hsdata.whiteminvalue.ToString("0.00");
                    whitemaxval.Text = hsdata.whitemaxvalue.ToString("0.00");

                    greenminval.Text = hsdata.greenminvalue.ToString("0.00");
                    greenmaxval.Text = hsdata.greenmaxvalue.ToString("0.00");

                    enablecolor.Checked = hsdata.enablecolor;
                    enablespeech.Checked = hsdata.enablevoice;
                    enableautoonlyspeech.Checked = hsdata.enableautoonlyvoice;
                    voicecontent.Text = hsdata.voicecontent;

                }
                else
                {
                    redminval.Text = hsdata.redminvalue.ToString("0.00");
                    redmaxval.Text = hsdata.redmaxvalue.ToString("0.00");

                    whiteminval.Text = hsdata.whiteminvalue.ToString("0.00");
                    whitemaxval.Text = hsdata.whitemaxvalue.ToString("0.00");

                    greenminval.Text = hsdata.greenminvalue.ToString("0.00");
                    greenmaxval.Text = hsdata.greenmaxvalue.ToString("0.00");

                    enablecolor.Checked = hsdata.enablecolor;
                    enablespeech.Checked = hsdata.enablevoice;
                    enableautoonlyspeech.Checked = hsdata.enableautoonlyvoice;
                    voicecontent.Text = hsdata.voicecontent;

                    redminval.Enabled = false;
                    redmaxval.Enabled = false;

                    whiteminval.Enabled = false;
                    whitemaxval.Enabled = false;

                    greenminval.Enabled = false;
                    greenmaxval.Enabled = false;

                    enablespeech.Enabled = false;
                    enableautoonlyspeech.Enabled = false;
                    voicecontent.Enabled = false;
                }
            }
            else
            {
                HSDataName.Text = HSdatagridview.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                HSSetting.hsdatainfo hsdata = new HSSetting.hsdatainfo();
                hsdata.name = HSdatagridview.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString();
                hsdata.redminvalue = 0;
                hsdata.redmaxvalue = 0;
                hsdata.whiteminvalue = 0;
                hsdata.whitemaxvalue = 0;
                hsdata.greenminvalue = 0;
                hsdata.greenmaxvalue = 0;
                hsdata.enablecolor = false;
                hsdata.enablevoice = false;
                hsdata.enableautoonlyvoice = false;
                voicecontent.Text = "";

                redminval.Text = 0.ToString("0.00");
                redmaxval.Text = 0.ToString("0.00");

                whiteminval.Text = 0.ToString("0.00");
                whitemaxval.Text = 0.ToString("0.00");

                greenminval.Text = 0.ToString("0.00");
                greenmaxval.Text = 0.ToString("0.00");

                enablecolor.Checked = false;
                enablespeech.Checked = false;
                enableautoonlyspeech.Checked = false;
                voicecontent.Text = "";


                HSSetting.hsdatas[hsdata.name] = hsdata;

                HSSetting.Instance.xmlhsdata(true);

                redminval.Enabled = false;
                redmaxval.Enabled = false;

                whiteminval.Enabled = false;
                whitemaxval.Enabled = false;

                greenminval.Enabled = false;
                greenmaxval.Enabled = false;

                enablespeech.Enabled = false;
                enableautoonlyspeech.Enabled = false;
                voicecontent.Enabled = false;

            }


        }

        private void enablecolor_checked_changed(object sender, EventArgs e)
        {
            if(enablecolor.Checked)
            {
                redminval.Enabled = true;
                redmaxval.Enabled = true;

                whiteminval.Enabled = true;
                whitemaxval.Enabled = true;

                greenminval.Enabled = true;
                greenmaxval.Enabled = true;

                enablecolor.Enabled = true;
                enablespeech.Enabled = true;
                enableautoonlyspeech.Enabled = true;
                voicecontent.Enabled = true;
            }
            else
            {
                redminval.Enabled = false;
                redmaxval.Enabled = false;

                whiteminval.Enabled = false;
                whitemaxval.Enabled = false;

                greenminval.Enabled = false;
                greenmaxval.Enabled = false;

                enablespeech.Enabled = false;
                enableautoonlyspeech.Enabled = false;
                voicecontent.Enabled = false;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            HSSetting.hsdatainfo hsdata = new HSSetting.hsdatainfo();
            hsdata.name = HSdatagridview.Rows[HSdatagridview.CurrentRow.Index].Cells[1].Value.ToString();
            double value = 0;
            hsdata.redminvalue = double.TryParse(redminval.Text, out value) ? value : 0;
            hsdata.redmaxvalue = double.TryParse(redmaxval.Text, out value) ? value : 0;
            hsdata.whiteminvalue = double.TryParse(whiteminval.Text, out value) ? value : 0;
            hsdata.whitemaxvalue = double.TryParse(whitemaxval.Text, out value) ? value : 0;
            hsdata.greenminvalue = double.TryParse(greenminval.Text, out value) ? value : 0;
            hsdata.greenmaxvalue = double.TryParse(greenmaxval.Text, out value) ? value : 0;
            hsdata.enablecolor = enablecolor.Checked;
            hsdata.enablevoice = enablespeech.Checked;
            hsdata.enableautoonlyvoice = enableautoonlyspeech.Checked;
            hsdata.voicecontent = voicecontent.Text;

            HSSetting.hsdatas[hsdata.name] = hsdata;

            HSSetting.Instance.xmlhsdata(true);
        }

        private void connect(object o)
        {
            MainV2.instance.HSConnect_thread(_connectionControl.CMB_serialport.Text, _connectionControl.CMB_baudrate.Text);
            if(MainV2.comPort.BaseStream.IsOpen)
            {
                BTN_disconnect.Enabled = true;
                BTN_Connect.Enabled = false;
                for(int i=0;i<MainV2.instance.HsdevInterface.prearmcheck.Count();i++)
                {
                    MainV2.instance.HsdevInterface.prearmcheck[i] = false;
                }
                //MainV2.instance.MenuFlightPlanner_Click(null,null);                
                MainV2.instance.FlightPlanner.backgroundgetWPs();
                //MainV2.instance.MenuHsdevInterface_Click(null, null);
            }
            else
            {
                BTN_disconnect.Enabled = false;
                BTN_Connect.Enabled = true;
            }
        }

        private void BTN_Connect_Click(object sender, EventArgs e)
        {
            //System.Threading.ThreadPool.QueueUserWorkItem(MainV2.instance.HSConnect_thread);
           // MainV2.instance.HSConnect_thread(null);
           // return;
            try
            {
                Thread httpthread = new Thread(connect)
                {
                    Name = "motion jpg stream-network kml",
                    IsBackground = true
                };
                httpthread.Start();
            }
            catch (Exception ex)
            {
                //log.Error("Error starting TCP listener thread: ", ex);
                CustomMessageBox.Show(ex.ToString());
            }

            BTN_disconnect.Enabled = false;
            BTN_Connect.Enabled = false;

        }

        private void BTN_disconnect_Click(object sender, EventArgs e)
        {
            MainV2.instance.HSConnect_thread(_connectionControl.CMB_serialport.Text, _connectionControl.CMB_baudrate.Text);
            if (MainV2.comPort.BaseStream.IsOpen)
            {
                BTN_disconnect.Enabled = true;
                BTN_Connect.Enabled = false;
            }
            else
            {
                BTN_disconnect.Enabled = false;
                BTN_Connect.Enabled = true;
            }
        }

        void my_Paint(object sender, EventArgs e)
        {
            BTN_Connect.BackColor = Color.White;
            BTN_disconnect.BackColor = Color.White;
            BTN_Save.BackColor = Color.White;
        }

    }
}
