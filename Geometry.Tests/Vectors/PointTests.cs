using NUnit.Framework;
using System;

namespace StudioLE.Geometry.Tests
{
    [TestFixture]
    public class PointTests
    {
        private Point point;

        [SetUp]
        public void Setup()
        {
            point = new Point(3, 2, 1);
        }

        [TestCase(3, 2, 1)]
        public void PointGet_DistanceToOrigin(double x, double y, double z)
        {
            Point p1 = new Point(x, y, z);
            double expect = DistanceBetween(Point.Origin, p1);
            Assert.AreEqual(expect, Point.Origin.DistanceTo(p1), "Distance is not correct");
        }

        [TestCase(1, 2, 3)]
        public void PointGet_DistanceTo(double x, double y, double z)
        {
            Point p1 = new Point(x, y, z);
            double expect = DistanceBetween(point, p1);
            Assert.AreEqual(expect, point.DistanceTo(p1), "Distance is not correct");
        }

        [Test]
        public void PointIs_Vector()
        {
            Assert.IsNotNull(point as Vector, "Should be a Vector");
        }

        private static double DistanceBetween(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
        }
    }
}