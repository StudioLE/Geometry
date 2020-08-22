using NUnit.Framework;
using System;

namespace StudioLE.Geometry.Tests
{
    [TestFixture]
    public class VectorTests
    {
        private Vector vector;

        [SetUp]
        public void Setup()
        {
            vector = new Vector(3, 2, 1);
        }

        [TestCase(3, 2, 1)]
        public void VectorGet_Distance(double x, double y, double z)
        {
            Vector v1 = new Vector(x, y, z);
            double expect = DistanceTo(Vector.Origin, v1);
            Assert.AreEqual(expect, v1.Distance, "Distance is not correct");
        }

        [TestCase(2)]
        public void VectorGet_DistanceX(double x)
        {
            double expect = x;
            Vector v1 = new Vector(x, 0, 0);
            Assert.AreEqual(expect, v1.Distance, "Distance is not correct");
        }

        [TestCase(2)]
        public void VectorGet_DistanceY(double y)
        {
            double expect = y;
            Vector v1 = new Vector(0, y, 0);
            Assert.AreEqual(expect, v1.Distance, "Distance is not correct");
        }

        [TestCase(2)]
        public void VectorGet_DistanceZ(double z)
        {
            double expect = z;
            Vector v1 = new Vector(0, 0, z);
            Assert.AreEqual(expect, v1.Distance, "Distance is not correct");
        }

        [Test]
        public void VectorIsNot_Point()
        {
            Assert.IsNull(vector as Point, "Should not be a Point");
        }

        [Test]
        public void Vector_Distance()
        {
            Cuboid cuboid = new Cuboid(3, 3, 3);
            Assert.DoesNotThrow(() => { double test = vector.Distance; }, "Should have Distance");
        }

        [TestCase(1, 2, 3)]
        public void Vector_VectorAddition(double x, double y, double z)
        {
            Vector v2 = new Vector(x, y, z);
            Vector v3 = vector + v2;
            Vector expect = new Vector(
                vector.X + v2.X,
                vector.Y + v2.Y,
                vector.Z + v2.Z
            );
            Assert.IsTrue(v3.Equals(expect), "Vector is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Vector_VectorSubtraction(double x, double y, double z)
        {
            Vector v2 = new Vector(x, y, z);
            Vector v3 = vector - v2;
            Vector expect = new Vector(
                vector.X - v2.X,
                vector.Y - v2.Y,
                vector.Z - v2.Z
            );
            Assert.IsTrue(v3.Equals(expect), "Vector is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Vector_VectorMultiplication(double x, double y, double z)
        {
            Vector v2 = new Vector(x, y, z);
            Vector v3 = vector * v2;
            Vector expect = new Vector(
                vector.X * v2.X,
                vector.Y * v2.Y,
                vector.Z * v2.Z
            );
            Assert.IsTrue(v3.Equals(expect), "Vector is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Vector_VectorDivision(double x, double y, double z)
        {
            Vector v2 = new Vector(x, y, z);
            Vector v3 = vector / v2;
            Vector expect = new Vector(
                vector.X / v2.X,
                vector.Y / v2.Y,
                vector.Z / v2.Z
            );
            Assert.IsTrue(v3.Equals(expect), "Vector is not correct");
        }

        private static double DistanceTo(Vector v1, Vector v2)
        {
            return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2) + Math.Pow(v1.Z - v2.Z, 2));
        }
    }
}