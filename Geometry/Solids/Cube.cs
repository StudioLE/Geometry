using System;
using UnitsNet;

namespace StudioLE.Geometry.Solids
{
    public record Cube : Cuboid
    {
        public Cube(Length length) : base(length, length, length)
        {
        }

        public static Cube From(Cuboid cuboid)
        {
            if (cuboid.Width != cuboid.Length || cuboid.Width != cuboid.Height)
                throw new InvalidOperationException("Width, Length, and Height of the Cuboid are not equal");
            return cuboid as Cube;
        }
    }
}
