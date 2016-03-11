using System.Drawing;

namespace Ontwikkelopdracht_Game
{
    public abstract class GameObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Width { get; set; } = 50;
        public int Height { get; set; } = 50;
        public Rectangle Rect => new Rectangle((int) X, (int) Y, Width, Height);
        public double Rotation { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }

        public bool Intersects(Rectangle rectangle)
        {
            return Rect.IntersectsWith(rectangle);
        }

        public abstract void GameTick();
        public abstract void Draw(Graphics g);

        public virtual void DealDamage(GameObject source, double damage)
        {
            Health -= damage;
        }

        public void Destroy()
        {
            ObjectManager.Instance.RemoveObject(this);
        }
    }
}