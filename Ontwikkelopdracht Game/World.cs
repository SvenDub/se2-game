using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ontwikkelopdracht_Game
{
    public class World
    {
        public PictureBox ImgCanvas { get; set; }

        private readonly ObjectManager _objectManager = ObjectManager.Instance;

        private readonly Timer _gameTimer;
        private readonly Timer _drawTimer;

        private readonly Graphics _graphics;
        private readonly Bitmap _bitmap;

        public World(PictureBox imgCanvas)
        {
            ImgCanvas = imgCanvas;

            _bitmap = new Bitmap(ImgCanvas.Width, ImgCanvas.Height);
            _graphics = Graphics.FromImage(_bitmap);

            _gameTimer = new Timer { Interval = (int)(1000d / 60) };
            _gameTimer.Tick += _gameTimer_Tick;
            _gameTimer.Start();

            _drawTimer = new Timer { Interval = (int)(1000d / 60) };
            _drawTimer.Tick += _drawTimer_Tick;
            _drawTimer.Start();

            _objectManager.AddObject(new Player
            {
                X = 10,
                Y = 10,
                Width = 100,
                Height = 100
            });
        }

        private void _gameTimer_Tick(object sender, EventArgs e)
        {
            GameTick();
            Draw(_graphics);
        }

        private void _drawTimer_Tick(object sender, EventArgs e)
        {
            Draw(_graphics);
            ImgCanvas.Image = _bitmap;
        }

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
