using System;
using System.Collections.Generic;
using System.Drawing;
using FakePowerPoint.Model.Enums;
using FakePowerPoint.Model.Shape.Factory;

namespace FakePowerPoint.Model
{
    public class Model
    {
        List<Shape.Shape> _shapes;
        Random _random;

        public Model()
        {
            _shapes = new List<Shape.Shape>();
            _random = new Random();
        }

        protected Point GetRandomPoint(int xMax, int yMax)
        {
            return new Point(_random.Next(xMax), _random.Next(yMax));
        }

        public void AddShape(string shapeSelectorText, Tuple<Point, Point> coordinates = null,
            Color color = default(Color))
        {
            if (coordinates == null)
            {// TODO store curr window size
                coordinates = new Tuple<Point, Point>(GetRandomPoint(1000, 1000), GetRandomPoint(1000, 1000));
            }
            ShapeType shapeType = (ShapeType)Enum.Parse(typeof(ShapeType), shapeSelectorText);
            ShapeFactory shapeFactory = _shapeFactories[shapeType];
            Shape.Shape shape = shapeFactory.CreateShape(coordinates, color);
            _shapes.Add(shape);
        }


        private readonly Dictionary<ShapeType, ShapeFactory> _shapeFactories = new Dictionary<ShapeType, ShapeFactory>
        {
            { ShapeType.Line, new LineFactory() },
            { ShapeType.Rectangle, new RectangleFactory() },
            { ShapeType.Ellipse, new EllipseFactory() }
        };
    }
}
