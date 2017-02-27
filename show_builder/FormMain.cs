using cgc_compiler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace show_builder
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();



            UpdateLogsTimer = new System.Windows.Forms.Timer();
            UpdateLogsTimer.Tick += UpdateLogsTimer_Tick;
            UpdateLogsTimer.Interval = 1000;
            UpdateLogsTimer.Start();
        }

        Thread BuildThread;
        System.Windows.Forms.Timer UpdateLogsTimer;

        bool InterruptBuilder;
        bool GameBuilt;
        string GameName = "";
        Strategy left;
        Strategy right;

        string GameLog = "";
        string ExecutionLog = "";
        string BriefLog = "";

        private void CheckForInterrupt()
        {
            if (InterruptBuilder)
            {
                Thread.CurrentThread.Abort();
            }
        }

        private void Builder()
        {
            try
            {
                InterruptBuilder = false;
                GameBuilt = false;
                GameName = string.Format("{0} vs {1}", left.Name, right.Name);

                GameLog = "";
                ExecutionLog = "";
                BriefLog = "";

                Judge judge =  new Judge(
                    left.CombineExecutionString(),
                    right.CombineExecutionString(),
                    s =>
                    {
                        GameLog += s + Environment.NewLine;
                        CheckForInterrupt();
                    },
                    s =>
                    {
                        ExecutionLog += s + Environment.NewLine;
                        CheckForInterrupt();
                    },
                    s =>
                    {
                        BriefLog += s + Environment.NewLine;
                        CheckForInterrupt();
                    }
                );

                judge.RunSimulation();

                GameBuilt = true;
            }
            catch (Exception ex)
            {
                BriefLog += ex.Message + Environment.NewLine;
            }
        }

        private void UpdateLogsTimer_Tick(object sender, EventArgs e)
        {
            if (richTextBoxBrief.Text != BriefLog.Replace("\r\n", "\n") || richTextBoxGame.Text != GameLog.Replace("\r\n", "\n"))
            {
                richTextBoxBrief.Text = BriefLog;
                richTextBoxExecution.Text = ExecutionLog;
                richTextBoxGame.Text = GameLog;

                richTextBoxBrief.SelectionStart = richTextBoxBrief.TextLength;
                richTextBoxBrief.ScrollToCaret();

                richTextBoxExecution.SelectionStart = richTextBoxExecution.TextLength;
                richTextBoxExecution.ScrollToCaret();

                richTextBoxGame.SelectionStart = richTextBoxGame.TextLength;
                richTextBoxGame.ScrollToCaret();
            }

            if (GameBuilt)
            {
                GameBuilt = false;

                listBoxGames.Items.Add(new Game(GameName, GameLog, ExecutionLog, BriefLog));

                //if (BriefLog.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Last().Split(' ')[0].Contains("Left"))
                //{
                //    left.Wins++;
                //}
                //else
                //{
                //    right.Wins++;
                //}

                for (int i = 0; i < listBoxStrategies.Items.Count; i++)
                {
                    listBoxStrategies.Items[i] = listBoxStrategies.Items[i];
                }
            }
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedItems.Count != 2)
            {
                MessageBox.Show("Please select two strategies from list.");
                return;
            }

            if (BuildThread != null && BuildThread.IsAlive)
            {
                MessageBox.Show("Build thread is already running.");
                return;
            }

            left = (Strategy)listBoxStrategies.SelectedItems[0];
            right = (Strategy)listBoxStrategies.SelectedItems[1];

            BuildThread = new Thread(Builder);
            BuildThread.Start();
        }

        private void buttonInterrupt_Click(object sender, EventArgs e)
        {
            InterruptBuilder = true;
        }

        private void listBoxGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxGames.SelectedIndex != -1 && (BuildThread == null || !BuildThread.IsAlive))
            {
                Game save = (Game)listBoxGames.SelectedItem;

                BriefLog = save.BriefLog;
                ExecutionLog = save.ExecutionLog;
                GameLog = save.GameLog;

                UpdateLogsTimer_Tick(null, null);
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (listBoxGames.SelectedItem != null)
            {
                Game save = (Game)listBoxGames.SelectedItem;

                try
                {
                    File.WriteAllText(Path.Combine(Path.GetDirectoryName(PlayerExecutable), "game_log.txt"), save.GameLog);

                    Process.Start(new ProcessStartInfo() {
                        FileName = PlayerExecutable,
                        WorkingDirectory = Path.GetDirectoryName(PlayerExecutable)
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        string PlayerExecutable = "cgc_player_unity.exe";

        private void buttonBrowsePlayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                PlayerExecutable = dialog.FileName;
            }
        }

        private void buttonBatch_Click(object sender, EventArgs e)
        { 
            for (int i = 0; i < listBoxStrategies.Items.Count - 1; i++)
            {
                for (int j = i + 1; j < listBoxStrategies.Items.Count; j++)
                {
                    for (int game = 0; game < numericUpDownBatch.Value; game++)
                    {
                        left = (Strategy)listBoxStrategies.Items[i];
                        right = (Strategy)listBoxStrategies.Items[j];

                        BuildThread = new Thread(Builder);
                        BuildThread.Start();

                        while (BuildThread.IsAlive)
                        {
                            if (InterruptBuilder)
                            {
                                return;
                            }

                            Thread.Sleep(100);
                            Application.DoEvents();
                        }

                        UpdateLogsTimer_Tick(null, null);
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < listBoxGames.Items.Count; i++)
                    {
                        Game save = (Game)listBoxGames.Items[i];

                        string name = save.Name + ".txt";
                        int p = 1;

                        while (File.Exists(Path.Combine(dialog.SelectedPath, name)))
                        {
                            name = string.Format("{0}_{1}.txt", save.Name, p++);
                        }

                        File.WriteAllText(Path.Combine(dialog.SelectedPath, name), save.GameLog);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxGames.Items.Clear();

                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = Directory.GetFiles(dialog.SelectedPath);

                    for (int i = 0; i < files.Length; i++)
                    {
                        Game save = new Game(
                            Path.GetFileNameWithoutExtension(files[i]),
                            File.ReadAllText(files[i]),
                            "",
                            ""
                            );

                        listBoxGames.Items.Add(save);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxGames.Items.Clear();
        }

        // New

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Strategy strategy = new Strategy();
            FormStrategy dialog = new FormStrategy(strategy);

            dialog.ShowDialog();

            if (dialog.DialogResult == DialogResult.OK)
            {
                listBoxStrategies.Items.Add(strategy);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedItem == null)
            {
                return;
            }

            Strategy strategy = (Strategy)listBoxStrategies.SelectedItem;
            FormStrategy dialog = new FormStrategy(strategy);

            dialog.ShowDialog();

            int ind = listBoxStrategies.Items.IndexOf(strategy);
            listBoxStrategies.Items[ind] = listBoxStrategies.Items[ind];
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedItem != null)
            {
                listBoxStrategies.Items.Remove(listBoxStrategies.SelectedItem);
            }
        }
    }
}
