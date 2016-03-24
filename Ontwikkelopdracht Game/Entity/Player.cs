using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Input;

namespace Ontwikkelopdracht_Game.Entity
{
    public class Player : Character
    {
        private readonly InputController _input = InputController.Instance;
        private readonly List<ICarryable> _carryables = new List<ICarryable>();
        public int Strength { get; set; } = 50;
        public int UsedStrength => _carryables.Sum(carryable => carryable.Weight);

        private int DropCooldown { get; set; } = 0;
        private int BaseDropCooldown { get; set; } = 50;

        public override void GameTick()
        {
            int dx = 0;
            int dy = 0;
            
            if (_input.IsKeyDown(Key.W))
            {
                dy = -3;
            }
            else if (_input.IsKeyDown(Key.S))
            {
                dy = 3;
            }

            if (_input.IsKeyDown(Key.A))
            {
                dx = -3;
            }
            else if (_input.IsKeyDown(Key.D))
            {
                dx = 3;
            }

            if (_input.IsKeyDown(Key.Q))
            {
                if (DropCooldown <= 0)
                {
                    DropItem();
                    DropCooldown = BaseDropCooldown;
                }
            }

            if (dx != 0 || dy != 0)
            {
                Move(dx, dy);
            }

            if (_input.IsKeyDown(Key.Space))
            {
                if (Cooldown <= 0)
                {
                    Fire();
                    Cooldown = BaseCooldown;
                }
            }

            if (Cooldown > 0)
            {
                Cooldown--;
            }

            if (DropCooldown > 0)
            {
                DropCooldown--;
            }

            List<GameObject> intersectedObjects = ObjectManager.Instance.IntersectedObjects(this);
            List<ICarryable> intersectedCarryables = intersectedObjects.OfType<ICarryable>().ToList();
                
            intersectedCarryables.ForEach(carryable =>
            {
                if (AddItem(carryable))
                {
                    carryable.PickUp();
                }
            });
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Blue, Rect);
            List<IDrawable> list = _carryables.OfType<IDrawable>().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                g.FillRectangle(Brushes.LightSkyBlue, (float) (X + 15 * i), (float) (Y + Width + 5), 10, 10);
            }
        }

        public override void Fire()
        {
            ObjectManager.Instance.AddObject(new Bullet
            {
                Damage = 25,
                Owner = this,
                Rotation = Rotation,
                X = X + Width/2-5,
                Y = Y + Height/2-5,
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

        public bool AddItem(ICarryable item)
        {
            if (UsedStrength + item.Weight <= Strength)
            {
                _carryables.Add(item);
                return true;
            }

            return false;
        }

        public void DropItem()
        {
            if (_carryables.Count > 0)
            {
                DropItem(_carryables.Last());
            }
        }

        public void DropItem(ICarryable item)
        {
            _carryables.Remove(item);
        }

        public IReadOnlyCollection<ICarryable> GetItems()
        {
            return _carryables.AsReadOnly();
        }
    }
}