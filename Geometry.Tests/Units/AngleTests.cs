using System;
using NUnit.Framework;
using UnitsNet;
using UnitsNet.NumberExtensions.NumberToAngle;

namespace StudioLE.Geometry.Tests.Units
{
    [TestFixture]
    public class AngleTests
    {
        private Angle angle;

        [SetUp]
        public void Setup()
        {
            this.angle = 235.Degrees();
        }

        [Test]
        public void AngleGet_Radians()
        {
            double expect = ToRadians(235);
            Assert.AreEqual(expect, this.angle.Radians, "Angle is not correct");
        }

        [Test]
        public void AngleSet_Radians()
        {
            double expect = 360;
            this.angle = (2 * Math.PI).Radians();
            Assert.AreEqual(expect, this.angle.Degrees, "Angle is not correct");
        }

        [TestCase(90)]
        [TestCase(-5)]
        public void Angle_AngleAddition(double degrees)
        {
            double expect = this.angle.Degrees + degrees;
            Angle a2 = degrees.Degrees();
            Angle a3 = this.angle + a2;
            Assert.AreEqual(expect, a3.Degrees, "Angle is not correct");
        }

        [TestCase(90)]
        [TestCase(-35.5)]
        public void Angle_AngleSubtraction(double degrees)
        {
            double expect = this.angle.Degrees - degrees;
            Angle a2 = degrees.Degrees();
            Angle a3 = this.angle - a2;
            Assert.AreEqual(expect, a3.Degrees, "Angle is not correct");
        }

        [TestCase(90)]
        public void Angle_AngleGreaterThan(double degrees)
        {
            bool expect = this.angle.Degrees > degrees;
            Angle a2 = degrees.Degrees();
            bool result = this.angle > a2;
            Assert.AreEqual(expect, result, "Angle comparison is not correct");
        }

        [TestCase(90)]
        public void Angle_AngleLessThan(double degrees)
        {
            bool expect = this.angle.Degrees < degrees;
            Angle a2 = degrees.Degrees();
            bool result = this.angle < a2;
            Assert.AreEqual(expect, result, "Angle comparison is not correct");
        }

        [TestCase(90)]
        public void Angle_ToRadians(double degrees)
        {
            double expect = ToRadians(degrees);
            double result = degrees.Degrees().Radians;
            Assert.AreEqual(expect, result, "Angle is not correct");
        }

        [TestCase(90)]
        public void Angle_ToDegrees(double radians)
        {
            double expect = ToDegrees(radians);
            double result = radians.Radians().Degrees;
            Assert.AreEqual(expect, result, "Angle is not correct");
        }

        public static double ToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        public static double ToDegrees(double radians)
        {
            return (180 / Math.PI) * radians;
        }
    }
}