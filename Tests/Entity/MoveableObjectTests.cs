using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game.Entity;

namespace Tests.Entity
{
    [TestClass]
    public class MoveableObjectTests
    {
        [TestMethod]
        public void TestRotate()
        {
            Player player = new Player
            {
                Rotation = 0
            };

            player.Rotate(Math.PI);

            Assert.AreEqual(Math.PI, player.Rotation);
        }

        [TestMethod]
        public void TestMultipleRotations()
        {
            Player player = new Player
            {
                Rotation = 0
            };

            player.Rotate(Math.PI*3.5);

            Assert.AreEqual(Math.PI*1.5, player.Rotation);
        }
    }
}
