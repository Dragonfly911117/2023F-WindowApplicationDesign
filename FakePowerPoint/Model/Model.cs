using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using FakePowerPoint.Model.Enums;
using FakePowerPoint.Model.Shape.Factory;

namespace FakePowerPoint.Model
{
    public class Model
    {
        List<Slide> _slides = new();
        Slide _currentSlide;
        Random _random = new();
        BindingList<Shape.Shape> _currentShapes = new();

        public Model()
        {
            _slides.Add(new Slide(new Size(1000, 1000)));
            _currentSlide = _slides[0];
            _currentShapes.RaiseListChangedEvents = true;
            _currentShapes.ListChanged += (sender, args) => Repaint();
            _currentSlide.SetShapes(_currentShapes);
        }

        protected Point GetRandomPoint(Size size)
        {
            return new Point(_random.Next(size.Width), _random.Next(size.Height));
        }

        public void AddShape(ShapeType shapeType, Tuple<Point, Point> coordinates = null, Color color = default, int index = -1)
        {
            var size = _currentSlide.GetSize();
            coordinates ??= new Tuple<Point, Point>(GetRandomPoint(size), GetRandomPoint(size));
            if (shapeType == ShapeType.Undefined) return;
            var shapeFactory = _shapeFactories[shapeType];
            var shape = shapeFactory.CreateShape(coordinates, color);
            _currentSlide.AddShape(shape, index);
        }

        public void RemoveShape(int index)
        {
            _currentSlide.RemoveShape(index);
        }

        public void RemoveShape(Shape.Shape shape)
        {
            _currentSlide.RemoveShape(shape);
        }


        readonly Dictionary<ShapeType, ShapeFactory> _shapeFactories = new Dictionary<ShapeType, ShapeFactory>
        {
            { ShapeType.Line, new LineFactory() },
            { ShapeType.Rectangle, new RectangleFactory() },
            { ShapeType.Ellipse, new EllipseFactory() }
        };

        public void Repaint()
        {
            _currentSlide.Draw();
        }

        public Bitmap GetCurrentSlideBitmap()
        {
            return _currentSlide.GetBitmap();
        }

        public ref BindingList<Shape.Shape> GetShapes()
        {
            return ref _currentShapes;
        }

        public void SetShapes(BindingList<Shape.Shape> value)
        {
            _currentSlide.SetShapes(value);
        }
    }
}
