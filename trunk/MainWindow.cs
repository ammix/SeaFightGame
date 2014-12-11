using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SeaFightGame.Model;
using SeaFightGame.View;

namespace SeaFightGame
{
    public partial class MainWindow : Form
    {
        private ViewController field1View;
        private ViewController field2View;
        private IShipsSetupAlgorithm algorithm;

        public MainWindow()
        {
            InitializeComponent();

            Field field1 = new Field();
            Field field2 = new Field();
            algorithm = new AutoShipsSetup();

            field1View = new PlayerViewControler(field1);
            field2View = new EnemyViewControler(field2);

            this.field1View.Location = new System.Drawing.Point(12, 47);
            this.field1View.Size = new System.Drawing.Size(300, 300);
            this.Controls.Add(field1View);

            this.field2View.Location = new System.Drawing.Point(328, 47);
            this.field2View.Size = new System.Drawing.Size(300, 300);
            this.Controls.Add(field2View);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //field1View.AutoSetupShips(algorithm);
            field2View.AutoSetupShips(algorithm);
        }

    }
}
