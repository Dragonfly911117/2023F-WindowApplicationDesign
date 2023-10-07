using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FakePowerPoint
{
    public class Model
    {
        public Model()
        {
            // remove the first item in the list, which is undefined
            ShapeTypes = new List<string>(ShapeTypeDescriptions.Values);
            ShapeTypes.RemoveAt(0);
        }

        public void AddShape(string shape)
        {
            var temp = ShapeFactory.CreateShape(shape);
            Shapes.Add(new Tuple<string, string, IShape>(ShapeTypeDescriptions[temp.ShapeType], temp.GetCoordinates(), temp));
        }

        public void RemoveShape(int index)
        {
            Shapes.RemoveAt(index);
        }

        public static readonly Dictionary<ShapeType, string> ShapeTypeDescriptions = new Dictionary<ShapeType, string>
        {
            { ShapeType.Undefined, "Undefined" }, { ShapeType.Rectangle, "Rectangle" }, { ShapeType.Line, "Line" }
        };

        public List<Tuple<String, String, IShape>> Shapes { get; } = new List<Tuple<String, String, IShape>>();
        public List<String> ShapeTypes { get; set; }
    }
}
