using NUnit.Framework;
using StudioLE.Geometry.Solids;
// ReSharper disable RedundantCast

namespace StudioLE.Geometry.Tests.Solids
{
    [TestFixture]
    public class SolidTests
    {
        private Solid solid;

        [SetUp]
        public void Setup()
        {
            this.solid = new Solid()
            {
                Volume = 4
            };
        }

        [Test]
        public void SolidGet_Volume()
        {
            double expect = 4;
            Assert.AreEqual(expect, this.solid.Volume, "Volume is not correct");
        }

        [Test]
        public void SolidGet_Mass()
        {
            double density = 0.5;
            this.solid.Density = density;
            double expect = this.solid.Volume * density;
            Assert.AreEqual(expect, this.solid.Mass, "Mass is not correct");
        }

        [Test]
        public void SolidIs_Solid()
        {
            Assert.IsNotNull(this.solid as Solid, "Should be a Solid");
        }

        [Test]
        public void SolidIsNot_Cuboid()
        {
            Assert.IsNull(this.solid as Cuboid, "Should not be a Cuboid");
        }

        [Test]
        public void SolidIsNot_Sphere()
        {
            Assert.IsNull(this.solid as Sphere, "Should not be a Sphere");
        }
    }
}