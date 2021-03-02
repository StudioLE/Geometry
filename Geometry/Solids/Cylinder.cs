using System;

namespace StudioLE.Geometry.Solids
{
    public class Cylinder : Sphere
    {
        public double Height { get; set; }

        public override double Volume { get => Math.PI * this.Radius * this.Height; }

        public Cylinder(double radius, double height) : base(radius)
        {
            this.Radius = radius;
            this.Height = height;
        }
    }
}
