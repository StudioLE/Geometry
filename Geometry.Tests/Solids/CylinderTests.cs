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
            Assert.AreEqual(expect, this.cylinder.Volume(), "Volume is not correct");
        }

        [Test]
        public void CylinderGet_Mass()
        {
            Density density = 1.GramsPerCubicCentimeter();
            Mass expect = CalculateVolume(this.cylinder.Radius, this.cylinder.Height) * density;
            Assert.AreEqual(expect, this.cylinder.Mass(), "Mass is not correct");
        }

        [Test]
        public void Cylinder_Equality()
        {
            var same = new Cylinder(1.Meters(), 3.Meters());
            var different = new Cylinder(2.Meters(), 3.Meters());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(same == this.cylinder, "Objects should be equal");
                Assert.IsTrue(same.Equals(this.cylinder), "Objects should be equal");
                Assert.IsTrue(different != this.cylinder, "Objects should be different");
                Assert.IsFalse(different == this.cylinder, "Objects should be different");
                Assert.IsFalse(different.Equals(this.cylinder), "Objects should be different");
            });
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