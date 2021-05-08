using System;
using UnitsNet;
using UnitsNet.NumberExtensions.NumberToVolume;

namespace StudioLE.Geometry.Solids
{
    public record Cylinder : Sphere
    {
        public Length Height { get; set; }

        public override Volume GetVolume() => CalculateVolume(this.Radius, this.Height);

        public Cylinder(Length radius, Length height) : base(radius)
        {
            this.Height = height;
        }

        private static Volume CalculateVolume(Length radius, Length height)
        {
            return (Math.PI * Math.Pow(radius.Meters, 2) * height.Meters).CubicMeters();
        }
    }
}
