using NUnit.Framework;
using StudioLE.Geometry.Solids;
// ReSharper disable RedundantCast

namespace StudioLE.Geometry.Tests.Solids
{
    [TestFixture]
    public class CuboidTests
    {
        private Cuboid cuboid;

        [SetUp]
        public void Setup()
        {
            this.cuboid = new Cuboid(3, 2, 1);
        }

        [Test]
        public void CuboidGet_Volume()
        {
            double expect = this.cuboid.Width * this.cuboid.Length * this.cuboid.Height;
            Assert.AreEqual(expect, this.cuboid.Volume, "Volume is not correct");
        }

        [Test]
        public void CuboidGet_Mass()
        {
            double density = 0.5;
            this.cuboid.Density = density;
            double expect = this.cuboid.Width * this.cuboid.Length * this.cuboid.Height * density;
            Assert.AreEqual(expect, this.cuboid.Mass, "Mass is not correct");
        }

        [Test]
        public void CuboidIs_Solid()
        {
            Assert.IsNotNull(this.cuboid as Solid, "Should be a Solid");
        }
    }
}