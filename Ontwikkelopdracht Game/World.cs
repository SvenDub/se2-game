using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ontwikkelopdracht_Game
{
    public class World
    {
        public const int Width = 1366;
        public const int Height = 768;

        private readonly Bitmap _bitmap;
        private readonly Timer _drawTimer;
        private readonly Timer _gameTimer;
        private readonly Graphics _graphics;

        private readonly ObjectManager _objectManager = ObjectManager.Instance;

        public static readonly World Instance = new World();

        private World()
        {
            _bitmap = new Bitmap(Width, Height);
            _graphics = Graphics.FromImage(_bitmap);

            _gameTimer = new Timer { Interval = (int)(1000d / 60) };
            _gameTimer.Tick += _gameTimer_Tick;
            _gameTimer.Start();

            _drawTimer = new Timer { Interval = (int)(1000d / 60) };
            _drawTimer.Tick += _drawTimer_Tick;
            _drawTimer.Start();
        }

        private PictureBox imgCanvas;

        public PictureBox ImgCanvas
        {
            get { return imgCanvas; }
            set
            {
                imgCanvas = value;
                imgCanvas.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void _gameTimer_Tick(object sender, EventArgs e)
        {
            GameTick();
            //Draw(_graphics);
        }

        private void _drawTimer_Tick(object sender, EventArgs e)
        {
            if (imgCanvas != null)
            {
                Draw(_graphics);
                ImgCanvas.Image = _bitmap;
            }
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

        public void End(bool won)
        {
            _gameTimer.Stop();

            MessageBox.Show(won ? "Won" : "Lost");
        }

        public void Populate(List<GameObject> gameObjects)
        {
            gameObjects.ForEach(_objectManager.AddObject);
        }
    }
}