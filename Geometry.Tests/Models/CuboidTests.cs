using NUnit.Framework;
using System;

namespace StudioLE.Geometry.Tests
{
    [TestFixture]
    public class CuboidTests
    {
        private Cuboid cuboid;

        [SetUp]
        public void Setup()
        {
            cuboid = new Cuboid(3, 2, 1);
        }

        [Test]
        public void CuboidCorrect_Volume()
        {
            double expect = cuboid.Width * cuboid.Length * cuboid.Height;
            Assert.AreEqual(expect, cuboid.Volume, "Volume is not correct");
        }

        [Test]
        public void CuboidCorrect_Mass()
        {
            double density = 0.5;
            cuboid.Density = density;
            double expect = cuboid.Width * cuboid.Length * cuboid.Height * density;
            Assert.AreEqual(expect, cuboid.Mass, "Mass is not correct");
        }

        [Test]
        public void CuboidIs_Solid()
        {
            Assert.IsNotNull(cuboid as Solid, "Should be a Solid");
        }
    }
}