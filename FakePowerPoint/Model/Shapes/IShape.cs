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

        // string Coordinates { get; } // Property to get the coordinates of a shape
        public List<Point> Coordinates { get; set; }

        Color Color { get; set; } // Color property of a shape

        bool Selected { get; set; } // Property to get/set the selection state of a shape

        // Draw method to be implemented by concrete shape classes
        public void Draw(Graphics graphics, int penWidth);

        // DrawHandle method to be implemented by concrete shape classes
        public void DrawHandle(Graphics graphics);

        // Method to get string representation of coordinates
        string GetCoordinates();

        bool IsPointOnShape(Point point); // Method to check if a point is inside a shape

        List<Handle> Handles { get; set; }
    }

    // Abstract factory class to create the shapes
    public abstract class ShapeFactory
    {
        public abstract IShape CreateShape(List<int> coordinates);
    }

    public class RectangleFactory : ShapeFactory
    {
        public override IShape CreateShape(List<int> coordinates)
        {
            var x1 = coordinates[0];
            var y1 = coordinates[1];
            var x2 = coordinates[2];
            var y2 = coordinates[3];
            return new Rectangle(x1, x2, y1, y2);
        }
    }

    public class LineFactory : ShapeFactory
    {
        public override IShape CreateShape(List<int> coordinates)
        {
            var x1 = coordinates[0];
            var y1 = coordinates[1];
            var x2 = coordinates[2];
            var y2 = coordinates[3];
            return new Line(x1, x2, y1, y2);
        }
    }

    public class EclipseFactory : ShapeFactory
    {
        public override IShape CreateShape(List<int> coordinates)
        {
            var x1 = coordinates[0];
            var y1 = coordinates[1];
            var x2 = coordinates[2];
            var y2 = coordinates[3];
            return new Eclipse(x1, x2, y1, y2);
        }
    }

    public interface IRandomNumberGenerator
    {
        int GenerateRandomNumber(int min, int max);
    }

    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private static readonly Random _random = new Random();

        public int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
