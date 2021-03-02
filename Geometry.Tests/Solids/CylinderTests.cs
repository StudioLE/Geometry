using System;
using NUnit.Framework;
using StudioLE.Geometry.Solids;
// ReSharper disable RedundantCast

namespace StudioLE.Geometry.Tests.Solids
{
    [TestFixture]
    public class CylinderTests
    {
        private Cylinder cylinder;

        [SetUp]
        public void Setup()
        {
            this.cylinder = new Cylinder(1, 3);
        }

        [Test]
        public void CylinderGet_Radius()
        {
            double expect = this.cylinder.Diameter / 2;
            Assert.AreEqual(expect, this.cylinder.Radius, "Radius should be half the diameter");
        }

        [Test]
        public void CylinderGet_Diameter()
        {
            double expect = this.cylinder.Radius * 2;
            Assert.AreEqual(expect, this.cylinder.Diameter, "Diameter should be double the radius");
        }

        [Test]
        public void CylinderGet_Volume()
        {
            double expect = VolumeFromRadiusAndHeight(this.cylinder.Radius, this.cylinder.Height);
            Assert.AreEqual(expect, this.cylinder.Volume, "Volume is not correct");
        }

        [Test]
        public void CylinderGet_Mass()
        {
            double density = 0.5;
            this.cylinder.Density = density;
            double expect = VolumeFromRadiusAndHeight(this.cylinder.Radius, this.cylinder.Height) * density;
            Assert.AreEqual(expect, this.cylinder.Mass, "Mass is not correct");
        }

        [Test]
        public void CylinderIs_Solid()
        {
            Assert.IsNotNull(this.cylinder as Solid, "Should be a Solid");
        }

        [Test]
        public void CylinderIs_Sphere()
        {
            Assert.IsNotNull(this.cylinder as Sphere, "Should be a Sphere");
        }

        private double VolumeFromRadiusAndHeight(double radius, double height)
        {
            return Math.PI * radius * height;
        }
    }
}