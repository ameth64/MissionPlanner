using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DirectShowLib;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using log4net;
using MissionPlanner.Controls;
using MissionPlanner.Joystick;
using MissionPlanner.Log;
using MissionPlanner.Utilities;
using MissionPlanner.Warnings;
using OpenTK;
using Org.BouncyCastle.Asn1.X509.Qualified;
using WebCamService;
using ZedGraph;
using LogAnalyzer = MissionPlanner.Utilities.LogAnalyzer;
using System.Windows;

namespace MissionPlanner.GCSViews
{
    public partial class HsdevInterface : MyUserControl, IActivate, IDeactivate
    {
        public class mypanel : Panel
        {
           public mypanel()
            {
               this.SetStyle(ControlStyles.AllPaintingInWmPaint | //不擦除背景 ,减少闪烁
                    ControlStyles.OptimizedDoubleBuffer | //双缓冲
                  ControlStyles.UserPaint, //使用自定义的重绘事件,减少闪烁
                    true);
            }

        }
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        internal static GMapOverlay tfrpolygons;
        public static GMapOverlay kmlpolygons;
        internal static GMapOverlay geofence;
        internal static GMapOverlay rallypointoverlay;
        internal static GMapOverlay photosoverlay;
        internal static GMapOverlay poioverlay = new GMapOverlay("POI"); // poi layer

        GMapOverlay polygons;
        GMapOverlay routes;
        GMapRoute route;

        List<TabPage> TabListOriginal = new List<TabPage>();

        bool huddropout;
        bool huddropoutresize;

        Thread thisthread;

        //      private DockStateSerializer _serializer = null;
        public List<string> voicealarm = new List<string>();
        List<PointLatLng> trackPoints = new List<PointLatLng>();

        const float rad2deg = (float)(180 / Math.PI);

        const float deg2rad = (float)(1.0 / rad2deg);

        public static HUD myhud;
        public static myGMAP mymap;

        public static HsdevInterface instance;

        bool playingLog;
        double LogPlayBackSpeed = 1.0;

        GMapMarker marker;

        AviWriter aviwriter;

        public SplitContainer MainHcopy;

        //The file path of the selected script
        string selectedscript = "";
        //the thread the script is running on
        Thread scriptthread;
        //whether or not a script is running
        bool scriptrunning = false;
        Script script;
        //whether or not the output console has already started

        public bool[] prearmcheck;

        bool autopan = false;

        bool outputwindowstarted = false;
        bool threadrun = false;

        private bool CameraOverlap = false;

        internal GMapMarker CurrentGMapMarker;

        public List<Object> middlebuttons;
        public struct LabelInfo
        {
            public System.Windows.Forms.Label label;
            public string digit;
            public string unit;
            public string[] strswap;
            public DateTime voicetime;
            
            public LabelInfo(System.Windows.Forms.Label _label,string _digit, string _unit , string[] _strswap = null)
                {
                    this.label = _label;
                    this.unit = _unit;
                    this.digit = _digit;
                    this.strswap = _strswap;
                    voicetime = DateTime.Now;
                }
        }

        public List<LabelInfo> leftlabels;
        public List<LabelInfo> rightlabels;
        Hashtable paneltable = new Hashtable();

        List<Rectangle> btnbounds;
        System.Drawing.Size originalmiddlesize = new System.Drawing.Size();
        System.Drawing.Size originalleftsize = new System.Drawing.Size();
        System.Drawing.Size originalrightsize = new System.Drawing.Size();
        System.Drawing.Size originalhudpanelsize = new System.Drawing.Size();
        float minfont = 10000;

        //public Bitmap bmpleftpanel;

        public HsdevInterface()
        {

            middlebuttons = new List<object>();
            leftlabels = new List<LabelInfo>();
            rightlabels = new List<LabelInfo>();
            btnbounds = new List<Rectangle>();

            InitializeComponent();

            HSSetting.Instance.xmlhsdata(false);

            middlebuttons.Add(btn_prearm);
            middlebuttons.Add(btn_arm);
            middlebuttons.Add(btn_normalland);

            middlebuttons.Add(btn_rtl);
            middlebuttons.Add(btn_auto);
            middlebuttons.Add(btn_qrtlemergent);

            middlebuttons.Add(btn_parachute);
            middlebuttons.Add(btn_manual);
            middlebuttons.Add(btn_stabilize);
            middlebuttons.Add(btn_qlandemergent);

            middlebuttons.Add(CMB_setwp);
            middlebuttons.Add(btn_setwp);
            middlebuttons.Add(btn_qhover);

            for(int i=0;i<middlebuttons.Count;i++)
            {
                Rectangle temp = new Rectangle();
                Type t = middlebuttons[i].GetType();
                if(t.Name == "Button")
                {
                    Button b = (Button)middlebuttons[i];
                    temp = b.Bounds;
                    btnbounds.Add(temp);
                    //b.BackColor = Color.White;
                }
                if(t.Name == "ComboBox")
                {
                    ComboBox b = (ComboBox)middlebuttons[i];
                    temp = b.Bounds;
                    btnbounds.Add(temp);
                    //b.BackColor = Color.White;
                }
            }
            //CurrentState cs = MainV2.comPort.MAV.cs;
            string[] gpsstatus_swap = new string[] {"无GPS","未定位","2D","3D","高精度","浮点解","固定解" };

            leftlabels.Add(new LabelInfo(alt, "0", "m")); leftlabels.Add(new LabelInfo(altasl, "0", "m"));

            leftlabels.Add(new LabelInfo( targetalt, "0", "m" )); leftlabels.Add(new LabelInfo(alt_error, "0", "m"));

            leftlabels.Add(new LabelInfo(airspeed, "0", "km")); leftlabels.Add(new LabelInfo(groundspeed, "0", "km"));

            leftlabels.Add(new LabelInfo(targetairspeed, "0", "km")); leftlabels.Add(new LabelInfo(aspd_error, "0", "km"));

            leftlabels.Add(new LabelInfo(satcount, "0", "")); leftlabels.Add(new LabelInfo(gpsstatus, "0", "", gpsstatus_swap));

            leftlabels.Add(new LabelInfo(lng, "0.0000", "")); leftlabels.Add(new LabelInfo(lat, "0.0000", ""));

            leftlabels.Add(new LabelInfo(gpshdop, "0", ""));


            object thisBoxed = MainV2.comPort.MAV.cs;
            Type test = thisBoxed.GetType();
            //FieldInfo f = test.GetField("roll", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            //object Value = f.GetValue(thisBoxed);

            PropertyInfo[] props = test.GetProperties();

            //props

            foreach (var field in props)
            {
                // field.Name has the field's name.
                object fieldValue;
                TypeCode typeCode;
                try
                {
                    fieldValue = field.GetValue(thisBoxed, null); // Get value

                    if (fieldValue == null)
                        continue;
                    // Get the TypeCode enumeration. Multiple types get mapped to a common typecode.
                    typeCode = Type.GetTypeCode(fieldValue.GetType());
                }
                catch
                {
                    continue;
                }


                    if (!paneltable.Contains(field.Name))
                    {
                        paneltable[field.Name] = new Dictionary<String, PropertyInfo>();
                    }

                    Dictionary<String, PropertyInfo> temp = (Dictionary<String, PropertyInfo>)paneltable[field.Name];

                    temp[field.Name] = field;

            }



            rightlabels.Add(new LabelInfo(wpno, "0", "")); rightlabels.Add(new LabelInfo(wp_dist, "0", "m"));

            rightlabels.Add(new LabelInfo(DistToHome, "0", "m")); rightlabels.Add(new LabelInfo(xtrack_error, "0.0", "m"));

            rightlabels.Add(new LabelInfo(battery_voltage, "0.00", "V")); rightlabels.Add(new LabelInfo(current, "0.0", "A"));

            rightlabels.Add(new LabelInfo(battery_remaining, "0", "mah"));

            rightlabels.Add(new LabelInfo(battery_voltage2, "0", "V")); rightlabels.Add(new LabelInfo(current2, "0", "A"));

            rightlabels.Add(new LabelInfo(battery2_usedmah, "0", "mah")); 

            instance = this;
            //    _serializer = new DockStateSerializer(dockContainer1);
            //    _serializer.SavePath = Application.StartupPath + Path.DirectorySeparatorChar + "FDscreen.xml";
            //    dockContainer1.PreviewRenderer = new PreviewRenderer();
            //
            mymap = gMapControl1;
            //myhud = hud1;
            //MainHcopy = MainH;

            mymap.Paint += mymap_Paint;

            // config map      
            log.Info("Map Setup");
            //gMapControl1.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;

            gMapControl1.CacheLocation = Settings.GetDataDirectory() +
                                         "gmapcache" + Path.DirectorySeparatorChar;
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 3;

            gMapControl1.OnMapZoomChanged += gMapControl1_OnMapZoomChanged;

            gMapControl1.DisableFocusOnMouseEnter = true;

            gMapControl1.OnMarkerEnter += gMapControl1_OnMarkerEnter;
            gMapControl1.OnMarkerLeave += gMapControl1_OnMarkerLeave;

            gMapControl1.RoutesEnabled = true;
            gMapControl1.PolygonsEnabled = true;

            if (Settings.Instance["CHK_autopan"] != null)
                autopan = Settings.Instance.GetBoolean("CHK_autopan");

            tfrpolygons = new GMapOverlay("tfrpolygons");
            gMapControl1.Overlays.Add(tfrpolygons);

            kmlpolygons = new GMapOverlay("kmlpolygons");
            gMapControl1.Overlays.Add(kmlpolygons);

            geofence = new GMapOverlay("geofence");
            gMapControl1.Overlays.Add(geofence);

            polygons = new GMapOverlay("polygons");
            gMapControl1.Overlays.Add(polygons);

            photosoverlay = new GMapOverlay("photos overlay");
            gMapControl1.Overlays.Add(photosoverlay);

            routes = new GMapOverlay("routes");
            gMapControl1.Overlays.Add(routes);

            rallypointoverlay = new GMapOverlay("rally points");
            gMapControl1.Overlays.Add(rallypointoverlay);

            gMapControl1.Overlays.Add(poioverlay);

            GraphTimer.Interval = 20000;

            GraphTimer.Start();

            prearmcheck = new bool[6] {false, false, false, false, false, false };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (middlesplitContainer!=null)
            {
                Graphics g = middlesplitContainer.CreateGraphics();
                g.Clear(middlesplitContainer.BackColor);
            }
        }

