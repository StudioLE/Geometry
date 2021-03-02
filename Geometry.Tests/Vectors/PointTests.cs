using System;
using NUnit.Framework;
using UnitsNet;
using UnitsNet.NumberExtensions.NumberToLength;

namespace StudioLE.Geometry.Tests.Vectors
{
    [TestFixture]
    public class PointTests
    {
        private Point point;

        [SetUp]
        public void Setup()
        {
            this.point = new Point(3.Meters(), 2.Meters(), 1.Meters());
        }

        [TestCase(3, 2, 1)]
        public void PointGet_DistanceToOrigin(double x, double y, double z)
        {
            var p1 = new Point(x.Meters(), y.Meters(), z.Meters());
            Length expect = DistanceTo(Point.Origin, p1);
            Assert.AreEqual(expect, Point.Origin.DistanceTo(p1), "Distance is not correct");
        }

        [TestCase(1, 2, 3)]
        public void PointGet_DistanceTo(double x, double y, double z)
        {
            var p1 = new Point(x.Meters(), y.Meters(), z.Meters());
            Length expect = DistanceTo(this.point, p1);
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
            var p2 = new Point(x.Meters(), y.Meters(), z.Meters());
            Point p3 = this.point + p2;
            var expect = new Point(
                this.point.X + p2.X,
                this.point.Y + p2.Y,
                this.point.Z + p2.Z
            );
            Assert.IsTrue(p3.Equals(expect), "Point is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Point_PointSubtraction(double x, double y, double z)
        {
            var p2 = new Point(x.Meters(), y.Meters(), z.Meters());
            Point p3 = this.point - p2;
            var expect = new Point(
                this.point.X - p2.X,
                this.point.Y - p2.Y,
                this.point.Z - p2.Z
            );
            Assert.IsTrue(p3.Equals(expect), "Point is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Point_PointMultiplication(double x, double y, double z)
        {
            var p2 = new Point(x.Meters(), y.Meters(), z.Meters());
            Point p3 = this.point * p2;
            var expect = new Point(
                (this.point.X.Meters * p2.X.Meters).Meters(),
                (this.point.Y.Meters * p2.Y.Meters).Meters(),
                (this.point.Z.Meters * p2.Z.Meters).Meters()
            );
            Assert.IsTrue(p3.Equals(expect), "Point is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Point_PointDivision(double x, double y, double z)
        {
            var p2 = new Point(x.Meters(), y.Meters(), z.Meters());
            Point p3 = this.point / p2;
            var expect = new Point(
                (this.point.X.Meters / p2.X.Meters).Meters(),
                (this.point.Y.Meters / p2.Y.Meters).Meters(),
                (this.point.Z.Meters / p2.Z.Meters).Meters()
            );
            Assert.IsTrue(p3.Equals(expect), "Point is not correct");
        }

        private static Length DistanceTo(Point p1, Point p2)
        {
            double x = Math.Pow((p1.X - p2.X).Meters, 2);
            double y = Math.Pow((p1.Y - p2.Y).Meters, 2);
            double z = Math.Pow((p1.Z - p2.Z).Meters, 2);
            return Math.Sqrt(x + y + z).Meters();
        }
    }
}