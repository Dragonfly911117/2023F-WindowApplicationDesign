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
            var x1 = GenerateRandomNumber(0, 1358);
            var y1 = GenerateRandomNumber(0, 1052);
            var x2 = GenerateRandomNumber(x1, 1358);
            var y2 = GenerateRandomNumber(y1, 1052);
            return shapeType switch
            {
                "Rectangle" => new Rectangle(x1, x2, y1, y2),
                "Line" => new Line(x1, x2, y1, y2),
                _ => throw new ArgumentException("Invalid shape type")
            };
        }

        // brief: Generate a random number
        private static int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private static readonly Random _random = new Random();
    }
}
