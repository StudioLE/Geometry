using System;

namespace StudioLE.Geometry
{
    public class Vector : Point
    {
        public static new Vector Origin { get { return new Vector(0, 0, 0); } }

        public double Distance { get { return DistanceTo(Origin); } }

        public Vector(double x, double y, double z) : base(x, y, z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(
                v1.X + v2.X,
                v1.Y + v2.Y,
                v1.Z + v2.Z
            );
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(
                v1.X - v2.X,
                v1.Y - v2.Y,
                v1.Z - v2.Z
            );
        }

        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(
                v1.X * v2.X,
                v1.Y * v2.Y,
                v1.Z * v2.Z
            );
        }

        public static Vector operator /(Vector v1, Vector v2)
        {
            return new Vector(
                v1.X / v2.X,
                v1.Y / v2.Y,
                v1.Z / v2.Z
            );
        }

        public double DistanceTo(Vector v2)
        {
            return DistanceTo(v2 as Point);
        }
    }
}
