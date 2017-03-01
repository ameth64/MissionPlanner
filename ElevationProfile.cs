using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using GMap.NET;
using System.Xml;
using MissionPlanner.Utilities; // GE xml alt reader
using OSGeo.GDAL;
using System.IO;

namespace MissionPlanner
{
    public partial class ElevationProfile : Form
    {
        List<PointLatLngAlt> gelocs = new List<PointLatLngAlt>();
        List<PointLatLngAlt> srtmlocs = new List<PointLatLngAlt>();
        List<PointLatLngAlt> planlocs = new List<PointLatLngAlt>();
        PointPairList list1 = new PointPairList();
        PointPairList list2 = new PointPairList();
        PointPairList list3 = new PointPairList();

        PointPairList list4terrain = new PointPairList();
        int distance = 0;
        double homealt = 0;
        GCSViews.FlightPlanner.altmode altmode = GCSViews.FlightPlanner.altmode.Relative;

        public ElevationProfile(List<PointLatLngAlt> locs, double homealt, GCSViews.FlightPlanner.altmode altmode)
        {
            InitializeComponent();

            this.altmode = altmode;

            planlocs = locs;

            for (int a = 0; a < planlocs.Count; a++)
            {
                if (planlocs[a] == null || planlocs[a].Tag != null && planlocs[a].Tag.Contains("ROI"))
                {
                    planlocs.RemoveAt(a);
                    a--;
                }
            }

            if (planlocs.Count <= 1)
            {
                CustomMessageBox.Show("没有航线", Strings.ERROR);
                return;
            }

            // get total distance
            distance = 0;
            PointLatLngAlt lastloc = null;
            foreach (PointLatLngAlt loc in planlocs)
            {
                if (loc == null)
                    continue;

                if (lastloc != null)
                {
                    distance += (int) loc.GetDistance(lastloc);
                }
                lastloc = loc;
            }

            this.homealt = homealt/CurrentState.multiplierdist;

            Form frm = Common.LoadingBox("读取中", "读取高度数据");
           // Gdal.AllRegister();
            //gelocs = getGEAltPath(planlocs);
            gelocs = getSTRM90Path(planlocs);

            srtmlocs = getSRTMAltPath(planlocs);

            frm.Close();

            MissionPlanner.Utilities.Tracking.AddPage(this.GetType().ToString(), this.Text);
        }

        private void ElevationProfile_Load(object sender, EventArgs e)
        {
            if (planlocs.Count <= 1)
            {
                this.Close();
                return;
            }
            // GE plot
            double a = 0;
            double increment = (distance/(float)(gelocs.Count - 1));

            foreach (PointLatLngAlt geloc in gelocs)
            {
                if (geloc == null)
                    continue;

                list2.Add(a, geloc.Alt);

                Console.WriteLine("GE " + geloc.Lng + "," + geloc.Lat + "," + geloc.Alt);

                a += increment;
            }

            // Planner Plot
            a = 0;
            int count = 0;
            PointLatLngAlt lastloc = null;
            foreach (PointLatLngAlt planloc in planlocs)
            {
                if (planloc == null)
                    continue;

                if (lastloc != null)
                {
                    a += planloc.GetDistance(lastloc);
                }

                // deal with at mode
                if (altmode == GCSViews.FlightPlanner.altmode.Terrain)
                {
                    list1 = list4terrain;
                    break;
                }
                else if (altmode == GCSViews.FlightPlanner.altmode.Relative)
                {
                    // already includes the home alt
                    list1.Add(a, (planloc.Alt/CurrentState.multiplierdist), 0, planloc.Tag);
                }
                else
                {
                    // abs
                    // already absolute
                    list1.Add(a, (planloc.Alt/CurrentState.multiplierdist), 0, planloc.Tag);
                }

                lastloc = planloc;
                count++;
            }
            // draw graph
            CreateChart(zg1);
        }

