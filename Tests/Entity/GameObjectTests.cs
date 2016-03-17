using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game;
using Ontwikkelopdracht_Game.Entity;

namespace Tests.Entity
{
    [TestClass]
    public class GameObjectTests
    {
        private readonly ObjectManager _objectManager = ObjectManager.Instance;

        [TestInitialize]
        public void SetUp()
        {

        }

        [TestCleanup]
        public void TearDown()
        {
            _objectManager.GameObjects.Clear();
        }

        [TestMethod]
        public void TestDestroying()
        {
            GameObject gameObject = new Wall();
            _objectManager.AddObject(gameObject);
            Assert.AreEqual(1, _objectManager.GameObjects.Count);
            gameObject.Destroy();
            Assert.AreEqual(0, _objectManager.GameObjects.Count);
        }

        [TestMethod]
        public void TestDealDamage()
        {
            GameObject gameObject = new Wall();
            gameObject.Health = 100;
            gameObject.DealDamage(null, 10);
            Assert.AreEqual(90, gameObject.Health);
        }

        [TestMethod]
        public void TestToString()
        {
            GameObject gameObject = new Wall();
            Assert.AreEqual("Wall @ 0,0", gameObject.ToString());
        }
    }
}
