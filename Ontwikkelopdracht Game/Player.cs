using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace Ontwikkelopdracht_Game
{
    public class Player : Character
    {
        public override void GameTick()
        {
            int dx = 0;
            int dy = 0;
            
            if (Keyboard.IsKeyDown(Key.W))
            {
                dy = -3;
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                dy = 3;
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                dx = -3;
            }
            else if (Keyboard.IsKeyDown(Key.D))
            {
                dx = 3;
            }

            if (dx != 0 || dy != 0)
            {
                Move(dx, dy);
            }
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Blue, Rect);
        }

        public override void Fire()
        {
            ObjectManager.Instance.AddObject(new Bullet
            {
                Damage = 25,
                Owner = this,
                Rotation = Rotation,
                X = X,
                Y = Y,
                Speed = 10,
                Width = 10,
                Height = 10
            });
        }

        public override void DealDamage(GameObject source, double damage)
        {
            base.DealDamage(source, damage);

            if (Health <= 0)
            {
                World.Instance.End(false);
            }
        }
    }
}