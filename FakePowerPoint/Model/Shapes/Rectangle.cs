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
        private List<Point> _coordinates;

        public event PropertyChangedEventHandler PropertyChanged; // Event for handling property changes.

        public ShapeType ShapeType
        {
            get => _shapeType;
            set =>
                throw new InvalidOperationException("The shape type cannot be changed"); // The ShapeType is read-only.
        }

        public string Coordinates
        {
            get => GetCoordinates(); // The Coordinates is read-only.
            set => throw new InvalidOperationException("The coordinates cannot be changed directly");
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

        public bool Selected { get; set; } = true; // for test purpose TODO: remove the default val

        /* The Rectangle's constructor.
         * It initializes the rectangle's shape type, coordinates, and color. */
        public Rectangle(int x1 = 0, int x2 = 0, int y1 = 0, int y2 = 0)
        {
            _color = Color.FromArgb(255, 132, 120, 222);
            _shapeType = ShapeType.Rectangle;
            _coordinates = new List<Point> { new Point(x1, y1), new Point(x2, y2) };
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
            graphics.DrawRectangle(new Pen(_color, penWidth), ConvertToRectangle());
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

        // Returns the string format of coordinates.
        public string GetCoordinates()
        {
            return $"({_coordinates[0].X}, {_coordinates[0].Y}),\n({_coordinates[1].X}, {_coordinates[1].Y})";
        }

        public List<Handle> Handles { get; set; }

        /* Converts the coordinates to a System.Drawing.Rectangle object.
         * It determines the top-left point and the bottom-right point to calculate the rectangle. */
        private System.Drawing.Rectangle ConvertToRectangle()
        {
            var x1 = Math.Min(_coordinates[0].X, _coordinates[1].X);
            var x2 = Math.Max(_coordinates[0].X, _coordinates[1].X);
            var y1 = Math.Min(_coordinates[0].Y, _coordinates[1].Y);
            var y2 = Math.Max(_coordinates[0].Y, _coordinates[1].Y);
            return new System.Drawing.Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /* Triggers the PropertyChanged event.
         * This is used to inform any observers that a property value has changed. */
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
