using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace show_builder
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Storage.Instance.OnChange += Bind;
            Storage.Instance.Bind();
        }

        private void Bind()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(Bind), new object[] { });
                return;
            }

            // Save selection
            List<Strategy> SelectedStrategies = listBoxStrategies.SelectedItems.OfType<Strategy>().ToList();
            List<Game> SelectedGames = listBoxGames.SelectedItems.OfType<Game>().ToList();

            // Bind
            listBoxStrategies.DataSource = null;
            listBoxStrategies.DataSource = Storage.Instance.Strategies;

            listBoxGames.DataSource = null;
            listBoxGames.DataSource = Storage.Instance.Games;

            // Restore selection
            listBoxStrategies.SelectedIndices.Clear();
            SelectedStrategies.ForEach(s => listBoxStrategies.SelectedItems.Add(s));

            listBoxGames.SelectedIndices.Clear();
            SelectedGames.ForEach(g => listBoxGames.SelectedItems.Add(g));
        }

        public void AddStrategy(object sender, EventArgs e)
        {
            Strategy strategy = new Strategy();

            Storage.Instance.Strategies.Add(strategy);
            Storage.Instance.Bind();

            FormStrategy dialog = new FormStrategy(strategy);
            dialog.Show();
        }

        public void StrategyDetails(object sender, EventArgs e)
        {
            List<Strategy> selected = listBoxStrategies.SelectedItems.OfType<Strategy>().ToList();

            if (selected.Count == 0)
            {
                MessageBox.Show("Select strategies form the list.");
                return;
            }

            selected.ForEach(s =>
                {
                    FormStrategy dialog = new FormStrategy(s);
                    dialog.Show();
                });
        }

        public async void RemoveStrategies(object sender, EventArgs e)
        {
            List<Strategy> strategiesToDel = listBoxStrategies.SelectedItems.OfType<Strategy>().ToList();

            if (strategiesToDel.Count == 0)
            {
                MessageBox.Show("Select strategies from the list.");
                return;
            }

            List<Game> gamesToDel = Storage.Instance.Games
                .Where(g => strategiesToDel.Contains(g.Left) || strategiesToDel.Contains(g.Right))
                .ToList();

            string msg = "Do you really want to delete strategies: {0}? The following games also will be aborted and deleted: {1}.";
            string cptn = "Delete strategies";

            DialogResult res = MessageBox.Show(
                string.Format(msg,
                    string.Join(", ",strategiesToDel),
                    string.Join(", ", gamesToDel.Select(g => g.Name))),
                cptn,
                MessageBoxButtons.OKCancel);

            if (res == DialogResult.Cancel)
            {
                return;
            }

            await Storage.StopBuilders(gamesToDel);

            gamesToDel.ForEach(g => Storage.Instance.Games.Remove(g));
            strategiesToDel.ForEach(s => Storage.Instance.Strategies.Remove(s));
            Storage.Instance.Bind();
        }

        public void CreateGame(object sender, EventArgs e)
        {
            Strategy left;
            Strategy right;

            if (listBoxStrategies.SelectedItems.Count == 2)
            {
                left = listBoxStrategies.SelectedItems[0] as Strategy;
                right = listBoxStrategies.SelectedItems[1] as Strategy;
            }
            else if (listBoxStrategies.SelectedItems.Count == 1)
            {
                left = listBoxStrategies.SelectedItems[0] as Strategy;
                right = listBoxStrategies.SelectedItems[0] as Strategy;
            }
            else
            {
                MessageBox.Show("Select one or two strategies from the list.");
                return;
            }

            Game game = new Game(left, right);

            Storage.Instance.Games.Add(game);
            Storage.Instance.Bind();

            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                return;
            }

            FormGame form = new FormGame(game);
            form.Show();
        }

        public void GameDetails(object sender, EventArgs e)
        {
            List<Game> selected = listBoxGames.SelectedItems.OfType<Game>().ToList();

            if (selected.Count == 0)
            {
                MessageBox.Show("Select games from the list.");
                return;
            }

            selected.ForEach(s =>
                {
                    FormGame dialog = new FormGame(s);
                    dialog.Show();
                });
        }

        public async void RemoveGames(object sender, EventArgs e)
        {
            List<Game> selected = listBoxGames.SelectedItems.OfType<Game>().ToList();

            if (selected.Count == 0)
            {
                MessageBox.Show("Select games from the list.");
                return;
            }

            string msg = "Do you really want to abort and delete games: {0}?";
            string cptn = "Delete games";

            DialogResult res = MessageBox.Show(
                string.Format(msg, string.Join(", ", selected.Select(g => g.Name))),
                cptn,
                MessageBoxButtons.OKCancel);

            if (res == DialogResult.Cancel)
            {
                return;
            }

            await Storage.StopBuilders(selected);

            selected.ForEach(g => Storage.Instance.Games.Remove(g));
            Storage.Instance.Bind();
        }

        public void BuildGame(object sender, EventArgs e)
        {
            List<Game> selected = listBoxGames.SelectedItems.OfType<Game>().ToList();

            if (selected.Count == 0)
            {
                MessageBox.Show("Select games from the list.");
                return;
            }

            selected
                .Where(g => g.State != GameState.Building && g.State != GameState.Finished)
                .ToList()
                .ForEach(g => g.State = GameState.Inqueued);

            Storage.Instance.Bind();
        }

        public async void StopBuild(object sender, EventArgs e)
        {
            List<Game> selected = listBoxGames.SelectedItems.OfType<Game>().ToList();

            if (selected.Count == 0)
            {
                MessageBox.Show("Select games from the list.");
                return;
            }

            try
            {
                await Storage.StopBuilders(selected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void preferencesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormPreferences form = new FormPreferences();
            form.Show();
        }

        private async void saveStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Storage.Instance.IsBuilding)
            {
                DialogResult res = MessageBox.Show("Cannot save - building is running. Stop building and save games?", "Stop and save", MessageBoxButtons.OKCancel);

                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }

            // Stop all games
            await Storage.StopAllBuilders();

            // Save storage
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "State files (*.xml)|*.xml|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Storage.Save(dialog.FileName);
            }
        }

        private async void loadStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Storage.Instance.IsBuilding)
            {
                DialogResult res = MessageBox.Show("Cannot load - building is running. Stop building and save games?", "Stop and save", MessageBoxButtons.OKCancel);

                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }

            // Stop all games
            await Storage.StopAllBuilders();

            // Unsubscribe
            Storage.Instance.OnChange -= Bind;

            Application.OpenForms   // Others :)
                .OfType<Form>()
                .Where(f => f != this)
                .ToList()
                .ForEach(f => f.Close());

            // Load storage
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "State files (*.xml)|*.xml|All files (*.*)|*.*";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Storage.Load(dialog.FileName);

            // Bind
            Storage.Instance.OnChange += Bind;
            Storage.Instance.Bind();
        }

        private async void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Storage.Instance.IsBuilding)
            {
                DialogResult res = MessageBox.Show("Building is in process: do you want abort it and exit?", "Close", MessageBoxButtons.OKCancel);

                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            Storage.Instance.OnChange -= Bind;
            await Storage.StopAllBuilders();
        }
    }
}
