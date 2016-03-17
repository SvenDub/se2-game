using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game.Entity;

namespace Tests
{
    [TestClass]
    public class DrawTests
    {
        [TestMethod]
        public void TestWall()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            Wall wall = new Wall
            {
                X = 1,
                Y = 1,
                Width = 50,
                Height = 50
            };

            wall.Draw(graphics);

            Assert.AreEqual(Color.FromArgb(255, 255, 255, 255), bitmap.GetPixel(51, 51));
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), bitmap.GetPixel(1, 1));
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), bitmap.GetPixel(50, 50));
        }

        [TestMethod]
        public void TestBot()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            Bot bot = new Bot
            {
                X = 1,
                Y = 1,
                Width = 50,
                Height = 50
            };

            bot.Draw(graphics);

            Assert.AreEqual(Color.FromArgb(255, 255, 255, 255), bitmap.GetPixel(51, 51));
            Assert.AreEqual(Color.FromArgb(255, 255, 165, 0), bitmap.GetPixel(1, 1));
            Assert.AreEqual(Color.FromArgb(255, 255, 165, 0), bitmap.GetPixel(50, 50));
        }

        [TestMethod]
        public void TestPlayer()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            Player player = new Player
            {
                X = 1,
                Y = 1,
                Width = 50,
                Height = 50
            };

            player.Draw(graphics);

            Assert.AreEqual(Color.FromArgb(255, 255, 255, 255), bitmap.GetPixel(51, 51));
            Assert.AreEqual(Color.FromArgb(255, 0, 0, 255), bitmap.GetPixel(1, 1));
            Assert.AreEqual(Color.FromArgb(255, 0, 0, 255), bitmap.GetPixel(50, 50));
        }

        [TestMethod]
        public void TestBullet()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            Bullet bullet = new Bullet
            {
                X = 1,
                Y = 1,
                Width = 50,
                Height = 50
            };

            bullet.Draw(graphics);

            Assert.AreEqual(Color.FromArgb(255, 255, 255, 255), bitmap.GetPixel(51, 51));
            Assert.AreEqual(Color.FromArgb(255, 0, 0, 0), bitmap.GetPixel(10, 10));
            Assert.AreEqual(Color.FromArgb(255, 0, 0, 0), bitmap.GetPixel(40, 40));
        }

        [TestMethod]
        public void TestEvent()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            Event @event = new Event
            {
                X = 1,
                Y = 1,
                Width = 50,
                Height = 50
            };

            @event.Draw(graphics);

            Assert.AreEqual(Color.FromArgb(255, 255, 255, 255), bitmap.GetPixel(51, 51));
            Assert.AreEqual(Color.FromArgb(255, 0, 128, 0), bitmap.GetPixel(1, 1));
            Assert.AreEqual(Color.FromArgb(255, 0, 128, 0), bitmap.GetPixel(50, 50));
        }
    }
}
