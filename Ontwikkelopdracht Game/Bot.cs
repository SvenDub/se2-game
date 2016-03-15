using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ontwikkelopdracht_Game
{
    public class Bot : Character
    {
        private readonly GraphicsPath _path = new GraphicsPath();

        private object _lock = new object();

        public override void GameTick()
        {
            double minDistance = ObjectManager.Instance.GameObjects.OfType<Player>()
                .Min(player => DistanceTo(player));
            Player closestPlayer = ObjectManager.Instance.GameObjects.OfType<Player>()
                .FirstOrDefault(player => Math.Abs(DistanceTo(player) - minDistance) < 0.001);

            _path.Reset();

            if (closestPlayer != null)
            {
                lock (_lock)
                {
                    if (shortestPath.Count > 1)
                    {
                        List<Point> path = new List<Point>();
                        shortestPath.ForEach(point =>
                        {
                            point.X = point.X*SearchAccuracy;
                            point.Y = point.Y*SearchAccuracy;
                            path.Add(point);
                        });

                        if (Math.Abs(path[0].X - X) < 50 && Math.Abs(path[0].Y - Y) < 50)
                        {
                            Rotation = Math.Atan2(path[1].X - (X + Width/2), path[1].Y - (Y + Width/2));
                        }
                        else
                        {
                            Rotation = Math.Atan2(path[0].X - (X + Width/2), path[0].Y - (Y + Width/2));
                        }
                    }
                }
                Move(2);

                CreatePath(closestPlayer);

                if (Cooldown <= 0)
                {
                    Fire(closestPlayer.X, closestPlayer.Y);
                    Cooldown = BaseCooldown;
                }
            }

                Cooldown--;
        }

        private double DistanceTo(Player player)
        {
            return Math.Pow(X - player.X, 2) + Math.Pow(Y - player.Y, 2);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Orange, Rect);

            lock (_lock)
            {
                if (shortestPath.Count > 1)
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

            g.DrawPath(new Pen(Color.Aqua, 10), _path);

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

        public void Fire(double x, double y)
        {
            double rotation = Math.Atan2(x - X, y - Y);

            ObjectManager.Instance.AddObject(new Bullet
            {
                Damage = 25,
                Owner = this,
                Rotation = rotation,
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

        const int SearchAccuracy = 49;

        const int SearchHeight = World.Height/SearchAccuracy;
        const int SearchWidth = World.Width/SearchAccuracy;

        private void CreatePath(GameObject target)
        {
            lock (_lock)
            {
                shortestPath = new List<Point>();
                shortestPathLength = SearchWidth;
            }
            targetX = (int) target.X/SearchAccuracy;
            targetY = (int) target.Y/SearchAccuracy;
            grid = new int[SearchWidth, SearchHeight];
            ignoreGrid = new int[SearchWidth, SearchHeight];

            for (int x = 0; x < SearchWidth; x++)
            {
                for (int y = 0; y < SearchHeight; y++)
                {
                    grid[x, y] = SearchWidth;
                    Rectangle rectangle = new Rectangle(x*SearchAccuracy, y*SearchAccuracy, SearchAccuracy,
                        SearchAccuracy);
                    if (ObjectManager.Instance.Intersects(this, rectangle,
                        ObjectManager.Instance.GameObjects.FindAll(o => o is Bullet && ((Bullet) o).Owner == this)))
                    {
                        ignoreGrid[x, y] = 1;
                        if (ObjectManager.Instance.IntersectedObjects(this, rectangle).Contains(target))
                        {
                            ignoreGrid[x, y] = 2;
                        }
                    }
                }
            }

            Task.Factory.StartNew(() =>
            {
                Lee(0, (int) ((X + Width/2 + 1)/SearchAccuracy),
                    (int) ((Y + Height/2 + 1)/SearchAccuracy), new List<Point>());
            });
        }

        private void Lee(int k, int x, int y, List<Point> path)
        {
            path.Add(new Point(x, y));
            lock (_lock)
            {
                if (shortestPathLength > k && ignoreGrid[x, y] == 2)
                {
                    shortestPath = path;
                    shortestPathLength = k;
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

            if (x + 1 < SearchWidth && ignoreGrid[x + 1, y] != 1)
            {
                // E
                if (grid[x + 1, y] > k + 1)
                {
                    grid[x + 1, y] = k + 1;
                    Lee(k + 1, x + 1, y, new List<Point>(path));
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
            
            if (x - 1 > 0 && ignoreGrid[x - 1, y] != 1)
            {
                // W
                if (grid[x - 1, y] > k + 1)
                {
                    grid[x - 1, y] = k + 1;
                    Lee(k + 1, x - 1, y, new List<Point>(path));
                }
            }
        }
    }
}