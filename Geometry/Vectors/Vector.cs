using System;

namespace StudioLE.Geometry
{
    public class Vector
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public virtual double Distance { get { return DistanceBetween(Origin); } }

        public static Vector Origin { get { return new Vector(0, 0, 0); } }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double DistanceBetween(Vector v2)
        {
            return Math.Sqrt(Math.Pow(X - v2.X, 2) + Math.Pow(Y - v2.Y, 2) + Math.Pow(Z - v2.Z, 2));
        }
    }
}
