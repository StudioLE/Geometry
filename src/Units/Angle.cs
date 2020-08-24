using System;

namespace StudioLE.Geometry
{
    public class Angle
    {
        public double Degrees { get; set; }

        public double Radians
        {
            get => ToRadians(Degrees);
            set => Degrees = ToDegrees(value);
        }

        public static implicit operator Angle(double degrees)
            => new Angle() { Degrees = degrees };

        public static Angle operator +(Angle a1, Angle a2)
            => (a1.Degrees + a2.Degrees);

        public static Angle operator -(Angle a1, Angle a2)
            => (a1.Degrees - a2.Degrees);

        public static bool operator <(Angle a1, Angle a2)
            => a1.Degrees < a2.Degrees;

        public static bool operator >(Angle a1, Angle a2)
            => a1.Degrees > a2.Degrees;

        public static bool operator <=(Angle a1, Angle a2)
            => a1.Degrees <= a2.Degrees;

        public static bool operator >=(Angle a1, Angle a2)
            => a1.Degrees >= a2.Degrees;

        public static double ToRadians(double degrees)
            => (Math.PI / 180) * degrees;

        public static double ToDegrees(double radians)
            => (180 / Math.PI) * radians;

        public bool Equals(Angle a2)
            => Degrees == a2.Degrees;
    }
}
