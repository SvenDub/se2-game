using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game;
using Ontwikkelopdracht_Game.Entity;

namespace Tests.Entity
{
    [TestClass]
    public class BotTests
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
        public void TestFireStraight()
        {
            Bot bot = new Bot
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Rotation = Math.PI
            };

            bot.Fire();

            Assert.IsInstanceOfType(_objectManager.GameObjects[0], typeof(Bullet));

            Bullet bullet = (Bullet) _objectManager.GameObjects[0];

            Assert.AreEqual(Math.PI, bullet.Rotation);
        }

        [TestMethod]
        public void TestFireAtTarget()
        {
            Bot bot = new Bot
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Rotation = Math.PI
            };

            bot.Fire(200, 100);

            Assert.IsInstanceOfType(_objectManager.GameObjects[0], typeof(Bullet));

            Bullet bullet = (Bullet)_objectManager.GameObjects[0];

            Assert.AreEqual(Math.PI*0.5, bullet.Rotation);
        }

        [TestMethod]
        public void TestDie()
        {
            Bot bot = new Bot
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Health = 50,
                MaxHealth = 50
            };

            _objectManager.AddObject(bot);

            bot.DealDamage(new Wall(), 50);

            Assert.AreEqual(0, bot.Health);
            Assert.IsFalse(_objectManager.GameObjects.Contains(bot));
        }

        [TestMethod]
        public void TestDieOverkill()
        {
            Bot bot = new Bot
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Health = 50,
                MaxHealth = 50
            };

            _objectManager.AddObject(bot);

            bot.DealDamage(new Wall(), 51);

            Assert.AreEqual(-1, bot.Health);
            Assert.IsFalse(_objectManager.GameObjects.Contains(bot));
        }

        [TestMethod]
        public void TestLee()
        {
            Bot bot = new Bot
            {
                X = 150,
                Y = 100,
                Width = 50,
                Height = 50
            };

            Player player = new Player
            {
                X = 40,
                Y = 40,
                Width = 50,
                Height = 50
            };

            _objectManager.AddObject(bot);
            _objectManager.AddObject(player);

            Task.Factory.StartNew(() => bot.CreatePath(player)).Wait();

            Assert.AreEqual(3, bot.ShortestPathLength);
        }

        [TestMethod]
        public void TestGameTick()
        {
            Bot bot = new Bot
            {
                X = 150,
                Y = 100,
                Width = 50,
                Height = 50,
                BaseCooldown = 50
            };

            Player player = new Player
            {
                X = 40,
                Y = 40,
                Width = 50,
                Height = 50
            };

            _objectManager.AddObject(bot);
            _objectManager.AddObject(player);

            Task.Factory.StartNew(() => bot.CreatePath(player)).Wait();

            Assert.AreEqual(3, bot.ShortestPathLength);

            Task.Factory.StartNew(() => bot.GameTick()).Wait();

            Assert.AreEqual(149.31, Math.Round(bot.X, 2));
            Assert.AreEqual(98.12, Math.Round(bot.Y, 2));
            Assert.AreEqual(49, bot.Cooldown);
        }
    }
}
