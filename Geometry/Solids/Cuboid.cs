namespace StudioLE.Geometry.Solids
{
    public class Cuboid : Solid
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }

        public override double Volume { get => this.Width * this.Height * this.Length; }

        public Cuboid(double width, double length, double height)
        {
            this.Width = width;
            this.Length = length;
            this.Height = height;
        }
    }
}
