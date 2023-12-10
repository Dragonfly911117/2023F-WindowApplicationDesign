using System;
using System.Drawing;

namespace FakePowerPoint.Model.Shape.Factory
{
    public class EllipseFactory : ShapeFactory
    {
        public override Shape CreateShape(Tuple<Point, Point> coordinates = null, Color color = default(Color))
        {
            return new Shapes.Ellipse(coordinates, color);
        }
    }
}
