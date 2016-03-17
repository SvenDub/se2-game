using System.Drawing;

namespace Ontwikkelopdracht_Game.Entity
{
    public class Wall : GameObject
    {
        public override void GameTick()
        {
            
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, Rect);
        }
    }
}
