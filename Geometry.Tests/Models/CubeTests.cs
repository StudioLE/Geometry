using NUnit.Framework;
using System;

namespace StudioLE.Geometry.Tests
{
    [TestFixture]
    public class CubeTests
    {
        private Cube cube;

        [SetUp]
        public void Setup()
        {
            cube = new Cube(3);
        }

        [Test]
        public void CubeEqual_WidthLength()
        {
            Assert.AreEqual(cube.Width, cube.Length, "Length not equal to width");
        }

        [Test]
        public void CubeEqual_WidthHeight()
        {
            Assert.AreEqual(cube.Width, cube.Height, "Height not equal to width");
        }

        [Test]
        public void CubeCorrect_Volume()
        {
            double expect = cube.Width * cube.Length * cube.Height;
            Assert.AreEqual(expect, cube.Volume, "Volume is not correct");
        }

        [Test]
        public void CubeCorrect_Mass()
        {
            double density = 0.5;
            cube.Density = density;
            double expect = cube.Width * cube.Length * cube.Height * density;
            Assert.AreEqual(expect, cube.Mass, "Mass is not correct");
        }

        [Test]
        public void CubeIs_Solid()
        {
            Assert.IsNotNull(cube as Solid, "Should be a Solid");
        }

        [Test]
        public void CubeIs_Cuboid()
        {
            Assert.IsNotNull(cube as Cuboid, "Should be a Cuboid");
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