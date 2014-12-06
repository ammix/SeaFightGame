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

        public MainWindow()
        {
            InitializeComponent();

            Field field1 = new Field();
            //field1.AddShip(new Ship { X1 = 0, X2 = 2, Y1 = 0, Y2 = 0 });
            //field1.AddShip(new Ship { X1 = 5, X2 = 5, Y1 = 5, Y2 = 7 });
            ShipsSetupAlgorithm.Setup(field1);
            Field field2 = new Field();
            ShipsSetupAlgorithm.Setup(field2);

            field1View = new ViewController(field1);
            field2View = new ViewController(field2);

            this.field1View.Location = new System.Drawing.Point(12, 47);
            this.field1View.Size = new System.Drawing.Size(300, 300);
            this.Controls.Add(field1View);

            this.field2View.Location = new System.Drawing.Point(328, 47);
            this.field2View.Size = new System.Drawing.Size(300, 300);
            this.Controls.Add(field2View);
        }

    }
}
