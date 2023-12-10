using System;
using System.Collections.Generic;
using System.Drawing;
using FakePowerPoint.Model.Enums;
using FakePowerPoint.Model.Shape.Shapes;

namespace FakePowerPoint.Model.Shape.Factory
{
    public class RectangleFactory: ShapeFactory
    {
        public override Shape CreateShape( Tuple<Point, Point> coordinates = null, Color color = default(Color))
        {
            ReorderCoordinates(ref coordinates);
            return new Shapes.Rectangle(coordinates, color);
        }
    }
}
