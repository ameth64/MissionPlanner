﻿using System;
using System.Collections.Generic; // Lists
using System.Text; // stringbuilder
using System.Drawing; // pens etc
using System.IO; // file io
using System.IO.Ports; // serial
using System.Windows.Forms; // Forms
using System.Collections; // hashs
using System.Text.RegularExpressions; // regex
using System.Xml; // GE xml alt reader
using System.Net; // dns, ip address
using System.Net.Sockets; // tcplistner
using System.Threading;
using GMap.NET;
using GMap.NET.WindowsForms;
using System.Globalization; // language
using GMap.NET.WindowsForms.Markers;
using ZedGraph; // Graphs
using System.Drawing.Drawing2D;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using MissionPlanner.Controls.BackstageView;
//using Crom.Controls.Docking;
using System.Media;
using log4net;
using System.Reflection;
using MissionPlanner.Log;


// written by michael oborne
namespace MissionPlanner.GCSViews
{
    public partial class HsdevFlightData : MyUserControl
    {
        public static int threadrun = 0;
        SynchronizationContext m_SyncContext = null;
        System.IO.Stream stream;
        SoundPlayer sp;

        DateTime start;

        internal static GMapOverlay kmlpolygons;
        internal static GMapOverlay geofence;
        public GMapOverlay shotposition;
        public void addshotposition(double Lng, double Lat)
        {
            PointLatLng result = new PointLatLng();
            result.Lng = Lng;
            result.Lat = Lat;
            shotposition.Markers.Add(new GMapMarkerCamera(result, 0, 0, 0, 0, gMapControl1));
        }

        Dictionary<Guid, Form> formguids = new Dictionary<Guid, Form>();

        bool huddropout = false;
        bool huddropoutresize = false;

        //      private DockStateSerializer _serializer = null;

        List<PointLatLng> trackPoints = new List<PointLatLng>();

        const float rad2deg = (float)(180 / Math.PI);

        const float deg2rad = (float)(1.0 / rad2deg);

        public static Controls.HUD myhud = null;
        public static GMapControl mymap = null;

        bool playingLog = false;
        double LogPlayBackSpeed = 1.0;

        GMapMarker marker;

        GMapPolygon polygon;
        GMapOverlay polygons;
        GMapOverlay routes;
        GMapRoute route;

        public SplitContainer MainHcopy = null;

        public static FlightData instance;

        int tickStart = 0;

        private bool zg1_show = false;

        RollingPointPairList list1 = new RollingPointPairList(1200);
        RollingPointPairList list2 = new RollingPointPairList(1200);
        RollingPointPairList list3 = new RollingPointPairList(1200);
        RollingPointPairList list4 = new RollingPointPairList(1200);
        RollingPointPairList list5 = new RollingPointPairList(1200);
        RollingPointPairList list6 = new RollingPointPairList(1200);
        RollingPointPairList list7 = new RollingPointPairList(1200);
        RollingPointPairList list8 = new RollingPointPairList(1200);
        RollingPointPairList list9 = new RollingPointPairList(1200);
        RollingPointPairList list10 = new RollingPointPairList(1200);

        System.Reflection.PropertyInfo list1item = null;
        System.Reflection.PropertyInfo list2item = null;
        System.Reflection.PropertyInfo list3item = null;
        System.Reflection.PropertyInfo list4item = null;
        System.Reflection.PropertyInfo list5item = null;
        System.Reflection.PropertyInfo list6item = null;
        System.Reflection.PropertyInfo list7item = null;
        System.Reflection.PropertyInfo list8item = null;
        System.Reflection.PropertyInfo list9item = null;
        System.Reflection.PropertyInfo list10item = null;

        CurveItem list1curve;
        CurveItem list2curve;
        CurveItem list3curve;
        CurveItem list4curve;
        CurveItem list5curve;
        CurveItem list6curve;
        CurveItem list7curve;
        CurveItem list8curve;
        CurveItem list9curve;
        CurveItem list10curve;


        public HsdevFlightData()
        {

            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            m_SyncContext = SynchronizationContext.Current;

            gMapControl1.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;

            gMapControl1.OnMapZoomChanged += new MapZoomChanged(gMapControl1_OnMapZoomChanged);

            gMapControl1.Zoom = 3;

            gMapControl1.RoutesEnabled = true;
            gMapControl1.PolygonsEnabled = true;

            kmlpolygons = new GMapOverlay("kmlpolygons");
            gMapControl1.Overlays.Add(kmlpolygons);

            geofence = new GMapOverlay("geofence");
            gMapControl1.Overlays.Add(geofence);

            polygons = new GMapOverlay("polygons");
            gMapControl1.Overlays.Add(polygons);

            routes = new GMapOverlay("routes");
            gMapControl1.Overlays.Add(routes);

            shotposition = new GMapOverlay("shotposition");
            gMapControl1.Overlays.Add(shotposition);

            CreateChart(zg1);

            mymap = gMapControl1;
            myhud = hud2;
            Type t = this.GetType();
            System.Reflection.Assembly a = t.Assembly;
            stream = a.GetManifestResourceStream(t.Namespace + ".shotphoto.wav ");
            sp = new SoundPlayer(stream);

            start = DateTime.Now;

            _3DMesh1.yawrotate = true;


        }

        public void CreateChart(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Tuning";
            myPane.XAxis.Title.Text = "Time (s)";
            myPane.YAxis.Title.Text = "Unit";

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 5;

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.White;
            myPane.YAxis.Title.FontSpec.FontColor = Color.White;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = true;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            //myPane.YAxis.Scale.Min = -1;
            //myPane.YAxis.Scale.Max = 1;

            // Fill the axis background with a gradient
            //myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            // Sample at 50ms intervals
            ZedGraphTimer.Interval = 200;
            //timer1.Enabled = true;
            //timer1.Start();


            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

            tickStart = Environment.TickCount;

            string line = Settings.Instance["Tuning_Graph_Selected"].ToString();
            string[] lines = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string option in lines)
            {
                chk_box_CheckedChanged((object)(new CheckBox() { Name = option, Checked = true }), new EventArgs());
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Make sure that the curvelist has at least one curve
                if (zg1.GraphPane.CurveList.Count <= 0)
                    return;

                // Get the first CurveItem in the graph
                LineItem curve = zg1.GraphPane.CurveList[0] as LineItem;
                if (curve == null)
                    return;

                // Get the PointPairList
                IPointListEdit list = curve.Points as IPointListEdit;
                // If this is null, it means the reference at curve.Points does not
                // support IPointListEdit, so we won't be able to modify it
                if (list == null)
                    return;

                // Time is measured in seconds
                double time = (Environment.TickCount - tickStart) / 1000.0;

                // Keep the X scale at a rolling 30 second interval, with one
                // major step between the max X value and the end of the axis
                Scale xScale = zg1.GraphPane.XAxis.Scale;
                if (time > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 10.0;
                }

                // Make sure the Y axis is rescaled to accommodate actual data
                zg1.AxisChange();

                // Force a redraw

                zg1.Invalidate();
            }
            catch { }

        }

