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
            InitializeComponent();

            comboBoxPattern.DataSource = ExecutionPattern.AllPatterns;

            Strategy = strategy;

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

            Text = Strategy.Name;

            textBoxName.Text = Strategy.Name;
            textBoxExecutable.Text = Strategy.Executable;
            textBoxInterpreter.Text = Strategy.Interpreter;
            textBoxExecutionPattern.Text = Strategy.ExecutionPattern;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveGame();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SaveGame()
        {
            Strategy.Name = textBoxName.Text;
            Strategy.Executable = textBoxExecutable.Text;
            Strategy.Interpreter = textBoxInterpreter.Text;
            Strategy.ExecutionPattern = textBoxExecutionPattern.Text;

            Storage.Instance.BindAll();
        }

        private bool UpdatePatternText = true;

        private void textBoxExecutionPattern_TextChanged(object sender, EventArgs e)
        {
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

    }
}