        internal PointLatLng MouseDownStart;

        private void gMapControl1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void gMapControl1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void gMapControl1_OnPositionChanged(PointLatLng point)
        {
            UpdateOverlayVisibility();
        }

        void UpdateOverlayVisibility()
        {
            // change overlay visability
            if (gMapControl1.ViewArea != null)
            {
                var bounds = gMapControl1.ViewArea;
                bounds.Inflate(1, 1);

                foreach (var poly in kmlpolygons.Polygons)
                {
                    if (bounds.Contains(poly.Points[0]))
                        poly.IsVisible = true;
                    else
                        poly.IsVisible = false;
                }
            }
        }

        private void gMapControl1_MouseLeave(object sender, EventArgs e)
        {

        }

        void gMapControl1_OnMarkerLeave(GMapMarker item)
        {
            CurrentGMapMarker = null;
        }

        void gMapControl1_OnMarkerEnter(GMapMarker item)
        {
            CurrentGMapMarker = item;
        }

        void mymap_Paint(object sender, PaintEventArgs e)
        {
            //distanceBar1.DoPaintRemote(e);
        }

        void gMapControl1_OnMapZoomChanged()
        {
            try
            {
                // Exception System.Runtime.InteropServices.SEHException: External component has thrown an exception.
                //TRK_zoom.Value = (float)gMapControl1.Zoom;
                //Zoomlevel.Value = Convert.ToDecimal(gMapControl1.Zoom);
            }
            catch
            {
            }
        }

        private void HsdevInterface_Load(object sender, EventArgs e)
        {
            thisthread = new Thread(mainloop);
            thisthread.Name = "HS Mainloop";
            thisthread.IsBackground = true;
            thisthread.Start();
        }

        private void HsdevInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadrun = false;

            while (thisthread.IsAlive)
            {
                Application.DoEvents();
            }

            // you cannot call join on the main thread, and invoke on the thread. as it just hangs on the invoke.

            //thisthread.Join();
        }

        int ignore = 0;
        private void HsdevInterface_Resize(object sender, EventArgs e)
        {
            
            System.Drawing.Size size = new System.Drawing.Size();
            size.Width = (int)((float)this.Width - (float)this.Width / 5);
            size.Height = (int)((float)this.Height / 4.5);
            size.Width = Math.Min(Math.Max(size.Width, 800), 1920);
            size.Height = Math.Min(Math.Max(size.Height, 180), 1080);


            int lowerthan1 = size.Width * size.Height;
            int lowerthan2 = DataPanel.Size.Width * DataPanel.Size.Height;
            if (minfont > 10)
            {
                DataPanel.Size = size;
            }
            else if(lowerthan1>lowerthan2)
            {
                DataPanel.Size = size;
            }

            System.Drawing.Point p = new System.Drawing.Point();
            p.X = this.Width / 2 - DataPanel.Width / 2;
            p.Y = this.Height - DataPanel.Height - 2;
            DataPanel.Location = p;

            
            size = new System.Drawing.Size();
            size.Width = middlesplitContainer.Width;
            size.Height = middlesplitContainer.Height;
            //hud1.Site = size;

            //HUDpanel.Size = size;
            //p.X = DataPanel.Location.X + leftsplitContainer.Panel1.Width + 4;
            //p.Y = DataPanel.Location.Y - HUDpanel.Height - 2;
            //HUDpanel.Location = p;

            leftsplitContainer.BackColor = Color.White;
            rightsplitContainer.BackColor = Color.White;
            middlesplitContainer.BackColor = Color.White;

        }
        public void DrawWarningMessage(string txt)
        {
            Graphics g = middlesplitContainer.CreateGraphics();
            g.Clear(middlesplitContainer.BackColor);
            Font font = new Font("SimSun", 16);
            float f = 16;
            Panel temp = middlesplitContainer;
            SizeF s = GetTextBounds(font, txt);
            while (true)
            {
                

                if (temp.Size.Width - s.Width < 12)
                    f -= 0.25f;

                font = new Font("SimSun", f);

                s = GetTextBounds(font, txt);

                if (temp.Size.Width - s.Width >= 12)
                    break;

            }

            g.DrawString(txt, font, Brushes.Red,0,0);

        }

