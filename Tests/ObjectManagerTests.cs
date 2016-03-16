using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game;

namespace Tests
{
    [TestClass]
    public class ObjectManagerTests
    {
        [TestInitialize]
        public void SetUp()
        {
            
        }

        [TestCleanup]
        public void TearDown()
        {
            ObjectManager.Instance.GameObjects.Clear();
        }

        [TestMethod]
        public void TestAdding()
        {
            GameObject testObject = new Wall();
            ObjectManager.Instance.AddObject(testObject);
            Assert.IsTrue(ObjectManager.Instance.GameObjects.Count == 1);
        }

        [TestMethod]
        public void TestDeleting()
        {
            GameObject testObject = new Wall();
            ObjectManager.Instance.AddObject(testObject);
            Assert.IsTrue(ObjectManager.Instance.GameObjects.Count == 1);
            ObjectManager.Instance.RemoveObject(testObject);
            Assert.IsTrue(ObjectManager.Instance.GameObjects.Count == 0);
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

            ObjectManager.Instance.AddObject(gameObject);
            ObjectManager.Instance.AddObject(intersectingGameObject);
            ObjectManager.Instance.AddObject(nonIntersectingGameObject);

            Assert.IsTrue(ObjectManager.Instance.Intersects(intersectingGameObject));
            Assert.IsFalse(ObjectManager.Instance.Intersects(nonIntersectingGameObject));

            Assert.IsTrue(ObjectManager.Instance.Intersects(nonIntersectingGameObject, new Rectangle(0, 0, 10, 10)));
            Assert.IsFalse(ObjectManager.Instance.Intersects(nonIntersectingGameObject, new Rectangle(0, 0, 5, 5), new List<GameObject> {gameObject}));
        }
    }
}
