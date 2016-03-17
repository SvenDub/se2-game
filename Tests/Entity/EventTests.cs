using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht_Game;
using Ontwikkelopdracht_Game.Entity;

namespace Tests.Entity
{
    [TestClass]
    public class GameTickTests
    {
        private readonly ObjectManager _objectManager = ObjectManager.Instance;
        private readonly World _world = World.Instance;

        private bool _eventFired = false;
        private bool _won = false;

        [TestInitialize]
        public void SetUp()
        {
            
        }

        private void _world_GameEnded(object sender, GameEndedArgs args)
        {
            _eventFired = true;
            _won = true;
        }

        [TestCleanup]
        public void TearDown()
        {
            _objectManager.GameObjects.Clear();
            _eventFired = false;
            _won = false;
            _world.GameEnded -= _world_GameEnded;
        }

        [TestMethod]
        public void TestEventFired()
        {
            Event @event = new Event
            {
                Action = new Action<GameObject, GameObject>(Target),
                X = 0,
                Y = 0,
                Width = 50,
                Height = 50
            };

            Wall wall = new Wall
            {
                X = 0,
                Y = 0,
                Width = 50,
                Height = 50
            };

            _objectManager.AddObject(wall);

            @event.GameTick();

            Assert.IsTrue(_eventFired);
        }

        private void Target(GameObject gameObject, GameObject o)
        {
            _eventFired = true;
        }

        [TestMethod]
        public void TestDealDamage()
        {
            Event @event = new Event
            {
                X = 0,
                Y = 0,
                Width = 50,
                Height = 50,
                MaxHealth = 1,
                Health = 1
            };

            _objectManager.AddObject(@event);

            @event.DealDamage(new Wall(), 100);

            Assert.IsTrue(_objectManager.GameObjects.Contains(@event));
        }

        [TestMethod]
        public void TestWin()
        {
            _world.GameEnded += _world_GameEnded;

            Event @event = new Event
            {
                Action = GameEvent.Win,
                X = 0,
                Y = 0,
                Width = 50,
                Height = 50
            };

            Player player = new Player
            {
                X = 0,
                Y = 0,
                Width = 50,
                Height = 50
            };

            _objectManager.AddObject(player);

            @event.GameTick();

            Assert.IsTrue(_eventFired);
            Assert.IsTrue(_won);
        }
    }
}
