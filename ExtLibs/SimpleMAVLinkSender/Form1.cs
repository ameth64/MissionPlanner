using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SimpleMAVLinkSender
{
  public partial class SimpleMAVLinkSender : Form
  {
    MAVLink.MavlinkParse mavlink = new MAVLink.MavlinkParse();
    bool armed = false;
    // locking to prevent multiple reads on serial port
    object readlock = new object();
    // our target sysid
    byte sysid = 1;
    // our target compid
    byte compid = 1;
    public int packetcount = 0;

    public SimpleMAVLinkSender()
    {
      InitializeComponent();

      comboBox_serialport.Items.AddRange(SerialPort.GetPortNames());

      comboBox_baudrate.Items.AddRange(
        new object[] { 2400, 4800, 9600, 19200, 38400, 57600, 115200 });

      mavlink.GenerateMAVLinkPacket10(MAVLink.MAVLINK_MSG_ID.REQUEST_DATA_STREAM,
      new MAVLink.mavlink_request_data_stream_t()
      {
        req_message_rate = 2,
        req_stream_id = (byte)MAVLink.MAV_DATA_STREAM.ALL,
        start_stop = 1,
        target_component = compid,
        target_system = sysid
      });

      //serialPort.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
    }

    void bgwheartbeat_DoWork(object sender, DoWorkEventArgs e)
    {
      while (serialPort.IsOpen)
      {
          lock (readlock)
          {
            MAVLink.mavlink_heartbeat_t hb = new MAVLink.mavlink_heartbeat_t();

            hb.type =  (byte)MAVLink.MAV_TYPE.FIXED_WING;
            hb.autopilot = (byte)MAVLink.MAV_AUTOPILOT.GENERIC;
            hb.base_mode = (byte)MAVLink.MAV_MODE_FLAG.MANUAL_INPUT_ENABLED;
            hb.system_status = (byte)MAVLink.MAV_STATE.BOOT;

            byte[] packet = GenerateMAVLinkPacketSender(MAVLink.MAVLINK_MSG_ID.HEARTBEAT, hb);
            serialPort.Write(packet, 0, packet.Length);            
          }
          System.Threading.Thread.Sleep(2000);
      }
    }

    void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
      while (serialPort.IsOpen)
      {
        try
        {
          MAVLink.MAVLinkMessage packet;
          lock (readlock)
          {
            // read any valid packet from the port
            packet = mavlink.ReadPacket(serialPort.BaseStream);

            // check its valid
            if (packet == null || packet.data == null)
              continue;
          }

          if (packet.data.GetType() == typeof(MAVLink.mavlink_command_long_t))
          {
            var hb = (MAVLink.mavlink_command_long_t)packet.data;

            // from here we should check the the message is addressed to us
            if (sysid != hb.target_system || compid != hb.target_component)
            {
              Console.WriteLine("Error, target system or component not match!");
              continue;
            }

            if (hb.command == (ushort)MAVLink.MAV_CMD.COMPONENT_ARM_DISARM)
            {
              armed = hb.param1==1 ? true : false;
              if(armed)
                Console.WriteLine("Arm Success!");
              else
                Console.WriteLine("Disarm Success!");

              //发送mavlink_command_ack_t包给MP
              MAVLink.mavlink_command_ack_t ack = new MAVLink.mavlink_command_ack_t();

              ack.command = (ushort)MAVLink.MAV_CMD.COMPONENT_ARM_DISARM;
              ack.result = (byte)MAVLink.MAV_RESULT.ACCEPTED;

              byte[] ack_packet = GenerateMAVLinkPacketSender(
                MAVLink.MAVLINK_MSG_ID.COMMAND_ACK,ack);

              serialPort.Write(ack_packet, 0, ack_packet.Length);
            }

            
            
          }



        }
        catch
        {
        }

        System.Threading.Thread.Sleep(1);
      }
    }


    private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      
      try
      {
        MAVLink.MAVLinkMessage packet;
        lock (readlock)
        {
          // read any valid packet from the port
          packet = mavlink.ReadPacket(serialPort.BaseStream);

          // check its valid
          if (packet == null || packet.data == null)
            return;

          if(packet.msgid == (byte)MAVLink.MAVLINK_MSG_ID.HEARTBEAT)
            return;

        }

      }
      catch
      {
        Console.WriteLine("OnDataReceived error\n");
      }
    }

    private void button_connect_Click(object sender, EventArgs e)
    {
      // if the port is open close it
      if (serialPort.IsOpen)
      {
        serialPort.Close();
        return;
      }

      // set the comport options
      serialPort.PortName = comboBox_serialport.Text;
      serialPort.BaudRate = int.Parse(comboBox_baudrate.Text);

      // open the comport
      serialPort.Open();

      serialPort.ReadTimeout = 2000;

      if (serialPort.IsOpen)
      {
        Console.WriteLine(comboBox_serialport.Text + " connect!\n");
      }

      BackgroundWorker bgw = new BackgroundWorker();
      BackgroundWorker bgwheartbeat = new BackgroundWorker();

      bgw.DoWork += bgw_DoWork;
      bgwheartbeat.DoWork += bgwheartbeat_DoWork;

      bgw.RunWorkerAsync();
      bgwheartbeat.RunWorkerAsync();
    }

    public byte[] GenerateMAVLinkPacketSender(MAVLink.MAVLINK_MSG_ID messageType, object indata)
    {
      byte[] data;

      data = MavlinkUtil.StructureToByteArray(indata);

      byte[] packet = new byte[data.Length + 6 + 2];

      packet[0] = 0xfe;
      packet[1] = (byte)data.Length;
      packet[2] = (byte)packetcount;

      packetcount++;

      packet[3] = 1;
      packet[4] = 1;
      packet[5] = (byte)messageType;


      int i = 6;
      foreach (byte b in data)
      {
        packet[i] = b;
        i++;
      }

      ushort checksum = MAVLink.MavlinkCRC.crc_calculate(packet, packet[1] + 6);

      checksum = MAVLink.MavlinkCRC.crc_accumulate(
        MAVLink.MAVLINK_MESSAGE_CRCS[(byte)messageType], checksum);

      byte ck_a = (byte)(checksum & 0xFF); ///< High byte
      byte ck_b = (byte)(checksum >> 8); ///< Low byte

      packet[i] = ck_a;
      i += 1;
      packet[i] = ck_b;
      i += 1;

      return packet;
    }

  }
}
