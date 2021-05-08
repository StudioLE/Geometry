using System;
using UnitsNet;
using UnitsNet.NumberExtensions.NumberToVolume;

namespace StudioLE.Geometry.Solids
{
    public record Sphere : Solid
    {
        public Length Radius { get; set; }

        public Length Diameter
        { 
            get => this.Radius * 2;
            set => this.Radius = value / 2;
        }

        public override Volume Volume => CalculateVolume(this.Radius);

        public Sphere(Length radius)
        {
            this.Radius = radius;
        }

        private static Volume CalculateVolume(Length radius)
        {
            return ((4 / 3d) * Math.PI * Math.Pow(radius.Meters, 3)).CubicMeters();
        }
    }
}
