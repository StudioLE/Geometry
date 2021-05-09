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
            Assert.AreEqual(expect, this.cuboid.Volume(), "Volume is not correct");
        }

        [Test]
        public void CuboidGet_Mass()
        {
            Density density = 1.GramsPerCubicCentimeter();
            Mass expect = this.cuboid.Width * this.cuboid.Length * this.cuboid.Height * density;
            Assert.AreEqual(expect, this.cuboid.Mass(), "Mass is not correct");
        }

        [Test]
        public void Cuboid_Equality()
        {
            var same = new Cuboid(3.Meters(), 2.Meters(), 1.Meters());
            var different = new Cuboid(3.Meters(), 1.Meters(), 1.Meters());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(same == this.cuboid, "Objects should be equal");
                Assert.IsTrue(same.Equals(this.cuboid), "Objects should be equal");
                Assert.IsTrue(different != this.cuboid, "Objects should be different");
                Assert.IsFalse(different == this.cuboid, "Objects should be different");
                Assert.IsFalse(different.Equals(this.cuboid), "Objects should be different");
            });
        }

        [Test]
        public void CuboidIs_Solid()
        {
            Assert.IsNotNull(this.cuboid as Solid, "Should be a Solid");
        }
    }
}