using System;
using System.Collections.Generic;
using System.Drawing;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Model.Shape.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(Tuple<Point, Point> coordinates)
        {
            Coordinates = coordinates;
            {
                var x1 = Coordinates.Item1.X;
                var y1 = Coordinates.Item1.Y;
                var x2 = Coordinates.Item2.X;
                var y2 = Coordinates.Item2.Y;

                Handles = new List<Handle>
                {
                    new Handle(new Point(x1, y1), HandlePosition.TopLeft),
                    new Handle(new Point((x1 + x2) / 2, y1), HandlePosition.TopMiddle),
                    new Handle(new Point(x2, y1), HandlePosition.TopRight),
                    new Handle(new Point(x1, (y1 + y2) / 2), HandlePosition.MiddleLeft),
                    new Handle(new Point(x2, (y1 + y2) / 2), HandlePosition.MiddleRight),
                    new Handle(new Point(x1, y2), HandlePosition.BottomLeft),
                    new Handle(new Point((x1 + x2) / 2, y2), HandlePosition.BottomMiddle),
                    new Handle(new Point(x2, y2), HandlePosition.BottomRight)
                };
                Color = Color.FromArgb(255, 132, 120, 222);
            }
        }

        public void Draw(Graphics graphics)
        {
            var x1 = Coordinates.Item1.X;
            var y1 = Coordinates.Item1.Y;
            var x2 = Coordinates.Item2.X;
            var y2 = Coordinates.Item2.Y;
            graphics.DrawRectangle(pen: new Pen(Color, 1 << 1 << 1), x: x1, y: y1, width: x2 - x1, height: y2 - y1);
            if (Selected)
            {
                DrawHandles(graphics);
            }
        }
    }
}
