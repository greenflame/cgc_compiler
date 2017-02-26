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
        class StrategyInfo
        {
            public string Name { get; set; }
            public string Executable { get; set; }
            public string Interpreter { get; set; }
            public string ExecutionPattern { get; set; }
            public int Wins { get; set; } = 0;

            public StrategyInfo(string name, string executable, string interpreter, string executionPattern)
            {
                Name = name;
                Executable = executable;
                Interpreter = interpreter;
                ExecutionPattern = executionPattern;
            }

            public StrategyInfo()
            {
                Name = "New strategy name";
                Executable = "Full path to executable";
                Interpreter = "Full path to interpreter";
                ExecutionPattern = FormMain.ExecutionPattern.DefaultPattern.Pattern;
            }

            public override string ToString()
            {
                return string.Format("{0} wins:{1}", Name, Wins);
            }
        }

        class ExecutionPattern
        {
            public string Name { get; set; }
            public string Pattern { get; set; }

            public ExecutionPattern(string name, string pattern)
            {
                Name = name;
                Pattern = pattern;
            }

            public override string ToString()
            {
                return Name;
            }

            public static ExecutionPattern DefaultPattern { get; private set; }
            public static ExecutionPattern CustomPattern { get; private set; }

            public static List<ExecutionPattern> AllPatterns { get; private set; } = new List<ExecutionPattern>();

            static ExecutionPattern()
            {
                DefaultPattern = new ExecutionPattern("No interpreter", "{e}#");
                CustomPattern = new ExecutionPattern("Custom", "{i}#-magic_param {e}");

                AllPatterns.Add(DefaultPattern);
                AllPatterns.Add(new ExecutionPattern("No interpreter", "{e}#"));
                AllPatterns.Add(new ExecutionPattern("Java", "{i}#-jar {e}"));
                AllPatterns.Add(new ExecutionPattern("Python / Node", "{i}#{e}"));
                AllPatterns.Add(CustomPattern);
            }
        }

        public FormMain()
        {
            InitializeComponent();

            ExecutionPattern.AllPatterns.ForEach(p => comboBoxPattern.Items.Insert(comboBoxPattern.Items.Count, p));

            UpdateLogsTimer = new System.Windows.Forms.Timer();
            UpdateLogsTimer.Tick += UpdateLogsTimer_Tick;
            UpdateLogsTimer.Interval = 1000;
            UpdateLogsTimer.Start();
        }

        private void listBoxStrategies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedIndex != -1)
            {
                StrategyInfo si = (StrategyInfo)listBoxStrategies.SelectedItem;
                textBoxName.Text = si.Name;
                textBoxExecutable.Text = si.Executable;
                textBoxInterpreter.Text = si.Interpreter;
                textBoxExecutionPattern.Text = si.ExecutionPattern;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBoxStrategies.Items.Add(new StrategyInfo());
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedIndex != -1)
            {
                listBoxStrategies.Items.RemoveAt(listBoxStrategies.SelectedIndex);
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedIndex != -1)
            {
                ((StrategyInfo)listBoxStrategies.SelectedItem).Name = textBoxName.Text;
                listBoxStrategies.Items[listBoxStrategies.SelectedIndex] = listBoxStrategies.Items[listBoxStrategies.SelectedIndex];
            }
        }

        private void textBoxExecutable_TextChanged(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedIndex != -1)
            {
                ((StrategyInfo)listBoxStrategies.SelectedItem).Executable = textBoxExecutable.Text;
                listBoxStrategies.Items[listBoxStrategies.SelectedIndex] = listBoxStrategies.Items[listBoxStrategies.SelectedIndex];
            }
        }

        private void textBoxInterpreter_TextChanged(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedIndex != -1)
            {
                ((StrategyInfo)listBoxStrategies.SelectedItem).Interpreter = textBoxInterpreter.Text;
                listBoxStrategies.Items[listBoxStrategies.SelectedIndex] = listBoxStrategies.Items[listBoxStrategies.SelectedIndex];
            }
        }

        bool UpdatePatternText = true;

        private void textBoxExecutionPattern_TextChanged(object sender, EventArgs e)
        {
            if (listBoxStrategies.SelectedIndex != -1)
            {
                ((StrategyInfo)listBoxStrategies.SelectedItem).ExecutionPattern = textBoxExecutionPattern.Text;
                listBoxStrategies.Items[listBoxStrategies.SelectedIndex] = listBoxStrategies.Items[listBoxStrategies.SelectedIndex];
            }

            List<ExecutionPattern> currentPattern = ExecutionPattern.AllPatterns.Where(p => p.Pattern == textBoxExecutionPattern.Text).ToList();

            if (currentPattern.Count != 0)
            {
                comboBoxPattern.SelectedItem = currentPattern[0];
            }
            else
            {
                UpdatePatternText = false;
                comboBoxPattern.SelectedItem = ExecutionPattern.CustomPattern;
                UpdatePatternText = true;
            }
        }

        private void comboBoxPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPattern.SelectedIndex != -1 && UpdatePatternText)
            {
                textBoxExecutionPattern.Text = ((ExecutionPattern)comboBoxPattern.SelectedItem).Pattern;
            }
        }

        private void buttonBrowseExecutable_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                textBoxExecutable.Text = dialog.FileName;
                textBoxName.Text = Path.GetFileNameWithoutExtension(dialog.FileName);
            }
        }

        private void buttonBrowseInterpreter_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            textBoxInterpreter.Text = dialog.FileName;
        }

        private string CombineExecutionString(StrategyInfo info)
        {
            string template = info.ExecutionPattern
                .Replace("{i}", info.Interpreter)
                .Replace("{e}", "{0}");

            return string.Format("{0}|{1}", info.Executable, template);
        }

        class GameSave
        {
            public string Name { get; private set; }
            public string GameLog { get; private set; }
            public string ExecutionLog { get; private set; }
            public string BriefLog { get; private set; }

            public GameSave(string name, string gl, string el, string bl)
            {
                Name = name;
                GameLog = gl;
                ExecutionLog = el;
                BriefLog = bl;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        Thread BuildThread;
        System.Windows.Forms.Timer UpdateLogsTimer;

        bool InterruptBuilder;
        bool GameBuilt;
        string GameName = "";
        StrategyInfo left;
        StrategyInfo right;

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

                MainClass.BuildGame(
                    CombineExecutionString(left),
                    CombineExecutionString(right),
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

                GameBuilt = true;
            }
            catch (Exception ex)
            {
                BriefLog += ex.Message + Environment.NewLine;
            }
        }

        private void UpdateLogsTimer_Tick(object sender, EventArgs e)
        {
            if (richTextBoxBrief.Text != BriefLog.Replace("\r\n", "\n"))
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

                listBoxGames.Items.Add(new GameSave(GameName, GameLog, ExecutionLog, BriefLog));

                if (BriefLog.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Last().Split(' ')[0].Contains("Left"))
                {
                    left.Wins++;
                }
                else
                {
                    right.Wins++;
                }

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

            left = (StrategyInfo)listBoxStrategies.SelectedItems[0];
            right = (StrategyInfo)listBoxStrategies.SelectedItems[1];

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
                GameSave save = (GameSave)listBoxGames.SelectedItem;

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
                GameSave save = (GameSave)listBoxGames.SelectedItem;

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
                        left = (StrategyInfo)listBoxStrategies.Items[i];
                        right = (StrategyInfo)listBoxStrategies.Items[j];

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
    }
}
