using System.Drawing;

namespace FakePowerPoint.Model.Shape
{
    public class Handle
    {
        Point _coordinate;
        Enums.HandlePosition _position;
        bool _selected = false;

        public Handle(Point coordinate, Enums.HandlePosition position)
        {
            _coordinate = coordinate;
            _position = position;
        }

        public void Draw(System.Drawing.Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(Color.LightGray), _coordinate.X - 5, _coordinate.Y - 5, 10, 10);
        }

        public Enums.HandlePosition GetPosition()
        {
            return _position;
        }

        public Point GetCoordinate()
        {
            return _coordinate;
        }

        public bool GetSelected()
        {
            return _selected;
        }

        public void SetSelected(bool selected)
        {
            _selected = selected;
        }

        public bool IfClicked(Point coordinates)
        {
            return coordinates.X >= _coordinate.X - 5 && coordinates.X <= _coordinate.X + 5 &&
                   coordinates.Y >= _coordinate.Y - 5 && coordinates.Y <= _coordinate.Y + 5;
        }

        public void Move(Point delta)
        {
            _coordinate = new Point(_coordinate.X + delta.X, _coordinate.Y + delta.Y);
        }
    }
}
