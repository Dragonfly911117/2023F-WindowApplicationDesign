using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace FakePowerPoint
{
    public enum ShapeType
    {
        Undefined,
        Line,
        Rectangle,
        Eclipse
    }


    public interface IShape : INotifyPropertyChanged
    {
        ShapeType ShapeType { get; set; }

        // the property is string for better binding to the datagridview. There's gonna be list of tuples in the child classes
        string Coordinates { get; set; }

        Color Color { get; set; }

        // brief: Draw the shape
        void Draw(PresentationModel drawer);

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

        public static IShape CreateShape(string shapeType, List<int> coordinates)
        {
            var x1 = coordinates[0];
            var y1 = coordinates[1];
            var x2 = coordinates[2];
            var y2 = coordinates[3];
            return shapeType switch
            {
                RECTANGLE => new Rectangle(x1, x2, y1, y2),
                LINE => new Line(x1, x2, y1, y2),
                ECLIPSE => new Eclipse(x1, x2, y1, y2),
                _ => throw new ArgumentException("Invalid shape type")
            };
        }
        public static IShape CreateShape(string shapeType, List<int> startCoordinates, List<int> endCoordinates )
        {
            // call the public static IShape CreateShape(string shapeType, List<int> coordinates) method
            var coordinates = new List<int>();
            coordinates.AddRange(startCoordinates);
            coordinates.AddRange(endCoordinates);
            return CreateShape(shapeType, coordinates);
        }

        // brief: Generate a random number
        private static int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public const string NOT_DEFINED = "Undefined";
        public const string RECTANGLE = "Rectangle";
        public const string LINE = "Line";
        public const string ECLIPSE = "Eclipse";

        private static readonly Random _random = new Random();

        public static Dictionary<ShapeType, string> ShapeTypeDescriptions = new Dictionary<ShapeType, string>
        {
            { ShapeType.Undefined, NOT_DEFINED },
            { ShapeType.Line, LINE },
            { ShapeType.Rectangle, RECTANGLE },
            { ShapeType.Eclipse, ECLIPSE }
        };
    }
}
