namespace MissionPlanner.GCSViews.ConfigurationView
{
    partial class PrearmCheck
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
            this.CHK_servo = new System.Windows.Forms.CheckBox();
            this.CHK_compass = new System.Windows.Forms.CheckBox();
            this.CHK_airspeed = new System.Windows.Forms.CheckBox();
            this.CHK_cam = new System.Windows.Forms.CheckBox();
            this.BTN_Camera = new System.Windows.Forms.Button();
            this.CHK_rotoridle = new System.Windows.Forms.CheckBox();
            this.CHK_rcinput = new System.Windows.Forms.CheckBox();
            this.btn_logspace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CHK_servo
            // 
            this.CHK_servo.AutoSize = true;
            this.CHK_servo.Location = new System.Drawing.Point(30, 60);
            this.CHK_servo.Name = "CHK_servo";
            this.CHK_servo.Size = new System.Drawing.Size(108, 16);
            this.CHK_servo.TabIndex = 23;
            this.CHK_servo.Text = "固定翼舵机检查";
            this.CHK_servo.UseVisualStyleBackColor = true;
            // 
            // CHK_compass
            // 
            this.CHK_compass.AutoSize = true;
            this.CHK_compass.Location = new System.Drawing.Point(30, 102);
            this.CHK_compass.Name = "CHK_compass";
            this.CHK_compass.Size = new System.Drawing.Size(72, 16);
            this.CHK_compass.TabIndex = 24;
            this.CHK_compass.Text = "罗盘指向";
            this.CHK_compass.UseVisualStyleBackColor = true;
            // 
            // CHK_airspeed
            // 
            this.CHK_airspeed.AutoSize = true;
            this.CHK_airspeed.Location = new System.Drawing.Point(30, 144);
            this.CHK_airspeed.Name = "CHK_airspeed";
            this.CHK_airspeed.Size = new System.Drawing.Size(60, 16);
            this.CHK_airspeed.TabIndex = 25;
            this.CHK_airspeed.Text = "空速计";
            this.CHK_airspeed.UseVisualStyleBackColor = true;
            // 
            // CHK_cam
            // 
            this.CHK_cam.AutoSize = true;
            this.CHK_cam.Location = new System.Drawing.Point(30, 188);
            this.CHK_cam.Name = "CHK_cam";
            this.CHK_cam.Size = new System.Drawing.Size(48, 16);
            this.CHK_cam.TabIndex = 26;
            this.CHK_cam.Text = "相机";
            this.CHK_cam.UseVisualStyleBackColor = true;
            // 
            // BTN_Camera
            // 
            this.BTN_Camera.Location = new System.Drawing.Point(101, 184);
            this.BTN_Camera.Name = "BTN_Camera";
            this.BTN_Camera.Size = new System.Drawing.Size(75, 23);
            this.BTN_Camera.TabIndex = 27;
            this.BTN_Camera.Text = "拍照";
            this.BTN_Camera.UseVisualStyleBackColor = true;
            this.BTN_Camera.Click += new System.EventHandler(this.BTN_Camera_Click);
            // 
            // CHK_rotoridle
            // 
            this.CHK_rotoridle.AutoSize = true;
            this.CHK_rotoridle.Location = new System.Drawing.Point(30, 229);
            this.CHK_rotoridle.Name = "CHK_rotoridle";
            this.CHK_rotoridle.Size = new System.Drawing.Size(108, 16);
            this.CHK_rotoridle.TabIndex = 28;
            this.CHK_rotoridle.Text = "多旋翼怠速检查";
            this.CHK_rotoridle.UseVisualStyleBackColor = true;
            // 
            // CHK_rcinput
            // 
            this.CHK_rcinput.AutoSize = true;
            this.CHK_rcinput.Location = new System.Drawing.Point(30, 265);
            this.CHK_rcinput.Name = "CHK_rcinput";
            this.CHK_rcinput.Size = new System.Drawing.Size(108, 16);
            this.CHK_rcinput.TabIndex = 29;
            this.CHK_rcinput.Text = "遥控器输入检验";
            this.CHK_rcinput.UseVisualStyleBackColor = true;
            // 
            // btn_logspace
            // 
            this.btn_logspace.Location = new System.Drawing.Point(27, 305);
            this.btn_logspace.Name = "btn_logspace";
            this.btn_logspace.Size = new System.Drawing.Size(140, 23);
            this.btn_logspace.TabIndex = 30;
            this.btn_logspace.Text = "检查飞控剩余空间";
            this.btn_logspace.UseVisualStyleBackColor = true;
            this.btn_logspace.Click += new System.EventHandler(this.btn_logspace_Click);
            // 
            // PrearmCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 390);
            this.Controls.Add(this.btn_logspace);
            this.Controls.Add(this.CHK_rcinput);
            this.Controls.Add(this.CHK_rotoridle);
            this.Controls.Add(this.BTN_Camera);
            this.Controls.Add(this.CHK_cam);
            this.Controls.Add(this.CHK_airspeed);
            this.Controls.Add(this.CHK_compass);
            this.Controls.Add(this.CHK_servo);
            this.Name = "PrearmCheck";
            this.Text = "PrearmCheck";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PrearmCheck_FormClosed);
            this.Shown += new System.EventHandler(this.my_show);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BTN_Camera;
        public System.Windows.Forms.CheckBox CHK_servo;
        public System.Windows.Forms.CheckBox CHK_compass;
        public System.Windows.Forms.CheckBox CHK_airspeed;
        public System.Windows.Forms.CheckBox CHK_cam;
        public System.Windows.Forms.CheckBox CHK_rotoridle;
        public System.Windows.Forms.CheckBox CHK_rcinput;
        private System.Windows.Forms.Button btn_logspace;
    }
}