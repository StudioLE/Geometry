using System;
using NUnit.Framework;
using StudioLE.Geometry.Solids;
// ReSharper disable RedundantCast

namespace StudioLE.Geometry.Tests.Solids
{
    [TestFixture]
    public class SphereTests
    {
        private Sphere sphere;

        [SetUp]
        public void Setup()
        {
            this.sphere = new Sphere(3);
        }

        [Test]
        public void SphereGet_Diameter()
        {
            double expect = this.sphere.Radius * 2;
            Assert.AreEqual(expect, this.sphere.Diameter, "Diameter should be double the radius");
        }

        [TestCase(1)]
        public void SphereSet_Diameter(double diameter)
        {
            this.sphere.Diameter = diameter;
            double expect = diameter / 2;
            Assert.AreEqual(expect, this.sphere.Radius, "Setting Diameter should set Radius");
        }

        [TestCase(1)]
        public void SphereSet_Radius(double radius)
        {
            this.sphere.Radius = radius;
            double expect = radius * 2;
            Assert.AreEqual(expect, this.sphere.Diameter, "Setting Radius should set Diameter");
        }

        [Test]
        public void SphereGet_Volume()
        {
            double expect = SphereVolumeFromRadius(this.sphere.Radius);
            Assert.AreEqual(expect, this.sphere.Volume, "Volume is not correct");
        }

        [Test]
        public void SphereGet_Mass()
        {
            double density = 0.5;
            this.sphere.Density = density;
            double expect = SphereVolumeFromRadius(this.sphere.Radius) * density;
            Assert.AreEqual(expect, this.sphere.Mass, "Mass is not correct");
        }

        [Test]
        public void SphereIs_Solid()
        {
            Assert.IsNotNull(this.sphere as Solid, "Should be a Solid");
        }

        [Test]
        public void SphereIsNot_Cylinder()
        {
            Assert.IsNull(this.sphere as Cylinder, "Should not be a Cylinder");
        }

        private double SphereVolumeFromRadius(double radius)
        {
            return (4 / 3d) * Math.PI * Math.Pow(radius, 3);
        }
    }
}