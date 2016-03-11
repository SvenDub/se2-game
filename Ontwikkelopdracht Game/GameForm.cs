using System.Windows.Forms;

namespace Ontwikkelopdracht_Game
{
    public partial class GameForm : Form
    {
        private readonly World _world = World.Instance;

        public GameForm()
        {
            InitializeComponent();

            _world.ImgCanvas = imgCanvas;

            _world.Populate(LevelPreset.One);
        }
    }
}