using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Model.Shape
{
    public abstract class Shape : INotifyPropertyChanged
    {
        protected ShapeType ShapeType;
        public string ShapeTypeString => ShapeType.ToString();
        protected Tuple<Point, Point> Coordinates;

        public string CoordinatesString =>
            $"({Coordinates.Item1.X}, {Coordinates.Item1.Y}), ({Coordinates.Item2.X}, {Coordinates.Item2.Y})";

        protected Color Color;
        public string ColorString => $"{Color.R}, {Color.G}, {Color.B}, {Color.A}";


        protected bool Selected = false;
        protected List<Handle> Handles = new List<Handle>();

        protected Shape()
        {
        }

        protected Shape(ShapeType shapeType)
        {
            ShapeType = shapeType;
        }

        public Tuple<Point, Point> GetCoordinates()
        {
            return Coordinates ?? throw new InvalidOperationException(Properties.Resources.Property_is_not_set);
        }

        public void SetCoordinates(Tuple<Point, Point> coordinates)
        {
            Coordinates = coordinates;
        }

        public Color GetColor()
        {
            return Color;
        }

        public override string ToString()
        {
            return new StringBuilder(
                    @"{_shapeType} {_coordinates.Item1.X} {_coordinates.Item1.Y} {_coordinates.Item2.X} {_coordinates.Item2.Y} {_color.R} {_color.G} {_color.B} {_color.A}")
                .ToString();
        }

        public ShapeType GetShapeType()
        {
            return ShapeType;
        }

        public bool GetSelected()
        {
            return Selected;
        }

        public void SetSelected(bool selected)
        {
            Selected = selected;
        }

        public void SetColor(Color color)
        {
            Color = color;
            OnPropertyChanged(nameof(Color));
        }

        public HandlePosition? IfHandleClicked(Point coordinates)
        {
            foreach (var handle in Handles.Where(handle => handle.IfClicked(coordinates)))
            {
                return handle.GetPosition();
            }

            return null;
        }

        public bool IfShapeClicked(Point coordinates)
        {
            return coordinates.X >= Coordinates.Item1.X && coordinates.X <= Coordinates.Item2.X &&
                   coordinates.Y >= Coordinates.Item1.Y && coordinates.Y <= Coordinates.Item2.Y;
        }

        public void Move(Point coordinates)
        {
            var x1 = Coordinates.Item1.X;
            var y1 = Coordinates.Item1.Y;
            var x2 = Coordinates.Item2.X;
            var y2 = Coordinates.Item2.Y;

            var dx = coordinates.X - x1;
            var dy = coordinates.Y - y1;

            Coordinates = new Tuple<Point, Point>(new Point(x1 + dx, y1 + dy), new Point(x2 + dx, y2 + dy));

            Handles.ForEach(handle => handle.Move(new Point(dx, dy)));
            OnPropertyChanged(nameof(Coordinates));
        }

        public virtual void Resize(Size size, HandlePosition handlePosition = HandlePosition.BottomRight)
        {
            var currSize = new Size(Coordinates.Item2.X - Coordinates.Item1.X,
                Coordinates.Item2.Y - Coordinates.Item1.Y);
            var dx = size.Width - currSize.Width;
            var dy = size.Height - currSize.Height;
            var x1 = Coordinates.Item1.X;
            var y1 = Coordinates.Item1.Y;
            var x2 = Coordinates.Item2.X;
            var y2 = Coordinates.Item2.Y;

            if (new[] { HandlePosition.TopLeft, HandlePosition.MiddleLeft, HandlePosition.BottomLeft }.Contains(
                    handlePosition))
            {
                x1 -= dx;
            }

            if (new[] { HandlePosition.TopRight, HandlePosition.MiddleRight, HandlePosition.BottomRight }.Contains(
                    handlePosition))
            {
                x2 += dx;
            }

            if (new[] { HandlePosition.TopLeft, HandlePosition.TopMiddle, HandlePosition.TopRight }.Contains(
                    handlePosition))
            {
                y1 -= dy;
            }

            if (new[] { HandlePosition.BottomLeft, HandlePosition.BottomMiddle, HandlePosition.BottomRight }.Contains(
                    handlePosition))
            {
                y2 += dy;
            }

            Coordinates = new Tuple<Point, Point>(new Point(x1, y1), new Point(x2, y2));

            Handles = new List<Handle>
            {
                new(new Point(x1, y1), HandlePosition.TopLeft),
                new(new Point((x1 + x2) / 2, y1), HandlePosition.TopMiddle),
                new(new Point(x2, y1), HandlePosition.TopRight),
                new(new Point(x1, (y1 + y2) / 2), HandlePosition.MiddleLeft),
                new(new Point(x2, (y1 + y2) / 2), HandlePosition.MiddleRight),
                new(new Point(x1, y2), HandlePosition.BottomLeft),
                new(new Point((x1 + x2) / 2, y2), HandlePosition.BottomMiddle),
                new(new Point(x2, y2), HandlePosition.BottomRight)
            };
            OnPropertyChanged(nameof(Coordinates));
        }


        public abstract void Draw(Graphics graphics);

        protected void DrawHandles(Graphics graphics)
        {
            Handles.ForEach(handle => handle.Draw(graphics));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
