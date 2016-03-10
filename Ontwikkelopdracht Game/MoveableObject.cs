using System;
using System.Drawing;

namespace Ontwikkelopdracht_Game
{
    public abstract class MoveableObject : GameObject
    {
        public void Move(int amount)
        {
            double dx = Math.Sin(Rotation)*amount;
            double dy = Math.Cos(Rotation)*amount;

            Move(dx, dy);
        }

        public void Move(double dx, double dy)
        {
            if (CanMove(dx, dy))
            {
                X += dx;
                Y += dy;
            }

            Rotation = Math.Atan2(dy, dx);
        }

        public void Rotate(double amount)
        {
            Rotation += amount;
            Rotation %= 2*Math.PI;
        }

        protected virtual bool CanMove(double dx, double dy)
        {
            Rectangle newRectangle = Rect;
            newRectangle.X += (int) dx;
            newRectangle.Y += (int) dy;
            return !ObjectManager.Instance.Intersects(this, newRectangle);
        }
    }
}