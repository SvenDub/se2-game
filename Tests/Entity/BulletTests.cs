using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game;
using Ontwikkelopdracht_Game.Entity;

namespace Tests.Entity
{
    [TestClass]
    public class BulletTests
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
        public void TestMoveUp()
        {
            Bullet bullet = new Bullet
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Rotation = Math.PI,
                Speed = 1
            };

            bullet.GameTick();

            Assert.AreEqual(100, bullet.X);
            Assert.AreEqual(99, bullet.Y);
        }

        [TestMethod]
        public void TestMoveDown()
        {
            Bullet bullet = new Bullet
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Rotation = 0,
                Speed = 1
            };

            bullet.GameTick();

            Assert.AreEqual(100, bullet.X);
            Assert.AreEqual(101, bullet.Y);
        }

        [TestMethod]
        public void TestMoveLeft()
        {
            Bullet bullet = new Bullet
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Rotation = Math.PI*1.5,
                Speed = 1
            };

            bullet.GameTick();

            Assert.AreEqual(99, bullet.X);
            Assert.AreEqual(100, bullet.Y);
        }

        [TestMethod]
        public void TestMoveRight()
        {
            Bullet bullet = new Bullet
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Rotation = Math.PI*0.5,
                Speed = 1
            };

            bullet.GameTick();

            Assert.AreEqual(101, bullet.X);
            Assert.AreEqual(100, bullet.Y);
        }

        [TestMethod]
        public void TestHit()
        {
            Bullet bullet = new Bullet
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Rotation = 0,
                Speed = 1
            };

            Wall wall = new Wall
            {
                X = 100,
                Y = 151,
                Width = 50,
                Height = 50
            };

            _objectManager.AddObject(bullet);
            _objectManager.AddObject(wall);

            bullet.GameTick();

            Assert.IsTrue(_objectManager.GameObjects.Contains(bullet));

            bullet.GameTick();

            Assert.IsFalse(_objectManager.GameObjects.Contains(bullet));
        }

        [TestMethod]
        public void TestHitOwner()
        {
            Wall wall = new Wall
            {
                X = 100,
                Y = 151,
                Width = 50,
                Height = 50
            };

            Bullet bullet = new Bullet
            {
                X = 100,
                Y = 100,
                Width = 50,
                Height = 50,
                Rotation = 0,
                Speed = 1,
                Owner = wall
            };

            _objectManager.AddObject(bullet);
            _objectManager.AddObject(wall);

            bullet.GameTick();

            Assert.IsTrue(_objectManager.GameObjects.Contains(bullet));

            bullet.GameTick();

            Assert.IsTrue(_objectManager.GameObjects.Contains(bullet));
        }
    }
}