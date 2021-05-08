using System.Drawing;
using UnitsNet;
using UnitsNet.NumberExtensions.NumberToDensity;

namespace StudioLE.Geometry.Solids
{
    public record Solid
    {
        public Color Color { get; set; } = Color.Black;

        public Density Density { get; set; } = 1.GramsPerCubicCentimeter();

        public virtual Volume Volume { get; set; }

        public Mass Mass => this.Volume * this.Density;
    }
}
