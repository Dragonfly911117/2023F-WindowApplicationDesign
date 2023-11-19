using System.Collections.Generic;
using System.Drawing;

namespace FakePowerPoint
{
    public class Handle
    {
        public Handle(Point coordinate)
        {
            Coordinate = coordinate;
            Selected = false;
        }
        public Point Coordinate { get; set; }
        public bool Selected { get; set; }

        public void Draw(Graphics graphics)
        {
            var brush = new SolidBrush(Color.White);
            var pen = new Pen(Color.White, 1);
            graphics.DrawEllipse(pen, Coordinate.X - 2, Coordinate.Y - 2, 4, 4);
            graphics.FillEllipse(brush, Coordinate.X - 2, Coordinate.Y - 2, 4, 4);
        }
    }
}
