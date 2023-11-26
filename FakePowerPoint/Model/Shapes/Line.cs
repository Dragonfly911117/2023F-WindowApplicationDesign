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
        public void Draw(IGraphics graphics, int penWidth)
        {
            graphics.DrawLine(new Pen(_color, penWidth), Coordinates[0].X, Coordinates[0].Y, Coordinates[1].X,
                Coordinates[1].Y);
            if (Selected)
            {
                DrawHandle(graphics);
            }
        }

        // Method to draw the handles
        public void DrawHandle(IGraphics graphics)
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

        // Method to get the distance from a point to the line
        private double DistanceFromPoint(Point point)
        {
            var x1 = Coordinates[0].X;
            var y1 = Coordinates[0].Y;
            var x2 = Coordinates[1].X;
            var y2 = Coordinates[1].Y;


            return Math.Abs((x2-x1)*(y1-point.Y)-(x1-point.X)*(y2-y1))/Math.Sqrt((x2-x1)*(x2-x1)+(y2-y1)*(y2-y1));

        }

        // Method to check if a point is on the line
        public bool IsPointOnShape(Point point)
        {
            if (DistanceFromPoint(point) <= SELECT_TOLERANCE)
            {
                return true;
            }
            return false;
        }

        private const uint SELECT_TOLERANCE = 5;

        public List<Handle> Handles { get; set; }

        // Method to call the PropertyChanged event
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
