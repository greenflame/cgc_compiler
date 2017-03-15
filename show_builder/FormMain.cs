using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

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

        public void AddStrategy()
        {
            Strategy strategy = new Strategy();
            Storage.Instance.Strategies.Add(strategy);
            Storage.Instance.Bind();

            FormStrategy dialog = new FormStrategy(strategy);
            dialog.Show();
        }

        public void StrategyDetails()
        {
            if (listBoxStrategies.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select strategies form the list.");
                return;
            }

            listBoxStrategies.SelectedItems
                .OfType<Strategy>()
                .ToList()
                .ForEach(s =>
                {
                    FormStrategy dialog = new FormStrategy(s);
                    dialog.Show();
                });
        }

        public async Task RemoveStrategies()
        {
            if (listBoxStrategies.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select strategies from the list.");
                return;
            }

            List<Strategy> strategiesToDel = listBoxStrategies.SelectedItems
                .OfType<Strategy>()
                .ToList();

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

            // Stop games to delete
            await Storage.StopBuilders(gamesToDel);

            gamesToDel.ForEach(g => Storage.Instance.Games.Remove(g));
            strategiesToDel.ForEach(s => Storage.Instance.Strategies.Remove(s));
            Storage.Instance.Bind();
        }

        public void CreateGame()
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

            FormGame form = new FormGame(game);
            form.Show();
        }

        public void GameDetails()
        {
            if (listBoxGames.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select games from the list.");
                return;
            }

            listBoxGames.SelectedItems
                .OfType<Game>()
                .ToList()
                .ForEach(s =>
                {
                    FormGame dialog = new FormGame(s);
                    dialog.Show();
                });
        }

        public async Task RemoveGames()
        {
            if (listBoxGames.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select games from the list.");
                return;
            }

            List<Game> gamesToDel = listBoxGames.SelectedItems
                .OfType<Game>()
                .ToList();

            string msg = "Do you really want to abort adn delete games: {0}?";
            string cptn = "Delete games";

            DialogResult res = MessageBox.Show(
                string.Format(msg, string.Join(", ", gamesToDel)),
                cptn,
                MessageBoxButtons.OKCancel);

            if (res == DialogResult.Cancel)
            {
                return;
            }

            // Stop games to delete
            await Storage.StopBuilders(gamesToDel);

            gamesToDel.ForEach(g => Storage.Instance.Games.Remove(g));
            Storage.Instance.Bind();
        }

        private void buttonStrategyAdd_Click(object sender, EventArgs e)
        {
            AddStrategy();
        }

        private void buttonStrategyDetails_Click(object sender, EventArgs e)
        {
            StrategyDetails();
        }

        private void buttonCreateGame_Click(object sender, EventArgs e)
        {
            CreateGame();
        }

        private async void buttonDeleteGame_Click(object sender, EventArgs e)
        {
            await RemoveGames();
        }

        private void buttonGameDetails_Click(object sender, EventArgs e)
        {
            GameDetails();
        }

        private void preferencesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormPreferences form = new FormPreferences();
            form.Show();
        }

        private async void saveStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Stop all games
            await Storage.StopAllBuilders();

            // Save storage
            Storage.Save("state.xml");
        }

        private async void loadStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Stop all games
            await Storage.StopAllBuilders();

            // Load storage
            Storage.Load("state.xml");

            // Bind
            Storage.Instance.OnChange += Bind;
            Storage.Instance.Bind();

            // Close all forms in case of wrong binding
            Application.OpenForms
                .OfType<Form>()
                .Where(f => f != this)
                .ToList()
                .ForEach(f => f.Close());
        }

        private async void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Storage.Instance.OnChange -= Bind;
            await Storage.StopAllBuilders();
        }

        private async void stopAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Storage.StopAllBuilders();
        }

        private void buildAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Storage.Instance.Games
                .Where(g => g.State != GameState.Building)
                .ToList()
                .ForEach(g => g.StartBuild());
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStrategy();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StrategyDetails();
        }

        private async void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await RemoveStrategies();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGame();
        }

        private void detailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GameDetails();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await RemoveGames();
        }
    }
}
