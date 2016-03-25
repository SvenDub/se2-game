using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Ontwikkelopdracht_Game.Entity;

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

                Directory.CreateDirectory("Levels");
                MapManager.Export(LevelPreset.One, "Levels\\One.lvl");
                MapManager.Export(LevelPreset.Test, "Levels\\Test.lvl");

                OpenFileDialog dialog = new OpenFileDialog
                {
                    Filter = "Level|*.lvl",
                    InitialDirectory = Directory.GetCurrentDirectory() + "\\Levels"
                };

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    try
                    {
                        List<GameObject> gameObjects = MapManager.Import(dialog.FileName);
                        _world.Populate(gameObjects);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not load the level. Exiting.");
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("No file selected. Exiting.");
                    Close();
                }

                _world.Resume();
            });
        }
    }
}