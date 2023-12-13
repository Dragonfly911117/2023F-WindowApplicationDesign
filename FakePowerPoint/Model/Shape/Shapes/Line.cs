using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Model.Shape.Shapes
{
    public class Line : Shape
    {
        public Line(Tuple<Point, Point> coordinates, Color color = default(Color))
        {
            ShapeType = Enums.ShapeType.Line;
            Coordinates = coordinates ?? new Tuple<Point, Point>(new Point(0, 0), new Point(0, 0));
            Color = color == default ? Color.Violet : color;
            var x1 = Coordinates.Item1.X;
            var y1 = Coordinates.Item1.Y;
            var x2 = Coordinates.Item2.X;
            var y2 = Coordinates.Item2.Y;
            Handles = new List<Handle>
            {
                new(new Point(x1, y1), HandlePosition.TopLeft),
                new(new Point(x2, y2), HandlePosition.BottomRight)
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

        public override bool IfShapeClicked(Point point)
        {
            return CalculateDistanceToPoint(point) < 10;
        }

        int CalculateDistanceToPoint(Point point)
        {
            var x1 = Coordinates.Item1.X;
            var y1 = Coordinates.Item1.Y;
            var x2 = Coordinates.Item2.X;
            var y2 = Coordinates.Item2.Y;
            var x0 = point.X;
            var y0 = point.Y;
            var a = y2 - y1;
            var b = x1 - x2;
            var c = x2 * y1 - x1 * y2;
            var distance = Math.Abs(a * x0 + b * y0 + c) / Math.Sqrt(a * a + b * b);
            return (int)distance;
        }

        public override void Resize(Size size, HandlePosition handlePosition = HandlePosition.BottomRight)
        {
            var dx = size.Width; //- currSize.Width;
            var dy = size.Height; // - currSize.Height;
            var x1 = Coordinates.Item1.X;
            var y1 = Coordinates.Item1.Y;
            var x2 = Coordinates.Item2.X;
            var y2 = Coordinates.Item2.Y;

            if (new[] { HandlePosition.TopLeft, HandlePosition.MiddleLeft, HandlePosition.BottomLeft }.Contains(
                    handlePosition))
            {
                x1 += dx;
            }

            if (new[] { HandlePosition.TopRight, HandlePosition.MiddleRight, HandlePosition.BottomRight }.Contains(
                    handlePosition))
            {
                x2 += dx;
            }

            if (new[] { HandlePosition.TopLeft, HandlePosition.TopMiddle, HandlePosition.TopRight }.Contains(
                    handlePosition))
            {
                y1 += dy;
            }

            if (new[] { HandlePosition.BottomLeft, HandlePosition.BottomMiddle, HandlePosition.BottomRight }.Contains(
                    handlePosition))
            {
                y2 += dy;
            }

            // check if coojdinates are in correct order
            if (x1 > x2 || y1 > y2)
            {
                (x1, x2) = (x2, x1);
                (y1, y2) = (y2, y1);
            }


            Coordinates = new Tuple<Point, Point>(new Point(x1, y1), new Point(x2, y2));

            Handles = new List<Handle>
            {
                new(new Point(x1, y1), HandlePosition.TopLeft),
                new(new Point(x2, y2), HandlePosition.BottomRight)
            };
            OnPropertyChanged(nameof(Coordinates));
        }
    }
}
