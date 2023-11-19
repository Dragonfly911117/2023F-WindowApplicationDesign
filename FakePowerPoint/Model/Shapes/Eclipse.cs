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
        public List<Point> Coordinates { get; set; }

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

        private static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        // Constructor for eclipse with optional parameters
        public Eclipse(int x1 = 0, int x2 = 0, int y1 = 0, int y2 = 0)
        {
            _color = Color.FromArgb(255, 132, 120, 112);  // default color
            _shapeType = ShapeType.Eclipse; // default shape type
            if (x1 > x2)  Swap(ref x1, ref x2);
            if (y1 > y2)  Swap(ref y1, ref y2);
            Coordinates = new List<Point> { new Point(x1, y1), new Point(x2, y2) }; // coordinate list
            Handles = new List<Handle>
            {
                new Handle(new Point(x1, y1)),
                new Handle(new Point((x1 + x2) / 2, y1)),
                new Handle(new Point(x2, y1)),
                new Handle(new Point(x1, (y1 + y2) / 2)),
                new Handle(new Point(x2, y2)),
                new Handle(new Point((x1 + x2) / 2, y2)),
                new Handle(new Point(x1, y2)),
                new Handle(new Point(x2, (y1 + y2) / 2))
            };
        }

        // Draws itself using the presentation model
        public void Draw(Graphics graphics, int penWidth)
        {
            graphics.DrawEllipse(new Pen(_color, penWidth), ConvertToRectangle());
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

        // Returns coordinates as a formatted string
        public string GetCoordinates()
        {
            return $"({Coordinates[0].X}, {Coordinates[0].Y}),\n({Coordinates[1].X}, {Coordinates[1].Y})";
        }

        public bool IsPointOnShape(Point point)
        {
            var rectangle = ConvertToRectangle();
            var toleranceRectangle = new System.Drawing.Rectangle(rectangle.X - (int)SELECT_TOLERANCE,
                rectangle.Y - (int)SELECT_TOLERANCE, rectangle.Width + (int)SELECT_TOLERANCE * 2,
                rectangle.Height + (int)SELECT_TOLERANCE * 2);
            return toleranceRectangle.Contains(point);
        }

        public List<Handle> Handles { get; set;}


        // Converts coordinates to a Rectangle object
        private System.Drawing.Rectangle ConvertToRectangle()
        {
            return new System.Drawing.Rectangle(Coordinates[0].X, Coordinates[0].Y,
                Coordinates[1].X - Coordinates[0].X, Coordinates[1].Y - Coordinates[0].Y);
        }

        // Method to raise the PropertyChanged event
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private const uint SELECT_TOLERANCE = 5;
    }
}
