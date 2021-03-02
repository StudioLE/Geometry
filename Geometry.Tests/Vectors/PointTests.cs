using System;
using NUnit.Framework;

namespace StudioLE.Geometry.Tests.Vectors
{
    [TestFixture]
    public class PointTests
    {
        private Point point;

        [SetUp]
        public void Setup()
        {
            this.point = new Point(3, 2, 1);
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
            double expect = DistanceBetween(this.point, p1);
            Assert.AreEqual(expect, this.point.DistanceTo(p1), "Distance is not correct");
        }

        [Test]
        public void PointIsNot_Vector()
        {
            Assert.IsNull(this.point as Vector, "Should not be a Vector");
        }

        [TestCase(1, 2, 3)]
        public void Point_PointAddition(double x, double y, double z)
        {
            Point p2 = new Point(x, y, z);
            Point p3 = this.point + p2;
            Point expect = new Point(
                this.point.X + p2.X,
                this.point.Y + p2.Y,
                this.point.Z + p2.Z
            );
            Assert.IsTrue(p3.Equals(expect), "Point is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Point_PointSubtraction(double x, double y, double z)
        {
            Point p2 = new Point(x, y, z);
            Point p3 = this.point - p2;
            Point expect = new Point(
                this.point.X - p2.X,
                this.point.Y - p2.Y,
                this.point.Z - p2.Z
            );
            Assert.IsTrue(p3.Equals(expect), "Point is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Point_PointMultiplication(double x, double y, double z)
        {
            Point p2 = new Point(x, y, z);
            Point p3 = this.point * p2;
            Point expect = new Point(
                this.point.X * p2.X,
                this.point.Y * p2.Y,
                this.point.Z * p2.Z
            );
            Assert.IsTrue(p3.Equals(expect), "Point is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Point_PointDivision(double x, double y, double z)
        {
            Point p2 = new Point(x, y, z);
            Point p3 = this.point / p2;
            Point expect = new Point(
                this.point.X / p2.X,
                this.point.Y / p2.Y,
                this.point.Z / p2.Z
            );
            Assert.IsTrue(p3.Equals(expect), "Point is not correct");
        }

        private static double DistanceBetween(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
        }
    }
}