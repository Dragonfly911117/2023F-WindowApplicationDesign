using System;
using System.Collections.Generic;
using System.Drawing;
using FakePowerPoint.Model.Commands;
using FakePowerPoint.Model.Enums;
using FakePowerPoint.Model.Shape;
using FakePowerPoint.Model.Shape.Factory;
using FakePowerPoint.Properties;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        Bitmap _bitmap;
        ShapeType _shapeType = ShapeType.Undefined;

        public void Repaint()
        {
            _model.Repaint();
            var temp = _model.GetCurrentSlideBitmap();
            if (_tempShape != null)
            {
                var graphics = Graphics.FromImage(_bitmap);
                _tempShape.Draw(graphics);
            }
            SlideBitmap = temp;
        }

        public Size NormalizeSize(Size slidePanelSize)
        {
            const double ASPECT_RATIO = 16.0 / 9.0;
            slidePanelSize.Height = (int)(slidePanelSize.Width / ASPECT_RATIO);

            return slidePanelSize;
        }

        void DropPen(Point normalizedPoint)
        {
            _coordinates = new Tuple<Point, Point>(normalizedPoint, normalizedPoint);
        }
        void DrawShape(Point normalizedPoint)
        {
            if (_coordinates == null)
                return;
            _coordinates = new Tuple<Point, Point>(_coordinates.Item1, normalizedPoint);
            _tempShape = _shapeFactories[_shapeType].CreateShape(_coordinates);
            Repaint();
        }

        Shape _tempShape;
        Tuple<Point, Point> _coordinates;
        readonly Dictionary<ShapeType, ShapeFactory> _shapeFactories = new()
        {
            { ShapeType.Line, new LineFactory() },
            { ShapeType.Rectangle, new RectangleFactory() },
            { ShapeType.Ellipse, new EllipseFactory() }
        };

        void PickUpThePen(Point normalizedPoint)
        {
            DrawShape(normalizedPoint);
            var command = new AddShape(_model, _shapeType, _coordinates);
            command.Execute();
            Dos[0] = true;
            _undo.Clear();
            Dos[1] = false;
            _command.Push(command);
            _tempShape = null;
            _coordinates = null;
            _shapeType = ShapeType.Undefined;
            UpdateSelected();
            Repaint();
        }

        void SelectShape(Point normalizedPoint)
        {
            _selectedShapeIndex = _model.GetShapeIndex(normalizedPoint);
            Repaint();
        }
        int _selectedShapeIndex = -1;
    }
}
