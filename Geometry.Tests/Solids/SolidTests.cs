using System;
using NUnit.Framework;
using StudioLE.Geometry.Solids;

// ReSharper disable RedundantCast

namespace StudioLE.Geometry.Tests.Solids
{
    [TestFixture]
    public class SolidTests
    {
        private Solid solid;

        [SetUp]
        public void Setup()
        {
            this.solid = new Solid();
        }

        [Test]
        public void SolidGet_Volume()
        {
            Assert.Throws<NotImplementedException>(() => this.solid.Volume(), "Volume should throw");
        }

        [Test]
        public void SolidGet_Mass()
        {
            Assert.Throws<NotImplementedException> (() => this.solid.Mass(), "Mass should throw");
        }

        [Test]
        public void SolidIs_Solid()
        {
            Assert.IsNotNull(this.solid as Solid, "Should be a Solid");
        }

        [Test]
        public void SolidIsNot_Cuboid()
        {
            Assert.IsNull(this.solid as Cuboid, "Should not be a Cuboid");
        }

        [Test]
        public void SolidIsNot_Sphere()
        {
            Assert.IsNull(this.solid as Sphere, "Should not be a Sphere");
        }
    }
}