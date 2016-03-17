using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game;
using Ontwikkelopdracht_Game.Entity;

namespace Tests
{
    [TestClass]
    public class WorldTests
    {
        private readonly World _world = World.Instance;
        private readonly ObjectManager _objectManager = ObjectManager.Instance;

        private bool _gameEnded = false;
        private bool _gameWon = false;

        [TestInitialize]
        public void SetUp()
        {

        }

        [TestCleanup]
        public void TearDown()
        {
            _objectManager.GameObjects.Clear();
            _gameEnded = false;
            _gameWon = false;
        }

        [TestMethod]
        public void TestPopulate()
        {
            GameObject object1 = new Wall();
            GameObject object2 = new Wall();

            _world.Populate(new List<GameObject> {object1, object2});

            Assert.AreEqual(2, _objectManager.GameObjects.Count);
        }

        [TestMethod]
        public void TestCanvas()
        {
            PictureBox imgCanvas = new PictureBox {SizeMode = PictureBoxSizeMode.AutoSize};

            _world.ImgCanvas = imgCanvas;

            Assert.AreEqual(PictureBoxSizeMode.StretchImage, imgCanvas.SizeMode);
            Assert.AreEqual(imgCanvas, _world.ImgCanvas);
        }

        [TestMethod]
        public void TestEnd()
        {
            _world.GameEnded += _world_GameEnded;

            _world.End(true);

            Assert.IsFalse(_world.Running);
            Assert.IsTrue(_gameEnded);
            Assert.IsTrue(_gameWon);
        }

        private void _world_GameEnded(object sender, GameEndedArgs args)
        {
            _gameEnded = true;
            _gameWon = args.Won;
        }
    }
}
