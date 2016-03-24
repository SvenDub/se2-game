using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Ontwikkelopdracht_Game.Entity
{
    public class Stone : GameObject, ICarryable
    {
        public override void GameTick()
        {
            
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.LightSlateGray, Rect);
        }

        public int Weight => 14;

        public void PickUp()
        {
            Destroy();
        }
    }
}
