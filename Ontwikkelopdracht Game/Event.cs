using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ontwikkelopdracht_Game
{
    public class Event : GameObject
    {
        public Action<GameObject, GameObject> Action { get; set; }

        public override void GameTick()
        {
            if (ObjectManager.Instance.Intersects(this))
            {
                Console.WriteLine("Intersecting");
                List<GameObject> intersectedObjects = ObjectManager.Instance.IntersectedObjects(this);
                Action.Invoke(this, intersectedObjects[0]);
            }
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Green, Rect);
        }

        public override void DealDamage(GameObject source, double damage)
        {
        }
    }

    public struct GameEvent
    {
        public static readonly Action<GameObject, GameObject> Win = (source, target) =>
        {
            if (target is Player)
            {
                World.Instance.End(true);
                source.Destroy();
            }
        };
    }
}