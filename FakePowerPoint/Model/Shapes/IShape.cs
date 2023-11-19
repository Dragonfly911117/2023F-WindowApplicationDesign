using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace FakePowerPoint
{
    // Enum to represent different types of shapes
    public enum ShapeType
    {
        Undefined,
        Line,
        Rectangle,
        Eclipse
    }

    // Interface for all types of shapes with standard properties and methods
    public interface IShape : INotifyPropertyChanged
    {
        ShapeType ShapeType { get; } // Property to get the type of shape
        string Coordinates { get; } // Property to get the coordinates of a shape

        Color Color { get; set; } // Color property of a shape

        bool Selected { get; set; } // Property to get/set the selection state of a shape

        // Draw method to be implemented by concrete shape classes
        public void Draw(Graphics graphics, int penWidth);

        // DrawHandle method to be implemented by concrete shape classes
        public void DrawHandle(Graphics graphics);

        // Method to get string representation of coordinates
        string GetCoordinates();

        List<Handle> Handles { get; set;}
    }

    // Abstract factory class to create the shapes
    public abstract class ShapeFactory
    {
        // Creates a new shape of given type with random coordinates
        public static IShape CreateShape(ShapeType shapeType)
        {
            var x1 = GenerateRandomNumber(0, 1358);
            var y1 = GenerateRandomNumber(0, 1052);
            var x2 = GenerateRandomNumber(0, 1358);
            var y2 = GenerateRandomNumber(0, 1052);

            // Select the type of shape to create based on the shapeType argument
            return shapeType switch
            {
                ShapeType.Rectangle => new Rectangle(x1, x2, y1, y2),
                ShapeType.Line => new Line(x1, x2, y1, y2),
                ShapeType.Eclipse => new Eclipse(x1, x2, y1, y2),
                _ => throw new ArgumentException("Invalid shape type")
            };
        }

        // Creates a new shape of given type with specified coordinates
        public static IShape CreateShape(ShapeType shapeType, List<int> coordinates)
        {
            var x1 = coordinates[0];
            var y1 = coordinates[1];
            var x2 = coordinates[2];
            var y2 = coordinates[3];

            // Select the type of shape to create based on the shapeType argument
            return shapeType switch
            {
                ShapeType.Rectangle => new Rectangle(x1, x2, y1, y2),
                ShapeType.Line => new Line(x1, x2, y1, y2),
                ShapeType.Eclipse => new Eclipse(x1, x2, y1, y2),
                _ => throw new ArgumentException("Invalid shape type")
            };
        }

        // Creates a new shape of a given type using start and end coordinate lists
        public static IShape CreateShape(ShapeType shapeType, List<int> startCoordinates, List<int> endCoordinates)
        {
            var coordinates = new List<int>();
            coordinates.AddRange(startCoordinates);
            coordinates.AddRange(endCoordinates);
            return CreateShape(shapeType, coordinates);
        }

        // Generates a random number within the specified range
        private static int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Private member to generate random numbers
        private static readonly Random _random = new Random();
    }
}
