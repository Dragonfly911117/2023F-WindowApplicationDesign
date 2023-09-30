using System;
using System.Drawing;

namespace FakePowerPoint
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            Color = Color.FromArgb(153, 132, 120, 222);
            CenterCoordinate = new Tuple<int, int>(0, 0);
        }

        public Rectangle(Color color, Tuple<int, int> centerCoordinate)
        {
            Color = color;
            CenterCoordinate = centerCoordinate;
        }

        public Tuple<int, int> GetTopLeft()
        {
            return new Tuple<int, int>(CenterCoordinate.Item1 - Width / 2, CenterCoordinate.Item2 - Height / 2);
        }

        public override void Draw(Graphics graphics)
        {
            var topLeft = GetTopLeft();
            graphics.FillRectangle(new SolidBrush(Color), topLeft.Item1, topLeft.Item2, Width, Height);
        }

        public int Width { get; set; }
        public int Height { get; set; }
    }
}
