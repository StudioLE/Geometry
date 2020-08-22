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

        private static double DistanceTo(Vector v1, Vector v2)
        {
            return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2) + Math.Pow(v1.Z - v2.Z, 2));
        }
    }
}