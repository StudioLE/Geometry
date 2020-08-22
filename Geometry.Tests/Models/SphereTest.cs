using NUnit.Framework;
using System;

namespace StudioLE.Geometry.Tests
{
    [TestFixture]
    public class SphereTests
    {
        private Sphere sphere;

        [SetUp]
        public void Setup()
        {
            sphere = new Sphere(3);
        }

        [Test]
        public void SphereGet_Diameter()
        {
            double expect = sphere.Radius * 2;
            Assert.AreEqual(expect, sphere.Diameter, "Diameter should be double the radius");
        }

        [Test]
        public void SphereGet_Volume()
        {
            double expect = SphereVolumeFromRadius(sphere.Radius);
            Assert.AreEqual(expect, sphere.Volume, "Volume is not correct");
        }

        [Test]
        public void SphereGet_Mass()
        {
            double density = 0.5;
            sphere.Density = density;
            double expect = SphereVolumeFromRadius(sphere.Radius) * density;
            Assert.AreEqual(expect, sphere.Mass, "Mass is not correct");
        }

        [Test]
        public void SphereIs_Solid()
        {
            Assert.IsNotNull(sphere as Solid, "Should be a Solid");
        }

        [Test]
        public void SphereIsNot_Cylinder()
        {
            Assert.IsNull(sphere as Cylinder, "Should not be a Cylinder");
        }

        private double SphereVolumeFromRadius(double radius)
        {
            return (4 / 3) * Math.PI * Math.Pow(radius, 3);
        }
    }
}