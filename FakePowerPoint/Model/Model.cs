using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace FakePowerPoint
{
    public class Model
    {
        private const int CANVAS_WIDTH = 1358;
        private const int CANVAS_HEIGHT = 1052;

        private static Random _random = new Random();

        // Method to generate a random number
        public int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Method to set the random number generator since unit tests can't use the default random number generator
        public void SetRandom(Random random)
        {
            _random = random;
        }

        // Method to create a shape
        public IShape CreateShape(ShapeType shapeType, List<int> coordinates = null)
        {
            var factory = _shapeFactories[shapeType];

            coordinates ??= new List<int>
            {
                GenerateRandomNumber(0, CANVAS_WIDTH),
                GenerateRandomNumber(0, CANVAS_HEIGHT),
                GenerateRandomNumber(0, CANVAS_WIDTH),
                GenerateRandomNumber(0, CANVAS_HEIGHT)
            };

            return factory.CreateShape(coordinates);
        }

        // Creates and adds a shape of the specified type to the Shapes list.
        public void AddShape(ShapeType shape, List<int> coordinates = null)
        {
            Shapes.Add(CreateShape(shape, coordinates));
        }

        // Adds a provided shape to the Shapes list.
        public void AddShape(IShape shape)
        {
            Shapes.Add(shape);
        }

        // Removes the shape at the specified index from the Shapes list if it exists.
        public void RemoveShape(int index)
        {
            if (index >= 0 && index < Shapes.Count)
                Shapes.RemoveAt(index);
        }

        // Data-binding enabled list of shapes.
        public BindingList<IShape> Shapes { get; } = new BindingList<IShape>();

        private readonly Dictionary<ShapeType, ShapeFactory> _shapeFactories = new Dictionary<ShapeType, ShapeFactory>
        {
            { ShapeType.Line, new LineFactory() },
            { ShapeType.Rectangle, new RectangleFactory() },
            { ShapeType.Eclipse, new EclipseFactory() }
        };
    }
}
