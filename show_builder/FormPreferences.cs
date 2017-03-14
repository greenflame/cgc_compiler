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

            Storage.Instance.OnStorageChanged += BindData;
            Storage.Instance.BindAll();
        }

        private void BindData()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(BindData), new object[] { });
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
                Storage.Instance.BindAll();
            }
        }

        private void textBoxPlayerExecutable_TextChanged(object sender, EventArgs e)
        {
            Storage.Instance.PlayerExecutable = textBoxPlayerExecutable.Text;
            Storage.Instance.BindAll();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Storage.Instance.OnStorageChanged -= BindData;
            Close();
        }
    }
}
