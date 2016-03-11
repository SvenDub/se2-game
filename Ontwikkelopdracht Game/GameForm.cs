using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Ontwikkelopdracht_Game
{
    public partial class GameForm : Form
    {
        private readonly World _world = World.Instance;

        public GameForm()
        {
            InitializeComponent();

            _world.ImgCanvas = imgCanvas;
        }
    }
}
