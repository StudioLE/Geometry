using System;
using NUnit.Framework;
using UnitsNet;
using UnitsNet.NumberExtensions.NumberToLength;

// ReSharper disable RedundantCast

namespace StudioLE.Geometry.Tests.Vectors
{
    [TestFixture]
    public class VectorTests
    {
        private Vector vector;

        [SetUp]
        public void Setup()
        {
            this.vector = new Vector(3.Meters(), 2.Meters(), 1.Meters());
        }

        [TestCase(3, 2, 1)]
        public void VectorGet_Distance(double x, double y, double z)
        {
            var v1 = new Vector(x.Meters(), y.Meters(), z.Meters());
            Length expect = DistanceTo(Vector.Origin, v1);
            Assert.AreEqual(expect, v1.Distance, "Distance is not correct");
        }

        [TestCase(2)]
        public void VectorGet_DistanceX(double x)
        {
            Length expect = x.Meters();
            var v1 = new Vector(x.Meters(), 0.Meters(), 0.Meters());
            Assert.AreEqual(expect, v1.Distance, "Distance is not correct");
        }

        [TestCase(2)]
        public void VectorGet_DistanceY(double y)
        {
            Length expect = y.Meters();
            var v1 = new Vector(0.Meters(), y.Meters(), 0.Meters());
            Assert.AreEqual(expect, v1.Distance, "Distance is not correct");
        }

        [TestCase(2)]
        public void VectorGet_DistanceZ(double z)
        {
            Length expect = z.Meters();
            var v1 = new Vector(0.Meters(), 0.Meters(), z.Meters());
            Assert.AreEqual(expect, v1.Distance, "Distance is not correct");
        }

        [Test]
        public void VectorIs_Point()
        {
            Assert.IsNotNull(this.vector as Point, "Should be a Point");
        }

        [Test]
        public void Vector_Distance()
        {
            Assert.DoesNotThrow(() => { Length test = this.vector.Distance; }, "Should have Distance");
        }

        [TestCase(1, 2, 3)]
        public void Vector_VectorAddition(double x, double y, double z)
        {
            var v2 = new Vector(x.Meters(), y.Meters(), z.Meters());
            Vector v3 = this.vector + v2;
            var expect = new Vector(
                this.vector.X + v2.X,
                this.vector.Y + v2.Y,
                this.vector.Z + v2.Z
            );
            Assert.IsTrue(v3.Equals(expect), "Vector is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Vector_VectorSubtraction(double x, double y, double z)
        {
            var v2 = new Vector(x.Meters(), y.Meters(), z.Meters());
            Vector v3 = this.vector - v2;
            var expect = new Vector(
                this.vector.X - v2.X,
                this.vector.Y - v2.Y,
                this.vector.Z - v2.Z
            );
            Assert.IsTrue(v3.Equals(expect), "Vector is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Vector_VectorMultiplication(double x, double y, double z)
        {
            var v2 = new Vector(x.Meters(), y.Meters(), z.Meters());
            Vector v3 = this.vector * v2;
            Vector expect = new Vector(
                (this.vector.X.Meters * v2.X.Meters).Meters(),
                (this.vector.Y.Meters * v2.Y.Meters).Meters(),
                (this.vector.Z.Meters * v2.Z.Meters).Meters()
            );
            Assert.IsTrue(v3.Equals(expect), "Vector is not correct");
        }

        [TestCase(1, 2, 3)]
        public void Vector_VectorDivision(double x, double y, double z)
        {
            var v2 = new Vector(x.Meters(), y.Meters(), z.Meters());
            Vector v3 = this.vector / v2;
            var expect = new Vector(
                (this.vector.X.Meters / v2.X.Meters).Meters(),
                (this.vector.Y.Meters / v2.Y.Meters).Meters(),
                (this.vector.Z.Meters / v2.Z.Meters).Meters()
            );
            Assert.IsTrue(v3.Equals(expect), "Vector is not correct");
        }

        [Test]
        public void Point_Equality()
        {
            var anEqualVector = new Vector(3.Meters(), 2.Meters(), 1.Meters());
            var aDifferentVector = new Vector(2.Meters(), 2.Meters(), 1.Meters());

            Assert.IsTrue(anEqualVector == this.vector);
            Assert.IsTrue(anEqualVector.Equals(this.vector));
            Assert.IsTrue(aDifferentVector != this.vector);
            Assert.IsFalse(aDifferentVector == this.vector);
            Assert.IsFalse(aDifferentVector.Equals(this.vector));
        }

        private static Length DistanceTo(Vector p1, Vector p2)
        {
            double x = Math.Pow((p1.X - p2.X).Meters, 2);
            double y = Math.Pow((p1.Y - p2.Y).Meters, 2);
            double z = Math.Pow((p1.Z - p2.Z).Meters, 2);
            return Math.Sqrt(x + y + z).Meters();
        }
    }
}