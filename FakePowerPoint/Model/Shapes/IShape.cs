using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace FakePowerPoint
{
    // Enum to represent different types of shapes
    public enum ShapeType
    {
        Selection,
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
        public void Draw(IGraphics graphics, int penWidth);

        // DrawHandle method to be implemented by concrete shape classes
        public void DrawHandle(IGraphics graphics);

        // Method to get string representation of coordinates
        string GetCoordinates();

        // Method to check if a point is inside a shape
        bool IsPointOnShape(Point point);

        List<Handle> Handles { get; set; }
    }

    // Abstract factory class to create the shapes

}
