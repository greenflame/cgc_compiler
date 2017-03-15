using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace show_builder
{
    public partial class FormStrategy : Form
    {
        public Strategy Strategy { get; private set; }

        public FormStrategy(Strategy strategy)
        {
            Strategy = strategy;

            InitializeComponent();

            UpdatePatternText = false;
            comboBoxPattern.DataSource = ExecutionPattern.AllPatterns;
            UpdatePatternText = true;

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

            if (!Storage.Instance.Strategies.Contains(Strategy))
            {
                Close();
            }

            Text = Strategy.Name;

            textBoxName.Text = Strategy.Name;
            textBoxExecutable.Text = Strategy.Executable;
            textBoxInterpreter.Text = Strategy.Interpreter;
            textBoxExecutionPattern.Text = Strategy.ExecutionPattern;

            UpdatePatternText = false;
            comboBoxPattern.SelectedItem = ExecutionPattern.Suggest(Strategy.ExecutionPattern);
            UpdatePatternText = true;

            bool interpreterUsed = comboBoxPattern.SelectedItem as ExecutionPattern != ExecutionPattern.NoInterpreter;
            textBoxInterpreter.Enabled = interpreterUsed;
            buttonBrowseInterpreter.Enabled = interpreterUsed;
        }

        private bool UpdatePatternText = true;

        private void textBoxExecutionPattern_TextChanged(object sender, EventArgs e)
        {
            Strategy.ExecutionPattern = textBoxExecutionPattern.Text;
            Storage.Instance.Bind();

            UpdatePatternText = false;
            comboBoxPattern.SelectedItem = ExecutionPattern.Suggest(textBoxExecutionPattern.Text);
            UpdatePatternText = true;
        }

        private void comboBoxPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPattern.SelectedItem != null && UpdatePatternText)
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

            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                textBoxInterpreter.Text = dialog.FileName;
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            List<Game> gamesToDel = Storage.Instance.Games
                .Where(g => g.Left == Strategy || g.Right == Strategy)
                .ToList();

            string msg = "Do you really want to delete strategy {0}? The following games also will be aborted and deleted: {1}.";
            string cptn = "Delete strategy";

            DialogResult res = MessageBox.Show(
                string.Format(msg,
                    Strategy,
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
            Storage.Instance.Strategies.Remove(Strategy);
            Storage.Instance.Bind();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            Strategy.Name = textBoxName.Text;
            Storage.Instance.Bind();
        }

        private void textBoxExecutable_TextChanged(object sender, EventArgs e)
        {
            Strategy.Executable = textBoxExecutable.Text;
            Storage.Instance.Bind();
        }

        private void textBoxInterpreter_TextChanged(object sender, EventArgs e)
        {
            Strategy.Interpreter = textBoxInterpreter.Text;
            Storage.Instance.Bind();
        }
    }
}
