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
        public List<Point> Coordinates { get; set; }

        // Event to be triggered when a property value changes
        public event PropertyChangedEventHandler PropertyChanged;

        // Property for ShapeType encapsulating _shapeType
        public ShapeType ShapeType
        {
            get => _shapeType;
            // Prevent modification of shape type once set
            set => throw new InvalidOperationException("The shape type cannot be changed");
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
            Coordinates = new List<Point>();
            Coordinates.Add(new Point(x1, y1));
            Coordinates.Add(new Point(x2, y2));
            Handles = new List<Handle>
            {
                new Handle(new Point(x1, y1)),
                new Handle(new Point((x1 + x2) / 2, (y1 + y2) / 2)),
                new Handle(new Point(x2, y2))
            };
        }

        // Method to draw a line
        public void Draw(Graphics graphics, int penWidth)
        {
            graphics.DrawLine(new Pen(_color, penWidth), Coordinates[0].X, Coordinates[0].Y, Coordinates[1].X,
                Coordinates[1].Y);
            if (Selected)
            {
                DrawHandle(graphics);
            }
        }

        public void DrawHandle(Graphics graphics)
        {
            foreach (var handle in Handles)
            {
                handle.Draw(graphics);
            }
        }

        // Method to get the string representation of the coordinates
        public string GetCoordinates()
        {
            return $"({Coordinates[0].X}, {Coordinates[0].Y}),\n({Coordinates[1].X}, {Coordinates[1].Y})";
        }

        public bool IsPointOnShape(Point point)
        {
            var x1 = Coordinates[0].X;
            var y1 = Coordinates[0].Y;
            var x2 = Coordinates[1].X;
            var y2 = Coordinates[1].Y;

            var xMin = Math.Min(x1, x2);
            var xMax = Math.Max(x1, x2);
            var yMin = Math.Min(y1, y2);
            var yMax = Math.Max(y1, y2);

            if (xMin - SELECT_TOLERANCE <= point.X && point.X <= xMax + SELECT_TOLERANCE &&
                yMin - SELECT_TOLERANCE <= point.Y && point.Y <= yMax + SELECT_TOLERANCE)
            {
                return true;
            }

            return false;
        }

        private const uint SELECT_TOLERANCE = 5;

        public List<Handle> Handles { get; set; }
        public int _width { get; }

        // Method to call the PropertyChanged event
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
