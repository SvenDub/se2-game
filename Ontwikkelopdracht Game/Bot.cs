using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Ontwikkelopdracht_Game
{
    public class Bot : Character
    {
        private readonly GraphicsPath _path = new GraphicsPath();

        public override void GameTick()
        {
            double minDistance = ObjectManager.Instance.GameObjects.OfType<Player>()
                .Min(player => DistanceTo(player));
            Player closestPlayer = ObjectManager.Instance.GameObjects.OfType<Player>()
                .FirstOrDefault(player => Math.Abs(DistanceTo(player) - minDistance) < 0.001);

            _path.Reset();

            if (closestPlayer != null)
            {
                CreatePath(closestPlayer.X, closestPlayer.Y);

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
            g.DrawPath(new Pen(Color.Aqua, Width), _path);
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

        private int[,] grid;
        const int SearchHeight = World.Height;
        const int SearchWidth = World.Width;

        private void CreatePath(double targetX, double targetY)
        {
            grid = new int[SearchWidth, SearchHeight];
            for (int x = 0; x < SearchWidth; x++)
            {
                for (int y = 0; y < SearchHeight; y++)
                {
                    grid[x, y] = SearchWidth;
                }
            }
            Lee(0, (int) X, (int) Y);
            Console.WriteLine("Shortest route: " + grid[(int) targetX, (int) targetY]);
        }

        private void Lee(int k, int x, int y)
        {
            if (x + 1 < SearchWidth)
            {
                // Go down...
                if (grid[x + 1, y] > k + 1)
                {
                    grid[x + 1, y] = k + 1;
                    Lee(k + 1, x + 1, y);
                }
            }

            // First check for boundaries...
            if (x - 1 > 0)
            {
                // Go up...
                if (grid[x - 1, y] > k + 1)
                {
                    grid[x - 1, y] = k + 1;
                    Lee(k + 1, x - 1, y);
                }
            }

            // First check for boundaries...
            if (y + 1 < SearchHeight)
            {
                // Go right...
                if (grid[x, y + 1] > k + 1)
                {
                    grid[x, y + 1] = k + 1;
                    Lee(k + 1, x, y + 1);
                }
            }

            // First check for boundaries...
            if (y - 1 > 0)
            {
                // Go left...
                if (grid[x, y - 1] > k + 1)
                {
                    grid[x, y - 1] = k + 1;
                    Lee(k + 1, x, y - 1);
                }
            }
        }
    }
}