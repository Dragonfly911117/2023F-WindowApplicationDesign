using System;
using System.Drawing;

namespace FakePowerPoint.Model.Shape.Factory
{
    public class LineFactory : ShapeFactory
    {
        public override Shape CreateShape(Tuple<Point, Point> coordinates = null, Color color = default(Color))
        {
            return new Shapes.Line(coordinates, color);
        }
    }
}
