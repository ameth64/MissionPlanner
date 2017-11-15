namespace MissionPlanner.GCSViews.ConfigurationView
{
    partial class HSConfigure
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HSConfigure));
            this.HSDataName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.redminval = new System.Windows.Forms.TextBox();
            this.redmaxval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.whitemaxval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.whiteminval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.greenmaxval = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.greenminval = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.enablecolor = new System.Windows.Forms.CheckBox();
            this.enablespeech = new System.Windows.Forms.CheckBox();
            this.enableautoonlyspeech = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.voicecontent = new System.Windows.Forms.TextBox();
            this.BTN_Connect = new System.Windows.Forms.Button();
            this.BTN_disconnect = new System.Windows.Forms.Button();
            this._connectionControl = new MissionPlanner.Controls.ConnectionControl();
            this.HSdatagridview = new MissionPlanner.Controls.MyDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.HSdatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // HSDataName
            // 
            this.HSDataName.Location = new System.Drawing.Point(384, 21);
            this.HSDataName.Name = "HSDataName";
            this.HSDataName.Size = new System.Drawing.Size(100, 21);
            this.HSDataName.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(384, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 25);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(616, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 25);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel3.Location = new System.Drawing.Point(857, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(238, 25);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "最小";
            // 
            // redminval
            // 
            this.redminval.Location = new System.Drawing.Point(417, 98);
            this.redminval.Name = "redminval";
            this.redminval.Size = new System.Drawing.Size(67, 21);
            this.redminval.TabIndex = 6;
            // 
            // redmaxval
            // 
            this.redmaxval.Location = new System.Drawing.Point(531, 98);
            this.redmaxval.Name = "redmaxval";
            this.redmaxval.Size = new System.Drawing.Size(70, 21);
            this.redmaxval.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "最大";
            // 
            // whitemaxval
            // 
            this.whitemaxval.Location = new System.Drawing.Point(768, 100);
            this.whitemaxval.Name = "whitemaxval";
            this.whitemaxval.Size = new System.Drawing.Size(70, 21);
            this.whitemaxval.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(735, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "最大";
            // 
            // whiteminval
            // 
            this.whiteminval.Location = new System.Drawing.Point(656, 98);
            this.whiteminval.Name = "whiteminval";
            this.whiteminval.Size = new System.Drawing.Size(67, 21);
            this.whiteminval.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(621, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "最小";
            // 
            // greenmaxval
            // 
            this.greenmaxval.Location = new System.Drawing.Point(1008, 99);
            this.greenmaxval.Name = "greenmaxval";
            this.greenmaxval.Size = new System.Drawing.Size(70, 21);
            this.greenmaxval.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(975, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "最大";
            // 
            // greenminval
            // 
            this.greenminval.Location = new System.Drawing.Point(894, 100);
            this.greenminval.Name = "greenminval";
            this.greenminval.Size = new System.Drawing.Size(67, 21);
            this.greenminval.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(861, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "最小";
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(986, 159);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 20;
            this.BTN_Save.Text = "保存";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // enablecolor
            // 
            this.enablecolor.AutoSize = true;
            this.enablecolor.Location = new System.Drawing.Point(384, 135);
            this.enablecolor.Name = "enablecolor";
            this.enablecolor.Size = new System.Drawing.Size(96, 16);
            this.enablecolor.TabIndex = 21;
            this.enablecolor.Text = "启用颜色显示";
            this.enablecolor.UseVisualStyleBackColor = true;
            this.enablecolor.CheckedChanged += new System.EventHandler(this.enablecolor_checked_changed);
            // 
            // enablespeech
            // 
            this.enablespeech.AutoSize = true;
            this.enablespeech.Location = new System.Drawing.Point(521, 135);
            this.enablespeech.Name = "enablespeech";
            this.enablespeech.Size = new System.Drawing.Size(96, 16);
            this.enablespeech.TabIndex = 22;
            this.enablespeech.Text = "启用语音报警";
            this.enablespeech.UseVisualStyleBackColor = true;
            // 
            // enableautoonlyspeech
            // 
            this.enableautoonlyspeech.AutoSize = true;
            this.enableautoonlyspeech.Location = new System.Drawing.Point(682, 135);
            this.enableautoonlyspeech.Name = "enableautoonlyspeech";
            this.enableautoonlyspeech.Size = new System.Drawing.Size(144, 16);
            this.enableautoonlyspeech.TabIndex = 23;
            this.enableautoonlyspeech.Text = "启用只在导航模式报警";
            this.enableautoonlyspeech.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(384, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "报警内容";
            // 
            // voicecontent
            // 
            this.voicecontent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.voicecontent.Location = new System.Drawing.Point(443, 161);
            this.voicecontent.Name = "voicecontent";
            this.voicecontent.Size = new System.Drawing.Size(495, 21);
            this.voicecontent.TabIndex = 25;
            // 
            // BTN_Connect
            // 
            this.BTN_Connect.Location = new System.Drawing.Point(266, 204);
            this.BTN_Connect.Name = "BTN_Connect";
            this.BTN_Connect.Size = new System.Drawing.Size(64, 23);
            this.BTN_Connect.TabIndex = 26;
            this.BTN_Connect.Text = "连接飞控";
            this.BTN_Connect.UseVisualStyleBackColor = true;
            this.BTN_Connect.Click += new System.EventHandler(this.BTN_Connect_Click);
            // 
            // BTN_disconnect
            // 
            this.BTN_disconnect.Location = new System.Drawing.Point(267, 235);
            this.BTN_disconnect.Name = "BTN_disconnect";
            this.BTN_disconnect.Size = new System.Drawing.Size(63, 23);
            this.BTN_disconnect.TabIndex = 27;
            this.BTN_disconnect.Text = "断开连接";
            this.BTN_disconnect.UseVisualStyleBackColor = true;
            this.BTN_disconnect.Click += new System.EventHandler(this.BTN_disconnect_Click);
            // 
            // _connectionControl
            // 
            this._connectionControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_connectionControl.BackgroundImage")));
            this._connectionControl.Location = new System.Drawing.Point(31, 204);
            this._connectionControl.MinimumSize = new System.Drawing.Size(230, 54);
            this._connectionControl.Name = "_connectionControl";
            this._connectionControl.Size = new System.Drawing.Size(230, 54);
            this._connectionControl.TabIndex = 28;
            // 
            // HSdatagridview
            // 
            this.HSdatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HSdatagridview.GridColor = System.Drawing.Color.DimGray;
            this.HSdatagridview.Location = new System.Drawing.Point(29, 21);
            this.HSdatagridview.Name = "HSdatagridview";
            this.HSdatagridview.RowTemplate.Height = 23;
            this.HSdatagridview.Size = new System.Drawing.Size(301, 156);
            this.HSdatagridview.TabIndex = 0;
            this.HSdatagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.hsdata_CellContentClick);
            // 
            // HSConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._connectionControl);
            this.Controls.Add(this.BTN_disconnect);
            this.Controls.Add(this.BTN_Connect);
            this.Controls.Add(this.voicecontent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.enableautoonlyspeech);
            this.Controls.Add(this.enablespeech);
            this.Controls.Add(this.enablecolor);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.greenmaxval);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.greenminval);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.whitemaxval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.whiteminval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.redmaxval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.redminval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HSDataName);
            this.Controls.Add(this.HSdatagridview);
            this.Name = "HSConfigure";
            this.Size = new System.Drawing.Size(1098, 545);
            this.Enter += new System.EventHandler(this.my_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.HSdatagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.MyDataGridView HSdatagridview;
        private System.Windows.Forms.TextBox HSDataName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox redminval;
        private System.Windows.Forms.TextBox redmaxval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox whitemaxval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox whiteminval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox greenmaxval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox greenminval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.CheckBox enablecolor;
        private System.Windows.Forms.CheckBox enablespeech;
        private System.Windows.Forms.CheckBox enableautoonlyspeech;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox voicecontent;
        private System.Windows.Forms.Button BTN_Connect;
        private System.Windows.Forms.Button BTN_disconnect;
        private Controls.ConnectionControl _connectionControl;
    }
}
