using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows;

namespace Ontwikkelopdracht_Game
{
    public class Bot : Character
    {
        public override void GameTick()
        {
            double minDistance = ObjectManager.Instance.GameObjects.OfType<Player>()
                .Min(player => DistanceTo(player));
            Player closestPlayer = ObjectManager.Instance.GameObjects.OfType<Player>()
                .FirstOrDefault(player => Math.Abs(DistanceTo(player) - minDistance) < 0.001);

            if (closestPlayer != null)
            {
                Rotation = Math.Atan2(closestPlayer.X - X, closestPlayer.Y - Y);
                Move(2);
            }

            if (Cooldown <= 0)
            {
                Fire();
                Cooldown = BaseCooldown;
            }
            else
            {
                Cooldown--;
            }
        }

        private double DistanceTo(Player player)
        {
            return Math.Pow(X - player.X, 2) + Math.Pow(Y - player.Y, 2);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Orange, Rect);
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
                Speed = 5,
                Width = 10,
                Height = 10
            });
        }

        public override void DealDamage(GameObject source, double damage)
        {
            base.DealDamage(source, damage);

            if (Health <= 0)
            {
                Destroy();
            }
        }
    }
}
