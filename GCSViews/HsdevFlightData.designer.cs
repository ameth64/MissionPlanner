namespace MissionPlanner.GCSViews
{
    partial class HsdevFlightData
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HsdevFlightData));
            this.contextMenuStripHud = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer_main_map = new System.Windows.Forms.SplitContainer();
            this.splitContainer_main_left = new System.Windows.Forms.SplitContainer();
            this.splitContainer_3dview_hud = new System.Windows.Forms.SplitContainer();
            this.splitContainer_3dview_msg = new System.Windows.Forms.SplitContainer();
            this._3DMesh1 = new MissionPlanner.Mesh._3DMesh();
            this.bindingSourceHud = new System.Windows.Forms.BindingSource(this.components);
            this.hud2 = new MissionPlanner.Controls.HSHUD();
            this.splitContainer_opr_logplayer = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer_info_system_more = new System.Windows.Forms.SplitContainer();
            this.splitContainer_info_fixedwing_copter = new System.Windows.Forms.SplitContainer();
            this.panel_fixedwing_info = new BSE.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_fw_voltage = new System.Windows.Forms.Label();
            this.val_timeinair = new System.Windows.Forms.Label();
            this.val_fw_mah_used = new System.Windows.Forms.Label();
            this.lbl_fw_mah_used = new System.Windows.Forms.Label();
            this.val_traveled_km = new System.Windows.Forms.Label();
            this.lbl_traveled_km = new System.Windows.Forms.Label();
            this.val_fw_current = new System.Windows.Forms.Label();
            this.val_fw_voltage = new System.Windows.Forms.Label();
            this.lbl_fw_current = new System.Windows.Forms.Label();
            this.lbl_fw_timeinair = new System.Windows.Forms.Label();
            this.panel_copter_info = new BSE.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_quad_voltage = new System.Windows.Forms.Label();
            this.val_quadbat_time = new System.Windows.Forms.Label();
            this.val_quad_voltage = new System.Windows.Forms.Label();
            this.lbl_quadbat_time = new System.Windows.Forms.Label();
            this.val_quad_mah_used = new System.Windows.Forms.Label();
            this.lbl_quad_current = new System.Windows.Forms.Label();
            this.lbl_quad_mah_used = new System.Windows.Forms.Label();
            this.val_quad_current = new System.Windows.Forms.Label();
            this.panel_sysinfo = new BSE.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_mode = new System.Windows.Forms.Label();
            this.val_cam_num = new System.Windows.Forms.Label();
            this.lbl_cam_num = new System.Windows.Forms.Label();
            this.val_alt_error = new System.Windows.Forms.Label();
            this.lbl_alt_error = new System.Windows.Forms.Label();
            this.val_target_wp = new System.Windows.Forms.Label();
            this.lbl_target_wp = new System.Windows.Forms.Label();
            this.val_gps_ground_vel = new System.Windows.Forms.Label();
            this.val_compass = new System.Windows.Forms.Label();
            this.val_xtrack_error = new System.Windows.Forms.Label();
            this.lbl_xtrack_error = new System.Windows.Forms.Label();
            this.lbl_sat_count = new System.Windows.Forms.Label();
            this.val_latitude = new System.Windows.Forms.Label();
            this.val_gps_mode = new System.Windows.Forms.Label();
            this.lbl_gps_mode = new System.Windows.Forms.Label();
            this.lbl_compass = new System.Windows.Forms.Label();
            this.lbl_longtitude = new System.Windows.Forms.Label();
            this.val_sat_count = new System.Windows.Forms.Label();
            this.lbl_latitude = new System.Windows.Forms.Label();
            this.val_longitude = new System.Windows.Forms.Label();
            this.lbl_alt = new System.Windows.Forms.Label();
            this.lbl_gps_ground_vel = new System.Windows.Forms.Label();
            this.val_airspeed_error = new System.Windows.Forms.Label();
            this.val_alt_target = new System.Windows.Forms.Label();
            this.val_mode = new System.Windows.Forms.Label();
            this.lbl_alt_target = new System.Windows.Forms.Label();
            this.lbl_throttle = new System.Windows.Forms.Label();
            this.val_throttle = new System.Windows.Forms.Label();
            this.lbl_airspeed = new System.Windows.Forms.Label();
            this.val_alt = new System.Windows.Forms.Label();
            this.val_airspeed = new System.Windows.Forms.Label();
            this.lbl_airspeed_target = new System.Windows.Forms.Label();
            this.val_airspeed_target = new System.Windows.Forms.Label();
            this.lbl_airspeed_error = new System.Windows.Forms.Label();
            this.lblbtn_set_target_wp = new System.Windows.Forms.Label();
            this.btn_force_disarm = new MissionPlanner.Controls.MyButton();
            this.BUT_ARM = new MissionPlanner.Controls.MyButton();
            this.BUT_parachute = new MissionPlanner.Controls.MyButton();
            this.BUT_standby = new MissionPlanner.Controls.MyButton();
            this.BUT_camera = new MissionPlanner.Controls.MyButton();
            this.BUT_clear_track = new MissionPlanner.Controls.MyButton();
            this.CMB_setwp = new System.Windows.Forms.ComboBox();
            this.BUTrestartmission = new MissionPlanner.Controls.MyButton();
            this.BUT_quickrtl = new MissionPlanner.Controls.MyButton();
            this.BUT_quickauto = new MissionPlanner.Controls.MyButton();
            this.lblrepl_replay_speed = new System.Windows.Forms.Label();
            this.CMB_playspeed = new System.Windows.Forms.ComboBox();
            this.lblrepl_logpercent = new MissionPlanner.Controls.MyLabel();
            this.tracklog = new System.Windows.Forms.TrackBar();
            this.BUT_playlog = new MissionPlanner.Controls.MyButton();
            this.BUT_loadtelem = new MissionPlanner.Controls.MyButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.windDir1 = new MissionPlanner.Controls.WindDir();
            this.gMapControl1 = new MissionPlanner.Controls.myGMAP();
            this.contextMenuStripMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flyToHereAltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixbattery = new System.Windows.Forms.ToolStripMenuItem();
            this.landStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSourceGaugesTab = new System.Windows.Forms.BindingSource(this.components);
            this.ZedGraphTimer = new System.Windows.Forms.Timer(this.components);
            this.bindingSourceStatusTab = new System.Windows.Forms.BindingSource(this.components);
            this.speedUintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main_map)).BeginInit();
            this.splitContainer_main_map.Panel1.SuspendLayout();
            this.splitContainer_main_map.Panel2.SuspendLayout();
            this.splitContainer_main_map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main_left)).BeginInit();
            this.splitContainer_main_left.Panel1.SuspendLayout();
            this.splitContainer_main_left.Panel2.SuspendLayout();
            this.splitContainer_main_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_3dview_hud)).BeginInit();
            this.splitContainer_3dview_hud.Panel1.SuspendLayout();
            this.splitContainer_3dview_hud.Panel2.SuspendLayout();
            this.splitContainer_3dview_hud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_3dview_msg)).BeginInit();
            this.splitContainer_3dview_msg.Panel1.SuspendLayout();
            this.splitContainer_3dview_msg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_opr_logplayer)).BeginInit();
            this.splitContainer_opr_logplayer.Panel1.SuspendLayout();
            this.splitContainer_opr_logplayer.Panel2.SuspendLayout();
            this.splitContainer_opr_logplayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_info_system_more)).BeginInit();
            this.splitContainer_info_system_more.Panel1.SuspendLayout();
            this.splitContainer_info_system_more.Panel2.SuspendLayout();
            this.splitContainer_info_system_more.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_info_fixedwing_copter)).BeginInit();
            this.splitContainer_info_fixedwing_copter.Panel1.SuspendLayout();
            this.splitContainer_info_fixedwing_copter.Panel2.SuspendLayout();
            this.splitContainer_info_fixedwing_copter.SuspendLayout();
            this.panel_fixedwing_info.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel_copter_info.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_sysinfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tracklog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.contextMenuStripMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGaugesTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStatusTab)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripHud
            // 
            this.contextMenuStripHud.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripHud.Name = "contextMenuStripHud";
            this.contextMenuStripHud.Size = new System.Drawing.Size(61, 4);
            // 
            // splitContainer_main_map
            // 
            this.splitContainer_main_map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_main_map.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_main_map.Name = "splitContainer_main_map";
            // 
            // splitContainer_main_map.Panel1
            // 
            this.splitContainer_main_map.Panel1.Controls.Add(this.splitContainer_main_left);
            this.splitContainer_main_map.Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitContainer_main_map.Panel2
            // 
            this.splitContainer_main_map.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer_main_map.Size = new System.Drawing.Size(1366, 768);
            this.splitContainer_main_map.SplitterDistance = 737;
            this.splitContainer_main_map.TabIndex = 79;
            // 
            // splitContainer_main_left
            // 
            this.splitContainer_main_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_main_left.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_main_left.Name = "splitContainer_main_left";
            this.splitContainer_main_left.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_main_left.Panel1
            // 
            this.splitContainer_main_left.Panel1.Controls.Add(this.splitContainer_3dview_hud);
            // 
            // splitContainer_main_left.Panel2
            // 
            this.splitContainer_main_left.Panel2.Controls.Add(this.splitContainer_opr_logplayer);
            this.splitContainer_main_left.Panel2.Controls.Add(this.panel1);
            this.splitContainer_main_left.Size = new System.Drawing.Size(737, 768);
            this.splitContainer_main_left.SplitterDistance = 311;
            this.splitContainer_main_left.TabIndex = 81;
            // 
            // splitContainer_3dview_hud
            // 
            this.splitContainer_3dview_hud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_3dview_hud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_3dview_hud.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_3dview_hud.Name = "splitContainer_3dview_hud";
            // 
            // splitContainer_3dview_hud.Panel1
            // 
            this.splitContainer_3dview_hud.Panel1.Controls.Add(this.splitContainer_3dview_msg);
            this.splitContainer_3dview_hud.Panel1.Resize += new System.EventHandler(this.splitContainer5_Panel1_Resize);
            // 
            // splitContainer_3dview_hud.Panel2
            // 
            this.splitContainer_3dview_hud.Panel2.Controls.Add(this.hud2);
            this.splitContainer_3dview_hud.Size = new System.Drawing.Size(737, 311);
            this.splitContainer_3dview_hud.SplitterDistance = 358;
            this.splitContainer_3dview_hud.TabIndex = 6;
            // 
            // splitContainer_3dview_msg
            // 
            this.splitContainer_3dview_msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_3dview_msg.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_3dview_msg.Name = "splitContainer_3dview_msg";
            this.splitContainer_3dview_msg.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_3dview_msg.Panel1
            // 
            this.splitContainer_3dview_msg.Panel1.Controls.Add(this._3DMesh1);
            this.splitContainer_3dview_msg.Size = new System.Drawing.Size(356, 309);
            this.splitContainer_3dview_msg.SplitterDistance = 239;
            this.splitContainer_3dview_msg.TabIndex = 0;
            // 
            // _3DMesh1
            // 
            this._3DMesh1.aileron_l = ((ushort)(0));
            this._3DMesh1.aileron_r = ((ushort)(0));
            this._3DMesh1.AutoSize = true;
            this._3DMesh1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this._3DMesh1.BackColor = System.Drawing.Color.Aqua;
            this._3DMesh1.DataBindings.Add(new System.Windows.Forms.Binding("heading", this.bindingSourceHud, "yaw", true));
            this._3DMesh1.DataBindings.Add(new System.Windows.Forms.Binding("pitch", this.bindingSourceHud, "pitch", true));
            this._3DMesh1.DataBindings.Add(new System.Windows.Forms.Binding("roll", this.bindingSourceHud, "roll", true));
            this._3DMesh1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._3DMesh1.heading = 0F;
            this._3DMesh1.Location = new System.Drawing.Point(0, 0);
            this._3DMesh1.Name = "_3DMesh1";
            this._3DMesh1.pitch = 0F;
            this._3DMesh1.roll = 0F;
            this._3DMesh1.Size = new System.Drawing.Size(356, 239);
            this._3DMesh1.TabIndex = 2;
            this._3DMesh1.VSync = false;
            this._3DMesh1.Load += new System.EventHandler(this._3DMesh1_Load);
            // 
            // bindingSourceHud
            // 
            this.bindingSourceHud.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // hud2
            // 
            this.hud2.airspeed = 0F;
            this.hud2.alt = 0F;
            this.hud2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.hud2.BackColor = System.Drawing.Color.Black;
            this.hud2.batterylevel = 0F;
            this.hud2.batteryremaining = 0F;
            this.hud2.bgimage = null;
            this.hud2.connected = false;
            this.hud2.ContextMenuStrip = this.contextMenuStripHud;
            this.hud2.current = 0F;
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("airspeed", this.bindingSourceHud, "airspeed", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("alt", this.bindingSourceHud, "alt", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("batterylevel", this.bindingSourceHud, "battery_voltage", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("batteryremaining", this.bindingSourceHud, "battery_remaining", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("connected", this.bindingSourceHud, "connected", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("current", this.bindingSourceHud, "current", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("datetime", this.bindingSourceHud, "datetime", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("disttowp", this.bindingSourceHud, "wp_dist", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("failsafe", this.bindingSourceHud, "failsafe", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("gpsfix", this.bindingSourceHud, "gpsstatus", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("gpshdop", this.bindingSourceHud, "gpshdop", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("groundalt", this.bindingSourceHud, "HomeAlt", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("groundcourse", this.bindingSourceHud, "groundcourse", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("groundspeed", this.bindingSourceHud, "groundspeed", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("heading", this.bindingSourceHud, "yaw", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("linkqualitygcs", this.bindingSourceHud, "linkqualitygcs", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("message", this.bindingSourceHud, "messageHigh", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("messagetime", this.bindingSourceHud, "messageHighTime", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("mode", this.bindingSourceHud, "mode", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("navpitch", this.bindingSourceHud, "nav_pitch", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("navroll", this.bindingSourceHud, "nav_roll", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("pitch", this.bindingSourceHud, "pitch", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("roll", this.bindingSourceHud, "roll", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("status", this.bindingSourceHud, "armed", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("targetalt", this.bindingSourceHud, "targetalt", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("targetheading", this.bindingSourceHud, "nav_bearing", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("targetspeed", this.bindingSourceHud, "targetairspeed", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("turnrate", this.bindingSourceHud, "turnrate", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("verticalspeed", this.bindingSourceHud, "verticalspeed", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("wpno", this.bindingSourceHud, "wpno", true));
            this.hud2.DataBindings.Add(new System.Windows.Forms.Binding("xtrack_error", this.bindingSourceHud, "xtrack_error", true));
            this.hud2.datetime = new System.DateTime(((long)(0)));
            this.hud2.displayekf = false;
            this.hud2.displayvibe = false;
            this.hud2.disttowp = 0F;
            this.hud2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hud2.ekfstatus = 0F;
            this.hud2.failsafe = false;
            this.hud2.gpsfix = 0F;
            this.hud2.gpsfix2 = 0F;
            this.hud2.gpshdop = 0F;
            this.hud2.gpshdop2 = 0F;
            this.hud2.groundalt = 0F;
            this.hud2.groundcourse = 0F;
            this.hud2.groundspeed = 0F;
            this.hud2.heading = 0F;
            this.hud2.hudcolor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(241)))), ((int)(((byte)(30)))));
            this.hud2.linkqualitygcs = 0F;
            this.hud2.Location = new System.Drawing.Point(0, 0);
            this.hud2.lowairspeed = false;
            this.hud2.lowgroundspeed = false;
            this.hud2.lowvoltagealert = false;
            this.hud2.Margin = new System.Windows.Forms.Padding(4);
            this.hud2.message = "";
            this.hud2.messagetime = new System.DateTime(((long)(0)));
            this.hud2.mode = "未知";
            this.hud2.Name = "hud2";
            this.hud2.navpitch = 0F;
            this.hud2.navroll = 0F;
            this.hud2.opengl = false;
            this.hud2.pitch = 0F;
            this.hud2.roll = 0F;
            this.hud2.Russian = false;
            this.hud2.Size = new System.Drawing.Size(373, 309);
            this.hud2.status = false;
            this.hud2.streamjpg = null;
            this.hud2.TabIndex = 4;
            this.hud2.targetalt = 0F;
            this.hud2.targetheading = 0F;
            this.hud2.targetspeed = 0F;
            this.hud2.turnrate = 0F;
            this.hud2.UseOpenGL = false;
            this.hud2.verticalspeed = 0F;
            this.hud2.vibex = 0F;
            this.hud2.vibey = 0F;
            this.hud2.vibez = 0F;
            this.hud2.VSync = false;
            this.hud2.wpno = 0;
            this.hud2.xtrack_error = 0F;
            // 
            // splitContainer_opr_logplayer
            // 
            this.splitContainer_opr_logplayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_opr_logplayer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_opr_logplayer.Name = "splitContainer_opr_logplayer";
            this.splitContainer_opr_logplayer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_opr_logplayer.Panel1
            // 
            this.splitContainer_opr_logplayer.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer_opr_logplayer.Panel2
            // 
            this.splitContainer_opr_logplayer.Panel2.Controls.Add(this.lblrepl_replay_speed);
            this.splitContainer_opr_logplayer.Panel2.Controls.Add(this.CMB_playspeed);
            this.splitContainer_opr_logplayer.Panel2.Controls.Add(this.lblrepl_logpercent);
            this.splitContainer_opr_logplayer.Panel2.Controls.Add(this.tracklog);
            this.splitContainer_opr_logplayer.Panel2.Controls.Add(this.BUT_playlog);
            this.splitContainer_opr_logplayer.Panel2.Controls.Add(this.BUT_loadtelem);
            this.splitContainer_opr_logplayer.Panel2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer_opr_logplayer.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainer_opr_logplayer.Size = new System.Drawing.Size(737, 453);
            this.splitContainer_opr_logplayer.SplitterDistance = 389;
            this.splitContainer_opr_logplayer.TabIndex = 84;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer_info_system_more);
            this.splitContainer4.Panel1.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.lblbtn_set_target_wp);
            this.splitContainer4.Panel2.Controls.Add(this.btn_force_disarm);
            this.splitContainer4.Panel2.Controls.Add(this.BUT_ARM);
            this.splitContainer4.Panel2.Controls.Add(this.BUT_parachute);
            this.splitContainer4.Panel2.Controls.Add(this.BUT_standby);
            this.splitContainer4.Panel2.Controls.Add(this.BUT_camera);
            this.splitContainer4.Panel2.Controls.Add(this.BUT_clear_track);
            this.splitContainer4.Panel2.Controls.Add(this.CMB_setwp);
            this.splitContainer4.Panel2.Controls.Add(this.BUTrestartmission);
            this.splitContainer4.Panel2.Controls.Add(this.BUT_quickrtl);
            this.splitContainer4.Panel2.Controls.Add(this.BUT_quickauto);
            this.splitContainer4.Panel2.Resize += new System.EventHandler(this.splitContainer4_Panel2_Resize);
            this.splitContainer4.Size = new System.Drawing.Size(737, 389);
            this.splitContainer4.SplitterDistance = 242;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer_info_system_more
            // 
            this.splitContainer_info_system_more.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_info_system_more.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_info_system_more.Name = "splitContainer_info_system_more";
            // 
            // splitContainer_info_system_more.Panel1
            // 
            this.splitContainer_info_system_more.Panel1.Controls.Add(this.splitContainer_info_fixedwing_copter);
            // 
            // splitContainer_info_system_more.Panel2
            // 
            this.splitContainer_info_system_more.Panel2.Controls.Add(this.panel_sysinfo);
            this.splitContainer_info_system_more.Size = new System.Drawing.Size(737, 242);
            this.splitContainer_info_system_more.SplitterDistance = 356;
            this.splitContainer_info_system_more.TabIndex = 0;
            // 
            // splitContainer_info_fixedwing_copter
            // 
            this.splitContainer_info_fixedwing_copter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_info_fixedwing_copter.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_info_fixedwing_copter.Name = "splitContainer_info_fixedwing_copter";
            this.splitContainer_info_fixedwing_copter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_info_fixedwing_copter.Panel1
            // 
            this.splitContainer_info_fixedwing_copter.Panel1.Controls.Add(this.panel_fixedwing_info);
            // 
            // splitContainer_info_fixedwing_copter.Panel2
            // 
            this.splitContainer_info_fixedwing_copter.Panel2.Controls.Add(this.panel_copter_info);
            this.splitContainer_info_fixedwing_copter.Size = new System.Drawing.Size(356, 242);
            this.splitContainer_info_fixedwing_copter.SplitterDistance = 116;
            this.splitContainer_info_fixedwing_copter.TabIndex = 1;
            // 
            // panel_fixedwing_info
            // 
            this.panel_fixedwing_info.AssociatedSplitter = null;
            this.panel_fixedwing_info.BackColor = System.Drawing.Color.Transparent;
            this.panel_fixedwing_info.CaptionFont = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold);
            this.panel_fixedwing_info.CaptionHeight = 27;
            this.panel_fixedwing_info.ColorScheme = BSE.Windows.Forms.ColorScheme.Custom;
            this.panel_fixedwing_info.Controls.Add(this.tableLayoutPanel3);
            this.panel_fixedwing_info.CustomColors.BorderColor = System.Drawing.Color.Silver;
            this.panel_fixedwing_info.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panel_fixedwing_info.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel_fixedwing_info.CustomColors.CaptionGradientBegin = System.Drawing.Color.DodgerBlue;
            this.panel_fixedwing_info.CustomColors.CaptionGradientEnd = System.Drawing.Color.DodgerBlue;
            this.panel_fixedwing_info.CustomColors.CaptionGradientMiddle = System.Drawing.Color.Transparent;
            this.panel_fixedwing_info.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel_fixedwing_info.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel_fixedwing_info.CustomColors.CaptionText = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_fixedwing_info.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_fixedwing_info.CustomColors.ContentGradientBegin = System.Drawing.Color.Transparent;
            this.panel_fixedwing_info.CustomColors.ContentGradientEnd = System.Drawing.Color.Transparent;
            this.panel_fixedwing_info.CustomColors.InnerBorderColor = System.Drawing.Color.Transparent;
            this.panel_fixedwing_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_fixedwing_info.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_fixedwing_info.Image = null;
            this.panel_fixedwing_info.Location = new System.Drawing.Point(0, 0);
            this.panel_fixedwing_info.MinimumSize = new System.Drawing.Size(27, 27);
            this.panel_fixedwing_info.Name = "panel_fixedwing_info";
            this.panel_fixedwing_info.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.panel_fixedwing_info.Size = new System.Drawing.Size(356, 116);
            this.panel_fixedwing_info.TabIndex = 161;
            this.panel_fixedwing_info.Text = "固定翼系统";
            this.panel_fixedwing_info.ToolTipTextCloseIcon = null;
            this.panel_fixedwing_info.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel_fixedwing_info.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.lbl_fw_voltage, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.val_timeinair, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.val_fw_mah_used, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_fw_mah_used, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.val_traveled_km, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbl_traveled_km, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.val_fw_current, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.val_fw_voltage, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_fw_current, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_fw_timeinair, 2, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 28);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(354, 87);
            this.tableLayoutPanel3.TabIndex = 157;
            // 
            // lbl_fw_voltage
            // 
            this.lbl_fw_voltage.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_fw_voltage.Location = new System.Drawing.Point(3, 0);
            this.lbl_fw_voltage.Name = "lbl_fw_voltage";
            this.lbl_fw_voltage.Size = new System.Drawing.Size(82, 23);
            this.lbl_fw_voltage.TabIndex = 71;
            this.lbl_fw_voltage.Text = "电压：";
            this.lbl_fw_voltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_timeinair
            // 
            this.val_timeinair.ContextMenuStrip = this.contextMenuStripHud;
            this.val_timeinair.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_timeinair.Location = new System.Drawing.Point(267, 58);
            this.val_timeinair.Name = "val_timeinair";
            this.val_timeinair.Size = new System.Drawing.Size(84, 23);
            this.val_timeinair.TabIndex = 156;
            this.val_timeinair.Text = "0";
            // 
            // val_fw_mah_used
            // 
            this.val_fw_mah_used.ContextMenuStrip = this.contextMenuStripHud;
            this.val_fw_mah_used.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "battery_usedmah", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_fw_mah_used.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_fw_mah_used.Location = new System.Drawing.Point(91, 29);
            this.val_fw_mah_used.Name = "val_fw_mah_used";
            this.val_fw_mah_used.Size = new System.Drawing.Size(82, 23);
            this.val_fw_mah_used.TabIndex = 152;
            this.val_fw_mah_used.Text = "0";
            // 
            // lbl_fw_mah_used
            // 
            this.lbl_fw_mah_used.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_fw_mah_used.Location = new System.Drawing.Point(3, 29);
            this.lbl_fw_mah_used.Name = "lbl_fw_mah_used";
            this.lbl_fw_mah_used.Size = new System.Drawing.Size(82, 23);
            this.lbl_fw_mah_used.TabIndex = 151;
            this.lbl_fw_mah_used.Text = "耗电(mAh)：";
            this.lbl_fw_mah_used.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_traveled_km
            // 
            this.val_traveled_km.ContextMenuStrip = this.contextMenuStripHud;
            this.val_traveled_km.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_traveled_km.Location = new System.Drawing.Point(91, 58);
            this.val_traveled_km.Name = "val_traveled_km";
            this.val_traveled_km.Size = new System.Drawing.Size(82, 23);
            this.val_traveled_km.TabIndex = 154;
            this.val_traveled_km.Text = "0";
            // 
            // lbl_traveled_km
            // 
            this.lbl_traveled_km.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_traveled_km.Location = new System.Drawing.Point(3, 58);
            this.lbl_traveled_km.Name = "lbl_traveled_km";
            this.lbl_traveled_km.Size = new System.Drawing.Size(82, 23);
            this.lbl_traveled_km.TabIndex = 153;
            this.lbl_traveled_km.Text = "里程：";
            this.lbl_traveled_km.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_fw_current
            // 
            this.val_fw_current.ContextMenuStrip = this.contextMenuStripHud;
            this.val_fw_current.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "current", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_fw_current.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_fw_current.Location = new System.Drawing.Point(267, 0);
            this.val_fw_current.Name = "val_fw_current";
            this.val_fw_current.Size = new System.Drawing.Size(84, 23);
            this.val_fw_current.TabIndex = 74;
            this.val_fw_current.Text = "0";
            // 
            // val_fw_voltage
            // 
            this.val_fw_voltage.ContextMenuStrip = this.contextMenuStripHud;
            this.val_fw_voltage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "battery_voltage", true));
            this.val_fw_voltage.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_fw_voltage.Location = new System.Drawing.Point(91, 0);
            this.val_fw_voltage.Name = "val_fw_voltage";
            this.val_fw_voltage.Size = new System.Drawing.Size(82, 23);
            this.val_fw_voltage.TabIndex = 72;
            this.val_fw_voltage.Text = "0";
            // 
            // lbl_fw_current
            // 
            this.lbl_fw_current.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_fw_current.Location = new System.Drawing.Point(179, 0);
            this.lbl_fw_current.Name = "lbl_fw_current";
            this.lbl_fw_current.Size = new System.Drawing.Size(82, 23);
            this.lbl_fw_current.TabIndex = 73;
            this.lbl_fw_current.Text = "电流：";
            this.lbl_fw_current.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_fw_timeinair
            // 
            this.lbl_fw_timeinair.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_fw_timeinair.Location = new System.Drawing.Point(179, 58);
            this.lbl_fw_timeinair.Name = "lbl_fw_timeinair";
            this.lbl_fw_timeinair.Size = new System.Drawing.Size(82, 23);
            this.lbl_fw_timeinair.TabIndex = 155;
            this.lbl_fw_timeinair.Text = "飞行时间：";
            this.lbl_fw_timeinair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel_copter_info
            // 
            this.panel_copter_info.AssociatedSplitter = null;
            this.panel_copter_info.BackColor = System.Drawing.Color.Transparent;
            this.panel_copter_info.CaptionFont = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold);
            this.panel_copter_info.CaptionHeight = 27;
            this.panel_copter_info.ColorScheme = BSE.Windows.Forms.ColorScheme.Custom;
            this.panel_copter_info.Controls.Add(this.tableLayoutPanel1);
            this.panel_copter_info.CustomColors.BorderColor = System.Drawing.Color.Silver;
            this.panel_copter_info.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panel_copter_info.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel_copter_info.CustomColors.CaptionGradientBegin = System.Drawing.Color.DarkViolet;
            this.panel_copter_info.CustomColors.CaptionGradientEnd = System.Drawing.Color.DarkViolet;
            this.panel_copter_info.CustomColors.CaptionGradientMiddle = System.Drawing.Color.Transparent;
            this.panel_copter_info.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel_copter_info.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel_copter_info.CustomColors.CaptionText = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_copter_info.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_copter_info.CustomColors.ContentGradientBegin = System.Drawing.Color.Transparent;
            this.panel_copter_info.CustomColors.ContentGradientEnd = System.Drawing.Color.Transparent;
            this.panel_copter_info.CustomColors.InnerBorderColor = System.Drawing.Color.Transparent;
            this.panel_copter_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_copter_info.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_copter_info.Image = null;
            this.panel_copter_info.Location = new System.Drawing.Point(0, 0);
            this.panel_copter_info.MinimumSize = new System.Drawing.Size(27, 27);
            this.panel_copter_info.Name = "panel_copter_info";
            this.panel_copter_info.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.panel_copter_info.Size = new System.Drawing.Size(356, 122);
            this.panel_copter_info.TabIndex = 163;
            this.panel_copter_info.Text = "多旋翼系统";
            this.panel_copter_info.ToolTipTextCloseIcon = null;
            this.panel_copter_info.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel_copter_info.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_quad_voltage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.val_quadbat_time, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.val_quad_voltage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_quadbat_time, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.val_quad_mah_used, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_quad_current, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_quad_mah_used, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.val_quad_current, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 93);
            this.tableLayoutPanel1.TabIndex = 165;
            // 
            // lbl_quad_voltage
            // 
            this.lbl_quad_voltage.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_quad_voltage.Location = new System.Drawing.Point(3, 0);
            this.lbl_quad_voltage.Name = "lbl_quad_voltage";
            this.lbl_quad_voltage.Size = new System.Drawing.Size(82, 23);
            this.lbl_quad_voltage.TabIndex = 71;
            this.lbl_quad_voltage.Text = "电压：";
            this.lbl_quad_voltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_quadbat_time
            // 
            this.val_quadbat_time.ContextMenuStrip = this.contextMenuStripHud;
            this.val_quadbat_time.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_quadbat_time.Location = new System.Drawing.Point(91, 62);
            this.val_quadbat_time.Name = "val_quadbat_time";
            this.val_quadbat_time.Size = new System.Drawing.Size(82, 23);
            this.val_quadbat_time.TabIndex = 164;
            this.val_quadbat_time.Text = "0";
            // 
            // val_quad_voltage
            // 
            this.val_quad_voltage.ContextMenuStrip = this.contextMenuStripHud;
            this.val_quad_voltage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "battery_voltage2", true));
            this.val_quad_voltage.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_quad_voltage.Location = new System.Drawing.Point(91, 0);
            this.val_quad_voltage.Name = "val_quad_voltage";
            this.val_quad_voltage.Size = new System.Drawing.Size(82, 23);
            this.val_quad_voltage.TabIndex = 158;
            this.val_quad_voltage.Text = "0";
            // 
            // lbl_quadbat_time
            // 
            this.lbl_quadbat_time.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_quadbat_time.Location = new System.Drawing.Point(3, 62);
            this.lbl_quadbat_time.Name = "lbl_quadbat_time";
            this.lbl_quadbat_time.Size = new System.Drawing.Size(82, 23);
            this.lbl_quadbat_time.TabIndex = 155;
            this.lbl_quadbat_time.Text = "飞行时间：";
            this.lbl_quadbat_time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_quad_mah_used
            // 
            this.val_quad_mah_used.ContextMenuStrip = this.contextMenuStripHud;
            this.val_quad_mah_used.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "battery2_usedmah", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_quad_mah_used.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_quad_mah_used.Location = new System.Drawing.Point(91, 31);
            this.val_quad_mah_used.Name = "val_quad_mah_used";
            this.val_quad_mah_used.Size = new System.Drawing.Size(82, 23);
            this.val_quad_mah_used.TabIndex = 162;
            this.val_quad_mah_used.Text = "0";
            // 
            // lbl_quad_current
            // 
            this.lbl_quad_current.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_quad_current.Location = new System.Drawing.Point(179, 0);
            this.lbl_quad_current.Name = "lbl_quad_current";
            this.lbl_quad_current.Size = new System.Drawing.Size(82, 23);
            this.lbl_quad_current.TabIndex = 73;
            this.lbl_quad_current.Text = "电流：";
            this.lbl_quad_current.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_quad_mah_used
            // 
            this.lbl_quad_mah_used.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_quad_mah_used.Location = new System.Drawing.Point(3, 31);
            this.lbl_quad_mah_used.Name = "lbl_quad_mah_used";
            this.lbl_quad_mah_used.Size = new System.Drawing.Size(82, 23);
            this.lbl_quad_mah_used.TabIndex = 151;
            this.lbl_quad_mah_used.Text = "耗电(mAh)：";
            this.lbl_quad_mah_used.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_quad_current
            // 
            this.val_quad_current.ContextMenuStrip = this.contextMenuStripHud;
            this.val_quad_current.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "current2", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_quad_current.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_quad_current.Location = new System.Drawing.Point(267, 0);
            this.val_quad_current.Name = "val_quad_current";
            this.val_quad_current.Size = new System.Drawing.Size(84, 23);
            this.val_quad_current.TabIndex = 160;
            this.val_quad_current.Text = "0";
            // 
            // panel_sysinfo
            // 
            this.panel_sysinfo.AssociatedSplitter = null;
            this.panel_sysinfo.BackColor = System.Drawing.Color.Transparent;
            this.panel_sysinfo.CaptionFont = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold);
            this.panel_sysinfo.CaptionHeight = 27;
            this.panel_sysinfo.ColorScheme = BSE.Windows.Forms.ColorScheme.Custom;
            this.panel_sysinfo.Controls.Add(this.tableLayoutPanel2);
            this.panel_sysinfo.CustomColors.BorderColor = System.Drawing.Color.Silver;
            this.panel_sysinfo.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panel_sysinfo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel_sysinfo.CustomColors.CaptionGradientBegin = System.Drawing.Color.Green;
            this.panel_sysinfo.CustomColors.CaptionGradientEnd = System.Drawing.Color.Green;
            this.panel_sysinfo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.Transparent;
            this.panel_sysinfo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel_sysinfo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel_sysinfo.CustomColors.CaptionText = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_sysinfo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_sysinfo.CustomColors.ContentGradientBegin = System.Drawing.Color.Transparent;
            this.panel_sysinfo.CustomColors.ContentGradientEnd = System.Drawing.Color.Transparent;
            this.panel_sysinfo.CustomColors.InnerBorderColor = System.Drawing.Color.Transparent;
            this.panel_sysinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_sysinfo.ForeColor = System.Drawing.Color.Lime;
            this.panel_sysinfo.Image = null;
            this.panel_sysinfo.Location = new System.Drawing.Point(0, 0);
            this.panel_sysinfo.MinimumSize = new System.Drawing.Size(27, 27);
            this.panel_sysinfo.Name = "panel_sysinfo";
            this.panel_sysinfo.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.panel_sysinfo.Size = new System.Drawing.Size(377, 242);
            this.panel_sysinfo.TabIndex = 160;
            this.panel_sysinfo.Text = "飞行状态";
            this.panel_sysinfo.ToolTipTextCloseIcon = null;
            this.panel_sysinfo.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel_sysinfo.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_mode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.val_cam_num, 5, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl_cam_num, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.val_alt_error, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl_alt_error, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.val_target_wp, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl_target_wp, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.val_gps_ground_vel, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.val_compass, 5, 4);
            this.tableLayoutPanel2.Controls.Add(this.val_xtrack_error, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl_xtrack_error, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl_sat_count, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.val_latitude, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.val_gps_mode, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbl_gps_mode, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbl_compass, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.lbl_longtitude, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.val_sat_count, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbl_latitude, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.val_longitude, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lbl_alt, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl_gps_ground_vel, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.val_airspeed_error, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.val_alt_target, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.val_mode, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_alt_target, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl_throttle, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.val_throttle, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_airspeed, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.val_alt, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.val_airspeed, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_airspeed_target, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.val_airspeed_target, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_airspeed_error, 4, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(375, 213);
            this.tableLayoutPanel2.TabIndex = 167;
            // 
            // lbl_mode
            // 
            this.lbl_mode.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_mode.Location = new System.Drawing.Point(3, 0);
            this.lbl_mode.Name = "lbl_mode";
            this.lbl_mode.Size = new System.Drawing.Size(56, 23);
            this.lbl_mode.TabIndex = 89;
            this.lbl_mode.Text = "模式：";
            this.lbl_mode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_cam_num
            // 
            this.val_cam_num.ContextMenuStrip = this.contextMenuStripHud;
            this.val_cam_num.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "triggernum", true));
            this.val_cam_num.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_cam_num.Location = new System.Drawing.Point(313, 175);
            this.val_cam_num.Name = "val_cam_num";
            this.val_cam_num.Size = new System.Drawing.Size(59, 23);
            this.val_cam_num.TabIndex = 166;
            this.val_cam_num.Text = "0";
            // 
            // lbl_cam_num
            // 
            this.lbl_cam_num.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_cam_num.Location = new System.Drawing.Point(251, 175);
            this.lbl_cam_num.Name = "lbl_cam_num";
            this.lbl_cam_num.Size = new System.Drawing.Size(56, 23);
            this.lbl_cam_num.TabIndex = 165;
            this.lbl_cam_num.Text = "拍照数：";
            this.lbl_cam_num.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_alt_error
            // 
            this.val_alt_error.ContextMenuStrip = this.contextMenuStripHud;
            this.val_alt_error.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "alt_error", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_alt_error.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_alt_error.Location = new System.Drawing.Point(313, 70);
            this.val_alt_error.Name = "val_alt_error";
            this.val_alt_error.Size = new System.Drawing.Size(59, 23);
            this.val_alt_error.TabIndex = 134;
            this.val_alt_error.Text = "0";
            // 
            // lbl_alt_error
            // 
            this.lbl_alt_error.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_alt_error.Location = new System.Drawing.Point(251, 70);
            this.lbl_alt_error.Name = "lbl_alt_error";
            this.lbl_alt_error.Size = new System.Drawing.Size(56, 23);
            this.lbl_alt_error.TabIndex = 133;
            this.lbl_alt_error.Tag = "r-3";
            this.lbl_alt_error.Text = "高度差：";
            this.lbl_alt_error.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_target_wp
            // 
            this.val_target_wp.ContextMenuStrip = this.contextMenuStripHud;
            this.val_target_wp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "wpno", true));
            this.val_target_wp.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_target_wp.Location = new System.Drawing.Point(189, 175);
            this.val_target_wp.Name = "val_target_wp";
            this.val_target_wp.Size = new System.Drawing.Size(56, 23);
            this.val_target_wp.TabIndex = 136;
            this.val_target_wp.Text = "0";
            // 
            // lbl_target_wp
            // 
            this.lbl_target_wp.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_target_wp.Location = new System.Drawing.Point(127, 175);
            this.lbl_target_wp.Name = "lbl_target_wp";
            this.lbl_target_wp.Size = new System.Drawing.Size(56, 23);
            this.lbl_target_wp.TabIndex = 135;
            this.lbl_target_wp.Text = "目标点：";
            this.lbl_target_wp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_gps_ground_vel
            // 
            this.val_gps_ground_vel.ContextMenuStrip = this.contextMenuStripHud;
            this.val_gps_ground_vel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "groundspeed", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_gps_ground_vel.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_gps_ground_vel.Location = new System.Drawing.Point(313, 105);
            this.val_gps_ground_vel.Name = "val_gps_ground_vel";
            this.val_gps_ground_vel.Size = new System.Drawing.Size(59, 23);
            this.val_gps_ground_vel.TabIndex = 76;
            this.val_gps_ground_vel.Text = "0";
            // 
            // val_compass
            // 
            this.val_compass.ContextMenuStrip = this.contextMenuStripHud;
            this.val_compass.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "yaw", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_compass.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_compass.Location = new System.Drawing.Point(313, 140);
            this.val_compass.Name = "val_compass";
            this.val_compass.Size = new System.Drawing.Size(59, 23);
            this.val_compass.TabIndex = 88;
            this.val_compass.Text = "0";
            // 
            // val_xtrack_error
            // 
            this.val_xtrack_error.ContextMenuStrip = this.contextMenuStripHud;
            this.val_xtrack_error.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "xtrack_error", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_xtrack_error.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_xtrack_error.Location = new System.Drawing.Point(65, 175);
            this.val_xtrack_error.Name = "val_xtrack_error";
            this.val_xtrack_error.Size = new System.Drawing.Size(56, 23);
            this.val_xtrack_error.TabIndex = 82;
            this.val_xtrack_error.Text = "0";
            // 
            // lbl_xtrack_error
            // 
            this.lbl_xtrack_error.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_xtrack_error.Location = new System.Drawing.Point(3, 175);
            this.lbl_xtrack_error.Name = "lbl_xtrack_error";
            this.lbl_xtrack_error.Size = new System.Drawing.Size(56, 23);
            this.lbl_xtrack_error.TabIndex = 81;
            this.lbl_xtrack_error.Text = "偏航距(m)：";
            this.lbl_xtrack_error.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_sat_count
            // 
            this.lbl_sat_count.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_sat_count.Location = new System.Drawing.Point(127, 105);
            this.lbl_sat_count.Name = "lbl_sat_count";
            this.lbl_sat_count.Size = new System.Drawing.Size(56, 23);
            this.lbl_sat_count.TabIndex = 85;
            this.lbl_sat_count.Text = "星数：";
            this.lbl_sat_count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_latitude
            // 
            this.val_latitude.ContextMenuStrip = this.contextMenuStripHud;
            this.val_latitude.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "lat", true));
            this.val_latitude.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_latitude.Location = new System.Drawing.Point(189, 140);
            this.val_latitude.Name = "val_latitude";
            this.val_latitude.Size = new System.Drawing.Size(56, 23);
            this.val_latitude.TabIndex = 98;
            this.val_latitude.Text = "0";
            // 
            // val_gps_mode
            // 
            this.val_gps_mode.ContextMenuStrip = this.contextMenuStripHud;
            this.val_gps_mode.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_gps_mode.Location = new System.Drawing.Point(65, 105);
            this.val_gps_mode.Name = "val_gps_mode";
            this.val_gps_mode.Size = new System.Drawing.Size(56, 23);
            this.val_gps_mode.TabIndex = 138;
            this.val_gps_mode.Text = "0";
            // 
            // lbl_gps_mode
            // 
            this.lbl_gps_mode.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_gps_mode.Location = new System.Drawing.Point(3, 105);
            this.lbl_gps_mode.Name = "lbl_gps_mode";
            this.lbl_gps_mode.Size = new System.Drawing.Size(56, 23);
            this.lbl_gps_mode.TabIndex = 137;
            this.lbl_gps_mode.Text = "GPS状态：";
            this.lbl_gps_mode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_compass
            // 
            this.lbl_compass.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_compass.Location = new System.Drawing.Point(251, 140);
            this.lbl_compass.Name = "lbl_compass";
            this.lbl_compass.Size = new System.Drawing.Size(56, 23);
            this.lbl_compass.TabIndex = 87;
            this.lbl_compass.Tag = "r-3";
            this.lbl_compass.Text = "罗盘：";
            this.lbl_compass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_longtitude
            // 
            this.lbl_longtitude.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_longtitude.Location = new System.Drawing.Point(3, 140);
            this.lbl_longtitude.Name = "lbl_longtitude";
            this.lbl_longtitude.Size = new System.Drawing.Size(56, 23);
            this.lbl_longtitude.TabIndex = 95;
            this.lbl_longtitude.Text = "经度：";
            this.lbl_longtitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_sat_count
            // 
            this.val_sat_count.ContextMenuStrip = this.contextMenuStripHud;
            this.val_sat_count.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "satcount", true));
            this.val_sat_count.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_sat_count.Location = new System.Drawing.Point(189, 105);
            this.val_sat_count.Name = "val_sat_count";
            this.val_sat_count.Size = new System.Drawing.Size(56, 23);
            this.val_sat_count.TabIndex = 86;
            this.val_sat_count.Text = "0";
            // 
            // lbl_latitude
            // 
            this.lbl_latitude.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_latitude.Location = new System.Drawing.Point(127, 140);
            this.lbl_latitude.Name = "lbl_latitude";
            this.lbl_latitude.Size = new System.Drawing.Size(56, 23);
            this.lbl_latitude.TabIndex = 97;
            this.lbl_latitude.Text = "纬度：";
            this.lbl_latitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_longitude
            // 
            this.val_longitude.ContextMenuStrip = this.contextMenuStripHud;
            this.val_longitude.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "lng", true));
            this.val_longitude.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_longitude.Location = new System.Drawing.Point(65, 140);
            this.val_longitude.Name = "val_longitude";
            this.val_longitude.Size = new System.Drawing.Size(56, 23);
            this.val_longitude.TabIndex = 96;
            this.val_longitude.Text = "0";
            // 
            // lbl_alt
            // 
            this.lbl_alt.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_alt.Location = new System.Drawing.Point(3, 70);
            this.lbl_alt.Name = "lbl_alt";
            this.lbl_alt.Size = new System.Drawing.Size(56, 23);
            this.lbl_alt.TabIndex = 79;
            this.lbl_alt.Text = "高度：";
            this.lbl_alt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_gps_ground_vel
            // 
            this.lbl_gps_ground_vel.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_gps_ground_vel.Location = new System.Drawing.Point(251, 105);
            this.lbl_gps_ground_vel.Name = "lbl_gps_ground_vel";
            this.lbl_gps_ground_vel.Size = new System.Drawing.Size(56, 23);
            this.lbl_gps_ground_vel.TabIndex = 75;
            this.lbl_gps_ground_vel.Tag = "r-3";
            this.lbl_gps_ground_vel.Text = "GPS地速：";
            this.lbl_gps_ground_vel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_airspeed_error
            // 
            this.val_airspeed_error.ContextMenuStrip = this.contextMenuStripHud;
            this.val_airspeed_error.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "aspd_error", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_airspeed_error.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_airspeed_error.Location = new System.Drawing.Point(313, 35);
            this.val_airspeed_error.Name = "val_airspeed_error";
            this.val_airspeed_error.Size = new System.Drawing.Size(59, 23);
            this.val_airspeed_error.TabIndex = 132;
            this.val_airspeed_error.Text = "0";
            // 
            // val_alt_target
            // 
            this.val_alt_target.ContextMenuStrip = this.contextMenuStripHud;
            this.val_alt_target.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "targetalt", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_alt_target.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_alt_target.Location = new System.Drawing.Point(189, 70);
            this.val_alt_target.Name = "val_alt_target";
            this.val_alt_target.Size = new System.Drawing.Size(56, 23);
            this.val_alt_target.TabIndex = 92;
            this.val_alt_target.Text = "0";
            // 
            // val_mode
            // 
            this.val_mode.ContextMenuStrip = this.contextMenuStripHud;
            this.val_mode.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_mode.Location = new System.Drawing.Point(65, 0);
            this.val_mode.Name = "val_mode";
            this.val_mode.Size = new System.Drawing.Size(56, 23);
            this.val_mode.TabIndex = 90;
            this.val_mode.Text = "0";
            // 
            // lbl_alt_target
            // 
            this.lbl_alt_target.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_alt_target.Location = new System.Drawing.Point(127, 70);
            this.lbl_alt_target.Name = "lbl_alt_target";
            this.lbl_alt_target.Size = new System.Drawing.Size(56, 23);
            this.lbl_alt_target.TabIndex = 91;
            this.lbl_alt_target.Text = "目标高度：";
            this.lbl_alt_target.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_throttle
            // 
            this.lbl_throttle.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_throttle.Location = new System.Drawing.Point(127, 0);
            this.lbl_throttle.Name = "lbl_throttle";
            this.lbl_throttle.Size = new System.Drawing.Size(56, 23);
            this.lbl_throttle.TabIndex = 83;
            this.lbl_throttle.Text = "油门：";
            this.lbl_throttle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_throttle
            // 
            this.val_throttle.ContextMenuStrip = this.contextMenuStripHud;
            this.val_throttle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "ch3percent", true));
            this.val_throttle.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_throttle.Location = new System.Drawing.Point(189, 0);
            this.val_throttle.Name = "val_throttle";
            this.val_throttle.Size = new System.Drawing.Size(56, 23);
            this.val_throttle.TabIndex = 84;
            this.val_throttle.Text = "0";
            this.val_throttle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_airspeed
            // 
            this.lbl_airspeed.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_airspeed.Location = new System.Drawing.Point(3, 35);
            this.lbl_airspeed.Name = "lbl_airspeed";
            this.lbl_airspeed.Size = new System.Drawing.Size(56, 23);
            this.lbl_airspeed.TabIndex = 77;
            this.lbl_airspeed.Text = "空速：";
            this.lbl_airspeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_alt
            // 
            this.val_alt.ContextMenuStrip = this.contextMenuStripHud;
            this.val_alt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "alt", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_alt.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_alt.Location = new System.Drawing.Point(65, 70);
            this.val_alt.Name = "val_alt";
            this.val_alt.Size = new System.Drawing.Size(56, 23);
            this.val_alt.TabIndex = 80;
            this.val_alt.Text = "0";
            this.val_alt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // val_airspeed
            // 
            this.val_airspeed.ContextMenuStrip = this.contextMenuStripHud;
            this.val_airspeed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "airspeed", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_airspeed.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_airspeed.Location = new System.Drawing.Point(65, 35);
            this.val_airspeed.Name = "val_airspeed";
            this.val_airspeed.Size = new System.Drawing.Size(56, 23);
            this.val_airspeed.TabIndex = 78;
            this.val_airspeed.Text = "0";
            // 
            // lbl_airspeed_target
            // 
            this.lbl_airspeed_target.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_airspeed_target.Location = new System.Drawing.Point(127, 35);
            this.lbl_airspeed_target.Name = "lbl_airspeed_target";
            this.lbl_airspeed_target.Size = new System.Drawing.Size(56, 23);
            this.lbl_airspeed_target.TabIndex = 93;
            this.lbl_airspeed_target.Text = "目标空速：";
            this.lbl_airspeed_target.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // val_airspeed_target
            // 
            this.val_airspeed_target.ContextMenuStrip = this.contextMenuStripHud;
            this.val_airspeed_target.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "targetairspeed", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.val_airspeed_target.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.val_airspeed_target.Location = new System.Drawing.Point(189, 35);
            this.val_airspeed_target.Name = "val_airspeed_target";
            this.val_airspeed_target.Size = new System.Drawing.Size(56, 23);
            this.val_airspeed_target.TabIndex = 94;
            this.val_airspeed_target.Text = "0";
            // 
            // lbl_airspeed_error
            // 
            this.lbl_airspeed_error.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_airspeed_error.Location = new System.Drawing.Point(251, 35);
            this.lbl_airspeed_error.Name = "lbl_airspeed_error";
            this.lbl_airspeed_error.Size = new System.Drawing.Size(56, 23);
            this.lbl_airspeed_error.TabIndex = 131;
            this.lbl_airspeed_error.Tag = "r-3";
            this.lbl_airspeed_error.Text = "空速差：";
            this.lbl_airspeed_error.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblbtn_set_target_wp
            // 
            this.lblbtn_set_target_wp.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbtn_set_target_wp.Location = new System.Drawing.Point(368, 5);
            this.lblbtn_set_target_wp.Name = "lblbtn_set_target_wp";
            this.lblbtn_set_target_wp.Size = new System.Drawing.Size(110, 23);
            this.lblbtn_set_target_wp.TabIndex = 100;
            this.lblbtn_set_target_wp.Text = "设定目标航点：";
            this.lblbtn_set_target_wp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_force_disarm
            // 
            this.btn_force_disarm.BGGradBot = System.Drawing.Color.Maroon;
            this.btn_force_disarm.BGGradTop = System.Drawing.Color.Maroon;
            this.btn_force_disarm.ColorMouseDown = System.Drawing.Color.Empty;
            this.btn_force_disarm.ColorMouseOver = System.Drawing.Color.Empty;
            this.btn_force_disarm.ColorNotEnabled = System.Drawing.Color.Empty;
            this.btn_force_disarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_force_disarm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_force_disarm.Location = new System.Drawing.Point(6, 40);
            this.btn_force_disarm.Name = "btn_force_disarm";
            this.btn_force_disarm.Size = new System.Drawing.Size(78, 24);
            this.btn_force_disarm.TabIndex = 99;
            this.btn_force_disarm.Text = "强制加锁";
            this.btn_force_disarm.TextColor = System.Drawing.Color.WhiteSmoke;
            this.btn_force_disarm.UseVisualStyleBackColor = true;
            this.btn_force_disarm.Click += new System.EventHandler(this.btn_force_disarm_Click);
            // 
            // BUT_ARM
            // 
            this.BUT_ARM.ColorMouseDown = System.Drawing.Color.Empty;
            this.BUT_ARM.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_ARM.ColorNotEnabled = System.Drawing.Color.Empty;
            this.BUT_ARM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BUT_ARM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_ARM.Location = new System.Drawing.Point(95, 40);
            this.BUT_ARM.Name = "BUT_ARM";
            this.BUT_ARM.Size = new System.Drawing.Size(78, 24);
            this.BUT_ARM.TabIndex = 98;
            this.BUT_ARM.Text = "解锁";
            this.BUT_ARM.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BUT_ARM.UseVisualStyleBackColor = true;
            this.BUT_ARM.Click += new System.EventHandler(this.BUT_ARM_Click);
            // 
            // BUT_parachute
            // 
            this.BUT_parachute.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_parachute.Location = new System.Drawing.Point(7, 116);
            this.BUT_parachute.Name = "BUT_parachute";
            this.BUT_parachute.Size = new System.Drawing.Size(68, 24);
            this.BUT_parachute.TabIndex = 85;
            this.BUT_parachute.Text = "强制开伞";
            this.BUT_parachute.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BUT_parachute.UseVisualStyleBackColor = true;
            this.BUT_parachute.Visible = false;
            this.BUT_parachute.Click += new System.EventHandler(this.BUT_parachute_Click);
            // 
            // BUT_standby
            // 
            this.BUT_standby.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_standby.Location = new System.Drawing.Point(6, 4);
            this.BUT_standby.Name = "BUT_standby";
            this.BUT_standby.Size = new System.Drawing.Size(78, 24);
            this.BUT_standby.TabIndex = 84;
            this.BUT_standby.Text = "待机状态";
            this.BUT_standby.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BUT_standby.UseVisualStyleBackColor = true;
            this.BUT_standby.Click += new System.EventHandler(this.BUT_standby_Click);
            // 
            // BUT_camera
            // 
            this.BUT_camera.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_camera.Location = new System.Drawing.Point(650, 4);
            this.BUT_camera.Name = "BUT_camera";
            this.BUT_camera.Size = new System.Drawing.Size(68, 24);
            this.BUT_camera.TabIndex = 87;
            this.BUT_camera.Text = "相机";
            this.BUT_camera.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BUT_camera.UseVisualStyleBackColor = true;
            this.BUT_camera.Click += new System.EventHandler(this.BUT_camera_Click);
            // 
            // BUT_clear_track
            // 
            this.BUT_clear_track.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_clear_track.Location = new System.Drawing.Point(576, 4);
            this.BUT_clear_track.Name = "BUT_clear_track";
            this.BUT_clear_track.Size = new System.Drawing.Size(68, 24);
            this.BUT_clear_track.TabIndex = 81;
            this.BUT_clear_track.Text = "清除轨迹";
            this.BUT_clear_track.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BUT_clear_track.UseVisualStyleBackColor = true;
            this.BUT_clear_track.Click += new System.EventHandler(this.BUT_clear_track_Click);
            // 
            // CMB_setwp
            // 
            this.CMB_setwp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CMB_setwp.DropDownHeight = 70;
            this.CMB_setwp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_setwp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMB_setwp.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CMB_setwp.FormattingEnabled = true;
            this.CMB_setwp.Items.AddRange(new object[] {
            "0 (Home)"});
            this.CMB_setwp.Location = new System.Drawing.Point(481, 7);
            this.CMB_setwp.Name = "CMB_setwp";
            this.CMB_setwp.Size = new System.Drawing.Size(74, 20);
            this.CMB_setwp.TabIndex = 86;
            this.CMB_setwp.SelectedIndexChanged += new System.EventHandler(this.CMB_setwp_SelectedIndexChanged);
            this.CMB_setwp.Click += new System.EventHandler(this.CMB_setwp_Click);
            // 
            // BUTrestartmission
            // 
            this.BUTrestartmission.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUTrestartmission.Location = new System.Drawing.Point(273, 4);
            this.BUTrestartmission.Name = "BUTrestartmission";
            this.BUTrestartmission.Size = new System.Drawing.Size(78, 24);
            this.BUTrestartmission.TabIndex = 80;
            this.BUTrestartmission.Text = "重启任务";
            this.BUTrestartmission.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BUTrestartmission.UseVisualStyleBackColor = true;
            this.BUTrestartmission.Click += new System.EventHandler(this.BUTrestartmission_Click);
            // 
            // BUT_quickrtl
            // 
            this.BUT_quickrtl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_quickrtl.Location = new System.Drawing.Point(184, 4);
            this.BUT_quickrtl.Name = "BUT_quickrtl";
            this.BUT_quickrtl.Size = new System.Drawing.Size(78, 24);
            this.BUT_quickrtl.TabIndex = 83;
            this.BUT_quickrtl.Text = "返航";
            this.BUT_quickrtl.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BUT_quickrtl.UseVisualStyleBackColor = true;
            this.BUT_quickrtl.Click += new System.EventHandler(this.BUT_quickrtl_Click);
            // 
            // BUT_quickauto
            // 
            this.BUT_quickauto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_quickauto.Location = new System.Drawing.Point(95, 4);
            this.BUT_quickauto.Name = "BUT_quickauto";
            this.BUT_quickauto.Size = new System.Drawing.Size(78, 24);
            this.BUT_quickauto.TabIndex = 82;
            this.BUT_quickauto.Text = "导航";
            this.BUT_quickauto.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BUT_quickauto.UseVisualStyleBackColor = true;
            this.BUT_quickauto.Click += new System.EventHandler(this.BUT_quickauto_Click);
            // 
            // lblrepl_replay_speed
            // 
            this.lblrepl_replay_speed.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblrepl_replay_speed.Location = new System.Drawing.Point(444, 6);
            this.lblrepl_replay_speed.Name = "lblrepl_replay_speed";
            this.lblrepl_replay_speed.Size = new System.Drawing.Size(89, 23);
            this.lblrepl_replay_speed.TabIndex = 156;
            this.lblrepl_replay_speed.Text = "回放速率：";
            this.lblrepl_replay_speed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CMB_playspeed
            // 
            this.CMB_playspeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_playspeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMB_playspeed.FormattingEnabled = true;
            this.CMB_playspeed.Location = new System.Drawing.Point(537, 7);
            this.CMB_playspeed.Name = "CMB_playspeed";
            this.CMB_playspeed.Size = new System.Drawing.Size(64, 20);
            this.CMB_playspeed.TabIndex = 101;
            this.CMB_playspeed.SelectedIndexChanged += new System.EventHandler(this.CMB_playspeed_SelectedIndexChanged);
            this.CMB_playspeed.Click += new System.EventHandler(this.CMB_playspeed_Click);
            // 
            // lblrepl_logpercent
            // 
            this.lblrepl_logpercent.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblrepl_logpercent.Location = new System.Drawing.Point(385, 4);
            this.lblrepl_logpercent.Name = "lblrepl_logpercent";
            this.lblrepl_logpercent.resize = false;
            this.lblrepl_logpercent.Size = new System.Drawing.Size(50, 23);
            this.lblrepl_logpercent.TabIndex = 102;
            this.lblrepl_logpercent.Text = "0.00 %";
            // 
            // tracklog
            // 
            this.tracklog.AutoSize = false;
            this.tracklog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tracklog.Location = new System.Drawing.Point(160, 8);
            this.tracklog.Maximum = 100;
            this.tracklog.Name = "tracklog";
            this.tracklog.Size = new System.Drawing.Size(223, 23);
            this.tracklog.TabIndex = 100;
            this.tracklog.TickFrequency = 5;
            this.tracklog.Scroll += new System.EventHandler(this.tracklog_Scroll);
            // 
            // BUT_playlog
            // 
            this.BUT_playlog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_playlog.Location = new System.Drawing.Point(84, 7);
            this.BUT_playlog.Name = "BUT_playlog";
            this.BUT_playlog.Size = new System.Drawing.Size(68, 24);
            this.BUT_playlog.TabIndex = 99;
            this.BUT_playlog.Text = "播放";
            this.BUT_playlog.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BUT_playlog.UseVisualStyleBackColor = true;
            this.BUT_playlog.Click += new System.EventHandler(this.BUT_playlog_Click);
            // 
            // BUT_loadtelem
            // 
            this.BUT_loadtelem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_loadtelem.Location = new System.Drawing.Point(7, 7);
            this.BUT_loadtelem.Name = "BUT_loadtelem";
            this.BUT_loadtelem.Size = new System.Drawing.Size(68, 24);
            this.BUT_loadtelem.TabIndex = 98;
            this.BUT_loadtelem.Text = "录像";
            this.BUT_loadtelem.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BUT_loadtelem.UseVisualStyleBackColor = true;
            this.BUT_loadtelem.Click += new System.EventHandler(this.BUT_loadtelem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 0);
            this.panel1.TabIndex = 78;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.zg1);
            this.splitContainer6.Panel1Collapsed = true;
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.windDir1);
            this.splitContainer6.Panel2.Controls.Add(this.gMapControl1);
            this.splitContainer6.Size = new System.Drawing.Size(625, 768);
            this.splitContainer6.SplitterDistance = 178;
            this.splitContainer6.TabIndex = 82;
            // 
            // zg1
            // 
            this.zg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zg1.Location = new System.Drawing.Point(0, 0);
            this.zg1.Margin = new System.Windows.Forms.Padding(4);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(150, 178);
            this.zg1.TabIndex = 81;
            this.zg1.Visible = false;
            // 
            // windDir1
            // 
            this.windDir1.BackColor = System.Drawing.Color.Transparent;
            this.windDir1.DataBindings.Add(new System.Windows.Forms.Binding("Direction", this.bindingSourceHud, "wind_dir", true));
            this.windDir1.DataBindings.Add(new System.Windows.Forms.Binding("Speed", this.bindingSourceHud, "wind_vel", true));
            this.windDir1.Direction = 180D;
            this.windDir1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windDir1.Location = new System.Drawing.Point(3, 3);
            this.windDir1.Name = "windDir1";
            this.windDir1.Size = new System.Drawing.Size(67, 60);
            this.windDir1.Speed = 0D;
            this.windDir1.TabIndex = 81;
            // 
            // gMapControl1
            // 
            this.gMapControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.ContextMenuStrip = this.contextMenuStripMap;
            this.gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Gray;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(0, 0);
            this.gMapControl1.Margin = new System.Windows.Forms.Padding(0);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 24;
            this.gMapControl1.MinZoom = 0;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Fractional;
            this.gMapControl1.SelectedArea = ((GMap.NET.RectLatLng)(resources.GetObject("gMapControl1.SelectedArea")));
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(625, 768);
            this.gMapControl1.TabIndex = 79;
            this.gMapControl1.Zoom = 3D;
            this.gMapControl1.Click += new System.EventHandler(this.gMapControl1_Click);
            this.gMapControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDown);
            this.gMapControl1.MouseLeave += new System.EventHandler(this.gMapControl1_MouseLeave);
            this.gMapControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseMove);
            // 
            // contextMenuStripMap
            // 
            this.contextMenuStripMap.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flyToHereAltToolStripMenuItem,
            this.fixbattery,
            this.speedUintToolStripMenuItem,
            this.landStartToolStripMenuItem});
            this.contextMenuStripMap.Name = "contextMenuStrip1";
            this.contextMenuStripMap.Size = new System.Drawing.Size(161, 92);
            // 
            // flyToHereAltToolStripMenuItem
            // 
            this.flyToHereAltToolStripMenuItem.Name = "flyToHereAltToolStripMenuItem";
            this.flyToHereAltToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.flyToHereAltToolStripMenuItem.Text = "指点飞行到这里";
            this.flyToHereAltToolStripMenuItem.Click += new System.EventHandler(this.goHereToolStripMenuItem_Click);
            // 
            // fixbattery
            // 
            this.fixbattery.Name = "fixbattery";
            this.fixbattery.Size = new System.Drawing.Size(160, 22);
            this.fixbattery.Text = "修正电池电压";
            this.fixbattery.Click += new System.EventHandler(this.changebatteryvalue);
            // 
            // landStartToolStripMenuItem
            // 
            this.landStartToolStripMenuItem.Name = "landStartToolStripMenuItem";
            this.landStartToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.landStartToolStripMenuItem.Text = "执行降落";
            this.landStartToolStripMenuItem.Click += new System.EventHandler(this.landStartToolStripMenuItem_Click);
            // 
            // bindingSourceGaugesTab
            // 
            this.bindingSourceGaugesTab.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // ZedGraphTimer
            // 
            this.ZedGraphTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bindingSourceStatusTab
            // 
            this.bindingSourceStatusTab.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // speedUintToolStripMenuItem
            // 
            this.speedUintToolStripMenuItem.Name = "speedUintToolStripMenuItem";
            this.speedUintToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.speedUintToolStripMenuItem.Text = "更改速度单位";
            this.speedUintToolStripMenuItem.Click += new System.EventHandler(this.speedUintToolStripMenuItem_Click);
            // 
            // HsdevFlightData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.splitContainer_main_map);
            this.Name = "HsdevFlightData";
            this.Size = new System.Drawing.Size(1366, 768);
            this.Load += new System.EventHandler(this.HsdevFlightData_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.HsdevFlightData_Layout);
            this.splitContainer_main_map.Panel1.ResumeLayout(false);
            this.splitContainer_main_map.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main_map)).EndInit();
            this.splitContainer_main_map.ResumeLayout(false);
            this.splitContainer_main_left.Panel1.ResumeLayout(false);
            this.splitContainer_main_left.Panel2.ResumeLayout(false);
            this.splitContainer_main_left.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main_left)).EndInit();
            this.splitContainer_main_left.ResumeLayout(false);
            this.splitContainer_3dview_hud.Panel1.ResumeLayout(false);
            this.splitContainer_3dview_hud.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_3dview_hud)).EndInit();
            this.splitContainer_3dview_hud.ResumeLayout(false);
            this.splitContainer_3dview_msg.Panel1.ResumeLayout(false);
            this.splitContainer_3dview_msg.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_3dview_msg)).EndInit();
            this.splitContainer_3dview_msg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHud)).EndInit();
            this.splitContainer_opr_logplayer.Panel1.ResumeLayout(false);
            this.splitContainer_opr_logplayer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_opr_logplayer)).EndInit();
            this.splitContainer_opr_logplayer.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer_info_system_more.Panel1.ResumeLayout(false);
            this.splitContainer_info_system_more.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_info_system_more)).EndInit();
            this.splitContainer_info_system_more.ResumeLayout(false);
            this.splitContainer_info_fixedwing_copter.Panel1.ResumeLayout(false);
            this.splitContainer_info_fixedwing_copter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_info_fixedwing_copter)).EndInit();
            this.splitContainer_info_fixedwing_copter.ResumeLayout(false);
            this.panel_fixedwing_info.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel_copter_info.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_sysinfo.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tracklog)).EndInit();
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.contextMenuStripMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGaugesTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStatusTab)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceHud;
        public System.Windows.Forms.ContextMenuStrip contextMenuStripHud;
        private System.Windows.Forms.BindingSource bindingSourceStatusTab;
        private System.Windows.Forms.SplitContainer splitContainer_main_map;
        private Controls.myGMAP gMapControl1;
        private System.Windows.Forms.SplitContainer splitContainer_main_left;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSourceGaugesTab;
        private System.Windows.Forms.SplitContainer splitContainer_3dview_hud;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Timer ZedGraphTimer;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private Controls.WindDir windDir1;
        public System.Windows.Forms.ContextMenuStrip contextMenuStripMap;
        private System.Windows.Forms.ToolStripMenuItem flyToHereAltToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixbattery;
        private Controls.HSHUD hud2;
        private System.Windows.Forms.ToolStripMenuItem landStartToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer_opr_logplayer;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private Controls.MyButton BUT_parachute;
        private Controls.MyButton BUT_ARM;
        private Controls.MyButton BUT_camera;
        private System.Windows.Forms.ComboBox CMB_setwp;
        private Controls.MyButton BUT_standby;
        private Controls.MyButton BUT_clear_track;
        private Controls.MyButton BUT_quickrtl;
        private Controls.MyButton BUT_quickauto;
        private Controls.MyButton BUTrestartmission;
        private System.Windows.Forms.SplitContainer splitContainer_3dview_msg;
        private Mesh._3DMesh _3DMesh1;
        private System.Windows.Forms.SplitContainer splitContainer_info_system_more;
        private Controls.MyButton btn_force_disarm;
        private System.Windows.Forms.Label lblrepl_replay_speed;
        private System.Windows.Forms.ComboBox CMB_playspeed;
        private Controls.MyLabel lblrepl_logpercent;
        private System.Windows.Forms.TrackBar tracklog;
        private Controls.MyButton BUT_playlog;
        private Controls.MyButton BUT_loadtelem;
        private System.Windows.Forms.SplitContainer splitContainer_info_fixedwing_copter;
        private BSE.Windows.Forms.Panel panel_fixedwing_info;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbl_fw_voltage;
        private System.Windows.Forms.Label val_timeinair;
        private System.Windows.Forms.Label val_fw_mah_used;
        private System.Windows.Forms.Label lbl_fw_mah_used;
        private System.Windows.Forms.Label val_traveled_km;
        private System.Windows.Forms.Label lbl_traveled_km;
        private System.Windows.Forms.Label val_fw_current;
        private System.Windows.Forms.Label val_fw_voltage;
        private System.Windows.Forms.Label lbl_fw_current;
        private System.Windows.Forms.Label lbl_fw_timeinair;
        private BSE.Windows.Forms.Panel panel_copter_info;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_quad_voltage;
        private System.Windows.Forms.Label val_quadbat_time;
        private System.Windows.Forms.Label val_quad_voltage;
        private System.Windows.Forms.Label lbl_quadbat_time;
        private System.Windows.Forms.Label val_quad_mah_used;
        private System.Windows.Forms.Label lbl_quad_current;
        private System.Windows.Forms.Label lbl_quad_mah_used;
        private System.Windows.Forms.Label val_quad_current;
        private BSE.Windows.Forms.Panel panel_sysinfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_mode;
        private System.Windows.Forms.Label val_cam_num;
        private System.Windows.Forms.Label lbl_cam_num;
        private System.Windows.Forms.Label val_alt_error;
        private System.Windows.Forms.Label lbl_alt_error;
        private System.Windows.Forms.Label val_target_wp;
        private System.Windows.Forms.Label lbl_target_wp;
        private System.Windows.Forms.Label val_gps_ground_vel;
        private System.Windows.Forms.Label val_compass;
        private System.Windows.Forms.Label val_xtrack_error;
        private System.Windows.Forms.Label lbl_xtrack_error;
        private System.Windows.Forms.Label lbl_sat_count;
        private System.Windows.Forms.Label val_latitude;
        private System.Windows.Forms.Label val_gps_mode;
        private System.Windows.Forms.Label lbl_gps_mode;
        private System.Windows.Forms.Label lbl_compass;
        private System.Windows.Forms.Label lbl_longtitude;
        private System.Windows.Forms.Label val_sat_count;
        private System.Windows.Forms.Label lbl_latitude;
        private System.Windows.Forms.Label val_longitude;
        private System.Windows.Forms.Label lbl_alt;
        private System.Windows.Forms.Label lbl_gps_ground_vel;
        private System.Windows.Forms.Label val_airspeed_error;
        private System.Windows.Forms.Label val_alt_target;
        private System.Windows.Forms.Label val_mode;
        private System.Windows.Forms.Label lbl_alt_target;
        private System.Windows.Forms.Label lbl_throttle;
        private System.Windows.Forms.Label val_throttle;
        private System.Windows.Forms.Label lbl_airspeed;
        private System.Windows.Forms.Label val_alt;
        private System.Windows.Forms.Label val_airspeed;
        private System.Windows.Forms.Label lbl_airspeed_target;
        private System.Windows.Forms.Label val_airspeed_target;
        private System.Windows.Forms.Label lbl_airspeed_error;
        private System.Windows.Forms.Label lblbtn_set_target_wp;
        private System.Windows.Forms.ToolStripMenuItem speedUintToolStripMenuItem;
    }
}
