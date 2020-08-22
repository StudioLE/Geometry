using NUnit.Framework;
using System;

namespace StudioLE.Geometry.Tests
{
    [TestFixture]
    public class SolidTests
    {
        private Solid solid;

        [SetUp]
        public void Setup()
        {
            solid = new Solid()
            {
                Volume = 4
            };
        }

        [Test]
        public void SolidCorrect_Volume()
        {
            double expect = 4;
            Assert.AreEqual(expect, solid.Volume, "Volume is not correct");
        }

        [Test]
        public void SolidCorrect_Mass()
        {
            double density = 0.5;
            solid.Density = density;
            double expect = solid.Volume * density;
            Assert.AreEqual(expect, solid.Mass, "Mass is not correct");
        }

        [Test]
        public void SolidIs_Solid()
        {
            Assert.IsNotNull(solid as Solid, "Should be a Solid");
        }

        [Test]
        public void SolidIsNot_Cuboid()
        {
            Assert.IsNull(solid as Cuboid, "Should not be a Cuboid");
        }

        [Test]
        public void SolidIsNot_Sphere()
        {
            Assert.IsNull(solid as Sphere, "Should not be a Sphere");
        }
    }
}