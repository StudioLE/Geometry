using System;

namespace StudioLE.Geometry.Solids
{
    public class Sphere : Solid
    {
        public double Radius { get; set; }

        public double Diameter
        { 
            get => this.Radius * 2;
            set => this.Radius = value / 2;
        }

        public override double Volume => (4 / 3d) * Math.PI * Math.Pow(this.Radius, 3);

        public Sphere(double radius)
            => this.Radius = radius;
    }
}
