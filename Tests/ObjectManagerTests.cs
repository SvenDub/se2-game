using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game;
using Ontwikkelopdracht_Game.Entity;

namespace Tests
{
    [TestClass]
    public class ObjectManagerTests
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
        public void TestAdding()
        {
            GameObject testObject = new Wall();
            _objectManager.AddObject(testObject);
            Assert.AreEqual(1, _objectManager.GameObjects.Count);
        }

        [TestMethod]
        public void TestDeleting()
        {
            GameObject testObject = new Wall();
            _objectManager.AddObject(testObject);
            Assert.AreEqual(1, _objectManager.GameObjects.Count);
            _objectManager.RemoveObject(testObject);
            Assert.AreEqual(0, _objectManager.GameObjects.Count);
        }

        [TestMethod]
        public void TestIntersecting()
        {
            GameObject gameObject = new Wall
            {
                X = 0,
                Y = 0,
                Width = 10,
                Height = 10
            };

            GameObject intersectingGameObject = new Wall
            {
                X = 0,
                Y = 5,
                Width = 10,
                Height = 10
            };

            GameObject nonIntersectingGameObject = new Wall
            {
                X = 10,
                Y = 0,
                Width = 10,
                Height = 10
            };

            _objectManager.AddObject(gameObject);
            _objectManager.AddObject(intersectingGameObject);
            _objectManager.AddObject(nonIntersectingGameObject);

            Assert.IsTrue(_objectManager.Intersects(intersectingGameObject));
            Assert.IsFalse(_objectManager.Intersects(nonIntersectingGameObject));

            Assert.IsTrue(_objectManager.Intersects(nonIntersectingGameObject, new Rectangle(0, 0, 10, 10)));
            Assert.IsFalse(_objectManager.Intersects(intersectingGameObject, new List<GameObject> { gameObject }));
            Assert.IsFalse(_objectManager.Intersects(nonIntersectingGameObject, new Rectangle(0, 0, 5, 5), new List<GameObject> {gameObject}));
        }

        [TestMethod]
        public void TestIntersectedObjects()
        {
            GameObject gameObject = new Wall
            {
                X = 0,
                Y = 0,
                Width = 10,
                Height = 10
            };

            GameObject intersectingGameObject = new Wall
            {
                X = 0,
                Y = 5,
                Width = 10,
                Height = 10
            };

            GameObject nonIntersectingGameObject = new Wall
            {
                X = 10,
                Y = 0,
                Width = 10,
                Height = 10
            };

            _objectManager.AddObject(gameObject);
            _objectManager.AddObject(intersectingGameObject);
            _objectManager.AddObject(nonIntersectingGameObject);

            List<GameObject> intersectedObjects = _objectManager.IntersectedObjects(gameObject);
            Assert.IsTrue(intersectedObjects.Contains(intersectingGameObject));
            Assert.IsFalse(intersectedObjects.Contains(nonIntersectingGameObject));

            intersectedObjects = _objectManager.IntersectedObjects(nonIntersectingGameObject, new Rectangle(0, 0, 10, 10));
            Assert.IsTrue(intersectedObjects.Contains(gameObject));

            intersectedObjects = _objectManager.IntersectedObjects(intersectingGameObject, new List<GameObject> { gameObject });
            Assert.IsFalse(intersectedObjects.Contains(gameObject));

            intersectedObjects = _objectManager.IntersectedObjects(nonIntersectingGameObject, new Rectangle(0, 0, 5, 5), new List<GameObject> { gameObject });
            Assert.IsFalse(intersectedObjects.Contains(gameObject));
        }
    }
}
