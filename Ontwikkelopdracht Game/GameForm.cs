using System.Windows.Forms;

namespace Ontwikkelopdracht_Game
{
    public partial class GameForm : Form
    {
        private readonly World _world = World.Instance;

        public GameForm()
        {
            InitializeComponent();

            _world.GameEnded += _world_GameEnded;

            _world.ImgCanvas = imgCanvas;

            _world.Populate(LevelPreset.Test);

#if DEBUG
            new DebugView().Show();
#endif
        }

        private void _world_GameEnded(object sender, GameEndedArgs args)
        {
            MessageBox.Show(args.Won ? "Won" : "Lost");
        }
    }
}