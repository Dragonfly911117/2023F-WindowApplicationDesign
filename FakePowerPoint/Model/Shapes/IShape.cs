using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace FakePowerPoint
{
    public enum ShapeType
    {
        Undefined,
        Rectangle,
        Line,
        Eclipse
    }


    public interface IShape : INotifyPropertyChanged
    {
        ShapeType ShapeType { get; set; }

        // the property is string for better binding to the datagridview. There's gonna be list of tuples in the child classes
        String Coordinates { get; set; }

        Color Color { get; set; }

        // brief: Draw the shape
        void Draw(Info drawer);

        // brief: Get the coordinates of the shape
        public string GetCoordinates();
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
                RECTANGLE => new Rectangle(x1, x2, y1, y2),
                LINE => new Line(x1, x2, y1, y2),
                ECLIPSE => new Eclipse(x1, x2, y1, y2),
                _ => throw new ArgumentException("Invalid shape type")
            };
        }

        // brief: Generate a random number
        private static int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public const String NOT_DEFINED = "Undefined";
        public const String RECTANGLE = "Rectangle";
        public const String LINE = "Line";
        public const String ECLIPSE = "Eclipse";

        public static Dictionary<ShapeType, String> ShapeTypeDescriptions = new Dictionary<ShapeType, string>
        {
            {ShapeType.Undefined, NOT_DEFINED},
            {ShapeType.Rectangle, RECTANGLE},
            {ShapeType.Line, LINE},
            {ShapeType.Eclipse, ECLIPSE}
        };

        private static readonly Random _random = new Random();
    }
}
