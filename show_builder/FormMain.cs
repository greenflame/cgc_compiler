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

            Storage.Instance.OnStorageChanged += BindData;
            Storage.Instance.BindAll();
        }

        private void BindData()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(BindData), new object[] { });
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

        private async Task StopAllBuilders()
        {
            List<Game> runningBuilders = Storage.Instance.Games
                .Where(g => g.Status == GameState.Building)
                .ToList();

            runningBuilders.ForEach(g => g.StopBuild());
            await Task.Run(() => runningBuilders.ForEach(g => g.JoinBuilder()));
        }

        private void buttonStrategyAdd_Click(object sender, EventArgs e)
        {
            Strategy strategy = new Strategy();
            Storage.Instance.Strategies.Add(strategy);
            Storage.Instance.BindAll();

            FormStrategy dialog = new FormStrategy(strategy);
            dialog.Show();
        }

        private void buttonStrategyDetails_Click(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedItem != null)
            {
                FormStrategy dialog = new FormStrategy(listBoxStrategies.SelectedItem as Strategy);
                dialog.Show();
            }
        }

        private void buttonCreateGame_Click(object sender, EventArgs e)
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
            Storage.Instance.BindAll();

            FormGame form = new FormGame(game);
            form.Show();
        }

        private void buttonDeleteGame_Click(object sender, EventArgs e)
        {
            listBoxGames.SelectedItems.OfType<Game>().ToList().ForEach(i => Storage.Instance.Games.Remove(i));
            Storage.Instance.BindAll();
        }

        private void buttonGameDetails_Click(object sender, EventArgs e)
        {
            if (listBoxGames.SelectedItem != null)
            {
                FormGame form = new FormGame(listBoxGames.SelectedItem as Game);
                form.Show();
            }
        }

        private void preferencesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormPreferences form = new FormPreferences();
            form.Show();
        }

        private async void saveStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Stop all games
            await StopAllBuilders();

            // Save storage
            Storage.Save("state.xml");
        }

        private async void loadStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Stop all games
            await StopAllBuilders();

            // Load storage
            Storage.Load("state.xml");

            // Bind
            Storage.Instance.OnStorageChanged += BindData;
            Storage.Instance.BindAll();

            // Close all forms in case of wrong binding
            Application.OpenForms
                .OfType<Form>()
                .Where(f => f != this)
                .ToList()
                .ForEach(f => f.Close());
        }

        private async void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Storage.Instance.OnStorageChanged -= BindData;
            await StopAllBuilders();
        }
    }
}
