using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Ontwikkelopdracht_Game.Database;
using Ontwikkelopdracht_Game.Entity;

namespace Ontwikkelopdracht_Game
{
    public partial class GameForm : Form
    {
        private readonly World _world = World.Instance;
        private readonly ObjectManager _objectManager = ObjectManager.Instance;

        private readonly IRepository<List<GameObject>, string> _repository =
            Injector.Resolve<IRepository<List<GameObject>, string>>();

        public GameForm()
        {
            InitializeComponent();

            _world.GameEnded += _world_GameEnded;

            _world.ImgCanvas = imgCanvas;

#if DEBUG
            new DebugView().Show();
#endif
        }

        private void _world_GameEnded(object sender, GameEndedArgs args)
        {
            MessageBox.Show(args.Won ? "Won" : "Lost");
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker) delegate
            {
                _world.Pause();

                _repository.Save(LevelPreset.One, "One");
                _repository.Save(LevelPreset.Test, "Test");
                _repository.Save(LevelPreset.Test, "Test2");

                ListPrompt prompt = new ListPrompt("Load", _repository.List().ToList());

                if (prompt.ShowDialog(this) == DialogResult.OK)
                {
                    _objectManager.GameObjects.Clear();
                    _world.Populate(_repository.FindOne(prompt.SelectedItem));
                }

                _world.Resume();
            });
        }
    }
}