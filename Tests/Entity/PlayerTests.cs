using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game;
using Ontwikkelopdracht_Game.Entity;

namespace Tests.Entity
{
    [TestClass]
    public class PlayerTests
    {
        private readonly ObjectManager _objectManager = ObjectManager.Instance;
        private readonly MockInputController _input = new MockInputController();

        [TestInitialize]
        public void SetUp()
        {
            InputController.Instance = _input;
        }

        [TestCleanup]
        public void TearDown()
        {
            _objectManager.GameObjects.Clear();
            _input.OverriddenKeys.Clear();
        }

        [TestMethod]
        public void TestMoveUp()
        {
            Player player = new Player
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50
            };

            _input.OverriddenKeys.Add(Key.W);
            player.GameTick();

            Assert.AreEqual(100, player.X);
            Assert.AreEqual(97, player.Y);
        }

        [TestMethod]
        public void TestMoveDown()
        {
            Player player = new Player
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50
            };
            
            _input.OverriddenKeys.Add(Key.S);
            player.GameTick();

            Assert.AreEqual(100, player.X);
            Assert.AreEqual(103, player.Y);
        }

        [TestMethod]
        public void TestMoveRight()
        {
            Player player = new Player
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50
            };

            _input.OverriddenKeys.Add(Key.D);
            player.GameTick();

            Assert.AreEqual(103, player.X);
            Assert.AreEqual(100, player.Y);
        }

        [TestMethod]
        public void TestMoveLeft()
        {
            Player player = new Player
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50
            };

            _input.OverriddenKeys.Add(Key.A);
            player.GameTick();

            Assert.AreEqual(97, player.X);
            Assert.AreEqual(100, player.Y);
        }

        [TestMethod]
        public void TestDealDamage()
        {
            Player player = new Player
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Health = 50,
                MaxHealth = 50
            };

            player.DealDamage(new Wall(), 5);

            Assert.AreEqual(45, player.Health);
        }

        [TestMethod]
        public void TestDie()
        {
            Player player = new Player
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Health = 50,
                MaxHealth = 50
            };

            player.DealDamage(new Wall(), 50);

            Assert.AreEqual(0, player.Health);
            Assert.IsFalse(World.Instance.Running);
        }

        [TestMethod]
        public void TestDieOverkill()
        {
            Player player = new Player
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Health = 50,
                MaxHealth = 50
            };

            player.DealDamage(new Wall(), 51);

            Assert.AreEqual(-1, player.Health);
            Assert.IsFalse(World.Instance.Running);
        }

        [TestMethod]
        public void TestFire()
        {
            Player player = new Player
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50
            };

            player.Fire();

            Assert.IsInstanceOfType(_objectManager.GameObjects[0], typeof (Bullet));
        }
    }
}
