using System;
namespace MissionPlanner
{
    partial class MainV2
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
            Console.WriteLine("mainv2_Dispose");
            if (PluginThreadrunner != null)
                PluginThreadrunner.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainV2));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.CTX_mainmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readonlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHsdevInterface = new System.Windows.Forms.ToolStripButton();
            this.MenuHsFilghtData = new System.Windows.Forms.ToolStripButton();
            this.MenuFlightData = new System.Windows.Forms.ToolStripButton();
            this.MenuFlightPlanner = new System.Windows.Forms.ToolStripButton();
            this.MenuHSConfigure = new System.Windows.Forms.ToolStripButton();
            this.MenuInitConfig = new System.Windows.Forms.ToolStripButton();
            this.MenuConfigTune = new System.Windows.Forms.ToolStripButton();
            this.MenuSimulation = new System.Windows.Forms.ToolStripButton();
            this.MenuTerminal = new System.Windows.Forms.ToolStripButton();
            this.MenuHelp = new System.Windows.Forms.ToolStripButton();
            this.MenuLogManger = new System.Windows.Forms.ToolStripButton();
            this.MenuConnect = new System.Windows.Forms.ToolStripButton();
            this.MenuDownLoadPos = new System.Windows.Forms.ToolStripButton();
            this.MenuCalCompass = new System.Windows.Forms.ToolStripButton();
            this.toolStripConnectionControl = new MissionPlanner.Controls.ToolStripConnectionControl();
            this.MenuDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new MissionPlanner.Controls.MyButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CHK_hsmav = new System.Windows.Forms.CheckBox();
            this.MainMenu.SuspendLayout();
            this.CTX_mainmenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackgroundImage = global::MissionPlanner.Properties.Resources.bgdark;
            this.MainMenu.ContextMenuStrip = this.CTX_mainmenu;
            this.MainMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(0, 0);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHsdevInterface,
            this.MenuHsFilghtData,
            this.MenuFlightData,
            this.MenuFlightPlanner,
            this.MenuHSConfigure,
            this.MenuInitConfig,
            this.MenuConfigTune,
            this.MenuSimulation,
            this.MenuTerminal,
            this.MenuHelp,
            this.MenuLogManger,
            this.MenuConnect,
            this.MenuDownLoadPos,
            this.MenuCalCompass,
            this.toolStripConnectionControl,
            this.MenuDonate});
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Stretch = false;
            this.MainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenu_ItemClicked);
            this.MainMenu.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            this.MainMenu.Resize += new System.EventHandler(this.resize);
            // 
            // CTX_mainmenu
            // 
            this.CTX_mainmenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CTX_mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoHideToolStripMenuItem,
            this.fullScreenToolStripMenuItem,
            this.readonlyToolStripMenuItem,
            this.connectionOptionsToolStripMenuItem});
            this.CTX_mainmenu.Name = "CTX_mainmenu";
            resources.ApplyResources(this.CTX_mainmenu, "CTX_mainmenu");
            // 
            // autoHideToolStripMenuItem
            // 
            this.autoHideToolStripMenuItem.CheckOnClick = true;
            this.autoHideToolStripMenuItem.Name = "autoHideToolStripMenuItem";
            resources.ApplyResources(this.autoHideToolStripMenuItem, "autoHideToolStripMenuItem");
            this.autoHideToolStripMenuItem.Click += new System.EventHandler(this.autoHideToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.CheckOnClick = true;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            resources.ApplyResources(this.fullScreenToolStripMenuItem, "fullScreenToolStripMenuItem");
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // readonlyToolStripMenuItem
            // 
            this.readonlyToolStripMenuItem.CheckOnClick = true;
            this.readonlyToolStripMenuItem.Name = "readonlyToolStripMenuItem";
            resources.ApplyResources(this.readonlyToolStripMenuItem, "readonlyToolStripMenuItem");
            this.readonlyToolStripMenuItem.Click += new System.EventHandler(this.readonlyToolStripMenuItem_Click);
            // 
            // connectionOptionsToolStripMenuItem
            // 
            this.connectionOptionsToolStripMenuItem.Name = "connectionOptionsToolStripMenuItem";
            resources.ApplyResources(this.connectionOptionsToolStripMenuItem, "connectionOptionsToolStripMenuItem");
            this.connectionOptionsToolStripMenuItem.Click += new System.EventHandler(this.connectionOptionsToolStripMenuItem_Click);
            // 
            // MenuHsdevInterface
            // 
            resources.ApplyResources(this.MenuHsdevInterface, "MenuHsdevInterface");
            this.MenuHsdevInterface.ForeColor = System.Drawing.Color.White;
            this.MenuHsdevInterface.Image = global::MissionPlanner.Properties.Resources.light_flightdata_icon;
            this.MenuHsdevInterface.Margin = new System.Windows.Forms.Padding(0);
            this.MenuHsdevInterface.Name = "MenuHsdevInterface";
            this.MenuHsdevInterface.Click += new System.EventHandler(this.MenuHsdevInterface_Click);
            // 
            // MenuHsFilghtData
            // 
            resources.ApplyResources(this.MenuHsFilghtData, "MenuHsFilghtData");
            this.MenuHsFilghtData.ForeColor = System.Drawing.Color.White;
            this.MenuHsFilghtData.Image = global::MissionPlanner.Properties.Resources.light_flightdata_icon;
            this.MenuHsFilghtData.Margin = new System.Windows.Forms.Padding(0);
            this.MenuHsFilghtData.Name = "MenuHsFilghtData";
            this.MenuHsFilghtData.Click += new System.EventHandler(this.MenuHsFlightData_Click);
            // 
            // MenuFlightData
            // 
            resources.ApplyResources(this.MenuFlightData, "MenuFlightData");
            this.MenuFlightData.ForeColor = System.Drawing.Color.White;
            this.MenuFlightData.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightData.Name = "MenuFlightData";
            this.MenuFlightData.Click += new System.EventHandler(this.MenuFlightData_Click);
            // 
            // MenuFlightPlanner
            // 
            resources.ApplyResources(this.MenuFlightPlanner, "MenuFlightPlanner");
            this.MenuFlightPlanner.ForeColor = System.Drawing.Color.White;
            this.MenuFlightPlanner.Image = global::MissionPlanner.Properties.Resources.light_flightplan_icon;
            this.MenuFlightPlanner.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightPlanner.Name = "MenuFlightPlanner";
            this.MenuFlightPlanner.Click += new System.EventHandler(this.MenuFlightPlanner_Click);
            // 
            // MenuHSConfigure
            // 
            resources.ApplyResources(this.MenuHSConfigure, "MenuHSConfigure");
            this.MenuHSConfigure.ForeColor = System.Drawing.Color.White;
            this.MenuHSConfigure.Image = global::MissionPlanner.Properties.Resources.dark_terminal_icon;
            this.MenuHSConfigure.Margin = new System.Windows.Forms.Padding(0);
            this.MenuHSConfigure.Name = "MenuHSConfigure";
            this.MenuHSConfigure.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MenuHSConfigure.Click += new System.EventHandler(this.toolStripMenuHSconfigure_Click);
            // 
            // MenuInitConfig
            // 
            resources.ApplyResources(this.MenuInitConfig, "MenuInitConfig");
            this.MenuInitConfig.ForeColor = System.Drawing.Color.White;
            this.MenuInitConfig.Margin = new System.Windows.Forms.Padding(0);
            this.MenuInitConfig.Name = "MenuInitConfig";
            this.MenuInitConfig.Click += new System.EventHandler(this.MenuSetup_Click);
            // 
            // MenuConfigTune
            // 
            resources.ApplyResources(this.MenuConfigTune, "MenuConfigTune");
            this.MenuConfigTune.ForeColor = System.Drawing.Color.White;
            this.MenuConfigTune.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConfigTune.Name = "MenuConfigTune";
            this.MenuConfigTune.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.MenuConfigTune.Click += new System.EventHandler(this.MenuTuning_Click);
            // 
            // MenuSimulation
            // 
            resources.ApplyResources(this.MenuSimulation, "MenuSimulation");
            this.MenuSimulation.ForeColor = System.Drawing.Color.White;
            this.MenuSimulation.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSimulation.Name = "MenuSimulation";
            this.MenuSimulation.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MenuSimulation.Click += new System.EventHandler(this.MenuSimulation_Click);
            // 
            // MenuTerminal
            // 
            resources.ApplyResources(this.MenuTerminal, "MenuTerminal");
            this.MenuTerminal.ForeColor = System.Drawing.Color.White;
            this.MenuTerminal.Margin = new System.Windows.Forms.Padding(0);
            this.MenuTerminal.Name = "MenuTerminal";
            this.MenuTerminal.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MenuTerminal.Click += new System.EventHandler(this.MenuTerminal_Click);
            // 
            // MenuHelp
            // 
            resources.ApplyResources(this.MenuHelp, "MenuHelp");
            this.MenuHelp.ForeColor = System.Drawing.Color.White;
            this.MenuHelp.Margin = new System.Windows.Forms.Padding(0);
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MenuHelp.Click += new System.EventHandler(this.MenuHelp_Click);
            // 
            // MenuLogManger
            // 
            resources.ApplyResources(this.MenuLogManger, "MenuLogManger");
            this.MenuLogManger.ForeColor = System.Drawing.Color.White;
            this.MenuLogManger.Image = global::MissionPlanner.Properties.Resources.dark_terminal_icon;
            this.MenuLogManger.Margin = new System.Windows.Forms.Padding(0);
            this.MenuLogManger.Name = "MenuLogManger";
            this.MenuLogManger.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MenuLogManger.Click += new System.EventHandler(this.toolStripMenuLogManger_Click);
            // 
            // MenuConnect
            // 
            this.MenuConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.MenuConnect, "MenuConnect");
            this.MenuConnect.ForeColor = System.Drawing.Color.White;
            this.MenuConnect.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConnect.Name = "MenuConnect";
            this.MenuConnect.Click += new System.EventHandler(this.MenuConnect_Click);
            // 
            // MenuDownLoadPos
            // 
            resources.ApplyResources(this.MenuDownLoadPos, "MenuDownLoadPos");
            this.MenuDownLoadPos.ForeColor = System.Drawing.Color.White;
            this.MenuDownLoadPos.Image = global::MissionPlanner.Properties.Resources.dark_help_icon;
            this.MenuDownLoadPos.Margin = new System.Windows.Forms.Padding(0);
            this.MenuDownLoadPos.Name = "MenuDownLoadPos";
            this.MenuDownLoadPos.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MenuDownLoadPos.Click += new System.EventHandler(this.MenuDownLoadPos_Click);
            // 
            // MenuCalCompass
            // 
            resources.ApplyResources(this.MenuCalCompass, "MenuCalCompass");
            this.MenuCalCompass.ForeColor = System.Drawing.Color.White;
            this.MenuCalCompass.Image = global::MissionPlanner.Properties.Resources.compass_cal;
            this.MenuCalCompass.Margin = new System.Windows.Forms.Padding(0);
            this.MenuCalCompass.Name = "MenuCalCompass";
            this.MenuCalCompass.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MenuCalCompass.Click += new System.EventHandler(this.toolStripMenuCalCompass_Click);
            // 
            // toolStripConnectionControl
            // 
            this.toolStripConnectionControl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripConnectionControl, "toolStripConnectionControl");
            this.toolStripConnectionControl.ForeColor = System.Drawing.Color.Black;
            this.toolStripConnectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripConnectionControl.Name = "toolStripConnectionControl";
            this.toolStripConnectionControl.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // MenuDonate
            // 
            resources.ApplyResources(this.MenuDonate, "MenuDonate");
            this.MenuDonate.ForeColor = System.Drawing.Color.White;
            this.MenuDonate.Name = "MenuDonate";
            this.MenuDonate.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MenuDonate.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menu
            // 
            resources.ApplyResources(this.menu, "menu");
            this.menu.Name = "menu";
            this.menu.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menu.UseVisualStyleBackColor = true;
            this.menu.MouseEnter += new System.EventHandler(this.menu_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.CHK_hsmav);
            this.panel1.Controls.Add(this.MainMenu);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // CHK_hsmav
            // 
            resources.ApplyResources(this.CHK_hsmav, "CHK_hsmav");
            this.CHK_hsmav.BackColor = System.Drawing.Color.Transparent;
            this.CHK_hsmav.Checked = true;
            this.CHK_hsmav.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_hsmav.Name = "CHK_hsmav";
            this.CHK_hsmav.UseVisualStyleBackColor = false;
            // 
            // MainV2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.KeyPreview = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainV2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainV2_KeyDown);
            this.Resize += new System.EventHandler(this.MainV2_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.CTX_mainmenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolStripButton MenuFlightData;
        public System.Windows.Forms.ToolStripButton MenuFlightPlanner;
        public System.Windows.Forms.ToolStripButton MenuInitConfig;
        public System.Windows.Forms.ToolStripButton MenuSimulation;
        public System.Windows.Forms.ToolStripButton MenuConfigTune;
        public System.Windows.Forms.ToolStripButton MenuTerminal;
        public System.Windows.Forms.ToolStripButton MenuConnect;

        private System.Windows.Forms.ToolStripButton MenuHelp;
        private Controls.ToolStripConnectionControl toolStripConnectionControl;
        private Controls.MyButton menu;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip CTX_mainmenu;
        private System.Windows.Forms.ToolStripMenuItem autoHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuDonate;
        public System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readonlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton MenuHsFilghtData;
        private System.Windows.Forms.ToolStripButton MenuLogManger;
        public System.Windows.Forms.ToolStripButton MenuDownLoadPos;
        private System.Windows.Forms.ToolStripButton MenuCalCompass;
        public System.Windows.Forms.CheckBox CHK_hsmav;
        private System.Windows.Forms.ToolStripButton MenuHsdevInterface;
        private System.Windows.Forms.ToolStripButton MenuHSConfigure;
    }
}