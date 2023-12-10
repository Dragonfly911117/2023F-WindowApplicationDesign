using System;
using System.Drawing;

namespace FakePowerPoint.Model.Shape.Factory
{
    public class LineFactory : ShapeFactory
    {
        protected override void ReorderCoordinates(ref Tuple<Point, Point> coordinates)
        {
            if (coordinates.Item1.X <= coordinates.Item2.X)
                return;
            var x1 = coordinates.Item1.X;
            var y1 = coordinates.Item1.Y;
            var x2 = coordinates.Item2.X;
            var y2 = coordinates.Item2.Y;
            Swap(ref x1, ref x2);
            Swap(ref y1, ref y2);
            coordinates = new Tuple<Point, Point>(new Point(x1, y1), new Point(x2, y2));
        }

        public override Shape CreateShape(Tuple<Point, Point> coordinates = null, Color color = default(Color))
        {
            ReorderCoordinates(ref coordinates);
            return new Shapes.Line(coordinates, color);
        }
    }
}
