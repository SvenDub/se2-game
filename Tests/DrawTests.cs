using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game;
using Ontwikkelopdracht_Game.Entity;

namespace Tests
{
    [TestClass]
    public class DrawTests
    {
        private readonly ObjectManager _objectManager = ObjectManager.Instance;
        private readonly World _world = World.Instance;

        private Bitmap _bitmap;

        [TestInitialize]
        public void SetUp()
        {
            _bitmap = new Bitmap(1000, 1000);
            Graphics graphics = Graphics.FromImage(_bitmap);
            graphics.Clear(Color.White);

            Wall wall = new Wall
            {
                X = 1,
                Y = 1,
                Width = 50,
                Height = 50
            };

            Bot bot = new Bot
            {
                X = 101,
                Y = 101,
                Width = 50,
                Height = 50
            };

            Player player = new Player
            {
                X = 201,
                Y = 201,
                Width = 50,
                Height = 50
            };

            Bullet bullet = new Bullet
            {
                X = 301,
                Y = 301,
                Width = 50,
                Height = 50
            };

            Event @event = new Event
            {
                X = 401,
                Y = 401,
                Width = 50,
                Height = 50
            };

            _world.Populate(new List<GameObject>
            {
                wall,
                bot,
                player,
                bullet,
                @event
            });

            _world.Draw(graphics);
        }

        [TestCleanup]
        public void TearDown()
        {
            _objectManager.GameObjects.Clear();
        }

        [TestMethod]
        public void TestWall()
        {
            Assert.AreEqual(Color.FromArgb(255, 255, 255, 255), _bitmap.GetPixel(51, 51));
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), _bitmap.GetPixel(1, 1));
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), _bitmap.GetPixel(50, 50));
        }

        [TestMethod]
        public void TestBot()
        {
            Assert.AreEqual(Color.FromArgb(255, 255, 255, 255), _bitmap.GetPixel(151, 151));
            Assert.AreEqual(Color.FromArgb(255, 255, 165, 0), _bitmap.GetPixel(101, 101));
            Assert.AreEqual(Color.FromArgb(255, 255, 165, 0), _bitmap.GetPixel(150, 150));
        }

        [TestMethod]
        public void TestPlayer()
        {
            Assert.AreEqual(Color.FromArgb(255, 255, 255, 255), _bitmap.GetPixel(251, 251));
            Assert.AreEqual(Color.FromArgb(255, 0, 0, 255), _bitmap.GetPixel(201, 201));
            Assert.AreEqual(Color.FromArgb(255, 0, 0, 255), _bitmap.GetPixel(250, 250));
        }

        [TestMethod]
        public void TestBullet()
        {
            Assert.AreEqual(Color.FromArgb(255, 255, 255, 255), _bitmap.GetPixel(351, 351));
            Assert.AreEqual(Color.FromArgb(255, 0, 0, 0), _bitmap.GetPixel(310, 310));
            Assert.AreEqual(Color.FromArgb(255, 0, 0, 0), _bitmap.GetPixel(340, 340));
        }

        [TestMethod]
        public void TestEvent()
        {
            Assert.AreEqual(Color.FromArgb(255, 255, 255, 255), _bitmap.GetPixel(451, 451));
            Assert.AreEqual(Color.FromArgb(255, 0, 128, 0), _bitmap.GetPixel(401, 401));
            Assert.AreEqual(Color.FromArgb(255, 0, 128, 0), _bitmap.GetPixel(450, 450));
        }
    }
}
