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
            _shapeTypeDescriptions.Add(ShapeType.Undefined, ShapeFactory.NOT_DEFINED);
            _shapeTypeDescriptions.Add(ShapeType.Rectangle, ShapeFactory.RECTANGLE);
            _shapeTypeDescriptions.Add(ShapeType.Line, ShapeFactory.LINE);

            Shapes = new BindingList<IShape>();
            ShapeTypes = new List<string>(_shapeTypeDescriptions.Values);
            ShapeTypes.RemoveAt(0);
        }

        // brief: Add a shape to the model
        public void AddShape(string shape)
        {
            var temp = ShapeFactory.CreateShape(shape);
            Shapes.Add(temp);
        }

        // brief: Remove a shape from the model
        public void RemoveShape(int index)
        {
            if (index < 0 || index >= Shapes.Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }

        // brief: Get the description of a shape type
        private readonly Dictionary<ShapeType, string> _shapeTypeDescriptions;

        public BindingList<IShape> Shapes { get; }

        public List<string> ShapeTypes { get; }
    }
}
