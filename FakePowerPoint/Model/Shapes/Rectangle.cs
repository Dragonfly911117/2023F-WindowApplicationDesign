using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace FakePowerPoint
{
    public class Rectangle : IShape, INotifyPropertyChanged
    {
        private const string COLOR = "Color";
        private Color _color;
        private readonly ShapeType _shapeType;
        public List<Point> Coordinates { get; set; }

        public event PropertyChangedEventHandler PropertyChanged; // Event for handling property changes.

        public ShapeType ShapeType
        {
            get => _shapeType;
            set =>
                throw new InvalidOperationException("The shape type cannot be changed"); // The ShapeType is read-only.
        }


        public Color Color
        {
            get => _color;
            // Color is not readonly as it can be updated after shape's creation. Also, the OnPropertyChanged event is fired here if the color changes.
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

        // Method to swap two integers
        private static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        /* The Rectangle's constructor.
         * It initializes the rectangle's shape type, coordinates, and color. */
        public Rectangle(int x1 = 0, int x2 = 0, int y1 = 0, int y2 = 0)
        {
            _color = Color.FromArgb(255, 132, 120, 222);
            _shapeType = ShapeType.Rectangle;
            if (x1 > x2) Swap(ref x1, ref x2);
            if (y1 > y2) Swap(ref y1, ref y2);
            Coordinates = new List<Point> { new Point(x1, y1), new Point(x2, y2) };
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

        // Calls DrawRectangle method of the presentation model to draw the rectangle.
        public void Draw(Graphics graphics, int penWidth)
        {
            _width = penWidth;
            graphics.DrawRectangle(new Pen(_color, penWidth), ConvertToRectangle());
            if (Selected)
            {
                DrawHandle(graphics);
            }
        }

        // Draws the handles of the rectangle.
        public void DrawHandle(Graphics graphics)
        {
            foreach (var handle in Handles)
            {
                handle.Draw(graphics);
            }
        }

        // Returns the string format of coordinates.
        public string GetCoordinates()
        {
            return $"({Coordinates[0].X}, {Coordinates[0].Y}),\n({Coordinates[1].X}, {Coordinates[1].Y})";
        }

        // Checks if a point is on the rectangle.
        public bool IsPointOnShape(Point point)
        {
            var rectangle = ConvertToRectangle();
            var toleranceRectangle = new System.Drawing.Rectangle(rectangle.X - (int)SELECT_TOLERANCE,
                rectangle.Y - (int)SELECT_TOLERANCE, rectangle.Width + (int)SELECT_TOLERANCE * 2,
                rectangle.Height + (int)SELECT_TOLERANCE * 2);
            return toleranceRectangle.Contains(point);
        }

        public List<Handle> Handles { get; set; }
        public int _width { get; private set; }

        /* Converts the coordinates to a System.Drawing.Rectangle object.
         * It determines the top-left point and the bottom-right point to calculate the rectangle. */
        private System.Drawing.Rectangle ConvertToRectangle()
        {
            var x1 = Math.Min(Coordinates[0].X, Coordinates[1].X);
            var x2 = Math.Max(Coordinates[0].X, Coordinates[1].X);
            var y1 = Math.Min(Coordinates[0].Y, Coordinates[1].Y);
            var y2 = Math.Max(Coordinates[0].Y, Coordinates[1].Y);
            return new System.Drawing.Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /* Triggers the PropertyChanged event.
         * This is used to inform any observers that a property value has changed. */
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private const uint SELECT_TOLERANCE = 5;
    }
}
