using UnitsNet;

namespace StudioLE.Geometry.Solids
{
    public record Cuboid : Solid
    {
        public Length Width { get; init; }

        public Length Height { get; init; }

        public Length Length { get; init; }

        public override Volume Volume() => this.Width * this.Height * this.Length;

        public Cuboid(Length width, Length length, Length height)
        {
            this.Width = width;
            this.Length = length;
            this.Height = height;
        }
    }
}
