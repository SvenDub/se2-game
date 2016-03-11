using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ontwikkelopdracht_Game
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
