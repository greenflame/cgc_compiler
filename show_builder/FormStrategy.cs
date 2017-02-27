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

            ExecutionPattern.AllPatterns.ForEach(p => comboBoxPattern.Items.Insert(comboBoxPattern.Items.Count, p));

            Strategy = strategy;
            SyncModelToView();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SyncViewToModel();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SyncModelToView()
        {
            textBoxName.Text = Strategy.Name;
            textBoxExecutable.Text = Strategy.Executable;
            textBoxInterpreter.Text = Strategy.Interpreter;
            textBoxExecutionPattern.Text = Strategy.ExecutionPattern;
        }

        private void SyncViewToModel()
        {
            Strategy.Name = textBoxName.Text;
            Strategy.Executable = textBoxExecutable.Text;
            Strategy.Interpreter = textBoxInterpreter.Text;
            Strategy.ExecutionPattern = textBoxExecutionPattern.Text;
        }

        private bool UpdatePatternText = true;

        private void textBoxExecutionPattern_TextChanged(object sender, EventArgs e)
        {
            ExecutionPattern currentPattern = ExecutionPattern.AllPatterns.Where(p => p.Pattern == textBoxExecutionPattern.Text).FirstOrDefault();

            if (currentPattern != null)
            {
                comboBoxPattern.SelectedItem = currentPattern;
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

            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                textBoxInterpreter.Text = dialog.FileName;
            }
        }

    }
}
