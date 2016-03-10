using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Ontwikkelopdracht_Game
{
    public partial class Form1 : Form
    {
        private readonly World _world;

        public Form1()
        {
            InitializeComponent();

            _world = new World(imgCanvas);
        }
    }
}
