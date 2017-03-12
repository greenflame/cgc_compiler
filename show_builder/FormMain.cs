using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace show_builder
{
    public partial class FormMain : Form
    {
        private BindingSource StrategiesBS = new BindingSource();
        private BindingSource GamesBS = new BindingSource();

        public Timer DataBindingTimer { get; private set; }

        public FormMain()
        {
            InitializeComponent();

            StrategiesBS.DataSource = Storage.Instance.Strategies;
            listBoxStrategies.DataSource = StrategiesBS;

            GamesBS.DataSource = Storage.Instance.Games;
            listBoxGames.DataSource = GamesBS;

            Storage.Instance.OnStorageChanged += BindData;
            BindData();
        }

        private void BindData()
        {
            // Save selection
            List<Strategy> SelectedStrategies = listBoxStrategies.SelectedItems.OfType<Strategy>().ToList();
            List<Game> SelectedGames = listBoxGames.SelectedItems.OfType<Game>().ToList();

            // Bind
            if (InvokeRequired)
            {
                this.Invoke(new Action(BindData), new object[] { });
                return;
            }

            StrategiesBS.ResetBindings(false);
            GamesBS.ResetBindings(false);

            // Restore selection
            listBoxStrategies.SelectedIndices.Clear();
            SelectedStrategies.ForEach(s => listBoxStrategies.SelectedItems.Add(s));

            listBoxGames.SelectedIndices.Clear();
            SelectedGames.ForEach(g => listBoxGames.SelectedItems.Add(g));
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

        private void buttonBrowsePlayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                Storage.Instance.PlayerExecutable = dialog.FileName;
                Storage.Instance.BindAll();
            }
        }
    }
}
