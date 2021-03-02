using System;
using NUnit.Framework;
using StudioLE.Geometry.Solids;
// ReSharper disable RedundantCast

namespace StudioLE.Geometry.Tests.Solids
{
    [TestFixture]
    public class CubeTests
    {
        private Cube cube;

        [SetUp]
        public void Setup()
        {
            this.cube = new Cube(3);
        }

        [Test]
        public void CubeEqual_WidthLength()
        {
            Assert.AreEqual(this.cube.Width, this.cube.Length, "Length not equal to width");
        }

        [Test]
        public void CubeEqual_WidthHeight()
        {
            Assert.AreEqual(this.cube.Width, this.cube.Height, "Height not equal to width");
        }

        [Test]
        public void CubeGet_Volume()
        {
            double expect = this.cube.Width * this.cube.Length * this.cube.Height;
            Assert.AreEqual(expect, this.cube.Volume, "Volume is not correct");
        }

        [Test]
        public void CubeGet_Mass()
        {
            double density = 0.5;
            this.cube.Density = density;
            double expect = this.cube.Width * this.cube.Length * this.cube.Height * density;
            Assert.AreEqual(expect, this.cube.Mass, "Mass is not correct");
        }

        [Test]
        public void CubeIs_Solid()
        {
            Assert.IsNotNull(this.cube as Solid, "Should be a Solid");
        }

        [Test]
        public void CubeIs_Cuboid()
        {
            Assert.IsNotNull(this.cube as Cuboid, "Should be a Cuboid");
        }

        [Test]
        public void CubeFrom_Cuboid()
        {
            Cuboid cuboid = new Cuboid(3, 3, 3);
            Assert.DoesNotThrow(() => Cube.From(cuboid), "Should create Cube from regular Cuboid");
        }

        [Test]
        public void CubeFrom_InvalidCuboid()
        {
            Cuboid cuboid = new Cuboid(3, 3, 1);
            Assert.Throws<InvalidOperationException>(() => Cube.From(cuboid), "Should not create Cube from irregular Cuboid");
        }
    }
}