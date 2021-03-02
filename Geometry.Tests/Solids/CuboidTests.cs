using NUnit.Framework;
using StudioLE.Geometry.Solids;
using UnitsNet;
using UnitsNet.NumberExtensions.NumberToDensity;
using UnitsNet.NumberExtensions.NumberToLength;

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
            this.cuboid = new Cuboid(3.Meters(), 2.Meters(), 1.Meters());
        }

        [Test]
        public void CuboidGet_Volume()
        {
            Volume expect = this.cuboid.Width * this.cuboid.Length * this.cuboid.Height;
            Assert.AreEqual(expect, this.cuboid.Volume, "Volume is not correct");
        }

        [Test]
        public void CuboidGet_Mass()
        {
            Density density = 0.5.KilogramsPerCubicMeter();
            this.cuboid.Density = density;
            Mass expect = this.cuboid.Width * this.cuboid.Length * this.cuboid.Height * density;
            Assert.AreEqual(expect, this.cuboid.Mass, "Mass is not correct");
        }

        [Test]
        public void CuboidIs_Solid()
        {
            Assert.IsNotNull(this.cuboid as Solid, "Should be a Solid");
        }
    }
}