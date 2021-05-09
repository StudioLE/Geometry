using System;
using System.Drawing;
using UnitsNet;
using UnitsNet.NumberExtensions.NumberToDensity;

namespace StudioLE.Geometry.Solids
{
    public record Solid
    {
        public Color Color { get; init; } = Color.Black;

        public Density Density { get; init; } = 1.GramsPerCubicCentimeter();

        public virtual Volume Volume() => throw new NotImplementedException();

        public Mass Mass() => this.Volume() * this.Density;
    }
}
