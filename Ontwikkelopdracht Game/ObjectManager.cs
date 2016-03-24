using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using Ontwikkelopdracht_Game.Entity;

namespace Ontwikkelopdracht_Game
{
    public class ObjectManager
    {
        public static readonly ObjectManager Instance = new ObjectManager();

        private ObjectManager()
        {
        }

        public ObservableCollection<GameObject> GameObjects { get; } = new ObservableCollection<GameObject>();

        public void GameTick()
        {
            GameObjects.ToList().ForEach(o => o.GameTick());
        }

        public void Draw(Graphics g)
        {
            GameObjects.OfType<IDrawable>().ToList().ForEach(o => o.Draw(g));
        }

        public void AddObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void RemoveObject(GameObject gameObject)
        {
            if (GameObjects.Contains(gameObject))
            {
                GameObjects.Remove(gameObject);
            }
        }

        public bool Intersects(GameObject source)
        {
            return Intersects(source, source.Rect);
        }

        public bool Intersects(GameObject source, Rectangle rect)
        {
            return Intersects(source, rect, new List<GameObject>());
        }


        public bool Intersects(GameObject source, List<GameObject> excluded)
        {
            return Intersects(source, source.Rect, excluded);
        }

        public bool Intersects(GameObject source, Rectangle rect, List<GameObject> excluded)
        {
            return
                GameObjects.Any(
                    gameObject =>
                        !gameObject.Equals(source)
                        && !(gameObject is Event)
                        && !excluded.Contains(gameObject)
                        && gameObject.Intersects(rect));
        }

        public List<GameObject> IntersectedObjects(GameObject source)
        {
            return IntersectedObjects(source, source.Rect);
        }

        public List<GameObject> IntersectedObjects(GameObject source, Rectangle rect)
        {
            return IntersectedObjects(source, rect, new List<GameObject>());
        }

        public List<GameObject> IntersectedObjects(GameObject source, List<GameObject> excluded)
        {
            return IntersectedObjects(source, source.Rect, excluded);
        }

        public List<GameObject> IntersectedObjects(GameObject source, Rectangle rect, List<GameObject> excluded)
        {
            return
                GameObjects.Where(
                    gameObject =>
                        !gameObject.Equals(source)
                        && !(gameObject is Event)
                        && !excluded.Contains(gameObject)
                        && gameObject.Intersects(rect)).ToList();
        }
    }
}