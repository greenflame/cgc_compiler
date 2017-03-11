using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace show_builder
{
    public partial class FormGame : Form
    {
        public Game Game { get; private set; }

        public Timer LogsUpdateTimer { get; private set; }

        public FormGame(Game game)
        {
            InitializeComponent();

            Game = game;
            Text = Game.Name;

            LogsUpdateTimer = new Timer();
            LogsUpdateTimer.Tick += (object sender, EventArgs e) => UpdateLogs();
            LogsUpdateTimer.Interval = 1000;
            LogsUpdateTimer.Start();
        }

        private void UpdateLogs()
        {
            richTextBoxBrief.Text = Game.BriefLog ?? "";
            richTextBoxGame.Text = Game.GameLog ?? "";
            richTextBoxExecution.Text = Game.ExecutionLog ?? "";
        }
    }
}
