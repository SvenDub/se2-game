using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;

namespace Ontwikkelopdracht_Game
{
    public class Bot : Character
    {
        private const int SearchAccuracy = 49;

        private const int SearchHeight = World.Height/SearchAccuracy;
        private const int SearchWidth = World.Width/SearchAccuracy;

        private readonly object _lock = new object();
        private readonly GraphicsPath _path = new GraphicsPath();

        private int[,] _grid = new int[SearchWidth, SearchHeight];
        private int[,] _ignoreGrid = new int[SearchWidth, SearchHeight];

        private List<Point> _shortestPath = new List<Point>();
        private int _shortestPathLength = SearchWidth;

        public bool Tracking = false;

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
                    if (_shortestPath.Count > 1)
                    {
                        Point firstPoint = _shortestPath[0];
                        firstPoint.X *= SearchAccuracy;
                        firstPoint.Y *= SearchAccuracy;

                        Point secondPoint = _shortestPath[1];
                        secondPoint.X *= SearchAccuracy;
                        secondPoint.Y *= SearchAccuracy;

                        if (Math.Abs(firstPoint.X - X) < 50 && Math.Abs(firstPoint.Y - Y) < 50)
                        {
                            Rotation = Math.Atan2(secondPoint.X - (X + Width/2), secondPoint.Y - (Y + Width/2));
                        }
                        else
                        {
                            Rotation = Math.Atan2(firstPoint.X - (X + Width/2), firstPoint.Y - (Y + Width/2));
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

            if (Tracking)
            {
                lock (_lock)
                {
                    if (_shortestPath.Count > 1)
                    {
                        List<Point> path = new List<Point>();
                        _shortestPath.ForEach(point =>
                        {
                            point.X = point.X * SearchAccuracy;
                            point.Y = point.Y * SearchAccuracy;
                            path.Add(point);
                        });
                        _path.AddCurve(path.ToArray());
                    }
                }

                g.DrawPath(new Pen(Color.Aqua, 10), _path);

                for (int x = 0; x < SearchWidth; x++)
                {
                    for (int y = 0; y < SearchHeight; y++)
                    {
                        g.DrawEllipse(new Pen(Color.FromArgb((int) (_grid[x, y]/(float) SearchWidth*255), Color.Black)),
                            x*SearchAccuracy, y*SearchAccuracy, SearchAccuracy, SearchAccuracy);
                    }
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

        private void CreatePath(GameObject target)
        {
            lock (_lock)
            {
                _shortestPath = new List<Point>();
                _shortestPathLength = SearchWidth;
            }

            // Create grid
            _grid = new int[SearchWidth, SearchHeight];
            _ignoreGrid = new int[SearchWidth, SearchHeight];

            // Populate grid
            for (int x = 0; x < SearchWidth; x++)
            {
                for (int y = 0; y < SearchHeight; y++)
                {
                    _grid[x, y] = SearchWidth;
                    Rectangle rectangle = new Rectangle(x*SearchAccuracy, y*SearchAccuracy,
                        SearchAccuracy, SearchAccuracy);

                    if (ObjectManager.Instance.Intersects(this, rectangle,
                        ObjectManager.Instance.GameObjects.ToList().FindAll(o => o is Bullet && ((Bullet) o).Owner == this)))
                    {
                        _ignoreGrid[x, y] = 1;

                        if (ObjectManager.Instance.IntersectedObjects(this, rectangle).Contains(target))
                        {
                            _ignoreGrid[x, y] = 2;
                        }
                    }
                }
            }

            // Start search algorithm
            Task.Factory.StartNew(() =>
            {
                Lee(0, (int) ((X + Width/2 + 1)/SearchAccuracy),
                    (int) ((Y + Height/2 + 1)/SearchAccuracy), new List<Point>());
            });
        }

        private void Lee(int k, int x, int y, List<Point> path)
        {
            // Add current point to path
            path.Add(new Point(x, y));

            lock (_lock)
            {
                // Check if new shortest path detected
                if (_shortestPathLength > k && _ignoreGrid[x, y] == 2)
                {
                    _shortestPath = path;
                    _shortestPathLength = k;
                }
            }

            if (y - 1 > 0 && _ignoreGrid[x, y - 1] != 1)
            {
                // N
                if (_grid[x, y - 1] > k + 1)
                {
                    _grid[x, y - 1] = k + 1;
                    Lee(k + 1, x, y - 1, new List<Point>(path));
                }
            }

            if (x + 1 < SearchWidth && _ignoreGrid[x + 1, y] != 1)
            {
                // E
                if (_grid[x + 1, y] > k + 1)
                {
                    _grid[x + 1, y] = k + 1;
                    Lee(k + 1, x + 1, y, new List<Point>(path));
                }
            }

            if (y + 1 < SearchHeight && _ignoreGrid[x, y + 1] != 1)
            {
                // S
                if (_grid[x, y + 1] > k + 1)
                {
                    _grid[x, y + 1] = k + 1;
                    Lee(k + 1, x, y + 1, new List<Point>(path));
                }
            }

            if (x - 1 > 0 && _ignoreGrid[x - 1, y] != 1)
            {
                // W
                if (_grid[x - 1, y] > k + 1)
                {
                    _grid[x - 1, y] = k + 1;
                    Lee(k + 1, x - 1, y, new List<Point>(path));
                }
            }
        }
    }
}