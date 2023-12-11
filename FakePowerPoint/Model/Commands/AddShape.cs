using System;
using System.Drawing;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Model.Commands
{
    public class AddShape : Command
    {
        readonly ShapeType _shapeType;
        Tuple<Point, Point> _coordinates;
        Color _color;
        int _index;
        Shape.Shape _shape;

        public AddShape(Model receiver, ShapeType shapeType, Tuple<Point, Point> coordinates = null,
            Color color = default, int index = -1, Shape.Shape shape = default)
            : base(receiver)
        {
            _shapeType = shapeType;
            _coordinates = coordinates;
            _color = color;
            _index = index;
            _shape = shape;
        }

        public override void Execute()
        {
            Receiver.AddShape(_shapeType, _coordinates, _color, _index);
            if (_index == -1)
            {
                _index = Receiver.GetShapes().Count - 1;
            }

            _shape ??= Receiver.GetShapes()[_index];
            _coordinates = _shape.GetCoordinates();
            _color = _shape.GetColor();
        }

        public override void UnExecute()
        {
            Receiver.RemoveShape(_index);
        }
    }
}
