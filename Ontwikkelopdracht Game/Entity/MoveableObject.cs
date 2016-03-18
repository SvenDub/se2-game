using System;
using System.Drawing;

namespace Ontwikkelopdracht_Game.Entity
{
    public abstract class MoveableObject : GameObject
    {
        public void Move(int amount)
        {
            double dx = Math.Sin(Rotation)*amount;
            double dy = Math.Cos(Rotation)*amount;

            double rotation = Rotation;

            Move(dx, dy);

            Rotation = rotation;
        }

        public void Move(double dx, double dy)
        {
            if (CanMove(dx, 0))
            {
                X += dx;
            }

            if (CanMove(0, dy))
            {
                Y += dy;
            }

            Rotation = Math.Atan2(dx, dy);
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