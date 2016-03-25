using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Ontwikkelopdracht_Game.Entity;

namespace Ontwikkelopdracht_Game
{
    public partial class DebugView : Form
    {
        private readonly World _world = World.Instance;
        private readonly ObjectManager _objectManager = ObjectManager.Instance;

        public DebugView()
        {
            InitializeComponent();

            lstPathfinding.DataSource = _objectManager.GameObjects;

            _objectManager.GameObjects.CollectionChanged += GameObjects_CollectionChanged;
        }

        private void GameObjects_CollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            lstPathfinding.DataSource = null;
            lstPathfinding.DataSource = _objectManager.GameObjects;
        }

        private void lstPathfinding_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            if (lstPathfinding.SelectedIndex >= _objectManager.GameObjects.Count || lstPathfinding.SelectedIndex == -1)
                return;

            GameObject selectedItem = _objectManager.GameObjects[lstPathfinding.SelectedIndex];

            lblX.Text = Math.Round(selectedItem.X).ToString();
            lblY.Text = Math.Round(selectedItem.Y).ToString();
            lblWidth.Text = selectedItem.Width.ToString();
            lblHeight.Text = selectedItem.Height.ToString();
            lblRotation.Text = Math.Round(selectedItem.Rotation, 2).ToString();
            lblHealth.Text = selectedItem.Health + "/" + selectedItem.MaxHealth;

            if (selectedItem is Bot)
            {
                Bot bot = (Bot) selectedItem;

                chkTracking.Enabled = true;
                chkTracking.Checked = bot.Tracking;
            }
            else
            {
                chkTracking.Enabled = false;
            }
        }

        private void chkTracking_CheckedChanged(object sender, EventArgs e)
        {
            if (lstPathfinding.SelectedIndex >= _objectManager.GameObjects.Count || lstPathfinding.SelectedIndex == -1)
                return;

            GameObject selectedItem = _objectManager.GameObjects[lstPathfinding.SelectedIndex];

            if (selectedItem is Bot)
            {
                Bot bot = (Bot) selectedItem;

                bot.Tracking = chkTracking.Checked;
            }
        }

        private void lstPathfinding_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            _world.Pause();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            _world.Resume();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                MapManager.Export(LevelPreset.One, "Levels\\One.lvl");
                MapManager.Export(LevelPreset.Test, "Levels\\Test.lvl");
            }
            catch (LevelSaveException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _world.Pause();

            Directory.CreateDirectory("Levels");

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
                    _objectManager.GameObjects.Clear();
                    _world.Populate(gameObjects);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            _world.Resume();
        }
    }
}
