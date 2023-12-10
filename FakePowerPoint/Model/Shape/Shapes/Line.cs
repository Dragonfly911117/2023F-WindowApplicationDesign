using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Model.Shape.Shapes
{
    public class Line : Shape
    {
        protected void ReorderCoordinates(ref Tuple<Point, Point> coordinates)
        {
        }

        public Line(Tuple<Point, Point> coordinates, Color color = default(Color))
        {
            Coordinates = coordinates ?? new Tuple<Point, Point>(new Point(0, 0), new Point(0, 0));
            Color = color == default ? Color.Violet : color;
            Handles = new List<Handle>
            {
                new Handle(Coordinates.Item1, HandlePosition.TopLeft),
                new Handle(Coordinates.Item2, HandlePosition.BottomRight)
            };
        }


        public override void Draw(Graphics graphics)
        {
            var x1 = Coordinates.Item1.X;
            var y1 = Coordinates.Item1.Y;
            var x2 = Coordinates.Item2.X;
            var y2 = Coordinates.Item2.Y;
            graphics.DrawLine(pen: new Pen(Color, 1 << 1 << 1), x1: x1, y1: y1, x2: x2, y2: y2);
            if (Selected)
            {
                DrawHandles(graphics);
            }
        }
    }
}
