using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace FakePowerPoint
{
 public class Eclipse : IShape
    {
        // Constants for property names
        private const string COLOR = "Color";
        private const string COORDINATES = "Coordinates";

        // Private fields to hold values for color, shape type and coordinates
        private Color _color;
        private ShapeType _shapeType;
        private List<Point> _coordinates;

        // Event to notify when a property changes
        public event PropertyChangedEventHandler PropertyChanged;

        // Property for shape type. It is read-only and cannot be changed.
        public ShapeType ShapeType
        {
            get => _shapeType;
            // setter throws an exception
            set => throw new InvalidOperationException("The shape type cannot be changed");
        }

        // Property for coordinates. It is read-only and cannot be directly changed
        public string Coordinates
        {
            get => GetCoordinates();
            set => throw new InvalidOperationException("The coordinates cannot be changed directly");
        }

        // Property for color of the eclipse. Notifies if it changes.
        public Color Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Selected { get; set; }

        // Constructor for eclipse with optional parameters
        public Eclipse(int x1 = 0, int x2 = 0, int y1 = 0, int y2 = 0)
        {
            _color = Color.FromArgb(255, 132, 120, 112);  // default color
            _shapeType = ShapeType.Eclipse; // default shape type
            _coordinates = new List<Point> { new Point(x1, y1), new Point(x2, y2) }; // coordinate list
        }

        // Draws itself using the presentation model
        public void Draw(Graphics graphics, int penWidth)
        {
            graphics.DrawEllipse(new Pen(_color, penWidth), ConvertToRectangle());
        }

        public void DrawHandle(Graphics graphics)
        {
            foreach (var handle in Handles)
            {
                graphics.DrawEllipse(new Pen(Color.White, 1), handle.Coordinate.X, handle.Coordinate.Y, 5, 5);
            }
        }

        // Returns coordinates as a formatted string
        public string GetCoordinates()
        {
            return $"({_coordinates[0].X}, {_coordinates[0].Y}),\n({_coordinates[1].X}, {_coordinates[1].Y})";
        }

        public List<Handle> Handles { get; set;}

        // Converts coordinates to a Rectangle object
        private System.Drawing.Rectangle ConvertToRectangle()
        {
            return new System.Drawing.Rectangle(_coordinates[0].X, _coordinates[0].Y,
                _coordinates[1].X - _coordinates[0].X, _coordinates[1].Y - _coordinates[0].Y);
        }

        // Method to raise the PropertyChanged event
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
