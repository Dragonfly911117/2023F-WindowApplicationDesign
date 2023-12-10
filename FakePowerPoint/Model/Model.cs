using System;
using System.Collections.Generic;
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

        public Model()
        {
            _slides.Add(new Slide(new Size(1000, 1000)));
            _currentSlide = _slides[0];
        }

        protected Point GetRandomPoint(Size size)
        {
            return new Point(_random.Next(size.Width), _random.Next(size.Height));
        }

        public void AddShape(ShapeType shaptype, Tuple<Point, Point> coordinates = null,
            Color color = default(Color))
        {
            var size = _currentSlide.GetSize();
            coordinates ??= new Tuple<Point, Point>(GetRandomPoint(size), GetRandomPoint(size));
            if (shaptype == ShapeType.Undefined) return;
            ShapeFactory shapeFactory = _shapeFactories[shaptype];
            Shape.Shape shape = shapeFactory.CreateShape(coordinates, color);
            _currentSlide.AddShape(shape);
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
    }
}
