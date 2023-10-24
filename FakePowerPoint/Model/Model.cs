using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FakePowerPoint
{
    public class Model
    {
        // Creates and adds a shape of the specified type to the Shapes list.
        public void AddShape(ShapeType shape)
        {
            var temp = ShapeFactory.CreateShape(shape);
            Shapes.Add(temp);
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
    }
}
