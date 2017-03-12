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

            Storage.Instance.OnStorageChanged += BindData;
            BindData();
        }

        public void BindData()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(BindData), new object[] {});
                return;
            }

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

            // Game state, name, strategy names
            Text = Game.Name;
            labelGameState.Text = Game.Status.ToString();

            labelLeftStrategyName.Text = Game.Left.Name;
            labelRightStrategyName.Text = Game.Right.Name;
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

        private void buttonStopBuild_Click(object sender, EventArgs e)
        {
            try
            {
                Game.StopBuild();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPlayGame_Click(object sender, EventArgs e)
        {
            string playerExecutable = Storage.Instance.PlayerExecutable;

            if (Game.Status != GameStatus.Finished)
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

    }
}
