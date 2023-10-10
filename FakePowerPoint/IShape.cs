using System;
using System.Collections.Generic;
using System.Drawing;

namespace FakePowerPoint
{
    public enum ShapeType
    {
        Undefined,
        Rectangle,
        Line
    }


    public interface IShape
    {
        Color Color { get; set; }
        ShapeType ShapeType { get; set; }
        List<Tuple<int, int>> Coordinates { get; set; }

        // brief: Draw the shape
        void Draw(IShapeDrawer drawer);

        // brief: Get the coordinates of the shape
        string GetCoordinates();


    }

    public abstract class ShapeFactory
    {
        // brief: Create a shape
        public static IShape CreateShape(string shapeType)
        {
            return shapeType switch
            {
                "Rectangle" => new Rectangle(),
                "Line" => new Line(),
                _ => throw new ArgumentException("Invalid shape type")
            };
        }
    }
}
