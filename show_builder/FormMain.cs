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
        public List<Strategy> Strategies { get; private set; } = new List<Strategy>();
        public List<Game> Games { get; private set; } = new List<Game>();

        private BindingSource StrategiesBS = new BindingSource();
        private BindingSource GamesBS = new BindingSource();

        private string PlayerExecutable;

        public FormMain()
        {
            InitializeComponent();

            StrategiesBS.DataSource = Strategies;
            listBoxStrategies.DataSource = StrategiesBS;

            GamesBS.DataSource = Games;
            listBoxGames.DataSource = GamesBS;
        }

        private void buttonStrategyAdd_Click(object sender, EventArgs e)
        {
            Strategy strategy = new Strategy();
            FormStrategy dialog = new FormStrategy(strategy);

            dialog.ShowDialog();

            if (dialog.DialogResult == DialogResult.OK)
            {
                Strategies.Add(strategy);
                StrategiesBS.ResetBindings(false);
            }
        }

        private void buttonStrategyEdit_Click(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedItem != null)
            {
                Strategy strategy = (Strategy)listBoxStrategies.SelectedItem;
                FormStrategy dialog = new FormStrategy(strategy);
                dialog.ShowDialog();

                StrategiesBS.ResetBindings(false);
                GamesBS.ResetBindings(false);
            }
        }

        private void buttonStrategyDelete_Click(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedItem != null)
            {
                Strategies.Remove(listBoxStrategies.SelectedItem as Strategy);
                StrategiesBS.ResetBindings(false);
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
            Games.Add(game);
            GamesBS.ResetBindings(false);
        }

        private void buttonDeleteGame_Click(object sender, EventArgs e)
        {
            listBoxGames.SelectedItems.OfType<Game>().ToList().ForEach(i => Games.Remove(i));
            GamesBS.ResetBindings(false);
        }

        private void buttonGameDetails_Click(object sender, EventArgs e)
        {
            if (listBoxGames.SelectedItem != null)
            {
                FormGame form = new FormGame(listBoxGames.SelectedItem as Game);
                form.Show();
                GamesBS.ResetBindings(false);
            }
        }

        private void buttonBuildGame_Click(object sender, EventArgs e)
        {
            if (listBoxGames.SelectedItem != null)
            {
                try
                {
                    (listBoxGames.SelectedItem as Game).StartBuild();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonStopBuild_Click(object sender, EventArgs e)
        {
            if (listBoxGames.SelectedItem != null)
            {
                try
                {
                    (listBoxGames.SelectedItem as Game).StopBuild();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonPlayGame_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerExecutable))
            {
                MessageBox.Show("Browse player executable first.");
                return;
            }

            if (listBoxGames.SelectedItem == null)
            {
                MessageBox.Show("Select game from the list.");
                return;
            }

            Game gameToPlay = (Game)listBoxGames.SelectedItem;

            try
            {
                File.WriteAllText(Path.Combine(Path.GetDirectoryName(PlayerExecutable), "game_log.txt"), gameToPlay.GameLog);

                Process.Start(new ProcessStartInfo()
                {
                    FileName = PlayerExecutable,
                    WorkingDirectory = Path.GetDirectoryName(PlayerExecutable)
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonBrowsePlayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                PlayerExecutable = dialog.FileName;
            }
        }
    }
}
