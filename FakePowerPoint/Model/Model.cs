using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FakePowerPoint
{
    public class Model
    {
        // brief: Constructor
        public Model()
        {
            _shapeTypeDescriptions = new Dictionary<ShapeType, string>();
            _shapeTypeDescriptions.Add(ShapeType.Undefined, NOT_DEFINED);
            _shapeTypeDescriptions.Add(ShapeType.Rectangle, RECTANGLE);
            _shapeTypeDescriptions.Add(ShapeType.Line, LINE);

            Shapes = new List<Tuple<string, string, IShape>>();
            ShapeTypes = new List<string>(_shapeTypeDescriptions.Values);
            ShapeTypes.RemoveAt(0);
        }

        // brief: Add a shape to the model
        public void AddShape(string shape)
        {
            var temp = ShapeFactory.CreateShape(shape);
            Shapes.Add(new Tuple<string, string, IShape>(_shapeTypeDescriptions[temp.ShapeType], temp.GetCoordinates(),
                temp));
        }

        // brief: Remove a shape from the model
        public void RemoveShape(int index)
        {
            Shapes.RemoveAt(index);
        }

        // brief: Get the description of a shape type
        private readonly Dictionary<ShapeType, string> _shapeTypeDescriptions;

        public List<Tuple<string, string, IShape>> Shapes
        {
            get;
        }

        public List<string> ShapeTypes
        {
            get;
        }

        private const String NOT_DEFINED = "Undefined";
        private const String RECTANGLE = "Rectangle";
        private const String LINE = "Line";
    }
}
