using System;

namespace StudioLE.Geometry
{
    public class Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public static Point Origin { get { return new Point(0, 0, 0); } }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double DistanceTo(Point p2)
        {
            return Math.Sqrt(Math.Pow(X - p2.X, 2) + Math.Pow(Y - p2.Y, 2) + Math.Pow(Z - p2.Z, 2));
        }
    }
}
