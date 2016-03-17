using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game.Entity;

namespace Tests.Entity
{
    [TestClass]
    public class WallTests
    {
        [TestMethod]
        public void TestGameTick()
        {
            Wall wall = new Wall
            {
                X = 0,
                Y = 0,
                Width = 50,
                Height = 50
            };

            wall.GameTick();

            Assert.AreEqual(0, wall.X);
            Assert.AreEqual(0, wall.Y);
        }
    }
}