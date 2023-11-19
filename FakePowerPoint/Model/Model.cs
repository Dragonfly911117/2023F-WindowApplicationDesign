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

        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public Model(IRandomNumberGenerator randomNumberGenerator)
        {
            this._randomNumberGenerator = randomNumberGenerator;
        }


        public IShape CreateShape(ShapeType shapeType, List<int> coordinates = null)
        {
            var factory = _shapeFactories[shapeType];

            if (coordinates == null)
            {
                coordinates = new List<int>
                {
                    _randomNumberGenerator.GenerateRandomNumber(0, CANVAS_WIDTH),
                    _randomNumberGenerator.GenerateRandomNumber(0, CANVAS_HEIGHT),
                    _randomNumberGenerator.GenerateRandomNumber(0, CANVAS_WIDTH),
                    _randomNumberGenerator.GenerateRandomNumber(0, CANVAS_HEIGHT)
                };
            }

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
