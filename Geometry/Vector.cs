using UnitsNet;
using UnitsNet.NumberExtensions.NumberToLength;

namespace StudioLE.Geometry
{
    public class Vector : Point
    {
        public new static Vector Origin => new Vector(0.Meters(), 0.Meters(), 0.Meters());

        public Length Distance => DistanceTo(Origin);

        public Vector(Length x, Length y, Length z) : base(x, y, z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
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

        public static Vector operator *(Vector p1, Vector p2)
        {
            return new Vector(
                (p1.X.Meters * p2.X.Meters).Meters(),
                (p1.Y.Meters * p2.Y.Meters).Meters(),
                (p1.Z.Meters * p2.Z.Meters).Meters()
            );
        }

        public static Vector operator /(Vector p1, Vector p2)
        {
            return new Vector(
                (p1.X.Meters / p2.X.Meters).Meters(),
                (p1.Y.Meters / p2.Y.Meters).Meters(),
                (p1.Z.Meters / p2.Z.Meters).Meters()
            );
        }

        public Length DistanceTo(Vector v2) => DistanceTo(v2 as Point);
    }
}

