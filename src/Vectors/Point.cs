using System;

namespace StudioLE.Geometry
{
    public class Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public static Point Origin { get => new Point(0, 0, 0); }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(
                p1.X + p2.X,
                p1.Y + p2.Y,
                p1.Z + p2.Z
            );
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(
                p1.X - p2.X,
                p1.Y - p2.Y,
                p1.Z - p2.Z
            );
        }

        public static Point operator *(Point p1, Point p2)
        {
            return new Point(
                p1.X * p2.X,
                p1.Y * p2.Y,
                p1.Z * p2.Z
            );
        }

        public static Point operator /(Point p1, Point p2)
        {
            return new Point(
                p1.X / p2.X,
                p1.Y / p2.Y,
                p1.Z / p2.Z
            );
        }

        public bool Equals(Point p2)
            => X == p2.X && Y == p2.Y && Z == p2.Z;

        public double DistanceTo(Point p2)
            => Math.Sqrt(Math.Pow(X - p2.X, 2) + Math.Pow(Y - p2.Y, 2) + Math.Pow(Z - p2.Z, 2));
    }
}
