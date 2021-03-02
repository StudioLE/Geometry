using System.Drawing;

namespace StudioLE.Geometry.Solids
{
    public class Solid
    {
        public Color Color { get; set; } = Color.Black;

        public double Density { get; set; } = 1;

        public virtual double Volume { get; set; }

        public double Mass { get => this.Volume * this.Density; }
    }
}
