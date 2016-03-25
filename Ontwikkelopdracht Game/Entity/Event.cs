using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace Ontwikkelopdracht_Game.Entity
{
    public class Event : GameObject
    {
        [JsonIgnore]
        public Action<GameObject, GameObject> Action { get; set; } = GameEvent.Win;

        public override void GameTick()
        {
            if (ObjectManager.Instance.Intersects(this))
            {
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
            }
        }; 
    }
}