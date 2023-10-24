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
    ShapeType ShapeType { get; }
    string Coordinates { get; }
    Color Color { get; set; }
    void Draw(PresentationModel drawer);
    string GetCoordinates();
}

    public abstract class ShapeFactory
    {
        public static IShape CreateShape(ShapeType shapeType)
        {
            var x1 = GenerateRandomNumber(0, 1358);
            var y1 = GenerateRandomNumber(0, 1052);
            var x2 = GenerateRandomNumber(0, 1358);
            var y2 = GenerateRandomNumber(0, 1052);
            return shapeType switch
            {
                ShapeType.Rectangle => new Rectangle(x1, x2, y1, y2),
                ShapeType.Line => new Line(x1, x2, y1, y2),
                ShapeType.Eclipse => new Eclipse(x1, x2, y1, y2),
                _ => throw new ArgumentException("Invalid shape type")
            };
        }

        public static IShape CreateShape(ShapeType shapeType, List<int> coordinates)
        {
            var x1 = coordinates[0];
            var y1 = coordinates[1];
            var x2 = coordinates[2];
            var y2 = coordinates[3];
            return shapeType switch
            {
                ShapeType.Rectangle => new Rectangle(x1, x2, y1, y2),
                ShapeType.Line => new Line(x1, x2, y1, y2),
                ShapeType.Eclipse => new Eclipse(x1, x2, y1, y2),
                _ => throw new ArgumentException("Invalid shape type")
            };
        }

        public static IShape CreateShape(ShapeType shapeType, List<int> startCoordinates, List<int> endCoordinates )
        {
            var coordinates = new List<int>();
            coordinates.AddRange(startCoordinates);
            coordinates.AddRange(endCoordinates);
            return CreateShape(shapeType, coordinates);
        }

        private static int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private static readonly Random _random = new Random();
    }
}
