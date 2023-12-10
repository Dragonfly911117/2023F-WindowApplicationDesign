using System;
using System.Collections.Generic;
using System.Drawing;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Model.Shape.Factory
{
    public abstract class ShapeFactory
    {
        // Method to create a shape
        public abstract Shape CreateShape(Tuple<Point, Point> coordinates = null, Color color = default(Color));
    }
}
