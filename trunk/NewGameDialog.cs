using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeaFightGame
{
    public partial class NewGameDialog : Form
    {
        public NewGameDialog()
        {
            InitializeComponent();
        }

        public bool AiShipSetup { get; set; }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            AiShipSetup = checkBox1.Checked;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
