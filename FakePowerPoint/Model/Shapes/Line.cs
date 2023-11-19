using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace FakePowerPoint
{
    // Line class which implements IShape interface
    public class Line : IShape
    {
        // Constant for color property name
        private const string COLOR = "Color";

        // Variable to hold the color value of the line
        private Color _color;

        // Variable to hold the ShapeType enumeration value
        private ShapeType _shapeType;

        // List to hold the coordinates of the line
        private List<Point> _coordinates;

        // Event to be triggered when a property value changes
        public event PropertyChangedEventHandler PropertyChanged;

        // Property for ShapeType encapsulating _shapeType
        public ShapeType ShapeType
        {
            get => _shapeType;
            // Prevent modification of shape type once set
            set => throw new InvalidOperationException("The shape type cannot be changed");
        }

        // Property to get the string value of coordinates
        public string Coordinates
        {
            get => GetCoordinates();
            // Prevent modification of coordinates directly
            set => throw new InvalidOperationException("The coordinates cannot be changed directly");
        }

        // Property for color encapsulating _color with INotifyPropertyChanged implementation
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

        // Constructor of Line class
        public Line(int x1 = 0, int x2 = 0, int y1 = 0, int y2 = 0)
        {
            _color = Color.FromArgb(255, 123, 0, 33);
            _shapeType = ShapeType.Line;
            _coordinates = new List<Point>();
            _coordinates.Add(new Point(x1, y1));
            _coordinates.Add(new Point(x2, y2));
        }

        // Method to draw a line
        public void Draw(Graphics graphics, int penWidth)
        {
            graphics.DrawLine(new Pen(_color, penWidth), _coordinates[0].X, _coordinates[0].Y,
                _coordinates[1].X, _coordinates[1].Y);
        }

        public void DrawHandle(Graphics graphics)
        {
            foreach (var handle in Handles)
            {
                graphics.DrawEllipse(new Pen(Color.White, 1), handle.Coordinate.X, handle.Coordinate.Y, 5, 5);
            }
        }

        // Method to get the string representation of the coordinates
        public string GetCoordinates()
        {
            return
                $"({_coordinates[0].X}, {_coordinates[0].Y}),\n({_coordinates[1].X}, {_coordinates[1].Y})";
        }

        public List<Handle> Handles { get; set;}

        // Method to call the PropertyChanged event
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
