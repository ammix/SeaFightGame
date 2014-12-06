//using System;
//using System.Collections.Generic;
//using System.Drawing;

//namespace SeaFightGame
//{
//    public class FieldView
//    {
//        private readonly Graphics g;

//        public FieldView(Graphics g)
//        {
//            this.g = g;           
//        }

//        public void DrawCell(Cell cell)
//        {

//        }

//        public void DrawShip(Ship ship)
//        {

//        }

//        public void DrawField()
//        {
//            int X = 10;
//            int Y = 10;
//            int Width = (int)g.ClipBounds.Width;
//            int Height = (int)g.ClipBounds.Height;
//            var brush = new SolidBrush(Color.Black);
//            var pen = new Pen(brush);

//            int width = Width - 40;
//            int height = Height - 40;
//            int dx = (width) / X;
//            int dy = (height) / Y;

//            for (int y = 0; y < Y; y++)
//                g.DrawString((y + 1).ToString(), new Font("Arial", 12), brush, 20, y * height / Y + 20, new StringFormat { Alignment = StringAlignment.Far });

//            string[] str = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
//            for (int x = 0; x < X; x++)
//                g.DrawString(str[x], new Font("Arial", 12), brush, x * width / X + 30, 0);

//            for (int y = 0; y <= Y; y++)
//                g.DrawLine(pen, 20, y * dy + 20, width + 20, y * dy + 20);

//            for (int x = 0; x <= X; x++)
//                g.DrawLine(pen, x * dx + 20, 20, x * dx + 20, height + 20);
//        }
//    }
//}
