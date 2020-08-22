using System;

namespace StudioLE.Geometry
{
    public class Point : Vector
    {
        [Obsolete("Don't use this", true)]
        public override double Distance { get { throw new NotImplementedException(); } }

        public static new Point Origin { get { return new Point(0, 0, 0); } }

        public Point(double x, double y, double z) : base(x, y, z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
