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
            foreach (var handle in Handles)
            {
                handle.Move(new Point(dx, dy));
            }
        }

        public void Resize(Point coordinates, HandlePosition handlePosition)
        {
            var x1 = Coordinates.Item1.X;
            var y1 = Coordinates.Item1.Y;
            var x2 = Coordinates.Item2.X;
            var y2 = Coordinates.Item2.Y;
            switch (handlePosition)
            {
                case HandlePosition.TopLeft:
                    Coordinates = new Tuple<Point, Point>(coordinates, new Point(x2, y2));
                    break;
                case HandlePosition.TopMiddle:
                    Coordinates = new Tuple<Point, Point>(new Point(x1, coordinates.Y), new Point(x2, y2));
                    break;
                case HandlePosition.TopRight:
                    Coordinates = new Tuple<Point, Point>(new Point(x1, coordinates.Y), coordinates);
                    break;
                case HandlePosition.MiddleLeft:
                    Coordinates = new Tuple<Point, Point>(new Point(coordinates.X, y1), new Point(x2, y2));
                    break;
                case HandlePosition.MiddleRight:
                    Coordinates = new Tuple<Point, Point>(new Point(x1, y1), new Point(coordinates.X, y2));
                    break;
                case HandlePosition.BottomLeft:
                    Coordinates = new Tuple<Point, Point>(new Point(coordinates.X, y1), new Point(x2, coordinates.Y));
                    break;
                case HandlePosition.BottomMiddle:
                    Coordinates = new Tuple<Point, Point>(new Point(x1, y1), new Point(x2, coordinates.Y));
                    break;
                case HandlePosition.BottomRight:
                    Coordinates = new Tuple<Point, Point>(new Point(x1, y1), coordinates);
                    break;
            }

            {
                x1 = Coordinates.Item1.X;
                y1 = Coordinates.Item1.Y;
                x2 = Coordinates.Item2.X;
                y2 = Coordinates.Item2.Y;
                Handles = new List<Handle>
                {
                    new Handle(new Point(x1, y1), HandlePosition.TopLeft),
                    new Handle(new Point((x1 + x2) / 2, y1), HandlePosition.TopMiddle),
                    new Handle(new Point(x2, y1), HandlePosition.TopRight),
                    new Handle(new Point(x1, (y1 + y2) / 2), HandlePosition.MiddleLeft),
                    new Handle(new Point(x2, (y1 + y2) / 2), HandlePosition.MiddleRight),
                    new Handle(new Point(x1, y2), HandlePosition.BottomLeft),
                    new Handle(new Point((x1 + x2) / 2, y2), HandlePosition.BottomMiddle),
                    new Handle(new Point(x2, y2), HandlePosition.BottomRight)
                };
            }
        }

        public abstract void Draw(System.Drawing.Graphics graphics);


        protected void DrawHandles(Graphics graphics)
        {
            Handles.ForEach(handle => handle.Draw(graphics));
        }
    }
}
