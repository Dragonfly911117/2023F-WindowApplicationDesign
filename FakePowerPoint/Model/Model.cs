using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FakePowerPoint
{
    public class Model
    {
        public void AddShape(ShapeType shape)
        {
            var temp = ShapeFactory.CreateShape(shape);
            Shapes.Add(temp);
        }

        public void AddShape(IShape shape)
        {
            Shapes.Add(shape);
        }

        public void RemoveShape(int index)
        {
            if (index >= 0 && index < Shapes.Count)
                Shapes.RemoveAt(index);
        }

        public BindingList<IShape> Shapes { get; } = new BindingList<IShape>();
    }
}
