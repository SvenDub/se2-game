using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Ontwikkelopdracht_Game
{
    public partial class Form1 : Form
    {
        private readonly World _world = new World();
        private readonly ObjectManager _objectManager = ObjectManager.Instance;

        private readonly Timer _gameTimer;
        private readonly Timer _drawTimer;

        private Graphics _graphics;
        private Bitmap _bitmap;

        public Form1()
        {
            InitializeComponent();

            _bitmap = new Bitmap(imgCanvas.Width, imgCanvas.Height);
            _graphics = Graphics.FromImage(_bitmap);

            _gameTimer = new Timer {Interval = (int) (1000d/60)};
            _gameTimer.Tick += _gameTimer_Tick;
            _gameTimer.Start();

            _drawTimer = new Timer {Interval = (int) (1000d/60)};
            _drawTimer.Tick += _drawTimer_Tick;
            _drawTimer.Start();

            _objectManager.AddObject(new Player
            {
                X = 50,
                Y = 50,
                Width = 50,
                Height = 50
            });

            _objectManager.AddObject(new Wall
            {
                X = 5,
                Y=5,
                Width = 15,
                Height = 15
            });

            _objectManager.AddObject(new Bot
            {
                X = 400,
                Y = 400,
                Width = 50,
                Height = 50
            });
        }

        private void _gameTimer_Tick(object sender, EventArgs e)
        {
            _world.GameTick();
            _world.Draw(_graphics);
        }

        private void _drawTimer_Tick(object sender, EventArgs e)
        {
            _world.Draw(_graphics);
            imgCanvas.Image = _bitmap;
        }
    }
}
