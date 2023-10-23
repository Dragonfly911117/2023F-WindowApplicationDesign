using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FakePowerPoint
{
    public class Model
    {
        // brief: Add a shape to the model
        public void AddShape(string shape)
        {
            var temp = ShapeFactory.CreateShape(shape);
            Shapes.Add(temp);
        }

        public void AddShape(IShape shape)
        {
            Shapes.Add(shape);
        }

        // brief: Remove a shape from the model
        public void RemoveShape(int index)
        {
            if (index >= 0 && index < Shapes.Count)
                Shapes.RemoveAt(index);
        }

        public BindingList<IShape> Shapes { get; } = new BindingList<IShape>();
    }
}
