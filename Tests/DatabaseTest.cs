using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game;
using Ontwikkelopdracht_Game.Database;
using Ontwikkelopdracht_Game.Entity;
using Tests.Database.Memory;

namespace Tests
{
    [TestClass]
    public class DatabaseTest
    {
        private IRepository<List<GameObject>, string> _repository;

        [TestInitialize]
        public void SetUp()
        {
            Injector.Register(InMemoryDbInjector.Types);
            _repository = Injector.Resolve<IRepository<List<GameObject>, string>>();
            (_repository as MapRepository)?.Reset();
        }

        [TestCleanup]
        public void TearDown()
        {
            
        }

        [TestMethod]
        public void TestType()
        {
            Assert.IsInstanceOfType(_repository, typeof(MapRepository));
        }

        [TestMethod]
        public void TestList()
        {
            Assert.AreEqual(2, _repository.List().Count());
        }

        [TestMethod]
        public void TestDelete()
        {
            _repository.Delete("Test");
            Assert.AreEqual(1, _repository.List().Count());
            Assert.IsFalse(_repository.Exists("Test"));
        }

        [TestMethod]
        public void TestExists()
        {
            Assert.IsTrue(_repository.Exists("Test"));

            Assert.IsFalse(_repository.Exists("Test2"));
        }

        [TestMethod]
        public void TestFindOne()
        {
            foreach (GameObject gameObject in _repository.FindOne("Test"))
            {
                Assert.IsTrue(LevelPreset.Test.Exists(o => o.X == gameObject.X && o.Y == gameObject.Y && o.GetType() == gameObject.GetType()));
            }

            Exception ex = null;

            try
            {
                _repository.FindOne("Test2");
            }
            catch (Exception e)
            {
                ex = e;
            }

            Assert.IsInstanceOfType(ex, typeof(LevelLoadException));
        }

        [TestMethod]
        public void TestSave()
        {
            List<GameObject> level = new List<GameObject>
            {
                new Wall
                {
                    X = 10,
                    Y = 5
                },
                new Stone
                {
                    X = 50,
                    Y = 75
                }
            };

            _repository.Save(level, "InMem");

            Assert.IsTrue(_repository.Exists("InMem"));

            foreach (GameObject gameObject in _repository.FindOne("InMem"))
            {
                Assert.IsTrue(level.Exists(o => o.X == gameObject.X && o.Y == gameObject.Y && o.GetType() == gameObject.GetType()));
            }
        }
    }
}
