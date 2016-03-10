using System.Collections.Generic;
using System.Drawing;

namespace Ontwikkelopdracht_Game
{
    public class Event : GameObject
    {
        public override void GameTick()
        {
            if (ObjectManager.Instance.Intersects(this))
            {
                List<GameObject> intersectedObjects = ObjectManager.Instance.IntersectedObjects(this);
                // TODO Handle event
                Destroy();
            }
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Green, Rect);
        }
    }
}