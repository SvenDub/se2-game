using System;
using System.Collections.Generic;
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

            // TODO TEMP
            for (int x = 0; x < SearchWidth; x++)
            {
                for (int y = 0; y < SearchHeight; y++)
                {
                    g.DrawEllipse(new Pen(Color.FromArgb((int) (grid[x,y]/((float) SearchWidth)*255), Color.Black)), x * SearchAccuracy, y * SearchAccuracy, SearchAccuracy, SearchAccuracy);
                }
            }
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

        private List<Point> shortestPath = new List<Point>();
        private int shortestPathLength = SearchWidth;
        private int targetX;
        private int targetY;

        private int[,] grid = new int[SearchWidth, SearchHeight];
        private int[,] ignoreGrid = new int[SearchWidth, SearchHeight];

        const int SearchAccuracy = 25;

        const int SearchHeight = World.Height/SearchAccuracy;
        const int SearchWidth = World.Width/SearchAccuracy;

        private void CreatePath(double targetX, double targetY)
        {
            shortestPath = new List<Point>();
            shortestPathLength = SearchWidth;
            this.targetX = (int) targetX/SearchAccuracy;
            this.targetY = (int) targetY/SearchAccuracy;
            grid = new int[SearchWidth, SearchHeight];
            ignoreGrid = new int[SearchWidth, SearchHeight];

            for (int x = 0; x < SearchWidth; x++)
            {
                for (int y = 0; y < SearchHeight; y++)
                {
                    grid[x, y] = SearchWidth;
                    if (ObjectManager.Instance.Intersects(this, new Rectangle(x*SearchAccuracy, y*SearchAccuracy, SearchAccuracy, SearchAccuracy)))
                    {
                        ignoreGrid[x, y] = 1;
                    }
                }
            }

            Lee(0, (int) X/SearchAccuracy, (int) Y/SearchAccuracy, new List<Point>());
            
            /*Point prevPoint = new Point((int) (X/SearchAccuracy), (int) (Y/SearchAccuracy));
            foreach (Point point in shortestPath)
            {
                _path.AddLine(prevPoint.X*SearchAccuracy, prevPoint.Y*SearchAccuracy, point.X*SearchAccuracy, point.Y*SearchAccuracy);
                prevPoint = point;
            }*/

            if (shortestPath.Count > 0)
            {
                List<Point> path = new List<Point>();
                shortestPath.ForEach(point =>
                {
                    point.X = point.X*SearchAccuracy;
                    point.Y = point.Y*SearchAccuracy;
                    path.Add(point);
                });
                _path.AddCurve(path.ToArray());
            }
        }

        private void Lee(int k, int x, int y, List<Point> path)
        {
            path.Add(new Point(x, y));
            if (shortestPathLength > k && x >= targetX - 1 && x <= targetX + 1 && y >= targetY - 1 && y <= targetY + 1)
            {
                shortestPath = path;
                shortestPathLength = k;
            }

            if (x + 1 < SearchWidth && ignoreGrid[x + 1, y] != 1)
            {
                // E
                if (grid[x + 1, y] > k + 1)
                {
                    grid[x + 1, y] = k + 1;
                    Lee(k + 1, x + 1, y, new List<Point>(path));
                }
            }

            if (x - 1 > 0 && ignoreGrid[x - 1, y] != 1)
            {
                // W
                if (grid[x - 1, y] > k + 1)
                {
                    grid[x - 1, y] = k + 1;
                    Lee(k + 1, x - 1, y, new List<Point>(path));
                }
            }

            if (y + 1 < SearchHeight && ignoreGrid[x, y + 1] != 1)
            {
                // S
                if (grid[x, y + 1] > k + 1)
                {
                    grid[x, y + 1] = k + 1;
                    Lee(k + 1, x, y + 1, new List<Point>(path));
                }
            }


            if (y - 1 > 0 && ignoreGrid[x, y - 1] != 1)
            {
                // N
                if (grid[x, y - 1] > k + 1)
                {
                    grid[x, y - 1] = k + 1;
                    Lee(k + 1, x, y - 1, new List<Point>(path));
                }
            }

            if (x - 1 < SearchWidth && y + 1 < SearchHeight && ignoreGrid[x - 1, y + 1] != 1)
            {
                // SW
                if (grid[x - 1, y + 1] > k + 1)
                {
                    grid[x - 1, y + 1] = k + 1;
                    Lee(k + 1, x - 1, y + 1, new List<Point>(path));
                }
            }

            if (x - 1 < SearchWidth && y - 1 < SearchHeight && ignoreGrid[x - 1, y - 1] != 1)
            {
                // NW
                if (grid[x - 1, y - 1] > k + 1)
                {
                    grid[x - 1, y - 1] = k + 1;
                    Lee(k + 1, x - 1, y - 1, new List<Point>(path));
                }
            }

            if (x + 1 < SearchWidth && y + 1 < SearchHeight && ignoreGrid[x + 1, y + 1] != 1)
            {
                // SE
                if (grid[x + 1, y + 1] > k + 1)
                {
                    grid[x + 1, y + 1] = k + 1;
                    Lee(k + 1, x + 1, y + 1, new List<Point>(path));
                }
            }

            if (x + 1 < SearchWidth && y - 1 < SearchHeight && ignoreGrid[x + 1, y - 1] != 1)
            {
                // NE
                if (grid[x + 1, y - 1] > k + 1)
                {
                    grid[x + 1, y - 1] = k + 1;
                    Lee(k + 1, x + 1, y - 1, new List<Point>(path));
                }
            }
        }
    }
}