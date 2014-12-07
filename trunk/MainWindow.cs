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
    public partial class MainWindow : Form
    {
        private ViewController field1View;
        private ViewController field2View;
        private IField field1;

        public MainWindow()
        {
            InitializeComponent();

            field1 = new Field();
            //ShipsSetupAlgorithm.Setup(field1);
            Field field2 = new Field();
            //ShipsSetupAlgorithm.Setup(field2);

            field1View = new ViewController(field1);
            field2View = new ViewController(field2);

            this.field1View.Location = new System.Drawing.Point(12, 47);
            this.field1View.Size = new System.Drawing.Size(300, 300);
            this.Controls.Add(field1View);

            this.field2View.Location = new System.Drawing.Point(328, 47);
            this.field2View.Size = new System.Drawing.Size(300, 300);
            this.Controls.Add(field2View);

            //ShipsSetupAlgorithm.Setup(field2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            field1.Clear();
            ShipsSetupAlgorithm.Setup(field1);
            field1View.Refresh();
        }

    }
}