        List<PointLatLngAlt> getSTRM90Path(List<PointLatLngAlt> list)
        {
            List<PointLatLngAlt> answer = new List<PointLatLngAlt>();

            double alt = 0;
            double lat = 0;
            double lng = 0;

            int pos = 0;
            //add by hdl
            int firstpoint = 0;

            if (list.Count <= 2)
            {
                CustomMessageBox.Show("航点太少", "错误");
                return answer;
            }
            //Ogr.RegisterAll();
            Gdal.AllRegister();

            PointLatLngAlt[] starttemp = new PointLatLngAlt[1];
            list.CopyTo(0, starttemp, 0, 1);
            PointLatLngAlt start = new PointLatLngAlt();
            start = starttemp[0];

            foreach (PointLatLngAlt loc in list)
            {

                PointLatLngAlt end = loc;
                if (start == end)
                    continue;
                int Getpointdistance = 0;
                double disInKm = start.GetDistance2(end);
                double exp = 0;
                double Xgeo = 0; double Ygeo = 0;
                string xx;
                string yy;
                Dataset ds = null;
                string oldpath = "";
                double dTemp = 0.0;
                double[] trans = new double[6];
                Band demband = null;
                while (true)
                {
                    if ((double)Getpointdistance < (disInKm))
                    {
                        exp = ((double)Getpointdistance) / (disInKm);
                        Ygeo = start.Lat + ((end.Lat - start.Lat) * exp);
                        Xgeo = start.Lng + ((end.Lng - start.Lng) * exp);
                    }
                    else
                    {
                        Ygeo = end.Lat;
                        Xgeo = end.Lng;

                        start = end;
                    }

                    xx = Math.Ceiling(((Xgeo + 180) / (5))).ToString();
                    yy = Math.Ceiling(((60 - Ygeo) / (5))).ToString();

                    if (yy.Length == 1)
                        yy = "0" + yy;

                    string path = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "srtm_90\\srtm_" + xx + "_" + yy + ".tif";
                    if (oldpath != path)
                    {
                        try
                        {
                            ds = Gdal.Open(path, Access.GA_ReadOnly);
                        }
                        catch (Exception e)
                        {
                            CustomMessageBox.Show("没找到文件" + "srtm_" + xx + "_" + yy + ".tif" + " 可能超出范围");
                            return answer;
                        }

                        oldpath = path;
                        demband = ds.GetRasterBand(1);

                        //double testx = 0; double testy = 0;

                        ds.GetGeoTransform(trans);
                        //testx = trans[0] + 1 * trans[1] + 1 * trans[2];
                        //testy = trans[3] + 1 * trans[4] + 1 * trans[5]; // 计算像素坐标为(100, 100)的点的实际地理坐标
                        dTemp = trans[1] * trans[5] - trans[2] * trans[4];
                    }
                    //int XSize = ds.RasterXSize;
                    //int YSize = ds.RasterYSize;
                    //int count = ds.RasterCount;

                    double dCol = 0.0; double dRow = 0.0;
                    dCol = (trans[5] * (Xgeo - trans[0]) - trans[2] * (Ygeo - trans[3])) / dTemp + 0.5;
                    dRow = (trans[1] * (Ygeo - trans[3]) - trans[4] * (Xgeo - trans[0])) / dTemp + 0.5;
                    int dx = (int)dCol;
                    int dy = (int)dRow;
                    int len = 1;
                    double[] dem = new double[1];
                    demband.ReadRaster(dx, dy, len, len, dem, len, len, len, len);
                    if (dem[0] < 0)
                        dem[0] = 0.0;
                    PointLatLngAlt getloc = new PointLatLngAlt(Ygeo, Xgeo, dem[0], "");
                    answer.Add(getloc);
                    firstpoint++;
                    //if (firstpoint == 1)
                        //homealt1 = dem[0];
                    if (start == end)
                        break;
                    Getpointdistance += 100;
                }
            }

            return answer;
        }

