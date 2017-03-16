using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace show_builder
{
    public partial class FormGame : Form
    {
        public Game Game { get; private set; }

        public FormGame(Game game)
        {
            InitializeComponent();

            Game = game;

            Storage.Instance.OnChange += Bind;
            Storage.Instance.Bind();
        }

        public void Bind()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(Bind), new object[] {});
                return;
            }

            if (!Storage.Instance.Games.Contains(Game))
            {
                Close();
            }

            comboBoxLeftStrategy.SelectedIndexChanged -= comboBoxLeftStrategy_SelectedIndexChanged;
            comboBoxRightStrategy.SelectedIndexChanged -= comboBoxRightStrategy_SelectedIndexChanged;
            textBoxName.TextChanged -= textBoxName_TextChanged;

            // Logs
            if (richTextBoxBrief.Text != Game.BriefLog.Replace("\r\n", "\n"))
            {
                richTextBoxBrief.Text = Game.BriefLog;
            }

            if (richTextBoxGame.Text != Game.GameLog.Replace("\r\n", "\n"))
            {
                richTextBoxGame.Text = Game.GameLog;
            }

            if (richTextBoxExecution.Text != Game.ExecutionLog.Replace("\r\n", "\n"))
            {
               richTextBoxExecution.Text = Game.ExecutionLog;
            }

            // Data
            Text = string.Format("{0} [{1}]", Game.Name, Game.State);

            textBoxName.Text = Game.Name;

            BindingSource leftStrategiesBS = new BindingSource();
            leftStrategiesBS.DataSource = Storage.Instance.Strategies;            
            comboBoxLeftStrategy.DataSource = leftStrategiesBS;
            comboBoxLeftStrategy.SelectedItem = Game.Left;

            BindingSource rightStrategiesBS = new BindingSource();
            rightStrategiesBS.DataSource = Storage.Instance.Strategies;
            comboBoxRightStrategy.DataSource = rightStrategiesBS;
            comboBoxRightStrategy.SelectedItem = Game.Right;

            // Components enable
            bool strategyChangeAvailible = Game.State != GameState.Building && Game.State != GameState.Finished;
            comboBoxLeftStrategy.Enabled = strategyChangeAvailible;
            comboBoxRightStrategy.Enabled = strategyChangeAvailible;

            comboBoxLeftStrategy.SelectedIndexChanged += comboBoxLeftStrategy_SelectedIndexChanged;
            comboBoxRightStrategy.SelectedIndexChanged += comboBoxRightStrategy_SelectedIndexChanged;
            textBoxName.TextChanged += textBoxName_TextChanged;
        }

        private void buttonBuildGame_Click(object sender, EventArgs e)
        {
            try
            {
                Game.StartBuild();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void buttonStopBuild_Click(object sender, EventArgs e)
        {
            try
            {
                await Game.StopBuild();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPlayGame_Click(object sender, EventArgs e)
        {
            string playerExecutable = Storage.Instance.PlayerExecutable;

            if (Game.State != GameState.Finished)
            {
                MessageBox.Show("Buld the game before playing.");
                return;
            }

            if (string.IsNullOrEmpty(playerExecutable))
            {
                MessageBox.Show("Browse player executable.");
                return;
            }

            try
            {
                File.WriteAllText(Path.Combine(Path.GetDirectoryName(playerExecutable), "game_log.txt"), Game.GameLog);

                Process.Start(new ProcessStartInfo()
                {
                    FileName = playerExecutable,
                    WorkingDirectory = Path.GetDirectoryName(playerExecutable)
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Storage.Instance.OnChange -= Bind;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            Game.Name = textBoxName.Text;
            Storage.Instance.Bind();
        }

        private void comboBoxLeftStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Strategy strategy = comboBoxLeftStrategy.SelectedItem as Strategy;

            if (strategy == null)
            {
                return;
            }

            Game.Left = strategy;
            Storage.Instance.Bind();
        }

        private void comboBoxRightStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Strategy strategy = comboBoxRightStrategy.SelectedItem as Strategy;

            if (strategy == null)
            {
                return;
            }

            Game.Right = strategy;
            Storage.Instance.Bind();
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to abort delete thiss game?", "Delete game", MessageBoxButtons.OKCancel);

            if (res == DialogResult.Cancel)
            {
                return;
            }

            if (Game.State == GameState.Building)
            {
                await Game.StopBuild();
            }

            Storage.Instance.Games.Remove(Game);
            Storage.Instance.Bind();
        }
    }
}
