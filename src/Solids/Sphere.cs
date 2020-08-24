using System;

namespace StudioLE.Geometry
{
    public class Sphere : Solid
    {
        public double Radius { get; set; }

        public double Diameter
        { 
            get => Radius * 2;
            set => Radius = value / 2;
        }

        public override double Volume { get => (4 / 3) * Math.PI * Math.Pow(Radius, 3); }

        public Sphere(double radius)
            => Radius = radius;
    }
}