        List<PointLatLngAlt> getSRTMAltPath(List<PointLatLngAlt> list)
        {
            List<PointLatLngAlt> answer = new List<PointLatLngAlt>();

            PointLatLngAlt last = null;

            double disttotal = 0;

            foreach (PointLatLngAlt loc in list)
            {
                if (loc == null)
                    continue;

                if (last == null)
                {
                    last = loc;
                    continue;
                }

                double dist = last.GetDistance(loc);

                int points = (int) (dist/10) + 1;

                double deltalat = (last.Lat - loc.Lat);
                double deltalng = (last.Lng - loc.Lng);

                double steplat = deltalat/points;
                double steplng = deltalng/points;

                PointLatLngAlt lastpnt = last;

                for (int a = 0; a <= points; a++)
                {
                    double lat = last.Lat - steplat*a;
                    double lng = last.Lng - steplng*a;

                    var newpoint = new PointLatLngAlt(lat, lng, srtm.getAltitude(lat, lng).alt, "");

                    double subdist = lastpnt.GetDistance(newpoint);

                    disttotal += subdist;

                    // srtm alts
                    list3.Add(disttotal, newpoint.Alt/CurrentState.multiplierdist);

                    // terrain alt
                    list4terrain.Add(disttotal, (newpoint.Alt - homealt + loc.Alt)/CurrentState.multiplierdist);

                    lastpnt = newpoint;
                }

                answer.Add(new PointLatLngAlt(loc.Lat, loc.Lng, srtm.getAltitude(loc.Lat, loc.Lng).alt, ""));

                last = loc;
            }

            return answer;
        }

        List<PointLatLngAlt> getGEAltPath(List<PointLatLngAlt> list)
        {
            double alt = 0;
            double lat = 0;
            double lng = 0;

            int pos = 0;

            List<PointLatLngAlt> answer = new List<PointLatLngAlt>();

            //http://code.google.com/apis/maps/documentation/elevation/
            //http://maps.google.com/maps/api/elevation/xml
            string coords = "";

            foreach (PointLatLngAlt loc in list)
            {
                if (loc == null)
                    continue;

                coords = coords + loc.Lat.ToString(new System.Globalization.CultureInfo("en-US")) + "," +
                         loc.Lng.ToString(new System.Globalization.CultureInfo("en-US")) + "|";
            }
            coords = coords.Remove(coords.Length - 1);

            if (list.Count < 2 || coords.Length > (2048 - 256))
            {
                CustomMessageBox.Show("Too many/few WP's or to Big a Distance " + (distance/1000) + "km", Strings.ERROR);
                return answer;
            }

            try
            {
                using (
                    XmlTextReader xmlreader =
                        new XmlTextReader("http://maps.google.com/maps/api/elevation/xml?path=" + coords + "&samples=" +
                                          (distance/100).ToString(new System.Globalization.CultureInfo("en-US")) +
                                          "&sensor=false"))
                {
                    while (xmlreader.Read())
                    {
                        xmlreader.MoveToElement();
                        switch (xmlreader.Name)
                        {
                            case "elevation":
                                alt = double.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                Console.WriteLine("DO it " + lat + " " + lng + " " + alt);
                                PointLatLngAlt loc = new PointLatLngAlt(lat, lng, alt, "");
                                answer.Add(loc);
                                pos++;
                                break;
                            case "lat":
                                lat = double.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                break;
                            case "lng":
                                lng = double.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch
            {
                CustomMessageBox.Show("Error getting GE data", Strings.ERROR);
            }

            return answer;
        }

        public void CreateChart(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "地面以上高程";
            myPane.XAxis.Title.Text = "距离 (米)";
            myPane.YAxis.Title.Text = "高程 (米)";

            LineItem myCurve;

            myCurve = myPane.AddCurve("任务航线高度", list1, Color.Red, SymbolType.None);
            myCurve = myPane.AddCurve("NASA卫星扫描高度", list2, Color.Green, SymbolType.None);
            myCurve = myPane.AddCurve("高度", list3, Color.Blue, SymbolType.None);

            foreach (PointPair pp in list1)
            {
                // Add a another text item to to point out a graph feature
                TextObj text = new TextObj((string) pp.Tag, pp.X, pp.Y);
                // rotate the text 90 degrees
                text.FontSpec.Angle = 90;
                text.FontSpec.FontColor = Color.White;
                // Align the text such that the Right-Center is at (700, 50) in user scale coordinates
                text.Location.AlignH = AlignH.Right;
                text.Location.AlignV = AlignV.Center;
                // Disable the border and background fill options for the text
                text.FontSpec.Fill.IsVisible = false;
                text.FontSpec.Border.IsVisible = false;
                myPane.GraphObjList.Add(text);
            }

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = distance;

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
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

            // Calculate the Axis Scale Ranges
            try
            {
                zg1.AxisChange();
            }
            catch
            {
            }
        }
    }
}