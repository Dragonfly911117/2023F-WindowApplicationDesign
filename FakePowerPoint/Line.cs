using System;
using System.Collections.Generic;
using System.Drawing;

namespace FakePowerPoint
{
    public class Line : IShape
    {
        public Color Color { get; set; } = Color.FromArgb(153, 132, 120, 222);
        public ShapeType ShapeType { get; set; } = ShapeType.Line;
        public List<Tuple<int, int>> Coordinates { get; set; } = new List<Tuple<int, int>>();

        public Line()
        {
            // make top left and bottom right  random from x = 0~1920, y = 0~1080
            var x1 = Utilities.RandomNumber(0, 1920);
            var y1 = Utilities.RandomNumber(0, 1080);
            var x2 = Utilities.RandomNumber(0, 1920);
            var y2 = Utilities.RandomNumber(0, 1080);

            Coordinates.Add(new Tuple<int, int>(x1, y1));
            Coordinates.Add(new Tuple<int, int>(x2, y2));
        }

        public void Draw(IShapeDrawer drawer)
        {
            drawer.DrawLine(Color, Coordinates);
        }
    }
}
