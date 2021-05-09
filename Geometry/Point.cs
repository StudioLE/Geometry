using System;
using UnitsNet;
using UnitsNet.NumberExtensions.NumberToLength;

namespace StudioLE.Geometry
{
    public record Point
    {
        public Length X { get; init; }

        public Length Y { get; init; }

        public Length Z { get; init; }

        public static Point Origin => new Point(0.Meters(), 0.Meters(), 0.Meters());

        public Point(Length x, Length y, Length z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
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
                (p1.X.Meters * p2.X.Meters).Meters(),
                (p1.Y.Meters * p2.Y.Meters).Meters(),
                (p1.Z.Meters * p2.Z.Meters).Meters()
            );
        }

        public static Point operator /(Point p1, Point p2)
        {
            return new Point(
                (p1.X.Meters / p2.X.Meters).Meters(),
                (p1.Y.Meters / p2.Y.Meters).Meters(),
                (p1.Z.Meters / p2.Z.Meters).Meters()
            );
        }

        public Length DistanceTo(Point p2)
        {
            double x = Math.Pow((this.X - p2.X).Meters, 2);
            double y = Math.Pow((this.Y - p2.Y).Meters, 2);
            double z = Math.Pow((this.Z - p2.Z).Meters, 2);
            return Math.Sqrt(x + y + z).Meters();
        }
    }
}
