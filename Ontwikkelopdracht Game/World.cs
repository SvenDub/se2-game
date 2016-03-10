using System.Drawing;

namespace Ontwikkelopdracht_Game
{
    public class World
    {
        private readonly ObjectManager _objectManager = ObjectManager.Instance;
        
        public void GameTick()
        {
            _objectManager.GameTick();
        }

        public void Draw(Graphics g)
        {
            g.Clear(Color.White);
            _objectManager.Draw(g);
        }
    }
}
