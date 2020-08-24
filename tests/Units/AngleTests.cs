using NUnit.Framework;
using System;

namespace StudioLE.Geometry.Tests
{
    [TestFixture]
    public class AngleTests
    {
        private Angle angle;

        [SetUp]
        public void Setup()
        {
            angle = 235;
        }

        [Test]
        public void AngleGet_Radians()
        {
            double expect = ToRadians(235);
            Assert.AreEqual(expect, angle.Radians, "Angle is not correct");
        }

        [Test]
        public void AngleSet_Radians()
        {
            double expect = 360;
            angle.Radians = 2 * Math.PI;
            Assert.AreEqual(expect, angle.Degrees, "Angle is not correct");
        }

        [TestCase(90)]
        [TestCase(-5)]
        public void Angle_AngleAddition(double degrees)
        {
            double expect = angle.Degrees + degrees;
            Angle a2 = degrees;
            Angle a3 = angle + a2;
            Assert.AreEqual(expect, a3.Degrees, "Angle is not correct");
        }

        [TestCase(90)]
        [TestCase(-35.5)]
        public void Angle_AngleSubtraction(double degrees)
        {
            double expect = angle.Degrees - degrees;
            Angle a2 = degrees;
            Angle a3 = angle - a2;
            Assert.AreEqual(expect, a3.Degrees, "Angle is not correct");
        }

        [TestCase(90)]
        public void Angle_AngleGreaterThan(double degrees)
        {
            bool expect = angle.Degrees > degrees;
            Angle a2 = degrees;
            bool result = angle > a2;
            Assert.AreEqual(expect, result, "Angle comparison is not correct");
        }

        [TestCase(90)]
        public void Angle_AngleLessThan(double degrees)
        {
            bool expect = angle.Degrees < degrees;
            Angle a2 = degrees;
            bool result = angle < a2;
            Assert.AreEqual(expect, result, "Angle comparison is not correct");
        }

        [TestCase(90)]
        public void Angle_ToRadians(double degrees)
        {
            double expect = ToRadians(degrees);
            double result = Angle.ToRadians(degrees);
            Assert.AreEqual(expect, result, "Angle is not correct");
        }

        [TestCase(90)]
        public void Angle_ToDegrees(double radians)
        {
            double expect = ToDegrees(radians);
            double result = Angle.ToDegrees(radians);
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