using NUnit.Framework;
using System;

namespace StudioLE.Geometry.Tests
{
    [TestFixture]
    public class CylinderTests
    {
        private Cylinder cylinder;

        [SetUp]
        public void Setup()
        {
            cylinder = new Cylinder(1, 3);
        }

        [Test]
        public void CylinderCorrect_Radius()
        {
            double expect = cylinder.Diameter / 2;
            Assert.AreEqual(expect, cylinder.Radius, "Radius should be half the diameter");
        }

        [Test]
        public void CylinderCorrect_Diameter()
        {
            double expect = cylinder.Radius * 2;
            Assert.AreEqual(expect, cylinder.Diameter, "Diameter should be double the radius");
        }

        [Test]
        public void CylinderCorrect_Volume()
        {
            double expect = VolumeFromRadiusAndHeight(cylinder.Radius, cylinder.Height);
            Assert.AreEqual(expect, cylinder.Volume, "Volume is not correct");
        }

        [Test]
        public void CylinderCorrect_Mass()
        {
            double density = 0.5;
            cylinder.Density = density;
            double expect = VolumeFromRadiusAndHeight(cylinder.Radius, cylinder.Height) * density;
            Assert.AreEqual(expect, cylinder.Mass, "Mass is not correct");
        }

        [Test]
        public void CylinderIs_Solid()
        {
            Assert.IsNotNull(cylinder as Solid, "Should be a Solid");
        }

        [Test]
        public void CylinderIs_Sphere()
        {
            Assert.IsNotNull(cylinder as Sphere, "Should be a Sphere");
        }

        private double VolumeFromRadiusAndHeight(double radius, double height)
        {
            return Math.PI * radius * height;
        }
    }
}