using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AGaugeApp;
using System.IO.Ports;
using System.Threading;
using MissionPlanner.Attributes;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using System.Security.Cryptography.X509Certificates;

using System.Net;
using System.Net.Sockets;
using System.Xml; // config file
using System.Runtime.InteropServices; // dll imports
using log4net;
using ZedGraph; // Graphs
using MissionPlanner;
using System.Reflection;
using MissionPlanner.Utilities;

using System.IO;

using System.Drawing.Drawing2D;

namespace MissionPlanner
{
    public class GMapMarkerCamera : GMapMarker
    {
        const float rad2deg = (float)(180 / Math.PI);
        const float deg2rad = (float)(1.0 / rad2deg);

        static readonly System.Drawing.Size SizeSt = new System.Drawing.Size(global::MissionPlanner.Properties.Resources.camera.Width, global::MissionPlanner.Properties.Resources.camera.Height);
        float heading = 0;
        float cog = -1;
        float target = -1;
        float nav_bearing = -1;
        public GMapControl MainMap;

        public GMapMarkerCamera(PointLatLng p, float heading, float cog, float nav_bearing, float target, GMapControl map)
            : base(p)
        {
            this.heading = heading;
            this.cog = cog;
            this.target = target;
            this.nav_bearing = nav_bearing;
            Size = SizeSt;
            MainMap = map;
        }

        public override void OnRender(Graphics g)
        {
            Matrix temp = g.Transform;
            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

            g.RotateTransform(-MainMap.Bearing);

            //int length = 500;

/*
            // anti NaN
            try
            {
                g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float)Math.Cos((heading - 90) * deg2rad) * length, (float)Math.Sin((heading - 90) * deg2rad) * length);
            }
            catch { }
            g.DrawLine(new Pen(Color.Green, 2), 0.0f, 0.0f, (float)Math.Cos((nav_bearing - 90) * deg2rad) * length, (float)Math.Sin((nav_bearing - 90) * deg2rad) * length);
            g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float)Math.Cos((cog - 90) * deg2rad) * length, (float)Math.Sin((cog - 90) * deg2rad) * length);
            g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length, (float)Math.Sin((target - 90) * deg2rad) * length);
            // anti NaN
            try
            {

                float desired_lead_dist = 100;


                double width = (MainMap.Manager.GetDistance(MainMap.FromLocalToLatLng(0, 0), MainMap.FromLocalToLatLng(MainMap.Width, 0)) * 1000.0);
                double m2pixelwidth = MainMap.Width / width;

                float alpha = ((desired_lead_dist * (float)m2pixelwidth) / MainV2.cs.radius) * rad2deg;

                if (MainV2.cs.radius < -1)
                {
                    // fixme 

                    float p1 = (float)Math.Cos((cog) * deg2rad) * MainV2.cs.radius + MainV2.cs.radius;

                    float p2 = (float)Math.Sin((cog) * deg2rad) * MainV2.cs.radius + MainV2.cs.radius;

                    g.DrawArc(new Pen(Color.HotPink, 2), p1, p2, Math.Abs(MainV2.cs.radius) * 2, Math.Abs(MainV2.cs.radius) * 2, cog, alpha);

                }

                else if (MainV2.cs.radius > 1)
                {
                    // correct

                    float p1 = (float)Math.Cos((cog - 180) * deg2rad) * MainV2.cs.radius + MainV2.cs.radius;

                    float p2 = (float)Math.Sin((cog - 180) * deg2rad) * MainV2.cs.radius + MainV2.cs.radius;

                    g.DrawArc(new Pen(Color.HotPink, 2), -p1, -p2, MainV2.cs.radius * 2, MainV2.cs.radius * 2, cog - 180, alpha);
                }

            }

            catch { }
*/

            try
            {
                g.RotateTransform(heading);
            }
            catch { }
            g.DrawImageUnscaled(global::MissionPlanner.Properties.Resources.camera, global::MissionPlanner.Properties.Resources.camera.Width / -2, global::MissionPlanner.Properties.Resources.camera.Height / -2);

            g.Transform = temp;
        }
    }
}
