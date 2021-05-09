using System;
using NUnit.Framework;
using StudioLE.Geometry.Solids;
using UnitsNet;
using UnitsNet.NumberExtensions.NumberToDensity;
using UnitsNet.NumberExtensions.NumberToLength;
using UnitsNet.NumberExtensions.NumberToVolume;

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
            this.sphere = new Sphere(3.Meters());
        }

        [Test]
        public void SphereGet_Diameter()
        {
            Length expect = this.sphere.Radius * 2;
            Assert.AreEqual(expect, this.sphere.Diameter, "Diameter should be double the radius");
        }

        [TestCase(1)]
        public void SphereSet_Diameter(double diameter)
        {
            this.sphere.Diameter = diameter.Meters();
            Length expect = diameter.Meters() / 2;
            Assert.AreEqual(expect, this.sphere.Radius, "Setting Diameter should set Radius");
        }

        [TestCase(1)]
        public void SphereSet_Radius(double radius)
        {
            this.sphere.Radius = radius.Meters();
            Length expect = radius.Meters() * 2;
            Assert.AreEqual(expect, this.sphere.Diameter, "Setting Radius should set Diameter");
        }

        [Test]
        public void SphereGet_Volume()
        {
            Volume expect = CalculateVolume(this.sphere.Radius);
            Assert.AreEqual(expect, this.sphere.Volume(), "Volume is not correct");
        }

        [Test]
        public void SphereGet_Mass()
        {
            Density density = 0.5.KilogramsPerCubicMeter();
            this.sphere.Density = density;
            Mass expect = CalculateVolume(this.sphere.Radius) * density;
            Assert.AreEqual(expect, this.sphere.Mass(), "Mass is not correct");
        }

        [Test]
        public void Sphere_Equality()
        {
            var anEqualSphere = new Sphere(3.Meters());
            var aDifferentSphere = new Sphere(2.Meters());

            Assert.IsTrue(anEqualSphere == this.sphere);
            Assert.IsTrue(anEqualSphere.Equals(this.sphere));
            Assert.IsTrue(aDifferentSphere != this.sphere);
            Assert.IsFalse(aDifferentSphere == this.sphere);
            Assert.IsFalse(aDifferentSphere.Equals(this.sphere));
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

        private static Volume CalculateVolume(Length radius)
        {
            return ((4 / 3d) * Math.PI * Math.Pow(radius.Meters, 3)).CubicMeters();
        }
    }
}