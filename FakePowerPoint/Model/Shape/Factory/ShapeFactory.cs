using System;
using System.Collections.Generic;
using System.Drawing;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Model.Shape.Factory
{
    public abstract class ShapeFactory
    {
        // Method to create a shape
        protected void Swap(ref int item1, ref int item2)
        {
            item1 ^= item2;
            item2 ^= item1;
            item1 ^= item2;
        }

        protected virtual void ReorderCoordinates(ref Tuple<Point, Point> coordinates)
        {
            var x1 = coordinates.Item1.X;
            var y1 = coordinates.Item1.Y;
            var x2 = coordinates.Item2.X;
            var y2 = coordinates.Item2.Y;
            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
            }

            if (y1 > y2)
            {
                Swap(ref y1, ref y2);
            }

            coordinates = new Tuple<Point, Point>(new Point(x1, y1), new Point(x2, y2));
        }

        public abstract Shape CreateShape(Tuple<Point, Point> coordinates = null, Color color = default(Color));
    }
}
