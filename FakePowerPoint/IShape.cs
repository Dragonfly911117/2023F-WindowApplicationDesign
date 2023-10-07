using System;
using System.Collections.Generic;
using System.Drawing;

namespace FakePowerPoint
{
    public enum ShapeType
    {
        Undefined,
        Rectangle,
        Line
    }



    public interface IShape
    {
        Color Color { get; set; }
        ShapeType ShapeType { get; set; }
        List<Tuple<int, int>> Coordinates { get; set; }

        void Draw(IShapeDrawer drawer);
        String GetCoordinates();
    }

    public abstract class ShapeFactory
    {
        public static IShape CreateShape(string shapeType)
        {
            return shapeType switch
            {
                "Rectangle" => new Rectangle(),
                "Line" => new Line(),
                _ => throw new ArgumentException("Invalid shape type")
            };
        }
    }
}