        private SizeF GetTextBounds(Font font, string txt)
        {
            Bitmap bmp = new Bitmap(1, 1);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                SizeF size = g.MeasureString(txt,font);
                return size;
            }
        }

        private void middlepanel_Resize(object sender, EventArgs e)
        {

            if (middlebuttons.Count == 0)
            {
                originalmiddlesize = middlesplitContainer.Size;

                originalleftsize = leftsplitContainer.Panel1.Size;

                originalrightsize = rightsplitContainer.Panel2.Size;

                originalhudpanelsize = HUDpanel.Size;

                return;
            }

            System.Drawing.Size size = new System.Drawing.Size();
            size = new System.Drawing.Size();
            size.Width = (int)((float)panel12.Width * (float)((float)originalhudpanelsize.Width / (float)originalmiddlesize.Width));
            size.Height = (int)((float)panel12.Height * (float)((float)originalhudpanelsize.Height / (float)originalmiddlesize.Height));
            HUDpanel.Size = size;

            System.Drawing.Point p = new System.Drawing.Point();
            p.X = panel12.Width / 2 - HUDpanel.Width / 2;
            p.Y = 5;
            HUDpanel.Location = p;

            p.Y += HUDpanel.Height + 3;

            messagetext.Location = p;

            size.Height = 25;

            messagetext.Size = size;



            float wscale = (float)middlesplitContainer.Width / (float)originalmiddlesize.Width;
            float hscale = (float)middlesplitContainer.Height / (float)originalmiddlesize.Height;

            minfont = 0;
            float f = 0;
            int i = 0;
            for ( i = 0; i < middlebuttons.Count; i++)
            {

                Type t = middlebuttons[i].GetType();
                if (t.Name == "Button")
                {

                    Button temp = (Button)middlebuttons[i];

                    //if (temp.Location.X < 0 || temp.Location.Y < 0)
                    //    temp.Location = p;

                    if (wscale>1.0)
                         p.X = (int)Math.Floor((float)btnbounds[i].X * wscale);
                    else
                         p.X = (int)Math.Ceiling((float)btnbounds[i].X * wscale);

                    if (hscale > 1.0)
                        p.Y = (int)Math.Floor((float)btnbounds[i].Y * hscale);
                    else
                        p.Y = (int)Math.Ceiling((float)btnbounds[i].Y * hscale);

                    temp.Location = p;

                    if (wscale > 1.0)
                        size.Width = (int)Math.Floor((float)btnbounds[i].Width * wscale);
                    else
                        size.Width = (int)Math.Ceiling((float)btnbounds[i].Width * wscale);

                    if (hscale > 1.0)
                        size.Height = (int)Math.Floor((float)btnbounds[i].Height * hscale);
                    else
                        size.Height = (int)Math.Ceiling((float)btnbounds[i].Height * hscale);

                    temp.Size = size;

                    f = float.Parse(temp.Font.Size.ToString());

                    while(true)
                    {
                        SizeF s = GetTextBounds(temp.Font, temp.Text);

                        if (temp.Size.Width - s.Width < 12)
                            f -= 0.25f;
                        else if (temp.Size.Width - s.Width > 15)
                            f += 0.25f;

                        temp.Font = new Font("SimSun",f);

                        s = GetTextBounds(temp.Font, temp.Text);

                        if (temp.Size.Width - s.Width >= 12 && temp.Size.Width - s.Width <= 15)
                            break;

                    }

                    while (true)
                    {
                        SizeF s = GetTextBounds(temp.Font, temp.Text);

                        if (temp.Size.Height - s.Height < 5)
                            f -= 0.25f;

                        temp.Font = new Font("SimSun", f);

                        s = GetTextBounds(temp.Font, temp.Text);

                        if (temp.Size.Height - s.Height >= 5)
                            break;

                    }

                }

               // if (f < minfont)
                    minfont += f;

                if (t.Name == "ComboBox")
                {

                    ComboBox temp = (ComboBox)middlebuttons[i];

                    //if (temp.Location.X < 0 || temp.Location.Y < 0)
                   //     continue;
                    if (wscale > 1.0)
                        p.X = (int)Math.Floor((float)btnbounds[i].X * wscale);
                    else
                        p.X = (int)Math.Ceiling((float)btnbounds[i].X * wscale);

                    if (hscale > 1.0)
                        p.Y = (int)Math.Floor((float)btnbounds[i].Y * hscale);
                    else
                        p.Y = (int)Math.Ceiling((float)btnbounds[i].Y * hscale);

                    temp.Location = p;

                    if (wscale > 1.0)
                        size.Width = (int)Math.Floor((float)btnbounds[i].Width * wscale);
                    else
                        size.Width = (int)Math.Ceiling((float)btnbounds[i].Width * wscale);

                    if (hscale > 1.0)
                        size.Height = (int)Math.Floor((float)btnbounds[i].Height * hscale);
                    else
                        size.Height = (int)Math.Ceiling((float)btnbounds[i].Height * hscale);

                    temp.Size = size;
                }

            }

            minfont /= i;
            for ( i = 0; i < middlebuttons.Count; i++)
            {
                Type t = middlebuttons[i].GetType();
                if (t.Name == "Button")
                {
                    Button temp = (Button)middlebuttons[i];
                    if (temp.Text == "设置")
                        continue;
                    temp.Font = new Font("SimSun", minfont);
                    temp.BackColor = Color.White;
                }
                if(t.Name =="ComboBox")
                {
                    ComboBox temp = (ComboBox)middlebuttons[i];
                    //temp.Font = new Font("SimSun", minfont);
                    temp.BackColor = Color.White;
                }
            }

        }

        private void HsdevInterface_ParentChanged(object sender, EventArgs e)
        {
            if (MainV2.cam != null)
            {
               // MainV2.cam.camimage += cam_camimage;
            }

        }

        public void Activate()
        {
            log.Info("Activate Called");

            OnResize(EventArgs.Empty);

           // if (CB_tuning.Checked)
           //     ZedGraphTimer.Start();

            if (MainV2.MONO)
            {
                if (!hud1.Visible)
                    hud1.Visible = true;
                if (!hud1.Enabled)
                    hud1.Enabled = true;

                hud1.Dock = DockStyle.Fill;
            }

            for (int f = 1; f < 10; f++)
            {
                // load settings
                if (Settings.Instance["quickView" + f] != null)
                {
                    Control[] ctls = Controls.Find("quickView" + f, true);
                    if (ctls.Length > 0)
                    {
                        QuickView QV = (QuickView)ctls[0];

                        // set description and unit
                        string desc = Settings.Instance["quickView" + f];
                        QV.Tag = QV.desc;
                        QV.desc = MainV2.comPort.MAV.cs.GetNameandUnit(desc);

                        // set databinding for value
                        QV.DataBindings.Clear();
                        try
                        {
                            QV.DataBindings.Add(new Binding("number", bindingSourceQuickTab,
                                Settings.Instance["quickView" + f], false));
                        }
                        catch (Exception ex)
                        {
                            log.Debug(ex);
                        }
                    }
                }
                else
                {
                    // if no config, update description on predefined
                    try
                    {
                        Control[] ctls = Controls.Find("quickView" + f, true);
                        if (ctls.Length > 0)
                        {
                            QuickView QV = (QuickView)ctls[0];
                            string desc = QV.desc;
                            QV.Tag = desc;
                            QV.desc = MainV2.comPort.MAV.cs.GetNameandUnit(desc);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Debug(ex);
                    }
                }
            }

           // CheckBatteryShow();

            // make sure the hud user items/warnings/checklist are using the current state
            HUD.Custom.src = MainV2.comPort.MAV.cs;
            CustomWarning.defaultsrc = MainV2.comPort.MAV.cs;
            MissionPlanner.Controls.PreFlight.CheckListItem.defaultsrc = MainV2.comPort.MAV.cs;

            if (Settings.Instance["maplast_lat"] != "")
            {
                try
                {
                    gMapControl1.Position = new PointLatLng(Settings.Instance.GetDouble("maplast_lat"),
                        Settings.Instance.GetDouble("maplast_lng"));
                    if (Math.Round(Settings.Instance.GetDouble("maplast_lat"), 1) == 0)
                    {
                        // no zoom in
                       // Zoomlevel.Value = 3;
                       // TRK_zoom.Value = 3;
                    }
                    else
                    {
                        var zoom = Settings.Instance.GetFloat("maplast_zoom");
                       // if (Zoomlevel.Maximum < (decimal)zoom)
                        //    zoom = (float)Zoomlevel.Maximum;
                       // Zoomlevel.Value = (decimal)zoom;
                      //  TRK_zoom.Value = (float)Zoomlevel.Value;
                    }
                }
                catch
                {
                }
            }

            hud1.doResize();
        }

        public void Deactivate()
        {
            if (MainV2.MONO)
            {
                hud1.Dock = DockStyle.None;
                hud1.Size = new System.Drawing.Size(5, 5);
                hud1.Enabled = false;
                hud1.Visible = false;
            }
            //     hud1.Location = new Point(-1000,-1000);

            Settings.Instance["maplast_lat"] = gMapControl1.Position.Lat.ToString();
            Settings.Instance["maplast_lng"] = gMapControl1.Position.Lng.ToString();
            Settings.Instance["maplast_zoom"] = gMapControl1.Zoom.ToString();

           GraphTimer.Stop();
        }

        private void updateBindingSourceWork()
        {
            try
            {
                if (this.Visible)
                {
                    //Console.Write("bindingSource1 ");
                    MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSource1);
                    //Console.Write("bindingSourceHud ");
                    MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceHud);
                    //Console.WriteLine("DONE ");
/*
                    if (tabControlactions.SelectedTab == tabStatus)
                    {
                        MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceStatusTab);
                    }
                    else if (tabControlactions.SelectedTab == tabQuick)
                    {
                        MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceQuickTab);
                    }
                    else if (tabControlactions.SelectedTab == tabGauges)
                    {
                        MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceGaugesTab);
                    }
                    else if (tabControlactions.SelectedTab == tabPagePreFlight)
                    {
                        MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceGaugesTab);
                    }
                }
                else
*/
                //{
                    //Console.WriteLine("Null Binding");
                    MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceHud);
                }
                lastscreenupdate = DateTime.Now;
            }
            catch
            {
            }
        }

        DateTime lastscreenupdate = DateTime.Now;
        object updateBindingSourcelock = new object();
        volatile int updateBindingSourcecount;
        string updateBindingSourceThreadName = "";
        private void updateBindingSource()
        {
            //  run at 25 hz.
            if (lastscreenupdate.AddMilliseconds(40) < DateTime.Now)
            {
                // this is an attempt to prevent an invoke queue on the binding update on slow machines
                if (updateBindingSourcecount > 0)
                    return;

                lock (updateBindingSourcelock)
                {
                    updateBindingSourcecount++;
                    updateBindingSourceThreadName = Thread.CurrentThread.Name;
                }

                this.BeginInvokeIfRequired((MethodInvoker)delegate
                {
                    updateBindingSourceWork();

                    lock (updateBindingSourcelock)
                    {
                        updateBindingSourcecount--;
                    }
                });
            }
        }

        private void setMapBearing()
        {
            Invoke((MethodInvoker)delegate { gMapControl1.Bearing = (int)MainV2.comPort.MAV.cs.yaw; });
        }

        private void updateRoutePosition()
        {
            // not async
            Invoke((MethodInvoker)delegate
            {
                gMapControl1.UpdateRouteLocalPosition(route);
            });
        }

        private void updateClearMissionRouteMarkers()
        {
            // not async
            Invoke((MethodInvoker)delegate
            {
                polygons.Routes.Clear();
                polygons.Markers.Clear();
                routes.Markers.Clear();
            });
        }

        private void addpolygonmarkerred(string tag, double lng, double lat, int alt, Color? color, GMapOverlay overlay)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.red);
                m.ToolTipMode = MarkerTooltipMode.Always;
                m.ToolTipText = tag;
                m.Tag = tag;

                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                }

                Invoke((MethodInvoker)delegate
                {
                    overlay.Markers.Add(m);
                    overlay.Markers.Add(mBorders);
                });
            }
            catch (Exception)
            {
            }
        }

        private void addpolygonmarker(string tag, double lng, double lat, int alt, Color? color, GMapOverlay overlay)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.green);
                m.ToolTipMode = MarkerTooltipMode.Always;
                m.ToolTipText = tag;
                m.Tag = tag;

                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                    try
                    {
                        mBorders.wprad =
                            (int)(Settings.Instance.GetFloat("TXT_WPRad") / CurrentState.multiplierdist);
                    }
                    catch
                    {
                    }
                    if (color.HasValue)
                    {
                        mBorders.Color = color.Value;
                    }
                }

                Invoke((MethodInvoker)delegate
                {
                    overlay.Markers.Add(m);
                    overlay.Markers.Add(mBorders);
                });
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// used to redraw the polygon
        /// </summary>
        void RegeneratePolygon()
        {
            List<PointLatLng> polygonPoints = new List<PointLatLng>();

            if (routes == null)
                return;

            foreach (GMapMarker m in polygons.Markers)
            {
                if (m is GMapMarkerRect)
                {
                    m.Tag = polygonPoints.Count;
                    polygonPoints.Add(m.Position);
                }
            }

            if (polygonPoints.Count < 2)
                return;

            GMapRoute homeroute = new GMapRoute("homepath");
            homeroute.Stroke = new Pen(Color.Yellow, 2);
            homeroute.Stroke.DashStyle = DashStyle.Dash;
            // add first point past home
            homeroute.Points.Add(polygonPoints[1]);
            // add home location
            homeroute.Points.Add(polygonPoints[0]);
            // add last point
            homeroute.Points.Add(polygonPoints[polygonPoints.Count - 1]);

            GMapRoute wppath = new GMapRoute("wp path");
            wppath.Stroke = new Pen(Color.Yellow, 4);
            wppath.Stroke.DashStyle = DashStyle.Custom;

            for (int a = 1; a < polygonPoints.Count; a++)
            {
                wppath.Points.Add(polygonPoints[a]);
            }

            Invoke((MethodInvoker)delegate
            {
                polygons.Routes.Add(homeroute);
                polygons.Routes.Add(wppath);
            });
        }

        private void updateClearRoutesMarkers()
        {
            Invoke((MethodInvoker)delegate
            {
                routes.Markers.Clear();
            });
        }

        private void addMissionRouteMarker(GMapMarker marker)
        {
            // not async
            Invoke((MethodInvoker)delegate
            {
                routes.Markers.Add(marker);
            });
        }

        private void addMissionPhotoMarker(GMapMarker marker)
        {
            // not async
            Invoke((MethodInvoker)delegate
            {
                photosoverlay.Markers.Add(marker);
            });
        }

        DateTime lastmapposchange = DateTime.MinValue;
        private void updateMapPosition(PointLatLng currentloc)
        {
            Invoke((MethodInvoker)delegate
            {
                try
                {
                    if (lastmapposchange.Second != DateTime.Now.Second)
                    {
                        if (Math.Abs(currentloc.Lat - gMapControl1.Position.Lat) > 0.0001 || Math.Abs(currentloc.Lng - gMapControl1.Position.Lng) > 0.0001)
                        {
                            gMapControl1.Position = currentloc;
                        }
                        lastmapposchange = DateTime.Now;
                    }
                    //hud1.Refresh();
                }
                catch
                {
                }
            });
        }

        private void updateMapZoom(int zoom)
        {
            Invoke((MethodInvoker)delegate
            {
                try
                {
                    gMapControl1.Zoom = zoom;
                }
                catch
                {
                }
            });
        }

        private void mainloop()
        {
            threadrun = true;
            EndPoint Remote = new IPEndPoint(IPAddress.Any, 0);

            DateTime tracklast = DateTime.Now.AddSeconds(0);

            DateTime tunning = DateTime.Now.AddSeconds(0);

            DateTime mapupdate = DateTime.Now.AddSeconds(0);

            DateTime vidrec = DateTime.Now.AddSeconds(0);

            DateTime waypoints = DateTime.Now.AddSeconds(0);

            DateTime updatescreen = DateTime.Now;

            DateTime tsreal = DateTime.Now;
            double taketime = 0;
            double timeerror = 0;

            while (!IsHandleCreated)
                Thread.Sleep(1000);

            while (threadrun)
            {
                if (MainV2.comPort.giveComport)
                {
                    Thread.Sleep(50);
                    updateBindingSource();
                    continue;
                }

                if (!MainV2.comPort.logreadmode)
                    Thread.Sleep(50); // max is only ever 10 hz but we go a little faster to empty the serial queue

                try
                {
                    if (aviwriter != null && vidrec.AddMilliseconds(100) <= DateTime.Now)
                    {
                        vidrec = DateTime.Now;

                        hud1.streamjpgenable = true;

                        //aviwriter.avi_start("test.avi");
                        // add a frame
                        aviwriter.avi_add(hud1.streamjpg.ToArray(), (uint)hud1.streamjpg.Length);
                        // write header - so even partial files will play
                        aviwriter.avi_end(hud1.Width, hud1.Height, 10);
                    }
                }
                catch
                {
                    log.Error("Failed to write avi");
                }

                // log playback
                if (MainV2.comPort.logreadmode && MainV2.comPort.logplaybackfile != null)
                {
                    if (MainV2.comPort.BaseStream.IsOpen)
                    {
                        MainV2.comPort.logreadmode = false;
                        try
                        {
                            MainV2.comPort.logplaybackfile.Close();
                        }
                        catch
                        {
                            log.Error("Failed to close logfile");
                        }
                        MainV2.comPort.logplaybackfile = null;
                    }


                    //Console.WriteLine(DateTime.Now.Millisecond);

                    if (updatescreen.AddMilliseconds(300) < DateTime.Now)
                    {
                        try
                        {
                           // updatePlayPauseButton(true);
                           // updateLogPlayPosition();
                        }
                        catch
                        {
                            log.Error("Failed to update log playback pos");
                        }
                        updatescreen = DateTime.Now;
                    }

                    //Console.WriteLine(DateTime.Now.Millisecond + " done ");

                    DateTime logplayback = MainV2.comPort.lastlogread;
                    try
                    {
                        if (!MainV2.comPort.giveComport)
                            MainV2.comPort.readPacket();

                        // update currentstate of sysids on the port
                        foreach (var MAV in MainV2.comPort.MAVlist)
                        {
                            try
                            {
                                MAV.cs.UpdateCurrentSettings(null, false, MainV2.comPort, MAV);
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                    }
                    catch
                    {
                        log.Error("Failed to read log packet");
                    }

                    double act = (MainV2.comPort.lastlogread - logplayback).TotalMilliseconds;

                    if (act > 9999 || act < 0)
                        act = 0;

                    double ts = 0;
                    if (LogPlayBackSpeed == 0)
                        LogPlayBackSpeed = 0.01;
                    try
                    {
                        ts = Math.Min((act / LogPlayBackSpeed), 1000);
                    }
                    catch
                    {
                    }

                    if (LogPlayBackSpeed >= 4 && MainV2.speechEnable)
                        MainV2.speechEngine.SpeakAsyncCancelAll();

                    double timetook = (DateTime.Now - tsreal).TotalMilliseconds;
                    if (timetook != 0)
                    {
                        //Console.WriteLine("took: " + timetook + "=" + taketime + " " + (taketime - timetook) + " " + ts);
                        //Console.WriteLine(MainV2.comPort.lastlogread.Second + " " + DateTime.Now.Second + " " + (MainV2.comPort.lastlogread.Second - DateTime.Now.Second));
                        //if ((taketime - timetook) < 0)
                        {
                            timeerror += (taketime - timetook);
                            if (ts != 0)
                            {
                                ts += timeerror;
                                timeerror = 0;
                            }
                        }
                        if (Math.Abs(ts) > 1000)
                            ts = 1000;
                    }

                    taketime = ts;
                    tsreal = DateTime.Now;

                    if (ts > 0 && ts < 1000)
                        Thread.Sleep((int)ts);

                    tracklast = tracklast.AddMilliseconds(ts - act);
                    tunning = tunning.AddMilliseconds(ts - act);

                    if (tracklast.Month != DateTime.Now.Month)
                    {
                        tracklast = DateTime.Now;
                        tunning = DateTime.Now;
                    }

                    try
                    {
                        if (MainV2.comPort.logplaybackfile != null &&
                            MainV2.comPort.logplaybackfile.BaseStream.Position ==
                            MainV2.comPort.logplaybackfile.BaseStream.Length)
                        {
                            MainV2.comPort.logreadmode = false;
                        }
                    }
                    catch
                    {
                        MainV2.comPort.logreadmode = false;
                    }
                }
                else
                {
                    // ensure we know to stop
                    if (MainV2.comPort.logreadmode)
                        MainV2.comPort.logreadmode = false;
                   // updatePlayPauseButton(false);

                    if (!playingLog && MainV2.comPort.logplaybackfile != null)
                    {
                        continue;
                    }
                }

                try
                {
                    //CheckAndBindPreFlightData();
                    //Console.WriteLine(DateTime.Now.Millisecond);
                    //int fixme;
                    updateBindingSource();
                    // Console.WriteLine(DateTime.Now.Millisecond + " done ");
                    updateleftpanel();
                    updaterightpanel();

                    if (MainV2.comPort.MAV.cs.messageHigh != "" && MainV2.comPort.MAV.cs.messageHighTime.AddSeconds(10) > DateTime.Now)
                    {
                        messagetext.Text = MainV2.comPort.MAV.cs.messageHigh;
                    }

                    // battery warning.
                    float warnvolt = Settings.Instance.GetFloat("speechbatteryvolt");
                    float warnpercent = Settings.Instance.GetFloat("speechbatterypercent");

                    if (MainV2.comPort.MAV.cs.battery_voltage <= warnvolt)
                    {
                        hud1.lowvoltagealert = true;
                    }
                    else if ((MainV2.comPort.MAV.cs.battery_remaining) < warnpercent)
                    {
                        hud1.lowvoltagealert = true;
                    }
                    else
                    {
                        hud1.lowvoltagealert = false;
                    }

                    // update opengltest
                    if (OpenGLtest.instance != null)
                    {
                        OpenGLtest.instance.rpy = new Vector3(MainV2.comPort.MAV.cs.roll, MainV2.comPort.MAV.cs.pitch,
                            MainV2.comPort.MAV.cs.yaw);
                        OpenGLtest.instance.LocationCenter = new PointLatLngAlt(MainV2.comPort.MAV.cs.lat,
                            MainV2.comPort.MAV.cs.lng, MainV2.comPort.MAV.cs.altasl, "here");
                    }

                    // update opengltest2
                    if (OpenGLtest2.instance != null)
                    {
                        OpenGLtest2.instance.rpy = new Vector3(MainV2.comPort.MAV.cs.roll, MainV2.comPort.MAV.cs.pitch,
                            MainV2.comPort.MAV.cs.yaw);
                        OpenGLtest2.instance.LocationCenter = new PointLatLngAlt(MainV2.comPort.MAV.cs.lat,
                            MainV2.comPort.MAV.cs.lng, MainV2.comPort.MAV.cs.altasl, "here");
                    }

                    // update vario info
                    Vario.SetValue(MainV2.comPort.MAV.cs.climbrate);

                    // update map
                    if (tracklast.AddSeconds(1.2) < DateTime.Now)
                    {
                        if (Settings.Instance.GetBoolean("CHK_maprotation"))
                        {
                            // dont holdinvalidation here
                            setMapBearing();
                        }

                        if (route == null)
                        {
                            route = new GMapRoute(trackPoints, "track");
                            routes.Routes.Add(route);
                        }

                        PointLatLng currentloc = new PointLatLng(MainV2.comPort.MAV.cs.lat, MainV2.comPort.MAV.cs.lng);

                        gMapControl1.HoldInvalidation = true;

                        int numTrackLength = Settings.Instance.GetInt32("NUM_tracklength");
                        // maintain route history length
                        if (route.Points.Count > numTrackLength)
                        {
                            route.Points.RemoveRange(0,
                                route.Points.Count - numTrackLength);
                        }
                        // add new route point
                        if (MainV2.comPort.MAV.cs.lat != 0 && MainV2.comPort.MAV.cs.lng != 0)
                        {
                            route.Points.Add(currentloc);
                        }

                        updateRoutePosition();

                        // update programed wp course
                        if (waypoints.AddSeconds(5) < DateTime.Now)
                        {
                            //Console.WriteLine("Doing FD WP's");
                            updateClearMissionRouteMarkers();

                            float dist = 0;
                            float travdist = 0;
                            //distanceBar1.ClearWPDist();
                            MAVLink.mavlink_mission_item_t lastplla = new MAVLink.mavlink_mission_item_t();
                            MAVLink.mavlink_mission_item_t home = new MAVLink.mavlink_mission_item_t();

                            foreach (MAVLink.mavlink_mission_item_t plla in MainV2.comPort.MAV.wps.Values)
                            {
                                if (plla.x == 0 || plla.y == 0)
                                    continue;

                                if (plla.command == (ushort)MAVLink.MAV_CMD.DO_SET_ROI)
                                {
                                    addpolygonmarkerred(plla.seq.ToString(), plla.y, plla.x, (int)plla.z, Color.Red,
                                        routes);
                                    continue;
                                }

                                string tag = plla.seq.ToString();
                                if (plla.seq == 0 && plla.current != 2)
                                {
                                    tag = "Home";
                                    home = plla;
                                }
                                if (plla.current == 2)
                                {
                                    continue;
                                }

                                if (lastplla.command == 0)
                                    lastplla = plla;

                                try
                                {
                                    dist =
                                        (float)
                                            new PointLatLngAlt(plla.x, plla.y).GetDistance(new PointLatLngAlt(
                                                lastplla.x, lastplla.y));

                                    //distanceBar1.AddWPDist(dist);

                                    if (plla.seq <= MainV2.comPort.MAV.cs.wpno)
                                    {
                                        travdist += dist;
                                    }

                                    lastplla = plla;
                                }
                                catch
                                {
                                }

                                addpolygonmarker(tag, plla.y, plla.x, (int)plla.z, Color.White, polygons);
                            }

                            try
                            {
                                //dist = (float)new PointLatLngAlt(home.x, home.y).GetDistance(new PointLatLngAlt(lastplla.x, lastplla.y));
                                // distanceBar1.AddWPDist(dist);
                            }
                            catch
                            {
                            }

                            travdist -= MainV2.comPort.MAV.cs.wp_dist;

                            if (MainV2.comPort.MAV.cs.mode.ToUpper() == "AUTO") ;
                                //distanceBar1.traveleddist = travdist;

                            RegeneratePolygon();

                            // update rally points

                            rallypointoverlay.Markers.Clear();

                            foreach (var mark in MainV2.comPort.MAV.rallypoints.Values)
                            {
                                rallypointoverlay.Markers.Add(new GMapMarkerRallyPt(mark));
                            }

                            // optional on Flight data
                            if (MainV2.ShowAirports)
                            {
                                // airports
                                foreach (var item in Airports.getAirports(gMapControl1.Position))
                                {
                                    rallypointoverlay.Markers.Add(new GMapMarkerAirport(item)
                                    {
                                        ToolTipText = item.Tag,
                                        ToolTipMode = MarkerTooltipMode.OnMouseOver
                                    });
                                }
                            }
                            waypoints = DateTime.Now;
                        }

                        updateClearRoutesMarkers();

                        // add this after the mav icons are drawn
                        if (MainV2.comPort.MAV.cs.MovingBase != null)
                        {
                            addMissionRouteMarker(new GMarkerGoogle(currentloc, GMarkerGoogleType.blue_dot)
                            {
                                Position = MainV2.comPort.MAV.cs.MovingBase,
                                ToolTipText = "Moving Base",
                                ToolTipMode = MarkerTooltipMode.OnMouseOver
                            });
                        }

                        // add gimbal point center
                        try
                        {
                            if (MainV2.comPort.MAV.param.ContainsKey("MNT_STAB_TILT")
                                && MainV2.comPort.MAV.param.ContainsKey("MNT_STAB_ROLL")
                                && MainV2.comPort.MAV.param.ContainsKey("MNT_TYPE"))
                            {
                                float temp1 = (float)MainV2.comPort.MAV.param["MNT_STAB_TILT"];
                                float temp2 = (float)MainV2.comPort.MAV.param["MNT_STAB_ROLL"];

                                float temp3 = (float)MainV2.comPort.MAV.param["MNT_TYPE"];

                                if (MainV2.comPort.MAV.param.ContainsKey("MNT_STAB_PAN") &&
                                    // (float)MainV2.comPort.MAV.param["MNT_STAB_PAN"] == 1 &&
                                    ((float)MainV2.comPort.MAV.param["MNT_STAB_TILT"] == 1 &&
                                      (float)MainV2.comPort.MAV.param["MNT_STAB_ROLL"] == 0) ||
                                     (float)MainV2.comPort.MAV.param["MNT_TYPE"] == 4) // storm driver
                                {
                                    var marker = GimbalPoint.ProjectPoint();

                                    if (marker != PointLatLngAlt.Zero)
                                    {
                                        MainV2.comPort.MAV.cs.GimbalPoint = marker;

                                        addMissionRouteMarker(new GMarkerGoogle(marker, GMarkerGoogleType.blue_dot)
                                        {
                                            ToolTipText = "Camera Target\n" + marker,
                                            ToolTipMode = MarkerTooltipMode.OnMouseOver
                                        });
                                    }
                                }
                            }


                            // cleanup old - no markers where added, so remove all old 
                            if (MainV2.comPort.MAV.camerapoints.Count == 0)
                                photosoverlay.Markers.Clear();

                            var min_interval = 0.0;
                            if (MainV2.comPort.MAV.param.ContainsKey("CAM_MIN_INTERVAL"))
                                min_interval = MainV2.comPort.MAV.param["CAM_MIN_INTERVAL"].Value / 1000.0;

                            // set fov's based on last grid calc
                            if (Settings.Instance["camera_fovh"] != null)
                            {
                                GMapMarkerPhoto.hfov = Settings.Instance.GetDouble("camera_fovh");
                                GMapMarkerPhoto.vfov = Settings.Instance.GetDouble("camera_fovv");
                            }

                            // add new - populate camera_feedback to map
                            double oldtime = double.MinValue;
                            foreach (var mark in MainV2.comPort.MAV.camerapoints.ToArray())
                            {
                                var timesincelastshot = (mark.time_usec / 1000.0) / 1000.0 - oldtime;
                                MainV2.comPort.MAV.cs.timesincelastshot = timesincelastshot;
                                bool contains = photosoverlay.Markers.Any(p => p.Tag.Equals(mark.time_usec));
                                if (!contains)
                                {
                                    if (timesincelastshot < min_interval)
                                        addMissionPhotoMarker(new GMapMarkerPhoto(mark, true));
                                    else
                                        addMissionPhotoMarker(new GMapMarkerPhoto(mark, false));
                                }
                                oldtime = (mark.time_usec / 1000.0) / 1000.0;
                            }

                            // age current
                            int camcount = MainV2.comPort.MAV.camerapoints.Count;
                            int a = 0;
                            foreach (var mark in photosoverlay.Markers)
                            {
                                if (mark is GMapMarkerPhoto)
                                {
                                    if (CameraOverlap)
                                    {
                                        var marker = ((GMapMarkerPhoto)mark);
                                        // abandon roll higher than 25 degrees
                                        if (Math.Abs(marker.Roll) < 25)
                                        {
                                            MainV2.comPort.MAV.GMapMarkerOverlapCount.Add(
                                                ((GMapMarkerPhoto)mark).footprintpoly);
                                        }
                                    }
                                    if (a < (camcount - 4))
                                        ((GMapMarkerPhoto)mark).drawfootprint = false;
                                }
                                a++;
                            }

                            if (CameraOverlap)
                            {
                                if (!kmlpolygons.Markers.Contains(MainV2.comPort.MAV.GMapMarkerOverlapCount) &&
                                    camcount > 0)
                                {
                                    kmlpolygons.Markers.Clear();
                                    kmlpolygons.Markers.Add(MainV2.comPort.MAV.GMapMarkerOverlapCount);
                                }
                            }
                            else if (kmlpolygons.Markers.Contains(MainV2.comPort.MAV.GMapMarkerOverlapCount))
                            {
                                kmlpolygons.Markers.Clear();
                            }
                        }
                        catch
                        {
                        }

                        lock (MainV2.instance.adsblock)
                        {
                            foreach (adsb.PointLatLngAltHdg plla in MainV2.instance.adsbPlanes.Values)
                            {
                                // 30 seconds history
                                if (((DateTime)plla.Time) > DateTime.Now.AddSeconds(-30))
                                {
                                    var adsbplane = new GMapMarkerADSBPlane(plla, plla.Heading)
                                    {
                                        ToolTipText = "ICAO: " + plla.Tag + " " + plla.Alt.ToString("0"),
                                        ToolTipMode = MarkerTooltipMode.OnMouseOver,
                                        Tag = plla
                                    };

                                    if (plla.DisplayICAO)
                                        adsbplane.ToolTipMode = MarkerTooltipMode.Always;

                                    switch (plla.ThreatLevel)
                                    {
                                        case MAVLink.MAV_COLLISION_THREAT_LEVEL.NONE:
                                            adsbplane.AlertLevel = GMapMarkerADSBPlane.AlertLevelOptions.Green;
                                            break;
                                        case MAVLink.MAV_COLLISION_THREAT_LEVEL.LOW:
                                            adsbplane.AlertLevel = GMapMarkerADSBPlane.AlertLevelOptions.Orange;
                                            break;
                                        case MAVLink.MAV_COLLISION_THREAT_LEVEL.HIGH:
                                            adsbplane.AlertLevel = GMapMarkerADSBPlane.AlertLevelOptions.Red;
                                            break;
                                    }

                                    addMissionRouteMarker(adsbplane);
                                }
                            }
                        }


                        if (route.Points.Count > 0)
                        {
                            // add primary route icon

                            // draw guide mode point for only main mav
                            if (MainV2.comPort.MAV.cs.mode.ToLower() == "guided" && MainV2.comPort.MAV.GuidedMode.x != 0)
                            {
                                addpolygonmarker("Guided Mode", MainV2.comPort.MAV.GuidedMode.y,
                                    MainV2.comPort.MAV.GuidedMode.x, (int)MainV2.comPort.MAV.GuidedMode.z, Color.Blue,
                                    routes);
                            }

                            // draw all icons for all connected mavs
                            foreach (var port in MainV2.Comports)
                            {
                                // draw the mavs seen on this port
                                foreach (var MAV in port.MAVlist)
                                {
                                    var marker = Common.getMAVMarker(MAV);

                                    addMissionRouteMarker(marker);
                                }
                            }

                            if (route.Points.Count == 0 || route.Points[route.Points.Count - 1].Lat != 0 &&
                                (mapupdate.AddSeconds(3) < DateTime.Now) && autopan)
                            {
                                updateMapPosition(currentloc);
                                mapupdate = DateTime.Now;
                            }

                            if (route.Points.Count == 1 && gMapControl1.Zoom == 3) // 3 is the default load zoom
                            {
                                updateMapPosition(currentloc);
                                updateMapZoom(17);
                            }
                        }

                        gMapControl1.HoldInvalidation = false;

                        if (gMapControl1.Visible)
                        {
                            gMapControl1.Invalidate();
                        }

                        tracklast = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    Tracking.AddException(ex);
                    Console.WriteLine("FD Main loop exception " + ex);
                }
            }
            Console.WriteLine("FD Main loop exit");
        }

        private void LRpanel_draw(Graphics g, CurrentState cs, ref LabelInfo labels, float areascale, float fontsize, float xscale, float yscale)
        {
            Font fnt = new Font("SimSun", fontsize);
            float lab_x = 0;
            float lab_y = 0;
            string drawtext = "";
            lab_x = labels.label.Location.X * xscale;
            lab_y = labels.label.Location.Y * yscale;
            drawtext = labels.label.Text;
            g.DrawString(drawtext, fnt, Brushes.White, lab_x, lab_y);
            SizeF f = GetTextBounds(fnt, drawtext);
            Dictionary<String, PropertyInfo> temp = (Dictionary<String, PropertyInfo>)paneltable[labels.label.Name];
            PropertyInfo val = temp[labels.label.Name];
            object value = Convert.ChangeType(val.GetValue(cs, null), TypeCode.Double);
            double s = (double)value;
            string strvalue = s.ToString(labels.digit);
            if (labels.strswap != null)
            {
                strvalue = labels.strswap[(int)s];
            }
            Brush brush = new SolidBrush(Color.White);
            if (HSSetting.hsdatas.ContainsKey(labels.label.Name))
            {
                HSSetting.hsdatainfo datainfo = HSSetting.hsdatas[labels.label.Name];
                if (datainfo.enablecolor)
                {
                    if (s >= datainfo.greenminvalue && s <= datainfo.greenmaxvalue)
                    {
                        brush = new SolidBrush(Color.Green);
                    }
                    if (s >= datainfo.whiteminvalue && s <= datainfo.whitemaxvalue)
                    {
                        brush = new SolidBrush(Color.White);
                    }
                    if (s >= datainfo.redminvalue && s <= datainfo.redmaxvalue)
                    {
                        brush = new SolidBrush(Color.Red);

                        if (datainfo.enablevoice)
                        {
                            if (labels.voicetime.AddMilliseconds(10000) < DateTime.Now)
                            {
                                LabelInfo tempmod = labels;
                                tempmod.voicetime = DateTime.Now;
                                labels = tempmod;

                                if (MainV2.comPort.BaseStream.IsOpen)
                                {
                                    if (datainfo.enableautoonlyvoice)
                                    {
                                        if (MainV2.comPort.MAV.cs.mode == "Auto")
                                        {
                                            //voice
                                            if (datainfo.voicecontent != null && datainfo.voicecontent != "")
                                            {
                                                lock (voicealarm)
                                                {
                                                    voicealarm.Add(datainfo.voicecontent);
                                                }
                                            }
                                            else
                                            {
                                                string v = labels.label.Text;
                                                v = v.Substring(0, v.Length - 1);
                                                v = v + "数值在报警范围";
                                                lock (voicealarm)
                                                {
                                                    voicealarm.Add(v);
                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (datainfo.voicecontent != null && datainfo.voicecontent != "")
                                        {
                                            lock (voicealarm)
                                            {
                                                voicealarm.Add(datainfo.voicecontent);
                                            }
                                        }
                                        else
                                        {
                                            string v = labels.label.Text;
                                            v = v.Substring(0, v.Length - 1);
                                            v = v + "数值在报警范围";
                                            lock (voicealarm)
                                            {
                                                voicealarm.Add(v);
                                            }
                                        }
                                    }
                                }
                            }
                        }//if(datainfo.enablevoice)


                    }

                }
            }
            g.DrawString(strvalue + labels.unit, fnt, brush, lab_x + f.Width, lab_y);
        }


        void leftpanel_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = leftdatapanel.CreateGraphics();
            Bitmap bmp = new Bitmap(leftdatapanel.Width,leftdatapanel.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            g.Clear(leftdatapanel.BackColor);
            CurrentState cs = MainV2.comPort.MAV.cs;

           float fontsize = alt.Font.Size;
           
           float areascale = 0;
           areascale = originalleftsize.Width * originalleftsize.Height;
           areascale = leftsplitContainer.Panel1.Width * leftsplitContainer.Panel1.Height / areascale;
           areascale *= 1.5f;
           float xscale = (float)leftsplitContainer.Panel1.Width / (float)originalleftsize.Width;
           float yscale = (float)leftsplitContainer.Panel1.Height / (float)originalleftsize.Height;


            fontsize = Math.Min(Math.Max(fontsize * areascale, 8), 12);


            for (int i = 0; i < leftlabels.Count; i++)
            {
                LabelInfo tempmod = leftlabels[i];
                LRpanel_draw(g, cs, ref tempmod, areascale, fontsize, xscale, yscale);
                leftlabels[i] = tempmod;
            }
            using (Graphics tg = e.Graphics)
            {
                tg.DrawImage(bmp, 0, 0);　　//把画布贴到画面上
            }
        }



        DateTime lastleftpanelscreenupdate = DateTime.Now;
        private void updateleftpanel()
        {

            //  run at 60 hz.
            if (lastleftpanelscreenupdate.AddMilliseconds(100) < DateTime.Now)
            {
                lastleftpanelscreenupdate = DateTime.Now;
                // not async
                Invoke((MethodInvoker)delegate
                {
                    leftsplitContainer.Panel1.Invalidate();
                });
            }
        }

        void rightpanel_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(rightdatapanel.Width, rightdatapanel.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            g.Clear(rightdatapanel.BackColor);
            CurrentState cs = MainV2.comPort.MAV.cs;

            float fontsize = alt.Font.Size;

            float areascale = 0;
            areascale = originalrightsize.Width * originalrightsize.Height;
            areascale = rightsplitContainer.Panel2.Width * rightsplitContainer.Panel2.Height / areascale;
            areascale *= 1.5f;
            float xscale = (float)rightsplitContainer.Panel2.Width / (float)originalrightsize.Width;
            float yscale = (float)rightsplitContainer.Panel2.Height / (float)originalrightsize.Height;

            fontsize = Math.Min(Math.Max(fontsize * areascale,8),12);

            for (int i = 0; i < rightlabels.Count; i++)
            {
                LabelInfo tempmod = rightlabels[i];
                LRpanel_draw(g, cs, ref tempmod, areascale, fontsize, xscale, yscale);
                rightlabels[i] = tempmod;
            }
            using (Graphics tg = e.Graphics)
            {
                tg.DrawImage(bmp, 0, 0);　　//把画布贴到画面上
            }
        }



        DateTime lastrightpanelscreenupdate = DateTime.Now;
        private void updaterightpanel()
        {
            //  run at 60 hz.
            if (lastrightpanelscreenupdate.AddMilliseconds(100) < DateTime.Now)
            {
                lastrightpanelscreenupdate = DateTime.Now;
                // not async
                Invoke((MethodInvoker)delegate
                {
                    rightsplitContainer.Panel2.Invalidate();
                });
            }
        }

        private void btn_prearm_Click(object sender, EventArgs e)
        {
            GCSViews.ConfigurationView.PrearmCheck prearm = new ConfigurationView.PrearmCheck();
            prearm.Prearmcheckload(prearmcheck);
            prearm.ShowDialog(this);


        }

        private void btn_arm_Click(object sender, EventArgs e)
        {
            if (!MainV2.comPort.BaseStream.IsOpen)
                return;

            if (!MainV2.comPort.MAV.cs.armed)
            {
                for (int i = 0; i < prearmcheck.Count(); i++)
                {
                    if (prearmcheck[i] == false)
                    {
                        CustomMessageBox.Show("没有完成起飞检查！", Strings.ERROR);
                        return;
                    }
                }
            }
                // arm the MAV
            try
            {
                if (MainV2.comPort.MAV.cs.armed)
                    if (CustomMessageBox.Show("确定要锁定电机吗?", "锁定?", MessageBoxButtons.YesNo) !=
                        DialogResult.Yes)
                        return;

                bool ans = MainV2.comPort.doARM(!MainV2.comPort.MAV.cs.armed);
                if (ans == false)
                    CustomMessageBox.Show(Strings.ErrorRejectedByMAV, Strings.ERROR);
                else
                {
                    if (!MainV2.comPort.MAV.cs.armed)
                        btn_arm.Text = "锁定";
                    else
                        btn_arm.Text = "解锁";
                }
            }
            catch
            {
                CustomMessageBox.Show(Strings.ErrorNoResponce, Strings.ERROR);
            }
        }

        private void btn_rtl_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setMode("RTL");
            }
            catch { CustomMessageBox.Show("The Command failed to execute", "Error"); }
            ((Button)sender).Enabled = true;
        }

        private void btn_auto_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setMode("Auto");
            }
            catch { CustomMessageBox.Show("The Command failed to execute", "Error"); }
            ((Button)sender).Enabled = true;
        }

        private void btn_normalland_Click(object sender, EventArgs e)
        {
            UInt32 wp = MainV2.instance.FlightPlanner.GetLandWaypoint();
            if (wp == 0xffffffff)
            {
                CustomMessageBox.Show("没有找到降落点", "错误");
            }
            MainV2.comPort.setWPCurrent((ushort)wp); // set nav to
            MainV2.comPort.setMode("Auto");
        }

        private void btn_qrtlemergent_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setMode("QRTL");
            }
            catch { CustomMessageBox.Show("指令执行失败", "错误"); }
            ((Button)sender).Enabled = true;
        }

        private void btn_qlandemergent_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setMode("QLAND");
            }
            catch { CustomMessageBox.Show("指令执行失败", "错误"); }
            ((Button)sender).Enabled = true;
        }

        private void btn_qhover_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setMode("QHOVER");
            }
            catch { CustomMessageBox.Show("指令执行失败", "错误"); }
            ((Button)sender).Enabled = true;
        }

        private void btn_manual_Click(object sender, EventArgs e)
        {
            MainV2.comPort.setMode("Manual");
        }

        private void btn_stabilize_Click(object sender, EventArgs e)
        {
            MainV2.comPort.setMode("STABILIZE");
        }

        private void btn_setwp_Click(object sender, EventArgs e)
        {
            if (CMB_setwp.SelectedIndex == -1)
                return;
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setWPCurrent((ushort)CMB_setwp.SelectedIndex); // set nav to
            }
            catch { CustomMessageBox.Show("The command failed to execute", "Error"); }
            ((Button)sender).Enabled = true;
        }

        private void CMB_setwp_Click(object sender, EventArgs e)
        {
            CMB_setwp.Items.Clear();
            CMB_setwp.ForeColor = Color.Black;
            CMB_setwp.Items.Add("0 (Home)");

            if (MainV2.comPort.MAV.param["CMD_TOTAL"] != null)
            {
                int wps = int.Parse(MainV2.comPort.MAV.param["CMD_TOTAL"].ToString());
                for (int z = 1; z <= wps; z++)
                {
                    CMB_setwp.Items.Add(z.ToString());
                }
                return;
            }

            if (MainV2.comPort.MAV.param["WP_TOTAL"] != null)
            {
                int wps = int.Parse(MainV2.comPort.MAV.param["WP_TOTAL"].ToString());
                for (int z = 1; z <= wps; z++)
                {
                    CMB_setwp.Items.Add(z.ToString());
                }
                return;
            }

            if (MainV2.comPort.MAV.param["MIS_TOTAL"] != null)
            {
                int wps = int.Parse(MainV2.comPort.MAV.param["MIS_TOTAL"].ToString());
                for (int z = 1; z <= wps; z++)
                {
                    CMB_setwp.Items.Add(z.ToString());
                }
                return;
            }

            if (MainV2.comPort.MAV.wps.Count > 0)
            {
                int wps = MainV2.comPort.MAV.wps.Count;
                for (int z = 1; z <= wps; z++)
                {
                    CMB_setwp.Items.Add(z.ToString());
                }
                return;
            }
        }

        private void btn_parachute_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuAutoDrog_Click(object sender, EventArgs e)
        {
            Settings.Instance["CHK_autopan"] = (!Settings.Instance.GetBoolean("CHK_autopan")).ToString();
            autopan = !autopan;
        }

        private void toolStripMenuQLAND_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setMode("QLAND");
            }
            catch { CustomMessageBox.Show("指令执行失败", "错误"); }
            ((Button)sender).Enabled = true;
        }

        private void toolStripMenuRTL_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setMode("RTL");
            }
            catch { CustomMessageBox.Show("The Command failed to execute", "Error"); }
            ((Button)sender).Enabled = true;
        }

        private void toolStripMenuQRTL_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setMode("QRTL");
            }
            catch { CustomMessageBox.Show("指令执行失败", "错误"); }
            ((Button)sender).Enabled = true;
        }

        private void DataPanel_Layout(object sender, LayoutEventArgs e)
        {
        }

    }
}