        bool setupPropertyInfo(ref System.Reflection.PropertyInfo input, string name, object source)
        {
            Type test = source.GetType();

            foreach (var field in test.GetProperties())
            {
                if (field.Name == name)
                {
                    input = field;
                    return true;
                }
            }

            return false;
        }

        void chk_box_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                if (list1item == null)
                {
                    if (setupPropertyInfo(ref list1item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list1.Clear();
                        list1curve = zg1.GraphPane.AddCurve(((CheckBox)sender).Name, list1, Color.Red, SymbolType.None);
                    }
                }
                else if (list2item == null)
                {
                    if (setupPropertyInfo(ref list2item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list2.Clear();
                        list2curve = zg1.GraphPane.AddCurve(((CheckBox)sender).Name, list2, Color.Blue, SymbolType.None);
                    }
                }
                else if (list3item == null)
                {
                    if (setupPropertyInfo(ref list3item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list3.Clear();
                        list3curve = zg1.GraphPane.AddCurve(((CheckBox)sender).Name, list3, Color.Green, SymbolType.None);
                    }
                }
                else if (list4item == null)
                {
                    if (setupPropertyInfo(ref list4item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list4.Clear();
                        list4curve = zg1.GraphPane.AddCurve(((CheckBox)sender).Name, list4, Color.Orange, SymbolType.None);
                    }
                }
                else if (list5item == null)
                {
                    if (setupPropertyInfo(ref list5item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list5.Clear();
                        list5curve = zg1.GraphPane.AddCurve(((CheckBox)sender).Name, list5, Color.Yellow, SymbolType.None);
                    }
                }
                else if (list6item == null)
                {
                    if (setupPropertyInfo(ref list6item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list6.Clear();
                        list6curve = zg1.GraphPane.AddCurve(((CheckBox)sender).Name, list6, Color.Magenta, SymbolType.None);
                    }
                }
                else if (list7item == null)
                {
                    if (setupPropertyInfo(ref list7item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list7.Clear();
                        list7curve = zg1.GraphPane.AddCurve(((CheckBox)sender).Name, list7, Color.Purple, SymbolType.None);
                    }
                }
                else if (list8item == null)
                {
                    if (setupPropertyInfo(ref list8item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list8.Clear();
                        list8curve = zg1.GraphPane.AddCurve(((CheckBox)sender).Name, list8, Color.LimeGreen, SymbolType.None);
                    }
                }
                else if (list9item == null)
                {
                    if (setupPropertyInfo(ref list9item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list9.Clear();
                        list9curve = zg1.GraphPane.AddCurve(((CheckBox)sender).Name, list9, Color.Cyan, SymbolType.None);
                    }
                }
                else if (list10item == null)
                {
                    if (setupPropertyInfo(ref list10item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list10.Clear();
                        list10curve = zg1.GraphPane.AddCurve(((CheckBox)sender).Name, list10, Color.Violet, SymbolType.None);
                    }
                }
                else
                {
                    CustomMessageBox.Show("Max 10 at a time.");
                    ((CheckBox)sender).Checked = false;
                }
                ThemeManager.ApplyThemeTo(this);

                string selected = "";
                try
                {
                    selected = selected + zg1.GraphPane.CurveList[0].Label.Text + "|";
                    selected = selected + zg1.GraphPane.CurveList[1].Label.Text + "|";
                    selected = selected + zg1.GraphPane.CurveList[2].Label.Text + "|";
                    selected = selected + zg1.GraphPane.CurveList[3].Label.Text + "|";
                    selected = selected + zg1.GraphPane.CurveList[4].Label.Text + "|";
                    selected = selected + zg1.GraphPane.CurveList[5].Label.Text + "|";
                    selected = selected + zg1.GraphPane.CurveList[6].Label.Text + "|";
                    selected = selected + zg1.GraphPane.CurveList[7].Label.Text + "|";
                    selected = selected + zg1.GraphPane.CurveList[8].Label.Text + "|";
                    selected = selected + zg1.GraphPane.CurveList[9].Label.Text + "|";
                    selected = selected + zg1.GraphPane.CurveList[10].Label.Text + "|";
                }
                catch { }
                Settings.Instance["Tuning_Graph_Selected"] = selected;
            }
            else
            {
                // reset old stuff
                if (list1item != null && list1item.Name == ((CheckBox)sender).Name)
                {
                    list1item = null;
                    zg1.GraphPane.CurveList.Remove(list1curve);
                }
                if (list2item != null && list2item.Name == ((CheckBox)sender).Name)
                {
                    list2item = null;
                    zg1.GraphPane.CurveList.Remove(list2curve);
                }
                if (list3item != null && list3item.Name == ((CheckBox)sender).Name)
                {
                    list3item = null;
                    zg1.GraphPane.CurveList.Remove(list3curve);
                }
                if (list4item != null && list4item.Name == ((CheckBox)sender).Name)
                {
                    list4item = null;
                    zg1.GraphPane.CurveList.Remove(list4curve);
                }
                if (list5item != null && list5item.Name == ((CheckBox)sender).Name)
                {
                    list5item = null;
                    zg1.GraphPane.CurveList.Remove(list5curve);
                }
                if (list6item != null && list6item.Name == ((CheckBox)sender).Name)
                {
                    list6item = null;
                    zg1.GraphPane.CurveList.Remove(list6curve);
                }
                if (list7item != null && list7item.Name == ((CheckBox)sender).Name)
                {
                    list7item = null;
                    zg1.GraphPane.CurveList.Remove(list7curve);
                }
                if (list8item != null && list8item.Name == ((CheckBox)sender).Name)
                {
                    list8item = null;
                    zg1.GraphPane.CurveList.Remove(list8curve);
                }
                if (list9item != null && list9item.Name == ((CheckBox)sender).Name)
                {
                    list9item = null;
                    zg1.GraphPane.CurveList.Remove(list9curve);
                }
                if (list10item != null && list10item.Name == ((CheckBox)sender).Name)
                {
                    list10item = null;
                    zg1.GraphPane.CurveList.Remove(list10curve);
                }
            }
        }

        public void Activate()
        {
        }

        public void Deactivate()
        {
        }

        private void mainloop(object o)
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            System.Threading.Thread.CurrentThread.IsBackground = true;
            this.lbl_logpercent.Location = new System.Drawing.Point(354, 33);
            threadrun = 1;
            EndPoint Remote = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));

            DateTime lastdata = DateTime.MinValue;

            DateTime tracklast = DateTime.Now.AddSeconds(0);

            DateTime tunning = DateTime.Now.AddSeconds(0);

            DateTime mapupdate = DateTime.Now.AddSeconds(0);

            DateTime vidrec = DateTime.Now.AddSeconds(0);

            DateTime waypoints = DateTime.Now.AddSeconds(0);

            DateTime updatescreen = DateTime.Now;

            DateTime tsreal = DateTime.Now;
            double taketime = 0;
            double timeerror = 0;
            while (threadrun == 1)
            {
                if (threadrun == 0) { return; }

                if (MainV2.comPort.giveComport == true)
                {
                    System.Threading.Thread.Sleep(50);
                    continue;
                }
                try
                {
                    if (!MainV2.comPort.BaseStream.IsOpen)
                        lastdata = DateTime.Now;
                }
                catch { }
                // re-request servo data
                if (!(lastdata.AddSeconds(8) > DateTime.Now) && MainV2.comPort.BaseStream.IsOpen)
                {
                    //Console.WriteLine("REQ streams - flightdata");
                    try
                    {
                        //System.Threading.Thread.Sleep(1000);

                        //comPort.requestDatastream((byte)MissionPlanner.MAVLink09.MAV_DATA_STREAM.RAW_CONTROLLER, 0); // request servoout
                        MainV2.comPort.requestDatastream(MAVLink.MAV_DATA_STREAM.EXTENDED_STATUS, 10/*MainV2.comPort.MAV.cs.ratestatus*/); // mode
                        MainV2.comPort.requestDatastream(MAVLink.MAV_DATA_STREAM.POSITION, MainV2.comPort.MAV.cs.rateposition); // request gps
                        MainV2.comPort.requestDatastream(MAVLink.MAV_DATA_STREAM.EXTRA1, MainV2.comPort.MAV.cs.rateattitude); // request attitude
                        MainV2.comPort.requestDatastream(MAVLink.MAV_DATA_STREAM.EXTRA2, MainV2.comPort.MAV.cs.rateattitude); // request vfr
                        MainV2.comPort.requestDatastream(MAVLink.MAV_DATA_STREAM.EXTRA3, MainV2.comPort.MAV.cs.ratesensors); // request extra stuff - tridge
                        MainV2.comPort.requestDatastream(MAVLink.MAV_DATA_STREAM.RAW_SENSORS, MainV2.comPort.MAV.cs.ratesensors); // request raw sensor
                        MainV2.comPort.requestDatastream(MAVLink.MAV_DATA_STREAM.RC_CHANNELS, MainV2.comPort.MAV.cs.raterc); // request rc info
                    }
                    catch { }


                    lastdata = DateTime.Now.AddSeconds(60); // prevent flooding
                }


                if (!MainV2.comPort.logreadmode)
                    System.Threading.Thread.Sleep(50); // max is only ever 10 hz but we go a little faster to empty the serial queue
                                                       // log playback
                if (MainV2.comPort.logreadmode && MainV2.comPort.logplaybackfile != null)
                {
                    if (threadrun == 0) { return; }

                    if (MainV2.comPort.BaseStream.IsOpen)
                    {
                        MainV2.comPort.logreadmode = false;
                        try
                        {
                            MainV2.comPort.logplaybackfile.Close();
                        }
                        catch
                        { //log.Error("Failed to close logfile");
                        }
                        MainV2.comPort.logplaybackfile = null;
                    }


                    //Console.WriteLine(DateTime.Now.Millisecond);

                    if (updatescreen.AddMilliseconds(300) < DateTime.Now)
                    {
                        try
                        {
                            updatePlayPauseButton(true);
                            updateLogPlayPosition();
                        }
                        catch
                        { //log.Error("Failed to update log playback pos"); 
                        }
                        updatescreen = DateTime.Now;
                    }

                    //Console.WriteLine(DateTime.Now.Millisecond + " done ");

                    DateTime logplayback = MainV2.comPort.lastlogread;
                    try
                    {
                        MainV2.comPort.readPacket();
                    }
                    catch
                    { //log.Error("Failed to read log packet");
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
                    catch { }

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
                        if (ts > 1000)
                            ts = 1000;
                    }

                    taketime = ts;
                    tsreal = DateTime.Now;

                    if (ts > 0 && ts < 1000)
                        System.Threading.Thread.Sleep((int)ts);



                    if (threadrun == 0) { return; }

                    tracklast = tracklast.AddMilliseconds(ts - act);
                    tunning = tunning.AddMilliseconds(ts - act);

                    if (tracklast.Month != DateTime.Now.Month)
                    {
                        tracklast = DateTime.Now;
                        tunning = DateTime.Now;
                    }

                    try
                    {
                        if (MainV2.comPort.logplaybackfile != null && MainV2.comPort.logplaybackfile.BaseStream.Position == MainV2.comPort.logplaybackfile.BaseStream.Length)
                        {
                            MainV2.comPort.logreadmode = false;
                        }
                    }
                    catch { MainV2.comPort.logreadmode = false; }
                }
                else
                {
                    // ensure we know to stop
                    if (MainV2.comPort.logreadmode)
                        MainV2.comPort.logreadmode = false;
                    //updatePlayPauseButton(false);

                    if (!playingLog && MainV2.comPort.logplaybackfile != null)
                    {
                        continue;
                    }
                }
                updateBindingSource();

                // udpate tunning tab
                if (tunning.AddMilliseconds(50) < DateTime.Now && zg1_show == true)
                {

                    double time = (Environment.TickCount - tickStart) / 1000.0;
                    if (list1item != null)
                        list1.Add(time, (float)list1item.GetValue((object)MainV2.comPort.MAV.cs, null));
                    if (list2item != null)
                        list2.Add(time, (float)list2item.GetValue((object)MainV2.comPort.MAV.cs, null));
                    if (list3item != null)
                        list3.Add(time, (float)list3item.GetValue((object)MainV2.comPort.MAV.cs, null));
                    if (list4item != null)
                        list4.Add(time, (float)list4item.GetValue((object)MainV2.comPort.MAV.cs, null));
                    if (list5item != null)
                        list5.Add(time, (float)list5item.GetValue((object)MainV2.comPort.MAV.cs, null));
                    if (list6item != null)
                        list6.Add(time, (float)list6item.GetValue((object)MainV2.comPort.MAV.cs, null));
                    if (list7item != null)
                        list7.Add(time, (float)list7item.GetValue((object)MainV2.comPort.MAV.cs, null));
                    if (list8item != null)
                        list8.Add(time, (float)list8item.GetValue((object)MainV2.comPort.MAV.cs, null));
                    if (list9item != null)
                        list9.Add(time, (float)list9item.GetValue((object)MainV2.comPort.MAV.cs, null));
                    if (list10item != null)
                        list10.Add(time, (float)list10item.GetValue((object)MainV2.comPort.MAV.cs, null));
                }

                // update map
                if (tracklast.AddSeconds(1.2) < DateTime.Now && gMapControl1.Visible)
                {
                    if (Settings.Instance["CHK_maprotation"] != null && Settings.Instance["CHK_maprotation"].ToString() == "True")
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

                    int cnt = 0;

                    while (gMapControl1.inOnPaint == true)
                    {
                        System.Threading.Thread.Sleep(1);
                        cnt++;
                    }

                    // maintain route history length
                    if (route.Points.Count > int.Parse(Settings.Instance["NUM_tracklength"].ToString()))
                    {
                        //  trackPoints.RemoveRange(0, trackPoints.Count - int.Parse(MainV2.config["NUM_tracklength"].ToString()));
                        route.Points.RemoveRange(0, route.Points.Count - int.Parse(Settings.Instance["NUM_tracklength"].ToString()));
                    }
                    // add new route point
                    if (MainV2.comPort.MAV.cs.lat != 0)
                    {
                        // trackPoints.Add(currentloc);
                        route.Points.Add(currentloc);
                    }

                    {

                        while (gMapControl1.inOnPaint == true)
                        {
                            System.Threading.Thread.Sleep(1);
                            cnt++;
                        }

                        //route = new GMapRoute(route.Points, "track");
                        //track.Stroke = Pens.Red;
                        //route.Stroke = new Pen(Color.FromArgb(144, Color.Red));
                        //route.Stroke.Width = 5;
                        //route.Tag = "track";

                        //updateClearRoutes();

                        gMapControl1.UpdateRouteLocalPosition(route);

                        // update programed wp course
                        if (waypoints.AddSeconds(5) < DateTime.Now)
                        {
                            //Console.WriteLine("Doing FD WP's");
                            updateMissionRouteMarkers();

                            foreach (MAVLink.mavlink_mission_item_t plla in MainV2.comPort.MAV.wps.Values)
                            {
                                if (plla.x == 0 || plla.y == 0)
                                    continue;

                                if (plla.command == (byte)MAVLink.MAV_CMD.DO_SET_ROI)
                                {
                                    addpolygonmarkerred(plla.seq.ToString(), plla.y, plla.x, (int)plla.z, Color.Red, routes);
                                    continue;
                                }

                                string tag = plla.seq.ToString();
                                if (plla.seq == 0 && plla.current != 2)
                                {
                                    tag = "Home";
                                }
                                if (plla.current == 2)
                                {
                                    continue;
                                }

                                if (plla.command == (byte)MAVLink.MAV_CMD.TAKEOFF)
                                    tag = "起飞点" + "高度：" + ((int)(plla.z)).ToString() ;
                                //else if (plla.command == (byte)MAVLink.MAV_CMD.LAND_PARACHUTE)
                                   // tag = "盘旋开伞点";
                                //else if (plla.command == (byte)MAVLink.MAV_CMD.LAND_DECLINE)
                                   // tag = "盘旋下落点";
                                //else if (plla.command == (byte)MAVLink.MAV_CMD.LAND_PARACHUTE_LINE)
                                   // tag = "直线开伞电";
                                else
                                {
                                    tag = tag + "点高度:" + ((int)(plla.z)).ToString();
                                }

                                addpolygonmarker(tag, plla.y, plla.x, (int)plla.z, Color.White, polygons);
                            }

                            RegeneratePolygon();

                            waypoints = DateTime.Now;
                        }

                        //routes.Polygons.Add(poly);    

                        if (route.Points.Count > 0)
                        {
                            // add primary route icon
                            if (routes.Markers.Count != 1)
                            {
                                routes.Markers.Clear();
                                routes.Markers.Add(new GMarkerGoogle(currentloc, GMarkerGoogleType.none));
                            }

                            if (MainV2.comPort.MAV.cs.mode.ToLower() == "guided" && MainV2.comPort.MAV.GuidedMode.x != 0)
                            {
                                addpolygonmarker("指点高度" + ((int)MainV2.comPort.MAV.GuidedMode.z).ToString(), MainV2.comPort.MAV.GuidedMode.y, MainV2.comPort.MAV.GuidedMode.x, (int)MainV2.comPort.MAV.GuidedMode.z, Color.Blue, routes);
                            }

                            if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduPlane || MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.Ateryx)
                            {
                                routes.Markers[0] = (new GMapMarkerPlane(currentloc, MainV2.comPort.MAV.cs.yaw, MainV2.comPort.MAV.cs.groundcourse, MainV2.comPort.MAV.cs.nav_bearing, MainV2.comPort.MAV.cs.target_bearing,1) { ToolTipText = MainV2.comPort.MAV.cs.alt.ToString("0"), ToolTipMode = MarkerTooltipMode.Always });
                            }
                            else if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduRover)
                            {
                                routes.Markers[0] = (new GMapMarkerRover(currentloc, MainV2.comPort.MAV.cs.yaw, MainV2.comPort.MAV.cs.groundcourse, MainV2.comPort.MAV.cs.nav_bearing, MainV2.comPort.MAV.cs.target_bearing));
                            }
                            else
                            {
                                routes.Markers[0] = (new GMapMarkerQuad(currentloc, MainV2.comPort.MAV.cs.yaw, MainV2.comPort.MAV.cs.groundcourse, MainV2.comPort.MAV.cs.nav_bearing,1));
                            }

                            // add extra mavs
                            int a = 1;
                            foreach (var port in MainV2.Comports)
                            {
                                if (port == MainV2.comPort)
                                    continue;

                                PointLatLng portlocation = new PointLatLng(port.MAV.cs.lat, port.MAV.cs.lng);

                                while (routes.Markers.Count < (a + 1))
                                    routes.Markers.Add(new GMarkerGoogle(portlocation, GMarkerGoogleType.none));

                                if (port.MAV.cs.firmware == MainV2.Firmwares.ArduPlane || MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.Ateryx)
                                {
                                    routes.Markers[a] = (new GMapMarkerPlane(portlocation, port.MAV.cs.yaw, port.MAV.cs.groundcourse, port.MAV.cs.nav_bearing, port.MAV.cs.target_bearing,1) { ToolTipText = "MAV: " + a + " " + port.MAV.cs.alt.ToString("0"), ToolTipMode = MarkerTooltipMode.Always });
                                }
                                else if (port.MAV.cs.firmware == MainV2.Firmwares.ArduRover)
                                {
                                    routes.Markers[a] = (new GMapMarkerRover(portlocation, port.MAV.cs.yaw, port.MAV.cs.groundcourse, port.MAV.cs.nav_bearing, port.MAV.cs.target_bearing));
                                }
                                else
                                {
                                    routes.Markers[a] = (new GMapMarkerQuad(portlocation, port.MAV.cs.yaw, port.MAV.cs.groundcourse, port.MAV.cs.nav_bearing,1));
                                }
                                a++;
                            }

                            if (route.Points[route.Points.Count - 1].Lat != 0 && (mapupdate.AddSeconds(3) < DateTime.Now) /*&& CHK_autopan.Checked*/)
                            {
                                updateMapPosition(currentloc);
                                mapupdate = DateTime.Now;
                            }
                            if(MainV2.comPort.camera_feedback_new!=null)
                            {
                                addshotposition(MainV2.comPort.camera_feedback_new.Lng/1E7, MainV2.comPort.camera_feedback_new.Lat / 1E7);
                                MainV2.comPort.camera_feedback_new = null;
                                sp.Play();
                            }

                            if (route.Points.Count == 1 && gMapControl1.Zoom == 3) // 3 is the default load zoom
                            {
                                updateMapPosition(currentloc);
                                updateMapZoom(17);
                                //gMapControl1.ZoomAndCenterMarkers("routes");// ZoomAndCenterRoutes("routes");
                            }
                        }

                        gMapControl1.HoldInvalidation = false;

                        gMapControl1.Invalidate();
                    }

                    tracklast = DateTime.Now;
                }
               

            }
        }

        void gMapControl1_OnMapZoomChanged()
        {
            try
            { // Exception System.Runtime.InteropServices.SEHException: External component has thrown an exception.
                //TRK_zoom.Value = (float)gMapControl1.Zoom;
                //Zoomlevel.Value = Convert.ToDecimal(gMapControl1.Zoom);
            }
            catch { }
        }

        private void HsdevFlightData_Load(object sender, EventArgs e)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(mainloop);
        }

        DateTime lastscreenupdate = DateTime.Now;

        private void updateBindingSource()
        {
            //  run at 25 hz.
            if (lastscreenupdate.AddMilliseconds(40) < DateTime.Now)
            {
                // async
                if (this.Visible)
                {
                    this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate ()
                {
                    try
                    {

                        if (this.Visible)
                        {
                            //Console.Write("bindingSource1 ");
                            //MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSource1);
                            //Console.Write("bindingSourceHud ");
                            MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceHud);
                            MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceGaugesTab);

                            m_SyncContext.Post(updateflightdatacontext, "update");
                            //Console.WriteLine("DONE ");
                        }
                        else
                        {
                            //Console.WriteLine("Null Binding");
                            //MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceHud);
                        }
                        lastscreenupdate = DateTime.Now;

                    }
                    catch { }
                });
                }
            }
        }

        private void updateflightdatacontext(object text)
        {
            //this.BeginInvoke((MethodInvoker)delegate()
            {
                // voltage_value.Update();
                if (MainV2.comPort.MAV.cs.mode == "Manual")
                {
                    mode_value.Text = "手动";
                   // mode_value.ForeColor = Color(0, 255, 0, 0);
                }
                else if (MainV2.comPort.MAV.cs.mode == "RTL")
                {
                    mode_value.Text = "返航";
                }
                else if (MainV2.comPort.MAV.cs.mode == "Auto")
                {
                    mode_value.Text = "导航";
                }
                else if (MainV2.comPort.MAV.cs.mode == "STABILIZE")
                {
                    mode_value.Text = "增稳";
                }
                else
                    mode_value.Text = MainV2.comPort.MAV.cs.mode.ToString();

                if (MainV2.comPort.MAV.cs.gpsstatus == 3)
                    gpsstate_value.Text = "3D锁定";
                else if (MainV2.comPort.MAV.cs.gpsstatus == 2)
                    gpsstate_value.Text = "锁定";
                else if (MainV2.comPort.MAV.cs.gpsstatus == 1)
                    gpsstate_value.Text = "未锁定";
                else if (MainV2.comPort.MAV.cs.gpsstatus == 0)
                    gpsstate_value.Text = "无GPS";

                if (MainV2.comPort.MAV.cs.gpsstatus == 3)
                {
                   // if (MainV2.comPort.MAV.cs.altoffsethome == 0)
                   //     MainV2.comPort.MAV.cs.altoffsethome = MainV2.comPort.MAV.cs.HomeAlt / MainV2.comPort.MAV.cs.multiplierdist;
                }

                //aileron_l.Text = ((int)((((float)(MainV2.comPort.MAV.cs.aileron_l) - 255f) / 180f) * 90f)).ToString();
                //aileron_r.Text = ((int)((((float)(MainV2.comPort.MAV.cs.aileron_r) - 255f) / 180f) * -90f)).ToString();

                String hh = ""; string mm = ""; string ss = "";
                hh = ((int)(MainV2.comPort.MAV.cs.timeInAir / 3600.0f)).ToString();
                mm = ((int)(MainV2.comPort.MAV.cs.timeInAir - (int.Parse(hh) * 3600)) / 60).ToString();
                ss = (MainV2.comPort.MAV.cs.timeInAir - (int.Parse(hh) * 3600) - (int.Parse(mm) * 60)).ToString();
                timeinair.Text = hh + ":" + mm + ":" + ss;

                //String hh2 = ""; string mm2 = ""; string ss2 = "";
                hh = ((int)(MainV2.comPort.MAV.cs.time2InAir / 3600.0f)).ToString();
                mm = ((int)(MainV2.comPort.MAV.cs.time2InAir - (int.Parse(hh) * 3600)) / 60).ToString();
                ss = (MainV2.comPort.MAV.cs.time2InAir - (int.Parse(hh) * 3600) - (int.Parse(mm) * 60)).ToString();
                quadbat_time.Text = hh + ":" + mm + ":" + ss;

                try
                {
                  //  goal_aill.Text = ((int)((((float)(MainV2.comPort.MAV.cs.ch1out) - 1500f) / 1000f) * 90f)).ToString();
                  //  goal_ailr.Text = ((int)((((float)(MainV2.comPort.MAV.cs.ch2out) - 1500f) / 1000f) * -90f)).ToString();
                }
                catch { }
            }

        }
        bool debug = false;
        private void mesh_Click(object sender, EventArgs e)
        {
            //if (debug == true)
               _3DMesh1.yawrotate = !_3DMesh1.yawrotate;
        }

        private void BUT_Homealt_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.altoffsethome != 0)
            {
                MainV2.comPort.MAV.cs.altoffsethome = 0;
            }
            else
            {
                MainV2.comPort.MAV.cs.altoffsethome = MainV2.comPort.MAV.cs.HomeAlt / CurrentState.multiplierdist;
            }
        }

        private void flyToHereAltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string alt = "100";

            if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduCopter2)
            {
                alt = (10 * CurrentState.multiplierdist).ToString("0");
            }
            else
            {
                alt = (100 * CurrentState.multiplierdist).ToString("0");
            }

            if (Settings.Instance.ContainsKey("guided_alt"))
                alt = Settings.Instance["guided_alt"].ToString();

            if (DialogResult.Cancel == InputBox.Show("Enter Alt", "Enter Guided Mode Alt", ref alt))
            {
                MainV2.comPort.MAV.GuidedMode.z = 0;
                return;
            }

            Settings.Instance["guided_alt"] = alt;

            int intalt = (int)(100 * CurrentState.multiplierdist);
            if (!int.TryParse(alt, out intalt))
            {
                CustomMessageBox.Show("Bad Alt");
                return;
            }

            MainV2.comPort.MAV.GuidedMode.z = intalt / CurrentState.multiplierdist;

            if (MainV2.comPort.MAV.cs.mode == "Guided")
            {
                MainV2.comPort.setGuidedModeWP(new Locationwp() { alt = (float)MainV2.comPort.MAV.GuidedMode.z, lat = MainV2.comPort.MAV.GuidedMode.x, lng = MainV2.comPort.MAV.GuidedMode.y });
            }
        }

        private void goHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MainV2.comPort.BaseStream.IsOpen)
            {
                CustomMessageBox.Show("没有连接", "Error");
                return;
            }

            //if (MainV2.comPort.MAV.GuidedMode.z == 0)
            {
                flyToHereAltToolStripMenuItem_Click(null, null);

                if (MainV2.comPort.MAV.GuidedMode.z == 0)
                    return;
            }

            if (gotolocation.Lat == 0 || gotolocation.Lng == 0)
            {
                CustomMessageBox.Show("输入错误", "Error");
                return;
            }

            Locationwp gotohere = new Locationwp();

            gotohere.id = (byte)MAVLink.MAV_CMD.WAYPOINT;
            gotohere.alt = (float)(MainV2.comPort.MAV.GuidedMode.z); // back to m
            gotohere.lat = (gotolocation.Lat);
            gotohere.lng = (gotolocation.Lng);

            try
            {
                MainV2.comPort.setGuidedModeWP(gotohere);
            }
            catch (Exception ex) { MainV2.comPort.giveComport = false; CustomMessageBox.Show("Error sending command : " + ex.Message, "Error"); }

        }

        private void gMapControl1_Click(object sender, EventArgs e)
        {

        }

        internal PointLatLng gotolocation = new PointLatLng();

        private void gMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            gotolocation = gMapControl1.FromLocalToLatLng(e.X, e.Y);

            if (Control.ModifierKeys == Keys.Control)
            {
                goHereToolStripMenuItem_Click(null, null);
            }
        }

        private void gMapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);

                double latdif = gotolocation.Lat - point.Lat;
                double lngdif = gotolocation.Lng - point.Lng;

                try
                {
                    gMapControl1.Position = new PointLatLng(gMapControl1.Position.Lat + latdif, gMapControl1.Position.Lng + lngdif);
                }
                catch { }
            }
            else
            {
                // setup a ballon with home distance
                if (marker != null)
                {
                    if (routes.Markers.Contains(marker))
                        routes.Markers.Remove(marker);
                }

                if (Settings.Instance.GetBoolean("CHK_disttohomeflightdata") != false)
                {
                    PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);

                    marker = new GMapMarkerRect(point);
                    marker.ToolTip = new GMapToolTip(marker);
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTipText = "Dist to Home: " + ((gMapControl1.MapProvider.Projection.GetDistance(point, MainV2.comPort.MAV.cs.HomeLocation.Point()) * 1000) * CurrentState.multiplierdist).ToString("0");

                    routes.Markers.Add(marker);
                }
            }
        }

        private void gMapControl1_MouseLeave(object sender, EventArgs e)
        {
            if (marker != null)
            {
                if (routes.Markers.Contains(marker))
                    routes.Markers.Remove(marker);
            }
        }

        private void setMapBearing()
        {
            this.Invoke((System.Windows.Forms.MethodInvoker)delegate()
            {
                gMapControl1.Bearing = (int)MainV2.comPort.MAV.cs.yaw;
            });
        }

        // to prevent cross thread calls while in a draw and exception
        private void updateClearRoutes()
        {
            // not async
            this.Invoke((System.Windows.Forms.MethodInvoker)delegate()
            {
                routes.Routes.Clear();
                routes.Routes.Add(route);
            });
        }

        // to prevent cross thread calls while in a draw and exception
        private void updateMissionRouteMarkers()
        {
            // not async
            this.Invoke((System.Windows.Forms.MethodInvoker)delegate()
            {
                polygons.Markers.Clear();
                routes.Markers.Clear();
            });
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
                        mBorders.wprad = (int)(Settings.Instance.GetFloat("TXT_WPRad") / CurrentState.multiplierdist);
                    }
                    catch { }
                    if (color.HasValue)
                    {
                        mBorders.Color = color.Value;
                    }
                }

                overlay.Markers.Add(m);
                overlay.Markers.Add(mBorders);
            }
            catch (Exception) { }
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

                overlay.Markers.Add(m);
                overlay.Markers.Add(mBorders);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Try to reduce the number of map position changes generated by the code
        /// </summary>
        DateTime lastmapposchange = DateTime.MinValue;

        private void updateMapPosition(PointLatLng currentloc)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                try
                {
                    if (lastmapposchange.Second != DateTime.Now.Second)
                    {
                        gMapControl1.Position = currentloc;
                        lastmapposchange = DateTime.Now;
                    }
                    //hud1.Refresh();
                }
                catch { }
            });
        }

        private void updateMapZoom(int zoom)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                try
                {
                    gMapControl1.Zoom = zoom;
                }
                catch { }
            });
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

            if (polygon == null)
            {
                polygon = new GMapPolygon(polygonPoints, "polygon test");
                polygons.Polygons.Add(polygon);
            }
            else
            {
                polygon.Points.Clear();
                polygon.Points.AddRange(polygonPoints);

                polygon.Stroke = new Pen(Color.Yellow, 4);
                polygon.Fill = Brushes.Transparent;

                if (polygons.Polygons.Count == 0)
                {
                    polygons.Polygons.Add(polygon);
                }
                else
                {
                    gMapControl1.UpdatePolygonLocalPosition(polygon);
                }
            }
        }

        private void BUTrestartmission_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;

                MainV2.comPort.setWPCurrent(1); // set nav to

            }
            catch { CustomMessageBox.Show("执行失败！", "Error"); }
            ((Button)sender).Enabled = true;
        }

        private void BUT_clear_track_Click(object sender, EventArgs e)
        {
            if (route != null)
                route.Points.Clear();
            if (shotposition != null)
                shotposition.Markers.Clear();
        }

        private void BUT_quickauto_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setMode("Auto");
            }
            catch { CustomMessageBox.Show("The Command failed to execute", "Error"); }
            ((Button)sender).Enabled = true;
        }

        private void BUT_quickrtl_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setMode("RTL");
            }
            catch { CustomMessageBox.Show("The Command failed to execute", "Error"); }
            ((Button)sender).Enabled = true;
        }

        private void BUT_Homealt_Click_1(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.altoffsethome != 0)
            {
                MainV2.comPort.MAV.cs.altoffsethome = 0;
            }
            else
            {
                MainV2.comPort.MAV.cs.altoffsethome = MainV2.comPort.MAV.cs.HomeAlt / CurrentState.multiplierdist;
            }
        }

        private void splitContainer4_Panel2_Resize(object sender, EventArgs e)
        {
            int mywidth, myheight;

            // localize it
            Control tabGauges = sender as Control;

            float scale = tabGauges.Width / (float)tabGauges.Height;

            if (scale > 0.5 && scale < 1.9)
            {// square
                Gvspeed.Visible = true;

                if (tabGauges.Height < tabGauges.Width)
                    myheight = tabGauges.Height / 2;
                else
                    myheight = tabGauges.Width / 2;

                Gvspeed.Height = myheight;
                Gspeed.Height = myheight;
                Galt.Height = myheight;
                Gheading.Height = myheight;

                Gvspeed.Location = new Point(0, 0);
                Gspeed.Location = new Point(Gvspeed.Right, 0);


                Galt.Location = new Point(0, Gspeed.Bottom);
                Gheading.Location = new Point(Galt.Right, Gspeed.Bottom);

                return;
            }

          /*
            if (tabGauges.Width < 500)
            {
                Gvspeed.Visible = false;
                mywidth = tabGauges.Width / 3;

                Gspeed.Height = mywidth;
                Galt.Height = mywidth;
                Gheading.Height = mywidth;

                Gspeed.Location = new Point(0, 0);
            }
            else
           */
            {
                Gvspeed.Visible = true;
                mywidth = tabGauges.Width / 4;

                Gvspeed.Height = mywidth;
                Gspeed.Height = mywidth;
                Galt.Height = mywidth;
                Gheading.Height = mywidth;

                Gvspeed.Location = new Point(0, 0);
                Gspeed.Location = new Point(Gvspeed.Right, 0);
            }

            Galt.Location = new Point(Gspeed.Right, 0);
            Gheading.Location = new Point(Galt.Right, 0);
        }

        private void splitContainer5_Panel1_Resize(object sender, EventArgs e)
        {
            int Width = splitContainer5.Panel1.Width;
            int Height = splitContainer5.Panel1.Height;
        }

        private void splitContainer5_Panel2_Resize(object sender, EventArgs e)
        {
        }


        public void zg1show()
        {
            zg1_show = !zg1_show;
            if (zg1_show)
            {
                splitContainer6.Panel1Collapsed = false;
                ZedGraphTimer.Enabled = true;
                ZedGraphTimer.Start();
                zg1.Visible = true;
                //zg1.Dock = DockStyle.Fill;
                zg1.Refresh();
                debug = true;
            }
            else
            {
                splitContainer6.Panel1Collapsed = true;
                ZedGraphTimer.Enabled = false;
                ZedGraphTimer.Stop();
                zg1.Visible = false;
                debug = false;
                _3DMesh1.yawrotate = false;
            }
        }

        private void BUT_standby_Click(object sender, EventArgs e)
        {
                MainV2.comPort.setMode("Stabilize");
        }

        private void BUT_parachute_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.mode == "Auto")
            {

                if (DialogResult.No == CustomMessageBox.Show("飞行器正处于导航模式。确定要强制开伞吗?","警告",MessageBoxButtons.YesNo))
                {
                    return;
                }
               
            }
            try
            {
                //((Button)sender).Enabled = false;
                //MainV2.comPort.setMode(25);
                //System.Windows.Forms.MessageBox.Show("飞控进入弹射模式，弹射延时" + launch_delay.Text + "毫秒");
            }
            catch { CustomMessageBox.Show("The Command failed to execute", "Error"); }
            //((Button)sender).Enabled = true;
        }

        private void CMB_setwp_Click(object sender, EventArgs e)
        {
            CMB_setwp.Items.Clear();

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

        private void CMB_setwp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //((Button)sender).Enabled = false;
                MainV2.comPort.setWPCurrent((ushort)CMB_setwp.SelectedIndex); // set nav to
            }
            catch { CustomMessageBox.Show("The command failed to execute", "Error"); }
            //((Button)sender).Enabled = true;
        }

        
        private void BUT_camera_Click(object sender, EventArgs e)
        {
            if (start.AddMilliseconds(1000)<DateTime.Now)
            {
                // start = DateTime.Now;
                // try
                // {
                //((Button)sender).Enabled = false;
                //MainV2.comPort.setMode(26);
                //System.Windows.Forms.MessageBox.Show("飞控进入弹射模式，弹射延时" + launch_delay.Text + "毫秒");
                //}
                // catch { CustomMessageBox.Show("The Command failed to execute", "Error"); }
                //((Button)sender).Enabled = true;
                try
                {
                    MainV2.comPort.setDigicamControl(true);
                }
                catch
                {
                    CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
                }
            }
        }

        private void changebatteryvalue(object sender, EventArgs e)
        {
            string battery_value = "";
            float new_divider = 0.0f;
            if (DialogResult.Cancel == InputBox.Show("设定电压", "输入测量电压", ref battery_value))
            {
                return;
            }

            try
            {
                float measuredvoltage = float.Parse(battery_value);
                float voltage = MainV2.comPort.MAV.cs.battery_voltage;
                string TXT_divider = "";
                // new
                if (MainV2.comPort.MAV.param["BATT_VOLT_MULT"] != null)
                    TXT_divider = MainV2.comPort.MAV.param["BATT_VOLT_MULT"].ToString();
                // old
                if (MainV2.comPort.MAV.param["VOLT_DIVIDER"] != null)
                    TXT_divider = MainV2.comPort.MAV.param["VOLT_DIVIDER"].ToString();
                float divider = float.Parse(TXT_divider);
                if (voltage == 0)
                    return;
                new_divider = (measuredvoltage * divider) / voltage;
                //TXT_divider.Text = new_divider.ToString();
            }
            catch { CustomMessageBox.Show("无效电压", "错误"); return; }

            try
            {

                MainV2.comPort.setParam(new string[] { "VOLT_DIVIDER", "BATT_VOLT_MULT" }, new_divider);

            }
            catch { CustomMessageBox.Show("Set BATT_VOLT_MULT Failed", "Error"); }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            threadrun = 0;

        }

        private void _3DMesh1_Resize(object sender, EventArgs e)
        {

        }

        private void _3DMesh1_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void BUT_loadtelem_Click(object sender, EventArgs e)
        {
            //LBL_logfn.Text = "";

            if (MainV2.comPort.logplaybackfile != null)
            {
                try
                {
                    MainV2.comPort.logplaybackfile.Close();
                    MainV2.comPort.logplaybackfile = null;
                }
                catch { }
            }

            OpenFileDialog fd = new OpenFileDialog();
            fd.AddExtension = true;
            fd.Filter = "Ardupilot Telemtry log (*.tlog)|*.tlog|Mavlink Log (*.mavlog)|*.mavlog";
            fd.InitialDirectory = Settings.Instance.LogDir;
            fd.DefaultExt = ".tlog";
            DialogResult result = fd.ShowDialog();
            string file = fd.FileName;
            LoadLogFile(file);
        }

        public void LoadLogFile(string file)
        {
            if (file != "")
            {
                try
                {
                    BUT_clear_track_Click(null, null);

                    MainV2.comPort.logreadmode = false;
                    MainV2.comPort.logplaybackfile = new BinaryReader(File.OpenRead(file));
                    MainV2.comPort.lastlogread = DateTime.MinValue;

                    //LBL_logfn.Text = Path.GetFileName(file);

                    tracklog.Value = 0;
                    tracklog.Minimum = 0;
                    tracklog.Maximum = 100;
                }
                catch { CustomMessageBox.Show("Error: Failed to read log file", "Error"); }
            }
        }

        private void BUT_playlog_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.logreadmode)
            {
                MainV2.comPort.logreadmode = false;
                ZedGraphTimer.Stop();
                playingLog = false;
            }
            else
            {
                // BUT_clear_track_Click(sender, e);
                MainV2.comPort.logreadmode = true;
                list1.Clear();
                list2.Clear();
                list3.Clear();
                list4.Clear();
                list5.Clear();
                list6.Clear();
                list7.Clear();
                list8.Clear();
                list9.Clear();
                list10.Clear();
                tickStart = Environment.TickCount;

                zg1.GraphPane.XAxis.Scale.Min = 0;
                zg1.GraphPane.XAxis.Scale.Max = 1;
                ZedGraphTimer.Start();
                playingLog = true;
            }
        }

        private void tracklog_Scroll(object sender, EventArgs e)
        {
            try
            {
                BUT_clear_track_Click(sender, e);

                MainV2.comPort.lastlogread = DateTime.MinValue;
                MainV2.comPort.MAV.cs.ResetInternals();

                if (MainV2.comPort.logplaybackfile != null)
                    MainV2.comPort.logplaybackfile.BaseStream.Position = (long)(MainV2.comPort.logplaybackfile.BaseStream.Length * (tracklog.Value / 100.0));

                updateLogPlayPosition();
            }
            catch { } // ignore any invalid 
        }

        private void updateLogPlayPosition()
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                try
                {
                    if (tracklog.Visible)
                        tracklog.Value = (int)(MainV2.comPort.logplaybackfile.BaseStream.Position / (double)MainV2.comPort.logplaybackfile.BaseStream.Length * 100);
                    if (lbl_logpercent.Visible)
                        lbl_logpercent.Text = (MainV2.comPort.logplaybackfile.BaseStream.Position / (double)MainV2.comPort.logplaybackfile.BaseStream.Length).ToString("0.00%");
                }
                catch { }
            });
        }

        private void CMB_playspeed_Click(object sender, EventArgs e)
        {
            CMB_playspeed.Items.Clear();
            CMB_playspeed.Items.Add((0.1).ToString("0.0"));
            CMB_playspeed.Items.Add((0.25).ToString("0.00"));
            CMB_playspeed.Items.Add((0.5).ToString("0.0"));
            CMB_playspeed.Items.Add((1).ToString());
            CMB_playspeed.Items.Add((2).ToString());
            CMB_playspeed.Items.Add((5).ToString());
            CMB_playspeed.Items.Add((10).ToString());
        }

        private void CMB_playspeed_SelectedIndexChanged(object sender, EventArgs e)
        {

            int i = CMB_playspeed.SelectedIndex; // set nav to
            switch (i)
            {
                case 0:
                    LogPlayBackSpeed = 0.1;
                    break;
                case 1:
                    LogPlayBackSpeed = 0.25;
                    break;
                case 2:
                    LogPlayBackSpeed = 0.5;
                    break;
                case 3:
                    LogPlayBackSpeed = 1;
                    break;
                case 4:
                    LogPlayBackSpeed = 2;
                    break;
                case 5:
                    LogPlayBackSpeed = 5;
                    break;
                case 6:
                    LogPlayBackSpeed = 10;
                    break;

            }

        }

        private void HsdevFlightData_Resize(object sender, EventArgs e)
        {
            this.lbl_logpercent.Location = new System.Drawing.Point(354, 33);
        }

        private void updatePlayPauseButton(bool playing)
        {
            if (playing)
            {
                if (BUT_playlog.Text == "暂停")
                    return;

                this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate ()
                {
                    try
                    {
                        BUT_playlog.Text = "暂停";
                    }
                    catch { }
                });
            }
            else
            {
                if (BUT_playlog.Text == "播放")
                    return;

                this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate ()
                {
                    try
                    {
                        BUT_playlog.Text = "播放";
                    }
                    catch { }
                });
            }
        }

        private void BUT_ARM_Click(object sender, EventArgs e)
        {
            if (!MainV2.comPort.BaseStream.IsOpen)
                return;

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
                        BUT_ARM.Text = "解锁";
                    else
                        BUT_ARM.Text = "锁定";
                }
            }
            catch
            {
                CustomMessageBox.Show(Strings.ErrorNoResponce, Strings.ERROR);
            }
        }
    }
}
