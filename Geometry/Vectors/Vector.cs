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

        public double DistanceTo(Vector v2)
        {
            return DistanceTo(v2);
        }
    }
}
