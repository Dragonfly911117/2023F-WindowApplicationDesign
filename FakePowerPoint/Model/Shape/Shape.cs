using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Model.Shape
{
    public abstract class Shape
    {
        protected Tuple<Point, Point> Coordinates;
        protected Color Color;
        protected ShapeType _shapeType;
        protected bool Selected = false;
        protected List<Handle> Handles = new List<Handle>();

        protected Shape()
        {
        }

        protected Shape(ShapeType shapeType)
        {
            _shapeType = shapeType;
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
            return _shapeType;
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
        }

        public virtual void Resize(Size size, HandlePosition handlePosition = HandlePosition.BottomRight)
        {
            var x1 = Coordinates.Item1.X;
            var y1 = Coordinates.Item1.Y;
            var x2 = Coordinates.Item2.X;
            var y2 = Coordinates.Item2.Y;

            if (new[] { HandlePosition.TopLeft, HandlePosition.MiddleLeft, HandlePosition.BottomLeft }.Contains(
                    handlePosition))
            {
                x1 += size.Width;
            }

            if (new[] { HandlePosition.TopRight, HandlePosition.MiddleRight, HandlePosition.BottomRight }.Contains(
                    handlePosition))
            {
                x2 += size.Width;
            }

            if (new[] { HandlePosition.TopLeft, HandlePosition.TopMiddle, HandlePosition.TopRight }.Contains(
                    handlePosition))
            {
                y1 += size.Height;
            }

            if (new[] { HandlePosition.BottomLeft, HandlePosition.BottomMiddle, HandlePosition.BottomRight }.Contains(
                    handlePosition))
            {
                y2 += size.Height;
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
        }


        public abstract void Draw(Graphics graphics);

        protected void DrawHandles(Graphics graphics)
        {
            Handles.ForEach(handle => handle.Draw(graphics));
        }

    }
}
