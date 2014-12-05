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
        public MainWindow()
        {
            InitializeComponent();

            DataField df = new DataField();
            df.AddShip(new Ship { X1 = 0, X2 = 2, Y1 = 0, Y2 = 0 });
            df.AddShip(new Ship { X1 = 5, X2 = 5, Y1 = 5, Y2 = 7 });
            player1Field.DataField = df;
            player2Field.DataField = new DataField();
        }
    }
}
