using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace FakePowerPoint
{
    public class Rectangle : IShape
    {
        public Color Color { get; set; } = Color.FromArgb(255, 132, 120, 222);
        public ShapeType ShapeType { get; set; } = ShapeType.Rectangle;
        public List<Tuple<int, int>> Coordinates { get; set; } = new List<Tuple<int, int>>();

        // brief: Constructor
        public Rectangle(int x1 = 0, int x2 = 0, int y1 = 0, int y2 = 0)
        {
            Coordinates.Add(new Tuple<int, int>(x1, y1));
            Coordinates.Add(new Tuple<int, int>(x2, y2));
        }

        // brief: Draw the shape

        public void Draw(IShapeDrawer drawer)
        {
            drawer.DrawRectangle(Color, ConvertToRectangle());
        }

        // brief: Get the coordinates of the shape

        public string GetCoordinates()
        {
            return
                $"({Coordinates[0].Item1}, {Coordinates[0].Item2}),\n({Coordinates[1].Item1}, {Coordinates[1].Item2})";
        }

        // brief: Convert the coordinates to a rectangle

        private System.Drawing.Rectangle ConvertToRectangle()
        {
            return new System.Drawing.Rectangle(Coordinates[0].Item1, Coordinates[0].Item2,
                Coordinates[1].Item1 - Coordinates[0].Item1, Coordinates[1].Item2 - Coordinates[0].Item2);
        }
    }
}
