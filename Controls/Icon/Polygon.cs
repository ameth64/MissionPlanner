using System.Drawing;

namespace MissionPlanner.Controls.Icon
{
    public class Polygon: Icon
    {
        internal override void doPaint(Graphics g)
        {
            var mid = Width/2;

            var points = new Point[]
            {
                new Point(mid - 7, mid - 7),
                new Point(mid + 7, mid - 10),
                new Point( mid, mid + 12), 
                new Point( mid-5, mid + 10), 
                new Point( mid - 7, mid - 7)
            };

            g.DrawLines(LinePen, points);
        }
    }

    public class PolygonWp : Icon
    {
        internal override void doPaint(Graphics g)
        {
            var mid = Width / 2;

            var points = new Point[]
            {
                new Point(mid - 4, mid - 4),
                new Point(mid + 4, mid - 10),
                new Point( mid, mid + 12),
                new Point( mid-5, mid + 10),
                new Point( mid - 4, mid - 4)
            };

            g.DrawLines(LinePen, points);
        }
    }
}
