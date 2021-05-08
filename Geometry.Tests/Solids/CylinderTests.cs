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
    public class CylinderTests
    {
        private Cylinder cylinder;

        [SetUp]
        public void Setup()
        {
            this.cylinder = new Cylinder(1.Meters(), 3.Meters());
        }

        [Test]
        public void CylinderGet_Radius()
        {
            Length expect = this.cylinder.Diameter / 2;
            Assert.AreEqual(expect, this.cylinder.Radius, "Radius should be half the diameter");
        }

        [Test]
        public void CylinderGet_Diameter()
        {
            Length expect = this.cylinder.Radius * 2;
            Assert.AreEqual(expect, this.cylinder.Diameter, "Diameter should be double the radius");
        }

        [Test]
        public void CylinderGet_Volume()
        {
            Volume expect = CalculateVolume(this.cylinder.Radius, this.cylinder.Height);
            Assert.AreEqual(expect, this.cylinder.GetVolume(), "Volume is not correct");
        }

        [Test]
        public void CylinderGet_Mass()
        {
            Density density = 0.5.KilogramsPerCubicMeter();
            this.cylinder.Density = density;
            Mass expect = CalculateVolume(this.cylinder.Radius, this.cylinder.Height) * density;
            Assert.AreEqual(expect, this.cylinder.GetMass(), "GetMass is not correct");
        }

        [Test]
        public void Cylinder_Equality()
        {
            var anEqualCylinder = new Cylinder(1.Meters(), 3.Meters());
            var aDifferentCylinder = new Cylinder(2.Meters(), 3.Meters());

            Assert.IsTrue(anEqualCylinder == this.cylinder);
            Assert.IsTrue(anEqualCylinder.Equals(this.cylinder));
            Assert.IsTrue(aDifferentCylinder != this.cylinder);
            Assert.IsFalse(aDifferentCylinder == this.cylinder);
            Assert.IsFalse(aDifferentCylinder.Equals(this.cylinder));
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

        private static Volume CalculateVolume(Length radius, Length height)
        {
            return (Math.PI * Math.Pow(radius.Meters, 2) * height.Meters).CubicMeters();
        }
    }
}