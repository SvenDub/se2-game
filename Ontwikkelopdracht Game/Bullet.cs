using System.Collections.Generic;
using System.Drawing;

namespace Ontwikkelopdracht_Game
{
    public class Bullet : MoveableObject
    {
        public int Speed { get; set; }
        public double Damage { get; set; }
        public GameObject Owner { get; set; }

        public override void GameTick()
        {
            Move(Speed);
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Black, Rect);
        }

        protected override bool CanMove(double dx, double dy)
        {
            List<GameObject> excluded = new List<GameObject> {Owner};

            Rectangle newRectangle = Rect;
            newRectangle.X += (int) dx;
            newRectangle.Y -= (int) dy;

            if (ObjectManager.Instance.Intersects(this, newRectangle, excluded))
            {
                List<GameObject> intersected = ObjectManager.Instance
                    .IntersectedObjects(this, newRectangle, excluded);

                intersected[0].DealDamage(this, Damage);
                Destroy();

                return false;
            }

            return true;
        }
    }
}