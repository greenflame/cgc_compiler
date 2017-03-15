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
    public partial class FormPreferences : Form
    {
        public FormPreferences()
        {
            InitializeComponent();

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

            textBoxPlayerExecutable.Text = Storage.Instance.PlayerExecutable;
        }

        private void buttonBrowsePlayerExecutable_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                Storage.Instance.PlayerExecutable = dialog.FileName;
                Storage.Instance.Bind();
            }
        }

        private void textBoxPlayerExecutable_TextChanged(object sender, EventArgs e)
        {
            Storage.Instance.PlayerExecutable = textBoxPlayerExecutable.Text;
            Storage.Instance.Bind();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Storage.Instance.OnChange -= Bind;
            Close();
        }
    }
}
