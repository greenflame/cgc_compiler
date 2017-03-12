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
            if (InvokeRequired)
            {
                this.Invoke(new Action(BindData), new object[] { });
                return;
            }

            StrategiesBS.ResetBindings(false);
            GamesBS.ResetBindings(false);
        }

        private void buttonStrategyAdd_Click(object sender, EventArgs e)
        {
            Strategy strategy = new Strategy();
            FormStrategy dialog = new FormStrategy(strategy);

            dialog.ShowDialog();

            if (dialog.DialogResult == DialogResult.OK)
            {
                Storage.Instance.Strategies.Add(strategy);
                Storage.Instance.BindAll();
            }
        }

        private void buttonStrategyEdit_Click(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedItem != null)
            {
                Strategy strategy = (Strategy)listBoxStrategies.SelectedItem;
                FormStrategy dialog = new FormStrategy(strategy);
                dialog.ShowDialog();
            }
        }

        private void buttonStrategyDelete_Click(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedItem != null)
            {
                Storage.Instance.Strategies.Remove(listBoxStrategies.SelectedItem as Strategy);
                Storage.Instance.BindAll();
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
