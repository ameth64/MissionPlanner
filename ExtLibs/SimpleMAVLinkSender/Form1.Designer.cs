namespace SimpleMAVLinkSender
{
  partial class SimpleMAVLinkSender
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBox_serialport = new System.Windows.Forms.ComboBox();
      this.comboBox_baudrate = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.button_connect = new System.Windows.Forms.Button();
      this.textBox_msg = new System.Windows.Forms.TextBox();
      this.button_send = new System.Windows.Forms.Button();
      this.serialPort = new System.IO.Ports.SerialPort(this.components);
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(25, 49);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(61, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "CMO串口";
      // 
      // comboBox_serialport
      // 
      this.comboBox_serialport.FormattingEnabled = true;
      this.comboBox_serialport.Location = new System.Drawing.Point(92, 46);
      this.comboBox_serialport.Name = "comboBox_serialport";
      this.comboBox_serialport.Size = new System.Drawing.Size(121, 23);
      this.comboBox_serialport.TabIndex = 1;
      // 
      // comboBox_baudrate
      // 
      this.comboBox_baudrate.FormattingEnabled = true;
      this.comboBox_baudrate.Location = new System.Drawing.Point(347, 46);
      this.comboBox_baudrate.Name = "comboBox_baudrate";
      this.comboBox_baudrate.Size = new System.Drawing.Size(121, 23);
      this.comboBox_baudrate.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(260, 49);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(71, 15);
      this.label2.TabIndex = 3;
      this.label2.Text = "BaudRate";
      // 
      // button_connect
      // 
      this.button_connect.Location = new System.Drawing.Point(524, 45);
      this.button_connect.Name = "button_connect";
      this.button_connect.Size = new System.Drawing.Size(75, 23);
      this.button_connect.TabIndex = 4;
      this.button_connect.Text = "connect";
      this.button_connect.UseVisualStyleBackColor = true;
      this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
      // 
      // textBox_msg
      // 
      this.textBox_msg.Location = new System.Drawing.Point(28, 183);
      this.textBox_msg.Name = "textBox_msg";
      this.textBox_msg.Size = new System.Drawing.Size(440, 25);
      this.textBox_msg.TabIndex = 5;
      // 
      // button_send
      // 
      this.button_send.Location = new System.Drawing.Point(524, 184);
      this.button_send.Name = "button_send";
      this.button_send.Size = new System.Drawing.Size(75, 23);
      this.button_send.TabIndex = 6;
      this.button_send.Text = "send";
      this.button_send.UseVisualStyleBackColor = true;
      // 
      // SimpleMAVLinkSender
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(701, 360);
      this.Controls.Add(this.button_send);
      this.Controls.Add(this.textBox_msg);
      this.Controls.Add(this.button_connect);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.comboBox_baudrate);
      this.Controls.Add(this.comboBox_serialport);
      this.Controls.Add(this.label1);
      this.Name = "SimpleMAVLinkSender";
      this.Text = "SimpleMAVLinkSender";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBox_serialport;
    private System.Windows.Forms.ComboBox comboBox_baudrate;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button_connect;
    private System.Windows.Forms.TextBox textBox_msg;
    private System.Windows.Forms.Button button_send;
    private System.IO.Ports.SerialPort serialPort;
  }
}

